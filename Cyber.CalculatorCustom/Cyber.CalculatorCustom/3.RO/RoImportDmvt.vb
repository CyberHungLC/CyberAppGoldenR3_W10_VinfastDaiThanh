Public Class RoImportDmvt
    Dim DrReturn As DataRow
    Dim DsLookup As DataSet
    Dim FileName As String
    Dim DsData As New DataSet
    Dim tbMaster, tbHeader As New DataTable
    Dim DvMaster, DvHeader As New DataView
    Private Sub ROCLOSE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        V_Load()
        V_AddHandler()
        CyberSupport.Translaste(Me, M_LAN, True)
    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_Load()
        DsData = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoGetListDmVT", M_Ma_Dvcs & "#" & M_User_Name)
        tbMaster = DsData.Tables(0)
        tbHeader = DsData.Tables(1)
        DvMaster = New DataView(tbMaster)
        DvHeader = New DataView(tbHeader)
        CyberFill.V_FillReports(Master1GRV, M_LAN, DvHeader, DvMaster)
        Master1GRV.GridControl.DataSource = DvMaster
    End Sub
    Private Sub V_AddHandler()
        AddHandler ButtOK.Click, AddressOf V_Nhan
        AddHandler CmdSelectFile.Click, AddressOf V_SelectFile
    End Sub
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Save_OK = False
        tbMaster.AcceptChanges()
        CyberSmodb.SetNotNullTable(tbMaster)
        tbMaster.AcceptChanges()
        Dim DsXML As New DataSet
        Dim tbXML As DataTable = tbMaster.Copy
        tbXML.TableName = "DMVT"
        For Each Col As DataColumn In tbXML.Columns
            Col.ColumnName = Col.ColumnName.ToUpper
        Next
        DsXML.Tables.Add(tbXML)
        Dim M_StrXML As String = DsXML.GetXml()
        M_StrXML = M_StrXML.Replace("<NewDataSet>", "")
        M_StrXML = M_StrXML.Replace("</NewDataSet>", "")
        If Not CyberLoading.IsShowWaitFrom Then CyberLoading.V_ShowWailtForm(M_LAN)
        Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure( _
            AppConn, _
            "CP_RoImportDmvt", _
            M_StrXML & "#" & M_Ma_Dvcs & "#" & M_User_Name)
        If CyberLoading.IsShowWaitFrom Then CyberLoading.V_CloseWailtForm()
        If DsTmp.Tables.Count > 0 Then
            If Not CyberSupport.V_MsgChk(DsTmp.Tables(0), Sysvar, M_LAN) Then
                DsTmp.Dispose()
                Exit Sub
            End If
        End If

        DsTmp.Dispose()

        MsgBox("Đã thực hiện xong", MsgBoxStyle.OkOnly, Sysvar("M_CYBER_VER"))
        CyberSmlib.FlushMemorySave()
        Me.Close()
    End Sub
    Private Sub V_SelectFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tbImport As DataTable
        tbImport = CyberExport.V_ImportDataToGridview(AppConn, Sysvar, Para, Master1GRV, tbMaster, M_LAN)
        If tbImport Is Nothing Then Exit Sub
        For Each dr As DataRow In tbImport.Select("Ma_Phu1<>''")
            tbMaster.ImportRow(dr)
        Next
        tbMaster.AcceptChanges()
    End Sub
End Class
