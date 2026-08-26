Public Class GLSO1_NTK
    Dim CyberMe As New Cyber.ReportsCustom.Sys
    Dim DrReturn As DataRow
    Dim DsLookup As DataSet
    Private Sub GLSO1_NTK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        V_Load()
        V_Addhander()
    End Sub
#Region "Load"
    Private Sub V_Load()
        V_AddMenuShorcut()
        CyberMe.V_LoadLoai_BC(ChkVND, ChkNT)
        Me.is_continue = False
        CyberFill.V_FillComBoxValue(Me.CBBMa_Dvcs, Me.DtUnists, "Ma_Dvcs", "Ten_Dvcs", Me.Ma_Dvcs)
        '----Set
        TxtM_Ngay_Ct1.Value = Now.Date
        TxtM_Ngay_Ct2.Value = Now.Date
        TxtM_Ngay_Ct1.Text = CyberSmLib.GetKeyValueRegistryDate(Me.sysvar, TxtM_Ngay_Ct1)
        TxtM_Ngay_Ct2.Text = CyberSmLib.GetKeyValueRegistryDate(Me.sysvar, TxtM_Ngay_Ct2)
        TxtM_Tk.Text = CyberSmLib.GetKeyValueRegistry(Me.sysvar, TxtM_Tk)
        If TxtM_Tk.Text.Trim = "" Then TxtM_Tk.Text = CyberSmLib.GetKeyValueRegistry(Me.sysvar, "TXTM_TK011")
        If TxtM_Tk.Text.Trim = "" Then Txtten_Tk.Text = "" Else Txtten_Tk.Text = CyberSmodb.SQLGetvalue(AppConn, "Ten_Tk0", "Dmtk0", "Tk0 = N'" + TxtM_Tk.Text.Trim + "'", CyberSmLib)
        '----
        CyberSmodb.GetValueToControler(Me)
    End Sub
    Private Sub V_Addhander()
        RemoveHandler ButtOK.Click, AddressOf V_Nhan
        RemoveHandler ButtExit.Click, AddressOf V_Exit
        AddHandler ButtOK.Click, AddressOf V_Nhan
        AddHandler ButtExit.Click, AddressOf V_Exit
        'Tk
        AddHandler TxtM_Tk.CyberValiting, AddressOf V_Tk
        AddHandler TxtM_Tk.CyberLeave, AddressOf L_Tk

        RemoveHandler CmdFilter_Tk.Click, AddressOf V_FilterTk
        AddHandler CmdFilter_Tk.Click, AddressOf V_FilterTk
    End Sub
#End Region
#Region "Valid"
#Region "Valid --- Tk"
    Private Sub V_Tk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TxtM_Tk.V_LookUp(Me.LAN, Me.Para, Me.sysvar, AppConn, DsLookup, "Tk0", "DmTK0", "1=1", "1=1")
    End Sub
    Private Sub L_Tk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        DrReturn = TxtM_Tk.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtM_Tk.Text = DrReturn.Item("Tk0")
            Txtten_Tk.Text = DrReturn.Item("Ten_TK0")
        Else
            TxtM_Tk.Text = ""
            Txtten_Tk.Text = ""
            Exit Sub
        End If
    End Sub
#End Region
#Region "Filter Tk"
    Private Sub V_FilterTk(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _Ten_Tk As String = ""
        Dim _Ma_Tk As String = TxtM_Tk.Text
        V_Tk_List(_Ma_Tk, _Ten_Tk)
    End Sub
    Private Sub V_Tk_List(ByVal _Ma_Tk As String, ByVal _Ten_TK As String)
        Dim str As String
        Dim strTen As String = ""

        str = GetDmTk(_Ma_Tk, strTen)
        If str Is Nothing Then Exit Sub
        If str Is Nothing Then str = ""
        If strTen Is Nothing Then strTen = ""

        TxtM_Tk.Text = str
        Txtten_Tk.Text = strTen
    End Sub
    Private Function GetDmTk(ByVal _Ma_TK As String, ByRef _Ten_Tk As String) As String
        GetDmTk = CyberSupport.V_GetStrSelectList(AppConn, sysvar, Para, "CP_GetListSelect", "DmTk#" & _Ma_TK & "##" & Ma_Dvcs & "#" & Me.User_Name, Me.LAN, _Ten_Tk)
    End Function
#End Region
#End Region
#Region "Button"
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TxtM_Tk.Text.Trim = "" Then
            TxtM_Tk.Focus()
            Exit Sub
        End If
        '-----------------------------------------------------------------------------
        Dim Dt1 As Date = TxtM_Ngay_Ct1.Value
        Dim Dt2 As Date = TxtM_Ngay_Ct2.Value
        Dim M_Ma_Dvcs_Filter As String = Me.CBBMa_Dvcs.SelectedValue.ToString.Trim
        Dim M_strParameterStore As String = TxtM_Tk.Text.Trim.Replace("#", "")
        M_strParameterStore = M_strParameterStore & "#" & Dt1.ToString("yyyyMMdd") & "#" & Dt2.ToString("yyyyMMdd").Trim
        M_strParameterStore = M_strParameterStore & "#" & If(ChkM_GROUP.Checked, "1", "0")
        M_strParameterStore = M_strParameterStore & "#" & Me.Para(Me.VT_PARA + 2).ToString.Trim
        M_strParameterStore = M_strParameterStore & "#" & CyberMe.GetLoai_BC(ChkVND, ChkNT)
        M_strParameterStore = M_strParameterStore & "#" & M_Ma_Dvcs_Filter
        M_strParameterStore = M_strParameterStore & "#" & Me.User_Name.Trim
        '-----------------------------------------------------------------------------
        Me.is_continue = True
        Dim M_strFieldValue As String = ""
        Dim M_strFieldName As String = ""
        CyberSmodb.GetValueControler(Me, M_strFieldName, M_strFieldValue, "")
        Me.Tag_Field = M_strFieldName
        Me.Tag_Value = M_strFieldValue
        CyberSmLib.SaveRegistry(Me, Me.sysvar)
        Me.Tag = M_strParameterStore
        Me.Close()
    End Sub
    Private Sub V_Exit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub V_AddMenuShorcut()
        Dim mnItems = New ContextMenu
        Dim mnItemsNhan As New MenuItem(IIf(Me.LAN = "V", "Chấp nhận", "OK"), AddressOf V_Nhan, Keys.Control + Keys.Enter)
        Dim mnItemsExit As New MenuItem(IIf(Me.LAN = "V", "Quay ra", "Exit"), AddressOf V_Exit, Keys.Escape)
        mnItems.MenuItems.Add(mnItemsNhan)
        mnItems.MenuItems.Add(mnItemsExit)
        Me.ContextMenu = mnItems
    End Sub
#End Region
End Class
