<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TKT
    Inherits Cyber.From.Frmvoucher

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CbbMa_GD = New System.Windows.Forms.ComboBox()
        Me.LabNgay_LCt = New System.Windows.Forms.Label()
        Me.LabNgay_Ct = New System.Windows.Forms.Label()
        Me.LabDien_Giai = New System.Windows.Forms.Label()
        Me.lblLoai_ct = New System.Windows.Forms.Label()
        Me.lblSo_ct = New System.Windows.Forms.Label()
        Me.txtSo_ct = New System.Windows.Forms.TextBox()
        Me.TxtNgay_LCt = New ClsTextBox.txtDate()
        Me.TxtNgay_Ct = New ClsTextBox.txtDate()
        Me.GroupBoxLine = New System.Windows.Forms.GroupBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.TxtT_Tien_NT = New ClsTextBox.txtTien_NT()
        Me.TxtT_Tien = New ClsTextBox.txtTien_NT()
        Me.LabT_TT_NT = New System.Windows.Forms.Label()
        Me.TxtMa_Dvcs = New System.Windows.Forms.TextBox()
        Me.TxtStt_Rec = New System.Windows.Forms.TextBox()
        Me.PopupMenuMasterGrid = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.TxtT_Tien2 = New ClsTextBox.txtTien_NT()
        Me.TxtT_Tien_NT2 = New ClsTextBox.txtTien_NT()
        Me.TxtT_Tien3 = New ClsTextBox.txtTien_NT()
        Me.TxtT_Tien_NT3 = New ClsTextBox.txtTien_NT()
        Me.TxtT_Ps = New ClsTextBox.txtTien_NT()
        Me.TxtT_Ps_NT = New ClsTextBox.txtTien_NT()
        Me.txtTen_HS_H = New System.Windows.Forms.TextBox()
        Me.txtMa_HS_H = New Cyber.SmLists.TxtLookup()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTen_BP_H = New System.Windows.Forms.TextBox()
        Me.TxtMa_Bp_H = New Cyber.SmLists.TxtLookup()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CbbNam = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbbThang = New System.Windows.Forms.ComboBox()
        Me.LabM_month1 = New System.Windows.Forms.Label()
        Me.txtDien_giai = New System.Windows.Forms.TextBox()
        Me.TxtT_SO_LUONG = New ClsTextBox.txtTien_NT()
        Me.TxtTien_NT1 = New ClsTextBox.txtTien_NT()
        Me.TxtTien_NT2 = New ClsTextBox.txtTien_NT()
        Me.TxtTien_NT3 = New ClsTextBox.txtTien_NT()
        Me.TxtTien_NT4 = New ClsTextBox.txtTien_NT()
        Me.TxtNgay_LapKHBS = New ClsTextBox.txtDate()
        Me.LblNgay_lapKHBS = New System.Windows.Forms.Label()
        Me.LblLan_KHBS = New System.Windows.Forms.Label()
        Me.TxtLan_KHBS = New ClsTextBox.txtTien_NT()
        Me.ChkKhai_bosung = New System.Windows.Forms.CheckBox()
        Me.ChkKhai_landau = New System.Windows.Forms.CheckBox()
        Me.btnGetDetailTKT = New System.Windows.Forms.Button()
        Me.TabToKhaiThue = New System.Windows.Forms.TabControl()
        Me.TabTKT = New System.Windows.Forms.TabPage()
        Me.Detail = New DevExpress.XtraGrid.GridControl()
        Me.DetailGRV = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ChkIn_chi_tiet = New System.Windows.Forms.CheckBox()
        Me.ChkIn_Bks = New System.Windows.Forms.CheckBox()
        Me.TabHH_DV_MuaVaoTrongKy = New System.Windows.Forms.TabPage()
        Me.DetailMuaVao = New DevExpress.XtraGrid.GridControl()
        Me.DetailGRVMuaVao = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.TabHH_DV_BanRaTrongKy = New System.Windows.Forms.TabPage()
        Me.DetailBanRa = New DevExpress.XtraGrid.GridControl()
        Me.DetailGRVBanRa = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.btnExportXML = New System.Windows.Forms.Button()
        Me.ChkPL_NQ142_GTGT = New System.Windows.Forms.CheckBox()
        Me.ChkPL01_KHBS = New System.Windows.Forms.CheckBox()
        Me.ChkPL01_1_KHBS = New System.Windows.Forms.CheckBox()
        CType(Me.PopupMenuMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuMasterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMa_HS_H.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMa_Bp_H.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabToKhaiThue.SuspendLayout()
        Me.TabTKT.SuspendLayout()
        CType(Me.Detail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailGRV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabHH_DV_MuaVaoTrongKy.SuspendLayout()
        CType(Me.DetailMuaVao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailGRVMuaVao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabHH_DV_BanRaTrongKy.SuspendLayout()
        CType(Me.DetailBanRa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailGRVBanRa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdEdit
        '
        Me.CmdEdit.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdEdit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdEdit.Appearance.Options.UseBackColor = True
        Me.CmdEdit.Appearance.Options.UseFont = True
        Me.CmdEdit.Appearance.Options.UseForeColor = True
        Me.CmdEdit.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdEdit.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdEdit.Location = New System.Drawing.Point(244, 526)
        Me.CmdEdit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        '
        'CmdSave
        '
        Me.CmdSave.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdSave.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdSave.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdSave.Appearance.Options.UseBackColor = True
        Me.CmdSave.Appearance.Options.UseFont = True
        Me.CmdSave.Appearance.Options.UseForeColor = True
        Me.CmdSave.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdSave.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdSave.Location = New System.Drawing.Point(4, 526)
        Me.CmdSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdSave.TabIndex = 10
        '
        'CmdView
        '
        Me.CmdView.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdView.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdView.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdView.Appearance.Options.UseBackColor = True
        Me.CmdView.Appearance.Options.UseFont = True
        Me.CmdView.Appearance.Options.UseForeColor = True
        Me.CmdView.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdView.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdView.Location = New System.Drawing.Point(483, 526)
        Me.CmdView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdView.TabIndex = 16
        '
        'LabMa_Post
        '
        Me.LabMa_Post.ForeColor = System.Drawing.Color.Navy
        Me.LabMa_Post.Location = New System.Drawing.Point(16, 509)
        Me.LabMa_Post.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        '
        'CmdSms
        '
        Me.CmdSms.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdSms.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdSms.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdSms.Appearance.Options.UseBackColor = True
        Me.CmdSms.Appearance.Options.UseFont = True
        Me.CmdSms.Appearance.Options.UseForeColor = True
        Me.CmdSms.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdSms.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdSms.Location = New System.Drawing.Point(992, 526)
        Me.CmdSms.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdSms.TabIndex = 20
        '
        'CmdImport
        '
        Me.CmdImport.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdImport.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdImport.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdImport.Appearance.Options.UseBackColor = True
        Me.CmdImport.Appearance.Options.UseFont = True
        Me.CmdImport.Appearance.Options.UseForeColor = True
        Me.CmdImport.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdImport.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdImport.Location = New System.Drawing.Point(1037, 526)
        Me.CmdImport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdImport.TabIndex = 24
        '
        'CbbMa_Post
        '
        Me.CbbMa_Post.Location = New System.Drawing.Point(86, 503)
        Me.CbbMa_Post.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CbbMa_Post.TabIndex = 9
        '
        'CmdExit
        '
        Me.CmdExit.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdExit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdExit.Appearance.Options.UseBackColor = True
        Me.CmdExit.Appearance.Options.UseFont = True
        Me.CmdExit.Appearance.Options.UseForeColor = True
        Me.CmdExit.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdExit.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdExit.Location = New System.Drawing.Point(643, 526)
        Me.CmdExit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdExit.TabIndex = 18
        '
        'CmdSearch
        '
        Me.CmdSearch.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdSearch.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdSearch.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdSearch.Appearance.Options.UseBackColor = True
        Me.CmdSearch.Appearance.Options.UseFont = True
        Me.CmdSearch.Appearance.Options.UseForeColor = True
        Me.CmdSearch.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdSearch.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdSearch.Location = New System.Drawing.Point(563, 526)
        Me.CmdSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdSearch.TabIndex = 17
        '
        'CmdCopy
        '
        Me.CmdCopy.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdCopy.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdCopy.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdCopy.Appearance.Options.UseBackColor = True
        Me.CmdCopy.Appearance.Options.UseFont = True
        Me.CmdCopy.Appearance.Options.UseForeColor = True
        Me.CmdCopy.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdCopy.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdCopy.Location = New System.Drawing.Point(404, 526)
        Me.CmdCopy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdCopy.TabIndex = 15
        '
        'CmdDelete
        '
        Me.CmdDelete.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdDelete.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdDelete.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdDelete.Appearance.Options.UseBackColor = True
        Me.CmdDelete.Appearance.Options.UseFont = True
        Me.CmdDelete.Appearance.Options.UseForeColor = True
        Me.CmdDelete.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdDelete.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdDelete.Location = New System.Drawing.Point(324, 526)
        Me.CmdDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdDelete.TabIndex = 14
        '
        'CmdPrint
        '
        Me.CmdPrint.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdPrint.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdPrint.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdPrint.Appearance.Options.UseBackColor = True
        Me.CmdPrint.Appearance.Options.UseFont = True
        Me.CmdPrint.Appearance.Options.UseForeColor = True
        Me.CmdPrint.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdPrint.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdPrint.Location = New System.Drawing.Point(164, 526)
        Me.CmdPrint.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdPrint.TabIndex = 12
        '
        'CmdNew
        '
        Me.CmdNew.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdNew.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdNew.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdNew.Appearance.Options.UseBackColor = True
        Me.CmdNew.Appearance.Options.UseFont = True
        Me.CmdNew.Appearance.Options.UseForeColor = True
        Me.CmdNew.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdNew.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdNew.Location = New System.Drawing.Point(84, 526)
        Me.CmdNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdNew.TabIndex = 11
        '
        'CmdCancel
        '
        Me.CmdCancel.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdCancel.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdCancel.Appearance.Options.UseBackColor = True
        Me.CmdCancel.Appearance.Options.UseFont = True
        Me.CmdCancel.Appearance.Options.UseForeColor = True
        Me.CmdCancel.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdCancel.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdCancel.Location = New System.Drawing.Point(244, 526)
        Me.CmdCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdCancel.TabIndex = 13
        '
        'CmdPhan_Bo
        '
        Me.CmdPhan_Bo.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdPhan_Bo.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdPhan_Bo.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdPhan_Bo.Appearance.Options.UseBackColor = True
        Me.CmdPhan_Bo.Appearance.Options.UseFont = True
        Me.CmdPhan_Bo.Appearance.Options.UseForeColor = True
        Me.CmdPhan_Bo.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdPhan_Bo.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdPhan_Bo.Location = New System.Drawing.Point(931, 526)
        Me.CmdPhan_Bo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmdPhan_Bo.TabIndex = 19
        '
        'TxtUser_id
        '
        Me.TxtUser_id.Location = New System.Drawing.Point(648, 529)
        Me.TxtUser_id.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtUser_id.TabIndex = 18
        '
        'CbbMa_GD
        '
        Me.CbbMa_GD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbMa_GD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbbMa_GD.ForeColor = System.Drawing.Color.Navy
        Me.CbbMa_GD.FormattingEnabled = True
        Me.CbbMa_GD.Location = New System.Drawing.Point(258, 33)
        Me.CbbMa_GD.Name = "CbbMa_GD"
        Me.CbbMa_GD.Size = New System.Drawing.Size(158, 23)
        Me.CbbMa_GD.TabIndex = 2
        '
        'LabNgay_LCt
        '
        Me.LabNgay_LCt.BackColor = System.Drawing.Color.Transparent
        Me.LabNgay_LCt.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LabNgay_LCt.ForeColor = System.Drawing.Color.Navy
        Me.LabNgay_LCt.Location = New System.Drawing.Point(2, 42)
        Me.LabNgay_LCt.Name = "LabNgay_LCt"
        Me.LabNgay_LCt.Size = New System.Drawing.Size(78, 13)
        Me.LabNgay_LCt.TabIndex = 144
        Me.LabNgay_LCt.Tag = "Create date"
        Me.LabNgay_LCt.Text = "Ngày Lập"
        '
        'LabNgay_Ct
        '
        Me.LabNgay_Ct.BackColor = System.Drawing.Color.Transparent
        Me.LabNgay_Ct.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LabNgay_Ct.ForeColor = System.Drawing.Color.Navy
        Me.LabNgay_Ct.Location = New System.Drawing.Point(2, 61)
        Me.LabNgay_Ct.Name = "LabNgay_Ct"
        Me.LabNgay_Ct.Size = New System.Drawing.Size(78, 13)
        Me.LabNgay_Ct.TabIndex = 143
        Me.LabNgay_Ct.Tag = "Voucher date"
        Me.LabNgay_Ct.Text = "Ngày c.từ"
        '
        'LabDien_Giai
        '
        Me.LabDien_Giai.BackColor = System.Drawing.Color.Transparent
        Me.LabDien_Giai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabDien_Giai.ForeColor = System.Drawing.Color.Navy
        Me.LabDien_Giai.Location = New System.Drawing.Point(640, 96)
        Me.LabDien_Giai.Margin = New System.Windows.Forms.Padding(0)
        Me.LabDien_Giai.Name = "LabDien_Giai"
        Me.LabDien_Giai.Size = New System.Drawing.Size(64, 15)
        Me.LabDien_Giai.TabIndex = 139
        Me.LabDien_Giai.Tag = "Note"
        Me.LabDien_Giai.Text = "Diễn giải"
        '
        'lblLoai_ct
        '
        Me.lblLoai_ct.BackColor = System.Drawing.Color.Transparent
        Me.lblLoai_ct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoai_ct.ForeColor = System.Drawing.Color.Navy
        Me.lblLoai_ct.Location = New System.Drawing.Point(182, 37)
        Me.lblLoai_ct.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLoai_ct.Name = "lblLoai_ct"
        Me.lblLoai_ct.Size = New System.Drawing.Size(70, 15)
        Me.lblLoai_ct.TabIndex = 138
        Me.lblLoai_ct.Tag = "Voucher style"
        Me.lblLoai_ct.Text = "Loại phiếu"
        '
        'lblSo_ct
        '
        Me.lblSo_ct.BackColor = System.Drawing.Color.Transparent
        Me.lblSo_ct.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblSo_ct.ForeColor = System.Drawing.Color.Navy
        Me.lblSo_ct.Location = New System.Drawing.Point(182, 61)
        Me.lblSo_ct.Name = "lblSo_ct"
        Me.lblSo_ct.Size = New System.Drawing.Size(70, 13)
        Me.lblSo_ct.TabIndex = 135
        Me.lblSo_ct.Tag = "Voucher no."
        Me.lblSo_ct.Text = "Số kế hoạch"
        '
        'txtSo_ct
        '
        Me.txtSo_ct.BackColor = System.Drawing.Color.White
        Me.txtSo_ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSo_ct.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtSo_ct.ForeColor = System.Drawing.Color.Navy
        Me.txtSo_ct.Location = New System.Drawing.Point(258, 59)
        Me.txtSo_ct.Name = "txtSo_ct"
        Me.txtSo_ct.Size = New System.Drawing.Size(158, 21)
        Me.txtSo_ct.TabIndex = 3
        Me.txtSo_ct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNgay_LCt
        '
        Me.TxtNgay_LCt.BackColor = System.Drawing.Color.White
        Me.TxtNgay_LCt.Flags = 65536
        Me.TxtNgay_LCt.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtNgay_LCt.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_LCt.isEmpty = True
        Me.TxtNgay_LCt.Location = New System.Drawing.Point(80, 37)
        Me.TxtNgay_LCt.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_LCt.MaxLength = 10
        Me.TxtNgay_LCt.Name = "TxtNgay_LCt"
        Me.TxtNgay_LCt.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_LCt.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_LCt.ReadOnly = True
        Me.TxtNgay_LCt.ShowDayBeforeMonth = False
        Me.TxtNgay_LCt.Size = New System.Drawing.Size(102, 21)
        Me.TxtNgay_LCt.TabIndex = 0
        Me.TxtNgay_LCt.Text = "18/09/2011"
        Me.TxtNgay_LCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_LCt.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'TxtNgay_Ct
        '
        Me.TxtNgay_Ct.BackColor = System.Drawing.Color.White
        Me.TxtNgay_Ct.Flags = 65536
        Me.TxtNgay_Ct.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtNgay_Ct.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_Ct.isEmpty = True
        Me.TxtNgay_Ct.Location = New System.Drawing.Point(80, 59)
        Me.TxtNgay_Ct.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_Ct.MaxLength = 10
        Me.TxtNgay_Ct.Name = "TxtNgay_Ct"
        Me.TxtNgay_Ct.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_Ct.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_Ct.ReadOnly = True
        Me.TxtNgay_Ct.ShowDayBeforeMonth = False
        Me.TxtNgay_Ct.Size = New System.Drawing.Size(102, 21)
        Me.TxtNgay_Ct.TabIndex = 1
        Me.TxtNgay_Ct.Text = "18/09/2011"
        Me.TxtNgay_Ct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_Ct.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxLine.Location = New System.Drawing.Point(0, 82)
        Me.GroupBoxLine.Name = "GroupBoxLine"
        Me.GroupBoxLine.Size = New System.Drawing.Size(1083, 8)
        Me.GroupBoxLine.TabIndex = 156
        Me.GroupBoxLine.TabStop = False
        '
        'TxtT_Tien_NT
        '
        Me.TxtT_Tien_NT.AllowNegative = True
        Me.TxtT_Tien_NT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien_NT.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien_NT.Enabled = False
        Me.TxtT_Tien_NT.Flags = 7680
        Me.TxtT_Tien_NT.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien_NT.InputMask = "### ### ### ### ###.#"
        Me.TxtT_Tien_NT.Location = New System.Drawing.Point(777, 533)
        Me.TxtT_Tien_NT.MaxWholeDigits = 16
        Me.TxtT_Tien_NT.Name = "TxtT_Tien_NT"
        Me.TxtT_Tien_NT.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien_NT.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien_NT.ReadOnly = True
        Me.TxtT_Tien_NT.Size = New System.Drawing.Size(22, 20)
        Me.TxtT_Tien_NT.TabIndex = 158
        Me.TxtT_Tien_NT.Text = "1.0"
        Me.TxtT_Tien_NT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Tien_NT.Visible = False
        '
        'TxtT_Tien
        '
        Me.TxtT_Tien.AllowNegative = True
        Me.TxtT_Tien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien.Enabled = False
        Me.TxtT_Tien.Flags = 7680
        Me.TxtT_Tien.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien.InputMask = "### ### ### ### ###.#"
        Me.TxtT_Tien.Location = New System.Drawing.Point(752, 538)
        Me.TxtT_Tien.MaxWholeDigits = 16
        Me.TxtT_Tien.Name = "TxtT_Tien"
        Me.TxtT_Tien.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien.ReadOnly = True
        Me.TxtT_Tien.Size = New System.Drawing.Size(39, 20)
        Me.TxtT_Tien.TabIndex = 159
        Me.TxtT_Tien.Text = "1.0"
        Me.TxtT_Tien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Tien.Visible = False
        '
        'LabT_TT_NT
        '
        Me.LabT_TT_NT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabT_TT_NT.AutoSize = True
        Me.LabT_TT_NT.BackColor = System.Drawing.Color.Transparent
        Me.LabT_TT_NT.Enabled = False
        Me.LabT_TT_NT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabT_TT_NT.ForeColor = System.Drawing.Color.Navy
        Me.LabT_TT_NT.Location = New System.Drawing.Point(735, 545)
        Me.LabT_TT_NT.Margin = New System.Windows.Forms.Padding(0)
        Me.LabT_TT_NT.Name = "LabT_TT_NT"
        Me.LabT_TT_NT.Size = New System.Drawing.Size(59, 13)
        Me.LabT_TT_NT.TabIndex = 160
        Me.LabT_TT_NT.Tag = "Total"
        Me.LabT_TT_NT.Text = "Tổng cộng"
        Me.LabT_TT_NT.Visible = False
        '
        'TxtMa_Dvcs
        '
        Me.TxtMa_Dvcs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMa_Dvcs.BackColor = System.Drawing.Color.White
        Me.TxtMa_Dvcs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMa_Dvcs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMa_Dvcs.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Dvcs.Location = New System.Drawing.Point(824, 532)
        Me.TxtMa_Dvcs.Name = "TxtMa_Dvcs"
        Me.TxtMa_Dvcs.Size = New System.Drawing.Size(21, 21)
        Me.TxtMa_Dvcs.TabIndex = 161
        Me.TxtMa_Dvcs.TabStop = False
        Me.TxtMa_Dvcs.Visible = False
        '
        'TxtStt_Rec
        '
        Me.TxtStt_Rec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtStt_Rec.BackColor = System.Drawing.Color.White
        Me.TxtStt_Rec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStt_Rec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStt_Rec.ForeColor = System.Drawing.Color.Navy
        Me.TxtStt_Rec.Location = New System.Drawing.Point(797, 532)
        Me.TxtStt_Rec.Name = "TxtStt_Rec"
        Me.TxtStt_Rec.Size = New System.Drawing.Size(21, 21)
        Me.TxtStt_Rec.TabIndex = 21
        Me.TxtStt_Rec.TabStop = False
        Me.TxtStt_Rec.Visible = False
        '
        'PopupMenuMasterGrid
        '
        Me.PopupMenuMasterGrid.Name = "PopupMenuMasterGrid"
        '
        'TxtT_Tien2
        '
        Me.TxtT_Tien2.AllowNegative = True
        Me.TxtT_Tien2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien2.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien2.Enabled = False
        Me.TxtT_Tien2.Flags = 7680
        Me.TxtT_Tien2.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien2.InputMask = "### ### ### ### ###.#"
        Me.TxtT_Tien2.Location = New System.Drawing.Point(777, 533)
        Me.TxtT_Tien2.MaxWholeDigits = 16
        Me.TxtT_Tien2.Name = "TxtT_Tien2"
        Me.TxtT_Tien2.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien2.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien2.ReadOnly = True
        Me.TxtT_Tien2.Size = New System.Drawing.Size(68, 20)
        Me.TxtT_Tien2.TabIndex = 252
        Me.TxtT_Tien2.Text = "1.0"
        Me.TxtT_Tien2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Tien2.Visible = False
        '
        'TxtT_Tien_NT2
        '
        Me.TxtT_Tien_NT2.AllowNegative = True
        Me.TxtT_Tien_NT2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien_NT2.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien_NT2.Enabled = False
        Me.TxtT_Tien_NT2.Flags = 7680
        Me.TxtT_Tien_NT2.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien_NT2.InputMask = "### ### ### ### ###.#"
        Me.TxtT_Tien_NT2.Location = New System.Drawing.Point(777, 533)
        Me.TxtT_Tien_NT2.MaxWholeDigits = 16
        Me.TxtT_Tien_NT2.Name = "TxtT_Tien_NT2"
        Me.TxtT_Tien_NT2.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien_NT2.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien_NT2.ReadOnly = True
        Me.TxtT_Tien_NT2.Size = New System.Drawing.Size(85, 20)
        Me.TxtT_Tien_NT2.TabIndex = 251
        Me.TxtT_Tien_NT2.Text = "1.0"
        Me.TxtT_Tien_NT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Tien_NT2.Visible = False
        '
        'TxtT_Tien3
        '
        Me.TxtT_Tien3.AllowNegative = True
        Me.TxtT_Tien3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien3.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien3.Enabled = False
        Me.TxtT_Tien3.Flags = 7680
        Me.TxtT_Tien3.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien3.InputMask = "### ### ### ### ###.#"
        Me.TxtT_Tien3.Location = New System.Drawing.Point(777, 533)
        Me.TxtT_Tien3.MaxWholeDigits = 16
        Me.TxtT_Tien3.Name = "TxtT_Tien3"
        Me.TxtT_Tien3.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien3.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien3.ReadOnly = True
        Me.TxtT_Tien3.Size = New System.Drawing.Size(55, 20)
        Me.TxtT_Tien3.TabIndex = 254
        Me.TxtT_Tien3.Text = "1.0"
        Me.TxtT_Tien3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Tien3.Visible = False
        '
        'TxtT_Tien_NT3
        '
        Me.TxtT_Tien_NT3.AllowNegative = True
        Me.TxtT_Tien_NT3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien_NT3.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien_NT3.Enabled = False
        Me.TxtT_Tien_NT3.Flags = 7680
        Me.TxtT_Tien_NT3.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien_NT3.InputMask = "### ### ### ### ###.#"
        Me.TxtT_Tien_NT3.Location = New System.Drawing.Point(777, 533)
        Me.TxtT_Tien_NT3.MaxWholeDigits = 16
        Me.TxtT_Tien_NT3.Name = "TxtT_Tien_NT3"
        Me.TxtT_Tien_NT3.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien_NT3.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien_NT3.ReadOnly = True
        Me.TxtT_Tien_NT3.Size = New System.Drawing.Size(68, 20)
        Me.TxtT_Tien_NT3.TabIndex = 253
        Me.TxtT_Tien_NT3.Text = "1.0"
        Me.TxtT_Tien_NT3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Tien_NT3.Visible = False
        '
        'TxtT_Ps
        '
        Me.TxtT_Ps.AllowNegative = True
        Me.TxtT_Ps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Ps.BackColor = System.Drawing.Color.White
        Me.TxtT_Ps.Enabled = False
        Me.TxtT_Ps.Flags = 7680
        Me.TxtT_Ps.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Ps.InputMask = "### ### ### ### ###.#"
        Me.TxtT_Ps.Location = New System.Drawing.Point(777, 533)
        Me.TxtT_Ps.MaxWholeDigits = 16
        Me.TxtT_Ps.Name = "TxtT_Ps"
        Me.TxtT_Ps.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Ps.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Ps.ReadOnly = True
        Me.TxtT_Ps.Size = New System.Drawing.Size(32, 20)
        Me.TxtT_Ps.TabIndex = 256
        Me.TxtT_Ps.Text = "1.0"
        Me.TxtT_Ps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Ps.Visible = False
        '
        'TxtT_Ps_NT
        '
        Me.TxtT_Ps_NT.AllowNegative = True
        Me.TxtT_Ps_NT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Ps_NT.BackColor = System.Drawing.Color.White
        Me.TxtT_Ps_NT.Enabled = False
        Me.TxtT_Ps_NT.Flags = 7680
        Me.TxtT_Ps_NT.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Ps_NT.InputMask = "### ### ### ### ###.#"
        Me.TxtT_Ps_NT.Location = New System.Drawing.Point(777, 533)
        Me.TxtT_Ps_NT.MaxWholeDigits = 16
        Me.TxtT_Ps_NT.Name = "TxtT_Ps_NT"
        Me.TxtT_Ps_NT.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Ps_NT.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Ps_NT.ReadOnly = True
        Me.TxtT_Ps_NT.Size = New System.Drawing.Size(41, 20)
        Me.TxtT_Ps_NT.TabIndex = 255
        Me.TxtT_Ps_NT.Text = "1.0"
        Me.TxtT_Ps_NT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Ps_NT.Visible = False
        '
        'txtTen_HS_H
        '
        Me.txtTen_HS_H.BackColor = System.Drawing.Color.White
        Me.txtTen_HS_H.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTen_HS_H.ForeColor = System.Drawing.Color.Navy
        Me.txtTen_HS_H.Location = New System.Drawing.Point(185, 115)
        Me.txtTen_HS_H.Name = "txtTen_HS_H"
        Me.txtTen_HS_H.ReadOnly = True
        Me.txtTen_HS_H.Size = New System.Drawing.Size(437, 20)
        Me.txtTen_HS_H.TabIndex = 9
        Me.txtTen_HS_H.TabStop = False
        '
        'txtMa_HS_H
        '
        Me.txtMa_HS_H._ActilookupPopup = False
        Me.txtMa_HS_H.CyberActilookupPopup = True
        Me.txtMa_HS_H.Dv_ListDetail = Nothing
        Me.txtMa_HS_H.Dv_Master = Nothing
        Me.txtMa_HS_H.FilterClient = Nothing
        Me.txtMa_HS_H.FilterSQL = Nothing
        Me.txtMa_HS_H.Location = New System.Drawing.Point(80, 115)
        Me.txtMa_HS_H.Name = "txtMa_HS_H"
        Me.txtMa_HS_H.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMa_HS_H.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.txtMa_HS_H.Properties.Appearance.Options.UseFont = True
        Me.txtMa_HS_H.Properties.Appearance.Options.UseForeColor = True
        Me.txtMa_HS_H.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.txtMa_HS_H.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.txtMa_HS_H.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.txtMa_HS_H.Size = New System.Drawing.Size(102, 20)
        Me.txtMa_HS_H.TabIndex = 7
        Me.txtMa_HS_H.Table_Name = Nothing
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(2, 117)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 15)
        Me.Label5.TabIndex = 261
        Me.Label5.Tag = "Employee"
        Me.Label5.Text = "Nhân viên"
        '
        'txtTen_BP_H
        '
        Me.txtTen_BP_H.BackColor = System.Drawing.Color.White
        Me.txtTen_BP_H.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTen_BP_H.ForeColor = System.Drawing.Color.Navy
        Me.txtTen_BP_H.Location = New System.Drawing.Point(185, 93)
        Me.txtTen_BP_H.Name = "txtTen_BP_H"
        Me.txtTen_BP_H.ReadOnly = True
        Me.txtTen_BP_H.Size = New System.Drawing.Size(437, 20)
        Me.txtTen_BP_H.TabIndex = 7
        Me.txtTen_BP_H.TabStop = False
        '
        'TxtMa_Bp_H
        '
        Me.TxtMa_Bp_H._ActilookupPopup = False
        Me.TxtMa_Bp_H.CyberActilookupPopup = True
        Me.TxtMa_Bp_H.Dv_ListDetail = Nothing
        Me.TxtMa_Bp_H.Dv_Master = Nothing
        Me.TxtMa_Bp_H.FilterClient = Nothing
        Me.TxtMa_Bp_H.FilterSQL = Nothing
        Me.TxtMa_Bp_H.Location = New System.Drawing.Point(80, 93)
        Me.TxtMa_Bp_H.Name = "TxtMa_Bp_H"
        Me.TxtMa_Bp_H.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtMa_Bp_H.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Bp_H.Properties.Appearance.Options.UseFont = True
        Me.TxtMa_Bp_H.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_Bp_H.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtMa_Bp_H.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtMa_Bp_H.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_Bp_H.Size = New System.Drawing.Size(102, 20)
        Me.TxtMa_Bp_H.TabIndex = 6
        Me.TxtMa_Bp_H.Table_Name = Nothing
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(2, 97)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 15)
        Me.Label4.TabIndex = 259
        Me.Label4.Tag = "Dept."
        Me.Label4.Text = "Bộ phận"
        '
        'CbbNam
        '
        Me.CbbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbNam.ForeColor = System.Drawing.Color.Navy
        Me.CbbNam.FormattingEnabled = True
        Me.CbbNam.Location = New System.Drawing.Point(512, 58)
        Me.CbbNam.Name = "CbbNam"
        Me.CbbNam.Size = New System.Drawing.Size(110, 21)
        Me.CbbNam.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(440, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 513
        Me.Label3.Tag = "Year"
        Me.Label3.Text = "Năm"
        '
        'CbbThang
        '
        Me.CbbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbThang.ForeColor = System.Drawing.Color.Navy
        Me.CbbThang.FormattingEnabled = True
        Me.CbbThang.Location = New System.Drawing.Point(512, 34)
        Me.CbbThang.Name = "CbbThang"
        Me.CbbThang.Size = New System.Drawing.Size(110, 21)
        Me.CbbThang.TabIndex = 4
        '
        'LabM_month1
        '
        Me.LabM_month1.AutoSize = True
        Me.LabM_month1.Location = New System.Drawing.Point(440, 37)
        Me.LabM_month1.Name = "LabM_month1"
        Me.LabM_month1.Size = New System.Drawing.Size(38, 13)
        Me.LabM_month1.TabIndex = 512
        Me.LabM_month1.Tag = "Month"
        Me.LabM_month1.Text = "Tháng"
        '
        'txtDien_giai
        '
        Me.txtDien_giai.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDien_giai.BackColor = System.Drawing.Color.White
        Me.txtDien_giai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDien_giai.ForeColor = System.Drawing.Color.Navy
        Me.txtDien_giai.Location = New System.Drawing.Point(705, 93)
        Me.txtDien_giai.Multiline = True
        Me.txtDien_giai.Name = "txtDien_giai"
        Me.txtDien_giai.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDien_giai.Size = New System.Drawing.Size(378, 41)
        Me.txtDien_giai.TabIndex = 8
        '
        'TxtT_SO_LUONG
        '
        Me.TxtT_SO_LUONG.AllowNegative = True
        Me.TxtT_SO_LUONG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_SO_LUONG.BackColor = System.Drawing.Color.White
        Me.TxtT_SO_LUONG.Flags = 7680
        Me.TxtT_SO_LUONG.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_SO_LUONG.InputMask = "### ### ### ### ###.#"
        Me.TxtT_SO_LUONG.Location = New System.Drawing.Point(328, 502)
        Me.TxtT_SO_LUONG.MaxWholeDigits = 16
        Me.TxtT_SO_LUONG.Name = "TxtT_SO_LUONG"
        Me.TxtT_SO_LUONG.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_SO_LUONG.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_SO_LUONG.ReadOnly = True
        Me.TxtT_SO_LUONG.Size = New System.Drawing.Size(74, 20)
        Me.TxtT_SO_LUONG.TabIndex = 174
        Me.TxtT_SO_LUONG.Text = "0.0"
        Me.TxtT_SO_LUONG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTien_NT1
        '
        Me.TxtTien_NT1.AllowNegative = True
        Me.TxtTien_NT1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtTien_NT1.BackColor = System.Drawing.Color.White
        Me.TxtTien_NT1.Flags = 7680
        Me.TxtTien_NT1.ForeColor = System.Drawing.Color.Navy
        Me.TxtTien_NT1.InputMask = "### ### ### ### ###.#"
        Me.TxtTien_NT1.Location = New System.Drawing.Point(483, 500)
        Me.TxtTien_NT1.MaxWholeDigits = 16
        Me.TxtTien_NT1.Name = "TxtTien_NT1"
        Me.TxtTien_NT1.RangeMax = 1.7976931348623157E+308R
        Me.TxtTien_NT1.RangeMin = -1.7976931348623157E+308R
        Me.TxtTien_NT1.ReadOnly = True
        Me.TxtTien_NT1.Size = New System.Drawing.Size(74, 20)
        Me.TxtTien_NT1.TabIndex = 174
        Me.TxtTien_NT1.Text = "0.0"
        Me.TxtTien_NT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTien_NT2
        '
        Me.TxtTien_NT2.AllowNegative = True
        Me.TxtTien_NT2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtTien_NT2.BackColor = System.Drawing.Color.White
        Me.TxtTien_NT2.Flags = 7680
        Me.TxtTien_NT2.ForeColor = System.Drawing.Color.Navy
        Me.TxtTien_NT2.InputMask = "### ### ### ### ###.#"
        Me.TxtTien_NT2.Location = New System.Drawing.Point(643, 500)
        Me.TxtTien_NT2.MaxWholeDigits = 16
        Me.TxtTien_NT2.Name = "TxtTien_NT2"
        Me.TxtTien_NT2.RangeMax = 1.7976931348623157E+308R
        Me.TxtTien_NT2.RangeMin = -1.7976931348623157E+308R
        Me.TxtTien_NT2.ReadOnly = True
        Me.TxtTien_NT2.Size = New System.Drawing.Size(74, 20)
        Me.TxtTien_NT2.TabIndex = 174
        Me.TxtTien_NT2.Text = "0.0"
        Me.TxtTien_NT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTien_NT3
        '
        Me.TxtTien_NT3.AllowNegative = True
        Me.TxtTien_NT3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtTien_NT3.BackColor = System.Drawing.Color.White
        Me.TxtTien_NT3.Flags = 7680
        Me.TxtTien_NT3.ForeColor = System.Drawing.Color.Navy
        Me.TxtTien_NT3.InputMask = "### ### ### ### ###.#"
        Me.TxtTien_NT3.Location = New System.Drawing.Point(797, 499)
        Me.TxtTien_NT3.MaxWholeDigits = 16
        Me.TxtTien_NT3.Name = "TxtTien_NT3"
        Me.TxtTien_NT3.RangeMax = 1.7976931348623157E+308R
        Me.TxtTien_NT3.RangeMin = -1.7976931348623157E+308R
        Me.TxtTien_NT3.ReadOnly = True
        Me.TxtTien_NT3.Size = New System.Drawing.Size(74, 20)
        Me.TxtTien_NT3.TabIndex = 174
        Me.TxtTien_NT3.Text = "0.0"
        Me.TxtTien_NT3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTien_NT4
        '
        Me.TxtTien_NT4.AllowNegative = True
        Me.TxtTien_NT4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtTien_NT4.BackColor = System.Drawing.Color.White
        Me.TxtTien_NT4.Flags = 7680
        Me.TxtTien_NT4.ForeColor = System.Drawing.Color.Navy
        Me.TxtTien_NT4.InputMask = "### ### ### ### ###.#"
        Me.TxtTien_NT4.Location = New System.Drawing.Point(950, 499)
        Me.TxtTien_NT4.MaxWholeDigits = 16
        Me.TxtTien_NT4.Name = "TxtTien_NT4"
        Me.TxtTien_NT4.RangeMax = 1.7976931348623157E+308R
        Me.TxtTien_NT4.RangeMin = -1.7976931348623157E+308R
        Me.TxtTien_NT4.ReadOnly = True
        Me.TxtTien_NT4.Size = New System.Drawing.Size(74, 20)
        Me.TxtTien_NT4.TabIndex = 174
        Me.TxtTien_NT4.Text = "0.0"
        Me.TxtTien_NT4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNgay_LapKHBS
        '
        Me.TxtNgay_LapKHBS.BackColor = System.Drawing.Color.White
        Me.TxtNgay_LapKHBS.Flags = 65536
        Me.TxtNgay_LapKHBS.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtNgay_LapKHBS.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_LapKHBS.isEmpty = True
        Me.TxtNgay_LapKHBS.Location = New System.Drawing.Point(495, 137)
        Me.TxtNgay_LapKHBS.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_LapKHBS.MaxLength = 10
        Me.TxtNgay_LapKHBS.Name = "TxtNgay_LapKHBS"
        Me.TxtNgay_LapKHBS.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_LapKHBS.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_LapKHBS.ReadOnly = True
        Me.TxtNgay_LapKHBS.ShowDayBeforeMonth = False
        Me.TxtNgay_LapKHBS.Size = New System.Drawing.Size(102, 21)
        Me.TxtNgay_LapKHBS.TabIndex = 524
        Me.TxtNgay_LapKHBS.Text = "18/09/2011"
        Me.TxtNgay_LapKHBS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_LapKHBS.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        Me.TxtNgay_LapKHBS.Visible = False
        '
        'LblNgay_lapKHBS
        '
        Me.LblNgay_lapKHBS.BackColor = System.Drawing.Color.Transparent
        Me.LblNgay_lapKHBS.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LblNgay_lapKHBS.ForeColor = System.Drawing.Color.Red
        Me.LblNgay_lapKHBS.Location = New System.Drawing.Point(417, 139)
        Me.LblNgay_lapKHBS.Name = "LblNgay_lapKHBS"
        Me.LblNgay_lapKHBS.Size = New System.Drawing.Size(78, 13)
        Me.LblNgay_lapKHBS.TabIndex = 525
        Me.LblNgay_lapKHBS.Tag = "Voucher date"
        Me.LblNgay_lapKHBS.Text = "Ngày lập KHBS"
        Me.LblNgay_lapKHBS.Visible = False
        '
        'LblLan_KHBS
        '
        Me.LblLan_KHBS.BackColor = System.Drawing.Color.Transparent
        Me.LblLan_KHBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LblLan_KHBS.ForeColor = System.Drawing.Color.Red
        Me.LblLan_KHBS.Location = New System.Drawing.Point(311, 141)
        Me.LblLan_KHBS.Margin = New System.Windows.Forms.Padding(0)
        Me.LblLan_KHBS.Name = "LblLan_KHBS"
        Me.LblLan_KHBS.Size = New System.Drawing.Size(33, 15)
        Me.LblLan_KHBS.TabIndex = 523
        Me.LblLan_KHBS.Tag = "Total"
        Me.LblLan_KHBS.Text = "Lần"
        Me.LblLan_KHBS.Visible = False
        '
        'TxtLan_KHBS
        '
        Me.TxtLan_KHBS.AllowNegative = True
        Me.TxtLan_KHBS.BackColor = System.Drawing.Color.White
        Me.TxtLan_KHBS.Flags = 7680
        Me.TxtLan_KHBS.ForeColor = System.Drawing.Color.Navy
        Me.TxtLan_KHBS.InputMask = "### ### ### ### ###"
        Me.TxtLan_KHBS.Location = New System.Drawing.Point(343, 137)
        Me.TxtLan_KHBS.MaxWholeDigits = 14
        Me.TxtLan_KHBS.Name = "TxtLan_KHBS"
        Me.TxtLan_KHBS.RangeMax = 1.7976931348623157E+308R
        Me.TxtLan_KHBS.RangeMin = -1.7976931348623157E+308R
        Me.TxtLan_KHBS.ReadOnly = True
        Me.TxtLan_KHBS.Size = New System.Drawing.Size(60, 20)
        Me.TxtLan_KHBS.TabIndex = 522
        Me.TxtLan_KHBS.Text = "0"
        Me.TxtLan_KHBS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtLan_KHBS.Visible = False
        '
        'ChkKhai_bosung
        '
        Me.ChkKhai_bosung.AutoSize = True
        Me.ChkKhai_bosung.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkKhai_bosung.Location = New System.Drawing.Point(185, 139)
        Me.ChkKhai_bosung.Name = "ChkKhai_bosung"
        Me.ChkKhai_bosung.Size = New System.Drawing.Size(100, 17)
        Me.ChkKhai_bosung.TabIndex = 521
        Me.ChkKhai_bosung.Text = "Khai bổ sung"
        Me.ChkKhai_bosung.UseVisualStyleBackColor = True
        '
        'ChkKhai_landau
        '
        Me.ChkKhai_landau.AutoSize = True
        Me.ChkKhai_landau.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkKhai_landau.Location = New System.Drawing.Point(81, 138)
        Me.ChkKhai_landau.Name = "ChkKhai_landau"
        Me.ChkKhai_landau.Size = New System.Drawing.Size(98, 17)
        Me.ChkKhai_landau.TabIndex = 520
        Me.ChkKhai_landau.Text = "Khai lần đầu"
        Me.ChkKhai_landau.UseVisualStyleBackColor = True
        '
        'btnGetDetailTKT
        '
        Me.btnGetDetailTKT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetDetailTKT.ForeColor = System.Drawing.Color.Red
        Me.btnGetDetailTKT.Location = New System.Drawing.Point(643, 56)
        Me.btnGetDetailTKT.Name = "btnGetDetailTKT"
        Me.btnGetDetailTKT.Size = New System.Drawing.Size(100, 23)
        Me.btnGetDetailTKT.TabIndex = 526
        Me.btnGetDetailTKT.Text = "Lấy dữ liệu"
        Me.btnGetDetailTKT.UseVisualStyleBackColor = True
        '
        'TabToKhaiThue
        '
        Me.TabToKhaiThue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabToKhaiThue.Controls.Add(Me.TabTKT)
        Me.TabToKhaiThue.Controls.Add(Me.TabHH_DV_MuaVaoTrongKy)
        Me.TabToKhaiThue.Controls.Add(Me.TabHH_DV_BanRaTrongKy)
        Me.TabToKhaiThue.Location = New System.Drawing.Point(7, 185)
        Me.TabToKhaiThue.Name = "TabToKhaiThue"
        Me.TabToKhaiThue.SelectedIndex = 0
        Me.TabToKhaiThue.Size = New System.Drawing.Size(1069, 310)
        Me.TabToKhaiThue.TabIndex = 1834
        '
        'TabTKT
        '
        Me.TabTKT.Controls.Add(Me.Detail)
        Me.TabTKT.Controls.Add(Me.ChkIn_chi_tiet)
        Me.TabTKT.Controls.Add(Me.ChkIn_Bks)
        Me.TabTKT.Location = New System.Drawing.Point(4, 22)
        Me.TabTKT.Name = "TabTKT"
        Me.TabTKT.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTKT.Size = New System.Drawing.Size(1061, 284)
        Me.TabTKT.TabIndex = 2
        Me.TabTKT.Tag = "Parts"
        Me.TabTKT.Text = "Tờ khai thuế"
        Me.TabTKT.UseVisualStyleBackColor = True
        '
        'Detail
        '
        Me.Detail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Detail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Detail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Detail.Location = New System.Drawing.Point(3, 3)
        Me.Detail.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.Detail.MainView = Me.DetailGRV
        Me.Detail.Name = "Detail"
        Me.Detail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit5, Me.RepositoryItemTextEdit6})
        Me.Detail.Size = New System.Drawing.Size(1055, 278)
        Me.Detail.TabIndex = 9
        Me.Detail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DetailGRV})
        '
        'DetailGRV
        '
        Me.DetailGRV.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DetailGRV.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DetailGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red
        Me.DetailGRV.Appearance.SelectedRow.Options.UseBackColor = True
        Me.DetailGRV.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.DetailGRV.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DetailGRV.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DetailGRV.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.DetailGRV.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailGRV.AppearancePrint.EvenRow.Options.UseFont = True
        Me.DetailGRV.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.DetailGRV.CustomizationFormBounds = New System.Drawing.Rectangle(907, 465, 210, 172)
        Me.DetailGRV.GridControl = Me.Detail
        Me.DetailGRV.GroupRowHeight = 30
        Me.DetailGRV.Name = "DetailGRV"
        Me.DetailGRV.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.DetailGRV.OptionsLayout.Columns.AddNewColumns = False
        Me.DetailGRV.OptionsSelection.CheckBoxSelectorColumnWidth = 20
        Me.DetailGRV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.DetailGRV.OptionsView.ColumnAutoWidth = False
        Me.DetailGRV.OptionsView.ShowGroupPanel = False
        Me.DetailGRV.RowHeight = 21
        '
        'RepositoryItemTextEdit5
        '
        Me.RepositoryItemTextEdit5.AutoHeight = False
        Me.RepositoryItemTextEdit5.Name = "RepositoryItemTextEdit5"
        '
        'RepositoryItemTextEdit6
        '
        Me.RepositoryItemTextEdit6.AutoHeight = False
        Me.RepositoryItemTextEdit6.Name = "RepositoryItemTextEdit6"
        '
        'ChkIn_chi_tiet
        '
        Me.ChkIn_chi_tiet.AutoSize = True
        Me.ChkIn_chi_tiet.ForeColor = System.Drawing.Color.Red
        Me.ChkIn_chi_tiet.Location = New System.Drawing.Point(159, 82)
        Me.ChkIn_chi_tiet.Name = "ChkIn_chi_tiet"
        Me.ChkIn_chi_tiet.Size = New System.Drawing.Size(80, 17)
        Me.ChkIn_chi_tiet.TabIndex = 2121
        Me.ChkIn_chi_tiet.Tag = "Insurance from productor"
        Me.ChkIn_chi_tiet.Text = "In tổng hợp"
        Me.ChkIn_chi_tiet.UseVisualStyleBackColor = True
        Me.ChkIn_chi_tiet.Visible = False
        '
        'ChkIn_Bks
        '
        Me.ChkIn_Bks.AutoSize = True
        Me.ChkIn_Bks.ForeColor = System.Drawing.Color.Red
        Me.ChkIn_Bks.Location = New System.Drawing.Point(78, 82)
        Me.ChkIn_Bks.Name = "ChkIn_Bks"
        Me.ChkIn_Bks.Size = New System.Drawing.Size(72, 17)
        Me.ChkIn_Bks.TabIndex = 2120
        Me.ChkIn_Bks.Tag = "Insurance from productor"
        Me.ChkIn_Bks.Text = "In biển số"
        Me.ChkIn_Bks.UseVisualStyleBackColor = True
        Me.ChkIn_Bks.Visible = False
        '
        'TabHH_DV_MuaVaoTrongKy
        '
        Me.TabHH_DV_MuaVaoTrongKy.Controls.Add(Me.DetailMuaVao)
        Me.TabHH_DV_MuaVaoTrongKy.Location = New System.Drawing.Point(4, 22)
        Me.TabHH_DV_MuaVaoTrongKy.Name = "TabHH_DV_MuaVaoTrongKy"
        Me.TabHH_DV_MuaVaoTrongKy.Padding = New System.Windows.Forms.Padding(3)
        Me.TabHH_DV_MuaVaoTrongKy.Size = New System.Drawing.Size(1061, 307)
        Me.TabHH_DV_MuaVaoTrongKy.TabIndex = 1
        Me.TabHH_DV_MuaVaoTrongKy.Tag = "Jobs"
        Me.TabHH_DV_MuaVaoTrongKy.Text = "Hàng hóa DV mua vào"
        Me.TabHH_DV_MuaVaoTrongKy.UseVisualStyleBackColor = True
        '
        'DetailMuaVao
        '
        Me.DetailMuaVao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.DetailMuaVao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailMuaVao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailMuaVao.Location = New System.Drawing.Point(3, 3)
        Me.DetailMuaVao.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DetailMuaVao.MainView = Me.DetailGRVMuaVao
        Me.DetailMuaVao.Name = "DetailMuaVao"
        Me.DetailMuaVao.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit3, Me.RepositoryItemTextEdit4})
        Me.DetailMuaVao.Size = New System.Drawing.Size(1055, 301)
        Me.DetailMuaVao.TabIndex = 0
        Me.DetailMuaVao.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DetailGRVMuaVao})
        '
        'DetailGRVMuaVao
        '
        Me.DetailGRVMuaVao.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DetailGRVMuaVao.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DetailGRVMuaVao.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red
        Me.DetailGRVMuaVao.Appearance.SelectedRow.Options.UseBackColor = True
        Me.DetailGRVMuaVao.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.DetailGRVMuaVao.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DetailGRVMuaVao.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DetailGRVMuaVao.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.DetailGRVMuaVao.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailGRVMuaVao.AppearancePrint.EvenRow.Options.UseFont = True
        Me.DetailGRVMuaVao.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.DetailGRVMuaVao.CustomizationFormBounds = New System.Drawing.Rectangle(907, 465, 210, 172)
        Me.DetailGRVMuaVao.GridControl = Me.DetailMuaVao
        Me.DetailGRVMuaVao.GroupRowHeight = 30
        Me.DetailGRVMuaVao.Name = "DetailGRVMuaVao"
        Me.DetailGRVMuaVao.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.DetailGRVMuaVao.OptionsLayout.Columns.AddNewColumns = False
        Me.DetailGRVMuaVao.OptionsSelection.CheckBoxSelectorColumnWidth = 20
        Me.DetailGRVMuaVao.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.DetailGRVMuaVao.OptionsView.ColumnAutoWidth = False
        Me.DetailGRVMuaVao.OptionsView.ShowGroupPanel = False
        Me.DetailGRVMuaVao.RowHeight = 21
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        '
        'TabHH_DV_BanRaTrongKy
        '
        Me.TabHH_DV_BanRaTrongKy.Controls.Add(Me.DetailBanRa)
        Me.TabHH_DV_BanRaTrongKy.Location = New System.Drawing.Point(4, 22)
        Me.TabHH_DV_BanRaTrongKy.Name = "TabHH_DV_BanRaTrongKy"
        Me.TabHH_DV_BanRaTrongKy.Padding = New System.Windows.Forms.Padding(3)
        Me.TabHH_DV_BanRaTrongKy.Size = New System.Drawing.Size(1061, 307)
        Me.TabHH_DV_BanRaTrongKy.TabIndex = 3
        Me.TabHH_DV_BanRaTrongKy.Text = "Hàng hóa DV bán ra"
        Me.TabHH_DV_BanRaTrongKy.UseVisualStyleBackColor = True
        '
        'DetailBanRa
        '
        Me.DetailBanRa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.DetailBanRa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailBanRa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailBanRa.Location = New System.Drawing.Point(3, 3)
        Me.DetailBanRa.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DetailBanRa.MainView = Me.DetailGRVBanRa
        Me.DetailBanRa.Name = "DetailBanRa"
        Me.DetailBanRa.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2})
        Me.DetailBanRa.Size = New System.Drawing.Size(1055, 301)
        Me.DetailBanRa.TabIndex = 1
        Me.DetailBanRa.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DetailGRVBanRa})
        '
        'DetailGRVBanRa
        '
        Me.DetailGRVBanRa.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DetailGRVBanRa.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DetailGRVBanRa.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red
        Me.DetailGRVBanRa.Appearance.SelectedRow.Options.UseBackColor = True
        Me.DetailGRVBanRa.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.DetailGRVBanRa.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DetailGRVBanRa.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DetailGRVBanRa.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.DetailGRVBanRa.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailGRVBanRa.AppearancePrint.EvenRow.Options.UseFont = True
        Me.DetailGRVBanRa.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.DetailGRVBanRa.CustomizationFormBounds = New System.Drawing.Rectangle(907, 465, 210, 172)
        Me.DetailGRVBanRa.GridControl = Me.DetailBanRa
        Me.DetailGRVBanRa.GroupRowHeight = 30
        Me.DetailGRVBanRa.Name = "DetailGRVBanRa"
        Me.DetailGRVBanRa.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.DetailGRVBanRa.OptionsLayout.Columns.AddNewColumns = False
        Me.DetailGRVBanRa.OptionsSelection.CheckBoxSelectorColumnWidth = 20
        Me.DetailGRVBanRa.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.DetailGRVBanRa.OptionsView.ColumnAutoWidth = False
        Me.DetailGRVBanRa.OptionsView.ShowGroupPanel = False
        Me.DetailGRVBanRa.RowHeight = 21
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'btnExportXML
        '
        Me.btnExportXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportXML.ForeColor = System.Drawing.Color.Red
        Me.btnExportXML.Location = New System.Drawing.Point(643, 141)
        Me.btnExportXML.Name = "btnExportXML"
        Me.btnExportXML.Size = New System.Drawing.Size(100, 23)
        Me.btnExportXML.TabIndex = 1835
        Me.btnExportXML.Text = "Xuất XML"
        Me.btnExportXML.UseVisualStyleBackColor = True
        '
        'ChkPL_NQ142_GTGT
        '
        Me.ChkPL_NQ142_GTGT.AutoSize = True
        Me.ChkPL_NQ142_GTGT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPL_NQ142_GTGT.Location = New System.Drawing.Point(81, 161)
        Me.ChkPL_NQ142_GTGT.Name = "ChkPL_NQ142_GTGT"
        Me.ChkPL_NQ142_GTGT.Size = New System.Drawing.Size(128, 17)
        Me.ChkPL_NQ142_GTGT.TabIndex = 1836
        Me.ChkPL_NQ142_GTGT.Text = "PL_NQ142_GTGT"
        Me.ChkPL_NQ142_GTGT.UseVisualStyleBackColor = True
        '
        'ChkPL01_KHBS
        '
        Me.ChkPL01_KHBS.AutoSize = True
        Me.ChkPL01_KHBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPL01_KHBS.Location = New System.Drawing.Point(314, 159)
        Me.ChkPL01_KHBS.Name = "ChkPL01_KHBS"
        Me.ChkPL01_KHBS.Size = New System.Drawing.Size(95, 17)
        Me.ChkPL01_KHBS.TabIndex = 1837
        Me.ChkPL01_KHBS.Text = "PL01_KHBS"
        Me.ChkPL01_KHBS.UseVisualStyleBackColor = True
        Me.ChkPL01_KHBS.Visible = False
        '
        'ChkPL01_1_KHBS
        '
        Me.ChkPL01_1_KHBS.AutoSize = True
        Me.ChkPL01_1_KHBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPL01_1_KHBS.Location = New System.Drawing.Point(495, 161)
        Me.ChkPL01_1_KHBS.Name = "ChkPL01_1_KHBS"
        Me.ChkPL01_1_KHBS.Size = New System.Drawing.Size(109, 17)
        Me.ChkPL01_1_KHBS.TabIndex = 1838
        Me.ChkPL01_1_KHBS.Text = "PL01_1_KHBS"
        Me.ChkPL01_1_KHBS.UseVisualStyleBackColor = True
        Me.ChkPL01_1_KHBS.Visible = False
        '
        'TKT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1083, 583)
        Me.Controls.Add(Me.ChkPL01_1_KHBS)
        Me.Controls.Add(Me.ChkPL01_KHBS)
        Me.Controls.Add(Me.ChkPL_NQ142_GTGT)
        Me.Controls.Add(Me.btnExportXML)
        Me.Controls.Add(Me.TabToKhaiThue)
        Me.Controls.Add(Me.btnGetDetailTKT)
        Me.Controls.Add(Me.TxtNgay_LapKHBS)
        Me.Controls.Add(Me.LblNgay_lapKHBS)
        Me.Controls.Add(Me.LblLan_KHBS)
        Me.Controls.Add(Me.TxtLan_KHBS)
        Me.Controls.Add(Me.ChkKhai_bosung)
        Me.Controls.Add(Me.ChkKhai_landau)
        Me.Controls.Add(Me.txtDien_giai)
        Me.Controls.Add(Me.CbbNam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CbbThang)
        Me.Controls.Add(Me.LabM_month1)
        Me.Controls.Add(Me.txtTen_HS_H)
        Me.Controls.Add(Me.txtMa_HS_H)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTen_BP_H)
        Me.Controls.Add(Me.TxtMa_Bp_H)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabT_TT_NT)
        Me.Controls.Add(Me.TxtT_Tien)
        Me.Controls.Add(Me.TxtT_Tien_NT)
        Me.Controls.Add(Me.GroupBoxLine)
        Me.Controls.Add(Me.TxtNgay_LCt)
        Me.Controls.Add(Me.TxtNgay_Ct)
        Me.Controls.Add(Me.CbbMa_GD)
        Me.Controls.Add(Me.LabNgay_LCt)
        Me.Controls.Add(Me.LabNgay_Ct)
        Me.Controls.Add(Me.LabDien_Giai)
        Me.Controls.Add(Me.lblLoai_ct)
        Me.Controls.Add(Me.lblSo_ct)
        Me.Controls.Add(Me.txtSo_ct)
        Me.Controls.Add(Me.TxtStt_Rec)
        Me.Controls.Add(Me.TxtMa_Dvcs)
        Me.Controls.Add(Me.TxtT_Ps)
        Me.Controls.Add(Me.TxtT_Ps_NT)
        Me.Controls.Add(Me.TxtT_Tien3)
        Me.Controls.Add(Me.TxtT_Tien_NT3)
        Me.Controls.Add(Me.TxtT_Tien2)
        Me.Controls.Add(Me.TxtT_Tien_NT2)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(947, 557)
        Me.Name = "TKT"
        Me.Controls.SetChildIndex(Me.TxtT_Tien_NT2, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien2, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien_NT3, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien3, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Ps_NT, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Ps, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Dvcs, 0)
        Me.Controls.SetChildIndex(Me.TxtStt_Rec, 0)
        Me.Controls.SetChildIndex(Me.txtSo_ct, 0)
        Me.Controls.SetChildIndex(Me.lblSo_ct, 0)
        Me.Controls.SetChildIndex(Me.lblLoai_ct, 0)
        Me.Controls.SetChildIndex(Me.LabDien_Giai, 0)
        Me.Controls.SetChildIndex(Me.LabNgay_Ct, 0)
        Me.Controls.SetChildIndex(Me.LabNgay_LCt, 0)
        Me.Controls.SetChildIndex(Me.CbbMa_GD, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_Ct, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_LCt, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien_NT, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien, 0)
        Me.Controls.SetChildIndex(Me.LabT_TT_NT, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Bp_H, 0)
        Me.Controls.SetChildIndex(Me.txtTen_BP_H, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtMa_HS_H, 0)
        Me.Controls.SetChildIndex(Me.txtTen_HS_H, 0)
        Me.Controls.SetChildIndex(Me.LabM_month1, 0)
        Me.Controls.SetChildIndex(Me.CbbThang, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.CbbNam, 0)
        Me.Controls.SetChildIndex(Me.txtDien_giai, 0)
        Me.Controls.SetChildIndex(Me.ChkKhai_landau, 0)
        Me.Controls.SetChildIndex(Me.ChkKhai_bosung, 0)
        Me.Controls.SetChildIndex(Me.TxtLan_KHBS, 0)
        Me.Controls.SetChildIndex(Me.LblLan_KHBS, 0)
        Me.Controls.SetChildIndex(Me.LblNgay_lapKHBS, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_LapKHBS, 0)
        Me.Controls.SetChildIndex(Me.btnGetDetailTKT, 0)
        Me.Controls.SetChildIndex(Me.TabToKhaiThue, 0)
        Me.Controls.SetChildIndex(Me.TxtUser_id, 0)
        Me.Controls.SetChildIndex(Me.CmdPhan_Bo, 0)
        Me.Controls.SetChildIndex(Me.CmdNew, 0)
        Me.Controls.SetChildIndex(Me.CmdSave, 0)
        Me.Controls.SetChildIndex(Me.CmdPrint, 0)
        Me.Controls.SetChildIndex(Me.CmdEdit, 0)
        Me.Controls.SetChildIndex(Me.CmdCancel, 0)
        Me.Controls.SetChildIndex(Me.CmdDelete, 0)
        Me.Controls.SetChildIndex(Me.CmdCopy, 0)
        Me.Controls.SetChildIndex(Me.CmdSearch, 0)
        Me.Controls.SetChildIndex(Me.CmdExit, 0)
        Me.Controls.SetChildIndex(Me.CbbMa_Post, 0)
        Me.Controls.SetChildIndex(Me.CmdImport, 0)
        Me.Controls.SetChildIndex(Me.CmdSms, 0)
        Me.Controls.SetChildIndex(Me.LabMa_Post, 0)
        Me.Controls.SetChildIndex(Me.CmdView, 0)
        Me.Controls.SetChildIndex(Me.btnExportXML, 0)
        Me.Controls.SetChildIndex(Me.ChkPL_NQ142_GTGT, 0)
        Me.Controls.SetChildIndex(Me.ChkPL01_KHBS, 0)
        Me.Controls.SetChildIndex(Me.ChkPL01_1_KHBS, 0)
        CType(Me.PopupMenuMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuMasterGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMa_HS_H.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMa_Bp_H.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabToKhaiThue.ResumeLayout(False)
        Me.TabTKT.ResumeLayout(False)
        Me.TabTKT.PerformLayout()
        CType(Me.Detail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailGRV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabHH_DV_MuaVaoTrongKy.ResumeLayout(False)
        CType(Me.DetailMuaVao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailGRVMuaVao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabHH_DV_BanRaTrongKy.ResumeLayout(False)
        CType(Me.DetailBanRa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailGRVBanRa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbbMa_GD As System.Windows.Forms.ComboBox
    Friend WithEvents LabNgay_LCt As System.Windows.Forms.Label
    Friend WithEvents LabNgay_Ct As System.Windows.Forms.Label
    Friend WithEvents LabDien_Giai As System.Windows.Forms.Label
    Friend WithEvents lblLoai_ct As System.Windows.Forms.Label
    Friend WithEvents lblSo_ct As System.Windows.Forms.Label
    Friend WithEvents txtSo_ct As System.Windows.Forms.TextBox
    Friend WithEvents TxtNgay_LCt As ClsTextBox.txtDate
    Friend WithEvents TxtNgay_Ct As ClsTextBox.txtDate
    Friend WithEvents GroupBoxLine As System.Windows.Forms.GroupBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents TxtT_Tien_NT As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Tien As ClsTextBox.txtTien_NT
    Friend WithEvents LabT_TT_NT As System.Windows.Forms.Label
    Friend WithEvents TxtMa_Dvcs As System.Windows.Forms.TextBox
    Friend WithEvents TxtStt_Rec As System.Windows.Forms.TextBox
    Friend WithEvents PopupMenuMasterGrid As DevExpress.XtraBars.PopupMenu
    Friend WithEvents TxtT_Tien2 As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Tien_NT2 As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Tien3 As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Tien_NT3 As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Ps As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Ps_NT As ClsTextBox.txtTien_NT
    Friend WithEvents txtTen_HS_H As System.Windows.Forms.TextBox
    Friend WithEvents txtMa_HS_H As Cyber.SmLists.TxtLookup
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTen_BP_H As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_Bp_H As Cyber.SmLists.TxtLookup
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CbbNam As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbbThang As System.Windows.Forms.ComboBox
    Friend WithEvents LabM_month1 As System.Windows.Forms.Label
    Friend WithEvents txtDien_giai As System.Windows.Forms.TextBox
    Friend WithEvents TxtT_SO_LUONG As ClsTextBox.txtTien_NT
    Friend WithEvents TxtTien_NT1 As ClsTextBox.txtTien_NT
    Friend WithEvents TxtTien_NT2 As ClsTextBox.txtTien_NT
    Friend WithEvents TxtTien_NT3 As ClsTextBox.txtTien_NT
    Friend WithEvents TxtTien_NT4 As ClsTextBox.txtTien_NT
    Friend WithEvents TxtNgay_LapKHBS As ClsTextBox.txtDate
    Friend WithEvents LblNgay_lapKHBS As Label
    Friend WithEvents LblLan_KHBS As Label
    Friend WithEvents TxtLan_KHBS As ClsTextBox.txtTien_NT
    Friend WithEvents ChkKhai_bosung As CheckBox
    Friend WithEvents ChkKhai_landau As CheckBox
    Friend WithEvents btnGetDetailTKT As Button
    Friend WithEvents TabToKhaiThue As TabControl
    Friend WithEvents TabTKT As TabPage
    Friend WithEvents Detail As DevExpress.XtraGrid.GridControl
    Friend WithEvents DetailGRV As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ChkIn_chi_tiet As CheckBox
    Friend WithEvents ChkIn_Bks As CheckBox
    Friend WithEvents TabHH_DV_MuaVaoTrongKy As TabPage
    Friend WithEvents DetailMuaVao As DevExpress.XtraGrid.GridControl
    Friend WithEvents DetailGRVMuaVao As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents TabHH_DV_BanRaTrongKy As TabPage
    Friend WithEvents DetailBanRa As DevExpress.XtraGrid.GridControl
    Friend WithEvents DetailGRVBanRa As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents btnExportXML As Button
    Friend WithEvents ChkPL_NQ142_GTGT As CheckBox
    Friend WithEvents ChkPL01_KHBS As CheckBox
    Friend WithEvents ChkPL01_1_KHBS As CheckBox
End Class
