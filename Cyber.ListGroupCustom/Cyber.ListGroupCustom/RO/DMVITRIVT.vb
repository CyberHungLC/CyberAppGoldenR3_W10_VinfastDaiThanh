Public Class DMVITRIVT
    Dim DrReturn As DataRow
    Dim DsLookup As New DataSet
    Private Sub DMMauKx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        V_GetChkErro()
        V_Load()
        CyberSupport.Translaste(Me, M_LAN, True)
        TxtMa_VT.Focus()
        If Me.Mode = "M" Then TxtMa_Dvcs.Text = M_Ma_Dvcs
        CyberSmodb.SetListFixLengthEnabled(Me, Me.Tb_Name, Appconn, Me.Mode, M_User_Name, CyberSmlib)
        'Cyber.ListGroupCustom.Sys.SetAutoCode(Appconn, Me.Tb_Name, Me.Mode, CyberSmlib, CyberSmodb, TxtMa_TTLN, TxtNh_TTLN1, TxtNh_TTLN2, TxtNh_TTLN3, TxtNh_TTLN4, TxtNh_TTLN5)
    End Sub
#Region "Load"
    Protected Overrides Sub V_Load()
        MyBase.V_Load()

        If TxtMa_VT.Text.Trim = "" Then TxtTen_VT.Text = "" Else TxtTen_VT.Text = CyberSmodb.SQLGetvalue(Appconn, "Ten_VT", "Dmvt", "(Ma_vt = N'" + TxtMa_VT.Text.Trim + "')", CyberSmlib)
        If TxtMa_kho.Text.Trim = "" Then TxtTen_kho.Text = "" Else TxtTen_kho.Text = CyberSmodb.SQLGetvalue(Appconn, "Ten_Kho", "DmKho", "(Ma_Kho = N'" + TxtMa_kho.Text.Trim + "')", CyberSmlib)
        If TxtMa_vitri.Text.Trim = "" Then TxtTen_vitri.Text = "" Else TxtTen_vitri.Text = CyberSmodb.SQLGetvalue(Appconn, "Ten_vitri", "Dmvitri", "(Ma_Vitri = N'" + TxtMa_vitri.Text.Trim + "')", CyberSmlib)

    End Sub
    Protected Overrides Sub V_Addhander()

        MyBase.V_Addhander()
        RemoveHandler TxtMa_VT.KeyPress, AddressOf TxtCodeError_KeyPress
        AddHandler TxtMa_VT.KeyPress, AddressOf TxtCodeError_KeyPress

        '--Ma_vt
        RemoveHandler TxtMa_VT.CyberValiting, AddressOf V_Ma_vt
        RemoveHandler TxtMa_VT.CyberLeave, AddressOf L_Ma_vt
        AddHandler TxtMa_VT.CyberValiting, AddressOf V_Ma_vt
        AddHandler TxtMa_VT.CyberLeave, AddressOf L_Ma_vt
        '--Ma_Kho
        RemoveHandler TxtMa_kho.CyberValiting, AddressOf V_Ma_Kho
        RemoveHandler TxtMa_kho.CyberLeave, AddressOf L_Ma_Kho
        AddHandler TxtMa_kho.CyberValiting, AddressOf V_Ma_Kho
        AddHandler TxtMa_kho.CyberLeave, AddressOf L_Ma_Kho

        '--Ma_Vitri
        RemoveHandler txtMa_ViTri.CyberValiting, AddressOf V_Ma_Vitri
        RemoveHandler txtMa_ViTri.CyberLeave, AddressOf L_Ma_Vitri
        AddHandler txtMa_ViTri.CyberValiting, AddressOf V_Ma_Vitri
        AddHandler txtMa_ViTri.CyberLeave, AddressOf L_Ma_Vitri


    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
    End Sub
#End Region
#Region "Valid"
#Region "Vali --- Ma_vt"
    Private Sub V_Ma_vt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtMa_VT.V_LookUp(M_LAN, M_Para, oSysvar, Appconn, DsLookup, "Ma_vt", "Dmvt", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_vt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TxtMa_VT.Text = "" Then
            TxtTen_VT.Text = ""
            Exit Sub
        End If
        DrReturn = TxtMa_VT.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_VT.Text = DrReturn.Item("Ma_vt")
            TxtTen_VT.Text = DrReturn.Item("Ten_VT")
        Else
            TxtMa_VT.Text = ""
            TxtTen_VT.Text = ""
        End If
    End Sub
#End Region
#Region "Vali --- Ma_Kho"
    Private Sub V_Ma_ViTri(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtMa_ViTri.V_LookUp(M_LAN, M_Para, oSysvar, Appconn, DsLookup, "Ma_ViTri", "Dmvitri", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_ViTri(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtMa_ViTri.Text = "" Then
            TxtTen_vitri.Text = ""
            Exit Sub
        End If
        DrReturn = txtMa_ViTri.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            txtMa_ViTri.Text = DrReturn.Item("Ma_ViTri")
            TxtTen_vitri.Text = DrReturn.Item("Ten_ViTri")
        Else
            txtMa_ViTri.Text = ""
            TxtTen_vitri.Text = ""
        End If
    End Sub
#End Region
#Region "Vali --- Ma_Kho"
    Private Sub V_Ma_Kho(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtMa_kho.V_LookUp(M_LAN, M_Para, oSysvar, Appconn, DsLookup, "Ma_Kho", "DmKho", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_Kho(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TxtMa_kho.Text = "" Then
            TxtTen_kho.Text = ""
            Exit Sub
        End If
        DrReturn = TxtMa_kho.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_kho.Text = DrReturn.Item("Ma_Kho")
            TxtTen_kho.Text = DrReturn.Item("Ten_Kho")
        Else
            TxtMa_kho.Text = ""
            TxtTen_kho.Text = ""
        End If
    End Sub
#End Region
#End Region
#Region "Buuton"
    Protected Overrides Sub V_Save(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim _Value As String = V_GetCode(Me, Mode, M_Ma_Dvcs, M_User_Name)
        If Not _Value.Trim = "" Then TxtMa_VT.Text = _Value
        CyberSmodb.AddValueToRow(Me.DrNew, Me)
        If Not CyberSmlistSys.SaveToSQLOfList(Appconn, oSysvar, Me, CyberSmodb, CyberSmlib, CyberSupport) Then Exit Sub
        MyBase.V_Save(sender, e) '// khong xoa doan nay
    End Sub
    Protected Overrides Sub V_Exit(ByVal sender As Object, ByVal e As System.EventArgs) ''// Su ly truoc khi thoat truong trinh viet vao day
        MyBase.V_Exit(sender, e) '// khong xoa doan nay
    End Sub
#End Region
End Class
