Imports System.Windows.Forms
Imports System.Drawing
Public Class ROHDSUPDL
    Dim CyberProgress As New Sys
    Dim Dt_DetailCvTmp, Dt_DetailCvTmp_H, Dt_Detail_Temp As DataTable
    Dim Dv_DetailCvTmp, Dv_DetailCvTmp_H, Dv_Detail As DataView
    Dim osysvar As Collection
    Dim M_Ma_TTCP As String = ""
    Dim M_Para As String() = Me.Para
    Dim DrReturn As DataRow
    Dim DsLookup As New DataSet
    Dim EditMa_TD3, EditMa_VV, EditMa_KH As New Cyber.Fill.CyberColumnGridView
    Dim EditStt_Rec, EditStt_Rec0, EditMa_CT As New Cyber.Fill.CyberColumnGridView
    Dim M_DsHead As DataSet
    Dim List_Ma_CT As String = ""
    Private Sub FrmUpdate_KTV_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        If DsLookup Is Nothing Then DsLookup = New DataSet
        Me.Save_OK = False
        Try
            M_Ma_Ct = Me.Para(Me.M_VT_PARA + 4).ToString.Trim

        Catch ex As Exception
        End Try
        Try
            List_Ma_CT = Me.Para(Me.M_VT_PARA + 3).ToString.Trim
        Catch ex As Exception

        End Try

        If List_Ma_CT <> "" Then
            List_Ma_CT = List_Ma_CT.Trim.Replace(" ", "")
        End If
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
        'RemoveHandler DetailGRV.RowCellStyle, AddressOf DetailGRV_RowCellStyle

        RemoveHandler CmdSelectAll.Click, AddressOf V_SelectAll
        RemoveHandler CmdRemoveAll.Click, AddressOf V_RemoveAll

        AddHandler DetailGRV.PopupMenuShowing, AddressOf MasterGRV_PopupMenuShowing
        'AddHandler DetailGRV.RowCellStyle, AddressOf DetailGRV_RowCellStyle
        AddHandler CmdSelectAll.Click, AddressOf V_SelectAll
        AddHandler CmdRemoveAll.Click, AddressOf V_RemoveAll

        AddHandler BttLay_Dl.Click, AddressOf V_Search
        AddHandler ButtOK.Click, AddressOf V_Save
        V_AddHandler_Detail()
    End Sub
    Private Sub V_AddHandler_Detail()

        If Not EditMa_KH.Column Is Nothing Then AddHandler EditMa_KH.EditColumn.Leave, AddressOf L_Update_Grid
        EditMa_KH.V_ActiLookUpColumn(AddressOf V_Ma_KH, AddressOf L_Ma_KH)

        If Not EditMa_TD3.Column Is Nothing Then AddHandler EditMa_TD3.EditColumn.Leave, AddressOf L_Update_Grid
        EditMa_TD3.V_ActiLookUpColumn(AddressOf V_Ma_TD3, AddressOf L_Ma_TD3)

        If Not EditMa_VV.Column Is Nothing Then AddHandler EditMa_VV.EditColumn.Leave, AddressOf L_Update_Grid
        EditMa_VV.V_ActiLookUpColumn(AddressOf V_Ma_VV, AddressOf L_Ma_VV)
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
        CyberFill.V_FillComBoxValue(CbbLoai_Chuyen, Dt, "Ma_Ct", If(Me.M_LAN = "V", "ten_Ct", "Ten_Ct2"), M_Ma_Ct)

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
        EditMa_TD3.GetColumn(DetailGRV, "Ma_TD3")
        EditMa_VV.GetColumn(DetailGRV, "Ma_VV")
        EditMa_KH.GetColumn(DetailGRV, "Ma_KH")
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
#End Region
#Region "Valid - Detail"
#Region "Valid - Ma_TD3"
    Dim M_Mode As String = "M"
    Dim M_Ma_Ct As String = ""
    Private Sub V_Ma_TD3(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim _Keyclient As String = "1=1"
        Dim _KeySQL As String = "1=1"
        Dim _Ma_To As String = ""
        _KeySQL = _KeySQL + " AND Ma_Dvcs = N'" + M_Ma_Dvcs.Trim + "'"
        If _Ma_To.Trim <> "" Then _Keyclient = _Keyclient
        CyberSupport.V_Lookup("Ma_TD3", "DMTD3", _KeySQL, _Keyclient, M_Mode, M_Ma_Ct, M_LAN, Me.Para, Me.Sysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD3(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            Dt_DetailCvTmp.Rows(iRow).Item("Ma_TD3") = ""
            If Dt_DetailCvTmp.Columns.Contains("Ten_TD3") Then Dv_DetailCvTmp.Item(iRow).Item("Ten_TD3") = ""
            If Dt_DetailCvTmp.Columns.Contains("Ma_HD") Then Dv_DetailCvTmp.Item(iRow).Item("Ma_HD") = ""
            Dv_DetailCvTmp.Item(iRow).EndEdit()
            Exit Sub
        Else
            Dv_DetailCvTmp.Item(iRow).BeginEdit()
            Dv_DetailCvTmp.Item(iRow).Item("Ma_TD3") = DrReturn("Ma_TD3").ToString.Trim
            If Dt_DetailCvTmp.Columns.Contains("Ten_TD3") Then Dv_DetailCvTmp.Item(iRow).Item("Ten_TD3") = DrReturn("Ten_TD3").ToString.Trim
            If Dt_DetailCvTmp.Columns.Contains("Ma_HD") Then Dv_DetailCvTmp.Item(iRow).Item("Ma_HD") = DrReturn("Ma_HD").ToString.Trim
            Dv_DetailCvTmp.Item(iRow).EndEdit()
        End If
        Dv_DetailCvTmp.Table.AcceptChanges()
        DetailGRV.UpdateCurrentRow()
    End Sub
#End Region
#Region "Valid - Ma_VV"
    Private Sub V_Ma_VV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim _Keyclient As String = "1=1"
        Dim _KeySQL As String = "1=1"
        Dim _Ma_To As String = ""
        _KeySQL = _KeySQL + " AND Ma_Dvcs = N'" + M_Ma_Dvcs.Trim + "'"
        If _Ma_To.Trim <> "" Then _Keyclient = _Keyclient
        CyberSupport.V_Lookup("Ma_VV", "DMVV", _KeySQL, _Keyclient, M_Mode, M_Ma_Ct, M_LAN, Me.Para, Me.Sysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_VV(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            Dt_DetailCvTmp.Rows(iRow).Item("Ma_VV") = ""
            Dv_DetailCvTmp.Item(iRow).EndEdit()
            Exit Sub
        Else
            Dv_DetailCvTmp.Item(iRow).BeginEdit()
            Dv_DetailCvTmp.Item(iRow).Item("Ma_VV") = DrReturn("Ma_VV").ToString.Trim
            Dv_DetailCvTmp.Item(iRow).EndEdit()
        End If
        Dv_DetailCvTmp.Table.AcceptChanges()
        DetailGRV.UpdateCurrentRow()
    End Sub
#End Region
#Region "Valid - Ma_KH"
    Private Sub V_Ma_KH(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim _Keyclient As String = "1=1"
        Dim _KeySQL As String = "1=1"
        Dim _Ma_To As String = ""
        _KeySQL = _KeySQL + " AND Ma_Dvcs = N'" + M_Ma_Dvcs.Trim + "'"
        If _Ma_To.Trim <> "" Then _Keyclient = _Keyclient
        CyberSupport.V_Lookup("Ma_KH", "DMKH", _KeySQL, _Keyclient, M_Mode, M_Ma_Ct, M_LAN, Me.Para, Me.Sysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_KH(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            Dt_DetailCvTmp.Rows(iRow).Item("Ma_KH") = ""
            If Dt_DetailCvTmp.Columns.Contains("Ten_KH") Then Dv_DetailCvTmp.Item(iRow).Item("Ten_KH") = ""
            Dv_DetailCvTmp.Item(iRow).EndEdit()
            Exit Sub
        Else
            Dv_DetailCvTmp.Item(iRow).BeginEdit()
            Dv_DetailCvTmp.Item(iRow).Item("Ma_KH") = DrReturn("Ma_KH").ToString.Trim
            If Dt_DetailCvTmp.Columns.Contains("Ten_KH") Then Dv_DetailCvTmp.Item(iRow).Item("Ten_KH") = DrReturn("Ten_KH").ToString.Trim
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

        Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RO_HDSUPDL_Load", _Status & "#" & CbbLoai_Chuyen.SelectedValue.ToString & "#" & _ngay_Ct1.ToString("yyyyMMdd") & "#" & _ngay_Ct2.ToString("yyyyMMdd").Trim & "#" & M_Ma_Dvcs & "#" & M_User_Name)
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
            If Dt_Detail_Temp.Rows(i).Item("Tag").ToString = 0 Then
                Dt_Detail_Temp.Rows.RemoveAt(i)
            End If
        Next

        strXML = CyberSmodb.V_ConvertDataToXML({"PH88"}, {Dt_Detail_Temp})
        Dim dSave As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RO_HDSUPDL_Save", strXML + "#" + Dt1.ToString("yyyyMMdd") + "#" + Dt2.ToString("yyyyMMdd") + "#" + M_Ma_Dvcs + "#" + M_User_Name)
        If Not CyberSupport.V_MsgChk(dSave.Tables(0), Me.Sysvar, M_LAN) Then
            dSave.Dispose()
            Exit Sub
        End If
        dSave.Dispose()
        'MsgBox("Lưu dữ liệu thành công", MsgBoxStyle.OkOnly, M_CYBER_VER)
        'V_RemoveAll(New System.Object, New System.EventArgs)

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
