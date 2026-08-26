<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BCRO_010
    Inherits Cyber.From.FilterReport

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
        Me.TxtM_Ngay_Ct2 = New ClsTextBox.txtDate1()
        Me.LabM_Ngay_Ct2 = New System.Windows.Forms.Label()
        Me.GroupBoxLine = New System.Windows.Forms.GroupBox()
        Me.LabMa_kho = New System.Windows.Forms.Label()
        Me.TxtTen_Nh2 = New System.Windows.Forms.TextBox()
        Me.TxtMa_Nh2 = New Cyber.SmLists.TxtLookup()
        Me.LabMa_Cc = New System.Windows.Forms.Label()
        Me.TxtTen_Vt = New System.Windows.Forms.TextBox()
        Me.TxtMa_Vt = New Cyber.SmLists.TxtLookup()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTen_Nh1 = New System.Windows.Forms.TextBox()
        Me.TxtMa_Nh1 = New Cyber.SmLists.TxtLookup()
        CType(Me.TxtMa_Nh2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMa_Vt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMa_Nh1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtExit
        '
        Me.ButtExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtExit.Appearance.Options.UseForeColor = True
        Me.ButtExit.Location = New System.Drawing.Point(492, 169)
        Me.ButtExit.TabIndex = 8
        '
        'CBBMa_Dvcs
        '
        Me.CBBMa_Dvcs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBBMa_Dvcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBMa_Dvcs.Location = New System.Drawing.Point(95, 130)
        Me.CBBMa_Dvcs.Size = New System.Drawing.Size(491, 21)
        Me.CBBMa_Dvcs.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 133)
        '
        'ButtOK
        '
        Me.ButtOK.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtOK.Appearance.Options.UseForeColor = True
        Me.ButtOK.Location = New System.Drawing.Point(388, 169)
        Me.ButtOK.TabIndex = 7
        '
        'LabLoai_NT
        '
        Me.LabLoai_NT.Location = New System.Drawing.Point(10, 111)
        '
        'ChkVND
        '
        Me.ChkVND.Location = New System.Drawing.Point(95, 108)
        Me.ChkVND.TabIndex = 4
        '
        'ChkNT
        '
        Me.ChkNT.Location = New System.Drawing.Point(210, 108)
        Me.ChkNT.TabIndex = 5
        '
        'TxtM_Ngay_Ct2
        '
        Me.TxtM_Ngay_Ct2.Flags = 0
        Me.TxtM_Ngay_Ct2.ForeColor = System.Drawing.Color.Navy
        Me.TxtM_Ngay_Ct2.IsAllowResize = False
        Me.TxtM_Ngay_Ct2.isEmpty = True
        Me.TxtM_Ngay_Ct2.Location = New System.Drawing.Point(95, 9)
        Me.TxtM_Ngay_Ct2.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtM_Ngay_Ct2.MaskDate = "dd/MM/yyyy"
        Me.TxtM_Ngay_Ct2.MaxLength = 10
        Me.TxtM_Ngay_Ct2.Name = "TxtM_Ngay_Ct2"
        Me.TxtM_Ngay_Ct2.RangeMax = New Date(CType(0, Long))
        Me.TxtM_Ngay_Ct2.RangeMin = New Date(CType(0, Long))
        Me.TxtM_Ngay_Ct2.ShowDayBeforeMonth = False
        Me.TxtM_Ngay_Ct2.Size = New System.Drawing.Size(116, 21)
        Me.TxtM_Ngay_Ct2.TabIndex = 3
        Me.TxtM_Ngay_Ct2.Text = "__/__/____"
        Me.TxtM_Ngay_Ct2.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'LabM_Ngay_Ct2
        '
        Me.LabM_Ngay_Ct2.AutoSize = True
        Me.LabM_Ngay_Ct2.Location = New System.Drawing.Point(10, 12)
        Me.LabM_Ngay_Ct2.Name = "LabM_Ngay_Ct2"
        Me.LabM_Ngay_Ct2.Size = New System.Drawing.Size(32, 13)
        Me.LabM_Ngay_Ct2.TabIndex = 14
        Me.LabM_Ngay_Ct2.Tag = "Date to"
        Me.LabM_Ngay_Ct2.Text = "Ngày"
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxLine.Location = New System.Drawing.Point(4, 152)
        Me.GroupBoxLine.Name = "GroupBoxLine"
        Me.GroupBoxLine.Size = New System.Drawing.Size(589, 9)
        Me.GroupBoxLine.TabIndex = 15
        Me.GroupBoxLine.TabStop = False
        '
        'LabMa_kho
        '
        Me.LabMa_kho.Location = New System.Drawing.Point(10, 61)
        Me.LabMa_kho.Name = "LabMa_kho"
        Me.LabMa_kho.Size = New System.Drawing.Size(82, 13)
        Me.LabMa_kho.TabIndex = 194
        Me.LabMa_kho.Tag = "Warehouse"
        Me.LabMa_kho.Text = "Nhóm VT2"
        '
        'TxtTen_Nh2
        '
        Me.TxtTen_Nh2.BackColor = System.Drawing.SystemColors.Control
        Me.TxtTen_Nh2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTen_Nh2.Enabled = False
        Me.TxtTen_Nh2.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_Nh2.Location = New System.Drawing.Point(216, 60)
        Me.TxtTen_Nh2.Name = "TxtTen_Nh2"
        Me.TxtTen_Nh2.ReadOnly = True
        Me.TxtTen_Nh2.Size = New System.Drawing.Size(370, 14)
        Me.TxtTen_Nh2.TabIndex = 193
        Me.TxtTen_Nh2.TabStop = False
        '
        'TxtMa_Nh2
        '
        Me.TxtMa_Nh2._ActilookupPopup = False
        Me.TxtMa_Nh2.CyberActilookupPopup = True
        Me.TxtMa_Nh2.Dv_ListDetail = Nothing
        Me.TxtMa_Nh2.Dv_Master = Nothing
        Me.TxtMa_Nh2.FilterClient = ""
        Me.TxtMa_Nh2.FilterSQL = ""
        Me.TxtMa_Nh2.Location = New System.Drawing.Point(95, 57)
        Me.TxtMa_Nh2.Name = "TxtMa_Nh2"
        Me.TxtMa_Nh2.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Nh2.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_Nh2.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtMa_Nh2.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtMa_Nh2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_Nh2.Size = New System.Drawing.Size(116, 20)
        Me.TxtMa_Nh2.TabIndex = 0
        Me.TxtMa_Nh2.Table_Name = ""
        '
        'LabMa_Cc
        '
        Me.LabMa_Cc.Location = New System.Drawing.Point(10, 85)
        Me.LabMa_Cc.Name = "LabMa_Cc"
        Me.LabMa_Cc.Size = New System.Drawing.Size(82, 13)
        Me.LabMa_Cc.TabIndex = 197
        Me.LabMa_Cc.Tag = "Supplies"
        Me.LabMa_Cc.Text = "Mã vật tư"
        '
        'TxtTen_Vt
        '
        Me.TxtTen_Vt.BackColor = System.Drawing.SystemColors.Control
        Me.TxtTen_Vt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTen_Vt.Enabled = False
        Me.TxtTen_Vt.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_Vt.Location = New System.Drawing.Point(216, 82)
        Me.TxtTen_Vt.Name = "TxtTen_Vt"
        Me.TxtTen_Vt.ReadOnly = True
        Me.TxtTen_Vt.Size = New System.Drawing.Size(370, 14)
        Me.TxtTen_Vt.TabIndex = 196
        Me.TxtTen_Vt.TabStop = False
        '
        'TxtMa_Vt
        '
        Me.TxtMa_Vt._ActilookupPopup = False
        Me.TxtMa_Vt.CyberActilookupPopup = True
        Me.TxtMa_Vt.Dv_ListDetail = Nothing
        Me.TxtMa_Vt.Dv_Master = Nothing
        Me.TxtMa_Vt.FilterClient = ""
        Me.TxtMa_Vt.FilterSQL = ""
        Me.TxtMa_Vt.Location = New System.Drawing.Point(95, 79)
        Me.TxtMa_Vt.Name = "TxtMa_Vt"
        Me.TxtMa_Vt.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Vt.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_Vt.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtMa_Vt.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtMa_Vt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_Vt.Size = New System.Drawing.Size(116, 20)
        Me.TxtMa_Vt.TabIndex = 1
        Me.TxtMa_Vt.Table_Name = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 200
        Me.Label2.Tag = "Warehouse"
        Me.Label2.Text = "Nhóm VT1"
        '
        'TxtTen_Nh1
        '
        Me.TxtTen_Nh1.BackColor = System.Drawing.SystemColors.Control
        Me.TxtTen_Nh1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTen_Nh1.Enabled = False
        Me.TxtTen_Nh1.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_Nh1.Location = New System.Drawing.Point(216, 36)
        Me.TxtTen_Nh1.Name = "TxtTen_Nh1"
        Me.TxtTen_Nh1.ReadOnly = True
        Me.TxtTen_Nh1.Size = New System.Drawing.Size(370, 14)
        Me.TxtTen_Nh1.TabIndex = 199
        Me.TxtTen_Nh1.TabStop = False
        '
        'TxtMa_Nh1
        '
        Me.TxtMa_Nh1._ActilookupPopup = False
        Me.TxtMa_Nh1.CyberActilookupPopup = True
        Me.TxtMa_Nh1.Dv_ListDetail = Nothing
        Me.TxtMa_Nh1.Dv_Master = Nothing
        Me.TxtMa_Nh1.FilterClient = ""
        Me.TxtMa_Nh1.FilterSQL = ""
        Me.TxtMa_Nh1.Location = New System.Drawing.Point(95, 33)
        Me.TxtMa_Nh1.Name = "TxtMa_Nh1"
        Me.TxtMa_Nh1.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Nh1.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_Nh1.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtMa_Nh1.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtMa_Nh1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_Nh1.Size = New System.Drawing.Size(116, 20)
        Me.TxtMa_Nh1.TabIndex = 198
        Me.TxtMa_Nh1.Table_Name = ""
        '
        'DMGIA2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(596, 222)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTen_Nh1)
        Me.Controls.Add(Me.TxtMa_Nh1)
        Me.Controls.Add(Me.LabMa_Cc)
        Me.Controls.Add(Me.TxtTen_Vt)
        Me.Controls.Add(Me.TxtMa_Vt)
        Me.Controls.Add(Me.LabMa_kho)
        Me.Controls.Add(Me.TxtTen_Nh2)
        Me.Controls.Add(Me.TxtMa_Nh2)
        Me.Controls.Add(Me.GroupBoxLine)
        Me.Controls.Add(Me.LabM_Ngay_Ct2)
        Me.Controls.Add(Me.TxtM_Ngay_Ct2)
        Me.MinimumSize = New System.Drawing.Size(489, 181)
        Me.Name = "DMGIA2"
        Me.Controls.SetChildIndex(Me.ButtExit, 0)
        Me.Controls.SetChildIndex(Me.CBBMa_Dvcs, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ButtOK, 0)
        Me.Controls.SetChildIndex(Me.ChkVND, 0)
        Me.Controls.SetChildIndex(Me.ChkNT, 0)
        Me.Controls.SetChildIndex(Me.LabLoai_NT, 0)
        Me.Controls.SetChildIndex(Me.TxtM_Ngay_Ct2, 0)
        Me.Controls.SetChildIndex(Me.LabM_Ngay_Ct2, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Nh2, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_Nh2, 0)
        Me.Controls.SetChildIndex(Me.LabMa_kho, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Vt, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_Vt, 0)
        Me.Controls.SetChildIndex(Me.LabMa_Cc, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Nh1, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_Nh1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.TxtMa_Nh2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMa_Vt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMa_Nh1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtM_Ngay_Ct2 As ClsTextBox.txtDate1
    Friend WithEvents LabM_Ngay_Ct2 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxLine As System.Windows.Forms.GroupBox
    Friend WithEvents LabMa_kho As System.Windows.Forms.Label
    Friend WithEvents TxtTen_Nh2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_Nh2 As Cyber.SmLists.TxtLookup
    Friend WithEvents LabMa_Cc As System.Windows.Forms.Label
    Friend WithEvents TxtTen_Vt As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_Vt As Cyber.SmLists.TxtLookup
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtTen_Nh1 As TextBox
    Friend WithEvents TxtMa_Nh1 As SmLists.TxtLookup
End Class
