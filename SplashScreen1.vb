Imports System.IO
Public NotInheritable Class SplashScreen1

    'TODO: ce formulaire peut facilement être configuré comme écran de démarrage de l'application en accédant à l'onglet "Application"
    '  du Concepteur de projets ("Propriétés" sous le menu "Projet").


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Version.Text = "Version: " & versionlogi


        Copyright.Text = "Créer par yoann multigaming " & Today.Year

        If Directory.Exists(dosrepertoire) = False Then
            Directory.CreateDirectory(dosrepertoire)
        End If

        If Directory.Exists(dostemp) = False Then
            Directory.CreateDirectory(dostemp)
        End If

        If Directory.Exists(dosprogramefile) = False Then
            Directory.CreateDirectory(dosprogramefile)
        End If

        If Directory.Exists(dosthéme) = False Then
            Directory.CreateDirectory(dosthéme)
            Dim sw1 As New StreamWriter(théme)
            sw1.WriteLine(0)
            sw1.Close()
        End If

        If Directory.Exists(dosinstall) = False Then
            Directory.CreateDirectory(dosinstall)
            Directory.CreateDirectory(dosinstall & "\page1\")
            Dim sw1 As New StreamWriter(dosinstall & "\page.txt")
            sw1.WriteLine(1)
            sw1.Close()
            Dim sw2 As New StreamWriter(dosinstall & "\page1\logi.txt")
            sw2.WriteLine(0)
            sw2.Close()
        End If

        If Directory.Exists(dosupdate) = False Then
            Directory.CreateDirectory(dosupdate)
            Directory.CreateDirectory(dosupdate & "\page1\")
            Dim sw1 As New StreamWriter(dosupdate & "\page.txt")
            sw1.WriteLine(1)
            sw1.Close()
            Dim sw2 As New StreamWriter(dosupdate & "\page1\logi.txt")
            sw2.WriteLine(0)
            sw2.Close()
            Dim sw3 As New StreamWriter(dosupdate & "\update.txt")
            sw3.WriteLine(0)
            sw3.Close()
        End If

        If Directory.Exists(dosinstall) = False Then
            Directory.CreateDirectory(dosconnextion)
            Dim sw1 As New StreamWriter(connecter)
            sw1.WriteLine(0)
            sw1.Close()
        End If

        ApplicationTitle.Text = nom

        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Form1.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub ApplicationTitle_Click(sender As Object, e As EventArgs) Handles ApplicationTitle.Click

    End Sub

    Private Sub MainLayoutPanel_Paint(sender As Object, e As PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub
End Class
