Imports System.Windows.Forms
Imports System.Drawing
Public Class ROUPDL
    Dim CyberProgress As New Sys
    Dim Dt_DetailCvTmp, Dt_DetailCvTmp_H, Dt_Detail, Dt_Detail_Temp As DataTable
    Dim Dv_DetailCvTmp, Dv_DetailCvTmp_H, Dv_Detail As DataView
    Dim osysvar As Collection
    Dim M_Ma_TTCP As String = ""
    Dim DrReturn As DataRow
    Dim DsLookup As New DataSet
    Dim EditMa_Hs As New Cyber.Fill.CyberColumnGridView
    Dim EditStt_Rec, EditStt_Rec0, EditMa_CT As New Cyber.Fill.CyberColumnGridView
    Dim M_DsHead As DataSet
    Dim List_Ma_CT As String = ""
    Private Sub FrmUpdate_KTV_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        If DsLookup Is Nothing Then DsLookup = New DataSet
        Me.Save_OK = False

        V_Load()
        V_GetColumn()
        V_AddHandler()
        V_MainSystem()
        CyberSupport.Translaste(Me, M_LAN, True)
    End Sub
#Region "Mainform"
    Private Sub V_MainSystem()
        Dim mnItemsMail = New ContextMenu
        Me.ContextMenu = mnItemsMail
    End Sub
    Private Sub MasterGRV_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim rowHandle As Integer = e.HitInfo.RowHandle
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            PopupMenuMasterGrid.ItemLinks.Clear()
            PopupMenuMasterGrid.ShowPopup(Control.MousePosition)
        End If
    End Sub
#End Region
#Region "Add Or Detete Item"
    Private Sub MasterGRV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim iCoumnVisible As Integer = DetailGRV.VisibleColumns.Count - 1
        Dim iRowVisible As Integer = DetailGRV.RowCount - 1
        Dim iRowRowFocus As Integer = DetailGRV.FocusedRowHandle
        Dim iColumnRowFocus As Integer = DetailGRV.VisibleColumns.IndexOf(DetailGRV.FocusedColumn)
        Dim iRowOld As Integer = DetailGRV.GetFocusedDataSourceRowIndex
        If iRowVisible <> iRowRowFocus Or iCoumnVisible <> iColumnRowFocus Then Exit Sub

        If e.KeyCode = Keys.Enter Then
        ElseIf e.KeyCode = Keys.End Then
            SendKeys.Send("^{Tab}")
        End If
    End Sub
#End Region
#Region "Load and System...."
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_AddHandler()
        AddHandler DetailGRV.RowCellStyle, AddressOf MasterGRV_RowCellStyle
        RemoveHandler DetailGRV.PopupMenuShowing, AddressOf MasterGRV_PopupMenuShowing

        RemoveHandler CmdSelectAll.Click, AddressOf V_SelectAll
        RemoveHandler CmdRemoveAll.Click, AddressOf V_RemoveAll
        RemoveHandler CmbbXuatExcel.Click, AddressOf V_XuatExcel

        AddHandler DetailGRV.PopupMenuShowing, AddressOf MasterGRV_PopupMenuShowing
        AddHandler CmdSelectAll.Click, AddressOf V_SelectAll
        AddHandler CmdRemoveAll.Click, AddressOf V_RemoveAll
        AddHandler CmbbXuatExcel.Click, AddressOf V_XuatExcel

        AddHandler BttLay_Dl.Click, AddressOf V_Search
        AddHandler ButtOK.Click, AddressOf V_Save
        V_AddHandler_Detail()
    End Sub
    Private Sub V_AddHandler_Detail()
        If Not EditMa_Hs.Column Is Nothing Then AddHandler EditMa_Hs.EditColumn.Leave, AddressOf L_Update_Grid
        EditMa_Hs.V_ActiLookUpColumn(AddressOf V_Ma_Hs, AddressOf L_Ma_Hs)

    End Sub
    Private Sub V_Load()
        Dim Dt As DataTable
        Dim _Dstmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_ReviewVoucherLoadDmctCopy", List_Ma_CT & "#" & M_Ma_Dvcs & "#" & M_User_Name)
        Dt = _Dstmp.Tables(0).Copy
        If M_Ma_Ct.Trim = "" And Dt.Rows.Count > 0 Then M_Ma_Ct = Dt.Rows(0).Item("Ma_Ct").ToString.Trim
        Dim _Chk As Boolean = False
        For i = 0 To Dt.Rows.Count - 1
            If Dt.Rows(i).Item("Ma_Ct").ToString.Trim.ToUpper = M_Ma_Ct.Trim.ToUpper Then
                _Chk = True
                '        Exit Sub
            End If
        Next
        If Not _Chk Then
            M_Ma_Ct = ""
            If Dt.Rows.Count > 0 Then M_Ma_Ct = Dt.Rows(0).Item("Ma_Ct")
        End If
        TxtM_Ngay_Ct1.Value = Now.Date
        TxtM_Ngay_Ct2.Value = Now.Date
        TxtM_Ngay_Ct1.Text = CyberSmlib.GetKeyValueRegistryDate(Me.Sysvar, TxtM_Ngay_Ct1)
        TxtM_Ngay_Ct2.Text = CyberSmlib.GetKeyValueRegistryDate(Me.Sysvar, TxtM_Ngay_Ct2)

        V_Loaddatatabse("1")
        CyberFill.V_FillVoucher(DetailGRV, M_LAN, Dv_DetailCvTmp_H, Dv_DetailCvTmp)
        'DetailGRV.GridControl.DataSource = Dv_DetailCvTmp

        For i As Integer = 0 To DetailGRV.Columns.Count - 1
            DetailGRV.Columns(i).OptionsFilter.AllowAutoFilter = True
            DetailGRV.Columns(i).OptionsFilter.AllowFilter = True
            DetailGRV.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next

    End Sub
    Private Sub V_GetColumn()
        EditMa_Hs.GetColumn(DetailGRV, "Ma_Hs")

    End Sub
    Private Sub MasterGRV_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim Dt_Master As New DataTable
        Dim vDt_Master As New DataView
        Dim Grid As New DevExpress.XtraGrid.Views.Grid.GridView
        Dim CyberColor As New Cyber.Color.Sys
        Grid = sender

        If Grid.DataSource.GetType.Name.Trim.ToUpper = "DATAVIEW" Then
            vDt_Master = Grid.DataSource
            Dt_Master = vDt_Master.Table
        Else
            Dt_Master = Grid.DataSource
        End If

        If Dt_Master.Columns.Contains("Bold") Then
            Dim _FieldBold As String = ""
            _FieldBold = Dt_Master.Columns("Bold").ColumnName
            Dim _categoryBold As String = Grid.GetRowCellDisplayText(e.RowHandle, _FieldBold).ToString.Trim
            If _categoryBold = "1" Then e.Appearance.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
        End If

        If Not sender.IsCellSelected(e.RowHandle, e.Column) Then
            If Dt_Master.Columns.Contains("BackColor") Then
                Dim _FieldBackColor As String = ""
                _FieldBackColor = Dt_Master.Columns("BackColor").ColumnName
                Dim _categoryBackColor As String = Grid.GetRowCellDisplayText(e.RowHandle, _FieldBackColor).ToString.Trim
                e.Appearance.BackColor = CyberColor.GetBacColorkReports(_categoryBackColor)
            End If
            If Dt_Master.Columns.Contains("BackColor2") Then
                Dim _FieldBackColor2 As String = ""
                _FieldBackColor2 = Dt_Master.Columns("BackColor2").ColumnName
                Dim _categoryBackColor2 As String = Grid.GetRowCellDisplayText(e.RowHandle, _FieldBackColor2).ToString.Trim
                e.Appearance.BackColor2 = CyberColor.GetBacColorkReports(_categoryBackColor2)
            End If
        Else
            e.Appearance.BackColor = System.Drawing.Color.Silver
        End If
    End Sub
#End Region
#Region "Valid And Input KTV"
    Private Sub L_Update_Grid()
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
    End Sub
#End Region
#Region "Valid"
    Private Sub V_XuatExcel(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _Dt_Title As New DataTable
        _Dt_Title.Columns.Add("Title1")
        _Dt_Title.Columns.Add("Title2")
        _Dt_Title.Columns.Add("Tu_ngay")
        Dim _Title As String = Me.Text.Trim
        Dim _Tu_Ngay As String = "TỪ NGÀY "
        _Title = _Title.ToUpper
        _Tu_Ngay = _Tu_Ngay.ToUpper
        _Dt_Title.Rows.Add(_Title, _Title, _Tu_Ngay)
        Dim _Dv_Title As DataView = New DataView(_Dt_Title)
        If CyberExport Is Nothing Then CyberExport = New Cyber.Export.Sys
        CyberExport.V_ExportToXls(AppConn, Me.DetailGRV, _Dv_Title, Dv_Detail, Me.Para, Me.Sysvar, Me.Lan, M_Ma_Dvcs, M_User_Name, "C:\CYBER_DsXE.xls")
    End Sub
#End Region
#Region "Valid - Detail"
#Region "Valid - Ma_Hs"
    Dim M_Mode As String = "M"
    Dim M_Ma_Ct As String = ""
    Private Sub V_Ma_Hs(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim _Keyclient As String = "1=1"
        Dim _KeySQL As String = "1=1"
        Dim _Ma_To As String = ""
        _KeySQL = _KeySQL + " AND Ma_Dvcs = N'" + M_Ma_Dvcs.Trim + "'"
        If _Ma_To.Trim <> "" Then _Keyclient = _Keyclient
        CyberSupport.V_Lookup("Ma_Hs", "DMHs", _KeySQL, _Keyclient, M_Mode, M_Ma_Ct, M_LAN, Me.Para, Me.Sysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Hs(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then
            Exit Sub
        End If
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_Ct, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailCvTmp.Item(iRow).BeginEdit()
            Dt_DetailCvTmp.Rows(iRow).Item("Ma_Hs") = ""
            If Dt_DetailCvTmp.Columns.Contains("Ten_Hs") Then Dv_DetailCvTmp.Item(iRow).Item("Ten_Hs") = ""
            Dv_DetailCvTmp.Item(iRow).EndEdit()
            Exit Sub
        Else
            Dv_DetailCvTmp.Item(iRow).BeginEdit()
            Dv_DetailCvTmp.Item(iRow).Item("Ma_Hs") = DrReturn("Ma_Hs").ToString.Trim
            If Dt_DetailCvTmp.Columns.Contains("Ten_Hs") Then Dv_DetailCvTmp.Item(iRow).Item("Ten_Hs") = DrReturn("Ten_Hs").ToString.Trim
            Dv_DetailCvTmp.Item(iRow).EndEdit()
        End If
        Dv_DetailCvTmp.Table.AcceptChanges()
        DetailGRV.UpdateCurrentRow()
    End Sub
#End Region
#End Region
#Region "Fix lai"
    Private Sub V_Loaddatatabse(ByVal _Status As String)
        Dim _ngay_Ct1 As Date = TxtM_Ngay_Ct1.Value
        Dim _ngay_Ct2 As Date = TxtM_Ngay_Ct2.Value

        Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_ROUPDATE_Load", _Status & "#" & _ngay_Ct1.ToString("yyyyMMdd") & "#" & _ngay_Ct2.ToString("yyyyMMdd").Trim & "#" & M_Ma_Dvcs & "#" & M_User_Name)
        For i As Integer = 0 To DsTmp.Tables.Count - 1
            CyberSmodb.SetNotNullTable(DsTmp.Tables(i))
        Next
        If _Status = "1" Then
            Dt_DetailCvTmp = DsTmp.Tables(0).Copy
            Dt_Detail_Temp = DsTmp.Tables(1).Copy
            Dt_DetailCvTmp_H = DsTmp.Tables(2).Copy

            Dv_DetailCvTmp = New DataView(Dt_DetailCvTmp)
            Dv_DetailCvTmp_H = New DataView(Dt_DetailCvTmp_H)
        Else
            Dt_DetailCvTmp.Clear()
            Dt_DetailCvTmp.Load(DsTmp.Tables(0).CreateDataReader)
            Dt_Detail_Temp.Load(DsTmp.Tables(1).CreateDataReader)
            Dt_DetailCvTmp.AcceptChanges()
        End If
        DsTmp.Dispose()
    End Sub
    Private Sub V_Search()
        V_Loaddatatabse("0")
    End Sub
    Private Sub V_Save()
        Me.Save_OK = False
        Dim Dt1 As Date = TxtM_Ngay_Ct1.Value
        Dim Dt2 As Date = TxtM_Ngay_Ct2.Value

        Dim strXML As String = ""
        Dt_Detail_Temp.Clear()
        CyberSmodb.SQLTbToTb(Dt_DetailCvTmp, Dt_Detail_Temp)

        ' Giam bớt dữ liệu load XML
        Dim count As Integer = Dt_Detail_Temp.Rows.Count - 1
        For i As Integer = count To 0 Step -1
            If Dt_Detail_Temp.Rows(i).Item("Is_XN").ToString = 0 Then
                Dt_Detail_Temp.Rows.RemoveAt(i)
            End If
        Next

        strXML = CyberSmodb.V_ConvertDataToXML({"CTTD"}, {Dt_Detail_Temp})
        Dim dSave As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_ROUPDATE_Save", strXML + "#" + Dt1.ToString("yyyyMMdd") + "#" + Dt2.ToString("yyyyMMdd") + "#" + M_Ma_Dvcs + "#" + M_User_Name)
        If Not CyberSupport.V_MsgChk(dSave.Tables(0), Me.Sysvar, M_LAN) Then
            dSave.Dispose()
            Exit Sub
        End If
        dSave.Dispose()

    End Sub
    Private Sub V_Exits(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Tag = ""
        Me.Save_OK = False
        CyberSmlib.FlushMemorySave()

        Me.Close()
    End Sub
    Private Sub V_SelectAll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        For i = 0 To Dt_DetailCvTmp.Rows.Count - 1
            Dt_DetailCvTmp.Rows(i).BeginEdit()
            Dt_DetailCvTmp.Rows(i).Item("Tag") = True
            Dt_DetailCvTmp.Rows(i).EndEdit()
            Dt_DetailCvTmp.AcceptChanges()
        Next
    End Sub
    Private Sub V_RemoveAll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        For i = 0 To Dt_DetailCvTmp.Rows.Count - 1
            Dt_DetailCvTmp.Rows(i).BeginEdit()
            Dt_DetailCvTmp.Rows(i).Item("Tag") = False
            Dt_DetailCvTmp.Rows(i).EndEdit()
            Dt_DetailCvTmp.AcceptChanges()
        Next
    End Sub
#End Region
End Class
