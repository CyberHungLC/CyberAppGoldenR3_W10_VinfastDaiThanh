<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLocRoPOD
    Inherits Cyber.From.FrmCalculator

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtT_Thue = New ClsTextBox.txtTien_NT()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TxtT_Tien2 = New ClsTextBox.txtTien_NT()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtSo_DN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNgay_Ct2 = New ClsTextBox.txtDate()
        Me.TxtNgay_Ct1 = New ClsTextBox.txtDate()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CmdLoc_Ro = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DetailRo_Master = New DevExpress.XtraGrid.GridControl()
        Me.DetailGRVRo_Master = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.DetailRo_DetailVt = New DevExpress.XtraGrid.GridControl()
        Me.DetailGRVRo_DetailVt = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit11 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit12 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.TxtTen_Hs = New System.Windows.Forms.TextBox()
        Me.lblMa_kh = New System.Windows.Forms.Label()
        Me.TxtMa_Hs = New Cyber.SmLists.TxtLookup()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSo_Ro_Hang = New System.Windows.Forms.TextBox()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TxtT_TT = New ClsTextBox.txtTien_NT()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DetailRo_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailGRVRo_Master, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailRo_DetailVt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailGRVRo_DetailVt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMa_Hs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Location = New System.Drawing.Point(4, 548)
        Me.GroupBoxLine.Size = New System.Drawing.Size(1070, 8)
        '
        'ButtOK
        '
        Me.ButtOK.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtOK.Appearance.Options.UseForeColor = True
        Me.ButtOK.Location = New System.Drawing.Point(868, 557)
        Me.ButtOK.Text = "&Chấp nhận"
        '
        'ButtExit
        '
        Me.ButtExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtExit.Appearance.Options.UseForeColor = True
        Me.ButtExit.Location = New System.Drawing.Point(970, 557)
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(375, 567)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 399
        Me.Label3.Tag = "Total "
        Me.Label3.Text = "Tổng cộng"
        '
        'TxtT_Thue
        '
        Me.TxtT_Thue.AllowNegative = True
        Me.TxtT_Thue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Thue.BackColor = System.Drawing.Color.White
        Me.TxtT_Thue.Flags = 7680
        Me.TxtT_Thue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtT_Thue.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Thue.InputMask = "### ### ### ### ### ###"
        Me.TxtT_Thue.Location = New System.Drawing.Point(243, 563)
        Me.TxtT_Thue.MaxWholeDigits = 17
        Me.TxtT_Thue.Name = "TxtT_Thue"
        Me.TxtT_Thue.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Thue.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Thue.ReadOnly = True
        Me.TxtT_Thue.Size = New System.Drawing.Size(123, 20)
        Me.TxtT_Thue.TabIndex = 391
        Me.TxtT_Thue.TabStop = False
        Me.TxtT_Thue.Text = "0"
        Me.TxtT_Thue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Navy
        Me.Label28.Location = New System.Drawing.Point(197, 566)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(32, 13)
        Me.Label28.TabIndex = 387
        Me.Label28.Tag = "Tax"
        Me.Label28.Text = "Thuế"
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Navy
        Me.Label27.Location = New System.Drawing.Point(10, 566)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(58, 13)
        Me.Label27.TabIndex = 386
        Me.Label27.Tag = "Amount"
        Me.Label27.Text = "Thành tiền"
        '
        'TxtT_Tien2
        '
        Me.TxtT_Tien2.AllowNegative = True
        Me.TxtT_Tien2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien2.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien2.Flags = 7680
        Me.TxtT_Tien2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtT_Tien2.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien2.InputMask = "### ### ### ### ### ###"
        Me.TxtT_Tien2.Location = New System.Drawing.Point(70, 563)
        Me.TxtT_Tien2.MaxWholeDigits = 17
        Me.TxtT_Tien2.Name = "TxtT_Tien2"
        Me.TxtT_Tien2.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien2.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien2.ReadOnly = True
        Me.TxtT_Tien2.Size = New System.Drawing.Size(123, 20)
        Me.TxtT_Tien2.TabIndex = 401
        Me.TxtT_Tien2.TabStop = False
        Me.TxtT_Tien2.Text = "0"
        Me.TxtT_Tien2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(309, 11)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 383
        Me.Label16.Tag = "Type (R/O)"
        Me.Label16.Text = "Số lệnh"
        Me.Label16.Visible = False
        '
        'TxtSo_DN
        '
        Me.TxtSo_DN.BackColor = System.Drawing.Color.White
        Me.TxtSo_DN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSo_DN.ForeColor = System.Drawing.Color.Navy
        Me.TxtSo_DN.Location = New System.Drawing.Point(369, 7)
        Me.TxtSo_DN.Name = "TxtSo_DN"
        Me.TxtSo_DN.Size = New System.Drawing.Size(134, 20)
        Me.TxtSo_DN.TabIndex = 2
        Me.TxtSo_DN.Tag = ""
        Me.TxtSo_DN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtSo_DN.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(154, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 382
        Me.Label2.Tag = "Date to"
        Me.Label2.Text = "Đến ngày"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 381
        Me.Label1.Tag = "Date from"
        Me.Label1.Text = "Từ ngày"
        '
        'TxtNgay_Ct2
        '
        Me.TxtNgay_Ct2.BackColor = System.Drawing.Color.White
        Me.TxtNgay_Ct2.Flags = 65536
        Me.TxtNgay_Ct2.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_Ct2.isEmpty = True
        Me.TxtNgay_Ct2.Location = New System.Drawing.Point(216, 7)
        Me.TxtNgay_Ct2.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_Ct2.MaxLength = 10
        Me.TxtNgay_Ct2.Name = "TxtNgay_Ct2"
        Me.TxtNgay_Ct2.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_Ct2.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_Ct2.ShowDayBeforeMonth = False
        Me.TxtNgay_Ct2.Size = New System.Drawing.Size(88, 20)
        Me.TxtNgay_Ct2.TabIndex = 1
        Me.TxtNgay_Ct2.Text = "18/09/2011"
        Me.TxtNgay_Ct2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_Ct2.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'TxtNgay_Ct1
        '
        Me.TxtNgay_Ct1.BackColor = System.Drawing.Color.White
        Me.TxtNgay_Ct1.Flags = 65536
        Me.TxtNgay_Ct1.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_Ct1.isEmpty = True
        Me.TxtNgay_Ct1.Location = New System.Drawing.Point(59, 7)
        Me.TxtNgay_Ct1.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_Ct1.MaxLength = 10
        Me.TxtNgay_Ct1.Name = "TxtNgay_Ct1"
        Me.TxtNgay_Ct1.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_Ct1.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_Ct1.ShowDayBeforeMonth = False
        Me.TxtNgay_Ct1.Size = New System.Drawing.Size(88, 20)
        Me.TxtNgay_Ct1.TabIndex = 0
        Me.TxtNgay_Ct1.Text = "18/09/2011"
        Me.TxtNgay_Ct1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_Ct1.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'GridView6
        '
        Me.GridView6.Name = "GridView6"
        '
        'GridView5
        '
        Me.GridView5.Name = "GridView5"
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'GridView3
        '
        Me.GridView3.Name = "GridView3"
        '
        'GridView4
        '
        Me.GridView4.Name = "GridView4"
        '
        'CmdLoc_Ro
        '
        Me.CmdLoc_Ro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdLoc_Ro.ForeColor = System.Drawing.Color.Navy
        Me.CmdLoc_Ro.Location = New System.Drawing.Point(951, 3)
        Me.CmdLoc_Ro.Name = "CmdLoc_Ro"
        Me.CmdLoc_Ro.Size = New System.Drawing.Size(117, 24)
        Me.CmdLoc_Ro.TabIndex = 5
        Me.CmdLoc_Ro.TabStop = False
        Me.CmdLoc_Ro.Tag = "&Find"
        Me.CmdLoc_Ro.Text = "&Lọc Phiếu"
        Me.CmdLoc_Ro.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 57)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DetailRo_Master)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DetailRo_DetailVt)
        Me.SplitContainer1.Size = New System.Drawing.Size(1070, 492)
        Me.SplitContainer1.SplitterDistance = 231
        Me.SplitContainer1.TabIndex = 402
        '
        'DetailRo_Master
        '
        Me.DetailRo_Master.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.DetailRo_Master.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailRo_Master.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailRo_Master.Location = New System.Drawing.Point(0, 0)
        Me.DetailRo_Master.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DetailRo_Master.MainView = Me.DetailGRVRo_Master
        Me.DetailRo_Master.Name = "DetailRo_Master"
        Me.DetailRo_Master.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2})
        Me.DetailRo_Master.Size = New System.Drawing.Size(1070, 231)
        Me.DetailRo_Master.TabIndex = 277
        Me.DetailRo_Master.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DetailGRVRo_Master})
        '
        'DetailGRVRo_Master
        '
        Me.DetailGRVRo_Master.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DetailGRVRo_Master.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DetailGRVRo_Master.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red
        Me.DetailGRVRo_Master.Appearance.SelectedRow.Options.UseBackColor = True
        Me.DetailGRVRo_Master.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.DetailGRVRo_Master.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DetailGRVRo_Master.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DetailGRVRo_Master.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.DetailGRVRo_Master.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailGRVRo_Master.AppearancePrint.EvenRow.Options.UseFont = True
        Me.DetailGRVRo_Master.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.DetailGRVRo_Master.CustomizationFormBounds = New System.Drawing.Rectangle(907, 465, 210, 172)
        Me.DetailGRVRo_Master.GridControl = Me.DetailRo_Master
        Me.DetailGRVRo_Master.GroupRowHeight = 30
        Me.DetailGRVRo_Master.Name = "DetailGRVRo_Master"
        Me.DetailGRVRo_Master.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.DetailGRVRo_Master.OptionsLayout.Columns.AddNewColumns = False
        Me.DetailGRVRo_Master.OptionsSelection.CheckBoxSelectorColumnWidth = 20
        Me.DetailGRVRo_Master.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.DetailGRVRo_Master.OptionsView.ColumnAutoWidth = False
        Me.DetailGRVRo_Master.OptionsView.ShowGroupPanel = False
        Me.DetailGRVRo_Master.RowHeight = 21
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
        'DetailRo_DetailVt
        '
        Me.DetailRo_DetailVt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.DetailRo_DetailVt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailRo_DetailVt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailRo_DetailVt.Location = New System.Drawing.Point(0, 0)
        Me.DetailRo_DetailVt.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DetailRo_DetailVt.MainView = Me.DetailGRVRo_DetailVt
        Me.DetailRo_DetailVt.Name = "DetailRo_DetailVt"
        Me.DetailRo_DetailVt.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit11, Me.RepositoryItemTextEdit12})
        Me.DetailRo_DetailVt.Size = New System.Drawing.Size(1070, 257)
        Me.DetailRo_DetailVt.TabIndex = 279
        Me.DetailRo_DetailVt.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DetailGRVRo_DetailVt})
        '
        'DetailGRVRo_DetailVt
        '
        Me.DetailGRVRo_DetailVt.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DetailGRVRo_DetailVt.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DetailGRVRo_DetailVt.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red
        Me.DetailGRVRo_DetailVt.Appearance.SelectedRow.Options.UseBackColor = True
        Me.DetailGRVRo_DetailVt.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.DetailGRVRo_DetailVt.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DetailGRVRo_DetailVt.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DetailGRVRo_DetailVt.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.DetailGRVRo_DetailVt.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailGRVRo_DetailVt.AppearancePrint.EvenRow.Options.UseFont = True
        Me.DetailGRVRo_DetailVt.CustomizationFormBounds = New System.Drawing.Rectangle(907, 465, 210, 172)
        Me.DetailGRVRo_DetailVt.GridControl = Me.DetailRo_DetailVt
        Me.DetailGRVRo_DetailVt.GroupRowHeight = 30
        Me.DetailGRVRo_DetailVt.Name = "DetailGRVRo_DetailVt"
        Me.DetailGRVRo_DetailVt.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.DetailGRVRo_DetailVt.OptionsLayout.Columns.AddNewColumns = False
        Me.DetailGRVRo_DetailVt.OptionsSelection.CheckBoxSelectorColumnWidth = 20
        Me.DetailGRVRo_DetailVt.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.DetailGRVRo_DetailVt.OptionsView.ColumnAutoWidth = False
        Me.DetailGRVRo_DetailVt.OptionsView.ShowGroupPanel = False
        Me.DetailGRVRo_DetailVt.RowHeight = 21
        '
        'RepositoryItemTextEdit11
        '
        Me.RepositoryItemTextEdit11.AutoHeight = False
        Me.RepositoryItemTextEdit11.Name = "RepositoryItemTextEdit11"
        '
        'RepositoryItemTextEdit12
        '
        Me.RepositoryItemTextEdit12.AutoHeight = False
        Me.RepositoryItemTextEdit12.Name = "RepositoryItemTextEdit12"
        '
        'TxtTen_Hs
        '
        Me.TxtTen_Hs.BackColor = System.Drawing.Color.White
        Me.TxtTen_Hs.Enabled = False
        Me.TxtTen_Hs.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_Hs.Location = New System.Drawing.Point(152, 30)
        Me.TxtTen_Hs.Name = "TxtTen_Hs"
        Me.TxtTen_Hs.ReadOnly = True
        Me.TxtTen_Hs.Size = New System.Drawing.Size(568, 20)
        Me.TxtTen_Hs.TabIndex = 377
        Me.TxtTen_Hs.Tag = ""
        '
        'lblMa_kh
        '
        Me.lblMa_kh.AutoSize = True
        Me.lblMa_kh.ForeColor = System.Drawing.Color.Navy
        Me.lblMa_kh.Location = New System.Drawing.Point(11, 34)
        Me.lblMa_kh.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMa_kh.Name = "lblMa_kh"
        Me.lblMa_kh.Size = New System.Drawing.Size(36, 13)
        Me.lblMa_kh.TabIndex = 380
        Me.lblMa_kh.Tag = "S.A"
        Me.lblMa_kh.Text = "CVDV"
        '
        'TxtMa_Hs
        '
        Me.TxtMa_Hs._ActilookupPopup = False
        Me.TxtMa_Hs.CyberActilookupPopup = True
        Me.TxtMa_Hs.Dv_ListDetail = Nothing
        Me.TxtMa_Hs.Dv_Master = Nothing
        Me.TxtMa_Hs.FilterClient = ""
        Me.TxtMa_Hs.FilterSQL = ""
        Me.TxtMa_Hs.Location = New System.Drawing.Point(59, 29)
        Me.TxtMa_Hs.Name = "TxtMa_Hs"
        Me.TxtMa_Hs.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMa_Hs.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Hs.Properties.Appearance.Options.UseFont = True
        Me.TxtMa_Hs.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_Hs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TxtMa_Hs.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_Hs.Size = New System.Drawing.Size(88, 22)
        Me.TxtMa_Hs.TabIndex = 4
        Me.TxtMa_Hs.Table_Name = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(513, 11)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 404
        Me.Label5.Tag = "Productor's R/o"
        Me.Label5.Text = "Số lệnh TMS"
        Me.Label5.Visible = False
        '
        'txtSo_Ro_Hang
        '
        Me.txtSo_Ro_Hang.BackColor = System.Drawing.Color.White
        Me.txtSo_Ro_Hang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSo_Ro_Hang.ForeColor = System.Drawing.Color.Navy
        Me.txtSo_Ro_Hang.Location = New System.Drawing.Point(586, 7)
        Me.txtSo_Ro_Hang.Name = "txtSo_Ro_Hang"
        Me.txtSo_Ro_Hang.Size = New System.Drawing.Size(134, 20)
        Me.txtSo_Ro_Hang.TabIndex = 3
        Me.txtSo_Ro_Hang.Tag = ""
        Me.txtSo_Ro_Hang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSo_Ro_Hang.Visible = False
        '
        'GridView7
        '
        Me.GridView7.Name = "GridView7"
        '
        'TxtT_TT
        '
        Me.TxtT_TT.AllowNegative = True
        Me.TxtT_TT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_TT.BackColor = System.Drawing.Color.White
        Me.TxtT_TT.Flags = 7680
        Me.TxtT_TT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtT_TT.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_TT.InputMask = "### ### ### ### ### ###"
        Me.TxtT_TT.Location = New System.Drawing.Point(440, 563)
        Me.TxtT_TT.MaxWholeDigits = 17
        Me.TxtT_TT.Name = "TxtT_TT"
        Me.TxtT_TT.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_TT.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_TT.ReadOnly = True
        Me.TxtT_TT.Size = New System.Drawing.Size(125, 20)
        Me.TxtT_TT.TabIndex = 392
        Me.TxtT_TT.TabStop = False
        Me.TxtT_TT.Text = "0"
        Me.TxtT_TT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmLocRoPOD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1074, 612)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSo_Ro_Hang)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtT_TT)
        Me.Controls.Add(Me.TxtT_Thue)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TxtMa_Hs)
        Me.Controls.Add(Me.TxtT_Tien2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TxtSo_DN)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNgay_Ct2)
        Me.Controls.Add(Me.TxtNgay_Ct1)
        Me.Controls.Add(Me.lblMa_kh)
        Me.Controls.Add(Me.CmdLoc_Ro)
        Me.Controls.Add(Me.TxtTen_Hs)
        Me.Name = "FrmLocRoPOD"
        Me.Controls.SetChildIndex(Me.TxtTen_Hs, 0)
        Me.Controls.SetChildIndex(Me.CmdLoc_Ro, 0)
        Me.Controls.SetChildIndex(Me.lblMa_kh, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_Ct1, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_Ct2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtSo_DN, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien2, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Hs, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Thue, 0)
        Me.Controls.SetChildIndex(Me.TxtT_TT, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.txtSo_Ro_Hang, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.ButtExit, 0)
        Me.Controls.SetChildIndex(Me.ButtOK, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DetailRo_Master, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailGRVRo_Master, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailRo_DetailVt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailGRVRo_DetailVt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMa_Hs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtT_Thue As ClsTextBox.txtTien_NT
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtT_Tien2 As ClsTextBox.txtTien_NT
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtSo_DN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNgay_Ct2 As ClsTextBox.txtDate
    Friend WithEvents TxtNgay_Ct1 As ClsTextBox.txtDate
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CmdLoc_Ro As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DetailRo_Master As DevExpress.XtraGrid.GridControl
    Friend WithEvents DetailGRVRo_Master As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents TxtTen_Hs As System.Windows.Forms.TextBox
    Friend WithEvents lblMa_kh As System.Windows.Forms.Label
    Friend WithEvents TxtMa_Hs As Cyber.SmLists.TxtLookup
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSo_Ro_Hang As System.Windows.Forms.TextBox
    Friend WithEvents DetailRo_DetailVt As DevExpress.XtraGrid.GridControl
    Friend WithEvents DetailGRVRo_DetailVt As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit11 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit12 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtT_TT As ClsTextBox.txtTien_NT

End Class
