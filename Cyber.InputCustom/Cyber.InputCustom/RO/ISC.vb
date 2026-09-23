Imports System.Data.SqlClient
Public Class ISC
#Region "Khai bao bien Property----------------------"
    Dim M_strFilter As String = "1=1"
    Dim M_DrDmct As DataRow
    Dim osysvar As Collection
    Dim M_Para As String() = Me.Para
    Dim M_AppConn As SqlConnection
    Dim M_DsData, M_DsHead, M_DsLookUp As DataSet
    Dim Dt_DetailCv, Dt_DetailCvTmp As New DataTable
    Dim Dv_DetailCv, Dv_DetailCvTmp As New DataView
#End Region
#Region "Khai bao bien Paramater----------------------"
#End Region
#Region "Khai bao bien Dll"
    Dim CyberInput As New Cyber.Input.Sys
    Dim CyberMe As New Cyber.From.Frmvoucher
    Dim CyberFrom As New Cyber.From.Sys
#End Region
#Region "Columns Edit"
    Dim EditMa_Vitri, EditMa_Vt, EditMa_CVVt, EditMa_CtCVVT, EditMa_NVKD, EditTen_Vt, EditTen_Vt3, EditDVt, EditMa_kho_i, EditTon13, EditTen_kho_i, EditMa_TT,
           EditMa_Vv_i, EditMa_Hd_i, EditMa_phi_I, EditMa_Sp_i, EditMa_ku_I, EditMa_TTLN_I, EditMa_TTCP_I, EditMa_BP_I, EditMa_HS_I, EditMa_CD_I As New Cyber.Fill.CyberColumnGridView
    Dim EditSo_Luong, EditTien2, EditTien0, EditGia_TK, EditGia2, EditCk_i,
        EditPt_Ck_i, EditThue_Suat, EditThue, EditTien_BH, EditThue_BH, EditLAN, EditSl_TD_I As New Cyber.Fill.CyberColumnGridView
    Dim Editma_KTV_I, EditMa_TD1_i, EditMa_TD2_i, EditMa_TD3_i, EditMa_TD4_i, EditMa_TD5_i As New Cyber.Fill.CyberColumnGridView
    '-------------------------------------------
    Dim EditMa_CVCv, EditTen_CVCv, EditTIEN_CV0Cv, EditTen_CV3Cv, EditMa_TTCv, EditMa_CtcvCv, EditGia_CVCV, EditGio_TCCV, EditTien_CVCv, EditPT_Ck_ICv, EditCk_ICv, EditThue_SuatCv,
        EditThueCV, EditTien_BHCv, EditThue_BHCv, EditLANCv As New Cyber.Fill.CyberColumnGridView
    Dim EditMa_Hd_iCV, EditMa_Vv_iCV, EditMa_phi_iCV, EditMa_Sp_iCV, EditMa_ku_iCV, EditMa_TTLN_iCV, EditMa_TTCP_iCV, EditMa_BP_iCV, EditMa_HS_iCV, EditMa_CD_iCV As New Cyber.Fill.CyberColumnGridView
    Dim Editma_KTV_ICV, EditMa_TD1_iCV, EditMa_TD2_iCV, EditMa_TD3_iCV, EditMa_TD4_iCV, EditMa_TD5_iCV As New Cyber.Fill.CyberColumnGridView
    '-------------------------------------------
    '---Dieu chinh
    Dim EditDC_I, EditPT_DC_I, EditDC_ICV, EditPT_DC_ICV As New Cyber.Fill.CyberColumnGridView
    Dim EditMa_Ktv_SCV, EditMa_Ktv_SVT As New Cyber.Fill.CyberColumnGridView

    Dim EditSua_Thue, EditSua_ThueCV As New Cyber.Fill.CyberColumnGridView
#End Region
#Region "Khai bao bien Private"
    Dim M_Ct, M_Ph As String
    Dim DrReturn As DataRow
    Dim M_Count As Integer = 1
    Dim DtPost, DtMaGD As DataTable
    Dim M_Ma_TT As String

#End Region
#Region "Khai bao bien Nam - Thang"
    Dim DtThang, DtNam As New DataTable
    Dim _M_Thang_Default As String = Now.Date.Month.ToString.Trim
    Dim _M_Nam_Default As String = Now.Date.Year.ToString.Trim
#End Region
    Private Sub ISC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateTableMonth()
        V_Load()
        V_GetColumn()
        V_AddHandler()
        V_Databing()
        M_Mode = "X"
        M_Count = Dt_Master.Rows.Count
        V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_MainSystem()

        GetRound()
        CmdNew.Select()
    End Sub
    Private Sub CreateTableMonth()

        DtThang.Columns.Add("Thang")
        DtThang.Columns.Add("Ten_Thang")
        DtThang.Columns.Add("Ten_Thang2")
        DtThang.Columns.Add("Default")

        Dim _Thang As String = ""
        Dim _Default As String = "0"

        For i As Integer = 1 To 12
            _Thang = i.ToString.Trim.Trim
            If Now.Date.Month = i Then _Default = "1" Else _Default = "0"
            DtThang.Rows.Add(_Thang.ToString, "Tháng " + _Thang, "Month " + _Thang, _Default)
        Next


        DtNam.Columns.Add("Nam")
        DtNam.Columns.Add("Ten_Nam")
        DtNam.Columns.Add("Ten_Nam2")
        DtNam.Columns.Add("Default")

        Dim _CurYear As Integer = Now.Year

        Dim _Nam As String = ""
        _Default = "0"

        For i As Integer = _CurYear - 10 To _CurYear + 10
            _Nam = Strings.Right("0000" + i.ToString.Trim, 4).Trim
            If Now.Year = i Then _Default = "1" Else _Default = "0"
            DtNam.Rows.Add(_Nam.ToString, "Năm " + _Nam, "Year " + _Nam, _Default)
        Next

        CyberFill.V_FillComBoxDefaul(CbbThang, DtThang, "Thang", IIf(Me.Lan = "V", "Ten_Thang", "Ten_Thang2"), "Default")
        CyberFill.V_FillComBoxDefaul(CbbNam, DtNam, "Nam", IIf(Me.Lan = "V", "Ten_Nam", "Ten_nam2"), "Default")
    End Sub
#Region "Load And Set And Default"
    Private Sub V_Load()
        V_Getdefault()
        ' Vật tư
        Dt_Detail = M_DsData.Tables(0)
        Dt_DetailTmp = Dt_Detail.Clone
        ' Công việc
        Dt_DetailCv = M_DsData.Tables(2)
        Dt_DetailCvTmp = Dt_DetailCv.Clone
        ' Ph
        Dt_Master = M_DsData.Tables(1)
        ' Vật tư
        Dv_Detail = New DataView(Dt_Detail)
        Dv_DetailTmp = New DataView(Dt_DetailTmp)
        ' Công việc
        Dv_DetailCv = New DataView(Dt_DetailCv)
        Dv_DetailCvTmp = New DataView(Dt_DetailCvTmp)
        ' Ph
        Dv_Master = New DataView(Dt_Master)
        '========= FillData to Gridview Vt
        DetailVt.DataSource = Dv_DetailTmp
        Me.DetailGRVVt.GridControl = Me.DetailVt
        CyberFill.V_FillVoucher(DetailGRVVt, M_LAN, New DataView(M_DsHead.Tables(1)), Dv_DetailTmp, Me.DrDmct)
        '========= FillData to Gridview Cv
        DetailCv.DataSource = Dv_DetailCvTmp
        Me.DetailGRVCv.GridControl = Me.DetailCv
        CyberFill.V_FillVoucher(DetailGRVCv, M_LAN, New DataView(M_DsHead.Tables(2)), Dv_DetailCvTmp, Me.DrDmct)
        '=========== FillCombox

        V_SetProperty()
        CyberSupport.Translaste(Me, M_LAN, True)
        ' M_Stt_Rec = CyberFrom.V_ViewVoucher(AppConn, osysvar, M_LAN, M_Para, DrDmct, DsData, DsHead, Dslookup, Dv_Master, Dv_Detail, M_Stt_Rec, strFilter, CyberFill, CyberSmlib, CyberSupport, True, True)
        TxtTy_Gia.InputMask = IIf(DrDmct.Item("M_IP_MK_TG").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TG").ToString.Trim, TxtTy_Gia.InputMask)

        TxtT_SO_LUONG.InputMask = IIf(DrDmct.Item("M_IP_MK_SL").ToString.Trim <> "", DrDmct.Item("M_IP_MK_SL").ToString.Trim, TxtT_SO_LUONG.InputMask)

        TxtT_Tien_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_Tien_NT.InputMask)
        TxtT_Tien.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Tien.InputMask)

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
        'M_Ma_Kx = M_Para(M_VT_PARA + 3).Trim
        'M_Ma_Mau = M_Para(M_VT_PARA + 4).Trim
        'M_MA_TP = M_Para(M_VT_PARA + 5).Trim
        M_Ma_TT = M_Para(M_VT_PARA + 6).Trim
        M_Stt_Rec = M_Para(M_VT_PARA + 7).Trim

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

        DtPost = CyberSmodb.OpenTableKey(AppConn, Nothing, "DmPost", "Ma_Post", "Ma_Ct =N'" + M_Ma_CT + "'", CyberSmlib)
        DtMaGD = CyberSmodb.OpenTableKey(AppConn, Nothing, "DmMaGd", "Ma_GD", "Ma_Ct =N'" + M_Ma_CT + "'", CyberSmlib)
        CyberFill.V_FillComBoxValue(Me.CbbMa_Post, DtPost, "Ma_Post", If(M_LAN = "V", "Ten_Post", "Ten_Post2"), M_Ma_Post)
        CyberFill.V_FillComBoxValue(Me.CbbMa_GD, DtMaGD, "Ma_GD", If(M_LAN = "V", "Ten_GD", "Ten_GD2"), M_Ma_GD)

        V_LoadDefault()
    End Sub
    Private Sub V_SetProperty()
        Me.Mode = M_Mode
        Me.Stt_Rec = M_Stt_Rec
        '---
        Dim FixCol As Integer = -1
        FixCol = DrDmct.Item("ColFrozen_master")
        If FixCol < DetailGRVVt.Columns.Count And FixCol > 0 Then
            For iCol = 0 To FixCol
                DetailGRVVt.Columns(iCol).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Next
        End If
        DetailGRVVt.OptionsNavigation.EnterMoveNextColumn = True
        Me.DetailGRVVt.Appearance.SelectedRow.BackColor = System.Drawing.Color.Brown

        If FixCol < DetailGRVCv.Columns.Count And FixCol > 0 Then
            For iCol = 0 To FixCol
                DetailGRVCv.Columns(iCol).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Next
        End If
        DetailGRVCv.OptionsNavigation.EnterMoveNextColumn = True
        Me.DetailGRVCv.Appearance.SelectedRow.BackColor = System.Drawing.Color.Brown

    End Sub
    Private Sub V_GetColumn()
        EditMa_Vitri.GetColumn(DetailGRVVt, "Ma_vitri")
        EditMa_NVKD.GetColumn(Me.DetailGRVVt, "Ma_NVKD")
        EditMa_Vt.GetColumn(Me.DetailGRVVt, "Ma_Vt")
        EditMa_CVVt.GetColumn(Me.DetailGRVVt, "Ma_CV")
        EditMa_CtCVVT.GetColumn(Me.DetailGRVVt, "Ma_Ctcv")

        EditTen_Vt.GetColumn(Me.DetailGRVVt, "Ten_Vt")
        EditTen_Vt3.GetColumn(Me.DetailGRVVt, "Ten_Vt3")
        EditDVt.GetColumn(Me.DetailGRVVt, "DVT")
        EditTon13.GetColumn(Me.DetailGRVVt, "Ton13")
        EditMa_kho_i.GetColumn(Me.DetailGRVVt, "Ma_kho_I")
        EditTen_kho_i.GetColumn(Me.DetailGRVVt, "Ten_kho_I")
        EditMa_TT.GetColumn(Me.DetailGRVVt, "Ma_TT")

        Editma_KTV_I.GetColumn(DetailGRVVt, "Ma_KTV_I")
        EditMa_Vv_i.GetColumn(DetailGRVVt, "Ma_Vv_I")
        EditMa_phi_I.GetColumn(DetailGRVVt, "Ma_Phi_I")
        EditMa_Hd_i.GetColumn(DetailGRVVt, "Ma_HD_I")
        EditMa_Sp_i.GetColumn(DetailGRVVt, "Ma_SP_I")
        EditMa_ku_I.GetColumn(DetailGRVVt, "Ma_KU_I")
        EditMa_TTLN_I.GetColumn(DetailGRVVt, "Ma_TTLN_I")
        EditMa_TTCP_I.GetColumn(DetailGRVVt, "Ma_TTCP_I")
        EditMa_BP_I.GetColumn(DetailGRVVt, "Ma_BP_I")
        EditMa_HS_I.GetColumn(DetailGRVVt, "Ma_Hs_I")
        EditMa_CD_I.GetColumn(DetailGRVVt, "Ma_CD_I")

        EditMa_TD1_i.GetColumn(DetailGRVVt, "Ma_TD1_I")
        EditMa_TD2_i.GetColumn(DetailGRVVt, "Ma_TD2_I")
        EditMa_TD3_i.GetColumn(DetailGRVVt, "Ma_TD3_I")
        EditMa_TD4_i.GetColumn(DetailGRVVt, "Ma_TD4_I")
        EditMa_TD5_i.GetColumn(DetailGRVVt, "Ma_TD5_I")

        EditSo_Luong.GetColumn(Me.DetailGRVVt, "So_luong")
        EditGia2.GetColumn(Me.DetailGRVVt, "Gia2")
        EditGia_TK.GetColumn(Me.DetailGRVVt, "Gia_Tk")

        EditTien2.GetColumn(Me.DetailGRVVt, "Tien2")
        EditTien0.GetColumn(Me.DetailGRVVt, "Tien0")
        EditCk_i.GetColumn(Me.DetailGRVVt, "Ck_i")
        EditPt_Ck_i.GetColumn(Me.DetailGRVVt, "Pt_Ck_i")
        '---Dieu chinh
        EditDC_I.GetColumn(Me.DetailGRVVt, "Dc_i")
        EditPT_DC_I.GetColumn(Me.DetailGRVVt, "Pt_Dc_i")

        EditThue_Suat.GetColumn(Me.DetailGRVVt, "Thue_Suat")
        EditThue.GetColumn(Me.DetailGRVVt, "Thue")
        EditSua_Thue.GetColumn(Me.DetailGRVVt, "Sua_Thue")

        EditThue_BH.GetColumn(Me.DetailGRVVt, "Thue_BH")
        EditTien_BH.GetColumn(Me.DetailGRVVt, "Tien_BH")

        EditSl_TD_I.GetColumn(Me.DetailGRVVt, "Sl_TD_I")
        EditLAN.GetColumn(Me.DetailGRVVt, "Lan")
        '---------------------------------------------------------------------------------
        ' Cong Viec
        EditMa_CVCv.GetColumn(Me.DetailGRVCv, "Ma_CV")
        EditTen_CVCv.GetColumn(Me.DetailGRVCv, "Ten_Cv")
        EditTIEN_CV0Cv.GetColumn(Me.DetailGRVCv, "Tien_Cv0")

        EditTen_CV3Cv.GetColumn(Me.DetailGRVCv, "Ten_Cv3")
        EditMa_TTCv.GetColumn(Me.DetailGRVCv, "Ma_TT")
        EditMa_CtcvCv.GetColumn(Me.DetailGRVCv, "Ma_Ctcv")

        EditGia_CVCV.GetColumn(Me.DetailGRVCv, "Gia_CV")
        EditGio_TCCV.GetColumn(Me.DetailGRVCv, "Gio_TC")
        EditTien_CVCv.GetColumn(Me.DetailGRVCv, "Tien_CV")

        EditPT_Ck_ICv.GetColumn(Me.DetailGRVCv, "PT_Ck_I")
        EditCk_ICv.GetColumn(Me.DetailGRVCv, "Ck_I")
        EditThueCV.GetColumn(Me.DetailGRVCv, "Thue")
        EditSua_ThueCV.GetColumn(Me.DetailGRVCv, "Sua_Thue")

        '---Dieu chinh
        EditDC_ICV.GetColumn(Me.DetailGRVCv, "Dc_i")
        EditPT_DC_ICV.GetColumn(Me.DetailGRVCv, "Pt_Dc_i")

        EditThue_SuatCv.GetColumn(Me.DetailGRVCv, "Thue_Suat")
        EditThue_BHCv.GetColumn(Me.DetailGRVCv, "Thue_BH")
        EditTien_BHCv.GetColumn(Me.DetailGRVCv, "Tien_BH")



        EditLANCv.GetColumn(Me.DetailGRVCv, "LAN")
        Editma_KTV_ICV.GetColumn(DetailGRVCv, "Ma_KTV_I")
        EditMa_Vv_iCV.GetColumn(DetailGRVCv, "Ma_Vv_I")
        EditMa_phi_iCV.GetColumn(DetailGRVCv, "Ma_Phi_I")
        EditMa_Hd_iCV.GetColumn(DetailGRVCv, "Ma_HD_I")
        EditMa_Sp_iCV.GetColumn(DetailGRVCv, "Ma_SP_I")
        EditMa_ku_iCV.GetColumn(DetailGRVCv, "Ma_KU_I")
        EditMa_TTLN_iCV.GetColumn(DetailGRVCv, "Ma_TTLN_I")
        EditMa_TTCP_iCV.GetColumn(DetailGRVCv, "Ma_TTCP_I")
        EditMa_BP_iCV.GetColumn(DetailGRVCv, "Ma_BP_I")
        EditMa_HS_iCV.GetColumn(DetailGRVCv, "Ma_Hs_I")
        EditMa_CD_iCV.GetColumn(DetailGRVCv, "Ma_CD_I")

        EditMa_TD1_iCV.GetColumn(DetailGRVCv, "Ma_TD1_I")
        EditMa_TD2_iCV.GetColumn(DetailGRVCv, "Ma_TD2_I")
        EditMa_TD3_iCV.GetColumn(DetailGRVCv, "Ma_TD3_I")
        EditMa_TD4_iCV.GetColumn(DetailGRVCv, "Ma_TD4_I")
        EditMa_TD5_iCV.GetColumn(DetailGRVCv, "Ma_TD5_I")

        EditMa_Ktv_SVT.GetColumn(Me.DetailGRVVt, "Ma_KTV_S")
        EditMa_Ktv_SCV.GetColumn(Me.DetailGRVCv, "Ma_KTV_S")

    End Sub
    Private Sub V_SetFocus(ByVal _Loai As String)
        _Loai = _Loai.Trim.ToUpper
        Select Case _Loai
            Case "M"
                TxtNgay_Ct.Focus()
            Case "S"
                TxtNgay_Ct.Focus()
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
        AddHandler DetailGRVVt.PopupMenuShowing, AddressOf MasterGRV_PopupMenuShowing
        AddHandler DetailGRVVt.KeyDown, AddressOf MasterGRV_KeyDown
        '---
        AddHandler DetailGRVCv.PopupMenuShowing, AddressOf MasterGRVCv_PopupMenuShowing
        AddHandler DetailGRVCv.KeyDown, AddressOf MasterGRVCv_KeyDown
        '---
        AddHandler CbbMa_GD.SelectedValueChanged, AddressOf L_Ma_GD
    End Sub
    Private Sub L_Ma_GD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        VisibleColumnMa_GD()
    End Sub
    Private Sub V_AddHandler_Master()
        AddHandler TxtNgay_Ct.Leave, AddressOf V_Ngay_Ct
        AddHandler TxtNgay_LCt.Leave, AddressOf V_Ngay_LCt
        AddHandler txtSo_ct.Enter, AddressOf V_So_Ct
        AddHandler TxtMa_NT.Leave, AddressOf L_Ma_NT
        AddHandler TxtTy_Gia.Leave, AddressOf L_Ty_Gia
        '--KH
        AddHandler TxtMa_Kh.CyberValiting, AddressOf V_Ma_KH
        AddHandler TxtMa_Kh.CyberLeave, AddressOf L_Ma_KH
        AddHandler TxtTen_SC.Leave, AddressOf L_Dia_Chi
        '--Ma_BP_H
        AddHandler TxtMa_Bp_H.CyberValiting, AddressOf V_Ma_BP_H
        AddHandler TxtMa_Bp_H.CyberLeave, AddressOf L_Ma_BP_H
        '--Ma_HS_H
        AddHandler txtMa_HS_H.CyberValiting, AddressOf V_Ma_HS_H
        AddHandler txtMa_HS_H.CyberLeave, AddressOf L_Ma_HS_H

        '----------------------------------------------------------------------------------------------------------
    End Sub
    Private Sub V_AddHandler_Detail()

        EditTen_Vt.ColumnReadOnly = True
        EditDVt.ColumnReadOnly = True
        EditTon13.ColumnReadOnly = True
        EditGia_TK.ColumnReadOnly = True
        EditTen_kho_i.ColumnReadOnly = True
        EditLAN.ColumnReadOnly = True

        If Not EditTen_Vt3.Column Is Nothing Then AddHandler EditTen_Vt3.EditColumn.Leave, AddressOf V_Ten_Vt3

        If Not EditSo_Luong.Column Is Nothing Then AddHandler EditSo_Luong.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        If Not EditGia2.Column Is Nothing Then AddHandler EditGia2.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        If Not EditTien2.Column Is Nothing Then AddHandler EditTien2.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        If Not EditTien0.Column Is Nothing Then AddHandler EditTien0.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        If Not EditPt_Ck_i.Column Is Nothing Then AddHandler EditPt_Ck_i.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        If Not EditCk_i.Column Is Nothing Then AddHandler EditCk_i.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        '---Dieu chinh
        If Not EditPT_DC_I.Column Is Nothing Then AddHandler EditPT_DC_I.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        If Not EditDC_I.Column Is Nothing Then AddHandler EditDC_I.EditColumn.Leave, AddressOf V_Tinh_ToanPT

        If Not EditThue_Suat.Column Is Nothing Then AddHandler EditThue_Suat.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        If Not EditSua_Thue.Column Is Nothing Then AddHandler EditSua_Thue.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        If Not EditThue.Column Is Nothing Then AddHandler EditThue.EditColumn.Leave, AddressOf V_Tinh_ToanPT


        If Not EditThue_BH.Column Is Nothing Then AddHandler EditThue_BH.EditColumn.Leave, AddressOf V_Tinh_ToanPT
        If Not EditTien_BH.Column Is Nothing Then AddHandler EditTien_BH.EditColumn.Leave, AddressOf V_Tinh_ToanPT

        EditMa_Vitri.V_ActiLookUpColumn(AddressOf V_Ma_Vitri, AddressOf L_Ma_Vitri)
        EditMa_NVKD.V_ActiLookUpColumn(AddressOf V_Ma_NVKD, AddressOf L_Ma_NVKD)
        EditMa_Vt.V_ActiLookUpColumn(AddressOf V_Ma_Vt, AddressOf L_Ma_Vt)

        EditMa_CVVt.V_ActiLookUpColumn(AddressOf V_Ma_CvVt, AddressOf L_Ma_CvVt)
        EditMa_CtCVVT.V_ActiLookUpColumn(AddressOf V_Ma_CtCvVT, AddressOf L_Ma_CtCvVT)
        EditMa_TT.V_ActiLookUpColumn(AddressOf V_Ma_TT, AddressOf L_Ma_TT)

        EditMa_kho_i.V_ActiLookUpColumn(AddressOf V_Ma_Kho_i, AddressOf L_Ma_Kho_i)



        '---Add On
        EditMa_Vv_i.V_ActiLookUpColumn(AddressOf V_Ma_Vv_i, AddressOf L_Ma_Vv_i)
        EditMa_phi_I.V_ActiLookUpColumn(AddressOf V_Ma_Phi_i, AddressOf L_Ma_Phi_i)
        EditMa_Hd_i.V_ActiLookUpColumn(AddressOf V_Ma_HD_i, AddressOf L_Ma_HD_i)
        EditMa_Sp_i.V_ActiLookUpColumn(AddressOf V_Ma_SP_i, AddressOf L_Ma_SP_i)
        EditMa_ku_I.V_ActiLookUpColumn(AddressOf V_Ma_KU_i, AddressOf L_Ma_KU_i)
        EditMa_TTLN_I.V_ActiLookUpColumn(AddressOf V_Ma_TTLN_i, AddressOf L_Ma_TTLN_i)
        EditMa_TTCP_I.V_ActiLookUpColumn(AddressOf V_Ma_TTCP_i, AddressOf L_Ma_TTCP_i)
        EditMa_BP_I.V_ActiLookUpColumn(AddressOf V_Ma_Bp_i, AddressOf L_Ma_Bp_i)
        EditMa_HS_I.V_ActiLookUpColumn(AddressOf V_Ma_HS_i, AddressOf L_Ma_HS_i)
        EditMa_CD_I.V_ActiLookUpColumn(AddressOf V_Ma_CD_i, AddressOf L_Ma_CD_i)
        EditMa_TD1_i.V_ActiLookUpColumn(AddressOf V_Ma_TD1_i, AddressOf L_Ma_TD1_i)
        EditMa_TD2_i.V_ActiLookUpColumn(AddressOf V_Ma_TD2_i, AddressOf L_Ma_TD2_i)
        EditMa_TD3_i.V_ActiLookUpColumn(AddressOf V_Ma_TD3_i, AddressOf L_Ma_TD3_i)
        EditMa_TD4_i.V_ActiLookUpColumn(AddressOf V_Ma_TD4_i, AddressOf L_Ma_TD4_i)
        EditMa_TD5_i.V_ActiLookUpColumn(AddressOf V_Ma_TD5_i, AddressOf L_Ma_TD5_i)

        '================== Coong viec
        EditTen_CVCv.ColumnReadOnly = True
        EditLANCv.ColumnReadOnly = True

        If Not EditGia_CVCV.Column Is Nothing Then AddHandler EditGia_CVCV.EditColumn.Leave, AddressOf V_Tinh_ToanCV
        If Not EditGio_TCCV.Column Is Nothing Then AddHandler EditGio_TCCV.EditColumn.Leave, AddressOf V_Tinh_ToanCV
        If Not EditTien_CVCv.Column Is Nothing Then AddHandler EditTien_CVCv.EditColumn.Leave, AddressOf V_Tinh_ToanCV
        If Not EditTIEN_CV0Cv.Column Is Nothing Then AddHandler EditTIEN_CV0Cv.EditColumn.Leave, AddressOf V_Tinh_ToanCV

        If Not EditPT_Ck_ICv.Column Is Nothing Then AddHandler EditPT_Ck_ICv.EditColumn.Leave, AddressOf V_Tinh_ToanCV
        If Not EditCk_ICv.Column Is Nothing Then AddHandler EditCk_ICv.EditColumn.Leave, AddressOf V_Tinh_ToanCV

        '---Dieu chinh
        If Not EditPT_DC_ICV.Column Is Nothing Then AddHandler EditPT_DC_ICV.EditColumn.Leave, AddressOf V_Tinh_ToanCV
        If Not EditDC_ICV.Column Is Nothing Then AddHandler EditDC_ICV.EditColumn.Leave, AddressOf V_Tinh_ToanCV

        If Not EditThue_SuatCv.Column Is Nothing Then AddHandler EditThue_SuatCv.EditColumn.Leave, AddressOf V_Tinh_ToanCV
        If Not EditThueCV.Column Is Nothing Then AddHandler EditThueCV.EditColumn.Leave, AddressOf V_Tinh_ToanCV
        If Not EditSua_ThueCV.Column Is Nothing Then AddHandler EditSua_ThueCV.EditColumn.Leave, AddressOf V_Tinh_ToanCV

        If Not EditThue_BHCv.Column Is Nothing Then AddHandler EditThue_BHCv.EditColumn.Leave, AddressOf V_Tinh_ToanCV
        If Not EditTien_BHCv.Column Is Nothing Then AddHandler EditThue_BHCv.EditColumn.Leave, AddressOf V_Tinh_ToanCV




        EditMa_CVCv.V_ActiLookUpColumn(AddressOf V_Ma_Cv, AddressOf L_Ma_Cv)
        EditMa_CtcvCv.V_ActiLookUpColumn(AddressOf V_Ma_CtCv, AddressOf L_Ma_CtCv)
        EditMa_TTCv.V_ActiLookUpColumn(AddressOf V_Ma_TTCV, AddressOf L_Ma_TTCV)

        Editma_KTV_ICV.V_ActiLookUpColumn(AddressOf V_Ma_KTV_ICV, AddressOf L_Ma_KTV_ICV)
        EditMa_Vv_iCV.V_ActiLookUpColumn(AddressOf V_Ma_Vv_iCV, AddressOf L_Ma_Vv_iCV)
        EditMa_phi_iCV.V_ActiLookUpColumn(AddressOf V_Ma_Phi_iCV, AddressOf L_Ma_Phi_iCV)
        EditMa_Hd_iCV.V_ActiLookUpColumn(AddressOf V_Ma_HD_iCV, AddressOf L_Ma_HD_iCV)
        EditMa_Sp_iCV.V_ActiLookUpColumn(AddressOf V_Ma_SP_iCV, AddressOf L_Ma_SP_iCV)
        EditMa_ku_iCV.V_ActiLookUpColumn(AddressOf V_Ma_KU_iCV, AddressOf L_Ma_KU_iCV)
        EditMa_TTLN_iCV.V_ActiLookUpColumn(AddressOf V_Ma_TTLN_iCV, AddressOf L_Ma_TTLN_iCV)
        EditMa_TTCP_iCV.V_ActiLookUpColumn(AddressOf V_Ma_TTCP_iCV, AddressOf L_Ma_TTCP_iCV)
        EditMa_BP_iCV.V_ActiLookUpColumn(AddressOf V_Ma_Bp_iCV, AddressOf L_Ma_Bp_iCV)
        EditMa_HS_iCV.V_ActiLookUpColumn(AddressOf V_Ma_HS_iCV, AddressOf L_Ma_HS_iCV)
        EditMa_CD_iCV.V_ActiLookUpColumn(AddressOf V_Ma_CD_iCV, AddressOf L_Ma_CD_iCV)
        EditMa_TD1_iCV.V_ActiLookUpColumn(AddressOf V_Ma_TD1_iCV, AddressOf L_Ma_TD1_iCV)
        EditMa_TD2_iCV.V_ActiLookUpColumn(AddressOf V_Ma_TD2_iCV, AddressOf L_Ma_TD2_iCV)
        EditMa_TD3_iCV.V_ActiLookUpColumn(AddressOf V_Ma_TD3_iCV, AddressOf L_Ma_TD3_iCV)
        EditMa_TD4_iCV.V_ActiLookUpColumn(AddressOf V_Ma_TD4_iCV, AddressOf L_Ma_TD4_iCV)
        EditMa_TD5_iCV.V_ActiLookUpColumn(AddressOf V_Ma_TD5_iCV, AddressOf L_Ma_TD5_iCV)

        AddHandler DetailGRVVt.RowCellStyle, AddressOf DetailGRVVT_RowCellStyle
        AddHandler DetailGRVCv.RowCellStyle, AddressOf DetailGRVCV_RowCellStyle
    End Sub
    Dim CyberColor As New Cyber.Color.Sys
    Private Sub DetailGRVVT_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        CyberSupport.DetailGRV_RowCellStyle2(sender, e, DetailGRVVt, Dt_DetailTmp, Me.Font, "Bold", "BackColor", "BackColor2", "Forecolor", "Underline", "Italic", CyberColor)
    End Sub
    Private Sub DetailGRVCV_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        CyberSupport.DetailGRV_RowCellStyle2(sender, e, DetailGRVCv, Dt_DetailCvTmp, Me.Font, "Bold", "BackColor", "BackColor2", "Forecolor", "Underline", "Italic", CyberColor)
    End Sub

    Private Sub VisibleColumnMa_NT()

        CyberFill.SetFoCusGRV(DetailGRVVt, M_Mode)
    End Sub

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
        If TxtMa_NT.Text.Trim = "" Then TxtMa_NT.Text = osysvar("M_Ma_NT0").ToString.Trim.ToUpper
        UpdateList()
        VisibleColumnMa_NT()
        VisibleColumnMa_GD()
    End Sub
    Private Sub V_Setstatus()
        If (M_Mode = "M" Or M_Mode = "S") Then
            DetailGRVVt.OptionsBehavior.ReadOnly = False
            If DrDmct.Item("M_Ngay_LCT").ToString.Trim = "1" Then TxtNgay_LCt.ReadOnly = False Else TxtNgay_LCt.ReadOnly = True 'Ngay chu tu nhap: vao hoac tu dong lay theo may chu
            If DrDmct.Item("M_Ngay_CT").ToString.Trim = "1" Then TxtNgay_Ct.ReadOnly = True Else TxtNgay_Ct.ReadOnly = False 'Ngay chu tu nhap: vao hoac tu dong lay theo may chu
            If DrDmct.Item("M_Au_So_CT").ToString.Trim = "1" Then txtSo_ct.ReadOnly = True Else txtSo_ct.ReadOnly = False 'Tu dong danh so chung tu
        Else
            DetailGRVVt.OptionsBehavior.ReadOnly = True
        End If
        If M_Mode = "S" Then CbbMa_GD.Enabled = False
        If M_Mode = "M" Then CbbMa_GD.Enabled = True
        CyberFill.SetFoCusGRV(DetailGRVVt, M_Mode)
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
        If Not DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" And txtSo_ct.Text.Trim <> "" Then Exit Sub
        If Not txtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        txtSo_ct.Text = CyberSupport.V_GetNoVoucherAuto(M_Mode, txtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
#End Region
#Region "Valid - Master"
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
            TxtTen_SC.Text = IIf(TxtTen_SC.Text.Trim = "", DrReturn.Item("Dia_Chi"), TxtTen_SC.Text)
        Else
            TxtMa_Kh.Text = ""
            TxtTen_kh.Text = ""

        End If
        If TxtMa_Kh.Text = "" Then
            TxtTen_kh.Text = ""
            TxtTen_SC.Text = ""
            Exit Sub
        End If
    End Sub
    Private Sub L_Dia_Chi(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        TxtTen_SC.Text = CyberInput.GetDia_Chi(TxtMa_Kh.Text, TxtTen_SC.Text, M_Ma_CT, M_Mode, AppConn, CyberSmlib, CyberSmodb)
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
#End Region
#Region "Valid - Detail"
#Region "Valid - Detail - Core"
    Private Sub UpdateList()
        Dim i As Integer
        Dim nT_So_Luong As Decimal = 0

        Dim nT_Tien2 As Decimal = 0
        Dim nT_CV As Decimal = 0
        Dim nT_Thue_VT As Decimal = 0
        Dim nT_Thue_CV As Decimal = 0

        Dim nT_Ck_VT As Decimal = 0
        Dim nT_Ck_CV As Decimal = 0
        '---Dieu chinh
        Dim nT_DC_VT As Decimal = 0
        Dim nT_DC_CV As Decimal = 0

        Dim nT_I As Decimal = 0
        Dim nT_W As Decimal = 0
        Dim nT_N As Decimal = 0
        Dim nT_C As Decimal = 0

        For i = 0 To Dt_DetailTmp.Rows.Count - 1
            If Dt_DetailTmp.Rows(i).RowState = DataRowState.Deleted Then
                Continue For
            End If

            If Dt_DetailTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "I" Then
                nT_I = nT_I + Dt_DetailTmp.Rows(i).Item("Tien2") - Dt_DetailTmp.Rows(i).Item("CK_I") + Dt_DetailTmp.Rows(i).Item("Thue") + Dt_DetailTmp.Rows(i).Item("Dc_I")
            End If
            If Dt_DetailTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "W" Then
                nT_W = nT_W + Dt_DetailTmp.Rows(i).Item("Tien2") - Dt_DetailTmp.Rows(i).Item("CK_I") + Dt_DetailTmp.Rows(i).Item("Thue") + Dt_DetailTmp.Rows(i).Item("Dc_I")
            End If

            If Not (Dt_DetailTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "W" Or Dt_DetailTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "I" Or Dt_DetailTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "C") Then
                nT_N = nT_N + Dt_DetailTmp.Rows(i).Item("Tien2") - Dt_DetailTmp.Rows(i).Item("CK_I") + Dt_DetailTmp.Rows(i).Item("Thue") + Dt_DetailTmp.Rows(i).Item("Dc_I")
            End If

            nT_Ck_VT = nT_Ck_VT + Dt_DetailTmp.Rows(i).Item("Ck_I")
            nT_So_Luong = nT_So_Luong + Dt_DetailTmp.Rows(i).Item("So_Luong")
            nT_Tien2 = nT_Tien2 + Dt_DetailTmp.Rows(i).Item("Tien2")
            nT_Thue_VT = nT_Thue_VT + Dt_DetailTmp.Rows(i).Item("Thue")
            nT_DC_VT = nT_DC_VT + Dt_DetailTmp.Rows(i).Item("Dc_I")
        Next
        '----------------------------------------------------------------------------
        TxtT_SO_LUONG.Double = nT_So_Luong
        '----------------------------------------------------------------------------
        For i = 0 To Dt_DetailCvTmp.Rows.Count - 1
            If Dt_DetailCvTmp.Rows(i).RowState = DataRowState.Deleted Then Continue For

            If Dt_DetailCvTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "I" Then
                nT_I = nT_I + Dt_DetailCvTmp.Rows(i).Item("Tien_CV") - Dt_DetailCvTmp.Rows(i).Item("CK_I") + Dt_DetailCvTmp.Rows(i).Item("Thue") + Dt_DetailCvTmp.Rows(i).Item("Dc_I")
            End If

            If Dt_DetailCvTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "W" Then
                nT_W = nT_W + Dt_DetailCvTmp.Rows(i).Item("Tien_CV") - Dt_DetailCvTmp.Rows(i).Item("CK_I") + Dt_DetailCvTmp.Rows(i).Item("Thue") + Dt_DetailCvTmp.Rows(i).Item("Dc_I")
            End If

            If Not (Dt_DetailCvTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "W" Or Dt_DetailCvTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "I" Or Dt_DetailCvTmp.Rows(i).Item("Ma_TT").ToString.Trim.ToUpper = "C") Then
                nT_N = nT_N + Dt_DetailCvTmp.Rows(i).Item("Tien_CV") - Dt_DetailCvTmp.Rows(i).Item("CK_I") + Dt_DetailCvTmp.Rows(i).Item("Thue") + Dt_DetailCvTmp.Rows(i).Item("Dc_I")
            End If

            nT_Ck_CV = nT_Ck_CV + Dt_DetailCvTmp.Rows(i).Item("Ck_I")
            nT_CV = nT_CV + Dt_DetailCvTmp.Rows(i).Item("Tien_CV")
            nT_Thue_CV = nT_Thue_CV + Dt_DetailCvTmp.Rows(i).Item("Thue")
            nT_DC_CV = nT_DC_CV + Dt_DetailCvTmp.Rows(i).Item("Dc_I")
        Next
    End Sub
    Private Sub V_Tinh_Toan(ByVal iRow As Integer)

    End Sub
    Private Sub L_Tinh_Toan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DetailGRVVt.PostEditor()
        Dim drvCurren As DataRowView
        drvCurren = DetailGRVVt.GetFocusedRow
        CyberSupport.V_UpdateGRV(DetailGRVVt)
        V_Tinh_Toan(iRow)
    End Sub

    Private Sub V_Ma_kh_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_kh_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_kh_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_kh_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub E_Dien_Giaii(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M") Then Exit Sub
        'If Not (M_Mode = "M" Or M_Mode = "S") And (M_Is_Delete = "X") Then Exit Sub
        Dim iRow As Integer = DetailGRVVt.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Dv_DetailTmp.Item(iRow).Item("Dien_Giaii").ToString.Trim = "" Then
            Dv_DetailTmp.Item(iRow).BeginEdit()
            Dv_DetailTmp.Item(iRow).Item("Dien_Giaii") = txtDien_giai.Text
            Dv_DetailTmp.Item(iRow).EndEdit()
        End If
        DetailGRVVt.ShowEditor()

    End Sub
#End Region

#Region "Ma_CtCvVT"
    Private Sub V_Ma_CtCvVT(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Lookup("Ma_CtCv", "DmCtCv", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_CtCvVT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailTmp.Item(iRow)("Ma_CtCv") = ""
            Exit Sub
        End If
        Dv_DetailTmp.Item(iRow).BeginEdit()
        Dv_DetailTmp.Item(iRow).Item("Ma_CtCv") = DrReturn("Ma_CtCv").ToString.Trim
        'Dv_DetailTmp.Item(iRow).Item("Thue_Suat") = IIf(Dv_DetailTmp.Item(iRow).Item("Thue_Suat") <> 0, Dv_DetailTmp.Item(iRow).Item("Thue_Suat"), DrReturn("Thue_Suat"))
        'Dv_DetailTmp.Item(iRow).Item("Tien_CV") = IIf(Dv_DetailTmp.Item(iRow).Item("Tien_CV") <> 0, Dv_DetailTmp.Item(iRow).Item("Tien_CV"), DrReturn("Tien_CV"))
        Dv_DetailTmp.Item(iRow).EndEdit()
        DetailGRVVt.UpdateCurrentRow()
    End Sub
#End Region

#Region "Ma_CvVt"
    Private Sub V_Ma_CvVt(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Lookup("Ma_Cv", "DmCv", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_CvVt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailTmp.Item(iRow)("Ma_Cv") = ""
            Exit Sub
        End If
        Dv_DetailTmp.Item(iRow).BeginEdit()
        Dv_DetailTmp.Item(iRow).Item("Ma_Cv") = DrReturn("Ma_Cv").ToString.Trim
        Dv_DetailTmp.Item(iRow).EndEdit()
        DetailGRVVt.UpdateCurrentRow()
    End Sub
#End Region


#Region "Vat tu kho/Vitri - "
    Private Sub V_Ma_Lo(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Lo(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Lo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Lo(M_Mode, M_Ma_CT, sender, DetailGRVVt)
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        V_SetSD(iRow)
    End Sub
    Private Sub V_Ma_Vt(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vt(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        DrReturn = Nothing
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailTmp.Item(iRow).BeginEdit()
            Dv_DetailTmp.Item(iRow)("Ma_vt") = ""
            Dv_DetailTmp.Item(iRow).Item("Ten_VT") = ""
            Dv_DetailTmp.Item(iRow).Item("Ten_VT3") = ""
            Dv_DetailTmp.Item(iRow).Item("Dvt") = ""
            Dv_DetailTmp.Item(iRow).EndEdit()
            Exit Sub
        End If
        Dim _Ma_kho_i As String = "", _Ma_VT As String = "", _DVT As String = "", _Ten_VT As String = "", _Thue_Suat As Decimal = 0
        Dim _Gia2 As Decimal = 0
        _Ma_VT = DrReturn("Ma_vt").ToString.Trim
        _Ten_VT = DrReturn("Ten_VT").ToString.Trim
        _DVT = DrReturn("DVT").ToString.Trim
        _Ma_kho_i = DrReturn("Ma_kho").ToString.Trim
        _Thue_Suat = DrReturn("Thue_Suat").ToString.Trim
        '-----------------------------------------------------------------------------------------------------------
        Dv_DetailTmp.Item(iRow).BeginEdit()
        Dv_DetailTmp.Item(iRow).Item("Ma_Vt") = _Ma_VT
        Dv_DetailTmp.Item(iRow).Item("Ten_vt") = _Ten_VT
        Dv_DetailTmp.Item(iRow).Item("DVT") = _DVT
        Dv_DetailTmp.Item(iRow).Item("Ma_TT") = IIf(Dv_DetailTmp.Item(iRow).Item("Ma_TT").ToString.Trim <> "", Dv_DetailTmp.Item(iRow).Item("Ma_TT"), M_Ma_TT)
        Dv_DetailTmp.Item(iRow).Item("Ma_kho_i") = IIf(Dv_DetailTmp.Item(iRow).Item("Ma_kho_i").ToString.Trim = "", _Ma_kho_i, Dv_DetailTmp.Item(iRow).Item("Ma_kho_i"))
        Dv_DetailTmp.Item(iRow).Item("Thue_Suat") = IIf(Dv_DetailTmp.Item(iRow).Item("Thue_Suat") = 0, _Thue_Suat, Dv_DetailTmp.Item(iRow).Item("Thue_Suat"))
        Dv_DetailTmp.Item(iRow).EndEdit()
        '-----------------------------------------------------------------------------------------------------------
        If Dv_DetailTmp.Item(iRow).Item("Ten_vt3").ToString.Trim = "" Then
            Dv_DetailTmp.Item(iRow).BeginEdit()
            Dv_DetailTmp.Item(iRow).Item("Ten_vt3") = _Ten_VT
            Dv_DetailTmp.Item(iRow).EndEdit()
        End If
        '-----------------------------------------------------------------------------------------------------------
        Tinh_Gia2(iRow)
        Tinh_TienPT(iRow)
        UpdateList()
        '-----------------------------------------------------------------------------------------------------------
        V_SetSD(iRow)
        DetailGRVVt.UpdateCurrentRow()
    End Sub
    Private Sub V_Ma_Kho_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Kho_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Kho_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Kho_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        V_SetSD(iRow)
    End Sub
    Private Sub V_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vitri(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vitri(M_Mode, M_Ma_CT, sender, DetailGRVVt)
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        V_SetSD(iRow)
    End Sub

    Private Sub V_Ma_NVKD(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Lookup("MD_HS", "DmHs", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_NVKD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailTmp.Item(iRow)("Ma_NVKD") = ""
            Exit Sub
        Else
            Dv_DetailTmp.Item(iRow)("Ma_NVKD") = DrReturn("MD_HS")
        End If
        Dt_DetailTmp.AcceptChanges()
        DetailGRVVt.UpdateCurrentRow()
    End Sub


    Private Sub V_SetSD(ByVal iRow As Integer)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If iRow < 0 Then Exit Sub
        Dim _Ma_Vt As String = Dv_DetailTmp.Item(iRow).Item("Ma_Vt").ToString.Trim
        Dim _Ma_kho As String = Dv_DetailTmp.Item(iRow).Item("Ma_Kho_I").ToString.Trim
        Dim _Ma_Vitri As String = If(Dv_DetailTmp.Table.Columns.Contains("Ma_Vitri"), Dv_DetailTmp.Item(iRow).Item("Ma_Vitri").ToString.Trim, "")
        Dim _Ma_Lo As String = If(Dt_DetailTmp.Columns.Contains("Ma_Lo"), Dv_DetailTmp.Item(iRow).Item("Ma_lo").ToString.Trim, "")
        Dim _Return As DataRow = CyberSupport.V_SetSD(StatusFooter1, AppConn, "VT", M_Mode, _Ma_Vt, _Ma_kho, _Ma_Vitri, _Ma_Lo, M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
        If Dv_DetailTmp.Table.Columns.Contains("Ton13") Then
            Dv_DetailTmp.Item(iRow).BeginEdit()
            If Dt_DetailTmp.Columns.Contains("Ton13") Then Dv_DetailTmp.Item(iRow).Item("Ton13") = If(_Return Is Nothing, 0, _Return("SL"))
            If Not _Return Is Nothing Then If Dt_DetailTmp.Columns.Contains("ma_Vitri") And _Return.Table.Columns.Contains("ma_Vitri") Then Dv_DetailTmp.Item(iRow).Item("ma_Vitri") = _Return("ma_Vitri")
            If Not _Return Is Nothing Then If Dt_DetailTmp.Columns.Contains("BackColor") And _Return.Table.Columns.Contains("BackColor") Then Dv_DetailTmp.Item(iRow).Item("BackColor") = _Return.Item("BackColor")
            If Not _Return Is Nothing Then If Dt_DetailTmp.Columns.Contains("BackColor2") And _Return.Table.Columns.Contains("BackColor2") Then Dv_DetailTmp.Item(iRow).Item("BackColor2") = _Return.Item("BackColor2")
            If Not _Return Is Nothing Then If Dt_DetailTmp.Columns.Contains("ForeColor") And _Return.Table.Columns.Contains("ForeColor") Then Dv_DetailTmp.Item(iRow).Item("ForeColor") = _Return.Item("ForeColor")
            If Not _Return Is Nothing Then If Dt_DetailTmp.Columns.Contains("Bold") And _Return.Table.Columns.Contains("Bold") Then Dv_DetailTmp.Item(iRow).Item("Bold") = _Return.Item("Bold")
            If Not _Return Is Nothing Then If Dt_DetailTmp.Columns.Contains("Underline") And _Return.Table.Columns.Contains("Underline") Then Dv_DetailTmp.Item(iRow).Item("Underline") = _Return.Item("Underline")
            If Not _Return Is Nothing Then If Dt_DetailTmp.Columns.Contains("Italic") And _Return.Table.Columns.Contains("Italic") Then Dv_DetailTmp.Item(iRow).Item("Italic") = _Return.Item("Italic")

            Dv_DetailTmp.Item(iRow).EndEdit()
        End If
    End Sub
#Region "Tinh toan PT"
    Private Sub V_Tinh_ToanPT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode.Trim = "M" Or M_Mode.Trim = "S") Then Exit Sub
        DetailGRVVt.PostEditor()
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dt_DetailTmp.AcceptChanges()
        Tinh_TienPT(iRow)
    End Sub
    Private Sub Tinh_TienPT(ByVal iRow As Integer)
        If iRow < 0 Then Exit Sub
        Dim nTy_Gia As Decimal = 0
        If TxtTy_Gia.Text.Trim = "0" Or TxtTy_Gia.Text.Trim = "" Or TxtMa_NT.Text.Trim = osysvar("M_Ma_Nt0").ToString.Trim Then
            TxtTy_Gia.Text = 1
            TxtTy_Gia.Refresh()
        End If
        nTy_Gia = CType(TxtTy_Gia.Text.Replace(" ", ""), Decimal)
        nTy_Gia = 1

        'Thanh Tien---------------------------------------------------------------------------------------
        Dv_DetailTmp.Item(iRow).BeginEdit()
        If Dv_DetailTmp.Item(iRow).Item("So_luong") * Dv_DetailTmp.Item(iRow).Item("Gia2") <> 0 Then
            Dv_DetailTmp.Item(iRow).Item("Tien2") = CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("So_luong") * Dv_DetailTmp.Item(iRow).Item("Gia2"), 0)
        End If
        Dv_DetailTmp.Item(iRow).EndEdit()
        '-------------------------------------------------------------------------------------------------

        'Chiet Khau---------------------------------------------------------------------------------------
        Dv_DetailTmp.Item(iRow).BeginEdit()
        If CyberSupport.ChkFieldKey(Dv_DetailTmp.Item(iRow).Item("Ma_TT"), "I,C") Then
            Dv_DetailTmp.Item(iRow).Item("CK_I") = IIf(Dv_DetailTmp.Item(iRow).Item("PT_Ck_I") = 0, Dv_DetailTmp.Item(iRow).Item("CK_I"),
                     CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("Tien2") * Dv_DetailTmp.Item(iRow).Item("PT_Ck_I") / 100, 0))
        Else
            Dv_DetailTmp.Item(iRow).Item("PT_Ck_I") = 0
            Dv_DetailTmp.Item(iRow).Item("CK_I") = 0
        End If
        Dv_DetailTmp.Item(iRow).EndEdit()


        '---Dieu chinh
        Dv_DetailTmp.Item(iRow).BeginEdit()
        Dv_DetailTmp.Item(iRow).Item("DC_I") = IIf(Dv_DetailTmp.Item(iRow).Item("PT_DC_I") = 0, Dv_DetailTmp.Item(iRow).Item("DC_I"), CyberSupport.V_Round((Dv_DetailTmp.Item(iRow).Item("Tien2") - Dv_DetailTmp.Item(iRow).Item("CK_I")) * Dv_DetailTmp.Item(iRow).Item("PT_DC_I") / 100, 0))
        Dv_DetailTmp.Item(iRow).EndEdit()
        '----------------------------- Thue,Tien0
        TinhThue_VT(iRow)
        '-----------------------------
        UpdateList()
    End Sub
    Private Sub TinhThue_VT(ByVal iRow As Integer)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub

        Dv_DetailTmp.Item(iRow).BeginEdit()
        If Dt_DetailTmp.Columns.Contains("Sua_Thue") Then
            If Dv_DetailTmp.Item(iRow).Item("Sua_Thue").ToString.Trim <> "1" Then
                Dv_DetailTmp.Item(iRow).Item("Thue") = Math.Round((Dv_DetailTmp.Item(iRow).Item("Tien2") - Dv_DetailTmp.Item(iRow).Item("CK_I") + Dv_DetailTmp.Item(iRow).Item("DC_I")) * Dv_DetailTmp.Item(iRow).Item("Thue_Suat") / 100, 0, MidpointRounding.AwayFromZero)
                'Else
                '    Dv_DetailTmp.Item(iRow).Item("Thue") = Math.Round((Dv_DetailTmp.Item(iRow).Item("Tien2") - Dv_DetailTmp.Item(iRow).Item("CK_I") + Dv_DetailTmp.Item(iRow).Item("DC_I")) * Dv_DetailTmp.Item(iRow).Item("Thue_Suat") / 100, 0, MidpointRounding.AwayFromZero)
            End If
        Else
            Dv_DetailTmp.Item(iRow).Item("Thue") = Math.Round((Dv_DetailTmp.Item(iRow).Item("Tien2") - Dv_DetailTmp.Item(iRow).Item("CK_I") + Dv_DetailTmp.Item(iRow).Item("DC_I")) * Dv_DetailTmp.Item(iRow).Item("Thue_Suat") / 100, 0, MidpointRounding.AwayFromZero)
        End If

        If Dt_DetailTmp.Columns.Contains("Tien0") Then Dv_DetailTmp.Item(iRow).Item("Tien0") = Dv_DetailTmp.Item(iRow).Item("Tien2") - Dv_DetailTmp.Item(iRow).Item("CK_I") + Dv_DetailTmp.Item(iRow).Item("DC_I")
        Dv_DetailTmp.Item(iRow).EndEdit()

    End Sub

#End Region

    Private Sub V_Ten_Vt3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dt_DetailTmp.AcceptChanges()
        If Dt_DetailTmp.Rows(iRow).Item("Ten_vt3").ToString.Trim = "" Then
            Dt_DetailTmp.Rows(iRow).BeginEdit()
            Dt_DetailTmp.Rows(iRow).Item("Ten_vt3") = Dt_DetailTmp.Rows(iRow).Item("Ten_vt")
            Dt_DetailTmp.Rows(iRow).EndEdit()
        End If
        Dt_DetailTmp.AcceptChanges()
        DetailGRVVt.UpdateCurrentRow()
    End Sub



#Region "Tinh toan CV"
    Private Sub V_Tinh_ToanCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode.Trim = "M" Or M_Mode.Trim = "S") Then Exit Sub
        DetailGRVCv.PostEditor()
        Dim iRow As Integer = -1
        iRow = DetailGRVCv.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dt_DetailCvTmp.AcceptChanges()
        Tinh_TienCV(iRow)
    End Sub
    Private Sub Tinh_TienCV(ByVal iRow As Integer)
        If Not (M_Mode.Trim = "M" Or M_Mode.Trim = "S") Then Exit Sub
        If iRow < 0 Then Exit Sub
        Dim nTy_Gia As Decimal = 0
        If TxtTy_Gia.Text.Trim = "0" Or TxtTy_Gia.Text.Trim = "" Or TxtMa_NT.Text.Trim = osysvar("M_Ma_Nt0").ToString.Trim Then
            TxtTy_Gia.Text = 1
            TxtTy_Gia.Refresh()
        End If
        nTy_Gia = CType(TxtTy_Gia.Text.Replace(" ", ""), Decimal)
        nTy_Gia = 1
        'Tinh Tiền Cong viec ---------------------------------------------------------------------------------------
        If Dv_DetailCvTmp.Item(iRow).Item("Gia_CV") * Dv_DetailCvTmp.Item(iRow).Item("Gio_TC") <> 0 Then
            Dv_DetailCvTmp.Item(iRow).BeginEdit()
            Dv_DetailCvTmp.Item(iRow).Item("Tien_CV") = CyberSupport.V_Round(Dv_DetailCvTmp.Item(iRow).Item("Gia_CV") * Dv_DetailCvTmp.Item(iRow).Item("Gio_TC"), 0)
            Dv_DetailCvTmp.Item(iRow).EndEdit()
        End If
        'Chiet Khau---------------------------------------------------------------------------------------
        '--------- Tinh Chiet Khau
        Dv_DetailCvTmp.Item(iRow).BeginEdit()
        If CyberSupport.ChkFieldKey(Dv_DetailCvTmp.Item(iRow).Item("Ma_TT"), "I,C") Then
            Dv_DetailCvTmp.Item(iRow).Item("Ck_I") = IIf(Dv_DetailCvTmp.Item(iRow).Item("PT_Ck_I") = 0, Dv_DetailCvTmp.Item(iRow).Item("Ck_I"), CyberSupport.V_Round(Dv_DetailCvTmp.Item(iRow).Item("Tien_Cv") * Dv_DetailCvTmp.Item(iRow).Item("PT_Ck_I") / 100, 0))
        Else
            Dv_DetailCvTmp.Item(iRow).Item("PT_Ck_I") = 0
            Dv_DetailCvTmp.Item(iRow).Item("Ck_I") = 0
        End If
        Dv_DetailCvTmp.Item(iRow).EndEdit()


        '---Dieu chinh
        Dv_DetailCvTmp.Item(iRow).BeginEdit()
        Dv_DetailCvTmp.Item(iRow).Item("DC_I") = IIf(Dv_DetailCvTmp.Item(iRow).Item("PT_DC_I") = 0, Dv_DetailCvTmp.Item(iRow).Item("DC_I"), CyberSupport.V_Round((Dv_DetailCvTmp.Item(iRow).Item("Tien_Cv") - Dv_DetailCvTmp.Item(iRow).Item("CK_I")) * Dv_DetailCvTmp.Item(iRow).Item("PT_DC_I") / 100, 0))
        Dv_DetailCvTmp.Item(iRow).EndEdit()
        '---------- Tinh thue
        TinhThue_CV(iRow)
        UpdateList()


    End Sub
    Private Sub TinhThue_CV(ByVal iRow As Integer)

        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dv_DetailCvTmp.Item(iRow).BeginEdit()
        If Dt_DetailCvTmp.Columns.Contains("Sua_Thue") Then
            If Dv_DetailCvTmp.Item(iRow).Item("Sua_Thue").ToString.Trim <> "1" Then
                Dv_DetailCvTmp.Item(iRow).Item("Thue") = Math.Round((Dv_DetailCvTmp.Item(iRow).Item("Tien_CV") - Dv_DetailCvTmp.Item(iRow).Item("CK_I") + Dv_DetailCvTmp.Item(iRow).Item("DC_I")) * Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat") / 100, 0, MidpointRounding.AwayFromZero)
                'Else
                '    Dv_DetailCvTmp.Item(iRow).Item("Thue") = Math.Round((Dv_DetailCvTmp.Item(iRow).Item("Tien_CV") - Dv_DetailCvTmp.Item(iRow).Item("CK_I") + Dv_DetailCvTmp.Item(iRow).Item("DC_I")) * Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat") / 100, 0, MidpointRounding.AwayFromZero)
            End If
        Else
            Dv_DetailCvTmp.Item(iRow).Item("Thue") = Math.Round((Dv_DetailCvTmp.Item(iRow).Item("Tien_CV") - Dv_DetailCvTmp.Item(iRow).Item("CK_I") + Dv_DetailCvTmp.Item(iRow).Item("DC_I")) * Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat") / 100, 0, MidpointRounding.AwayFromZero)
        End If


        If Dt_DetailCvTmp.Columns.Contains("Tien_CV0") Then Dv_DetailCvTmp.Item(iRow).Item("Tien_CV0") = Dv_DetailCvTmp.Item(iRow).Item("Tien_CV") - Dv_DetailCvTmp.Item(iRow).Item("CK_I") + Dv_DetailCvTmp.Item(iRow).Item("DC_I")
        Dv_DetailCvTmp.Item(iRow).EndEdit()

    End Sub
#End Region



#Region "Bosung"
#Region "Ma_Cv"
    Private Sub V_Ma_Cv(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Lookup("Ma_Cv", "Dmcv", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Cv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVCv.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailCvTmp.Item(iRow).BeginEdit()
            Dv_DetailCvTmp.Item(iRow).Item("Ma_Cv") = ""
            Dv_DetailCvTmp.Item(iRow).Item("Ten_Cv") = ""
            Dv_DetailCvTmp.Item(iRow).Item("Ma_TT") = ""
            Dv_DetailCvTmp.Item(iRow).EndEdit()
            DetailGRVVt.UpdateCurrentRow()
            Exit Sub
        End If
        Dv_DetailCvTmp.Item(iRow).BeginEdit()
        Dv_DetailCvTmp.Item(iRow).Item("Ma_TT") = IIf(Dv_DetailCvTmp.Item(iRow).Item("Ma_TT").ToString.Trim <> "", Dv_DetailCvTmp.Item(iRow).Item("Ma_TT"), M_Ma_TT)
        Dv_DetailCvTmp.Item(iRow).Item("Ma_Cv") = DrReturn("Ma_Cv").ToString.Trim
        Dv_DetailCvTmp.Item(iRow).Item("Ten_Cv") = DrReturn("Ten_Cv" + IIf(M_LAN = "V", "", "2")).ToString.Trim
        Dv_DetailCvTmp.Item(iRow).Item("Ten_Cv3") = IIf(Dv_DetailCvTmp.Item(iRow).Item("Ten_Cv3").ToString.Trim <> "", Dv_DetailCvTmp.Item(iRow).Item("Ten_Cv3"), DrReturn("Ten_Cv" + IIf(M_LAN = "V", "", "2")).ToString.Trim)
        Dv_DetailCvTmp.Item(iRow).Item("MA_KTV_I") = IIf(Dv_DetailCvTmp.Item(iRow).Item("MA_KTV_I").ToString.Trim <> "", Dv_DetailCvTmp.Item(iRow).Item("MA_KTV_I"), DrReturn("Ma_Hs").ToString.Trim)


        Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat") = IIf(Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat") <> 0, Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat"), DrReturn("Thue_Suat"))
        'If Dv_DetailCvTmp.Item(iRow).Item("Gia_CV") = 0 Then Dv_DetailCvTmp.Item(iRow).Item("Gia_CV") = DrReturn("Gia_CV")
        'If Dv_DetailCvTmp.Item(iRow).Item("Gio_TC") = 0 Then Dv_DetailCvTmp.Item(iRow).Item("Gio_TC") = DrReturn("Gio_TC")
        'If Dv_DetailCvTmp.Item(iRow).Item("Tien_CV") = 0 Then Dv_DetailCvTmp.Item(iRow).Item("Tien_CV") = DrReturn("Tien_CV")
        Dv_DetailCvTmp.Item(iRow).EndEdit()

        If Not V_Update_Gio_TC(iRow) Then
            Dv_DetailCvTmp.Item(iRow).BeginEdit()
            Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat") = IIf(Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat") <> 0, Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat"), DrReturn("Thue_Suat"))
            If Dv_DetailCvTmp.Item(iRow).Item("Gia_CV") = 0 Then Dv_DetailCvTmp.Item(iRow).Item("Gia_CV") = DrReturn("Gia_CV")
            If Dv_DetailCvTmp.Item(iRow).Item("Gio_TC") = 0 Then Dv_DetailCvTmp.Item(iRow).Item("Gio_TC") = DrReturn("Gio_TC")
            If Dv_DetailCvTmp.Item(iRow).Item("Tien_CV") = 0 Then Dv_DetailCvTmp.Item(iRow).Item("Tien_CV") = DrReturn("Tien_CV")
            Dv_DetailCvTmp.Item(iRow).EndEdit()
        End If

        Tinh_TienCV(iRow)
        DetailGRVCv.UpdateCurrentRow()
    End Sub
    Private Function V_Update_Gio_TC(ByVal _iRow As Integer) As Boolean
        'Dim _Return As Boolean = False
        'If _iRow < 0 Then Return _Return
        'If Not (M_Mode = "M" Or M_Mode = "S") Then Return _Return
        'Dim _Ma_Xe As String = TxtMa_Xe.Text
        'Dim _So_Khung As String = TxtSo_khung.Text
        'Dim _So_May As String = TxtSo_May.Text
        'Dim _ma_Kx As String = TxtMa_Kx.Text
        'Dim _ma_Mau As String = TxtMa_Mau.Text
        'Dim _Str As String = "INSERT CTGetCVCYBER SELECT N'" + Dv_DetailCvTmp.Item(_iRow).Item("Ma_Cv").ToString.Trim + "'"
        '_Str = _Str + ",N'" + Dv_DetailCvTmp.Item(_iRow).Item("Ma_CTCv").ToString.Trim + "'"
        '_Str = _Str + ",N'" + Dv_DetailCvTmp.Item(_iRow).Item("Gio_TC").ToString.Trim.Replace(" ", "").Replace(",", ".") + "'"
        '_Str = _Str + ",N'" + Dv_DetailCvTmp.Item(_iRow).Item("Gia_CV").ToString.Trim.Replace(" ", "").Replace(",", ".") + "'"
        '_Str = _Str + ",N'" + Dv_DetailCvTmp.Item(_iRow).Item("CK_I").ToString.Trim.Replace(" ", "").Replace(",", ".") + "'"
        '_Str = _Str + ",N'" + Dv_DetailCvTmp.Item(_iRow).Item("Tien_CV").ToString.Trim.Replace(" ", "").Replace(",", ".") + "'"
        'Dim _DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_ROUpdateGioTC", _Ma_Xe + "#" + _So_Khung + "#" + _So_May + "#" + _ma_Kx + "#" + _ma_Mau + "#" + _Str + "#" + M_Ma_CT + "#" + M_Mode + "#" + M_Stt_Rec + "#" + M_Ma_Dvcs + "#" + M_User_Name)

        'If _DsTmp.Tables.Count = 0 Then
        '    _DsTmp.Dispose()
        '    Return _Return
        'End If

        'If _DsTmp.Tables(0).Rows.Count = 0 Then
        '    _DsTmp.Dispose()
        '    Return _Return
        'End If
        'CyberSmodb.V_UpdateRowtoRow(_DsTmp.Tables(0).Rows(0), Dv_DetailCvTmp, _iRow)
        'DetailGRVCv.UpdateCurrentRow()
        '_DsTmp.Dispose()
        '_Return = True
        'Return _Return
    End Function


#Region "Ma_CtCv"
    Private Sub V_Ma_CtCv(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Lookup("Ma_CtCv", "DmCtCv", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_CtCv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVCv.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailCvTmp.Item(iRow)("Ma_CtCv") = ""
            Exit Sub
        End If
        Dv_DetailCvTmp.Item(iRow).BeginEdit()
        Dv_DetailCvTmp.Item(iRow).Item("Ma_CtCv") = DrReturn("Ma_CtCv").ToString.Trim

        If DrReturn.Table.Columns.Contains("Thue_Suat") Then Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat") = IIf(Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat") <> 0, Dv_DetailCvTmp.Item(iRow).Item("Thue_Suat"), DrReturn("Thue_Suat"))
        If DrReturn.Table.Columns.Contains("Gio_TC") Then Dv_DetailCvTmp.Item(iRow).Item("Gio_TC") = IIf(Dv_DetailCvTmp.Item(iRow).Item("Gio_TC") <> 0, Dv_DetailCvTmp.Item(iRow).Item("Gio_TC"), DrReturn("Gio_TC"))

        Dv_DetailCvTmp.Item(iRow).EndEdit()
        Tinh_TienCV(iRow)
        DetailGRVCv.UpdateCurrentRow()

    End Sub
#End Region
#Region "Ma_TTCV"
    Private Sub V_Ma_TTCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Lookup("Ma_TT", "DmTT", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVCv.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailCvTmp.Item(iRow)("Ma_TT") = ""
            Exit Sub
        End If
        Dv_DetailCvTmp.Item(iRow).BeginEdit()
        Dv_DetailCvTmp.Item(iRow).Item("Ma_TT") = DrReturn("Ma_TT").ToString.Trim
        Dv_DetailCvTmp.Item(iRow).EndEdit()
        Tinh_TienCV(iRow)
        UpdateList()
        DetailGRVCv.UpdateCurrentRow()
    End Sub
#End Region

#End Region




#Region "Ma_Vv_i/Phi...TD1/Td2.../TD5 = Cua cong viec sua chua"
    Private Sub V_Ma_KTV_ICV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Lookup("Ma_hs", "DmKTV", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_KTV_ICV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = -1
        iRow = DetailGRVCv.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailCvTmp.Item(iRow)("Ma_KTV_I") = ""
            If Dv_DetailCvTmp.Table.Columns.Contains("Ten_KTV_I") Then Dv_DetailCvTmp.Item(iRow).Item("Ten_KTV_I") = ""
            Exit Sub
        End If
        Dv_DetailCvTmp.Item(iRow).BeginEdit()
        Dv_DetailCvTmp.Item(iRow).Item("Ma_KTV_I") = DrReturn("Ma_hs").ToString.Trim
        If Dv_DetailCvTmp.Table.Columns.Contains("Ten_KTV_I") Then Dv_DetailCvTmp.Item(iRow).Item("Ten_KTV_I") = DrReturn("Ten_hs").ToString.Trim
        Dv_DetailCvTmp.Item(iRow).EndEdit()
        DetailGRVCv.UpdateCurrentRow()
    End Sub
    Private Sub V_Ma_Vv_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vv_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vv_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vv_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_Phi_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Phi_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Phi_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Phi_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_HD_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_HD_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hd_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_SP_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Sp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_SP_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Sp_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_KU_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Ku_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_KU_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Ku_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_TTLN_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTLN_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTLN_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTLN_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_TTCP_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTCP_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTCP_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTCP_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_Bp_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Bp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Bp_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Bp_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_HS_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hs_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_HS_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hs_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_CD_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Cd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_CD_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Cd_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_TD1_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Td1_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD1_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Td1_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_TD2_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD2_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD2_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD2_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_TD3_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD3_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD3_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD3_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_TD4_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD4_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD4_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD4_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
    Private Sub V_Ma_TD5_iCV(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD5_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD5_iCV(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD5_i(M_Mode, M_Ma_CT, sender, DetailGRVCv)
    End Sub
#End Region

#Region "L_Ma_TT"
    Private Sub V_Ma_TT(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Lookup("Ma_TT", "DmTT", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_DetailTmp.Item(iRow).BeginEdit()
            Dv_DetailTmp.Item(iRow)("Ma_TT") = ""
            Dv_DetailTmp.Item(iRow).EndEdit()
            Exit Sub
        End If
        Dv_DetailTmp.Item(iRow).BeginEdit()
        Dv_DetailTmp.Item(iRow).Item("Ma_TT") = DrReturn("Ma_TT").ToString.Trim
        Dv_DetailTmp.Item(iRow).EndEdit()

        '-------------------------------------------------------------------
        Tinh_Gia2(iRow)
        Tinh_TienPT(iRow)
        UpdateList()
        DetailGRVVt.UpdateCurrentRow()
        '-------------------------------------------------------------------
    End Sub
#End Region


#Region "Mainform Cong Viec"
    Private Sub V_MainSystemCv()
        Dim mnItemsMail = New ContextMenu
        Dim mnItemsF4 As New MenuItem(If(M_LAN = "V", "Thêm dòng", "New row"), AddressOf V_ShortAddItemCv, Keys.F4)
        Dim mnItemsF8 As New MenuItem(If(M_LAN = "V", "Xóa dòng", "Delete row"), AddressOf V_ShortDeleteItemCv, Keys.F8)
        mnItemsMail.MenuItems.Add(mnItemsF4)
        mnItemsMail.MenuItems.Add(mnItemsF8)
        DetailGRVCv.GridControl.ContextMenu = mnItemsMail
    End Sub
    Private Sub MasterGRVCv_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim rowHandle As Integer = e.HitInfo.RowHandle
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            PopupMenuMasterGrid.ItemLinks.Clear()

            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Thêm dòng", "Add item"), AddressOf V_ShortAddItemCv, Nothing, True, False))

            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Xóa dòng", "Delete item"), AddressOf V_ShortDeleteItemCv, Nothing, True, False))

            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Import", "Delete item"), AddressOf V_ImportCv, Nothing, True, True))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Lưu chứng từ", "Save"), AddressOf V_ShortSAVE, Nothing, True, True))

            PopupMenuMasterGrid.ShowPopup(Control.MousePosition)
        End If

    End Sub
    Private Sub V_ShortAddItemCv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRVCv.FocusedRowHandle
        V_AddItemCv(iRow)
        iRow = Dv_DetailCvTmp.Count - 1
        CyberFill.V_ForcusCell(DetailGRVCv, iRow, 0)
    End Sub
    Private Sub V_ShortDeleteItemCv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRVCv.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Not CyberSupport.V_DeleteItemVoucher(osysvar, M_LAN, M_Ma_CT, iRow, Dv_DetailCvTmp, AppConn, DetailGRVCv) Then Exit Sub
        Dv_DetailCvTmp.Delete(iRow)
        Dv_DetailCvTmp.Table.AcceptChanges()
        UpdateList()
    End Sub
#End Region


#Region "Add Or Detete Item Cong Viec"
    Private Sub MasterGRVCv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iCoumnVisible As Integer = sender.VisibleColumns.Count - 1
        Dim iRowVisible As Integer = sender.RowCount - 1
        Dim iRowRowFocus As Integer = sender.FocusedRowHandle
        Dim iColumnRowFocus As Integer = sender.VisibleColumns.IndexOf(sender.FocusedColumn)
        Dim iRowOld As Integer = sender.GetFocusedDataSourceRowIndex
        'If e.KeyCode = Keys.Enter And iRowVisible = iRowRowFocus And iCoumnVisible = iColumnRowFocus Then V_AddItem(iRowOld) '' Cot cuoi cung them dong
        If iRowVisible <> iRowRowFocus Or iCoumnVisible <> iColumnRowFocus Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            V_AddItemCv(iRowOld) '' Cot cuoi cung them dong
        ElseIf e.KeyCode = Keys.End Then
            SendKeys.Send("^{Tab}")
        End If
    End Sub
    Private Sub V_AddItemCv(Optional ByVal iRow As Integer = -1)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim DrvOld As DataRowView
        '===================================
        Dim vTbAdd As New DataView
        Dim TbHeader As New DataTable
        vTbAdd = Dv_DetailCvTmp
        TbHeader = M_DsHead.Tables(2)
        '===================================
        If iRow >= 0 Then DrvOld = vTbAdd.Item(iRow) Else DrvOld = Nothing
        vTbAdd.Table.Rows.Add()
        CyberSmodb.SetValueBlankRow(vTbAdd.Table.Rows(vTbAdd.Table.Rows.Count - 1))
        CyberSupport.SetCarryOn(DrvOld, vTbAdd.Table.Rows(vTbAdd.Table.Rows.Count - 1), New DataView(TbHeader))
        CarrOnCv(vTbAdd.Table.Rows(vTbAdd.Table.Rows.Count - 1))

        iRow = Dv_DetailCvTmp.Count - 1
        CyberFill.V_ForcusCell(DetailGRVCv, iRow, 0)
        UpdateList()
    End Sub
    Private Sub CarrOnCv(ByVal DvNew As DataRow)
        DvNew.Item("Stt_Rec") = M_Stt_Rec.Trim
        DvNew.Item("Ma_Ct") = M_Ma_CT.Trim
        DvNew.Item("Ngay_Ct") = Me.TxtNgay_Ct.Value
    End Sub
#End Region
#Region "Tinhgia2"
    Private Sub Tinh_Gia2(ByVal iRow As Integer)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If iRow < 0 Then Exit Sub
        Dim _Gia_TK As Decimal = Dv_DetailTmp.Item(iRow).Item("Gia_TK")
        Dim _Gia2 As Decimal = Dv_DetailTmp.Item(iRow).Item("Gia2")
        Dim _Ma_vt As String = Dv_DetailTmp.Item(iRow).Item("Ma_Vt")
        Dim _Ma_Kho As String = Dv_DetailTmp.Item(iRow).Item("Ma_Kho_I")
        Dim _Ma_TT As String = Dv_DetailTmp.Item(iRow).Item("Ma_TT")
        Dim _Ma_GD As String = CbbMa_GD.SelectedValue.ToString.Trim
        Dim _Ma_Post As String = CbbMa_Post.SelectedValue.ToString.Trim
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        '-----------------------------------------------------------------------------------------------------------
        Dim dsGia2 As New DataSet
        dsGia2 = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_GetHDKGia2", _Ngay_Ct.ToString("yyyyMMdd") & "#" & M_Ma_CT.Trim & "#" & M_Stt_Rec & "#" & M_Mode & "#" &
                                                    _Ma_GD & "#" & _Ma_Post & "#" & _Ma_vt.Trim & "#" & _Ma_Kho.Trim + "#" & _Ma_TT & "#" &
                                                    _Gia2.ToString.Trim.Replace(" ", "").Replace(",", ".") & "#" & TxtMa_Dvcs.Text.Trim + "#" + M_User_Name.Trim)
        _Gia2 = dsGia2.Tables(0).Rows(0).Item("Gia2")
        _Gia_TK = dsGia2.Tables(0).Rows(0).Item("Gia_TK")

        '-----------------------------------------------------------------------------------------------------------
        Dv_DetailTmp.Item(iRow).BeginEdit()
        Dv_DetailTmp.Item(iRow).Item("Gia2") = _Gia2
        If Dt_DetailTmp.Columns.Contains("Gia_TK") Then Dv_DetailTmp.Item(iRow).Item("Gia_TK") = _Gia_TK
        If Dt_DetailTmp.Columns.Contains("BackColor") And dsGia2.Tables(0).Columns.Contains("BackColor") Then Dv_DetailTmp.Item(iRow).Item("BackColor") = dsGia2.Tables(0).Rows(0).Item("BackColor")
        If Dt_DetailTmp.Columns.Contains("BackColor2") And dsGia2.Tables(0).Columns.Contains("BackColor2") Then Dv_DetailTmp.Item(iRow).Item("BackColor2") = dsGia2.Tables(0).Rows(0).Item("BackColor2")
        If Dt_DetailTmp.Columns.Contains("ForeColor") And dsGia2.Tables(0).Columns.Contains("ForeColor") Then Dv_DetailTmp.Item(iRow).Item("ForeColor") = dsGia2.Tables(0).Rows(0).Item("ForeColor")
        If Dt_DetailTmp.Columns.Contains("Bold") And dsGia2.Tables(0).Columns.Contains("Bold") Then Dv_DetailTmp.Item(iRow).Item("Bold") = dsGia2.Tables(0).Rows(0).Item("Bold")
        Dv_DetailTmp.Item(iRow).EndEdit()

        dsGia2.Dispose()

        '-----------------------------------------------------------------------------------------------------------
    End Sub
#End Region




#End Region
#End Region
#Region "Tai khoan "
    Private Sub V_Tk_VT(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Tk_Vt(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Tk_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Tk_Vt(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_Nx_I(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Nx_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Nx_I(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Nx_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
#End Region
#Region "So_So/So_PO/So_RO/So_VT"
    Private Sub L_So_So(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_So(Dv_DetailTmp, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_Po(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_PO(Dv_DetailTmp, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_Ro(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_Ro(Dv_DetailTmp, iRow, AppConn, osysvar, M_Ma_CT, "S", M_Mode, _Ngay_Ct, CbbMa_TTCP_H, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRVVt.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_VT(Dv_DetailTmp, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
#End Region
#Region "Valid - Detail - Add On"
    Private Sub V_Ma_Vv_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vv_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vv_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vv_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_Phi_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Phi_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Phi_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Phi_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_HD_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_HD_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hd_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_SP_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Sp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_SP_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Sp_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_KU_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Ku_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_KU_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Ku_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_TTLN_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTLN_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTLN_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTLN_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_TTCP_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTCP_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTCP_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTCP_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_Bp_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Bp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Bp_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Bp_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_HS_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hs_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_HS_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hs_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_CD_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Cd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_CD_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Cd_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_TD1_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Td1_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD1_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Td1_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_TD2_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD2_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD2_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD2_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_TD3_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD3_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD3_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD3_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_TD4_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD4_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD4_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD4_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD5_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD5_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_Db_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Db_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Db_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Db_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_Xe_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Xe_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Xe_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Xe_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_Kx(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'CyberSupport.V_Ma_Kx_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
        CyberSupport.V_Lookup("MA_KX", "DMKX", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Kx(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CyberSupport.L_Ma_Kx_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
        Dim iRows As Integer = -1
        Dim drReturn As DataRow
        iRows = DetailGRVVt.FocusedRowHandle
        If iRows < 0 Then Exit Sub
        drReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If drReturn Is Nothing Then
            Dt_DetailTmp.Rows(iRows)("Ma_kx") = ""
            Dt_DetailTmp.AcceptChanges()
            Exit Sub
        End If
        Dt_DetailTmp.Rows(iRows)("Ma_kx") = drReturn("Ma_kx").ToString.Trim
        Dt_DetailTmp.Rows(iRows)("Ten_kx") = drReturn("Ten_kx").ToString.Trim
        Dt_DetailTmp.AcceptChanges()
        DetailGRVVt.UpdateCurrentRow()
    End Sub
    Private Sub V_Ma_Mau(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Lookup("MA_MAU", "DMMAUXE", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Mau(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRows As Integer = -1
        Dim drReturn As DataRow
        iRows = DetailGRVVt.FocusedRowHandle
        If iRows < 0 Then Exit Sub
        drReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If drReturn Is Nothing Then
            Dt_DetailTmp.Rows(iRows)("Ma_Mau") = ""
            Dt_DetailTmp.AcceptChanges()
            Exit Sub
        End If
        Dt_DetailTmp.Rows(iRows)("Ma_Mau") = drReturn("Ma_Mau").ToString.Trim
        Dt_DetailTmp.Rows(iRows)("Ten_Mau") = drReturn("Ten_Mau").ToString.Trim
        Dt_DetailTmp.AcceptChanges()
        DetailGRVVt.UpdateCurrentRow()
    End Sub
    Private Sub V_Ma_Kx_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Kx_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Kx_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Kx_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_Tuyen_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Tuyen_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Tuyen_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Tuyen_i(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_Ts(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Ts(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Ts(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Ts(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
    Private Sub V_Ma_Cc(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Cc(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Cc(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Cc(M_Mode, M_Ma_CT, sender, DetailGRVVt)
    End Sub
#End Region
#End Region
#Region "Ngay ct, ngay lap chung tu,so chung tu"
    Private Sub V_Ngay_Ct(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" Then Exit Sub

        If Not txtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        txtSo_ct.Text = CyberSupport.V_GetNoVoucher(M_Mode, txtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
    Private Sub V_Ngay_LCt(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" Then Exit Sub
        If Not txtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        txtSo_ct.Text = CyberSupport.V_GetNoVoucher(M_Mode, txtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
    Private Sub V_So_Ct(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" Then Exit Sub
        If Not txtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        txtSo_ct.Text = CyberSupport.V_GetNoVoucher(M_Mode, txtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
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
        VisibleColumnMa_NT()
    End Sub
    Private Sub L_Ty_Gia(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.Trim.ToUpper = osysvar("M_MA_NT0").ToString.Trim Then TxtTy_Gia.Double = 1
        For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
            V_Tinh_Toan(iRow)
        Next
        Dv_DetailTmp.Table.AcceptChanges()
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
    Private Sub MasterGRV_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim rowHandle As Integer = e.HitInfo.RowHandle
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            PopupMenuMasterGrid.ItemLinks.Clear()
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Thêm dòng", "Add item"), AddressOf V_ShortAddItem, Nothing, True, False))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Xóa dòng", "Delete item"), AddressOf V_ShortDeleteItem, Nothing, True, False))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Import", "Delete item"), AddressOf V_Import, Nothing, True, True))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Lưu chứng từ", "Save"), AddressOf V_ShortSAVE, Nothing, True, True))
            PopupMenuMasterGrid.ShowPopup(Control.MousePosition)
        End If
    End Sub
    Private Sub V_ShortAddItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRVVt.FocusedRowHandle
        V_AddItem(iRow)
    End Sub
    Private Sub V_ShortDeleteItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRVVt.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Not CyberSupport.V_DeleteItemVoucher(osysvar, M_LAN, M_Ma_CT, iRow, Dv_DetailTmp, AppConn, DetailGRVVt) Then Exit Sub
        Dv_DetailTmp.Delete(iRow)
        Dv_DetailTmp.Table.AcceptChanges()
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
        DetailGRVVt.PostEditor()
        DetailGRVCv.PostEditor()
        Dv_DetailTmp.Table.AcceptChanges()
        Dv_DetailCvTmp.Table.AcceptChanges()

        If M_Mode.Trim = "M" Then TxtMa_Dvcs.Text = M_Ma_Dvcs
        If M_Mode.Trim = "M" Then TxtUser_id.Text = M_User_ID
        If TxtMa_NT.Text.Trim = "" Then V_GetTyGia()

        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        Dim _Ngay_LCt As Date = TxtNgay_Ct.Value
        ''V_GetAndSetChkbSCC_DS_ALL("1")
        '----------------------------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------------------------
        V_GetDateVoucher(M_Mode, _Ngay_Ct, _Ngay_LCt)
        '----------------------------------------------------------------------------------------------------------------------
        If Not ChkRightsVoucher("L") Then Exit Sub

        '----------------------------------------------------------------------------------------------------------------------
        'V_GetNoVoucherAuto() ' Tao So Chung tu tu dong

        '----------------------------------------------------------------------------------------------------------------------
        If Not ChkVsave() Then Exit Sub 'Kiem tra va Update du lieu chuong tri

        'CyberInput.V_Save_Default_TTCP(Dt_DetailTmp, M_Is_Visible_TTCP, CbbMa_TTCP_H, M_Ma_CT, CyberSmodb)
        'CyberInput.V_Save_Default_TTCP(Dt_DetailCvTmp, M_Is_Visible_TTCP, CbbMa_TTCP_H, M_Ma_CT, CyberSmodb)

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
        drMaster.Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
        '---Save Post
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)

        '---------------------------------------------------
        Dim DsSave As DataSet
        If Not CyberSmodb.V_SysCheckSaveVoucher(AppConn, osysvar, {Dt_DetailTmp, CyberSmodb.V_ConvertDrToTb(drMaster), Dt_DetailCvTmp}, {M_Ct, M_Ph, "CTISCCV"}, M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, CbbMa_GD.SelectedValue, M_Ma_CT, M_Stt_Rec, M_LAN, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib, CyberSupport, DsSave) Then
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
                drMaster.Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
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

        '---Update CV
        If DsSave.Tables.Count >= 4 Then
            For iRow As Integer = 0 To DsSave.Tables(3).Rows.Count - 1
                Try
                    CyberSmodb.V_UpdateRowtoRow(DsSave.Tables(3).Rows(iRow), Dt_DetailCvTmp, iRow)
                Catch ex As Exception
                End Try
            Next
        End If
        '---------------------------------------------------
        '---Xoa trong DetailCV
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_DetailCv, "Stt_Rec = '" + M_Stt_Rec + "'")
        Dt_DetailCv.Load(Dt_DetailCvTmp.CreateDataReader)
        '----------------------------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------------------------
        M_Mode = "X"
        M_Count = Dt_DetailTmp.Rows.Count
        V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("L")
        CyberSmlib.FlushMemorySave()
    End Sub
    Private Sub V_Save_Luu(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DetailGRVVt.PostEditor()
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
        'Dim _So_Ct As String = txtSo_ct.Text
        'If Not CyberInput.SysGetNo(AppConn, osysvar, "L", _So_Ct, TxtStt_Rec.Text, _Ngay_Ct, _Ngay_LCt, CbbMa_GD.SelectedValue.ToString.Trim, M_Ma_CT, M_Ma_Dvcs, M_User_Name) Then Exit Sub
        'txtSo_ct.Text = _So_Ct
        V_GetNoVoucherAuto() ' Tao So Chung tu tu dong
        '----------------------------------------------------------------------------------------------------------------------
        If Not ChkVsave() Then Exit Sub 'Kiem tra va Update du lieu chuong tri
        '----------------------------------------------------------------------------------------------------------------------
        CyberInput.V_Save_Default_TTCP(Dt_DetailTmp, M_Is_Visible_TTCP, CbbMa_TTCP_H, M_Ma_CT, CyberSmodb)
        '----------------------------------------------------------------------------------------------------------------------
        If Not CyberSupport.ChkVoucherInput(Me, AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Ma_CT, _Ngay_Ct, CbbMa_GD.SelectedValue, M_Stt_Rec, CbbMa_Post.SelectedValue, M_Ma_Dvcs, M_User_Name, Dt_DetailTmp, "Ten_Tk,TEN_KH", "TEN_VT,TEN_KHO_I", CyberSmlib, CyberSupport, CyberSmodb, CyberLoading) Then Exit Sub
        '----------------------------------------------------------------------------------------------------------------------
        If Not CyberSupport.V_ChkExistNovoucher(AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Stt_Rec, M_Ma_CT, txtSo_ct.Text.Trim, _Ngay_Ct, _Ngay_LCt, M_Ma_Dvcs, M_User_Name, CyberSmlib) Then Exit Sub '---Kiem tra trung so chung tu
        '----------------------------------------------------------------------------------------------------------------------

        If Not Add2Database() Then Return
        '----------------------------------------------------------------------------------------------------------------------
        M_Mode = "X"
        V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("L")
        CyberSmlib.FlushMemorySave()

    End Sub
    Private Function ChkVsave() As Boolean
        Dim iRow, nCount As Integer
        nCount = Dt_DetailTmp.Rows.Count
        For iRow = nCount - 1 To 0 Step -1
            If Dt_DetailTmp.Rows(iRow).Item("Ma_VT").ToString.Trim = "" Then
                Dt_DetailTmp.Rows(iRow).Delete()
                Dt_DetailTmp.AcceptChanges()
            End If
        Next
        '---------------------------------------------------------------------------------
        For iRow = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_DetailTmp.Rows(iRow).Item("Stt_Rec") = M_Stt_Rec
            Dt_DetailTmp.Rows(iRow).Item("Ma_Ct") = M_Ma_CT
            Dt_DetailTmp.Rows(iRow).Item("Ngay_Ct") = TxtNgay_Ct.Value
            Dt_DetailTmp.Rows(iRow).Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
            Dt_DetailTmp.Rows(iRow).Item("Stt_Rec0") = CyberSupport.GetStt_Rec0(iRow + 1)
            'If Dt_DetailTmp.Columns.Contains("Ma_DB_I") Then If TxtMa_DB_H.Text.Trim <> "" Then Dt_DetailTmp.Rows(iRow).Item("Ma_DB_I") = TxtMa_DB_H.Text.Trim
            If Dt_DetailTmp.Columns.Contains("Ma_Bp_I") Then If TxtMa_Bp_H.Text.Trim <> "" Then Dt_DetailTmp.Rows(iRow).Item("Ma_Bp_I") = TxtMa_Bp_H.Text.Trim
            If Dt_DetailTmp.Columns.Contains("Ma_HS_I") Then If txtMa_HS_H.Text.Trim <> "" Then Dt_DetailTmp.Rows(iRow).Item("Ma_HS_I") = txtMa_HS_H.Text.Trim
        Next
        Dt_DetailTmp.AcceptChanges()
        If Not CyberSupport.ChkDetail(Dv_DetailTmp.Count, M_Ma_CT, M_LAN, osysvar) Then Return False
        UpdateList()
        ChkVsave = True
    End Function
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
        drMaster.Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
        '---Save Post
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)
        If M_Mode.Trim = "M" Then Dt_Master.Rows.Add(drMaster) Else Dt_Master.Rows(CrrRow).EndEdit()
        Dt_Master.AcceptChanges()
        '-----------------------------------------------------------------------------------------------------
        '---Xoa trong Detail
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detail, "Stt_Rec = '" + M_Stt_Rec + "'")
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_DetailCv, "Stt_Rec = '" + M_Stt_Rec + "'")
        '+Import To Detail 
        For i As Integer = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_Detail.ImportRow(Dt_DetailTmp.Rows(i))
        Next
        For i As Integer = 0 To Dt_DetailCvTmp.Rows.Count - 1
            Dt_DetailCv.ImportRow(Dt_DetailCvTmp.Rows(i))
        Next
        '-----------------------------------------------------------------------------------------------------
        Return CyberSmodb.V_Add2Database(AppConn, osysvar, {Dt_DetailTmp, CyberSmodb.V_ConvertDrToTb(drMaster), Dt_DetailCvTmp}, {M_Ct, M_Ph, "CTISCCV"}, M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_LAN, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib, CyberSupport)
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
        drMaster.Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
        '---Save Post
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)
        If M_Mode.Trim = "M" Then Dt_Master.Rows.Add(drMaster) Else Dt_Master.Rows(CrrRow).EndEdit()
        Dt_Master.AcceptChanges()
        '-----------------------------------------------------------------------------------------------------
        '---Xoa trong Detail
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detail, "Stt_Rec = '" + M_Stt_Rec + "'")
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_DetailCv, "Stt_Rec = '" + M_Stt_Rec + "'")
        '+Import To Detail 
        For i As Integer = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_Detail.ImportRow(Dt_DetailTmp.Rows(i))
        Next
        For i As Integer = 0 To Dt_DetailCvTmp.Rows.Count - 1
            Dt_DetailCv.ImportRow(Dt_DetailCvTmp.Rows(i))
        Next
        '-----------------------------------------------------------------------------------------------------
        '---Save: History
        CyberSupport.V_HistoryVoucher(M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        '-----------------------------------------------------------------------------------------------------
        '---Save: TO SQL

        CyberSmodb.V_SaveToSQL(AppConn, osysvar, M_User_Name, drMaster, M_Ph, M_Mode, "Stt_Rec = N'" + M_Stt_Rec + "'", IIf(M_Mode.Trim = "S", True, False))
        'V_CyberSaveToSQL()

        CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailTmp, M_Ct, M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailCvTmp, "CTISCCV", M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")

        ' CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailTmp, M_Ct, M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        'CyberSmodb.V_SaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailCvTmp, "CTISCCV", M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
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
        txtSo_ct.Text = _So_Ct_Copy.Trim
        M_Mode = "M"
        V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
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
        If txtDien_giai.Text.Trim = "" Then txtDien_giai.Text = M_Dien_Giai

        V_New()
        V_SetEnabled(Me, M_Mode, Dt_Master)
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
            DrCurren.Item("Stt_Rec") = M_Stt_Rec.Trim
            DrCurren.Item("Ma_Ct") = M_Ma_CT.Trim
            DrCurren.Item("Stt_Rec0") = "001"
            Dt_DetailTmp.Rows.Add(DrCurren)
            Dt_DetailTmp.AcceptChanges()
        End If
        If Dt_DetailCvTmp.Rows.Count < 1 Then
            Dim DrCurren As DataRow
            Dt_DetailCvTmp.NewRow()
            DrCurren = Dt_DetailCvTmp.NewRow
            CyberSmodb.SetValueBlankRow(DrCurren)
            DrCurren.Item("Stt_Rec") = M_Stt_Rec.Trim
            DrCurren.Item("Ma_Ct") = M_Ma_CT.Trim
            DrCurren.Item("Stt_Rec0") = "001"
            Dt_DetailCvTmp.Rows.Add(DrCurren)
            Dt_DetailCvTmp.AcceptChanges()
        End If
    End Sub
    Private Sub V_Edit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Stt_RecOld = M_Stt_Rec
        If Not ChkRightsVoucher("S") Then Exit Sub
        M_Mode = "S"
        V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("S")
    End Sub
    Private Sub V_Delete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If M_Stt_Rec.Trim = "" Then Exit Sub
        If Not ChkRightsVoucher("D") Then Exit Sub
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

        V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("D")
    End Sub
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
        V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("X")
    End Sub
    Private Sub V_View(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = "X"
        If M_Stt_Rec = "" Then Exit Sub
        M_Stt_Rec = CyberFrom.V_ViewVoucher(AppConn, osysvar, M_LAN, M_Para, DrDmct, DsData, DsHead, DsLookup, Dv_Master, Dv_Detail, M_Stt_Rec, strFilter, CyberFill, CyberSmlib, CyberSupport, False, True)
        'CyberSmlib.SQLExcuteStoreProcedure 
        V_Databing()
        V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
    End Sub
    Private Sub V_Search(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not CyberVoucher.V_FilterVocuher(AppConn, osysvar, Me.DsLookup, M_LAN, M_Para, DrDmct, M_strFilter, M_Ma_CT, M_Ma_Dvcs, M_User_Name) Then Exit Sub
        Dim DsRefresh As DataSet = CyberSupport.V_FilterData(AppConn, M_strFilter, CyberSmlib, CyberSmodb, DsData)
        If Not CyberSupport.MsgFilterData(DsRefresh.Tables(1), M_LAN, osysvar) Then Exit Sub

        If DsRefresh.Tables(1).Rows.Count = 1 Then M_Stt_Rec = DsRefresh.Tables(1).Rows(0).Item("Stt_Rec")
        If DsRefresh.Tables(1).Rows.Count > 1 Then M_Stt_Rec = CyberFrom.V_ViewVoucher(AppConn, osysvar, M_LAN, M_Para, DrDmct, Me.DsData, Me.DsHead, Me.DsLookup, Dv_Master, Dv_Detail, M_Stt_Rec, strFilter, CyberFill, CyberSmlib, CyberSupport, False, True)

        V_Databing()
        V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        M_Mode = "X"
        V_SetEnabled(Me, M_Mode, Dt_Master)
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
        Dim iCoumnVisible As Integer = DetailGRVVt.VisibleColumns.Count - 1
        Dim iRowVisible As Integer = DetailGRVVt.RowCount - 1
        Dim iRowRowFocus As Integer = DetailGRVVt.FocusedRowHandle
        Dim iColumnRowFocus As Integer = DetailGRVVt.VisibleColumns.IndexOf(DetailGRVVt.FocusedColumn)
        Dim iRowOld As Integer = DetailGRVVt.GetFocusedDataSourceRowIndex
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
        CyberFill.V_ForcusCell(DetailGRVVt, iRow, 0)

    End Sub
    Private Sub CarrOn(ByVal DvNew As DataRow)
        DvNew.Item("Stt_Rec") = M_Stt_Rec.Trim
        DvNew.Item("Ma_Ct") = M_Ma_CT.Trim
        DvNew.Item("Ngay_Ct") = Me.TxtNgay_Ct.Value
    End Sub
#End Region
#Region "Sms - Import"
    Private Sub V_Import(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TbImport As New DataTable
        TbImport = CyberExport.V_ImportDataToGridview(AppConn, osysvar, M_Para, DetailGRVVt, Dt_DetailTmp, M_LAN)
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
    Private Sub V_ImportCv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TbImport As New DataTable
        TbImport = CyberExport.V_ImportDataToGridview(AppConn, osysvar, M_Para, DetailGRVCv, Dt_DetailCvTmp, M_LAN)
        If TbImport Is Nothing Then Exit Sub
        '==================== Xu ly du lieu được Import vào
        Dt_DetailCvTmp.Clear()
        Dt_DetailCvTmp.AcceptChanges()
        For i = 0 To TbImport.Rows.Count - 1
            Dt_DetailCvTmp.ImportRow(TbImport.Rows(i))
        Next
        Dt_DetailCvTmp.AcceptChanges()
    End Sub

    Private Sub SetTxt()
        TxtT_SO_LUONG.ReadOnly = True
        TxtT_Tien_NT.ReadOnly = True
        TxtT_Tien.ReadOnly = True
        TxtTen_kh.ReadOnly = True
    End Sub
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


