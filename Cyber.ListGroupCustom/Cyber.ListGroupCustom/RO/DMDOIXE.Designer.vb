<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DMDOIXE
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
        Me.TxtMa_Doi = New System.Windows.Forms.TextBox()
        Me.LabTen_kho = New System.Windows.Forms.Label()
        Me.TxtTen_Doi = New System.Windows.Forms.TextBox()
        Me.Labten_Kho2 = New System.Windows.Forms.Label()
        Me.LabMa_Nh1 = New System.Windows.Forms.Label()
        Me.TxtTen_TTCP = New System.Windows.Forms.TextBox()
        Me.TxtMa_TTCP = New Cyber.SmLists.TxtLookup()
        CType(Me.TxtMa_TTCP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtExit
        '
        Me.ButtExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtExit.Appearance.Options.UseForeColor = True
        Me.ButtExit.Location = New System.Drawing.Point(371, 75)
        Me.ButtExit.TabIndex = 13
        '
        'ButtOK
        '
        Me.ButtOK.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtOK.Appearance.Options.UseForeColor = True
        Me.ButtOK.Location = New System.Drawing.Point(269, 75)
        Me.ButtOK.TabIndex = 12
        '
        'TxtMa_Dvcs
        '
        Me.TxtMa_Dvcs.Location = New System.Drawing.Point(163, 81)
        Me.TxtMa_Dvcs.TabIndex = 11
        '
        'ChkActi
        '
        Me.ChkActi.Location = New System.Drawing.Point(110, 85)
        Me.ChkActi.TabIndex = 10
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Location = New System.Drawing.Point(2, 65)
        Me.GroupBoxLine.Size = New System.Drawing.Size(469, 9)
        '
        'TxtMa_Doi
        '
        Me.TxtMa_Doi.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Doi.Location = New System.Drawing.Point(110, 4)
        Me.TxtMa_Doi.Name = "TxtMa_Doi"
        Me.TxtMa_Doi.Size = New System.Drawing.Size(96, 21)
        Me.TxtMa_Doi.TabIndex = 6
        '
        'LabTen_kho
        '
        Me.LabTen_kho.Location = New System.Drawing.Point(5, 6)
        Me.LabTen_kho.Name = "LabTen_kho"
        Me.LabTen_kho.Size = New System.Drawing.Size(100, 18)
        Me.LabTen_kho.TabIndex = 12
        Me.LabTen_kho.Tag = "Name"
        Me.LabTen_kho.Text = "Mã Đội"
        '
        'TxtTen_Doi
        '
        Me.TxtTen_Doi.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_Doi.Location = New System.Drawing.Point(110, 26)
        Me.TxtTen_Doi.Name = "TxtTen_Doi"
        Me.TxtTen_Doi.Size = New System.Drawing.Size(361, 21)
        Me.TxtTen_Doi.TabIndex = 7
        '
        'Labten_Kho2
        '
        Me.Labten_Kho2.Location = New System.Drawing.Point(5, 30)
        Me.Labten_Kho2.Name = "Labten_Kho2"
        Me.Labten_Kho2.Size = New System.Drawing.Size(100, 18)
        Me.Labten_Kho2.TabIndex = 14
        Me.Labten_Kho2.Tag = "English name"
        Me.Labten_Kho2.Text = "Tên Đội"
        '
        'LabMa_Nh1
        '
        Me.LabMa_Nh1.Location = New System.Drawing.Point(5, 48)
        Me.LabMa_Nh1.Name = "LabMa_Nh1"
        Me.LabMa_Nh1.Size = New System.Drawing.Size(100, 18)
        Me.LabMa_Nh1.TabIndex = 24
        Me.LabMa_Nh1.Tag = "Group 1"
        Me.LabMa_Nh1.Text = "Tên TTCP"
        Me.LabMa_Nh1.Visible = False
        '
        'TxtTen_TTCP
        '
        Me.TxtTen_TTCP.BackColor = System.Drawing.Color.White
        Me.TxtTen_TTCP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTen_TTCP.Enabled = False
        Me.TxtTen_TTCP.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_TTCP.Location = New System.Drawing.Point(212, 51)
        Me.TxtTen_TTCP.Name = "TxtTen_TTCP"
        Me.TxtTen_TTCP.ReadOnly = True
        Me.TxtTen_TTCP.Size = New System.Drawing.Size(259, 14)
        Me.TxtTen_TTCP.TabIndex = 23
        Me.TxtTen_TTCP.TabStop = False
        Me.TxtTen_TTCP.Visible = False
        '
        'TxtMa_TTCP
        '
        Me.TxtMa_TTCP._ActilookupPopup = False
        Me.TxtMa_TTCP.CyberActilookupPopup = True
        Me.TxtMa_TTCP.Dv_ListDetail = Nothing
        Me.TxtMa_TTCP.Dv_Master = Nothing
        Me.TxtMa_TTCP.FilterClient = ""
        Me.TxtMa_TTCP.FilterSQL = ""
        Me.TxtMa_TTCP.Location = New System.Drawing.Point(110, 48)
        Me.TxtMa_TTCP.Name = "TxtMa_TTCP"
        Me.TxtMa_TTCP.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_TTCP.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_TTCP.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_TTCP.Size = New System.Drawing.Size(96, 20)
        Me.TxtMa_TTCP.TabIndex = 0
        Me.TxtMa_TTCP.Table_Name = ""
        Me.TxtMa_TTCP.Visible = False
        '
        'DMDOIXE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(473, 108)
        Me.Controls.Add(Me.LabMa_Nh1)
        Me.Controls.Add(Me.TxtTen_TTCP)
        Me.Controls.Add(Me.TxtMa_TTCP)
        Me.Controls.Add(Me.TxtTen_Doi)
        Me.Controls.Add(Me.Labten_Kho2)
        Me.Controls.Add(Me.TxtMa_Doi)
        Me.Controls.Add(Me.LabTen_kho)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(400, 90)
        Me.Name = "DMDOIXE"
        Me.Text = "Danh mục đội xe"
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Dvcs, 0)
        Me.Controls.SetChildIndex(Me.ChkActi, 0)
        Me.Controls.SetChildIndex(Me.ButtExit, 0)
        Me.Controls.SetChildIndex(Me.ButtOK, 0)
        Me.Controls.SetChildIndex(Me.LabTen_kho, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Doi, 0)
        Me.Controls.SetChildIndex(Me.Labten_Kho2, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_Doi, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_TTCP, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_TTCP, 0)
        Me.Controls.SetChildIndex(Me.LabMa_Nh1, 0)
        CType(Me.TxtMa_TTCP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtMa_Doi As System.Windows.Forms.TextBox
    Friend WithEvents LabTen_kho As System.Windows.Forms.Label
    Friend WithEvents TxtTen_Doi As System.Windows.Forms.TextBox
    Friend WithEvents Labten_Kho2 As System.Windows.Forms.Label
    Friend WithEvents LabMa_Nh1 As System.Windows.Forms.Label
    Friend WithEvents TxtTen_TTCP As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_TTCP As Cyber.SmLists.TxtLookup

End Class
