<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DmCV_DMS
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
        Me.TxtMa_Cv_DMS = New System.Windows.Forms.TextBox()
        Me.LabTen_TD2 = New System.Windows.Forms.Label()
        Me.TxtTen_Cv_Dms = New System.Windows.Forms.TextBox()
        Me.Labten_TD22 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTen_Cv = New System.Windows.Forms.TextBox()
        Me.TxtMa_Cv = New Cyber.SmLists.TxtLookup()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTen_CTCV = New System.Windows.Forms.TextBox()
        Me.TxtMa_CTCV = New Cyber.SmLists.TxtLookup()
        CType(Me.TxtMa_Cv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMa_CTCV.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtExit
        '
        Me.ButtExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtExit.Appearance.Options.UseForeColor = True
        Me.ButtExit.Location = New System.Drawing.Point(682, 109)
        Me.ButtExit.TabIndex = 12
        '
        'ButtOK
        '
        Me.ButtOK.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtOK.Appearance.Options.UseForeColor = True
        Me.ButtOK.Location = New System.Drawing.Point(580, 109)
        Me.ButtOK.TabIndex = 11
        '
        'TxtMa_Dvcs
        '
        Me.TxtMa_Dvcs.Location = New System.Drawing.Point(474, 115)
        Me.TxtMa_Dvcs.TabIndex = 13
        '
        'ChkActi
        '
        Me.ChkActi.Location = New System.Drawing.Point(110, 119)
        Me.ChkActi.TabIndex = 10
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Location = New System.Drawing.Point(2, 99)
        '
        'TxtMa_Cv_DMS
        '
        Me.TxtMa_Cv_DMS.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Cv_DMS.Location = New System.Drawing.Point(123, 47)
        Me.TxtMa_Cv_DMS.Name = "TxtMa_Cv_DMS"
        Me.TxtMa_Cv_DMS.Size = New System.Drawing.Size(659, 21)
        Me.TxtMa_Cv_DMS.TabIndex = 6
        '
        'LabTen_TD2
        '
        Me.LabTen_TD2.Location = New System.Drawing.Point(5, 49)
        Me.LabTen_TD2.Name = "LabTen_TD2"
        Me.LabTen_TD2.Size = New System.Drawing.Size(100, 16)
        Me.LabTen_TD2.TabIndex = 12
        Me.LabTen_TD2.Tag = "Name"
        Me.LabTen_TD2.Text = "Mã công việc DMS"
        '
        'TxtTen_Cv_Dms
        '
        Me.TxtTen_Cv_Dms.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_Cv_Dms.Location = New System.Drawing.Point(123, 70)
        Me.TxtTen_Cv_Dms.Name = "TxtTen_Cv_Dms"
        Me.TxtTen_Cv_Dms.Size = New System.Drawing.Size(659, 21)
        Me.TxtTen_Cv_Dms.TabIndex = 7
        '
        'Labten_TD22
        '
        Me.Labten_TD22.Location = New System.Drawing.Point(5, 71)
        Me.Labten_TD22.Name = "Labten_TD22"
        Me.Labten_TD22.Size = New System.Drawing.Size(100, 16)
        Me.Labten_TD22.TabIndex = 14
        Me.Labten_TD22.Tag = "English name"
        Me.Labten_TD22.Text = "Tên công việc DMS"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Tag = "Group 4"
        Me.Label3.Text = "Mã công việc"
        '
        'TxtTen_Cv
        '
        Me.TxtTen_Cv.BackColor = System.Drawing.Color.White
        Me.TxtTen_Cv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTen_Cv.Enabled = False
        Me.TxtTen_Cv.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_Cv.Location = New System.Drawing.Point(263, 6)
        Me.TxtTen_Cv.Name = "TxtTen_Cv"
        Me.TxtTen_Cv.ReadOnly = True
        Me.TxtTen_Cv.Size = New System.Drawing.Size(519, 14)
        Me.TxtTen_Cv.TabIndex = 32
        Me.TxtTen_Cv.TabStop = False
        '
        'TxtMa_Cv
        '
        Me.TxtMa_Cv._ActilookupPopup = False
        Me.TxtMa_Cv.CyberActilookupPopup = True
        Me.TxtMa_Cv.Dv_ListDetail = Nothing
        Me.TxtMa_Cv.Dv_Master = Nothing
        Me.TxtMa_Cv.FilterClient = ""
        Me.TxtMa_Cv.FilterSQL = ""
        Me.TxtMa_Cv.Location = New System.Drawing.Point(123, 3)
        Me.TxtMa_Cv.Name = "TxtMa_Cv"
        Me.TxtMa_Cv.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Cv.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_Cv.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_Cv.Size = New System.Drawing.Size(136, 20)
        Me.TxtMa_Cv.TabIndex = 3
        Me.TxtMa_Cv.Table_Name = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(5, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 36
        Me.Label4.Tag = "Group 5"
        Me.Label4.Text = "Mã chi tiết công việc"
        '
        'TxtTen_CTCV
        '
        Me.TxtTen_CTCV.BackColor = System.Drawing.Color.White
        Me.TxtTen_CTCV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTen_CTCV.Enabled = False
        Me.TxtTen_CTCV.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_CTCV.Location = New System.Drawing.Point(263, 28)
        Me.TxtTen_CTCV.Name = "TxtTen_CTCV"
        Me.TxtTen_CTCV.ReadOnly = True
        Me.TxtTen_CTCV.Size = New System.Drawing.Size(519, 14)
        Me.TxtTen_CTCV.TabIndex = 35
        Me.TxtTen_CTCV.TabStop = False
        '
        'TxtMa_CTCV
        '
        Me.TxtMa_CTCV._ActilookupPopup = False
        Me.TxtMa_CTCV.CyberActilookupPopup = True
        Me.TxtMa_CTCV.Dv_ListDetail = Nothing
        Me.TxtMa_CTCV.Dv_Master = Nothing
        Me.TxtMa_CTCV.FilterClient = ""
        Me.TxtMa_CTCV.FilterSQL = ""
        Me.TxtMa_CTCV.Location = New System.Drawing.Point(123, 25)
        Me.TxtMa_CTCV.Name = "TxtMa_CTCV"
        Me.TxtMa_CTCV.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_CTCV.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_CTCV.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_CTCV.Size = New System.Drawing.Size(136, 20)
        Me.TxtMa_CTCV.TabIndex = 4
        Me.TxtMa_CTCV.Table_Name = ""
        '
        'DmCV_DMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 142)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtTen_CTCV)
        Me.Controls.Add(Me.TxtMa_CTCV)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtTen_Cv)
        Me.Controls.Add(Me.TxtMa_Cv)
        Me.Controls.Add(Me.TxtTen_Cv_Dms)
        Me.Controls.Add(Me.Labten_TD22)
        Me.Controls.Add(Me.TxtMa_Cv_DMS)
        Me.Controls.Add(Me.LabTen_TD2)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(489, 181)
        Me.Name = "DmCV_DMS"
        Me.Text = "Danh mục coupon"
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Dvcs, 0)
        Me.Controls.SetChildIndex(Me.ChkActi, 0)
        Me.Controls.SetChildIndex(Me.ButtExit, 0)
        Me.Controls.SetChildIndex(Me.ButtOK, 0)
        Me.Controls.SetChildIndex(Me.LabTen_TD2, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Cv_DMS, 0)
        Me.Controls.SetChildIndex(Me.Labten_TD22, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_Cv_Dms, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Cv, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_Cv, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_CTCV, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_CTCV, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        CType(Me.TxtMa_Cv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMa_CTCV.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabMa_TD1 As System.Windows.Forms.Label
    Friend WithEvents TxtMa_Cv_DMS As System.Windows.Forms.TextBox
    Friend WithEvents LabTen_TD2 As System.Windows.Forms.Label
    Friend WithEvents TxtTen_Cv_Dms As System.Windows.Forms.TextBox
    Friend WithEvents Labten_TD22 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTen_Cv As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_Cv As Cyber.SmLists.TxtLookup
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTen_CTCV As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_CTCV As Cyber.SmLists.TxtLookup

End Class
