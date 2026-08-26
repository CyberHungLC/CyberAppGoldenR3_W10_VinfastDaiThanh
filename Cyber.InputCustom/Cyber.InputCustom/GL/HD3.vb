Imports System.Data.SqlClient
Public Class HD3
#Region "Khai bao bien Property----------------------"
    Dim M_strFilter As String = "1=1"
    Dim M_DrDmct As DataRow
    Dim osysvar As Collection
    Dim M_Para As String() = Me.Para
    Dim M_AppConn As SqlConnection
    Dim M_DsData, M_DsHead, M_DsLookUp, DSMaTT As DataSet
    Dim DtMaTT As DataTable
    Dim M_Ma_TT As String = "I"
#End Region
#Region "Khai bao bien Paramater----------------------"
    '-----
    Dim M_HT_TT, M_Ma_THue As String
#End Region
#Region "Khai bao bien Dll"
    Dim CyberInput As New Cyber.Input.Sys
    Dim CyberMe As New Cyber.From.Frmvoucher
    Dim CyberFrom As New Cyber.From.Sys

    Dim CyberFillColumn As New Cyber.Fill.CyberColumnGridView
#End Region
#Region "Columns Edit"
    Dim EditTk_DT, EditTk_CK As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
    Dim EditMa_KH_I, EditMa_Vv_I, EditMa_phi_i, EditMa_HD_I, EditMa_Sp_I, EditMa_ku_I, EditMa_TTLN_i, EditMa_TTCP_i, EditMa_BP_I, EditMa_HS_I, EditMa_CD_I, EditMa_TD1_I, EditMa_TD2_I, EditMa_TD3_I, EditMa_TD4_I, EditMa_TD5_I As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
    Dim Editma_Db_I, EditMa_Xe_I, EditMa_KX_I, EditMa_Tuyen_I, EditMa_Ts, EditMa_Cc As New Cyber.Fill.CyberColumnGridView 'New Cyber.SmLists.EditLookUp
    Dim EditDVT, EditTen_Tk_DT, EditTen_Tk_CK, EditSo_Luong, EditGia_NT2, EditGia2, EditTien_NT2, EditTien2, EditPT_CK, EditCK_NT, EditCK, EditThue_Suat, EditDien_Giaii, EditSo_So, EditSo_Po, EditSo_Ro, EditSo_VT As New Cyber.Fill.CyberColumnGridView 'DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Dim EditKhacMa_TT, EditKhacMa_BH, EditKhacMa_LHBH, EditKhacMa_Vitri, EditKhacMa_Vv_I, EditKhacMa_Phi_i, EditKhacMa_HD_I, EditKhacMa_SP_I, EditKhacMa_Ku_I, EditKhacMa_TTLN_i, EditKhacMa_TTCP_i, EditKhacMa_BP_I, EditKhacMa_HS_I, EditKhacMa_CD_I, EditKhacMa_TD1_I, EditKhacMa_TD2_I, EditKhacMa_TD3_I, EditKhacMa_TD4_I, EditKhacMa_TD5_I As New Cyber.Fill.CyberColumnGridView

    Dim EditKhacSo_So, EditKhacSo_Po, EditKhacSo_Ro, EditKhacSo_VT As New Cyber.Fill.CyberColumnGridView
    Dim Dt_DetailKhac, Dt_DetailtmpKhac As New DataTable
    Dim Dv_DetailKhac, Dv_DetailtmpKhac As New DataView
#End Region
#Region "Khai bao bien Private"



    Dim M_Ct, M_Ph As String
    Dim DrReturn As DataRow
    Dim M_Count As Integer = 1
    Dim DtPost, DtMaGD As DataTable
#End Region
    Private Sub HD1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        V_Load()
        If DrDmct.Table.Columns.Contains("NonVAT") Then ChkNonVAT.Visible = (DrDmct.Item("NonVAT").ToString.Trim = "1")
        If DrDmct.Table.Columns.Contains("CaptionNonVAT") Then If DrDmct.Item("CaptionNonVAT").ToString.Trim <> "" Then ChkNonVAT.Text = DrDmct.Item("CaptionNonVAT").ToString.Trim
        V_GetColumn()
        V_AddHandler()
        V_Databing()
        M_Mode = "X"
        M_Count = Dt_Master.Rows.Count
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_MainSystem()
        V_MainSystemKHAC()
        GetRound()
        CmdNew.Select()
    End Sub
#Region "Load And Set And Default"
    Private Sub V_Load()
        V_Getdefault()
        Dt_Detail = M_DsData.Tables(0)
        Dt_DetailTmp = Dt_Detail.Clone
        Dt_Master = M_DsData.Tables(1)

        Dt_DetailKhac = M_DsData.Tables(2)
        Dt_DetailtmpKhac = Dt_DetailKhac.Clone

        Dv_Detail = New DataView(Dt_Detail)
        Dv_DetailTmp = New DataView(Dt_DetailTmp)
        Dv_Master = New DataView(Dt_Master)

        Dv_DetailKhac = New DataView(Dt_DetailKhac)
        Dv_DetailtmpKhac = New DataView(Dt_DetailtmpKhac)

        Detail.DataSource = Dv_DetailTmp
        Me.DetailGRV.GridControl = Me.Detail
        CyberFill.V_FillVoucher(DetailGRV, M_LAN, New DataView(M_DsHead.Tables(1)), Dv_DetailTmp, Me.DrDmct)

        DetailKhac.DataSource = Dv_DetailtmpKhac
        Me.DetailKhacGRV.GridControl = Me.DetailKhac
        CyberFill.V_FillVoucher(DetailKhacGRV, M_LAN, New DataView(M_DsHead.Tables(2)), Dv_DetailtmpKhac, Me.DrDmct)

        V_SetProperty()
        CyberSupport.Translaste(Me, M_LAN, True)
        ' M_Stt_Rec = CyberFrom.V_ViewVoucher(AppConn, osysvar, M_LAN, M_Para, DrDmct, DsData, DsHead, Dslookup, Dv_Master, Dv_Detail, M_Stt_Rec, strFilter, CyberFill, CyberSmlib, CyberSupport, True, True)
        TxtTy_Gia.InputMask = IIf(DrDmct.Item("M_IP_MK_TG").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TG").ToString.Trim, TxtTy_Gia.InputMask)

        TxtT_SO_LUONG.InputMask = IIf(DrDmct.Item("M_IP_MK_SL").ToString.Trim <> "", DrDmct.Item("M_IP_MK_SL").ToString.Trim, TxtT_SO_LUONG.InputMask)

        TxtT_Tien_NT2.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_Tien_NT2.InputMask)
        TxtT_Tien2.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Tien2.InputMask)

        TxtT_thue_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_thue_NT.InputMask)
        TxtT_Thue.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Thue.InputMask)

        TxtT_CK_Nt.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_CK_Nt.InputMask)
        TxtT_CK.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_CK.InputMask)

        TxtT_Tien_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_Tien_NT.InputMask)
        TxtT_Tien.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Tien.InputMask)

        TxtT_TT_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_TT_NT.InputMask)
        TxtT_TT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_TT.InputMask)

    End Sub
    Private Sub V_Getdefault()
        M_strFilter = Me.strFilter
        M_DrDmct = Me.DrDmct
        M_Ph = M_DrDmct.Item("M_Ph").ToString.Trim
        M_Ct = M_DrDmct.Item("M_Ct").ToString.Trim

        osysvar = Me.SysVar
        M_Stt_Rec = Me.Stt_Rec
        M_LAN = Me.Lan
        M_Para = Me.Para
        AppConn = Me.AppConn
        M_DsData = Me.DsData
        M_DsHead = Me.DsHead
        M_DsLookUp = Me.DsLookup

        Dim M_VT_PARA As Integer = CType(M_Para(0).Trim, Integer)
        K_Tmp = M_Para(1).Trim
        K_System = M_Para(2).Trim
        K_Repo = M_Para(3).Trim
        K_Repo_Nt = M_Para(4).Trim
        M_CYBER_VER = M_Para(5).Trim
        M_User_Name = M_Para(6).Trim
        M_Comment = M_Para(7).Trim
        M_is_Admin = CType(M_Para(8), Boolean)
        M_User_ID = M_Para(9).Trim
        M_Menu_ID0 = M_Para(10).Trim
        M_Bar = M_Para(11).Trim
        M_Bar2 = M_Para(12).Trim
        M_LAN = M_Para(13).Trim
        M_Ma_Dvcs = M_Para(14).Trim
        '---------------------------------------------------------------------------------------------'
        M_Ma_GD = M_Para(M_VT_PARA + 1).Trim
        M_Ma_CT = M_Para(M_VT_PARA + 2).Trim
        M_Ma_THue = M_Para(M_VT_PARA + 3).Trim
        M_HT_TT = M_Para(M_VT_PARA + 4).Trim
        'M_Stt_Rec = M_Para(M_Para.Length - 1).Trim
        '---------------------------------------------------------------------------------------------'

        M_Ma_Post = CyberSupport.V_GetMaxPost(AppConn, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
        '---
        M_Tk_No = DrDmct.Item("M_Tk_No").ToString.Trim
        M_Tk_Co = DrDmct.Item("M_Tk_Co").ToString.Trim
        M_Tk_Thue = DrDmct.Item("M_Tk_Thue").ToString.Trim
        M_Ma_Nt = DrDmct.Item("Ma_Nt").ToString.Trim
        M_Dien_Giai = DrDmct.Item("Dien_Giai").ToString.Trim

        If M_Tk_No.Trim <> "" Then M_Ten_Tk_No = CyberSmodb.SQLGetvalue(AppConn, "Ten_Tk", "Dmtk", "Tk = N'" + M_Tk_No.Trim + "'", CyberSmlib) Else M_Ten_Tk_No = ""
        If M_Tk_Co.Trim <> "" Then M_Ten_Tk_Co = CyberSmodb.SQLGetvalue(AppConn, "Ten_Tk", "Dmtk", "Tk = N'" + M_Tk_Co.Trim + "'", CyberSmlib) Else M_Ten_Tk_Co = ""
        If M_Tk_Thue.Trim <> "" Then M_Ten_Tk_Thue = CyberSmodb.SQLGetvalue(AppConn, "Ten_Tk", "Dmtk", "Tk = N'" + M_Tk_Thue.Trim + "'", CyberSmlib) Else M_Ten_Tk_Thue = ""

        DSMaTT = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_GetLoaiTT", M_Ma_CT & "#" & M_User_Name)
        DtMaTT = DSMaTT.Tables(0)

        DtPost = CyberSmodb.OpenTableKey(AppConn, Nothing, "DmPost", "Ma_Post", "Ma_Ct =N'" + M_Ma_CT + "'", CyberSmlib)
        DtMaGD = CyberSmodb.OpenTableKey(AppConn, Nothing, "DmMaGd", "Ma_GD", "Ma_Ct =N'" + M_Ma_CT + "'", CyberSmlib)
        CyberFill.V_FillComBoxValue(Me.CbbMa_Post, DtPost, "Ma_Post", If(M_LAN = "V", "Ten_Post", "Ten_Post2"), M_Ma_Post)
        CyberFill.V_FillComBoxValue(Me.CbbMa_GD, DtMaGD, "Ma_GD", If(M_LAN = "V", "Ten_GD", "Ten_GD2"), M_Ma_GD)
        CyberFill.V_FillComBoxValue(Me.CbbMa_TT, DtMaTT, "Ma_TT", If(M_LAN = "V", "Ten_TT", "Ten_TT"), M_Ma_TT)

        V_LoadDefault()
    End Sub
    Private Sub V_SetProperty()
        Me.Mode = M_Mode
        Me.Stt_Rec = M_Stt_Rec

        '---
        Dim FixCol As Integer = -1
        FixCol = DrDmct.Item("ColFrozen_master")

        If FixCol < DetailGRV.Columns.Count And FixCol > 0 Then
            For iCol = 0 To FixCol
                DetailGRV.Columns(iCol).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Next
        End If
        DetailGRV.OptionsNavigation.EnterMoveNextColumn = True
        Me.DetailGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.Brown

        '---
        If FixCol < DetailKhacGRV.Columns.Count And FixCol > 0 Then
            For iCol = 0 To FixCol
                DetailKhacGRV.Columns(iCol).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Next
        End If
        For i As Integer = 0 To DetailKhacGRV.Columns.Count - 1
            DetailKhacGRV.Columns(i).OptionsFilter.AllowAutoFilter = True
            DetailKhacGRV.Columns(i).OptionsFilter.AllowFilter = True
            DetailKhacGRV.Columns(i).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next

        DetailKhacGRV.OptionsNavigation.EnterMoveNextColumn = True
        Me.DetailKhacGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.Brown

    End Sub
    Private Sub V_GetColumn()
        EditDVT.GetColumn(DetailGRV, "DVT")
        EditTk_DT.GetColumn(DetailGRV, "Tk_DT")
        EditTen_Tk_DT.GetColumn(DetailGRV, "Ten_Tk_DT")
        EditTk_CK.GetColumn(DetailGRV, "Tk_CK")
        EditTen_Tk_CK.GetColumn(DetailGRV, "Ten_Tk_CK")
        EditDien_Giaii.GetColumn(DetailGRV, "DIEN_GIAII")
        EditSo_Luong.GetColumn(DetailGRV, "So_Luong")
        EditGia_NT2.GetColumn(DetailGRV, "Gia_NT2")
        EditGia2.GetColumn(DetailGRV, "Gia2")
        EditThue_Suat.GetColumn(Me.DetailGRV, "Thue_Suat")

        EditTien_NT2.GetColumn(DetailGRV, "TIEN_NT2")
        EditTien2.GetColumn(DetailGRV, "TIEN2")

        EditPT_CK.GetColumn(DetailGRV, "PT_CK")

        EditCK_NT.GetColumn(DetailGRV, "CK_NT")
        EditCK.GetColumn(DetailGRV, "CK")

        ''--
        EditMa_KH_I.GetColumn(DetailGRV, "Ma_KH_I")
        EditMa_Vv_I.GetColumn(DetailGRV, "Ma_Vv_I")
        EditMa_phi_i.GetColumn(DetailGRV, "Ma_Phi_I")
        EditMa_HD_I.GetColumn(DetailGRV, "Ma_HD_I")
        EditMa_Sp_I.GetColumn(DetailGRV, "Ma_SP_I")
        EditMa_ku_I.GetColumn(DetailGRV, "Ma_KU_I")
        EditMa_TTLN_i.GetColumn(DetailGRV, "Ma_TTLN_I")
        EditMa_TTCP_i.GetColumn(DetailGRV, "Ma_TTCP_I")
        EditMa_BP_I.GetColumn(DetailGRV, "Ma_BP_I")
        EditMa_HS_I.GetColumn(DetailGRV, "Ma_Hs_I")
        EditMa_CD_I.GetColumn(DetailGRV, "Ma_CD_I")

        EditMa_TD1_I.GetColumn(DetailGRV, "Ma_TD1_I")
        EditMa_TD2_I.GetColumn(DetailGRV, "Ma_TD2_I")
        EditMa_TD3_I.GetColumn(DetailGRV, "Ma_TD3_I")
        EditMa_TD4_I.GetColumn(DetailGRV, "Ma_TD4_I")
        EditMa_TD5_I.GetColumn(DetailGRV, "Ma_TD5_I")

        EditSo_So.GetColumn(DetailGRV, "SO_SO")
        EditSo_Po.GetColumn(DetailGRV, "SO_PO")
        EditSo_Ro.GetColumn(DetailGRV, "SO_RO")
        EditSo_VT.GetColumn(DetailGRV, "SO_VT")

        Editma_Db_I.GetColumn(DetailGRV, "Ma_Db_I")
        EditMa_Xe_I.GetColumn(DetailGRV, "MA_XE_I")
        EditMa_Tuyen_I.GetColumn(DetailGRV, "Ma_TUYEN_I")
        EditMa_Ts.GetColumn(DetailGRV, "Ma_Ts")
        EditMa_Cc.GetColumn(DetailGRV, "Ma_Cc")

        EditKhacMa_Vv_I.GetColumn(DetailKhacGRV, "Ma_Vv_I")
        EditKhacMa_Phi_i.GetColumn(DetailKhacGRV, "Ma_Phi_I")
        EditKhacMa_HD_I.GetColumn(DetailKhacGRV, "Ma_HD_I")
        EditKhacMa_SP_I.GetColumn(DetailKhacGRV, "Ma_SP_I")
        EditKhacMa_Ku_I.GetColumn(DetailKhacGRV, "Ma_Ku_I")
        EditKhacMa_TTLN_i.GetColumn(DetailKhacGRV, "Ma_TTLN_I")
        EditKhacMa_TTCP_i.GetColumn(DetailKhacGRV, "Ma_TTCP_I")
        EditKhacMa_BP_I.GetColumn(DetailKhacGRV, "Ma_BP_I")
        EditKhacMa_HS_I.GetColumn(DetailKhacGRV, "Ma_Hs_I")
        EditKhacMa_CD_I.GetColumn(DetailKhacGRV, "Ma_CD_I")

        EditKhacMa_TD1_I.GetColumn(DetailKhacGRV, "Ma_TD1_I")
        EditKhacMa_TD2_I.GetColumn(DetailKhacGRV, "Ma_TD2_I")
        EditKhacMa_TD3_I.GetColumn(DetailKhacGRV, "Ma_TD3_I")
        EditKhacMa_TD4_I.GetColumn(DetailKhacGRV, "Ma_TD4_I")
        EditKhacMa_TD5_I.GetColumn(DetailKhacGRV, "Ma_TD5_I")

        EditKhacSo_So.GetColumn(DetailKhacGRV, "SO_SO")
        EditKhacSo_Po.GetColumn(DetailKhacGRV, "SO_PO")
        EditKhacSo_Ro.GetColumn(DetailKhacGRV, "SO_RO")
        EditKhacSo_VT.GetColumn(DetailKhacGRV, "SO_VT")

    End Sub ' MINHDC
    Private Sub V_SetFocus(ByVal _Loai As String)
        _Loai = _Loai.Trim.ToUpper
        Select Case _Loai
            Case "M"
                If DrDmct.Item("M_Ngay_CT").ToString.Trim <> "1" Then TxtNgay_Ct.Focus() Else TxtMa_Kh.Focus()
            Case "S"
                If DrDmct.Item("M_Ngay_CT").ToString.Trim <> "1" Then TxtNgay_Ct.Focus() Else txtOng_ba.Focus()
            Case "L"
                CmdPrint.Select()
        End Select
    End Sub
    Private Sub GetRound()
        M_R_TIEN = DrDmct.Item("M_R_Tien")
        M_R_TIEN_NT = DrDmct.Item("M_R_Tien_NT")
        M_R_GIA = DrDmct.Item("M_R_GIA")
        M_R_GIA_NT = DrDmct.Item("M_R_GIA_NT")
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.ToUpper.Trim = osysvar("M_MA_NT0").ToString.Trim.ToUpper Then
            M_R_GIA_NT = M_R_GIA
            M_R_TIEN_NT = M_R_TIEN
        End If
    End Sub
#End Region
#Region "V_AddHandler"
    Private Sub V_AddHandler()
        V_AddHandler_System()
        V_AddHandler_Master()
        V_AddHandler_Detail()
        V_AddHandler_DetailKhac()
    End Sub
    Private Sub V_AddHandler_System()
        AddHandler Me.KeyDown, AddressOf FrmMain_KeyDown
        '---
        AddHandler CmdSave.Click, AddressOf V_Save
        AddHandler CmdNew.Click, AddressOf V_New
        AddHandler CmdEdit.Click, AddressOf V_Edit
        AddHandler CmdDelete.Click, AddressOf V_Delete
        AddHandler CmdCancel.Click, AddressOf V_Cancel
        AddHandler CmdPrint.Click, AddressOf V_Print
        AddHandler CmdView.Click, AddressOf V_View
        AddHandler CmdSearch.Click, AddressOf V_Search
        AddHandler CmdExit.Click, AddressOf V_Exit

        AddHandler CmdImport.Click, AddressOf V_Import
        AddHandler CmdCopy.Click, AddressOf V_Copy
        '---
        AddHandler DetailGRV.KeyDown, AddressOf MasterGRV_KeyDown

        AddHandler DetailKhacGRV.KeyDown, AddressOf MasterKhacGRV_KeyDown
        '---
        AddHandler CbbMa_GD.SelectedValueChanged, AddressOf L_Ma_GD
    End Sub
    Private Sub L_Ma_GD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        VisibleColumnMa_GD()
    End Sub
    Private Sub V_AddHandler_Master()
        AddHandler TxtMa_Quyen.Leave, AddressOf L_Ma_Quyen
        AddHandler TxtNgay_Ct.Leave, AddressOf V_Ngay_Ct
        AddHandler TxtNgay_LCt.Leave, AddressOf V_Ngay_LCt
        AddHandler TxtSo_ct.Enter, AddressOf V_So_Ct
        AddHandler TxtMa_NT.Leave, AddressOf L_Ma_NT
        AddHandler TxtTy_Gia.Leave, AddressOf L_Ty_Gia
        '--KH
        AddHandler TxtMa_Kh.CyberValiting, AddressOf V_Ma_KH
        AddHandler TxtMa_Kh.CyberLeave, AddressOf L_Ma_KH
        AddHandler TxtTen_KhVAT.Leave, AddressOf L_Ten_KhVAT
        AddHandler TxtDia_ChiVAT.Leave, AddressOf L_Ten_KhVAT
        AddHandler TxtDia_Chi.Leave, AddressOf L_Dia_Chi
        '--Ma_NX
        AddHandler txtMa_NX.CyberValiting, AddressOf V_Ma_NX
        AddHandler txtMa_NX.CyberLeave, AddressOf L_Ma_NX
        '--Ma_BP_H
        AddHandler TxtMa_Bp_H.CyberValiting, AddressOf V_Ma_BP_H
        AddHandler TxtMa_Bp_H.CyberLeave, AddressOf L_Ma_BP_H
        '--Ma_HS_H
        AddHandler txtMa_HS_H.CyberValiting, AddressOf V_Ma_HS_H
        AddHandler txtMa_HS_H.CyberLeave, AddressOf L_Ma_HS_H
        '--Ma_Thue
        'AddHandler TxtMa_Thue.Leave, AddressOf L_Ma_THue
        '--TK_Thue_Co
        AddHandler TxtTk_Thue_Co.CyberValiting, AddressOf V_Tk_Thue_Co
        AddHandler TxtTk_Thue_Co.CyberLeave, AddressOf L_Tk_Thue_Co
        '--TK_Thue_No
        AddHandler TxtTk_Thue_No.CyberValiting, AddressOf V_Tk_Thue_no
        AddHandler TxtTk_Thue_No.CyberLeave, AddressOf L_Tk_Thue_No
        '---
        AddHandler ChkSua_TkThue.CheckedChanged, AddressOf V_Sua_TkThue
        AddHandler ChkSua_Thue.CheckedChanged, AddressOf V_Sua_Thue
        AddHandler ChkSua_Thue_CK.CheckedChanged, AddressOf V_Sua_Thue_CK
        AddHandler ChkSua_CK.CheckedChanged, AddressOf V_Sua_Ck
        '----------
        AddHandler TxtT_CK_Nt.Leave, AddressOf L_T_CK_NT
        AddHandler TxtT_CK_Nt.Enter, AddressOf E_T_CK_NT
        AddHandler TxtT_thue_NT.Leave, AddressOf L_T_Thue_NT
        AddHandler TxtT_thue_NT.Enter, AddressOf E_T_Thue_NT
        '----------------------------------------------------------------------------------------------------------
        AddHandler TxtLenh_SO.Leave, AddressOf L_Lenh_So
        AddHandler TxtLenh_PO.Leave, AddressOf L_Lenh_Po
        AddHandler TxtLenh_RO.Leave, AddressOf L_Lenh_Ro
        AddHandler TxtLenh_Vt.Leave, AddressOf L_Lenh_VT

        ' TT hóa đơn điều chỉnh thay thế
        AddHandler TxtSo_Ct_TT.Leave, AddressOf V_Ma_CTTT
        AddHandler TxtSo_Seri_TT.Leave, AddressOf V_Ma_CTTT

        ' So_BG
        AddHandler TxtSo_BG.Leave, AddressOf L_So_BG

        'Hoa don dien tu
        'AddHandler BtnTaoHDDT.Click, AddressOf V_TaoHD0
        'AddHandler BtnSuaHDDT.Click, AddressOf V_UpdateHD
        'AddHandler BtnDCHD.Click, AddressOf V_DCHD
        'AddHandler BtnTTHD.Click, AddressOf V_TTHD
        'AddHandler BtnXemHDDT.Click, AddressOf V_XemHD
        'AddHandler BtnViewNhap.Click, AddressOf V_TaoNhap

        'AddHandler BtnChuyenDoiHDDT.Click, AddressOf V_ChuyenDoiHD
    End Sub
    'Private Sub V_TaoNhap()
    '    Dim api As New InvoiceMisa.MisaInvoice
    '    Dim Ngay As Date = TxtNgay_Ct.Value

    '    Dim DsData As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_API_CreateInvoice", "R" + "#" + Ngay.ToString("yyyyMMdd") + "#" + "" + "#" + "" + "#" + M_Stt_Rec.Trim + "#" + "" + "#" + M_Ma_CT.Trim + "#" + M_Ma_Dvcs.Trim + "#" + M_User_Name.Trim)

    '    If DsData.Tables(0).Rows(0)("Status").ToString.Trim.ToUpper <> "Y" Then
    '        MsgBox(DsData.Tables(0).Rows(0)("Note").ToString.Trim)
    '        Return
    '    End If

    '    Dim strError As String = ""
    '    Dim dtSave, dtInvoice As DataTable
    '    api.V_NhapHoaDon(DsData, dtSave, dtInvoice, strError)
    '    If strError = "" Then Exit Sub
    '    ' Mở PDF bằng trình duyệt
    '    Process.Start(strError)
    'End Sub

    '#Region "Chuyển đôỉ hóa đơn điện tử"
    '    Private Sub V_ChuyenDoiHD(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Dim strErr As String = "", _Loai_HD As String = "CP"
    '        Dim Link As String = ""
    '        Dim AppID As String = ""
    '        Dim Url As String = ""
    '        Dim UrlToken As String = ""
    '        Dim User_Name As String = ""
    '        Dim Password As String = ""
    '        Dim Tax As String = ""
    '        Dim data As Byte() = Nothing
    '        Dim sys As New InvoiceMisa.MisaInvoice
    '        Dim DsgetInvoid As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_API_LoadInvoice", _Loai_HD + "#" + M_Ma_CT + "#" + M_Stt_Rec + "#" + TxtMa_Dvcs.Text + "#" + M_User_Name)

    '        Dim Count_Tb As Integer
    '        Count_Tb = DsgetInvoid.Tables.Count

    '        If Not CyberSupport.V_MsgChk(DsgetInvoid.Tables(Count_Tb - 1), SysVar) Then
    '            DsgetInvoid.Dispose()
    '            Exit Sub
    '        End If


    '        If DsgetInvoid.Tables(0).Rows.Count <= 0 Then
    '            DsgetInvoid.Dispose()
    '            Exit Sub
    '        End If

    '        Dim _DtgetInvoid As DataTable = DsgetInvoid.Tables(0)

    '        If DsgetInvoid.Tables(1).Columns.Contains("AppID") Then AppID = DsgetInvoid.Tables(1).Rows(0).Item("AppID")
    '        If _DtgetInvoid.Columns.Contains("Url") Then Url = _DtgetInvoid.Rows(0).Item("Url")
    '        If _DtgetInvoid.Columns.Contains("UrlToken") Then UrlToken = _DtgetInvoid.Rows(0).Item("UrlToken")
    '        If _DtgetInvoid.Columns.Contains("user_name") Then User_Name = _DtgetInvoid.Rows(0).Item("user_name")
    '        If _DtgetInvoid.Columns.Contains("pass") Then Password = _DtgetInvoid.Rows(0).Item("pass")
    '        If _DtgetInvoid.Columns.Contains("tax") Then Tax = _DtgetInvoid.Rows(0).Item("tax")

    '        Dim filePdf As String = ""
    '        Dim strError As String = ""

    '        filePdf = sys.V_ChuyendoiHoaDon(
    '            Url,
    '            UrlToken,
    '            AppID,
    '            User_Name,
    '            Password,
    '            Tax,
    '            _DtgetInvoid.Rows(0).Item("Ma_Tra_Cuu"),
    '            _DtgetInvoid.Rows(0).Item("TenNguoiChuyenDoi"),
    '            Convert.ToDateTime(_DtgetInvoid.Rows(0).Item("NgayChuyenDoi")),
    '        strError
    '        )

    '        If filePdf.Trim = "" Then

    '            MsgBox(strError)
    '            Exit Sub

    '        End If

    '        Process.Start(
    '            New ProcessStartInfo(filePdf) With {
    '                .UseShellExecute = True
    '            }
    '        )

    '    End Sub
    '#End Region
    'Private Sub V_TaoHD0()
    '    V_TaoHD("T", "")
    'End Sub
    'Private Sub V_DCHD()
    '    V_TaoHD("DC", TxtStt_Rec_TT.Text)
    'End Sub
    'Private Sub V_TTHD()
    '    V_TaoHD("TT", TxtStt_Rec_TT.Text)
    'End Sub
    Private Sub V_AddHandler_Detail()
        If Not EditSo_Luong.Column Is Nothing Then AddHandler EditSo_Luong.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditGia_NT2.Column Is Nothing Then AddHandler EditGia_NT2.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditGia2.Column Is Nothing Then AddHandler EditGia2.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditTien_NT2.Column Is Nothing Then AddHandler EditTien_NT2.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditTien2.Column Is Nothing Then AddHandler EditTien2.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditPT_CK.Column Is Nothing Then AddHandler EditPT_CK.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditCK_NT.Column Is Nothing Then AddHandler EditCK_NT.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditCK.Column Is Nothing Then AddHandler EditCK.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditDien_Giaii.Column Is Nothing Then AddHandler EditDien_Giaii.EditColumn.Enter, AddressOf E_Dien_Giaii

        If Not EditThue_Suat.Column Is Nothing Then AddHandler EditThue_Suat.EditColumn.Leave, AddressOf L_Tinh_Toan
        '-------------------------------------
        EditTk_DT.V_ActiLookUpColumn(AddressOf V_Tk_DT, AddressOf L_Tk_DT)
        EditTk_CK.V_ActiLookUpColumn(AddressOf V_Tk_CK, AddressOf L_Tk_CK)
        '-------------------------------------
        '---Add On
        EditMa_KH_I.V_ActiLookUpColumn(AddressOf V_Ma_kh_i, AddressOf L_Ma_kh_i)
        EditMa_Vv_I.V_ActiLookUpColumn(AddressOf V_Ma_Vv_i, AddressOf L_Ma_Vv_i)
        EditMa_phi_i.V_ActiLookUpColumn(AddressOf V_Ma_Phi_i, AddressOf L_Ma_Phi_i)
        EditMa_HD_I.V_ActiLookUpColumn(AddressOf V_Ma_HD_i, AddressOf L_Ma_HD_i)
        EditMa_Sp_I.V_ActiLookUpColumn(AddressOf V_Ma_SP_i, AddressOf L_Ma_SP_i)
        EditMa_ku_I.V_ActiLookUpColumn(AddressOf V_Ma_KU_i, AddressOf L_Ma_KU_i)
        EditMa_TTLN_i.V_ActiLookUpColumn(AddressOf V_Ma_TTLN_i, AddressOf L_Ma_TTLN_i)
        EditMa_TTCP_i.V_ActiLookUpColumn(AddressOf V_Ma_TTCP_i, AddressOf L_Ma_TTCP_i)
        EditMa_BP_I.V_ActiLookUpColumn(AddressOf V_Ma_Bp_i, AddressOf L_Ma_Bp_i)
        EditMa_HS_I.V_ActiLookUpColumn(AddressOf V_Ma_HS_i, AddressOf L_Ma_HS_i)
        EditMa_CD_I.V_ActiLookUpColumn(AddressOf V_Ma_CD_i, AddressOf L_Ma_CD_i)
        EditMa_TD1_I.V_ActiLookUpColumn(AddressOf V_Ma_TD1_i, AddressOf L_Ma_TD1_i)
        EditMa_TD2_I.V_ActiLookUpColumn(AddressOf V_Ma_TD2_i, AddressOf L_Ma_TD2_i)
        EditMa_TD3_I.V_ActiLookUpColumn(AddressOf V_Ma_TD3_i, AddressOf L_Ma_TD3_i)
        EditMa_TD4_I.V_ActiLookUpColumn(AddressOf V_Ma_TD4_i, AddressOf L_Ma_TD4_i)
        EditMa_TD5_I.V_ActiLookUpColumn(AddressOf V_Ma_TD5_i, AddressOf L_Ma_TD5_i)

        Editma_Db_I.V_ActiLookUpColumn(AddressOf V_Ma_Db_i, AddressOf L_Ma_Db_i)
        EditMa_Xe_I.V_ActiLookUpColumn(AddressOf V_Ma_Xe_i, AddressOf L_Ma_Xe_i)
        EditMa_KX_I.V_ActiLookUpColumn(AddressOf V_Ma_Kx_i, AddressOf L_Ma_Kx_i)
        EditMa_Tuyen_I.V_ActiLookUpColumn(AddressOf V_Ma_Tuyen_i, AddressOf L_Ma_Tuyen_i)
        EditMa_Ts.V_ActiLookUpColumn(AddressOf V_Ma_Ts, AddressOf L_Ma_Ts)
        EditMa_Cc.V_ActiLookUpColumn(AddressOf V_Ma_Cc, AddressOf L_Ma_Cc)
        If Not EditSo_So.Column Is Nothing Then AddHandler EditSo_So.EditColumn.Leave, AddressOf L_So_So
        If Not EditSo_Po.Column Is Nothing Then AddHandler EditSo_Po.EditColumn.Leave, AddressOf L_So_Po
        If Not EditSo_Ro.Column Is Nothing Then AddHandler EditSo_Ro.EditColumn.Leave, AddressOf L_So_Ro
        If Not EditSo_VT.Column Is Nothing Then AddHandler EditSo_VT.EditColumn.Leave, AddressOf L_So_VT
        AddHandler DetailGRV.RowCellStyle, AddressOf DetailGRV_RowCellStyle
    End Sub
    Private Sub V_AddHandler_DetailKhac()


        EditKhacMa_Vitri.V_ActiLookUpColumn(AddressOf V_khac_Ma_Vitri, AddressOf L_khac_Ma_Vitri)
        EditKhacMa_Vv_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_Vv_i, AddressOf L_khac_Ma_Vv_i)
        EditKhacMa_Phi_i.V_ActiLookUpColumn(AddressOf V_khac_Ma_Phi_i, AddressOf L_khac_Ma_Phi_i)
        EditKhacMa_HD_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_HD_i, AddressOf L_khac_Ma_HD_i)
        EditKhacMa_SP_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_SP_i, AddressOf L_khac_Ma_SP_i)
        EditKhacMa_Ku_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_Ku_i, AddressOf L_khac_Ma_Ku_i)
        EditKhacMa_TTLN_i.V_ActiLookUpColumn(AddressOf V_khac_Ma_TTLN_i, AddressOf L_khac_Ma_TTLN_i)
        EditKhacMa_TTCP_i.V_ActiLookUpColumn(AddressOf V_khac_Ma_TTCP_i, AddressOf L_khac_Ma_TTCP_i)
        EditKhacMa_BP_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_BP_i, AddressOf L_khac_Ma_BP_i)
        EditKhacMa_HS_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_HS_i, AddressOf L_khac_Ma_HS_i)
        EditKhacMa_CD_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_CD_i, AddressOf L_khac_Ma_CD_i)
        EditKhacMa_TD1_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_TD1_i, AddressOf L_khac_Ma_TD1_i)
        EditKhacMa_TD2_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_TD2_i, AddressOf L_khac_Ma_TD2_i)
        EditKhacMa_TD3_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_TD3_i, AddressOf L_khac_Ma_TD3_i)
        EditKhacMa_TD4_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_TD4_i, AddressOf L_khac_Ma_TD4_i)
        EditKhacMa_TD5_I.V_ActiLookUpColumn(AddressOf V_khac_Ma_TD5_i, AddressOf L_khac_Ma_TD5_i)

        If Not EditKhacSo_So.Column Is Nothing Then AddHandler EditKhacSo_So.EditColumn.Leave, AddressOf L_khac_So_So
        If Not EditKhacSo_Po.Column Is Nothing Then AddHandler EditKhacSo_Po.EditColumn.Leave, AddressOf L_khac_So_Po
        If Not EditKhacSo_Ro.Column Is Nothing Then AddHandler EditKhacSo_Ro.EditColumn.Leave, AddressOf L_khac_So_Ro
        If Not EditKhacSo_VT.Column Is Nothing Then AddHandler EditKhacSo_VT.EditColumn.Leave, AddressOf L_khac_So_VT

        AddHandler DetailGRV.RowCellStyle, AddressOf DetailGRV_RowCellStyle
        AddHandler DetailKhacGRV.RowCellStyle, AddressOf DetailKhacGRV_RowCellStyle
    End Sub
    Dim CyberColor As New Cyber.Color.Sys
    Private Sub DetailGRV_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        CyberSupport.DetailGRV_RowCellStyle2(sender, e, DetailGRV, Dt_DetailTmp, Me.Font, "Bold", "BackColor", "BackColor2", "Forecolor", "Underline", "Italic", CyberColor)
    End Sub
    Private Sub DetailKhacGRV_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        CyberSupport.DetailGRV_RowCellStyle2(sender, e, DetailKhacGRV, Dt_DetailtmpKhac, Me.Font, "Bold", "BackColor", "BackColor2", "Forecolor", "Underline", "Italic", CyberColor)
    End Sub
    Private Sub VisibleColumnMa_NT()
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.Trim.ToUpper = osysvar("M_Ma_NT0").ToString.Trim.ToUpper Then
            EditTien2.Visible = False
            EditGia2.Visible = False
            EditCK.Visible = False

            TxtT_Tien.Visible = False
            TxtT_Tien2.Visible = False
            TxtT_Thue.Visible = False
            TxtT_CK.Visible = False
            TxtT_TT.Visible = False
        Else
            EditTien2.Visible = True
            EditGia2.Visible = True
            EditCK.Visible = True


            TxtT_Tien.Visible = True
            TxtT_Tien2.Visible = True
            TxtT_Thue.Visible = True
            TxtT_CK.Visible = True
            TxtT_TT.Visible = True
        End If
    End Sub ' MINHDC
    Private Sub VisibleColumnMa_GD()

    End Sub
    Protected Overrides Sub V_Databing()
        Dim i As Integer
        Dim Drv As DataRowView
        Drv = Nothing

        For i = 0 To Dv_Master.Count - 1
            If Dv_Master.Item(i).Item("Stt_Rec").ToString.Trim = M_Stt_Rec.Trim Then
                Drv = Dv_Master.Item(i)
                Exit For
            End If
        Next

        CyberSmodb.SetValueTObj(Me, Drv)
        If Drv Is Nothing Then
            TxtMa_NT.Text = M_Ma_Nt
            TxtNgay_Ct.Value = Now.Date
            Dim _DT As Date = TxtNgay_Ct.Value
            TxtTy_Gia.Double = CyberSupport.GetRate(_DT, TxtMa_NT.Text, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
            CbbMa_GD.SelectedValue = M_Ma_GD
            CbbMa_Post.SelectedValue = M_Ma_Post
        End If
        Dt_DetailTmp.Clear()
        Dt_DetailTmp.AcceptChanges()

        For i = 0 To Dt_Detail.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'").Length - 1
            Dt_DetailTmp.ImportRow(Dt_Detail.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(i))
        Next
        Dt_DetailtmpKhac.Clear()
        Dt_DetailtmpKhac.AcceptChanges()
        For i = 0 To Dt_DetailKhac.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'").Length - 1
            Dt_DetailtmpKhac.ImportRow(Dt_DetailKhac.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(i))
        Next
        If TxtMa_NT.Text.Trim = "" Then TxtMa_NT.Text = osysvar("M_Ma_NT0").ToString.Trim.ToUpper
        UpdateList()
        VisibleColumnMa_NT()
        VisibleColumnMa_GD()
        CyberSupport.V_SetSD(StatusFooter1, AppConn, "KT", M_Mode, txtMa_NX.Text, TxtMa_Kh.Text, "", "", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Setstatus()
        If (M_Mode = "M" Or M_Mode = "S") Then
            DetailGRV.OptionsBehavior.ReadOnly = False
            If DrDmct.Item("M_Ngay_LCT").ToString.Trim = "1" Then TxtNgay_LCt.ReadOnly = False Else TxtNgay_LCt.ReadOnly = True 'Ngay chu tu nhap: vao hoac tu dong lay theo may chu
            If DrDmct.Item("M_Ngay_CT").ToString.Trim = "1" Then TxtNgay_Ct.ReadOnly = True Else TxtNgay_Ct.ReadOnly = False 'Ngay chu tu nhap: vao hoac tu dong lay theo may chu
            If DrDmct.Item("M_Au_So_CT").ToString.Trim = "1" Then TxtSo_ct.ReadOnly = True Else TxtSo_ct.ReadOnly = False 'Tu dong danh so chung tu
        Else
            DetailGRV.OptionsBehavior.ReadOnly = True
        End If
        If M_Mode = "S" Then CbbMa_GD.Enabled = False
        If M_Mode = "M" Then CbbMa_GD.Enabled = True
        CyberFill.SetFoCusGRV(DetailGRV, M_Mode)
        SetTxt()
    End Sub
    Private Sub V_GetDateVoucher(ByVal _Mode As String, ByRef _Ngay_Ct As Date, ByRef _Ngay_LCT As Date)
        Dim _DtReturn As DataTable = CyberSupport.V_GetDateVoucher(_Mode, _Ngay_Ct, _Ngay_LCT, M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        If _DtReturn Is Nothing Then Exit Sub Else If _DtReturn.Rows.Count <= 0 Then Exit Sub
        If Not _DtReturn.Columns.Contains("Status") Then Exit Sub
        If _DtReturn.Rows(0).Item("Status").ToString.Trim = "N" Then Exit Sub
        If Not DrDmct.Item("M_Ngay_LCt").ToString.Trim = "1" Then TxtNgay_LCt.Value = _DtReturn.Rows(0).Item("Ngay_HT")
        If DrDmct.Item("M_Ngay_Ct").ToString.Trim = "1" Then TxtNgay_Ct.Value = _DtReturn.Rows(0).Item("Ngay_HT")
        _Ngay_Ct = TxtNgay_Ct.Value
        _Ngay_LCT = TxtNgay_Ct.Value
    End Sub
    Private Sub V_GetNoVoucherAuto()
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" And TxtSo_ct.Text.Trim <> "" Then Exit Sub
        If Not TxtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        TxtSo_ct.Text = CyberSupport.V_GetNoVoucherAuto(M_Mode, TxtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
#End Region
#Region "Valid - Master"
#Region "Valid --- DMQuyen"
    Private Sub L_Ma_Quyen(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_Quyen.Text = "" Then Exit Sub
        DrReturn = Nothing
        CyberSmlistSys.Lookup(M_LAN, M_Para, osysvar, AppConn, M_DsLookUp, TxtMa_Quyen.Text, "ma_Quyen", "DmQuyen", DrReturn, "1=1", "1=1", "1")
        If DrReturn Is Nothing Then TxtMa_Quyen.Text = "" Else TxtMa_Quyen.Text = DrReturn.Item("ma_Quyen")
    End Sub
#End Region
#Region "Valid --- Ma_KH"
    Private Sub V_Ma_KH(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        TxtMa_Kh.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Ma_kh", "DmKh", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_KH(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_Kh.Text = "" Then
            TxtTen_kh.Text = ""
            Exit Sub
        End If
        DrReturn = TxtMa_Kh.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_Kh.Text = DrReturn.Item("Ma_KH")
            TxtTen_kh.Text = DrReturn.Item("Ten_KH")
            TxtDia_Chi.Text = DrReturn.Item("Dia_Chi")

            txtOng_ba.Text = DrReturn.Item("Ong_Ba")
            txtOng_ba.Text = DrReturn.Item("Doi_Tac")
            TxtHan_TT.Double = DrReturn.Item("han_TT")

            TxtMa_So_Thue.Text = DrReturn.Item("Ma_So_Thue")
            TxtTen_KhVAT.Text = DrReturn.Item("ten_KhVAT")
            TxtDia_ChiVAT.Text = DrReturn.Item("Dia_ChiVAT")
            If TxtTen_KhVAT.Text.Trim = "" Then TxtTen_KhVAT.Text = TxtTen_kh.Text
            If TxtDia_ChiVAT.Text.Trim = "" Then TxtDia_ChiVAT.Text = TxtDia_Chi.Text

            TxtEmailHDDT.Text = DrReturn.Item("E_Mail").ToString.Trim

            '-----------------------------------------------------------------------------------------------------------
            If TxtMa_Bp_H.Text.Trim = "" Then
                If DrReturn.Table.Columns.Contains("Ma_BP") Then TxtMa_Bp_H.Text = DrReturn.Item("Ma_BP")
                If TxtMa_Bp_H.Text.Trim <> "" Then txtTen_BP_H.Text = CyberSmodb.SQLGetvalue(AppConn, "Ten_BP", "DmBP", "(Ma_BP = N'" + TxtMa_Bp_H.Text.Trim + "')", CyberSmlib)

            End If
            '-----------------------------------------------------------------------------------------------------------
            If txtMa_HS_H.Text.Trim = "" Then
                If DrReturn.Table.Columns.Contains("Ma_HS") Then txtMa_HS_H.Text = DrReturn.Item("Ma_HS")
                If txtMa_HS_H.Text.Trim <> "" Then txtTen_HS_H.Text = CyberSmodb.SQLGetvalue(AppConn, "Ten_HS", "DmHS", "(Ma_HS = N'" + txtMa_HS_H.Text.Trim + "')", CyberSmlib)
            End If
            '-----------------------------------------------------------------------------------------------------------
            If txtMa_NX.Text.Trim = "" Then
                If DrReturn.Table.Columns.Contains("TK") Then txtMa_NX.Text = DrReturn.Item("TK")
                If txtMa_NX.Text.Trim <> "" Then txtTen_NX.Text = CyberSmodb.SQLGetvalue(AppConn, "Ten_TK", "DmTK", "(TK = N'" + txtMa_NX.Text.Trim + "')", CyberSmlib)
                If txtTen_NX.Text.Trim = "" Then txtMa_NX.Text = ""
            End If
        Else
            TxtMa_Kh.Text = ""
            TxtTen_kh.Text = ""
        End If

        If TxtMa_Kh.Text = "" Then
            TxtTen_kh.Text = ""
            TxtDia_Chi.Text = ""
            Exit Sub
        End If
        V_GetTk_Thue_No()
        CyberSupport.V_SetSD(StatusFooter1, AppConn, "KT", M_Mode, txtMa_NX.Text, TxtMa_Kh.Text, "", "", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_Ten_KhVAT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtTen_KhVAT.Text.Trim = "" Then TxtTen_KhVAT.Text = TxtTen_kh.Text
        If TxtDia_ChiVAT.Text.Trim = "" Then TxtDia_ChiVAT.Text = TxtDia_Chi.Text
    End Sub
    Private Sub L_Dia_Chi(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        TxtDia_Chi.Text = CyberInput.GetDia_Chi(TxtMa_Kh.Text, TxtDia_Chi.Text, M_Ma_CT, M_Mode, AppConn, CyberSmlib, CyberSmodb)
    End Sub
#End Region
#Region "Valid --- Ma_NX"
    Private Sub V_Ma_NX(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        txtMa_NX.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Tk", "DmTK", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_NX(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If txtMa_NX.Text = "" Then
            txtTen_NX.Text = ""
            V_GetTk_Thue_No()
            Exit Sub
        End If
        DrReturn = txtMa_NX.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            txtMa_NX.Text = DrReturn.Item("Tk")
            txtTen_NX.Text = DrReturn.Item("Ten_TK")
        End If
        If txtMa_NX.Text = "" Then
            txtTen_NX.Text = ""
            V_GetTk_Thue_No()
            Exit Sub
        End If
        V_GetTk_Thue_No()
        CyberSupport.V_SetSD(StatusFooter1, AppConn, "KT", M_Mode, txtMa_NX.Text, TxtMa_Kh.Text, "", "", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
#End Region
#Region "Valid --- Ma_BP_H"
    Private Sub V_Ma_BP_H(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        TxtMa_Bp_H.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Ma_BP", "DmBP", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_BP_H(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_Bp_H.Text = "" Then
            txtTen_BP_H.Text = ""
            Exit Sub
        End If
        DrReturn = TxtMa_Bp_H.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_Bp_H.Text = DrReturn.Item("Ma_BP")
            txtTen_BP_H.Text = DrReturn.Item("Ten_BP")
        Else
            TxtMa_Bp_H.Text = ""
            txtTen_BP_H.Text = ""
        End If
    End Sub
#End Region
#Region "Valid --- Ma_HS_H"
    Private Sub V_Ma_HS_H(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        txtMa_HS_H.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Ma_HS", "DmHS", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_HS_H(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If txtMa_HS_H.Text = "" Then
            txtTen_HS_H.Text = ""
            Exit Sub
        End If
        DrReturn = txtMa_HS_H.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            txtMa_HS_H.Text = DrReturn.Item("Ma_HS")
            txtTen_HS_H.Text = DrReturn.Item("Ten_HS")
        Else
            txtMa_HS_H.Text = ""
            txtTen_HS_H.Text = ""
        End If
    End Sub
#End Region
    '#Region "Valid --- Thue"
    '    Private Sub L_Ma_THue(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
    '        If TxtMa_Thue.Text = "" Then
    '            TxtThue_Suat.Double = 0
    '            UpdateList()
    '            Exit Sub
    '        End If
    '        DrReturn = Nothing
    '        CyberSmlistSys.Lookup(M_LAN, M_Para, osysvar, AppConn, M_DsLookUp, TxtMa_Thue.Text, "ma_Thue", "Dmthue", DrReturn, "1=1", "1=1", "1")
    '        If DrReturn Is Nothing Then
    '            TxtThue_Suat.Double = 0
    '            UpdateList()
    '            Exit Sub
    '        Else
    '            TxtThue_Suat.Double = DrReturn.Item("thue_Suat")
    '            TxtMa_Thue.Text = DrReturn.Item("ma_Thue")
    '            If ChkSua_TkThue.Checked Then
    '                If TxtTk_Thue_Co.Text.Trim = "" Then TxtTk_Thue_Co.Text = DrReturn.Item("Tk_Thue_Co")
    '            Else
    '                TxtTk_Thue_Co.Text = DrReturn.Item("Tk_Thue_Co")
    '            End If
    '            UpdateList()
    '            Exit Sub
    '        End If
    '    End Sub
    '#End Region
#Region "Valid --- Tk_Thue_no"
    Private Sub V_Tk_Thue_no(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtTk_Thue_No.ReadOnly Then Exit Sub
        TxtTk_Thue_No.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Tk", "DmTK", "1=1", "1=1")
    End Sub
    Private Sub L_Tk_Thue_No(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not ChkSua_TkThue.Checked Then
            V_GetTk_Thue_No()
            Exit Sub
        End If

        If TxtTk_Thue_No.Text = "" Then Exit Sub
        DrReturn = TxtTk_Thue_No.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then TxtTk_Thue_No.Text = DrReturn.Item("Tk")
    End Sub
#End Region
#Region "Valid --- Tk_Thue_Co"
    Private Sub V_Tk_Thue_Co(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtTk_Thue_Co.ReadOnly Then Exit Sub
        TxtTk_Thue_Co.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Tk", "DmTK", "1=1", "1=1")
    End Sub
    Private Sub L_Tk_Thue_Co(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not ChkSua_TkThue.Checked Then
            V_GetTk_Thue_Co()
            Exit Sub
        End If
        DrReturn = TxtTk_Thue_Co.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then TxtTk_Thue_Co.Text = DrReturn.Item("Tk")
    End Sub
#End Region
#Region "Phieu xuat gia dich danh Sua/HT thue/Tien thue/Chiet khau"
    Private Sub V_GetTk_Thue_No()
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not ChkSua_TkThue.Checked Or TxtTk_Thue_No.Text.Trim = "" Then TxtTk_Thue_No.Text = txtMa_NX.Text
    End Sub
    Private Sub V_GetTk_Thue_Co()
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not ChkSua_TkThue.Checked Or TxtTk_Thue_Co.Text.Trim = "" Then
            DrReturn = CyberSmodb.SQLGetRow(AppConn, "DmThue", "Ma_THue = N'" + TxtMa_Thue.Text.Trim + "'", CyberSmlib)
            If DrReturn Is Nothing Then Exit Sub
            TxtTk_Thue_Co.Text = DrReturn.Item("Tk_Thue_Co")
            TxtThue_Suat.Double = DrReturn.Item("Thue_Suat")
            UpdateList()
        End If
    End Sub
    Private Sub V_Sua_TkThue(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not ChkSua_TkThue.Checked Then
            TxtTk_Thue_Co.ReadOnly = True
            TxtTk_Thue_No.ReadOnly = True
            V_GetTk_Thue_No()
            V_GetTk_Thue_Co()
            Exit Sub
        End If
        TxtTk_Thue_No.ReadOnly = False
        TxtTk_Thue_Co.ReadOnly = False
        TxtTk_Thue_Co.Focus()
    End Sub
    Private Sub V_Sua_Thue(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not ChkSua_Thue.Checked Then
            TxtT_thue_NT.ReadOnly = True
        Else
            TxtT_thue_NT.ReadOnly = False
            TxtT_thue_NT.Focus()
        End If
        UpdateList()
    End Sub
    Private Sub V_Sua_Thue_CK(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        UpdateList()
    End Sub
    Private Sub V_Sua_Ck(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not ChkSua_CK.Checked Then
            TxtT_CK_Nt.ReadOnly = True
            For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
                V_Tinh_Toan(iRow)
            Next
            UpdateList()

        Else
            TxtT_CK_Nt.ReadOnly = False
            UpdateList()
            TxtT_CK_Nt.Focus()
        End If
    End Sub
    Private Sub L_T_CK_NT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not ChkSua_CK.Checked Then
            TxtT_CK_Nt.ReadOnly = True
        Else
            TxtT_CK_Nt.ReadOnly = False
            V_Phan_Bo_Tien()
        End If
        UpdateList()
    End Sub
    Private Sub E_T_CK_NT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode.Trim = "M" Or M_Mode.Trim = "S") Then Exit Sub
        If Not Me.ChkSua_CK.Checked Then SendKeys.Send("{Tab}")
    End Sub
    Private Sub L_T_Thue_NT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        UpdateList()
    End Sub
    Private Sub E_T_Thue_NT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode.Trim = "M" Or M_Mode.Trim = "S") Then Exit Sub
        If Not Me.ChkSua_Thue.Checked Then SendKeys.Send("{Tab}")
    End Sub
#End Region
#Region "Lenh/SO/Po/Ro/Vt"
    Private Sub L_Lenh_So(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        TxtLenh_SO.Text = CyberVoucher.V_FormatSo_So(AppConn, osysvar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Dt, TxtLenh_SO.Text, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_Lenh_Po(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        TxtLenh_PO.Text = CyberVoucher.V_FormatSo_PO(AppConn, osysvar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Dt, TxtLenh_PO.Text, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_Lenh_Ro(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        'TxtLenh_RO.Text = CyberVoucher.V_FormatSo_Ro(AppConn, osysvar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Dt, TxtLenh_RO.Text, CbbMa_TTCP_H, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib)
        TxtLenh_RO.Text = CyberVoucher.V_FormatSo_Ro(AppConn, osysvar, M_Ma_CT, "S", M_Mode, _Dt, TxtLenh_RO.Text, CbbMa_TTCP_H, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib)
        V_SetRO()
    End Sub
    Private Sub L_Lenh_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        TxtLenh_Vt.Text = CyberVoucher.V_FormatSo_VT(AppConn, osysvar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Dt, TxtLenh_Vt.Text, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_BG(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        TxtSo_BG.Text = CyberVoucher.V_GetSo_BG(M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Dt, TxtSo_BG.Text, M_Ma_Dvcs)
    End Sub
#End Region
#Region "Lấy thông tin hóa đơn thay thế, điều chỉnh"
    Sub V_Ma_CTTT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then
            Exit Sub
        End If
        With Me
            Dim _Ds As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_GLGetTTHDTTDC", TxtSo_Seri_tt.Text + "#" + TxtSo_ct_tt.Text + "#" + M_Ma_Dvcs + "#" + M_User_Name)

            Dim DtrReturn As DataTable = _Ds.Tables(0)
            If DtrReturn.Rows.Count > 0 Then
                TxtStt_Rec_TT.Text = DtrReturn.Rows(0)("Stt_rec")
            Else
                If TxtSo_Ct_TT.Text = "" And TxtSo_Seri_TT.Text = "" Then
                    TxtStt_Rec_TT.Text = ""
                End If

            End If
        End With
    End Sub
#End Region
#End Region
#Region "Valid - Detail"
#Region "Valid - Detail - Core"
    Private Sub V_Tinh_Thue_CK()
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim nTy_Gia As Decimal = V_GetTyGia()
        Dim nT_Tien_NT2 As Decimal = TxtT_Tien_NT2.Double
        Dim nT_Tien2 As Decimal = TxtT_Tien2.Double
        Dim nT_Thue_Nt As Decimal = TxtT_thue_NT.Double
        Dim nT_Thue As Decimal = TxtT_Thue.Double
        Dim nT_Ck_Nt As Decimal = 0
        Dim nT_Ck As Decimal = 0
        If Not ChkSua_CK.Checked Then
            For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
                nT_Ck_Nt = nT_Ck_Nt + Dv_DetailTmp.Item(iRow).Item("CK_NT")
                nT_Ck = nT_Ck + Dv_DetailTmp.Item(iRow).Item("CK_NT")
            Next
            TxtT_CK_Nt.Double = nT_Ck_Nt
            TxtT_CK.Double = nT_Ck
        End If

        nT_Ck_Nt = TxtT_CK_Nt.Double
        nT_Ck = TxtT_CK.Double

        If Not ChkSua_Thue.Checked Then
            Dim nThue_Suat As Decimal = TxtThue_Suat.Double
            Dim nT_Tien_Hang_NT As Decimal = TxtT_Tien_NT2.Double
            If ChkSua_Thue_CK.Checked Then nT_Tien_Hang_NT = nT_Tien_Hang_NT - nT_Ck_Nt
            nT_Thue_Nt = CyberSupport.V_Round(nT_Tien_Hang_NT * nThue_Suat / 100, M_R_TIEN_NT)
            TxtT_thue_NT.Double = nT_Thue_Nt
            TxtT_thue_NT.Refresh()
        End If

        nT_Thue_Nt = TxtT_thue_NT.Double
        nT_Ck_Nt = TxtT_CK_Nt.Double

        If nTy_Gia <> 1 Then
            nT_Thue = CyberSupport.V_Round(nT_Thue_Nt * nTy_Gia, M_R_TIEN)
            nT_Ck = CyberSupport.V_Round(nT_Ck_Nt * nTy_Gia, M_R_TIEN)
        Else
            nT_Thue = nT_Thue_Nt
            nT_Ck = nT_Ck_Nt
        End If
        TxtT_Thue.Double = nT_Thue
        TxtT_CK.Double = nT_Ck
    End Sub
    Private Sub UpdateList()
        Dim nT_Tien_NT2 As Decimal = 0
        Dim nT_Tien2 As Decimal = 0

        Dim nT_TT_NT As Decimal = 0
        Dim nT_TT As Decimal = 0

        Dim nT_So_Luong As Decimal = 0

        Dim nT_Thue_NT As Decimal = 0
        Dim nT_Thue As Decimal = 0

        For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
            nT_Tien_NT2 = nT_Tien_NT2 + Dv_DetailTmp.Item(iRow).Item("Tien_NT2")
            nT_Tien2 = nT_Tien2 + Dv_DetailTmp.Item(iRow).Item("Tien2")
            nT_So_Luong = nT_So_Luong + Dv_DetailTmp.Item(iRow).Item("So_Luong")
            nT_Thue_NT = nT_Thue_NT + Dv_DetailTmp.Item(iRow).Item("Thue")
            nT_Thue = nT_Thue + Dv_DetailTmp.Item(iRow).Item("Thue")
        Next
        TxtT_SO_LUONG.Double = nT_So_Luong
        TxtT_Tien_NT2.Double = nT_Tien_NT2
        TxtT_Tien2.Double = nT_Tien2
        '----------------------------------------------------------------------
        V_Tinh_Thue_CK()
        '----------------------------------------------------------------------
        TxtT_Thue.Double = nT_Thue
        TxtT_thue_NT.Double = nT_Thue_NT

        Dim nT_CK_NT As Decimal = TxtT_CK_Nt.Double
        Dim nT_CK As Decimal = TxtT_CK.Double

        nT_TT_NT = nT_Tien_NT2 + nT_Thue_NT - nT_CK_NT
        nT_TT = nT_Tien2 + nT_Thue - nT_CK
        TxtT_TT_NT.Double = nT_TT_NT
        TxtT_TT.Double = nT_TT
    End Sub
    Private Sub V_Tinh_Toan(ByVal iRow As Integer)
        Dim nTy_Gia As Decimal = V_GetTyGia()
        '--------------------------------------------------------------------------------
        If Dv_DetailTmp.Item(iRow).Item("So_Luong") * Dv_DetailTmp.Item(iRow).Item("Gia_NT2") <> 0 Then
            Dv_DetailTmp.Item(iRow).BeginEdit()
            Dv_DetailTmp.Item(iRow).Item("Tien_NT2") = CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("So_Luong") * Dv_DetailTmp.Item(iRow).Item("Gia_NT2"), M_R_TIEN_NT)
            Dv_DetailTmp.Item(iRow).EndEdit()
        End If
        '--------------------------------------------------------------------------------
        '--- Phan chiet khai
        If Not ChkSua_CK.Checked Then
            If Dv_DetailTmp.Item(iRow).Item("Tien_NT2") * Dv_DetailTmp.Item(iRow).Item("PT_CK") <> 0 Then
                Dv_DetailTmp.Item(iRow).BeginEdit()
                Dv_DetailTmp.Item(iRow).Item("CK_NT") = CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("Tien_NT2") * Dv_DetailTmp.Item(iRow).Item("PT_CK") / 100, M_R_TIEN_NT)
                Dv_DetailTmp.Item(iRow).EndEdit()
            End If
        End If
        '--------------------------------------------------------------------------------
        '----------------VND
        Dv_DetailTmp.Item(iRow).BeginEdit()
        If nTy_Gia = 1 Then
            Dv_DetailTmp.Item(iRow).Item("Tien2") = Dv_DetailTmp.Item(iRow).Item("Tien_NT2")
            Dv_DetailTmp.Item(iRow).Item("Gia2") = Dv_DetailTmp.Item(iRow).Item("Gia_NT2")
            If Not ChkSua_CK.Checked Then Dv_DetailTmp.Item(iRow).Item("CK") = Dv_DetailTmp.Item(iRow).Item("CK_NT")
        Else
            Dv_DetailTmp.Item(iRow).Item("Tien2") = CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("Tien_NT2") * nTy_Gia, M_R_TIEN)
            Dv_DetailTmp.Item(iRow).Item("Gia2") = CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("Gia_NT2") * nTy_Gia, M_R_GIA)
            If Not ChkSua_CK.Checked Then Dv_DetailTmp.Item(iRow).Item("CK") = CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("CK_NT") * nTy_Gia, M_R_TIEN)
        End If
        Dv_DetailTmp.Item(iRow).EndEdit()
        CyberSupport.V_UpdateGRV(DetailGRV)

        TinhThue_VT(iRow)
        UpdateList()
    End Sub

    Private Sub TinhThue_VT(ByVal iRow As Integer)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub

        Dv_DetailTmp.Item(iRow).BeginEdit()
        If Dt_DetailTmp.Columns.Contains("Sua_Thue") Then
            If Dv_DetailTmp.Item(iRow).Item("Sua_Thue").ToString.Trim <> "1" Then
                Dv_DetailTmp.Item(iRow).Item("Thue") = Math.Round((Dv_DetailTmp.Item(iRow).Item("TIEN_NT2") - Dv_DetailTmp.Item(iRow).Item("Ck") + Dv_DetailTmp.Item(iRow).Item("DC_I")) * Dv_DetailTmp.Item(iRow).Item("Thue_Suat") / 100, 0, MidpointRounding.AwayFromZero)
                'Else
                '    Dv_DetailTmp.Item(iRow).Item("Thue") = Math.Round((Dv_DetailTmp.Item(iRow).Item("Tien2") - Dv_DetailTmp.Item(iRow).Item("Ck") + Dv_DetailTmp.Item(iRow).Item("DC_I")) * Dv_DetailTmp.Item(iRow).Item("Thue_Suat") / 100, 0, MidpointRounding.AwayFromZero)
            End If
        Else
            Dv_DetailTmp.Item(iRow).Item("Thue") = Math.Round((Dv_DetailTmp.Item(iRow).Item("TIEN_NT2") - Dv_DetailTmp.Item(iRow).Item("Ck") + Dv_DetailTmp.Item(iRow).Item("DC_I")) * Dv_DetailTmp.Item(iRow).Item("Thue_Suat") / 100, 0, MidpointRounding.AwayFromZero)
        End If

        If Dt_DetailTmp.Columns.Contains("Tien0") Then Dv_DetailTmp.Item(iRow).Item("Tien0") = Dv_DetailTmp.Item(iRow).Item("TIEN_NT2") - Dv_DetailTmp.Item(iRow).Item("Ck") + Dv_DetailTmp.Item(iRow).Item("DC_I")
        Dv_DetailTmp.Item(iRow).EndEdit()

    End Sub

    Private Sub L_Tinh_Toan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DetailGRV.PostEditor()
        Dim drvCurren As DataRowView
        drvCurren = DetailGRV.GetFocusedRow
        CyberSupport.V_UpdateGRV(DetailGRV)
        V_Tinh_Toan(iRow)
    End Sub
    Private Sub E_Dien_Giaii(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M") Then Exit Sub
        'If Not (M_Mode = "M" Or M_Mode = "S") And (M_Is_Delete = "X") Then Exit Sub
        Dim iRow As Integer = DetailGRV.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Dv_DetailTmp.Item(iRow).Item("Dien_Giaii").ToString.Trim = "" Then
            Dv_DetailTmp.Item(iRow).BeginEdit()
            Dv_DetailTmp.Item(iRow).Item("Dien_Giaii") = txtDien_giai.Text
            Dv_DetailTmp.Item(iRow).EndEdit()
        End If
        DetailGRV.ShowEditor()

    End Sub
#End Region
#Region "Tai khoan "
    Private Sub V_Tk_DT(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Tk_Dt(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Tk_DT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DrReturn = CyberSupport.L_Tk_Dt(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        If DrReturn Is Nothing Then
            iRow = DetailGRV.GetFocusedDataSourceRowIndex
            If iRow < 0 Then Exit Sub
            If Dv_DetailTmp.Item(iRow).Item("Tk_DT").ToString.Trim = "" Then
                If Not CyberSupport.V_NhapTiep(osysvar, M_LAN) Then
                    Dv_DetailTmp.Item(iRow).Delete()
                    Dv_DetailTmp.Table.AcceptChanges()
                    UpdateList()
                    SendKeys.Send("^{TAB}")
                End If
            End If
            Exit Sub
        End If

    End Sub
    Private Sub V_Tk_CK(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Tk_CK(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Tk_CK(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Tk_CK(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
#End Region
#Region "So_So/So_PO/So_RO/So_VT"
    Private Sub L_So_So(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_So(Dv_DetailTmp, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_Po(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_PO(Dv_DetailTmp, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_Ro(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_Ro(Dv_DetailTmp, iRow, AppConn, osysvar, M_Ma_CT, "S", M_Mode, _Ngay_Ct, CbbMa_TTCP_H, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_VT(Dv_DetailTmp, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
#End Region
    Private Sub V_Ma_kh_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_kh_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_kh_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_kh_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
#Region "Valid - Detail - Add On"
    Private Sub V_Ma_Vv_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vv_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vv_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vv_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        ''--- Goi
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_Vv_I"), "Ma_Vv", "Ten_Vv", "DMVv", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_Phi_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Phi_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Phi_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Phi_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_Phi_I"), "Ma_Phi", "Ten_Phi", "DMPHI", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_HD_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_HD_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hd_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_HD_I"), "Ma_HD", "Ten_HD", "DMHD", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_SP_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Sp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_SP_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Sp_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_SP_I"), "Ma_SP", "Ten_SP", "DMSP", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_KU_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Ku_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_KU_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Ku_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_KU_I"), "Ma_KU", "Ten_KU", "DMKU", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_TTLN_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTLN_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTLN_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTLN_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_TTLN_I"), "Ma_TTLN", "Ten_TTLN", "DMTTLN", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_TTCP_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTCP_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTCP_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTCP_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_TTCP_I"), "Ma_TTCP", "Ten_TTCP", "DMTTCP", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_Bp_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Bp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Bp_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Bp_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_BP_I"), "Ma_BP", "Ten_BP", "DMBP", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_HS_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hs_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_HS_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hs_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_HS_I"), "Ma_HS", "Ten_HS", "DMHS", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_CD_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Cd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_CD_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Cd_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_CD_I"), "Ma_CD", "Ten_CD", "DMCD", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_TD1_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Td1_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD1_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Td1_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_TD1_I"), "Ma_TD1", "Ten_TD1", "DMTD1", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_TD2_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD2_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD2_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD2_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_TD2_I"), "Ma_TD2", "Ten_TD2", "DMTD2", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_TD3_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD3_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD3_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD3_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_TD3_I"), "Ma_TD3", "Ten_TD3", "DMTD3", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_TD4_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD4_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD4_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD4_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_TD4_I"), "Ma_TD4", "Ten_TD4", "DMTD4", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD5_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD5_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_TD5_I"), "Ma_TD5", "Ten_TD5", "DMTD5", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_Db_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Db_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Db_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Db_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_DB_I"), "Ma_DB", "Ten_DB", "DMDB", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_Xe_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Xe_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Xe_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Xe_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Kx_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Kx_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Kx_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Kx_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_KX_I"), "Ma_KX", "Ten_KX", "DMKX", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_Tuyen_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Tuyen_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Tuyen_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Tuyen_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_Tuyen_I"), "Ma_Tuyen", "Ten_Tuyen", "DMTuyen", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_Ts(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Ts(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Ts(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Ts(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_Ts_I"), "Ma_Ts", "Ten_Ts", "DMTs", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub V_Ma_Cc(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Cc(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Cc(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Cc(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        CyberSupport.V_GetNameList(StatusFooter1, AppConn, osysvar, M_Mode, Dv_DetailTmp.Item(iRow).Item("Ma_CC_I"), "Ma_Cc", "Ten_Cc", "DMCC", M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
#End Region
#End Region
#Region "Valid - Detail -Khac======================================="
#Region "Valid - Detail - Core"
    Private Sub Khac_UpdateList()
    End Sub
    Private Sub V_khac_Tinh_Toan(ByVal iRow As Integer)
        Dim nTy_Gia As Decimal = V_GetTyGia()
    End Sub

    Private Sub L_khac_Tinh_Toan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailKhacGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DetailKhacGRV.PostEditor()
        Dim drvCurren As DataRowView
        drvCurren = DetailKhacGRV.GetFocusedRow
        CyberSupport.V_UpdateGRV(DetailKhacGRV)
        V_khac_Tinh_Toan(iRow)
        UpdateList()
    End Sub
    Private Sub V_khac_Ma_kh_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_kh_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_kh_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_kh_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub E_khac_Dien_Giaii(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M") Then Exit Sub
        'If Not (M_Mode = "M" Or M_Mode = "S") And (M_Is_Delete = "X") Then Exit Sub
        Dim iRow As Integer = DetailKhacGRV.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Dv_DetailtmpKhac.Item(iRow).Item("Dien_Giaii").ToString.Trim = "" Then
            Dv_DetailtmpKhac.Item(iRow).BeginEdit()
            Dv_DetailtmpKhac.Item(iRow).Item("Dien_Giaii") = txtDien_giai.Text
            Dv_DetailtmpKhac.Item(iRow).EndEdit()
        End If
        DetailKhacGRV.ShowEditor()
    End Sub
#End Region
#Region "Vat tu kho/Vitri - "
    Private Sub V_khac_Ma_Lo(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Lo(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Lo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Lo(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
        Dim iRow As Integer = -1
        iRow = DetailKhacGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
    End Sub

    Private Sub V_khac_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vitri(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vitri(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
        Dim iRow As Integer = -1
        iRow = DetailKhacGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
    End Sub
#End Region

#Region "Valid - Detail - Add On"
    Private Sub V_khac_Ma_Vv_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vv_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Vv_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vv_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_Phi_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Phi_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Phi_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Phi_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_HD_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_HD_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hd_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_SP_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Sp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_SP_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Sp_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_Ku_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Ku_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Ku_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Ku_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_TTLN_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTLN_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_TTLN_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTLN_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_TTCP_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTCP_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_TTCP_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTCP_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_BP_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Bp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_BP_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Bp_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_HS_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hs_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_HS_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hs_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_CD_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Cd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_CD_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Cd_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_TD1_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Td1_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_TD1_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Td1_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_TD2_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD2_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_TD2_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD2_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_TD3_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD3_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_TD3_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD3_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_TD4_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD4_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_TD4_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD4_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD5_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD5_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_Db_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Db_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Db_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Db_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_Xe_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Xe_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Xe_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Xe_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_Kx_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Kx_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Kx_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Kx_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_Tuyen_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Tuyen_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Tuyen_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Tuyen_i(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_Ts(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Ts(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Ts(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Ts(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
    Private Sub V_khac_Ma_Cc(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Cc(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_khac_Ma_Cc(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Cc(M_Mode, M_Ma_CT, sender, DetailKhacGRV)
    End Sub
#End Region
#Region "So_So/So_PO/So_RO/So_VT"
    Private Sub L_khac_So_So(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailKhacGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value

        CyberVoucher.V_FormatSo_So(Dv_DetailtmpKhac, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_khac_So_Po(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailKhacGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_PO(Dv_DetailtmpKhac, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)

    End Sub
    Private Sub L_khac_So_Ro(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailKhacGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_Ro(Dv_DetailtmpKhac, iRow, AppConn, osysvar, M_Ma_CT, "S", M_Mode, _Ngay_Ct, CbbMa_TTCP_H, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib)

    End Sub
    Private Sub L_khac_So_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailKhacGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value

        CyberVoucher.V_FormatSo_VT(Dv_DetailtmpKhac, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
#End Region

#End Region
#Region "Ngay ct, ngay lap chung tu,so chung tu"
    Private Sub V_Ngay_Ct(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" Then Exit Sub

        If Not TxtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        TxtSo_ct.Text = CyberSupport.V_GetNoVoucher(M_Mode, TxtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
    Private Sub V_Ngay_LCt(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" Then Exit Sub
        If Not TxtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        TxtSo_ct.Text = CyberSupport.V_GetNoVoucher(M_Mode, TxtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
    Private Sub V_So_Ct(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" Then Exit Sub
        If Not TxtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        TxtSo_ct.Text = CyberSupport.V_GetNoVoucher(M_Mode, TxtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
#End Region
#Region "Ty gia -  Ngoai te"
    Private Sub L_Ma_NT(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        DrReturn = Nothing
        CyberSmlistSys.Lookup(M_LAN, M_Para, osysvar, AppConn, DsLookup, TxtMa_NT.Text, "Ma_NT", "DmNT", DrReturn, "1=1", "1=1", "1")
        If Not DrReturn Is Nothing Then TxtMa_NT.Text = DrReturn.Item("Ma_NT") Else TxtMa_NT.Text = ""
        Dim Dt As Date = TxtNgay_Ct.Value
        TxtTy_Gia.Double = CyberSupport.GetRate(Dt, TxtMa_NT.Text, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        GetRound()
        For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
            V_Tinh_Toan(iRow)
        Next
        Dv_DetailTmp.Table.AcceptChanges()
        VisibleColumnMa_NT()
    End Sub
    Private Sub L_Ty_Gia(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.Trim.ToUpper = osysvar("M_MA_NT0").ToString.Trim Then TxtTy_Gia.Double = 1
        For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
            V_Tinh_Toan(iRow)
        Next
        Dv_DetailTmp.Table.AcceptChanges()
        CyberSupport.V_UpdateGRV(DetailGRV)
        DetailGRV.RefreshData()
    End Sub
    Private Function V_GetTyGia() As Decimal
        Dim nTy_Gia As Decimal = TxtTy_Gia.Double
        If nTy_Gia = 0 Then nTy_Gia = 1
        If TxtMa_NT.Text.Trim = "" Then TxtMa_NT.Text = osysvar("M_MA_NT0")
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.Trim.ToUpper = osysvar("M_MA_NT0").ToString.ToUpper.Trim Then TxtTy_Gia.Double = 1
        TxtTy_Gia.Double = nTy_Gia
        V_GetTyGia = nTy_Gia
    End Function
#End Region
#Region "Mainform"
    Private Sub V_MainSystem()
        Dim mnItemsMail = New ContextMenu

        Dim mnItemsF4 As New MenuItem(If(M_LAN = "V", "Thêm dòng", "New row"), AddressOf V_ShortAddItem, Keys.F4)
        Dim mnItemsF8 As New MenuItem(If(M_LAN = "V", "Xóa dòng", "Delete row"), AddressOf V_ShortDeleteItem, Keys.F8)

        Dim mnItemsSave As New MenuItem(If(M_LAN = "V", "Lưu chứng từ", "Save"), AddressOf V_ShortSAVE, Keys.Control + Keys.Enter)
        Dim mnItemsPrint As New MenuItem(If(M_LAN = "V", "In chứng từ", "Print"), AddressOf V_ShortPrint, Keys.Control + Keys.P)

        mnItemsMail.MenuItems.Add(mnItemsF4)
        mnItemsMail.MenuItems.Add(mnItemsF8)

        mnItemsMail.MenuItems.Add(mnItemsSave)
        mnItemsMail.MenuItems.Add(mnItemsPrint)
        Me.ContextMenu = mnItemsMail
    End Sub
    Private Sub V_ShortAddItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRV.FocusedRowHandle
        V_AddItem(iRow)
    End Sub
    Private Sub V_ShortDeleteItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRV.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Not CyberSupport.V_DeleteItemVoucher(osysvar, M_LAN, M_Ma_CT, iRow, Dv_DetailTmp, AppConn, DetailGRV) Then Exit Sub
        Dv_DetailTmp.Delete(iRow)
        Dv_DetailTmp.Table.AcceptChanges()
        UpdateList()
    End Sub
    Private Sub V_MainSystemKHAC()
        Dim mnItemsMail = New ContextMenu
        Dim mnItemsF4 As New MenuItem(If(M_LAN = "V", "Thêm dòng", "New row"), AddressOf V_ShortAddItemKHAC, Keys.F4)
        Dim mnItemsF8 As New MenuItem(If(M_LAN = "V", "Xóa dòng", "Delete row"), AddressOf V_ShortDeleteItemKHAC, Keys.F8)
        mnItemsMail.MenuItems.Add(mnItemsF4)
        mnItemsMail.MenuItems.Add(mnItemsF8)
        DetailKhacGRV.GridControl.ContextMenu = mnItemsMail
    End Sub
    Private Sub V_Khac_ShortAddItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailKhacGRV.FocusedRowHandle
        V_AddItemKHAC(iRow)
    End Sub
    Private Sub V_Khac_ShortDeleteItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailKhacGRV.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Not CyberSupport.V_DeleteItemVoucher(osysvar, M_LAN, M_Ma_CT, iRow, Dv_DetailtmpKhac, AppConn, DetailKhacGRV) Then Exit Sub
        Dv_DetailtmpKhac.Delete(iRow)
        Dv_DetailtmpKhac.Table.AcceptChanges()
    End Sub
    Private Sub MasterKhacGRV_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim rowHandle As Integer = e.HitInfo.RowHandle
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            PopupMenuMasterGrid.ItemLinks.Clear()
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Thêm dòng", "Add item"), AddressOf V_Khac_ShortAddItem, Nothing, True, False))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Xóa dòng", "Delete item"), AddressOf V_Khac_ShortDeleteItem, Nothing, True, False))

            PopupMenuMasterGrid.ShowPopup(Control.MousePosition)
        End If
    End Sub
    Private Sub V_ShortAddItemKHAC(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailKhacGRV.FocusedRowHandle
        V_AddItemKHAC(iRow)
        iRow = Dv_DetailtmpKhac.Count - 1
        CyberFill.V_ForcusCell(Dv_DetailtmpKhac, iRow, 0)
    End Sub
    Private Sub V_ShortDeleteItemKHAC(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailKhacGRV.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Not CyberSupport.V_DeleteItemVoucher(osysvar, M_LAN, M_Ma_CT, iRow, Dv_DetailtmpKhac, AppConn) Then Exit Sub
        Dv_DetailtmpKhac.Delete(iRow)
        Dv_DetailtmpKhac.Table.AcceptChanges()
        UpdateList()
    End Sub
    Private Sub V_ShortSAVE(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Me.CmdSave.Enabled Then CmdSave.Focus()
        If Me.CmdSave.Enabled Then CmdSave.PerformClick()
    End Sub
    Private Sub V_ShortPrint(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not M_Mode = "X" Then Exit Sub
        If M_Stt_Rec.Trim = "" Then Exit Sub
        If Me.CmdPrint.Enabled Then V_Print(sender, e)
    End Sub
    Private Sub FrmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If M_Mode.Trim = "X" Then If e.KeyValue = 27 Then V_Exit(sender, e)
        If M_Mode.Trim = "X" Then
            Select Case e.KeyValue
                Case 33 'Pageup
                    V_Prev(sender, e)
                Case 34 'PageDown
                    V_NEXT(sender, e)
                Case 35 'End
                    V_Bottom(sender, e)
                Case 36 'Home
                    V_Top(sender, e)
            End Select
        End If
    End Sub
    Private Function ChkRightsVoucher(ByVal _Mode As String) As Boolean
        Dim _Dt As Date = TxtNgay_Ct.Value
        Dim _Ma_Post As String = CbbMa_Post.SelectedValue.ToString.Trim
        ChkRightsVoucher = CyberSupport.ChkRightsVoucher(_Dt, _Mode, _Ma_Post, M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, M_LAN, AppConn, osysvar, CyberSmlib)
    End Function
#End Region
#Region "Button"
    Private Sub V_Save(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DetailGRV.PostEditor()
        Dv_DetailTmp.Table.AcceptChanges()

        If M_Mode.Trim = "M" Then TxtMa_Dvcs.Text = M_Ma_Dvcs
        If M_Mode.Trim = "M" Then TxtUser_id.Text = M_User_ID
        If TxtMa_NT.Text.Trim = "" Then V_GetTyGia()
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        Dim _Ngay_LCt As Date = TxtNgay_Ct.Value
        '----------------------------------------------------------------------------------------------------------------------
        V_GetDateVoucher(M_Mode, _Ngay_Ct, _Ngay_LCt)
        '----------------------------------------------------------------------------------------------------------------------
        If Not ChkRightsVoucher("L") Then Exit Sub
        '----------------------------------------------------------------------------------------------------------------------
        V_GetNoVoucherAuto() ' Tao So Chung tu tu dong
        '----------------------------------------------------------------------------------------------------------------------
        If Not ChkVsave() Then Exit Sub 'Kiem tra va Update du lieu chuong tri
        '----------------------------------------------------------------------------------------------------------------------
        CyberInput.V_Save_Default_TTCP(Dt_DetailTmp, M_Is_Visible_TTCP, CbbMa_TTCP_H, M_Ma_CT, CyberSmodb)
        CyberInput.V_Save_Default_TTCP(Dt_DetailtmpKhac, M_Is_Visible_TTCP, CbbMa_TTCP_H, M_Ma_CT, CyberSmodb)
        '----------------------------------------------------------------------------------------------------------------------
        V_Phan_Bo_Tien()

        If Not CyberSupport.V_ChkExistNovoucher(AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Stt_Rec, M_Ma_CT, TxtSo_ct.Text.Trim, _Ngay_Ct, _Ngay_LCt, M_Ma_Dvcs, M_User_Name, CyberSmlib) Then Exit Sub '---Kiem tra trung so chung tu
        '----------------------------------------------------------------------------------------------------------------------
        Dim DrMasterOld As DataRow
        Dim drMaster As DataRow
        Dim CrrRow As Integer = -1
        If M_Mode.Trim = "M" Then
            drMaster = Dt_Master.NewRow
            CyberSmodb.SetValueBlankRow(drMaster)
            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.Item("Stt_Rec") = M_Stt_Rec
            drMaster.Item("Ma_Dvcs") = M_Ma_Dvcs
        Else
            CrrRow = Dt_Master.Rows.IndexOf(Dt_Master.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(0))
            drMaster = Dt_Master.Rows(CrrRow)
            DrMasterOld = CyberSmodb.V_CopyDataRow(drMaster)

            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.BeginEdit()
        End If
        drMaster.Item("Stt_Rec") = M_Stt_Rec.Trim
        drMaster.Item("Ma_Ct") = M_Ma_CT.Trim
        drMaster.Item("So_Ct") = CyberSupport.V_soct(TxtSo_ct.Text.Trim)
        '---Save Post
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)
        '---------------------------------------------------
        Dim DsSave As DataSet
        If Not CyberSmodb.V_SysCheckSaveVoucher(AppConn, osysvar, {Dt_DetailTmp, CyberSmodb.V_ConvertDrToTb(drMaster), Dt_DetailtmpKhac}, {M_Ct, M_Ph, "CT91RO"}, M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, CbbMa_GD.SelectedValue, M_Ma_CT, M_Stt_Rec, M_LAN, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib, CyberSupport, DsSave) Then
            If M_Mode = "S" And Not DrMasterOld Is Nothing Then CyberSmodb.V_UpdateRowtoRow(DrMasterOld, Dt_Master, CrrRow)
            Return
        End If
        '---------------------------------------------------
        '---Update Head
        If DsSave.Tables.Count >= 2 Then
            If DsSave.Tables(1).Rows.Count > 0 Then
                CyberSmodb.SetValueTObj_1(Me, DsSave.Tables(1).Rows(0)) '----Chi set Những trường có dữ liệu
                CyberSmodb.AddValueToRow(drMaster, Me)
                drMaster.Item("Stt_Rec") = M_Stt_Rec.Trim
                drMaster.Item("Ma_Ct") = M_Ma_CT.Trim
                drMaster.Item("So_Ct") = CyberSupport.V_soct(TxtSo_ct.Text.Trim)
            End If
        End If

        If M_Mode.Trim = "M" Then Dt_Master.Rows.Add(drMaster) Else Dt_Master.Rows(CrrRow).EndEdit()
        Dt_Master.AcceptChanges()
        '---Update Chi tiet
        If DsSave.Tables.Count >= 3 Then
            For iRow As Integer = 0 To DsSave.Tables(2).Rows.Count - 1
                Try
                    CyberSmodb.V_UpdateRowtoRow(DsSave.Tables(2).Rows(iRow), Dt_DetailTmp, iRow)
                Catch ex As Exception
                End Try
            Next
        End If
        '---Xoa trong Detail
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detail, "Stt_Rec = '" + M_Stt_Rec + "'")
        Dt_Detail.Load(Dt_DetailTmp.CreateDataReader)

        '---Update Khac
        If DsSave.Tables.Count >= 5 Then
            For iRow As Integer = 0 To DsSave.Tables(4).Rows.Count - 1
                Try
                    CyberSmodb.V_UpdateRowtoRow(DsSave.Tables(3).Rows(iRow), Dt_DetailtmpKhac, iRow)
                Catch ex As Exception
                End Try
            Next
        End If

        '---Xoa trong Detailkhac
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_DetailKhac, "Stt_Rec = '" + M_Stt_Rec + "'")
        Dt_DetailKhac.Load(Dt_DetailtmpKhac.CreateDataReader)

        '----------------------------------------------------------------------------------------------------------------------
        M_Mode = "X"
        M_Count = Dt_Master.Rows.Count
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("L")
        CyberSmlib.FlushMemorySave()
    End Sub
    Private Sub V_Save_Luu(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DetailGRV.PostEditor()
        Dv_DetailTmp.Table.AcceptChanges()
        If M_Mode.Trim = "M" Then TxtMa_Dvcs.Text = M_Ma_Dvcs
        If M_Mode.Trim = "M" Then TxtUser_id.Text = M_User_ID
        If TxtMa_NT.Text.Trim = "" Then V_GetTyGia()
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        Dim _Ngay_LCt As Date = TxtNgay_Ct.Value
        '----------------------------------------------------------------------------------------------------------------------
        V_GetDateVoucher(M_Mode, _Ngay_Ct, _Ngay_LCt)
        '----------------------------------------------------------------------------------------------------------------------
        If Not ChkRightsVoucher("L") Then Exit Sub
        '----------------------------------------------------------------------------------------------------------------------
        V_GetNoVoucherAuto() ' Tao So Chung tu tu dong
        '----------------------------------------------------------------------------------------------------------------------
        If Not ChkVsave() Then Exit Sub 'Kiem tra va Update du lieu chuong tri
        '----------------------------------------------------------------------------------------------------------------------
        CyberInput.V_Save_Default_TTCP(Dt_DetailTmp, M_Is_Visible_TTCP, CbbMa_TTCP_H, M_Ma_CT, CyberSmodb)
        '----------------------------------------------------------------------------------------------------------------------
        'V_Phan_Bo_Tien()
        '----------------------------------------------------------------------------------------------------------------------
        If Not CyberSupport.ChkVoucherInput(Me, AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Ma_CT, _Ngay_Ct, CbbMa_GD.SelectedValue, M_Stt_Rec, CbbMa_Post.SelectedValue, M_Ma_Dvcs, M_User_Name, Dt_DetailTmp, "Ten_Tk,TEN_KH", "TEN_VT,TEN_KHO_I", CyberSmlib, CyberSupport, CyberSmodb, CyberLoading) Then Exit Sub
        '----------------------------------------------------------------------------------------------------------------------
        If Not CyberSupport.V_ChkExistNovoucher(AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Stt_Rec, M_Ma_CT, TxtSo_ct.Text.Trim, _Ngay_Ct, _Ngay_LCt, M_Ma_Dvcs, M_User_Name, CyberSmlib) Then Exit Sub '---Kiem tra trung so chung tu
        '----------------------------------------------------------------------------------------------------------------------

        If Not Add2Database() Then Return
        '----------------------------------------------------------------------------------------------------------------------
        M_Mode = "X"
        M_Count = Dt_Master.Rows.Count
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("L")
        CyberSmlib.FlushMemorySave()

    End Sub
    Private Function ChkVsave() As Boolean
        Dim iRow, nCount As Integer
        nCount = Dt_DetailTmp.Rows.Count
        For iRow = nCount - 1 To 0 Step -1
            If Dt_DetailTmp.Rows(iRow).Item("Dien_Giaii").ToString.Trim = "" Then
                Dt_DetailTmp.Rows(iRow).Delete()
                Dt_DetailTmp.AcceptChanges()
            End If
        Next
        '-----------------------------------------------------------------------------------
        For iRow = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_DetailTmp.Rows(iRow).BeginEdit()
            Dt_DetailTmp.Rows(iRow).Item("Stt_Rec") = M_Stt_Rec
            Dt_DetailTmp.Rows(iRow).Item("Ma_Ct") = M_Ma_CT
            Dt_DetailTmp.Rows(iRow).Item("Ngay_Ct") = TxtNgay_Ct.Value
            Dt_DetailTmp.Rows(iRow).Item("So_Ct") = CyberSupport.V_soct(TxtSo_ct.Text.Trim)
            Dt_DetailTmp.Rows(iRow).Item("Stt_Rec0") = CyberSupport.GetStt_Rec0(iRow + 1)
            If TxtMa_Bp_H.Text.Trim <> "" Then Dt_DetailTmp.Rows(iRow).Item("Ma_Bp_I") = TxtMa_Bp_H.Text.Trim
            If txtMa_HS_H.Text.Trim <> "" Then Dt_DetailTmp.Rows(iRow).Item("Ma_HS_I") = txtMa_HS_H.Text.Trim
            Dt_DetailTmp.Rows(iRow).EndEdit()
        Next
        Dt_DetailTmp.AcceptChanges()


        '---------------------------------------------------------------------------------
        For iRow = 0 To Dt_DetailtmpKhac.Rows.Count - 1
            Dt_DetailtmpKhac.Rows(iRow).BeginEdit()
            Dt_DetailtmpKhac.Rows(iRow).Item("Stt_Rec") = M_Stt_Rec
            Dt_DetailtmpKhac.Rows(iRow).Item("Ma_Ct") = M_Ma_CT
            Dt_DetailtmpKhac.Rows(iRow).Item("Ngay_Ct") = TxtNgay_Ct.Value
            Dt_DetailtmpKhac.Rows(iRow).Item("So_Ct") = CyberSupport.V_soct(TxtSo_ct.Text.Trim)
            Dt_DetailtmpKhac.Rows(iRow).Item("Stt_Rec0") = CyberSupport.GetStt_Rec0(iRow + 1)
            If TxtMa_Bp_H.Text.Trim <> "" Then Dt_DetailtmpKhac.Rows(iRow).Item("Ma_Bp_I") = TxtMa_Bp_H.Text.Trim
            If txtMa_HS_H.Text.Trim <> "" Then Dt_DetailtmpKhac.Rows(iRow).Item("Ma_HS_I") = txtMa_HS_H.Text.Trim
            Dt_DetailtmpKhac.Rows(iRow).EndEdit()
        Next
        Dt_DetailtmpKhac.AcceptChanges()

        If Not CyberSupport.ChkDetail(Dv_DetailTmp.Count, M_Ma_CT, M_LAN, osysvar) Then Return False
        '---Update: So_RO/So_PO/So_SO
        CyberSupport.V_SaveLenh(Dv_DetailTmp, TxtLenh_RO.Text, TxtLenh_PO.Text, TxtLenh_SO.Text, TxtLenh_Vt.Text)
        UpdateList()
        ChkVsave = True
    End Function
    Private Sub V_Phan_Bo_Tien()
        'If ChkSua_CK.Checked Then
        '    CyberSupport.Phan_Bo(Dt_DetailTmp, "Tien_NT2", "Ck_Nt", TxtT_CK_Nt.Double, M_R_TIEN_NT)
        '    CyberSupport.Phan_Bo(Dt_DetailTmp, "Tien_NT2", "Ck", TxtT_CK.Double, M_R_TIEN)
        'End If

        'CyberSupport.Phan_Bo(Dt_DetailTmp, "Tien_NT2", "Thue_Nt", TxtT_thue_NT.Double, M_R_TIEN_NT)
        'CyberSupport.Phan_Bo(Dt_DetailTmp, "Tien_NT2", "Thue", TxtT_Thue.Double, M_R_TIEN)
    End Sub
    Private Function Add2Database() As Boolean
        Dim drMaster As DataRow
        Dim CrrRow As Integer = -1
        If M_Mode.Trim = "M" Then
            drMaster = Dt_Master.NewRow
            CyberSmodb.SetValueBlankRow(drMaster)
            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.Item("Stt_Rec") = M_Stt_Rec
            drMaster.Item("Ma_Dvcs") = M_Ma_Dvcs
        Else
            CrrRow = Dt_Master.Rows.IndexOf(Dt_Master.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(0))
            drMaster = Dt_Master.Rows(CrrRow)
            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.BeginEdit()
        End If
        drMaster.Item("Stt_Rec") = M_Stt_Rec.Trim
        drMaster.Item("Ma_Ct") = M_Ma_CT.Trim
        '--------------drMaster.Item("User_Id") = M_User_ID.Trim
        drMaster.Item("So_Ct") = CyberSupport.V_soct(TxtSo_ct.Text.Trim)
        '---Save Post
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)
        If M_Mode.Trim = "M" Then Dt_Master.Rows.Add(drMaster) Else Dt_Master.Rows(CrrRow).EndEdit()
        Dt_Master.AcceptChanges()
        '-----------------------------------------------------------------------------------------------------
        '---Xoa trong Detail
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detail, "Stt_Rec = '" + M_Stt_Rec + "'")
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_DetailKhac, "Stt_Rec = '" + M_Stt_Rec + "'")
        '+Import To Detail 
        For i As Integer = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_Detail.ImportRow(Dt_DetailTmp.Rows(i))
        Next
        For i As Integer = 0 To Dt_DetailtmpKhac.Rows.Count - 1
            Dt_DetailKhac.ImportRow(Dt_DetailtmpKhac.Rows(i))
        Next
        '-----------------------------------------------------------------------------------------------------
        Return CyberSmodb.V_Add2Database(AppConn, osysvar, {Dt_DetailTmp, CyberSmodb.V_ConvertDrToTb(drMaster), Dt_DetailtmpKhac}, {M_Ct, M_Ph, "CT91RO"}, M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_LAN, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib, CyberSupport)


        ''---Save: History
        'CyberSupport.V_HistoryVoucher(M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        ''-----------------------------------------------------------------------------------------------------
        ''---Save: TO SQL
        'If M_Ph.Trim <> "" Then CyberSmodb.V_SaveToSQL(AppConn, osysvar, M_User_Name, drMaster, M_Ph, M_Mode, "Stt_Rec = N'" + M_Stt_Rec + "'", IIf(M_Mode.Trim = "S", True, False))
        'If M_Ct.Trim <> "" Then CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailTmp, M_Ct, M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        ''-----------------------------------------------------------------------------------------------------
        ''---Save: Post
        'CyberSupport.V_PostVoucher(M_Mode, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Function
    Private Sub Add2Database_Luu()
        Dim drMaster As DataRow
        Dim CrrRow As Integer = -1
        If M_Mode.Trim = "M" Then
            drMaster = Dt_Master.NewRow
            CyberSmodb.SetValueBlankRow(drMaster)
            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.Item("Stt_Rec") = M_Stt_Rec
            drMaster.Item("Ma_Dvcs") = M_Ma_Dvcs
        Else
            CrrRow = Dt_Master.Rows.IndexOf(Dt_Master.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(0))
            drMaster = Dt_Master.Rows(CrrRow)
            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.BeginEdit()
        End If
        drMaster.Item("Stt_Rec") = M_Stt_Rec.Trim
        drMaster.Item("Ma_Ct") = M_Ma_CT.Trim
        '--------------drMaster.Item("User_Id") = M_User_ID.Trim
        drMaster.Item("So_Ct") = CyberSupport.V_soct(TxtSo_ct.Text.Trim)
        '---Save Post
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)
        If M_Mode.Trim = "M" Then Dt_Master.Rows.Add(drMaster) Else Dt_Master.Rows(CrrRow).EndEdit()
        Dt_Master.AcceptChanges()
        '-----------------------------------------------------------------------------------------------------
        '---Xoa trong Detail
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detail, "Stt_Rec = '" + M_Stt_Rec + "'")
        '+Import To Detail 
        For i As Integer = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_Detail.ImportRow(Dt_DetailTmp.Rows(i))
        Next
        '-----------------------------------------------------------------------------------------------------
        '---Save: History
        CyberSupport.V_HistoryVoucher(M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        '-----------------------------------------------------------------------------------------------------
        '---Save: TO SQL
        If M_Ph.Trim <> "" Then CyberSmodb.V_SaveToSQL(AppConn, osysvar, M_User_Name, drMaster, M_Ph, M_Mode, "Stt_Rec = N'" + M_Stt_Rec + "'", IIf(M_Mode.Trim = "S", True, False))
        If M_Ct.Trim <> "" Then CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailTmp, M_Ct, M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        '-----------------------------------------------------------------------------------------------------
        '---Save: Post
        CyberSupport.V_PostVoucher(M_Mode, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
    Private Sub V_Copy(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If M_Stt_Rec.Trim = "" Then Exit Sub
        If Not ChkRightsVoucher("C") Then Exit Sub

        M_Stt_RecOld = M_Stt_Rec
        M_Stt_Rec = CyberSmlib.V_Get_Stt_Rec(M_Ma_CT, AppConn)

        Dim Frm As Cyber.From.FrmCopy
        Frm = New FrmCopy
        Frm.Para = M_Para
        Frm.Lan = M_LAN
        Frm.Sysvar = osysvar
        Frm.DrDmct = Me.DrDmct
        Frm.So_CT = ""
        Frm.Ngay_CT = Now.Date
        Frm.Ngay_LCT = Now.Date
        Frm.SysApp = AppConn
        Frm.Ma_Dvcs = TxtMa_Dvcs.Text
        Frm.Stt_Rec = M_Stt_Rec
        Frm.ShowDialog()

        If Not Frm.Ok_Copy Then
            M_Stt_Rec = M_Stt_RecOld
            Exit Sub
        End If

        Dim _Ngay_Ct_Copy As Date = Frm.TxtNgay_Ct.Value
        Dim _Ngay_LCt_Copy As Date = Frm.TxtNgay_LCt.Value
        Dim _So_Ct_Copy As String = Frm.txtSo_ct.Text
        Dim _Ma_Quyen_Copy As String = Frm.TxtMa_Quyen.Text

        Dim I As Integer
        For I = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_DetailTmp.Rows(I).BeginEdit()
            Dt_DetailTmp.Rows(I).Item("Stt_Rec") = M_Stt_Rec
            Dt_DetailTmp.Rows(I).Item("Ngay_Ct") = _Ngay_Ct_Copy
            Dt_DetailTmp.Rows(I).Item("So_Ct") = _So_Ct_Copy
            Dt_DetailTmp.Rows(I).EndEdit()
        Next

        TxtStt_Rec.Text = M_Stt_Rec
        TxtNgay_Ct.Value = _Ngay_Ct_Copy
        TxtNgay_LCt.Value = _Ngay_LCt_Copy
        TxtMa_Quyen.Text = _Ma_Quyen_Copy.Trim
        TxtSo_ct.Text = _So_Ct_Copy.Trim
        M_Mode = "M"
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()

        TxtNgay_CTHD.Value = TxtNgay_Ct.Value
        TxtnoteHDDT.Text = ""
        TxtMau_VATHD.Text = ""
        TxtSo_seriHD.Text = ""
        TxtSo_HDDT.Text = ""
        Txtma_tra_cuu.Text = ""
        TxtEmailHDDT.Text = ""
    End Sub
    Private Sub V_New(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Stt_RecOld = M_Stt_Rec
        If Not ChkRightsVoucher("M") Then Exit Sub
        M_Stt_Rec = CyberSmlib.V_Get_Stt_Rec(M_Ma_CT, AppConn)

        M_Mode = "M"
        V_Databing()
        '--------------
        TxtStt_Rec.Text = M_Stt_Rec
        TxtMa_Dvcs.Text = M_Ma_Dvcs
        '--------------
        If txtDien_giai.Text.Trim = "" Then txtDien_giai.Text = M_Dien_Giai
        If txtMa_NX.Text.Trim = "" Then
            txtMa_NX.Text = M_Tk_No
            txtTen_NX.Text = M_Ten_Tk_No
        End If
        If TxtHT_TT.Text.Trim = "" Then TxtHT_TT.Text = M_HT_TT
        '--------------
        V_New()
        TxtNgay_CTHD.Value = New Date(1900, 1, 1)

        'V_GetTk_Thue_No()
        'V_GetTk_Thue_Co()
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("M")

        CyberSmodb.SetValueFromCombox(CbbMa_TTCP_H, M_Ma_TTCP_H)
    End Sub
    Private Sub V_New()
        If Dt_DetailTmp.Rows.Count < 1 Then
            Dim DrCurren As DataRow
            Dt_DetailTmp.NewRow()
            DrCurren = Dt_DetailTmp.NewRow
            CyberSmodb.SetValueBlankRow(DrCurren)

            If M_Tk_Co.Trim <> "" Then
                DrCurren.Item("Tk_DT") = M_Tk_Co.Trim
                If DrCurren.Table.Columns.Contains("Ten_Tk_DT") Then DrCurren.Item("Ten_Tk_DT") = M_Ten_Tk_Co.Trim
            End If

            DrCurren.Item("Stt_Rec") = M_Stt_Rec.Trim
            DrCurren.Item("Ma_Ct") = M_Ma_CT.Trim
            DrCurren.Item("Ngay_Ct") = TxtNgay_Ct.Value
            DrCurren.Item("Stt_Rec0") = "0001"

            Dt_DetailTmp.Rows.Add(DrCurren)
            Dt_DetailTmp.AcceptChanges()
        End If
        If Dt_DetailtmpKhac.Rows.Count < 1 Then
            Dim DrCurren As DataRow
            Dt_DetailtmpKhac.NewRow()
            DrCurren = Dt_DetailtmpKhac.NewRow
            CyberSmodb.SetValueBlankRow(DrCurren)
            DrCurren.Item("Stt_Rec") = M_Stt_Rec.Trim
            DrCurren.Item("Ma_Ct") = M_Ma_CT.Trim
            DrCurren.Item("Ngay_Ct") = TxtNgay_Ct.Value
            DrCurren.Item("Stt_Rec0") = "0001"

            Dt_DetailtmpKhac.Rows.Add(DrCurren)
            Dt_DetailtmpKhac.AcceptChanges()
        End If
    End Sub
    Private Sub V_Edit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Stt_RecOld = M_Stt_Rec
        If Not ChkRightsVoucher("S") Then Exit Sub
        M_Mode = "S"
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("S")
    End Sub
    Private Sub V_Delete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If M_Stt_Rec.Trim = "" Then Exit Sub
        If Not ChkRightsVoucher("D") Then Exit Sub
        If Not chkCherDeleteHDDT("D") Then Exit Sub

        Dim iMasterRow As Integer = -1
        For iRow As Integer = 0 To Dv_Master.Count - 1
            If Dv_Master.Item(iRow).Item("Stt_Rec").ToString.Trim = M_Stt_Rec Then
                iMasterRow = iRow
                Exit For
            End If
        Next
        If Not CyberSupport.V_DeleteVoucher(AppConn, osysvar, M_LAN, M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib) Then Exit Sub
        CyberSupport.V_DeleteTableVoucher(Dt_Master, M_Stt_Rec)
        CyberSupport.V_DeleteTableVoucher(Dt_Detail, M_Stt_Rec)

        M_Count = Dt_Master.Rows.Count

        If M_Count < 0 Then iMasterRow = -1
        If iMasterRow >= M_Count Then iMasterRow = M_Count - 1

        If iMasterRow >= 0 Then M_Stt_Rec = Dv_Master.Item(iMasterRow).Item("Stt_Rec").ToString.Trim Else M_Stt_Rec = ""

        M_Mode = "X"
        V_Databing()

        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("D")
    End Sub
    Function chkCherDeleteHDDT(ByVal Status As String) As Boolean
        If DrDmct.Table.Columns.Contains("HDDT") = False Then Return True
        If DrDmct("HDDT").ToString.Trim <> "1" Then Return True

        Dim dsReturn As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "Cp_InvoiceChekDeleteVoucher", M_Ma_CT & "#" & M_Stt_Rec & "#" & M_Ma_Dvcs & "#" & M_User_Name)
        If dsReturn.Tables(0).Rows(0)("Status").ToString.Trim.ToUpper = "N" Then
            MsgBox(dsReturn.Tables(0).Rows(0)("Note").ToString.Trim, MsgBoxStyle.Critical, osysvar("M_CYBER_VER"))
            dsReturn.Dispose()
            Return False
        End If
        dsReturn.Dispose()
        Return True
    End Function
    Private Sub V_Print(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not ChkRightsVoucher("P") Then Exit Sub
        If M_Stt_Rec.Trim = "" Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        Dim _Ma_Post As String = CbbMa_Post.SelectedValue.ToString.Trim
        CyberVoucher.V_PrintVocuher(AppConn, osysvar, Nothing, M_Stt_Rec, _Dt, _Ma_Post, M_LAN, M_Para, DrDmct, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib, CyberSupport)
    End Sub
    Private Sub V_Cancel(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Stt_Rec = M_Stt_RecOld
        V_Databing()
        M_Mode = "X"
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("X")
    End Sub
    Private Sub V_View(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = "X"
        If M_Stt_Rec = "" Then Exit Sub
        M_Stt_Rec = CyberFrom.V_ViewVoucher(AppConn, osysvar, M_LAN, M_Para, DrDmct, DsData, DsHead, DsLookup, Dv_Master, Dv_Detail, M_Stt_Rec, strFilter, CyberFill, CyberSmlib, CyberSupport, False, True)
        V_Databing()
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
    End Sub
    Private Sub V_Search(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not CyberVoucher.V_FilterVocuher(AppConn, osysvar, Me.DsLookup, M_LAN, M_Para, DrDmct, M_strFilter, M_Ma_CT, M_Ma_Dvcs, M_User_Name) Then Exit Sub
        Dim DsRefresh As DataSet = CyberSupport.V_FilterData(AppConn, M_strFilter, CyberSmlib, CyberSmodb, DsData)
        If Not CyberSupport.MsgFilterData(DsRefresh.Tables(1), M_LAN, osysvar) Then Exit Sub

        If DsRefresh.Tables(1).Rows.Count = 1 Then M_Stt_Rec = DsRefresh.Tables(1).Rows(0).Item("Stt_Rec")
        If DsRefresh.Tables(1).Rows.Count > 1 Then M_Stt_Rec = CyberFrom.V_ViewVoucher(AppConn, osysvar, M_LAN, M_Para, DrDmct, Me.DsData, Me.DsHead, Me.DsLookup, Dv_Master, Dv_Detail, M_Stt_Rec, strFilter, CyberFill, CyberSmlib, CyberSupport, False, True)

        V_Databing()
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        M_Mode = "X"
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
    End Sub
    Private Sub V_Exit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not CyberSupport.V_ExitVoucher(osysvar, M_LAN) Then Exit Sub
        Me.Close()
    End Sub
#End Region
#Region "Add Or Detete Item"
    Private Sub MasterGRV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iCoumnVisible As Integer = DetailGRV.VisibleColumns.Count - 1
        Dim iRowVisible As Integer = DetailGRV.RowCount - 1
        Dim iRowRowFocus As Integer = DetailGRV.FocusedRowHandle
        Dim iColumnRowFocus As Integer = DetailGRV.VisibleColumns.IndexOf(DetailGRV.FocusedColumn)
        Dim iRowOld As Integer = DetailGRV.GetFocusedDataSourceRowIndex
        'If e.KeyCode = Keys.Enter And iRowVisible = iRowRowFocus And iCoumnVisible = iColumnRowFocus Then V_AddItem(iRowOld) '' Cot cuoi cung them dong
        If iRowVisible <> iRowRowFocus Or iCoumnVisible <> iColumnRowFocus Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            V_AddItem(iRowOld) '' Cot cuoi cung them dong
        ElseIf e.KeyCode = Keys.End Then
            SendKeys.Send("^{Tab}")
        End If
    End Sub
    Private Sub V_AddItem(Optional ByVal iRow As Integer = -1)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim DrvOld As DataRowView
        If iRow >= 0 Then DrvOld = Dv_DetailTmp.Item(iRow) Else DrvOld = Nothing
        Dv_DetailTmp.Table.Rows.Add()
        CyberSmodb.SetValueBlankRow(Dv_DetailTmp.Table.Rows(Dv_DetailTmp.Table.Rows.Count - 1))
        CyberSupport.SetCarryOn(DrvOld, Dv_DetailTmp.Table.Rows(Dv_DetailTmp.Table.Rows.Count - 1), New DataView(M_DsHead.Tables(1)))
        CarrOn(Dv_DetailTmp.Table.Rows(Dv_DetailTmp.Table.Rows.Count - 1))
        UpdateList()
        iRow = Dv_DetailTmp.Count - 1
        CyberFill.V_ForcusCell(DetailGRV, iRow, 0)

    End Sub
    Private Sub CarrOn(ByVal DvNew As DataRow)
        DvNew.Item("Stt_Rec") = M_Stt_Rec.Trim
        DvNew.Item("Ma_Ct") = M_Ma_CT.Trim
        DvNew.Item("Ngay_Ct") = Me.TxtNgay_Ct.Value
    End Sub
#End Region
    Private Sub MasterKhacGRV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iCoumnVisible As Integer = DetailKhacGRV.VisibleColumns.Count - 1
        Dim iRowVisible As Integer = DetailKhacGRV.RowCount - 1
        Dim iRowRowFocus As Integer = DetailKhacGRV.FocusedRowHandle
        Dim iColumnRowFocus As Integer = DetailKhacGRV.VisibleColumns.IndexOf(DetailGRV.FocusedColumn)
        Dim iRowOld As Integer = DetailKhacGRV.GetFocusedDataSourceRowIndex
        If iRowVisible <> iRowRowFocus Or iCoumnVisible <> iColumnRowFocus Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            V_AddItemKHAC(iRowOld) '' Cot cuoi cung them dong
        ElseIf e.KeyCode = Keys.End Then
            SendKeys.Send("^{Tab}")
        End If
    End Sub
    Private Sub V_AddItemKHAC(Optional ByVal iRow As Integer = -1)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim DrvOld As DataRowView
        If iRow >= 0 Then DrvOld = Dv_DetailtmpKhac.Item(iRow) Else DrvOld = Nothing
        Dv_DetailtmpKhac.Table.Rows.Add()
        CyberSmodb.SetValueBlankRow(Dv_DetailtmpKhac.Table.Rows(Dv_DetailtmpKhac.Table.Rows.Count - 1))
        CyberSupport.SetCarryOn(DrvOld, Dv_DetailtmpKhac.Table.Rows(Dv_DetailtmpKhac.Table.Rows.Count - 1), New DataView(M_DsHead.Tables(2)))
        Khac_CarrOn(Dv_DetailtmpKhac.Table.Rows(Dv_DetailtmpKhac.Table.Rows.Count - 1))
        Khac_UpdateList()
        iRow = Dv_DetailtmpKhac.Count - 1
        CyberFill.V_ForcusCell(DetailKhacGRV, iRow, 0)
    End Sub
    Private Sub Khac_CarrOn(ByVal DvNew As DataRow)
        DvNew.Item("Stt_Rec") = M_Stt_Rec.Trim
        DvNew.Item("Ma_Ct") = M_Ma_CT.Trim
        DvNew.Item("Ngay_Ct") = Me.TxtNgay_Ct.Value
    End Sub
#Region "Sms - Import"
    Private Sub V_Import(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TbImport As New DataTable
        TbImport = CyberExport.V_ImportDataToGridview(AppConn, osysvar, M_Para, DetailGRV, Dt_DetailTmp, M_LAN)
        If TbImport Is Nothing Then Exit Sub
        '==================== Xu ly du lieu được Import vào
        Dt_DetailTmp.Clear()
        Dt_DetailTmp.AcceptChanges()
        For i = 0 To TbImport.Rows.Count - 1
            Dt_DetailTmp.ImportRow(TbImport.Rows(i))
        Next
        Dt_DetailTmp.AcceptChanges()
        For iRow = 0 To Dt_DetailTmp.Rows.Count - 1
            V_Tinh_Toan(iRow)
        Next
        Dt_DetailTmp.AcceptChanges()

    End Sub
    Private Sub SetTxt()
        TxtT_SO_LUONG.ReadOnly = True

        TxtT_Tien_NT.ReadOnly = True
        TxtT_Tien.ReadOnly = True

        TxtThue_Suat.ReadOnly = True

        TxtT_Tien_NT2.ReadOnly = True
        TxtT_Tien2.ReadOnly = True

        TxtT_thue_NT.ReadOnly = True
        TxtT_Thue.ReadOnly = True

        TxtT_CK_Nt.ReadOnly = True
        TxtT_CK.ReadOnly = True

        TxtT_TT_NT.ReadOnly = True
        TxtT_TT.ReadOnly = True

        TxtTen_kh.ReadOnly = True
        txtTen_BP_H.ReadOnly = True
        txtTen_HS_H.ReadOnly = True
        txtTen_NX.ReadOnly = True

        If M_Mode = "M" Or M_Mode = "S" Then
            If ChkSua_CK.Checked Then TxtT_CK_Nt.ReadOnly = False
            If ChkSua_Thue.Checked Then TxtT_thue_NT.ReadOnly = False
        End If


        'TxtNgay_CTHD.ReadOnly = True
        'TxtnoteHDDT.ReadOnly = True
        'TxtMau_VATHD.ReadOnly = True
        'TxtSo_seriHD.ReadOnly = True
        'TxtSo_HDDT.ReadOnly = True
        'Txtma_tra_cuu.ReadOnly = True
        'TxtEmailHDDT.ReadOnly = True

    End Sub
#End Region
    Private Sub TxtSo_BG_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtSo_BG.TextChanged
        V_SetBG()
        Dt_DetailTmp.AcceptChanges()
        For iRow = 0 To Dt_DetailTmp.Rows.Count - 1
            V_Tinh_Toan(iRow)
        Next
        Dt_DetailTmp.AcceptChanges()
    End Sub
    Private Sub V_SetBG()
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If M_Stt_Rec = "" Then Exit Sub

        Dim _So_BG As String = TxtSo_BG.Text.Trim

        Dim _DsDetail As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoGetDL_HD3", _So_BG & "#" & M_Stt_Rec.Trim & "#" & M_Ma_Dvcs.Trim & "#" & M_User_Name)

        If Not CyberSupport.V_MsgChk(_DsDetail.Tables(0), SysVar, M_LAN) Then
            Exit Sub
            _DsDetail.Dispose()
        End If
        ChkSua_Thue_CK.Checked = True
        For i = 1 To _DsDetail.Tables.Count - 1
            CyberSmodb.SetNotNullTable(_DsDetail.Tables(i))
        Next
        Dt_DetailTmp.Clear()
        CyberSmodb.SQLTbToTb(_DsDetail.Tables(1), Dt_DetailTmp)
        txtMa_NX.Text = _DsDetail.Tables(2).Rows(0).Item("Ma_nx")
        txtDien_giai.Text = _DsDetail.Tables(2).Rows(0).Item("Dien_Giai")
        TxtTen_KhVAT.Text = _DsDetail.Tables(2).Rows(0).Item("Ten_KhVAT")
        TxtDia_Chi.Text = _DsDetail.Tables(2).Rows(0).Item("Dia_Chi")
        TxtDia_ChiVAT.Text = _DsDetail.Tables(2).Rows(0).Item("Dia_ChiVAT")
        TxtEmailHDDT.Text = _DsDetail.Tables(2).Rows(0).Item("EmailHDDT")
        UpdateList()
        Dt_DetailTmp.AcceptChanges()
        _DsDetail.Dispose()
    End Sub
    Private Sub V_SetRO()
        If Not (M_Mode = "M") Then Exit Sub
        If M_Stt_Rec = "" Then Exit Sub

        Dim _So_Ro As String = TxtLenh_RO.Text.Trim

        Dim _DsDetail As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoGetDetailHD3", _So_Ro & "#" & M_Stt_Rec.Trim & "#" & M_Ma_Dvcs.Trim & "#" & M_User_Name & "#" & M_Mode)

        If Not CyberSupport.V_MsgChk(_DsDetail.Tables(0), SysVar, M_LAN) Then
            Exit Sub
            _DsDetail.Dispose()
        End If
        ChkSua_Thue_CK.Checked = True
        For i = 1 To _DsDetail.Tables.Count - 1
            CyberSmodb.SetNotNullTable(_DsDetail.Tables(i))
        Next
        Dt_DetailTmp.Clear()
        CyberSmodb.SQLTbToTb(_DsDetail.Tables(1), Dt_DetailTmp)
        txtMa_NX.Text = _DsDetail.Tables(2).Rows(0).Item("Ma_nx")
        txtDien_giai.Text = _DsDetail.Tables(2).Rows(0).Item("Dien_Giai")
        TxtTen_KhVAT.Text = _DsDetail.Tables(2).Rows(0).Item("Ten_KhVAT")
        TxtDia_Chi.Text = _DsDetail.Tables(2).Rows(0).Item("Dia_Chi")
        TxtDia_ChiVAT.Text = _DsDetail.Tables(2).Rows(0).Item("Dia_ChiVAT")
        TxtEmailHDDT.Text = _DsDetail.Tables(2).Rows(0).Item("EmailHDDT")
        UpdateList()
        Dt_DetailTmp.AcceptChanges()

        For iRow = 0 To Dt_DetailTmp.Rows.Count - 1
            V_Tinh_Toan(iRow)
        Next
        Dt_DetailTmp.AcceptChanges()

        _DsDetail.Dispose()
    End Sub
#Region "Hóa đơn điện tử"
    '#Region "Tạo hóa đơn điện tử"
    '    Private Sub V_TaoHD(ByVal _Loai_HD As String, ByVal _Stt_Rec_TT As String)
    '        Dim api As New InvoiceMisa.MisaInvoice
    '        Dim intReturnValue As Integer
    '        Dim Ngay As Date = TxtNgay_Ct.Value
    '        intReturnValue = MessageBox.Show("Bạn chắc chắn muốn tạo hóa đơn điện tử?", "Ghi chú", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
    '        If (intReturnValue = DialogResult.No) Then Exit Sub

    '        Dim _Chk As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_ChkHDDT_Tao", M_Stt_Rec + "#" + M_Ma_CT + "#" + M_Ma_Dvcs + "#" + M_User_Name)
    '        If Not CyberSupport.V_MsgChk(_Chk.Tables(0), SysVar, M_LAN) Then Exit Sub

    '        Dim DsData As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_API_CreateInvoice", _Loai_HD + "#" + Ngay.ToString("yyyyMMdd") + "#" + "" + "#" + "" + "#" + M_Stt_Rec.Trim + "#" + "" + "#" + M_Ma_CT.Trim + "#" + M_Ma_Dvcs.Trim + "#" + M_User_Name.Trim)

    '        If DsData.Tables(0).Rows(0)("Status").ToString.Trim.ToUpper <> "Y" Then
    '            MsgBox(DsData.Tables(0).Rows(0)("Note").ToString.Trim)
    '            Return
    '        End If

    '        Dim strError As String = ""
    '        Dim dtSave, dtInvoice As DataTable

    '        If api.V_KyHoaDon(DsData, dtSave, dtInvoice, strError) = False Then
    '            MsgBox(strError)
    '            Return
    '        End If

    '        Dim xml = CyberSmodb.V_ConvertDataToXML(New String() {"ROOTNODE"}, New DataTable() {dtSave})
    '        Dim xml_invoice = ""
    '        If Not dtInvoice Is Nothing And dtInvoice.Rows.Count > 0 Then
    '            dtInvoice.TableName = "INVOICE"
    '            Dim dtInvoiceCopy As New DataTable("INVOICE")
    '            dtInvoiceCopy = dtInvoice.Copy()
    '            xml_invoice = CyberSmodb.V_ConvertDataToXML(New String() {"INVOICE"}, New DataTable() {dtInvoice})
    '        End If
    '        Dim dataSave As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_API_SaveResponseCreateInvoice", M_Ma_CT + "#" + xml + "#" + xml_invoice + "#" + M_Stt_Rec + "#" + _Loai_HD + "#" + _Stt_Rec_TT + "#" + M_Ma_Dvcs + "#" + M_User_Name)
    '        MsgBox(dataSave.Tables(0).Rows(0).Item("Note").ToString())
    '        V_ShortRefresh(New System.Object, New System.EventArgs)
    '    End Sub
    '#End Region
    '#Region "Update hóa đơn từ Misa về Cyber"
    '    Private Sub V_UpdateHD(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If (M_Mode = "M" Or M_Mode = "S") Then
    '            Exit Sub
    '        End If

    '        If MsgBox("Bạn chắc chắn muốn update hóa đơn điện tử?", MsgBoxStyle.YesNo, osysvar("M_CYBER_VER")) <> MsgBoxResult.Yes Then Return
    '        Dim sys As New InvoiceMisa.MisaInvoice
    '        Dim dt As DataTable
    '        Dim strErr As String = ""
    '        Dim _Loai_HD As String = "U"
    '        Dim RefID As String = ""
    '        Dim AppID As String = ""
    '        Dim Url As String = ""
    '        Dim UrlToken As String = ""
    '        Dim User_Name As String = ""
    '        Dim Password As String = ""
    '        Dim Tax As String = ""
    '        Dim data As Byte() = Nothing

    '        Dim DsgetInvoid As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_API_LoadInvoice", _Loai_HD + "#" + M_Ma_CT + "#" + M_Stt_Rec + "#" + TxtMa_Dvcs.Text + "#" + M_User_Name)

    '        Dim Count_Tb As Integer
    '        Count_Tb = DsgetInvoid.Tables.Count

    '        If Not CyberSupport.V_MsgChk(DsgetInvoid.Tables(Count_Tb - 1), SysVar) Then
    '            DsgetInvoid.Dispose()
    '            Exit Sub
    '        End If

    '        If DsgetInvoid.Tables(0).Rows.Count <= 0 Then
    '            DsgetInvoid.Dispose()
    '            Exit Sub
    '        End If

    '        Dim _DtgetInvoid As DataTable = DsgetInvoid.Tables(0)

    '        If DsgetInvoid.Tables(1).Columns.Contains("AppID") Then AppID = DsgetInvoid.Tables(1).Rows(0).Item("AppID")
    '        If _DtgetInvoid.Columns.Contains("Url") Then Url = _DtgetInvoid.Rows(0).Item("Url")
    '        If _DtgetInvoid.Columns.Contains("UrlToken") Then UrlToken = _DtgetInvoid.Rows(0).Item("UrlToken")
    '        If _DtgetInvoid.Columns.Contains("user_name") Then User_Name = _DtgetInvoid.Rows(0).Item("user_name")
    '        If _DtgetInvoid.Columns.Contains("pass") Then Password = _DtgetInvoid.Rows(0).Item("pass")
    '        If _DtgetInvoid.Columns.Contains("tax") Then Tax = _DtgetInvoid.Rows(0).Item("tax")
    '        If _DtgetInvoid.Columns.Contains("RefId") Then RefID = _DtgetInvoid.Rows(0).Item("RefId")

    '        sys.V_LayThongTinHoaDon(Url, UrlToken, AppID, User_Name, Password, Tax, RefID, dt, strErr)
    '        Dim xml As String = CyberSmodb.V_ConvertDataToXML(New String() {"TTHDDT"}, New DataTable() {dt})
    '        Dim DsData As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_API_UpdateResponse_Invoice", M_Stt_Rec + "#" + M_Ma_CT + "#" + xml + "#" + M_Ma_Dvcs.Trim + "#" + M_User_Name.Trim)

    '        If DsData.Tables(0).Rows(0)("Status").ToString.Trim.ToUpper <> "Y" Then
    '            MsgBox(DsData.Tables(0).Rows(0)("Note").ToString.Trim, MsgBoxStyle.Critical, osysvar("M_Cyber_Ver"))
    '            Return
    '        End If

    '        MsgBox("Đã thực hiện Update hóa đơn điện tử xong!", MsgBoxStyle.Information, osysvar("M_CYBER_VER"))
    '        V_ShortRefresh(sender, e)
    '    End Sub
    '#End Region
#Region "Xem hóa đơn điện tử"
    'Private Sub V_XemHD(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim strErr As String = "", _Loai_HD As String = "V"
    '    Dim Link As String = ""
    '    Dim AppID As String = ""
    '    Dim Url As String = ""
    '    Dim UrlToken As String = ""
    '    Dim User_Name As String = ""
    '    Dim Password As String = ""
    '    Dim Tax As String = ""
    '    Dim data As Byte() = Nothing
    '    Dim sys As New InvoiceMisa.MisaInvoice
    '    Dim DsgetInvoid As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_API_LoadInvoice", _Loai_HD + "#" + M_Ma_CT + "#" + M_Stt_Rec + "#" + TxtMa_Dvcs.Text + "#" + M_User_Name)

    '    Dim Count_Tb As Integer
    '    Count_Tb = DsgetInvoid.Tables.Count

    '    If Not CyberSupport.V_MsgChk(DsgetInvoid.Tables(Count_Tb - 1), SysVar) Then
    '        DsgetInvoid.Dispose()
    '        Exit Sub
    '    End If


    '    If DsgetInvoid.Tables(0).Rows.Count <= 0 Then
    '        DsgetInvoid.Dispose()
    '        Exit Sub
    '    End If

    '    Dim _DtgetInvoid As DataTable = DsgetInvoid.Tables(0)

    '    If DsgetInvoid.Tables(1).Columns.Contains("AppID") Then AppID = DsgetInvoid.Tables(1).Rows(0).Item("AppID")
    '    If _DtgetInvoid.Columns.Contains("Url") Then Url = _DtgetInvoid.Rows(0).Item("Url")
    '    If _DtgetInvoid.Columns.Contains("UrlToken") Then UrlToken = _DtgetInvoid.Rows(0).Item("UrlToken")
    '    If _DtgetInvoid.Columns.Contains("user_name") Then User_Name = _DtgetInvoid.Rows(0).Item("user_name")
    '    If _DtgetInvoid.Columns.Contains("pass") Then Password = _DtgetInvoid.Rows(0).Item("pass")
    '    If _DtgetInvoid.Columns.Contains("tax") Then Tax = _DtgetInvoid.Rows(0).Item("tax")

    '    sys.V_viewHoaDon(Url, UrlToken, AppID, User_Name, Password, Tax, _DtgetInvoid.Rows(0).Item("Ma_Tra_Cuu"), Link)
    '    MsgBox(Link)
    '    If Link = "" Then Exit Sub
    '    ' Mở PDF bằng trình duyệt
    '    Process.Start(Link)
    'End Sub
#End Region
#Region "Refresh"
    Private Sub V_ShortRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If M_Stt_Rec.Trim = "" Then Exit Sub

        Dim M_strFilter As String = "1###" & M_Stt_Rec & "#19000101#19000101#0#9#" & M_Ma_CT.Trim & "#" & M_Ma_Dvcs & "#" & M_User_Name
        Dim DsTempRefresh As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_Filter" + M_Ma_CT.Trim, M_strFilter)

        For i As Integer = 0 To DsTempRefresh.Tables.Count - 1
            CyberSmodb.SetNotNullTable(DsTempRefresh.Tables(i))
        Next
        Dim _Update As Boolean = False
        If DsTempRefresh.Tables(1).Rows.Count >= 1 Then
            M_Stt_Rec = DsTempRefresh.Tables(1).Rows(0).Item("Stt_Rec").ToString.Trim
            For iRow As Integer = 0 To Dt_Master.Rows.Count - 1
                If Dt_Master.Rows(iRow).Item("Stt_Rec").ToString.Trim = M_Stt_Rec.Trim Then
                    CyberSmodb.V_UpdateRowtoRow(DsTempRefresh.Tables(1).Rows(0), Dt_Master, iRow)
                    _Update = True
                    Exit For
                End If
            Next
        End If
        If Not _Update Then
            DsTempRefresh.Dispose()
            Exit Sub
        End If

        CyberSupport.V_DeleteTableVoucher(Dt_Detail, M_Stt_Rec)

        For iRow As Integer = 0 To DsTempRefresh.Tables(0).Rows.Count - 1
            Dt_Detail.ImportRow(DsTempRefresh.Tables(0).Rows(iRow))
        Next

        V_Databing()
        DsTempRefresh.Dispose()
    End Sub
#End Region
#End Region
#Region "TTCP Default and New/Save _TTCP"
    Dim M_Is_Visible_TTCP As Boolean = False
    Dim DtTTCP As DataTable
    Dim M_Ma_TTCP_H As String = ""
    Dim M_Ten_TTCP_H As String = ""
    Dim M_Ten_TTCP2_H As String = ""

    Dim M_Ma_TTLN_H As String = ""
    Dim M_Ten_TTLN_H As String = ""
    Dim M_Ten_TTLN2_H As String = ""

    Dim M_Ma_HS_H As String = ""
    Dim M_Ten_HS_H As String = ""
    Dim M_Ten_HS2_H As String = ""

    Dim M_Ma_BP_H As String = ""
    Dim M_Ten_BP_H As String = ""
    Dim M_Ten_BP2_H As String = ""
    Private Sub V_LoadDefault()
        If DrDmct.Table.Columns.Contains("Is_Visible_TTCP") Then M_Is_Visible_TTCP = (DrDmct.Item("Is_Visible_TTCP").ToString.Trim = "1")
        LabMa_TTCP_H.Visible = M_Is_Visible_TTCP
        CbbMa_TTCP_H.Visible = M_Is_Visible_TTCP

        If M_Is_Visible_TTCP And DrDmct.Table.Columns.Contains("CaptionTTCP") Then If DrDmct.Item("CaptionTTCP").ToString.Trim <> "" Then LabMa_TTCP_H.Text = DrDmct.Item("CaptionTTCP").ToString.Trim

        If M_Is_Visible_TTCP Then
            Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_SysGetDefaultVoucher", M_Ma_CT.Trim & "#" & M_Ma_Dvcs.ToString().Trim() & "#" & M_User_Name.ToString().Trim())

            If DsTmp.Tables.Count = 0 Then
                M_Is_Visible_TTCP = False
                DsTmp.Dispose()
                Return
            End If

            If DsTmp.Tables(0).Columns.Contains("Ma_TTCP_H") Then M_Ma_TTCP_H = DsTmp.Tables(0).Rows(0).Item("Ma_TTCP_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_TTCP_H") Then M_Ten_TTCP_H = DsTmp.Tables(0).Rows(0).Item("Ten_TTCP_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_TTCP2_H") Then M_Ten_TTCP2_H = DsTmp.Tables(0).Rows(0).Item("Ten_TTCP2_H").ToString.Trim

            If DsTmp.Tables(0).Columns.Contains("Ma_TTLN_H") Then M_Ma_TTLN_H = DsTmp.Tables(0).Rows(0).Item("Ma_TTLN_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_TTLN_H") Then M_Ten_TTLN_H = DsTmp.Tables(0).Rows(0).Item("Ten_TTLN_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_TTLN2_H") Then M_Ten_TTLN2_H = DsTmp.Tables(0).Rows(0).Item("Ten_TTLN2_H").ToString.Trim

            If DsTmp.Tables(0).Columns.Contains("Ma_HS_H") Then M_Ma_HS_H = DsTmp.Tables(0).Rows(0).Item("Ma_HS_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_HS_H") Then M_Ten_HS_H = DsTmp.Tables(0).Rows(0).Item("Ten_HS_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_HS2_H") Then M_Ten_HS2_H = DsTmp.Tables(0).Rows(0).Item("Ten_HS2_H").ToString.Trim

            If DsTmp.Tables(0).Columns.Contains("Ma_BP_H") Then M_Ma_BP_H = DsTmp.Tables(0).Rows(0).Item("Ma_BP_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_BP_H") Then M_Ten_BP_H = DsTmp.Tables(0).Rows(0).Item("Ten_BP_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_BP2_H") Then M_Ten_BP2_H = DsTmp.Tables(0).Rows(0).Item("Ten_BP2_H").ToString.Trim

            If DsTmp.Tables.Count > 1 Then
                DtTTCP = DsTmp.Tables(1).Copy
                CyberFill.V_FillComBoxValue(Me.CbbMa_TTCP_H, DtTTCP, "Ma_TTCP", If(M_LAN = "V", "Ten_TTCP", "Ten_TTCP2"), M_Ma_TTCP_H)
            Else
                M_Is_Visible_TTCP = False
            End If

            DsTmp.Dispose()
        End If
    End Sub



#End Region
End Class