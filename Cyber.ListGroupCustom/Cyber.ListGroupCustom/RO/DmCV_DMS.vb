Public Class DmCV_DMS
    Dim DrReturn As DataRow
    Dim DsLookup As New DataSet
    Private Sub FDMTD1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        V_GetChkErro()
        V_Load()
        CyberSupport.Translaste(Me, M_LAN, True)
        CyberSmodb.SetListFixLengthEnabled(Me, Me.Tb_Name, Appconn, Me.Mode, M_User_Name, CyberSmlib)
        'Cyber.ListGroupGL.Sys.SetAutoCode(Appconn, Me.Tb_Name, Me.Mode, CyberSmlib, CyberSmodb, TxtMa_Coupont, TxtNh_Coupont1, TxtNh_Coupont2, TxtNh_Coupont3, TxtNh_Coupont4, TxtNh_Coupont5)
        'TxtMa_Coupont.Focus()
        CyberSupport.Translaste(Me, M_LAN, True)
    End Sub
#Region "Load"
    Protected Overrides Sub V_Load()
        MyBase.V_Load()

        If TxtMa_Cv.Text.Trim = "" Then TxtTen_Cv.Text = "" Else TxtTen_Cv.Text = CyberSmodb.SQLGetvalue(Appconn, "Ma_Cv", "DMCV", "1=1", CyberSmlib)
        If TxtMa_CTCV.Text.Trim = "" Then TxtTen_CTCV.Text = "" Else TxtTen_CTCV.Text = CyberSmodb.SQLGetvalue(Appconn, "Ma_CTCV", "DMCTCV", "1=1", CyberSmlib)

        If Me.Mode = "M" Then TxtMa_Dvcs.Text = M_Ma_Dvcs
    End Sub
    Protected Overrides Sub V_Addhander()
        MyBase.V_Addhander()


        'Nh_Coupont4
        RemoveHandler TxtMa_Cv.CyberValiting, AddressOf V_Ma_Cv
        RemoveHandler TxtMa_Cv.CyberLeave, AddressOf L_Ma_Cv
        AddHandler TxtMa_Cv.CyberValiting, AddressOf V_Ma_Cv
        AddHandler TxtMa_Cv.CyberLeave, AddressOf L_Ma_Cv
        'Nh_Coupont5
        RemoveHandler TxtMa_CTCV.CyberValiting, AddressOf V_Ma_CTCV
        RemoveHandler TxtMa_CTCV.CyberLeave, AddressOf L_Ma_CTCV
        AddHandler TxtMa_CTCV.CyberValiting, AddressOf V_Ma_CTCV
        AddHandler TxtMa_CTCV.CyberLeave, AddressOf L_Ma_CTCV

    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
    End Sub
#End Region
#Region "Valid"
#Region "Vali --- Ma_Cv"
    Private Sub V_Ma_Cv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtMa_Cv.V_LookUp(M_LAN, M_Para, oSysvar, Appconn, DsLookup, "Ma_Cv", "DMCV", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_Cv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DrReturn = TxtMa_Cv.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_Cv.Text = DrReturn.Item("Ma_Cv")
            TxtTen_Cv.Text = DrReturn.Item("Ten_CV")
        Else
            TxtMa_Cv.Text = ""
            TxtTen_Cv.Text = ""
        End If
    End Sub
#End Region
#Region "Vali --- Ma_CTCV"
    Private Sub V_Ma_CTCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtMa_CTCV.V_LookUp(M_LAN, M_Para, oSysvar, Appconn, DsLookup, "Ma_CTCV", "DMCTCV", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_CTCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DrReturn = TxtMa_CTCV.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_CTCV.Text = DrReturn.Item("Ma_CTCV")
            TxtTen_CTCV.Text = DrReturn.Item("Ten_CTCV")
        Else
            TxtMa_CTCV.Text = ""
            TxtTen_CTCV.Text = ""
        End If
    End Sub
#End Region

#End Region
#Region "Buuton"
    Protected Overrides Sub V_Save(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim _Value As String = V_GetCode(Me, Mode, M_Ma_Dvcs, M_User_Name)
        'If Not _Value.Trim = "" Then TxtMa_Coupont.Text = _Value
        CyberSmodb.AddValueToRow(Me.DrNew, Me)
        If Not CyberSmlistSys.SaveToSQLOfList(Appconn, oSysvar, Me, CyberSmodb, CyberSmlib, CyberSupport) Then Exit Sub
        MyBase.V_Save(sender, e) '// khong xoa doan nay
    End Sub
    Protected Overrides Sub V_Exit(ByVal sender As Object, ByVal e As System.EventArgs) ''// Su ly truoc khi thoat truong trinh viet vao day
        MyBase.V_Exit(sender, e) '// khong xoa doan nay
    End Sub
#End Region
End Class
