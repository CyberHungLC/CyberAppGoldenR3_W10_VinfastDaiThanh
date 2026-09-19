Public Class DMDOIXE
    Dim DrReturn As DataRow
    Dim DsLookup As New DataSet
    Private Sub FDMKHO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DsLookup = New DataSet
        V_GetChkErro()
        V_Load()
        CyberSupport.Translaste(Me, M_LAN, True)
        CyberSmodb.SetListFixLengthEnabled(Me, Me.Tb_Name, Appconn, Me.Mode, M_User_Name, CyberSmlib)

    End Sub
#Region "Load"
    Protected Overrides Sub V_Load()
        MyBase.V_Load()

        TxtTen_TTCP.Text = CyberSmodb.SQLGetvalue(Appconn, "Ten_TTCP", "DMTTCP", "(Ma_TTCP = N'" + TxtMa_TTCP.Text.Trim + "')", CyberSmlib)
        TxtTen_KH.Text = CyberSmodb.SQLGetvalue(Appconn, "Ten_KH", "DMKH", "(Ma_KH = N'" + TxtMa_KH.Text.Trim + "')", CyberSmlib)
        If Me.Mode = "M" Then TxtMa_Dvcs.Text = M_Ma_Dvcs

    End Sub
    Protected Overrides Sub V_Addhander()
        MyBase.V_Addhander()

        RemoveHandler TxtMa_TTCP.CyberValiting, AddressOf V_Ma_TTCP
        RemoveHandler TxtMa_TTCP.CyberLeave, AddressOf L_Ma_TTCP
        AddHandler TxtMa_TTCP.CyberValiting, AddressOf V_Ma_TTCP
        AddHandler TxtMa_TTCP.CyberLeave, AddressOf L_Ma_TTCP

        RemoveHandler TxtMa_KH.CyberValiting, AddressOf V_Ma_KH
        RemoveHandler TxtMa_KH.CyberLeave, AddressOf L_Ma_KH
        AddHandler TxtMa_KH.CyberValiting, AddressOf V_Ma_KH
        AddHandler TxtMa_KH.CyberLeave, AddressOf L_Ma_KH

    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()

    End Sub
#End Region
#Region "Valid"
#Region "Vali --- Ma_TTCP"
    Private Sub V_Ma_TTCP(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtMa_TTCP.V_LookUp(M_LAN, M_Para, oSysvar, Appconn, DsLookup, "Ma_TTCP", "DMTTCP", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_TTCP(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DrReturn = TxtMa_TTCP.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_TTCP.Text = DrReturn.Item("Ma_TTCP")
            TxtTen_TTCP.Text = DrReturn.Item("Ten_TTCP")
        Else
            TxtMa_TTCP.Text = ""
            TxtTen_TTCP.Text = ""
        End If
    End Sub
#End Region
#Region "Vali --- Ma_KH"
    Private Sub V_Ma_KH(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtMa_KH.V_LookUp(M_LAN, M_Para, oSysvar, Appconn, DsLookup, "Ma_KH", "DMKH", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_KH(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DrReturn = TxtMa_KH.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_KH.Text = DrReturn.Item("Ma_KH")
            TxtTen_KH.Text = DrReturn.Item("Ten_KH")
        Else
            TxtMa_KH.Text = ""
            TxtTen_KH.Text = ""
        End If
    End Sub
#End Region
#End Region
#Region "Buuton"
    Protected Overrides Sub V_Save(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim _Value As String = V_GetCode(Me, Mode, M_Ma_Dvcs, M_User_Name)
        If Not _Value.Trim = "" Then TxtMa_Doi.Text = _Value
        CyberSmodb.AddValueToRow(Me.DrNew, Me)
        If Not CyberSmlistSys.SaveToSQLOfList(Appconn, oSysvar, Me, CyberSmodb, CyberSmlib, CyberSupport) Then Exit Sub
        MyBase.V_Save(sender, e) '// khong xoa doan nay
    End Sub
    Protected Overrides Sub V_Exit(ByVal sender As Object, ByVal e As System.EventArgs)
        ''// Su ly truoc khi thoat truong trinh viet vao day
        MyBase.V_Exit(sender, e) '// khong xoa doan nay
    End Sub
#End Region
End Class