<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DMVITRIVT
    Inherits Cyber.From.FrmList

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
        Me.LabMa_Nh1 = New System.Windows.Forms.Label()
        Me.TxtTen_VT = New System.Windows.Forms.TextBox()
        Me.TxtMa_VT = New Cyber.SmLists.TxtLookup()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTen_vitri = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTen_kho = New System.Windows.Forms.TextBox()
        Me.TxtMa_kho = New Cyber.SmLists.TxtLookup()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNgay_HL = New ClsTextBox.txtDate1()
        Me.txtMa_ViTri = New Cyber.SmLists.TxtLookup()
        CType(Me.TxtMa_VT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMa_kho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMa_ViTri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtExit
        '
        Me.ButtExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtExit.Appearance.Options.UseForeColor = True
        Me.ButtExit.Location = New System.Drawing.Point(541, 125)
        Me.ButtExit.TabIndex = 6
        '
        'ButtOK
        '
        Me.ButtOK.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtOK.Appearance.Options.UseForeColor = True
        Me.ButtOK.Location = New System.Drawing.Point(439, 125)
        Me.ButtOK.TabIndex = 5
        '
        'TxtMa_Dvcs
        '
        Me.TxtMa_Dvcs.Location = New System.Drawing.Point(333, 131)
        Me.TxtMa_Dvcs.TabIndex = 14
        '
        'ChkActi
        '
        Me.ChkActi.Location = New System.Drawing.Point(108, 125)
        Me.ChkActi.TabIndex = 4
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Location = New System.Drawing.Point(2, 104)
        Me.GroupBoxLine.Size = New System.Drawing.Size(639, 9)
        '
        'LabMa_Nh1
        '
        Me.LabMa_Nh1.Location = New System.Drawing.Point(19, 32)
        Me.LabMa_Nh1.Name = "LabMa_Nh1"
        Me.LabMa_Nh1.Size = New System.Drawing.Size(80, 16)
        Me.LabMa_Nh1.TabIndex = 24
        Me.LabMa_Nh1.Tag = "Models code"
        Me.LabMa_Nh1.Text = "Mã vật tư"
        '
        'TxtTen_VT
        '
        Me.TxtTen_VT.BackColor = System.Drawing.Color.White
        Me.TxtTen_VT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTen_VT.Enabled = False
        Me.TxtTen_VT.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_VT.Location = New System.Drawing.Point(232, 34)
        Me.TxtTen_VT.Name = "TxtTen_VT"
        Me.TxtTen_VT.ReadOnly = True
        Me.TxtTen_VT.Size = New System.Drawing.Size(409, 14)
        Me.TxtTen_VT.TabIndex = 23
        Me.TxtTen_VT.TabStop = False
        '
        'TxtMa_VT
        '
        Me.TxtMa_VT._ActilookupPopup = False
        Me.TxtMa_VT.CyberActilookupPopup = True
        Me.TxtMa_VT.Dv_ListDetail = Nothing
        Me.TxtMa_VT.Dv_Master = Nothing
        Me.TxtMa_VT.FilterClient = ""
        Me.TxtMa_VT.FilterSQL = ""
        Me.TxtMa_VT.Location = New System.Drawing.Point(103, 31)
        Me.TxtMa_VT.Name = "TxtMa_VT"
        Me.TxtMa_VT.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_VT.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_VT.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_VT.Size = New System.Drawing.Size(123, 20)
        Me.TxtMa_VT.TabIndex = 1
        Me.TxtMa_VT.Table_Name = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Tag = "Colour"
        Me.Label1.Text = "Mã vị trí"
        '
        'TxtTen_vitri
        '
        Me.TxtTen_vitri.BackColor = System.Drawing.Color.White
        Me.TxtTen_vitri.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTen_vitri.Enabled = False
        Me.TxtTen_vitri.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_vitri.Location = New System.Drawing.Point(232, 83)
        Me.TxtTen_vitri.Name = "TxtTen_vitri"
        Me.TxtTen_vitri.ReadOnly = True
        Me.TxtTen_vitri.Size = New System.Drawing.Size(409, 14)
        Me.TxtTen_vitri.TabIndex = 26
        Me.TxtTen_vitri.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Tag = "Colour"
        Me.Label2.Text = "Mã kho"
        '
        'TxtTen_kho
        '
        Me.TxtTen_kho.BackColor = System.Drawing.Color.White
        Me.TxtTen_kho.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTen_kho.Enabled = False
        Me.TxtTen_kho.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_kho.Location = New System.Drawing.Point(232, 58)
        Me.TxtTen_kho.Name = "TxtTen_kho"
        Me.TxtTen_kho.ReadOnly = True
        Me.TxtTen_kho.Size = New System.Drawing.Size(409, 14)
        Me.TxtTen_kho.TabIndex = 7
        Me.TxtTen_kho.TabStop = False
        '
        'TxtMa_kho
        '
        Me.TxtMa_kho._ActilookupPopup = False
        Me.TxtMa_kho.CyberActilookupPopup = True
        Me.TxtMa_kho.Dv_ListDetail = Nothing
        Me.TxtMa_kho.Dv_Master = Nothing
        Me.TxtMa_kho.FilterClient = ""
        Me.TxtMa_kho.FilterSQL = ""
        Me.TxtMa_kho.Location = New System.Drawing.Point(103, 55)
        Me.TxtMa_kho.Name = "TxtMa_kho"
        Me.TxtMa_kho.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_kho.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_kho.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_kho.Size = New System.Drawing.Size(123, 20)
        Me.TxtMa_kho.TabIndex = 2
        Me.TxtMa_kho.Table_Name = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Tag = "Models code"
        Me.Label3.Text = "Ngày hiệu lực"
        '
        'TxtNgay_HL
        '
        Me.TxtNgay_HL.Flags = 65536
        Me.TxtNgay_HL.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_HL.IsAllowResize = False
        Me.TxtNgay_HL.isEmpty = True
        Me.TxtNgay_HL.Location = New System.Drawing.Point(103, 7)
        Me.TxtNgay_HL.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtNgay_HL.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_HL.MaxLength = 10
        Me.TxtNgay_HL.Name = "TxtNgay_HL"
        Me.TxtNgay_HL.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_HL.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_HL.ShowDayBeforeMonth = False
        Me.TxtNgay_HL.Size = New System.Drawing.Size(123, 21)
        Me.TxtNgay_HL.TabIndex = 0
        Me.TxtNgay_HL.Text = "07/09/2011"
        Me.TxtNgay_HL.Value = New Date(2011, 9, 7, 0, 0, 0, 0)
        '
        'txtMa_ViTri
        '
        Me.txtMa_ViTri._ActilookupPopup = False
        Me.txtMa_ViTri.CyberActilookupPopup = True
        Me.txtMa_ViTri.Dv_ListDetail = Nothing
        Me.txtMa_ViTri.Dv_Master = Nothing
        Me.txtMa_ViTri.FilterClient = ""
        Me.txtMa_ViTri.FilterSQL = ""
        Me.txtMa_ViTri.Location = New System.Drawing.Point(103, 78)
        Me.txtMa_ViTri.Name = "txtMa_ViTri"
        Me.txtMa_ViTri.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.txtMa_ViTri.Properties.Appearance.Options.UseForeColor = True
        Me.txtMa_ViTri.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.txtMa_ViTri.Size = New System.Drawing.Size(123, 20)
        Me.txtMa_ViTri.TabIndex = 32
        Me.txtMa_ViTri.Table_Name = ""
        '
        'DMVITRIVT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(643, 158)
        Me.Controls.Add(Me.txtMa_ViTri)
        Me.Controls.Add(Me.TxtNgay_HL)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTen_kho)
        Me.Controls.Add(Me.TxtMa_kho)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtTen_vitri)
        Me.Controls.Add(Me.LabMa_Nh1)
        Me.Controls.Add(Me.TxtTen_VT)
        Me.Controls.Add(Me.TxtMa_VT)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(489, 181)
        Me.Name = "DMVITRIVT"
        Me.Text = "Danh mục  vị trí trung tâm lợi nhuận"
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Dvcs, 0)
        Me.Controls.SetChildIndex(Me.ChkActi, 0)
        Me.Controls.SetChildIndex(Me.ButtExit, 0)
        Me.Controls.SetChildIndex(Me.ButtOK, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_VT, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_VT, 0)
        Me.Controls.SetChildIndex(Me.LabMa_Nh1, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_vitri, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_kho, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_kho, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_HL, 0)
        Me.Controls.SetChildIndex(Me.txtMa_ViTri, 0)
        CType(Me.TxtMa_VT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMa_kho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMa_ViTri.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabMa_Nh1 As System.Windows.Forms.Label
    Friend WithEvents TxtTen_VT As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_VT As Cyber.SmLists.TxtLookup
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTen_vitri As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTen_kho As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_kho As Cyber.SmLists.TxtLookup
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNgay_HL As ClsTextBox.txtDate1
    Friend WithEvents txtMa_ViTri As Cyber.SmLists.TxtLookup

End Class
