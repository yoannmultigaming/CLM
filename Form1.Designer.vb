<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ChromeTabcontrol1 = New CLM.ChromeTabcontrol()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.ChromeTabcontrol1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "CLM"
        Me.NotifyIcon1.Visible = True
        '
        'ChromeTabcontrol1
        '
        Me.ChromeTabcontrol1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.ChromeTabcontrol1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage1)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage2)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage3)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage4)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage5)
        Me.ChromeTabcontrol1.ItemSize = New System.Drawing.Size(30, 115)
        Me.ChromeTabcontrol1.Location = New System.Drawing.Point(0, -2)
        Me.ChromeTabcontrol1.Multiline = True
        Me.ChromeTabcontrol1.Name = "ChromeTabcontrol1"
        Me.ChromeTabcontrol1.SelectedIndex = 0
        Me.ChromeTabcontrol1.ShowOuterBorders = False
        Me.ChromeTabcontrol1.Size = New System.Drawing.Size(800, 452)
        Me.ChromeTabcontrol1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.ChromeTabcontrol1.SquareColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ChromeTabcontrol1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Location = New System.Drawing.Point(119, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(677, 444)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tout les logiciel"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(640, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 20)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(87, 415)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(20, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(122, 415)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "suivant"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 412)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "présétent"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(147, 7)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(489, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "Taper pour rechercher"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(3, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(138, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Location = New System.Drawing.Point(119, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(677, 444)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Logiciel installer"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Location = New System.Drawing.Point(119, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(677, 444)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Mise a jour"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.White
        Me.TabPage4.Location = New System.Drawing.Point(119, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(677, 444)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Paramètres"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.White
        Me.TabPage5.Location = New System.Drawing.Point(119, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(677, 444)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "A propos"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ChromeTabcontrol1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CLM"
        Me.ChromeTabcontrol1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ChromeTabcontrol1 As ChromeTabcontrol
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
End Class
