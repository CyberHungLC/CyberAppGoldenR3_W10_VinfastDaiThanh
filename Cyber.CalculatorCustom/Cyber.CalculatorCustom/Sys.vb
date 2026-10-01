Imports System.Data.SqlClient
Public Class Sys
    Public Function Initvao(ByVal M_Para As String()) As Boolean
        Dim M_VT_PARA As Integer = CType(M_Para(0).Trim, Integer)
        Dim M_CP_Name As String = M_Para(M_VT_PARA + 1).Trim
        Dim M_User_Name As String = M_Para(6).Trim
        Dim M_Lan As String = M_Para(13).Trim
        Dim M_Ma_Dvcs As String = M_Para(14).Trim
        Dim M_Bar As String = M_Para(11).Trim
        Dim M_Bar2 As String = M_Para(12).Trim
        Dim _Title As String = "Đang thực hiện: " + M_Bar
        Dim _Title2 As String = "Processing: " + M_Bar2
        '------------------------------------------------------------------------------------------------------
        If M_CP_Name = "TOI_DIEU_HUONG_SANG_BAN_CHUAN" Then Return False
        '------------------------------------------------------------------------------------------------------
        '--CYBERSOFT Cho Phép bạn Hiệu chỉnh ở phần này
        '------------------------------------------------------------------------------------------------------
        Dim CyberSmlib As New Cyber.SmLib.Sys
        Dim CyberSupport As New Cyber.Support.Sys
        Dim CyberFill As New Cyber.Fill.Sys
        Dim CyberSmlistSys As New Cyber.SmLists.Sys
        Dim CyberSmodb As New Cyber.Smodb.Sys
        Dim CyberEport As New Cyber.Export.Sys
        Dim CyberVoucher As New Cyber.Voucher.Sys
        Dim CyberLoading = New Cyber.Loading.Loading
        Dim Appconn As SqlConnection = CyberSmlib.GetConn()
        Dim oSysvar As Collection = CyberSmlib.IniSysVar(Appconn, M_Ma_Dvcs, M_User_Name)
        M_CP_Name = M_CP_Name.Trim.ToUpper

        Dim Frm As Cyber.From.FrmCalculator
        Select Case M_CP_Name.ToUpper
            'GL
            Case "CP_RoHistory".ToUpper.ToString
                Frm = New RoHistory
            Case "CP_RoImportDmvt".ToUpper.ToString
                Frm = New RoImportDmvt
            Case "CP_UPDATEGIA2".ToUpper.ToString
                Frm = New RoUpdateGia
            Case "CP_ROUPDATE_LOAD".ToUpper.ToString
                Frm = New ROUPDL
                'Case "CP_Ro_Up_Hang".ToUpper.Trim

                '    Frm = New Ro_Up_Hang_Loc
                '    Frm.Lan = M_Lan
                '    Frm.Para = M_Para
                '    Frm.Sysvar = oSysvar
                '    Frm.AppConn = Appconn
                '    Frm.CyberSmlib = CyberSmlib
                '    Frm.CyberSupport = CyberSupport
                '    Frm.CyberFill = CyberFill
                '    Frm.CyberSmlistSys = CyberSmlistSys
                '    Frm.CyberSmodb = CyberSmodb
                '    Frm.CyberExport = CyberEport
                '    Frm.CyberVoucher = CyberVoucher
                '    Frm.CyberLoading = CyberLoading
                '    Frm.ShowDialog()

                '    If Not Frm.Save_OK Then Return True
                '    Dim _Ro_strParameterStore As String = Frm.Tag.ToString.Trim

                '    If _Ro_strParameterStore.Trim = "" Then Return True

                '    Dim DsData As DataSet =
                '    CyberSmlib.SQLExcuteStoreProcedure(Appconn, M_CP_Name.Trim, _Ro_strParameterStore)

                '    Dim Frm1 As New Ro_Up_Hang_Xem
                '    Frm1.strLoc = _Ro_strParameterStore
                '    Frm1.Cp_Loc = M_CP_Name
                '    Frm1.DsDataLoc = DsData
                '    Frm1.Lan = M_Lan
                '    Frm1.Para = Frm.Para
                '    Frm1.Sysvar = oSysvar
                '    Frm1.AppConn = Appconn
                '    Frm1.CyberSmlib = CyberSmlib
                '    Frm1.CyberSupport = CyberSupport
                '    Frm1.CyberFill = CyberFill
                '    Frm1.CyberSmlistSys = CyberSmlistSys
                '    Frm1.CyberSmodb = CyberSmodb
                '    Frm1.CyberExport = CyberEport
                '    Frm1.CyberVoucher = CyberVoucher
                '    Frm1.CyberLoading = CyberLoading
                '    Frm1.WindowState = Windows.Forms.FormWindowState.Maximized
                '    Frm1.ShowDialog()
                '    Return True

                'Case "CP_CRMQLLLLoad".ToUpper.Trim
                '    Frm = New CRM_Loc
                '    Frm.Lan = M_Lan
                '    Frm.Para = M_Para
                '    Frm.Sysvar = oSysvar
                '    Frm.AppConn = Appconn
                '    Frm.CyberSmlib = CyberSmlib
                '    Frm.CyberSupport = CyberSupport
                '    Frm.CyberFill = CyberFill
                '    Frm.CyberSmlistSys = CyberSmlistSys
                '    Frm.CyberSmodb = CyberSmodb
                '    Frm.CyberExport = CyberEport
                '    Frm.CyberVoucher = CyberVoucher
                '    Frm.CyberLoading = CyberLoading

                '    Frm.ShowDialog()

                '    'CyberSmlib.FlushMemorySave()
                '    If Not Frm.Save_OK Then Return True
                '    'If Not Frm.Save_OK Then Return True
                '    ''--------------
                '    'Dim M_strParameterStore As String = Frm.Tag.ToString.Trim
                '    'If M_strParameterStore.Trim = "" Then Exit Function
                '    'If Not CyberLoading.IsShowWaitFrom Then CyberLoading.V_ShowWailtForm(_Title, _Title2, M_Lan)
                '    'Dim DsCalculator As DataSet
                '    'DsCalculator = CyberSmlib.SQLExcuteStoreProcedure(Appconn, M_CP_Name.Trim, M_strParameterStore)
                '    'If CyberLoading.IsShowWaitFrom Then CyberLoading.V_CloseWailtForm()
                '    Dim Frm1 As New CRM_Xem
                '    Frm1.strLoc = Frm.Tag.ToString.Trim
                '    '-------------
                '    Frm1.Loai = Frm.Key_Sub3.ToString.Trim
                '    Frm1.Ma_Loai = Frm.Key_Sub4.ToString.Trim
                '    Frm1.Ma_Ngay = Frm.Key_Sub5.ToString.Trim

                '    Frm1.Lan = M_Lan
                '    Frm1.Para = Frm.Para 'Lấy thêm loai và mã ngày
                '    Frm1.Sysvar = oSysvar
                '    Frm1.AppConn = Appconn
                '    Frm1.CyberSmlib = CyberSmlib
                '    Frm1.CyberSupport = CyberSupport
                '    Frm1.CyberFill = CyberFill
                '    Frm1.CyberSmlistSys = CyberSmlistSys
                '    Frm1.CyberSmodb = CyberSmodb
                '    Frm1.CyberExport = CyberEport
                '    Frm1.CyberVoucher = CyberVoucher
                '    Frm1.CyberLoading = CyberLoading
                '    Frm1.ShowDialog()
                '    Return True

            Case Else
                Return False
        End Select

        Frm.Lan = M_Lan
        Frm.Para = M_Para
        Frm.Sysvar = oSysvar
        Frm.AppConn = Appconn
        Frm.CyberSmlib = CyberSmlib
        Frm.CyberSupport = CyberSupport
        Frm.CyberFill = CyberFill
        Frm.CyberSmlistSys = CyberSmlistSys
        Frm.CyberSmodb = CyberSmodb
        Frm.CyberExport = CyberEport
        Frm.CyberVoucher = CyberVoucher
        Frm.CyberLoading = CyberLoading

        Frm.ShowDialog()
        CyberSmlib.FlushMemorySave()
        If Not Frm.Save_OK Then Return True
        ''--------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim M_strParameterStore As String = Frm.Tag.ToString.Trim
        If M_strParameterStore.Trim = "" Then Return True
        ''--------------------------------------------------------------------------------------------------------------------------------------------------------

        If M_CP_Name = "CP_BEXEPXE".ToUpper.Trim Then M_strParameterStore = "1#" + M_strParameterStore
        '--------------------------------------
        If Not CyberLoading.IsShowWaitFrom Then CyberLoading.V_ShowWailtForm(_Title, _Title2, M_Lan)
        Dim DsCalculator As DataSet = CyberSmlib.SQLExcuteStoreProcedure(Appconn, M_CP_Name.Trim, M_strParameterStore)
        If CyberLoading.IsShowWaitFrom Then CyberLoading.V_CloseWailtForm()

        CyberSmlib.FlushMemorySave()

        Return True
    End Function
    'Public Function GetFormCRM_F3(ByVal M_Loai As String, ByVal M_Ma_Loai As String, ByVal M_Ma_Ngay As String) As CRM_F3
    Public Function GetFormCRM_F3(ByVal M_Loai As String, ByVal M_Ma_Loai As String, ByVal M_Ma_Ngay As String) As ThangToThang
        'Dim _Return As CRM_F3 = Nothing
        ''_Return = New CRM_F3
        'Return _Return
        Return Nothing
    End Function

End Class
