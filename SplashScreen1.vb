Imports System.IO
Public NotInheritable Class SplashScreen1

    'TODO: ce formulaire peut facilement être configuré comme écran de démarrage de l'application en accédant à l'onglet "Application"
    '  du Concepteur de projets ("Propriétés" sous le menu "Projet").


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Version.Text = "Version: " & versionlogi


        Copyright.Text = My.Application.Info.Copyright

        If Directory.Exists(dosrepertoire) = False Then
            Directory.CreateDirectory(dosrepertoire)
        End If

        If Directory.Exists(dosthéme) = False Then
            Directory.CreateDirectory(dosthéme)
            Dim sw1 As New StreamWriter(théme)
            sw1.WriteLine(0)
            sw1.Close()
        End If

        If Directory.Exists(dosconnextion) = False Then
            Directory.CreateDirectory(dosconnextion)
            Dim sw1 As New StreamWriter(connecter)
            sw1.WriteLine(0)
            sw1.Close()
        End If

        Timer1.Start()
    End Sub

    Private Sub ApplicationTitle_Click(sender As Object, e As EventArgs) Handles ApplicationTitle.Click

    End Sub

    Private Sub MainLayoutPanel_Paint(sender As Object, e As PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Form1.Show()
    End Sub
End Class
