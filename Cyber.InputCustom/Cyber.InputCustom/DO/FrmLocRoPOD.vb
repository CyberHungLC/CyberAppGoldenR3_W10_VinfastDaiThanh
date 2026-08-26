Public Class FrmLocRoPOD
#Region "Get or Set Property----------------------"
    Public Property Stt_rec() As String
        Get
            Return M_Stt_rec
        End Get
        Set(ByVal value As String)
            M_Stt_rec = value
        End Set
    End Property
    Public Property Ma_Ct() As String
        Get
            Return M_Ma_Ct
        End Get
        Set(ByVal value As String)
            M_Ma_Ct = value
        End Set
    End Property
    Public Property Mode() As String
        Get
            Return M_Mode
        End Get
        Set(ByVal value As String)
            M_Mode = value
        End Set
    End Property
    Public Property So_Ro_Hang() As String
        Get
            Return M_So_Ro_Hang
        End Get
        Set(ByVal value As String)
            M_So_Ro_Hang = value
        End Set
    End Property
    Public Property So_DN() As String
        Get
            Return M_So_DN
        End Get
        Set(ByVal value As String)
            M_So_DN = value
        End Set
    End Property
    Public Property Master_Return() As DataTable
        Get
            Master_Return = M_Master_Return
        End Get
        Set(ByVal Value As DataTable)
            M_Master_Return = Value
        End Set
    End Property
    Public Property Vt_Return() As DataTable
        Get
            Vt_Return = M_Vt_Return
        End Get
        Set(ByVal Value As DataTable)
            M_Vt_Return = Value
        End Set
    End Property
    Public Property Dt_Return() As DataTable
        Get
            Dt_Return = M_Dt_Return
        End Get
        Set(ByVal Value As DataTable)
            M_Dt_Return = Value
        End Set
    End Property
    Public Property _Ds_LoolUp() As DataSet
        Get
            _Ds_LoolUp = DsLookup
        End Get
        Set(ByVal Value As DataSet)
            DsLookup = Value
        End Set
    End Property
#End Region
#Region "Bien----------------------"
    Dim M_Stt_rec As String = ""
    Dim M_Ma_Ct As String = ""
    Dim M_Mode As String = "M"
    Dim M_Ma_Thue As String = "10"
    Dim M_So_Ro_Hang As String = ""
    Dim M_Ma_TT As String = "C"
    Dim M_So_Ro As String = ""
    Dim M_So_DN As String = ""
    Dim DsLookup As New DataSet
    Dim tbMaster As New DataTable
    Dim dtMasterRo, dtMasterHeaderRo As New DataTable
    Dim vdtMasterRo, vdtMasterHeaderRo As New DataView
    Dim dtDetailRo As New DataTable, vdtDetailRo As New DataView

    Dim dtDetailCvRo, dtDetailHeaderCvRo As New DataTable
    Dim vdtDetailCvRo, vdtDetailHeaderCvRo As New DataView

    Dim dtDetailVtRo, dtDetailHeaderVtRo As New DataTable
    Dim vdtDetailVtRo, vdtDetailHeaderVtRo As New DataView

    Dim EditMasterTag, EditDetailCvTag, EditDetailVtTag As New Cyber.Fill.CyberColumnGridView
    Dim M_Master_Return, M_Vt_Return, M_Cv_Return, M_Dt_Return As DataTable
    Dim DrReturn As DataRow
#End Region
    Private Sub FrmLocRoPOD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        V_Load()
        V_GetColumn()
        Me.Text = "Chọn lệnh sửa chữa"
        V_AddHander()
    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_GetColumn()
        EditMasterTag.GetColumn(DetailGRVRo_Master, "tag")
        EditDetailVtTag.GetColumn(DetailGRVRo_DetailVt, "tag")
    End Sub
    Private Sub V_AddHander()
        If Not EditMasterTag.Column Is Nothing Then AddHandler EditMasterTag.EditColumn.EditValueChanged, AddressOf V_Chon
        If Not EditDetailVtTag.Column Is Nothing Then AddHandler EditDetailVtTag.EditColumn.EditValueChanged, AddressOf V_ChonVt

        AddHandler TxtSo_DN.Leave, AddressOf L_So_Lenh

        AddHandler ButtOK.Click, AddressOf V_Nhan
        AddHandler CmdLoc_Ro.Click, AddressOf V_LocRo
        'V_Menu(DetailGRVRo_Master, AddressOf V_EditVoucherRo)
        AddMenu()
        AddHandler DetailGRVRo_Master.FocusedRowChanged, AddressOf DetailGRVRo_Master_FocusedRowChanged
        CyberFill.V_GridviewRowCellStyle(DetailGRVRo_Master)

        AddHandler TxtMa_Hs.CyberValiting, AddressOf V_Ma_Hs
        AddHandler TxtMa_Hs.CyberLeave, AddressOf L_Ma_Hs
    End Sub
    Private Sub AddMenu()
        Dim mnItemsMail = New ContextMenu
        'Dim mnItemsF3 As New MenuItem("Xem chi tiết chứng từ", Events, Keys.F3)
        Dim mnItemsSelectAll As New MenuItem("Chọn toàn bộ", AddressOf V_SelectAllRo, Shortcut.CtrlA)
        Dim mnItemsRemoveAll As New MenuItem("Bỏ chọn ", AddressOf V_RemoveAllRo, Shortcut.CtrlU)

        mnItemsMail.MenuItems.Add(mnItemsSelectAll)
        mnItemsMail.MenuItems.Add(mnItemsRemoveAll)
        DetailGRVRo_Master.GridControl.ContextMenu = mnItemsMail
    End Sub
    Private Sub V_SelectAllRo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To dtMasterRo.Rows.Count - 1
            dtMasterRo.Rows(i).BeginEdit()
            dtMasterRo.Rows(i).Item("Tag") = "1"
            dtMasterRo.Rows(i).EndEdit()
        Next
        For i As Integer = 0 To dtDetailVtRo.Rows.Count - 1
            dtDetailVtRo.Rows(i).BeginEdit()
            dtDetailVtRo.Rows(i).Item("Tag") = "1"
            dtDetailVtRo.Rows(i).EndEdit()
        Next
        For i As Integer = 0 To dtDetailCvRo.Rows.Count - 1
            dtDetailCvRo.Rows(i).BeginEdit()
            dtDetailCvRo.Rows(i).Item("Tag") = "1"
            dtDetailCvRo.Rows(i).EndEdit()
        Next
        dtMasterRo.AcceptChanges()
        dtDetailVtRo.AcceptChanges()
        dtDetailCvRo.AcceptChanges()
    End Sub
    Private Sub V_RemoveAllRo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To dtMasterRo.Rows.Count - 1
            dtMasterRo.Rows(i).BeginEdit()
            dtMasterRo.Rows(i).Item("Tag") = "0"
            dtMasterRo.Rows(i).EndEdit()
        Next
        For i As Integer = 0 To dtDetailVtRo.Rows.Count - 1
            dtDetailVtRo.Rows(i).BeginEdit()
            dtDetailVtRo.Rows(i).Item("Tag") = "0"
            dtDetailVtRo.Rows(i).EndEdit()
        Next
        For i As Integer = 0 To dtDetailCvRo.Rows.Count - 1
            dtDetailCvRo.Rows(i).BeginEdit()
            dtDetailCvRo.Rows(i).Item("Tag") = "0"
            dtDetailCvRo.Rows(i).EndEdit()
        Next
        dtMasterRo.AcceptChanges()
        dtDetailVtRo.AcceptChanges()
        dtDetailCvRo.AcceptChanges()
    End Sub

#Region "Valid --- Ma_Hs"
    Private Sub V_Ma_Hs(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        TxtMa_Hs.V_LookUp(M_LAN, Me.Para, Me.Sysvar, AppConn, DsLookup, "Ma_Hs", "Dmhs", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_Hs(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_Hs.Text = "" Then
            TxtTen_Hs.Text = ""
            Exit Sub
        End If
        DrReturn = TxtMa_Hs.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_Hs.Text = DrReturn("Ma_Hs").ToString.Trim
            TxtTen_Hs.Text = DrReturn("ten_hs").ToString.Trim

        Else
            TxtMa_Hs.Text = ""
            TxtTen_Hs.Text = ""
        End If
    End Sub
#End Region


#Region "Load - "
    Private Sub V_EditVoucherRo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberFill.V_EditVoucher(M_LAN, Me.Para, Me.Sysvar, AppConn, DetailGRVRo_Master)
    End Sub
    Private Sub V_Load()
        TxtNgay_Ct1.Value = Now.Date
        TxtNgay_Ct2.Value = Now.Date
        V_LoadDatabase("1")
        V_LoadHeaderGridview()
    End Sub
    Private Sub V_LoadDatabase(ByVal Status As String)
        Dim _Ngay_Ct1 As Date = TxtNgay_Ct1.Value, _Ngay_Ct2 As Date = TxtNgay_Ct2.Value
        Dim strFiled = "", strValues As String = ""
        CyberSmodb.GetValueControler(Me, strFiled, strValues, "")

        Dim DsLenh_RO As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoGetPODFROMPDN", Status & "#" & TxtSo_DN.Text.Trim & "#" & _Ngay_Ct1.ToString("yyyyMMdd") & "#" & _Ngay_Ct2.ToString("yyyyMMdd") & "#" & M_Stt_rec & "#" & M_Ma_Dvcs & "#" & M_User_Name)
        If Not CyberSupport.V_MsgChk(DsLenh_RO.Tables(0), Me.Sysvar, Me.Lan) Then
            DsLenh_RO.Dispose()
            Exit Sub
        End If

        tbMaster = DsLenh_RO.Tables(1)
        For i = 0 To DsLenh_RO.Tables.Count - 1
            CyberSmodb.SetNotNullTable(DsLenh_RO.Tables(i))
        Next
        'If DsLenh_RO.Tables(1).Rows.Count > 0 Then MsgBox(DsLenh_RO.Tables(1).Rows(0).Item("Tien_nt"))
        V_BingDataTableToDataTable(Status, DsLenh_RO.Tables(2), dtMasterRo, vdtMasterRo)
        V_BingDataTableToDataTable(Status, DsLenh_RO.Tables(2), dtDetailRo, vdtDetailRo)
        V_BingDataTableToDataTable(Status, DsLenh_RO.Tables(1), dtDetailVtRo, vdtDetailVtRo)
        DsLenh_RO.Dispose()
        If Not Status.Trim = "1" Then V_Chon(New System.Object, New System.EventArgs)
    End Sub
    Private Sub V_LoadHeaderGridview()
        Dim DsHeader As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_GetDetailHeadPDN", M_Ma_Ct.Trim + "#" + M_User_Name)
        '========== Fill datatable
        V_BingDataTableToDataTable("1", DsHeader.Tables(0), dtMasterHeaderRo, vdtMasterHeaderRo)
        V_BingDataTableToDataTable("1", DsHeader.Tables(1), dtDetailHeaderVtRo, vdtDetailHeaderVtRo)

        '========== Fill gridview
        V_FillDataToGridview(DetailGRVRo_Master, M_LAN, vdtMasterHeaderRo, vdtMasterRo)
        V_FillDataToGridview(DetailGRVRo_DetailVt, M_LAN, vdtDetailHeaderVtRo, vdtDetailVtRo)

        DsHeader.Dispose()
    End Sub
    Private Sub V_FillDataToGridview(ByRef GRV As DevExpress.XtraGrid.Views.Grid.GridView, ByVal _M_lan As String, ByVal DvHeader As DataView, ByVal DvData As DataView)
        CyberFill.V_FillReports(GRV, _M_lan, DvHeader, DvData)
        GRV.GridControl.DataSource = DvData
    End Sub
    Private Sub V_BingDataTableToDataTable(ByVal Status As String, ByRef Dt_Data_Nguon As DataTable, ByRef Dt_Data_Dich As DataTable, ByRef Dv_Data_Dich As DataView)
        If Status.Trim = "1" Then
            Dt_Data_Dich = Dt_Data_Nguon.Copy
            Dv_Data_Dich = New DataView(Dt_Data_Dich)
            Exit Sub
        End If
        Dt_Data_Dich.Clear()
        For i As Integer = 0 To Dt_Data_Nguon.Rows.Count - 1
            Dt_Data_Dich.ImportRow(Dt_Data_Nguon.Rows(i))
        Next
    End Sub
#End Region
#Region "Tinh toan"

    Private Sub V_ChonVt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DetailGRVRo_DetailVt.PostEditor()
        Dim selectedRow = DetailGRVRo_Master.GetFocusedRow

        Dim _Rec_DN As String = ""
        Try
            _Rec_DN = selectedRow("Rec_DN").ToString.Trim
        Catch ex As Exception
        End Try
        TotalItem(_Rec_DN)
    End Sub
    Private Sub V_Chon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DetailGRVRo_Master.PostEditor()
        DetailGRVRo_Master.UpdateCurrentRow()

        Dim selectedRow = DetailGRVRo_Master.GetFocusedRow


        Dim _Tag As String = "0"
        Dim _Rec_DN As String = ""
        Try
            _Rec_DN = selectedRow("Rec_DN").ToString.Trim
        Catch ex As Exception

        End Try
        Try
            _Tag = selectedRow("Tag").ToString.Trim
        Catch ex As Exception
        End Try

        V_Detial(IIf(_Tag <> "1", "0", "1"), _Rec_DN)

        TotalItem(_Rec_DN)
    End Sub
    Private Sub DetailGRVRo_Master_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Dim selectedRow = DetailGRVRo_Master.GetFocusedRow
        Dim _stt_Rec As String = ""
        If selectedRow Is Nothing Then _stt_Rec = "" Else _stt_Rec = selectedRow("Rec_DN").ToString.Trim
        V_BilldtingRo(sender, vdtMasterRo, vdtDetailVtRo)
        TotalItem(_stt_Rec)
    End Sub
    Private Sub V_BilldtingRo(ByVal MasterGRV As DevExpress.XtraGrid.Views.Grid.GridView, ByVal Dv_Master As DataView, ByVal Dv_DetailTmp As DataView)
        If MasterGRV.GetFocusedRow Is Nothing Then Exit Sub
        If Not Dv_DetailTmp.Table.Columns.Contains("Rec_DN") Then Exit Sub
        If Not Dv_Master.Table.Columns.Contains("Rec_DN") Then Exit Sub
        If Dv_Master.Table.Rows.Count < 1 Then Exit Sub
        If Dv_Master.Table.Columns.Count < 1 Then Exit Sub
        Dim filter As String = "1=1"
        Dim selectedRow As DataRowView = Nothing
        Try
            selectedRow = MasterGRV.GetFocusedRow
            If (Not String.IsNullOrEmpty(selectedRow("Rec_DN").ToString)) Then
                filter = "Rec_DN='" + selectedRow("Rec_DN").ToString() + "'"
                Dv_DetailTmp.RowFilter = filter
            End If
        Catch ex As Exception
            Dv_DetailTmp.RowFilter = "1=0"
        End Try
    End Sub
    Private Sub V_Detial(ByVal status As String, ByVal _Rec_DN As String)
        _Rec_DN = _Rec_DN.Trim
        dtDetailVtRo.AcceptChanges()
        For Each dr As DataRow In dtDetailVtRo.Select("Rec_DN='" & _Rec_DN & "'")
            dr.BeginEdit()
            dr("tag") = status
            dr.EndEdit()
        Next
        dtDetailVtRo.AcceptChanges()
    End Sub
    Private Sub TotalItem(ByVal _Rec_Ro As String)
        Dim T_Tien2 As Decimal = 0
        Dim T_Thue As Decimal = 0
        Dim T_TT As Decimal = 0
        _Rec_Ro = _Rec_Ro.Trim

        dtDetailVtRo.AcceptChanges()

        For Each drVt As DataRow In dtDetailVtRo.Select("Tag='1' AND Rec_DN ='" + _Rec_Ro.ToString.Trim + "'")
            T_Tien2 = T_Tien2 + drVt("Tien_nt")
            T_Thue = T_Thue + drVt("Thue")
        Next

        TxtT_Tien2.Double = T_Tien2
        TxtT_Thue.Double = T_Thue
        TxtT_TT.Double = T_Tien2 + T_Thue
    End Sub

#End Region
    Private Sub L_So_Lenh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _Ngay_Ct As Date = TxtNgay_Ct1.Value
        TxtSo_DN.Text = CyberVoucher.V_GetSo_RO(M_Ma_Ct, "S", M_Mode, _Ngay_Ct, TxtSo_DN.Text, M_Ma_Dvcs)
    End Sub
    Private Sub V_LocRo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        V_LoadDatabase("2")
        If dtMasterRo.Rows.Count = 0 Then

        End If
        'Exit Sub
        Dim selectedRow = DetailGRVRo_Master.GetFocusedRow
        Dim _Rec_DN As String = ""
        Try
            _Rec_DN = selectedRow("Rec_DN").ToString.Trim
        Catch ex As Exception
        End Try
        TotalItem(_Rec_DN)
        'V_Chon(sender, e)
    End Sub
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Save_OK = True
        Dim M_strParameterStore As String = ""
        Me.Tag = M_strParameterStore

        'Dim _Master_Return As DataTable = tbMaster.Clone
        Dim _VT_Return As DataTable = dtDetailVtRo.Clone
        Dim _Dt_Return As DataTable = dtDetailRo.Clone


        For i As Integer = 0 To dtMasterRo.Rows.Count - 1

            If Not dtMasterRo.Rows(i).Item("Tag").ToString.Trim = "1" Then Continue For

            _Dt_Return.ImportRow(dtMasterRo.Rows(i))

            '' --------------------------- Gán lại cho các ô ---------------------------------
            'If dtDetailRo.Columns.Contains("T_C") And dtMasterRo.Columns.Contains("So_ro") Then
            '    tbMaster.Rows(0).Item("T_C") = tbMaster.Rows(0).Item("T_C") + dtDetailRo.Rows(i).Item("T_C")
            'End If

            'If dtDetailRo.Columns.Contains("T_I") And dtMasterRo.Columns.Contains("T_I") Then
            '    tbMaster.Rows(0).Item("T_I") = tbMaster.Rows(0).Item("T_I") + dtDetailRo.Rows(i).Item("T_I")
            'End If

            'If dtDetailRo.Columns.Contains("T_N") And tbMaster.Columns.Contains("T_N") Then
            '    tbMaster.Rows(0).Item("T_N") = tbMaster.Rows(0).Item("T_N") + dtDetailRo.Rows(i).Item("T_N")
            'End If

            'If dtDetailRo.Columns.Contains("T_W") And tbMaster.Columns.Contains("T_W") Then
            '    tbMaster.Rows(0).Item("T_W") = tbMaster.Rows(0).Item("T_W") + dtDetailRo.Rows(i).Item("T_W")
            'End If
            '' --------------------------- hết ---------------------------------

            Dim _Rec_DN As String = dtMasterRo.Rows(i).Item("Rec_DN").ToString.Trim.ToUpper

            For iRowVt = 0 To dtDetailVtRo.Rows.Count - 1
                If Not dtDetailVtRo.Rows(iRowVt).Item("Tag").ToString.Trim = "1" Then Continue For
                If Not dtDetailVtRo.Rows(iRowVt).Item("Rec_DN").ToString.Trim.ToUpper = _Rec_DN Then Continue For
                _VT_Return.ImportRow(dtDetailVtRo.Rows(iRowVt))
            Next
        Next

        Me.Master_Return = tbMaster
        Me.Vt_Return = _VT_Return
        Me.Dt_Return = _Dt_Return

        CyberSmlib.FlushMemorySave()
        Me.Close()
    End Sub
End Class
