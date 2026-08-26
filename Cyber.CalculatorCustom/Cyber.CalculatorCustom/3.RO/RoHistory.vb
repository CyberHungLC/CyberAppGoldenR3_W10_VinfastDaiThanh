Imports System.Windows.Forms
Imports System.Drawing
Public Class RoHistory
    Dim M_Ma_Xe As String = ""
    Public Property Ma_Xe() As String
        Get
            Ma_Xe = M_Ma_Xe
        End Get
        Set(ByVal Value As String)
            M_Ma_Xe = Value
        End Set
    End Property
    Dim M_Ma_Ct As String = ""
    Public Property Ma_Ct() As String
        Get
            Ma_Ct = M_Ma_Ct
        End Get
        Set(ByVal Value As String)
            M_Ma_Ct = Value
        End Set
    End Property
    Dim M_Stt_Rec As String = ""
    Public Property Stt_Rec() As String
        Get
            Stt_Rec = M_Stt_Rec
        End Get
        Set(ByVal Value As String)
            M_Stt_Rec = Value
        End Set
    End Property
    Dim M_Dien_Thoai As String = ""
    Public Property Dien_Thoai() As String
        Get
            Dien_Thoai = M_Dien_Thoai
        End Get
        Set(value As String)
            M_Dien_Thoai = value
        End Set
    End Property
    Dim dtMasterRo, dtMasterHeaderRo As New DataTable
    Dim vdtMasterRo, vdtMasterHeaderRo As New DataView

    Dim dtDetailCvRo, dtDetailHeaderCvRo As New DataTable
    Dim vdtDetailCvRo, vdtDetailHeaderCvRo As New DataView

    Dim dtDetailVtRo, dtDetailHeaderVtRo As New DataTable
    Dim vdtDetailVtRo, vdtDetailHeaderVtRo As New DataView

    Dim dtDetailRVR, dtDetailHeaderRVR As New DataTable
    Dim vdtDetailRVR, vdtDetailHeaderRVR As New DataView

    Dim dtDetailRS, dtDetailHeaderRS As New DataTable
    Dim vdtDetailRS, vdtDetailHeaderRS As New DataView

    Dim dtDetailTD, dtDetailHeaderTD As New DataTable
    Dim vdtDetailTD, vdtDetailHeaderTD As New DataView

    Dim dtDetailVRC, dtDetailHeaderVRC As New DataTable
    Dim vdtDetailVRC, vdtDetailHeaderVRC As New DataView

    Dim LabTieu_Chi As String = ""

    Dim _LenMin As Integer
    Dim CyberColor As New Cyber.Color.Sys
    Private Sub FrmLichSu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        Try
            _LenMin = Me.Para(Me.M_VT_PARA + 2)
        Catch ex As Exception
        End Try
        V_Load()
        V_AddHanderl()
        TxtMa_Xe.Text = M_Ma_Xe
        If Not TxtMa_Xe.Text.Trim = "" Then V_Search(sender, e)
    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_Load()
        If Not M_Ma_Xe = "" Then TxtMa_Xe.Text = M_Ma_Xe
        V_LoadDatabase(True)

        V_FillDataToGridview(DetailGRVRo_Master, M_LAN, vdtMasterHeaderRo, vdtMasterRo)
        V_FillDataToGridview(DetailGRVRo_DetailCv, M_LAN, vdtDetailHeaderCvRo, vdtDetailCvRo)
        V_FillDataToGridview(DetailGRVRo_DetailVt, M_LAN, vdtDetailHeaderVtRo, vdtDetailVtRo)

        V_FillDataToGridview(DetailGRVRVR, M_LAN, vdtDetailHeaderRVR, vdtDetailRVR)
        V_FillDataToGridview(DetailGRVRS, M_LAN, vdtDetailHeaderRS, vdtDetailRS)
        V_FillDataToGridview(DetailGRVTD, M_LAN, vdtDetailHeaderTD, vdtDetailTD)
        V_FillDataToGridview(DtGrvVRC, M_LAN, vdtDetailHeaderVRC, vdtDetailVRC)

        V_Menu(DetailGRVRo_Master, AddressOf V_EditVoucherRo)
        V_Menu(DetailGRVRVR, AddressOf V_EditVoucherRVR)
        V_Menu(DetailGRVRS, AddressOf V_EditVoucherRS)
        V_Menu(DetailGRVTD, AddressOf V_EditVoucherTD)
        V_Menu(DtGrvVRC, AddressOf V_EditVoucherVRC)

        V_SetGridview()
    End Sub
    Private Sub V_AddHanderl()
        AddHandler CmdSearch.Click, AddressOf V_Search
        AddHandler DetailGRVRo_Master.FocusedRowChanged, AddressOf DetailGRVRo_Master_FocusedRowChanged
        AddHandler DetailGRVRo_Master.RowCellStyle, AddressOf DetailGRVRo_Master_RowCellStyle
    End Sub
    Private Sub V_Menu(ByVal DetailGRVVt As DevExpress.XtraGrid.Views.Grid.GridView, ByVal Events As EventHandler)
        Dim mnItemsMail = New Windows.Forms.ContextMenu
        Dim mnItemsF3 As New MenuItem("Xem chi tiết chứng từ", Events, Keys.F3)
        mnItemsMail.MenuItems.Add(mnItemsF3)
        DetailGRVVt.GridControl.ContextMenu = mnItemsMail
    End Sub
    Private Sub V_SetGridview()
        'CustomGridview = New CustomGridview(Me, Me.sysVar, APPCONN, Me.Para, M_Stt_Rec)
        CyberFill.V_GridviewRowCellStyle(DetailGRVRo_Master) ' dt thuoc tinh Bold cho gridview
        CyberFill.V_GridviewRowCellStyle(DetailGRVRo_DetailCv)
        CyberFill.V_GridviewRowCellStyle(DetailGRVRo_DetailVt)
        CyberFill.V_GridviewRowCellStyle(DetailGRVRS)
        CyberFill.V_GridviewRowCellStyle(DetailGRVRVR)
        CyberFill.V_GridviewRowCellStyle(DetailGRVTD)
        CyberFill.V_GridviewRowCellStyle(DtGrvVRC)
    End Sub
    Private Sub V_Search(ByVal sender As System.Object, ByVal e As System.EventArgs)
        V_LoadDatabase(False)
    End Sub
    Private Sub DetailGRVRo_Master_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        V_BilldtingRo(sender, vdtMasterRo, vdtDetailCvRo)
        V_BilldtingRo(sender, vdtMasterRo, vdtDetailVtRo)
    End Sub
#Region "Edit voucher"
    Private Sub V_EditVoucherRo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberFill.V_EditVoucher(M_LAN, Me.Para, Me.Sysvar, AppConn, DetailGRVRo_Master)
    End Sub
    Private Sub V_EditVoucherRVR(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberFill.V_EditVoucher(M_LAN, Me.Para, Me.Sysvar, AppConn, DetailGRVRVR)
    End Sub
    Private Sub V_EditVoucherRS(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberFill.V_EditVoucher(M_LAN, Me.Para, Me.Sysvar, AppConn, DetailGRVRS)
    End Sub
    Private Sub V_EditVoucherTD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberFill.V_EditVoucher(M_LAN, Me.Para, Me.Sysvar, AppConn, DetailGRVTD)
    End Sub
    Private Sub V_EditVoucherVRC(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberFill.V_EditVoucher(M_LAN, Me.Para, Me.Sysvar, AppConn, DtGrvVRC)
    End Sub
#End Region
Private Sub V_LoadDatabase(ByVal isLoad As Boolean)
        Dim strFiled = "", strValues As String = ""
        CyberSmodb.GetValueControler(Me, strFiled, strValues, "")

        Dim strPara As String = TxtMa_Xe.Text.Trim & "#" & M_Ma_Ct.Trim & "#" & M_Ma_Dvcs.Trim & "#" & M_User_Name.Trim
        Dim DsXemPX As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoHistory", strPara)

        If DsXemPX Is Nothing OrElse DsXemPX.Tables.Count < 1 Then Exit Sub

        Dim nCount As Integer = DsXemPX.Tables.Count

        LabTieu_Chi = ""
        If DsXemPX.Tables(nCount - 1).Columns.Contains("Ghi_Chu") AndAlso DsXemPX.Tables(nCount - 1).Rows.Count >= 1 Then
            LabTieu_Chi = DsXemPX.Tables(nCount - 1).Rows(0).Item("Ghi_Chu").ToString()
        End If

        If isLoad Then

            If nCount > 0 Then dtDetailVtRo = DsXemPX.Tables(0).Clone
            If nCount > 1 Then dtMasterRo = DsXemPX.Tables(1).Clone
            If nCount > 2 Then dtDetailCvRo = DsXemPX.Tables(2).Clone
            If nCount > 3 Then dtDetailHeaderVtRo = DsXemPX.Tables(3).Copy
            If nCount > 4 Then dtMasterHeaderRo = DsXemPX.Tables(4).Copy
            If nCount > 5 Then dtDetailHeaderCvRo = DsXemPX.Tables(5).Copy

            If nCount > 6 Then dtDetailRVR = DsXemPX.Tables(6).Clone
            If nCount > 7 Then dtDetailHeaderRVR = DsXemPX.Tables(7).Copy

            If nCount > 8 Then dtDetailRS = DsXemPX.Tables(8).Clone
            If nCount > 9 Then dtDetailHeaderRS = DsXemPX.Tables(9).Copy

            If nCount > 10 Then dtDetailTD = DsXemPX.Tables(10).Clone
            If nCount > 11 Then dtDetailHeaderTD = DsXemPX.Tables(11).Copy

            If nCount > 12 Then dtDetailVRC = DsXemPX.Tables(12).Clone
            If nCount > 13 Then dtDetailHeaderVRC = DsXemPX.Tables(13).Copy

            vdtMasterRo = New DataView(dtMasterRo)
            vdtDetailCvRo = New DataView(dtDetailCvRo)
            vdtDetailVtRo = New DataView(dtDetailVtRo)
            vdtDetailRVR = New DataView(dtDetailRVR)
            vdtDetailRS = New DataView(dtDetailRS)
            vdtDetailTD = New DataView(dtDetailTD)
            vdtDetailVRC = New DataView(dtDetailVRC)

            vdtMasterHeaderRo = New DataView(dtMasterHeaderRo)
            vdtDetailHeaderCvRo = New DataView(dtDetailHeaderCvRo)
            vdtDetailHeaderVtRo = New DataView(dtDetailHeaderVtRo)
            vdtDetailHeaderRVR = New DataView(dtDetailHeaderRVR)
            vdtDetailHeaderRS = New DataView(dtDetailHeaderRS)
            vdtDetailHeaderTD = New DataView(dtDetailHeaderTD)
            vdtDetailHeaderVRC = New DataView(dtDetailHeaderVRC)

            DsXemPX.Dispose()
            Exit Sub
        End If
        '-------------------------------------------------------------------------
        If nCount > 0 Then
            dtDetailVtRo.Clear()
            For i As Integer = 0 To DsXemPX.Tables(0).Rows.Count - 1
                dtDetailVtRo.ImportRow(DsXemPX.Tables(0).Rows(i))
            Next
        End If

        If nCount > 1 Then
            dtMasterRo.Clear()
            For i As Integer = 0 To DsXemPX.Tables(1).Rows.Count - 1
                dtMasterRo.ImportRow(DsXemPX.Tables(1).Rows(i))
            Next
        End If

        If nCount > 2 Then
            dtDetailCvRo.Clear()
            For i As Integer = 0 To DsXemPX.Tables(2).Rows.Count - 1
                dtDetailCvRo.ImportRow(DsXemPX.Tables(2).Rows(i))
            Next
        End If
        '-------------------------------------------------------------------------
        If nCount > 6 Then
            dtDetailRVR.Clear()
            For i As Integer = 0 To DsXemPX.Tables(6).Rows.Count - 1
                dtDetailRVR.ImportRow(DsXemPX.Tables(6).Rows(i))
            Next
        End If
        '-------------------------------------------------------------------------
        If nCount > 8 Then
            dtDetailRS.Clear()
            For i As Integer = 0 To DsXemPX.Tables(8).Rows.Count - 1
                dtDetailRS.ImportRow(DsXemPX.Tables(8).Rows(i))
            Next
        End If
        '-------------------------------------------------------------------------
        If nCount > 10 Then
            dtDetailTD.Clear()
            For i As Integer = 0 To DsXemPX.Tables(10).Rows.Count - 1
                dtDetailTD.ImportRow(DsXemPX.Tables(10).Rows(i))
            Next
        End If
        '-------------------------------------------------------------------------
        If nCount > 12 Then
            dtDetailVRC.Clear()
            For i As Integer = 0 To DsXemPX.Tables(12).Rows.Count - 1
                dtDetailVRC.ImportRow(DsXemPX.Tables(12).Rows(i))
            Next
        End If

        DsXemPX.Dispose()
    End Sub
    Private Sub V_BilldtingRo(ByVal MasterGRV As DevExpress.XtraGrid.Views.Grid.GridView, ByVal Dv_Master As DataView, ByVal Dv_DetailTmp As DataView)
        If MasterGRV.GetFocusedRow Is Nothing Then Exit Sub
        If Not Dv_DetailTmp.Table.Columns.Contains("stt_rec") Then Exit Sub
        If Not Dv_Master.Table.Columns.Contains("stt_rec") Then Exit Sub
        If Dv_Master.Table.Rows.Count < 1 Then Exit Sub
        If Dv_Master.Table.Columns.Count < 1 Then Exit Sub
        Dim filter As String = "1=1"
        Dim selectedRow As DataRowView = Nothing
        Try
            selectedRow = MasterGRV.GetFocusedRow
            If (Not String.IsNullOrEmpty(selectedRow("stt_rec").ToString)) Then
                filter = "stt_rec='" + selectedRow("stt_rec").ToString() + "'"
                Dv_DetailTmp.RowFilter = filter
            End If
        Catch ex As Exception
            Dv_DetailTmp.RowFilter = "1=0"
        End Try
    End Sub
#Region "Color"
    Private Sub DetailGRVRo_Master_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        If dtMasterRo.Columns.Contains("Bold") Then
            Dim _FieldBold As String = ""
            _FieldBold = dtMasterRo.Columns("Bold").ColumnName
            Dim _categoryBold As String = DetailGRVRo_Master.GetRowCellDisplayText(e.RowHandle, _FieldBold).ToString.Trim
            If _categoryBold = "1" Then e.Appearance.Font = New Drawing.Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
        End If
        If Not sender.IsCellSelected(e.RowHandle, e.Column) Then
            If dtMasterRo.Columns.Contains("BackColor") Then
                Dim _FieldBackColor As String = dtMasterRo.Columns("BackColor").ColumnName
                Dim _categoryBackColor As String = DetailGRVRo_Master.GetRowCellDisplayText(e.RowHandle, _FieldBackColor).ToString.Trim
                '-------------
                e.Appearance.BackColor = CyberColor.GetBacColorkReports(_categoryBackColor)
            End If
        Else
            e.Appearance.BackColor = System.Drawing.Color.Silver
        End If
    End Sub
#End Region
    Private Sub V_FillDataToGridview(ByVal GRV As DevExpress.XtraGrid.Views.Grid.GridView, ByVal _M_lan As String, ByVal DvHeader As DataView, ByVal DvData As DataView)
        GRV.OptionsBehavior.Editable = False
        CyberFill.V_FillReports(GRV, _M_lan, DvHeader, DvData)
        GRV.GridControl.DataSource = DvData
    End Sub
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Save_OK = True
        Dim M_strParameterStore As String = ""
        Me.Tag = M_strParameterStore
        CyberSmlib.FlushMemorySave()
        Me.Close()
    End Sub
End Class