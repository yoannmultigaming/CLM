<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form9
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form9))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ChromeTabcontrol1 = New CLM.ChromeTabcontrol()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GunaAdvenceButton2 = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.GunaAdvenceButton1 = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ChromeTabcontrol2 = New CLM.ChromeTabcontrol()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.ChromeTabcontrol1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ChromeTabcontrol2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "jpg|*.jpg"
        '
        'ChromeTabcontrol1
        '
        Me.ChromeTabcontrol1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage5)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage1)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage2)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage3)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage4)
        Me.ChromeTabcontrol1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ChromeTabcontrol1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChromeTabcontrol1.ItemSize = New System.Drawing.Size(30, 115)
        Me.ChromeTabcontrol1.Location = New System.Drawing.Point(0, 0)
        Me.ChromeTabcontrol1.Multiline = True
        Me.ChromeTabcontrol1.Name = "ChromeTabcontrol1"
        Me.ChromeTabcontrol1.SelectedIndex = 0
        Me.ChromeTabcontrol1.ShowOuterBorders = False
        Me.ChromeTabcontrol1.Size = New System.Drawing.Size(832, 450)
        Me.ChromeTabcontrol1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.ChromeTabcontrol1.SquareColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ChromeTabcontrol1.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.White
        Me.TabPage5.Controls.Add(Me.GroupBox2)
        Me.TabPage5.Controls.Add(Me.GroupBox1)
        Me.TabPage5.Location = New System.Drawing.Point(119, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(709, 442)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Général"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 187)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(698, 255)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Information de CLM"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(171, 145)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(239, 26)
        Me.TextBox3.TabIndex = 6
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(419, 146)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 26)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Modifier"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(36, 146)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(135, 18)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Nom de l'instance:"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 18
        Me.ListBox1.Location = New System.Drawing.Point(572, 23)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 94)
        Me.ListBox1.TabIndex = 1
        Me.ListBox1.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Nombre de profils:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Nombre de compte:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(46, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 18)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Version de CLM:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Version de votre CLM:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GunaAdvenceButton2)
        Me.GroupBox1.Controls.Add(Me.GunaAdvenceButton1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(698, 173)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information du serveur"
        '
        'GunaAdvenceButton2
        '
        Me.GunaAdvenceButton2.AnimationHoverSpeed = 0.07!
        Me.GunaAdvenceButton2.AnimationSpeed = 0.03!
        Me.GunaAdvenceButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.CheckedBaseColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.CheckedBorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.CheckedForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton2.CheckedImage = CType(resources.GetObject("GunaAdvenceButton2.CheckedImage"), System.Drawing.Image)
        Me.GunaAdvenceButton2.CheckedLineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaAdvenceButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaAdvenceButton2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaAdvenceButton2.ForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton2.Image = CType(resources.GetObject("GunaAdvenceButton2.Image"), System.Drawing.Image)
        Me.GunaAdvenceButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaAdvenceButton2.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.Location = New System.Drawing.Point(512, 70)
        Me.GunaAdvenceButton2.Name = "GunaAdvenceButton2"
        Me.GunaAdvenceButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton2.OnHoverImage = Nothing
        Me.GunaAdvenceButton2.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.OnPressedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton2.Size = New System.Drawing.Size(180, 42)
        Me.GunaAdvenceButton2.TabIndex = 1
        Me.GunaAdvenceButton2.Text = "copier la clé de chiffrage"
        '
        'GunaAdvenceButton1
        '
        Me.GunaAdvenceButton1.AnimationHoverSpeed = 0.07!
        Me.GunaAdvenceButton1.AnimationSpeed = 0.03!
        Me.GunaAdvenceButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.CheckedBaseColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.CheckedBorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.CheckedForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton1.CheckedImage = CType(resources.GetObject("GunaAdvenceButton1.CheckedImage"), System.Drawing.Image)
        Me.GunaAdvenceButton1.CheckedLineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaAdvenceButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaAdvenceButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaAdvenceButton1.ForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton1.Image = CType(resources.GetObject("GunaAdvenceButton1.Image"), System.Drawing.Image)
        Me.GunaAdvenceButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaAdvenceButton1.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.Location = New System.Drawing.Point(512, 22)
        Me.GunaAdvenceButton1.Name = "GunaAdvenceButton1"
        Me.GunaAdvenceButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton1.OnHoverImage = Nothing
        Me.GunaAdvenceButton1.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.OnPressedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaAdvenceButton1.Size = New System.Drawing.Size(180, 42)
        Me.GunaAdvenceButton1.TabIndex = 1
        Me.GunaAdvenceButton1.Text = "copier le mot de passe ftp"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(128, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ID ftp:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(116, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "port ftp:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Adresse IP du serveur:"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.ChromeTabcontrol2)
        Me.TabPage1.Location = New System.Drawing.Point(119, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(709, 442)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Compte"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Location = New System.Drawing.Point(119, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(709, 442)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Profils"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.TextBox2)
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Controls.Add(Me.TextBox1)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.PictureBox1)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Location = New System.Drawing.Point(119, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(709, 442)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "organisation"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(169, 54)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(239, 26)
        Me.TextBox2.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(419, 56)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 26)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Modifier"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(169, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(239, 26)
        Me.TextBox1.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(414, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 26)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Modifier"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(561, 143)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 26)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Modifier"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(561, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(131, 111)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(602, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 18)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Logo:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(70, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 18)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Site internet:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(163, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Nom de l'organisation:"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.White
        Me.TabPage4.Location = New System.Drawing.Point(119, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(709, 442)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Mail"
        '
        'ChromeTabcontrol2
        '
        Me.ChromeTabcontrol2.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.ChromeTabcontrol2.Controls.Add(Me.TabPage6)
        Me.ChromeTabcontrol2.Controls.Add(Me.TabPage7)
        Me.ChromeTabcontrol2.Controls.Add(Me.TabPage8)
        Me.ChromeTabcontrol2.ItemSize = New System.Drawing.Size(30, 115)
        Me.ChromeTabcontrol2.Location = New System.Drawing.Point(0, -4)
        Me.ChromeTabcontrol2.Multiline = True
        Me.ChromeTabcontrol2.Name = "ChromeTabcontrol2"
        Me.ChromeTabcontrol2.SelectedIndex = 0
        Me.ChromeTabcontrol2.ShowOuterBorders = False
        Me.ChromeTabcontrol2.Size = New System.Drawing.Size(713, 450)
        Me.ChromeTabcontrol2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.ChromeTabcontrol2.SquareColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ChromeTabcontrol2.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.White
        Me.TabPage6.Location = New System.Drawing.Point(119, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(590, 442)
        Me.TabPage6.TabIndex = 0
        Me.TabPage6.Text = "Ajouter"
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.Color.White
        Me.TabPage7.Location = New System.Drawing.Point(119, 4)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(590, 436)
        Me.TabPage7.TabIndex = 1
        Me.TabPage7.Text = "Modifier"
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.Color.White
        Me.TabPage8.Location = New System.Drawing.Point(119, 4)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(590, 436)
        Me.TabPage8.TabIndex = 2
        Me.TabPage8.Text = "Suprimer"
        '
        'Form9
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 450)
        Me.Controls.Add(Me.ChromeTabcontrol1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(848, 489)
        Me.MinimumSize = New System.Drawing.Size(848, 489)
        Me.Name = "Form9"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form9"
        Me.ChromeTabcontrol1.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ChromeTabcontrol2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ChromeTabcontrol1 As ChromeTabcontrol
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GunaAdvenceButton2 As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents GunaAdvenceButton1 As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents ChromeTabcontrol2 As ChromeTabcontrol
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents TabPage8 As TabPage
End Class
