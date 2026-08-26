Imports System.Xml
Imports Newtonsoft.Json
Imports System.Net
Imports System.IO
Imports RestSharp
Imports System.Globalization
Imports System.Reflection
Imports System.Collections.Concurrent
Imports System.Text

Public Class supportInvoiceVNPT
    Dim _Error As New Dictionary(Of String, String)
    Public Sub New()
        _Error.Add("ERR:1", "Tài khoản đăng nhập sai hoặc không có quyền ")
        _Error.Add("ERR:2", "Hóa đơn cần điều chỉnh không tồn tại ")
        _Error.Add("ERR:3", "Dữ liệu xml đầu vào không đúng quy định ")
        _Error.Add("ERR:4", "Công ty chưa được đăng kí mẫu hóa đơn nào")
        _Error.Add("ERR:5", "Không phát hành được hóa đơn")
        _Error.Add("ERR:6", "Không đủ số hóa đơn cho lô phát hành ")
        _Error.Add("ERR:7", "User name không phù hợp, không tìm thấy company tương ứng cho user. ")
        _Error.Add("ERR:8", "Hóa đơn cần điều chỉnh đã bị thay thế. Không thể điều chỉnh/thay thế được nữa. ")
        _Error.Add("ERR:9", "Trạng thái hóa đơn không được điều chỉnh/thay thế ")
        _Error.Add("ERR:10", "Lô có số hóa đơn vượt quá max cho phép ")
        _Error.Add("ERR:11", "Hóa đơn chưa thanh toán nên không xem được")
        _Error.Add("ERR:12", "")
        _Error.Add("ERR:13", "Hóa đơn đã được gạch nợ")
        _Error.Add("ERR:14", "")
        _Error.Add("ERR:15", "")
        _Error.Add("ERR:16", "")
        _Error.Add("ERR:17", "")
        _Error.Add("ERR:18", "")
        _Error.Add("ERR:19", "")
        _Error.Add("ERR:20", "Pattern và serial không phù hợp, hoặc không tồn tại hóa đơn đ ã đăng kí có sử dụng Pattern và serial truyền vào ")
        _Error.Add("ERR:22", "Trùng số hóa đơn")

    End Sub
#Region "HDDT"
    Public Function V_GenToken(ByVal urlLogin As String, ByVal username As String, ByVal pass As String) As String
        Dim reponse As String = ""
        Dim token As String = ""
        Dim err As String = ""
        Dim body As String = "{""username"":""" + username + """,""password"": """ + pass + """}"
        If V_CallApi(urlLogin, Method.POST, Nothing, body, reponse, err) Then
            Dim dicObjResponse As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(reponse)
            If dicObjResponse.ContainsKey("data") Then
                Dim objToken As Object = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(dicObjResponse("data").ToString)
                Return objToken("access_token").ToString + "#" + objToken("clientId").ToString
            End If
        End If
        Return token
    End Function

    Public Function V_TaoHoaDon(ByVal ds As DataSet) As DataSet
        Dim objVat As InvoiceVatRequest = BinddingObjInvoice(ds.Tables(0),
                                                             ds.Tables(2),
                                                             ds.Tables(3),
                                                             ds.Tables(4),
                                                             ds.Tables(5),'
                                                             ds.Tables(6),'
                                                             ds.Tables(7),'
                                                             ds.Tables(8), ds.Tables(9), ds.Tables(10))
        Dim json As String = JsonConvert.SerializeObject(objVat)

        Dim header As New Dictionary(Of String, String)

        Dim result As String = V_GenToken(ds.Tables(0).Rows(0)("UrlLogin").ToString(), ds.Tables(0).Rows(0)("User_name").ToString(), ds.Tables(0).Rows(0)("password").ToString())
        Dim token As String = result.Split("#")(0)
        Dim client_id As String = result.Split("#")(1)
        If String.IsNullOrEmpty(token) Then
            MsgBox("Không lấy được token")
            Return Nothing
        End If
        header.Add("authorization", token)
        header.Add("client-id", client_id)
        header.Add("content-type", "application/json")
        Dim response As String = ""
        Dim err As String = ""

        If V_CallApi(ds.Tables(0).Rows(0)("URLPost").ToString(), Method.POST, header, json, response, err) Then
            'MsgBox(response + err)
            Return ReadDataFromJson(response)
        End If

        MsgBox(response + err)

        Return Nothing
    End Function
    Public Function ReadDataFromJson(ByVal jsonString As String,
                         Optional ByVal mode As XmlReadMode = XmlReadMode.Auto) As DataSet
        jsonString = jsonString.Trim()

        ' Nếu JSON là ARRAY → bọc trực tiếp vào rootNode
        If jsonString.StartsWith("[") Then
            ' Bọc JSON array thành object:  { "rootNode": [...] }
            jsonString = "{ ""rootNode"": " & jsonString & " }"

            Dim xdArray As XmlDocument = JsonConvert.DeserializeXmlNode(jsonString, "rootNode")
            RemoveNodesWithNullOrEmptyValue(xdArray.DocumentElement)

            Dim resultArr As New DataSet()
            resultArr.ReadXml(New XmlNodeReader(xdArray), mode)
            Return resultArr
        Else
            ' JSON là object → dùng logic cũ, chỉ bọc lại để chắc chắn dạng object
            jsonString = $"{{ ""rootNode"": {{{jsonString.Trim().TrimStart("{"c).TrimEnd("}"c)}}} }}"
            Dim xd As XmlDocument = JsonConvert.DeserializeXmlNode(jsonString)
            RemoveNodesWithNullOrEmptyValue(xd.DocumentElement)
            Dim result = New DataSet()
            result.ReadXml(New XmlNodeReader(xd), mode)
            Return result
        End If
        'jsonString = $"{{ ""rootNode"": {{{jsonString.Trim().TrimStart("{"c).TrimEnd("}"c)}}} }}"
    End Function
    Private Sub RemoveNodesWithNullOrEmptyValue(ByVal node As XmlNode)
        If node Is Nothing Then Return
        Dim nodesToRemove = New List(Of XmlNode)()

        For Each child As XmlNode In node.ChildNodes
            If String.IsNullOrEmpty(child.InnerText) Then
                nodesToRemove.Add(child)
            ElseIf child.InnerText.ToUpper = "TRUE" Then
                child.InnerText = "1"
            ElseIf child.InnerText.ToUpper = "FALSE" Then
                child.InnerText = "0"
            Else
                RemoveNodesWithNullOrEmptyValue(child)
            End If
        Next

        For Each child In nodesToRemove
            node.RemoveChild(child)
        Next
    End Sub
    Public Function ToCurlCommand(ByVal client As RestClient, ByVal request As RestRequest) As String
        Dim sb = New StringBuilder()
        sb.Append("curl")
        Dim method = request.Method.ToString().ToUpperInvariant()
        sb.Append(" -X ").Append(method)
        Dim url = client.BuildUri(request)
        sb.Append(" """).Append(EscapeDoubleQuotes(url.ToString())).Append("""")
        Dim headers = request.Parameters.Where(Function(p) p.Type = ParameterType.HttpHeader).ToList()

        For Each header In headers
            Dim name = If(header.Name, "")
            Dim value = If(header.Value?.ToString(), "")
            sb.Append(" -H """).Append(EscapeDoubleQuotes(name)).Append(": ").Append(EscapeDoubleQuotes(value)).Append("""")
        Next

        Dim body = request.Parameters.FirstOrDefault(Function(p) p.Type = ParameterType.RequestBody)

        If body?.Value IsNot Nothing Then
            sb.Append(" --data-raw '").Append(EscapeSingleQuotes(body.Value.ToString())).Append("'")
            Return sb.ToString()
        End If

        Dim formParams = request.Parameters.Where(Function(p) p.Type = ParameterType.GetOrPost).ToList()

        If formParams.Count > 0 Then
            Dim formBody = String.Join("&", formParams.[Select](Function(p) $"{Uri.EscapeDataString(If(p.Name, ""))}={Uri.EscapeDataString(If(p.Value?.ToString(), ""))}"))
            sb.Append(" --data-raw '").Append(EscapeSingleQuotes(formBody)).Append("'")
        End If

        Return sb.ToString()
    End Function

    Private Function EscapeSingleQuotes(ByVal value As String) As String
        Return value.Replace("'", "'""'""'")
    End Function

    Private Function EscapeDoubleQuotes(ByVal value As String) As String
        Return value.Replace("""", "\""")
    End Function
    Public Function V_CallApi(ByVal url As String, ByVal method As Method, ByVal headers As Dictionary(Of String, String), ByVal body As String, ByRef strResponse As String, ByRef err As String, Optional ByVal contentType As String = "application/json") As Boolean

        Try
            System.Net.ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12

            Dim client As New RestClient(url)
            Dim request As New RestRequest("", method)

            ' Add headers
            If headers IsNot Nothing Then
                For Each kv As KeyValuePair(Of String, String) In headers
                    request.AddHeader(kv.Key, kv.Value)
                Next
            End If

            ' Add body JSON
            If contentType.Trim().ToUpper() =
               "application/json".Trim().ToUpper() Then

                If Not String.IsNullOrEmpty(body) Then
                    request.AddParameter(
                        "application/json",
                        body,
                        ParameterType.RequestBody
                    )
                End If
            End If
            'MsgBox(url)

            '--> Msgbox để check
            'MsgBox(ToCurlCommand(client, request))

            '--> Copy to Clipboard để check
            My.Computer.Clipboard.SetText(ToCurlCommand(client, request))

            Dim response As RestResponse = client.Execute(request)
            'MsgBox(response.StatusCode.ToString)
            'MsgBox(response.Content.ToString)
            If response.StatusCode = HttpStatusCode.OK Then
                strResponse = response.Content
                err = ""
                Return True
            Else
                err = If(
                    response.ErrorMessage,
                    If(
                        response.StatusDescription,
                        "Unknown error"
                    )
                )

                err &= If(response.Content, "")
                strResponse = Nothing
                Return False
            End If

        Catch ex As Exception
            err = ex.Message
            strResponse = Nothing

            Return False
        End Try

    End Function
#End Region

#Region "Bindding object"
    Private Function BinddingObjInvoice(ByVal dtPH As DataTable, ByVal dtHoaDon As DataTable, ByVal dtBuyer As DataTable, ByVal dtSeller As DataTable, ByVal dtBke As DataTable, ByVal dtCt As DataTable, ByVal dtCk As DataTable, ByVal dtPayment As DataTable, ByVal dtThueSuat As DataTable, ByVal dtThuePhi As DataTable) As InvoiceVatRequest
        Dim objReturn As InvoiceVatRequest = New InvoiceVatRequest
        If dtPH.Rows.Count > 0 Then

            Bindings(objReturn, dtPH.Rows(0))
        End If

        objReturn.HDons = New List(Of InvoiceVat)()

        Dim invoiceVat As New InvoiceVat
        If dtHoaDon.Rows.Count > 0 Then
            Bindings(invoiceVat, dtHoaDon.Rows(0))
        End If

        If dtBuyer.Rows.Count > 0 Then
            Dim buyer As New BuyerInfo
            Bindings(buyer, dtBuyer.Rows(0))
            invoiceVat.NMua = buyer
        End If

        If dtSeller.Rows.Count > 0 Then
            Dim seller As New SellerInfo
            Bindings(seller, dtSeller.Rows(0))
            invoiceVat.NBan = seller
        End If
        If dtBke.Rows.Count > 0 Then
            Dim stateInfo As New StatementInfo
            Bindings(stateInfo, dtBke.Rows(0))
            invoiceVat.BKe = stateInfo
        End If

        If dtCt.Rows.Count > 0 Then
            Dim HHDVu As New List(Of ProductInfo)
            HHDVu = ToListObject(Of ProductInfo)(dtCt)
            invoiceVat.HHDVu = HHDVu
        End If

        If dtPayment.Rows.Count > 0 Then
            Dim payment As New PaymentInfo
            Bindings(payment, dtPayment.Rows(0))
            invoiceVat.TToan = payment
        End If

        If dtThueSuat.Rows.Count > 0 Then
            Dim TTSuat As New List(Of TaxSummaryInfo)
            TTSuat = ToListObject(Of TaxSummaryInfo)(dtThueSuat)
            invoiceVat.THTTLTSuat = TTSuat
        End If

        objReturn.HDons.Add(invoiceVat)
        Return objReturn
    End Function


    Private ReadOnly PropertyCache As New ConcurrentDictionary(Of Type, Dictionary(Of String, PropertyInfo))()

    Private Shared ReadOnly PropertyCacheTable As New ConcurrentDictionary(Of Type, PropertyInfo())()

    Public Function ToListObject(Of T As New)(table As DataTable) As List(Of T)
        Dim result As New List(Of T)()

        If table Is Nothing OrElse table.Rows.Count = 0 Then
            Return result
        End If

        Dim properties As Dictionary(Of String, PropertyInfo) =
            PropertyCache.GetOrAdd(
                GetType(T),
                Function(type) type _
                    .GetProperties(BindingFlags.Public Or BindingFlags.Instance) _
                    .Where(Function([property]) [property].CanWrite) _
                    .ToDictionary(
                        Function([property]) [property].Name,
                        Function([property]) [property],
                        StringComparer.OrdinalIgnoreCase)
            )

        For Each row As DataRow In table.Rows
            Dim item As New T()

            For Each column As DataColumn In table.Columns
                Dim [property] As PropertyInfo = Nothing

                If Not properties.TryGetValue(column.ColumnName, [property]) Then
                    Continue For
                End If

                Dim value As Object = row(column)

                If value Is Nothing OrElse value Is DBNull.Value Then
                    If Not [property].PropertyType.IsValueType OrElse
                       Nullable.GetUnderlyingType([property].PropertyType) IsNot Nothing Then

                        [property].SetValue(item, Nothing)
                    End If

                    Continue For
                End If

                Try
                    Dim targetType As Type =
                        If(
                            Nullable.GetUnderlyingType([property].PropertyType),
                            [property].PropertyType
                        )

                    Dim convertedValue As Object

                    If targetType Is GetType(String) Then
                        If TypeOf value Is DateTime Then
                            Dim [date] As DateTime = DirectCast(value, DateTime)

                            convertedValue =
                                If(
                                    [date] = New DateTime(1900, 1, 1),
                                    Nothing,
                                    [date].ToString(
                                        "yyyy-MM-dd'T'HH:mm:ss",
                                        CultureInfo.InvariantCulture)
                                )
                        Else
                            Dim text As String =
                                If(value.ToString(), String.Empty).Trim()

                            convertedValue =
                                If(
                                    String.IsNullOrEmpty(text),
                                    Nothing,
                                    text
                                )
                        End If

                    ElseIf targetType Is GetType(Guid) Then
                        convertedValue = Guid.Parse(value.ToString())

                    ElseIf targetType.IsEnum Then
                        convertedValue =
                            If(
                                TypeOf value Is String,
                                [Enum].Parse(
                                    targetType,
                                    value.ToString(),
                                    True),
                                [Enum].ToObject(
                                    targetType,
                                    value)
                            )

                    ElseIf targetType Is GetType(Boolean) Then
                        convertedValue = ConvertToBoolean(value)

                    Else
                        convertedValue =
                            Convert.ChangeType(
                                value,
                                targetType,
                                CultureInfo.InvariantCulture)
                    End If

                    [property].SetValue(item, convertedValue)

                Catch
                    ' Có thể ghi log theo tên cột nếu cần.
                End Try
            Next

            result.Add(item)
        Next

        Return result
    End Function

    Public Function Bindings(Of T As Class)(obj As T, row As DataRow) As Boolean
        If obj Is Nothing OrElse row Is Nothing Then
            Return False
        End If

        Dim objectType As Type = obj.GetType()

        Dim properties As Dictionary(Of String, PropertyInfo) =
        PropertyCache.GetOrAdd(
            objectType,
            AddressOf GetWritableProperties
        )

        For Each column As DataColumn In row.Table.Columns
            Dim [property] As PropertyInfo = Nothing

            If Not properties.TryGetValue(column.ColumnName, [property]) Then
                Continue For
            End If

            Dim value As Object = row(column)

            Try
                Dim convertedValue As Object =
                ConvertValue(value, [property].PropertyType)

                [property].SetValue(obj, convertedValue)
            Catch
                ' Có thể ghi log tại đây nếu cần.
                ' Không nên dùng MessageBox trong hàm mapping dữ liệu.
            End Try
        Next

        Return True
    End Function

    Private Function ConvertToBoolean(value As Object) As Boolean
        Dim text As String = If(value?.ToString(), String.Empty).Trim()

        If text = "1" OrElse
           String.Equals(text, "Y", StringComparison.OrdinalIgnoreCase) OrElse
           String.Equals(text, "YES", StringComparison.OrdinalIgnoreCase) OrElse
           String.Equals(text, "TRUE", StringComparison.OrdinalIgnoreCase) Then

            Return True
        End If

        If text = "0" OrElse
           String.Equals(text, "N", StringComparison.OrdinalIgnoreCase) OrElse
           String.Equals(text, "NO", StringComparison.OrdinalIgnoreCase) OrElse
           String.Equals(text, "FALSE", StringComparison.OrdinalIgnoreCase) Then

            Return False
        End If

        Return Convert.ToBoolean(value)
    End Function

    Private Function GetWritableProperties(type As Type) As Dictionary(Of String, PropertyInfo)
        Return type _
            .GetProperties(BindingFlags.Public Or BindingFlags.Instance) _
            .Where(Function([property]) [property].CanWrite) _
            .ToDictionary(
                Function([property]) [property].Name,
                Function([property]) [property],
                StringComparer.OrdinalIgnoreCase)
    End Function

    Private Function ConvertValue(value As Object, propertyType As Type) As Object
        Dim nullableType As Type = Nullable.GetUnderlyingType(propertyType)
        Dim targetType As Type = If(nullableType, propertyType)

        Dim allowNull As Boolean =
            Not propertyType.IsValueType OrElse
            nullableType IsNot Nothing

        If value Is Nothing OrElse value Is DBNull.Value Then
            Return If(
                allowNull,
                Nothing,
                Activator.CreateInstance(targetType)
            )
        End If

        '
        ' Xử lý chuỗi rỗng.
        '
        If TypeOf value Is String Then
            Dim text As String = DirectCast(value, String)

            If String.IsNullOrWhiteSpace(text) Then
                Return If(
                    allowNull,
                    Nothing,
                    Activator.CreateInstance(targetType)
                )
            End If
        End If

        '
        ' DataRow là DateTime nhưng property là String.
        '
        If TypeOf value Is DateTime AndAlso targetType Is GetType(String) Then
            Dim dateTimeValue As DateTime = DirectCast(value, DateTime)

            If dateTimeValue = New DateTime(1900, 1, 1) Then
                Return Nothing
            End If

            Return dateTimeValue.ToString(
                "yyyy-MM-dd'T'HH:mm:ss",
                CultureInfo.InvariantCulture)
        End If

        '
        ' Kiểu dữ liệu đã đúng với property.
        '
        If targetType.IsInstanceOfType(value) Then
            Return value
        End If

        '
        ' Chuyển sang String.
        '
        If targetType Is GetType(String) Then
            Return Convert.ToString(
                value,
                CultureInfo.InvariantCulture)
        End If

        '
        ' Chuyển Enum.
        '
        If targetType.IsEnum Then
            If TypeOf value Is String Then
                Return [Enum].Parse(
                    targetType,
                    value.ToString(),
                    True)
            End If

            Return [Enum].ToObject(
                targetType,
                value)
        End If

        '
        ' Chuyển Guid.
        '
        If targetType Is GetType(Guid) Then
            Return Guid.Parse(value.ToString())
        End If

        '
        ' Chuyển DateTime.
        '
        If targetType Is GetType(DateTime) Then
            Return Convert.ToDateTime(
                value,
                CultureInfo.InvariantCulture)
        End If

        '
        ' Chuyển Integer, Decimal, Double, Boolean...
        '
        Return Convert.ChangeType(
            value,
            targetType,
            CultureInfo.InvariantCulture)
    End Function
#End Region

End Class