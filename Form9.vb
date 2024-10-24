Imports System.ComponentModel
Imports System.IO
Imports System.Net

Public Class Form9
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.Text = nom
        PictureBox1.Image = Image.FromFile(dosrepertoire & "/logo.jpg")
        My.Computer.Network.DownloadFile(CLMipsite & "/CLM/organisation/nom.txt", dosrepertoire & "/nom.txt")
        My.Computer.Network.DownloadFile(CLMipsite & "/CLM/organisation/site.txt", dosrepertoire & "/site.txt")
        Dim lines1() As String = File.ReadAllLines(dosrepertoire & "/nom.txt")
        Dim lines2() As String = File.ReadAllLines(dosrepertoire & "/site.txt")
        TextBox1.Text = lines1(0)
        TextBox2.Text = lines2(0)
        File.Delete(dosrepertoire & "/nom.txt")
        File.Delete(dosrepertoire & "/site.txt")
        Text = nom & ": Panel administration"
        Label1.Text = "Adresse IP du serveur: " & CLMipsite
        Label3.Text = "Adresse IP du ftp: " & CLMPipserveur.Replace(CLMid, "").Replace(CLMpass, "").Replace("@", "")
        Label4.Text = "ID ftp: " & CLMid
        Label2.Text = "Version de votre CLM: " & versionlogi
        Label5.Text = "Version de CLM: 0.1"
        ListBox1.Items.Clear()
        Dim fwr As FtpWebRequest
        fwr = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/")
        fwr.Credentials = New NetworkCredential(CLMid, CLMpass)
        fwr.Method = WebRequestMethods.Ftp.ListDirectory
        Dim sr As New StreamReader(fwr.GetResponse().GetResponseStream())

        Dim str As String = sr.ReadLine()
        While Not str Is Nothing

            ListBox1.Items.Add(str)


            str = sr.ReadLine()

        End While

        ListBox1.Items.Remove("index.html")
        sr.Close()
        Label6.Text = "Nombre de compte: " & ListBox1.Items.Count
        ListBox1.Items.Clear()
        Dim fwr1 As FtpWebRequest
        fwr1 = FtpWebRequest.Create(CLMPipserveur & "/CLM/logiciel/profil/")
        fwr1.Credentials = New NetworkCredential(CLMid, CLMpass)
        fwr1.Method = WebRequestMethods.Ftp.ListDirectory
        Dim sr1 As New StreamReader(fwr1.GetResponse().GetResponseStream())

        Dim str1 As String = sr1.ReadLine()
        While Not str1 Is Nothing

            ListBox1.Items.Add(str1)


            str1 = sr1.ReadLine()

        End While

        ListBox1.Items.Remove("index.html")
        sr.Close()
        Label7.Text = "Nombre de profils: " & ListBox1.Items.Count
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        Clipboard.SetText(CLMpass)
        Form1.NotifyIcon1.BalloonTipTitle = "copier"
        Form1.NotifyIcon1.Text = nom & ": copier"
        Form1.NotifyIcon1.BalloonTipText = "le mots de passe ftp a bien êtê copier dans presse-papiers"
        Form1.NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        Form1.NotifyIcon1.ShowBalloonTip(1)
    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click
        Clipboard.SetText(clescrypte)
        Form1.NotifyIcon1.BalloonTipTitle = "copier"
        Form1.NotifyIcon1.Text = nom & ": copier"
        Form1.NotifyIcon1.BalloonTipText = " la clé de chiffrage a bien êtê copier dans presse-papiers"
        Form1.NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        Form1.NotifyIcon1.ShowBalloonTip(1)
    End Sub

    Private Sub Form9_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        PictureBox1.Image.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sw1 As New StreamWriter(dosrepertoire & "/nom.txt")
        sw1.WriteLine(TextBox1.Text)
        sw1.Close()
        My.Computer.Network.UploadFile(dosrepertoire & "/nom.txt", CLMPipserveur & "/CLM/organisation/nom.txt")
        Form1.Label22.Text = "Nom de l'organisation: " & TextBox1.Text
        File.Delete(dosrepertoire & "/nom.txt")
        MsgBox("Le nom de l'organisation a bien êtê change par: " & TextBox1.Text, MsgBoxStyle.Information)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sw1 As New StreamWriter(dosrepertoire & "/site.txt")
        sw1.WriteLine(TextBox2.Text)
        sw1.Close()
        My.Computer.Network.UploadFile(dosrepertoire & "/site.txt", CLMPipserveur & "/CLM/organisation/site.txt")
        Form1.siteorganisation = TextBox2.Text
        File.Delete(dosrepertoire & "/site.txt")
        MsgBox("Le site a bien êtê change par: " & TextBox2.Text, MsgBoxStyle.Information)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = 1 Then
            PictureBox1.Image.Dispose()
            Form1.PictureBox29.Image.Dispose()
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.Image.Save(dosrepertoire & "/logo.jpg")
            Form1.PictureBox29.Image = Image.FromFile(dosrepertoire & "/logo.jpg")
            Form1.GunaAdvenceButton3.Image = Form1.PictureBox29.Image
            My.Computer.Network.UploadFile(dosrepertoire & "/logo.jpg", CLMPipserveur & "/CLM/organisation/logo.jpg")
            MsgBox("l'image de l'organisation a bien êtê changer", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nom = TextBox3.Text
        Dim sw1 As New StreamWriter(dosrepertoire & "/nom.txt")
        sw1.WriteLine(TextBox3.Text)
        sw1.Close()
        My.Computer.Network.UploadFile(dosrepertoire & "/nom.txt", CLMPipserveur & "/CLM/config/nom.txt")
        File.Delete(dosrepertoire & "/nom.txt")
        nom = TextBox3.Text
        Form1.Label18.Text = "Nom de l'instance: " & nom
        Form1.Label23.Text = "Démarer " & nom & " avec Windows"
        Text = nom & ": Panel administration"
        Form1.Text = nom & ": Paramètre"
        MsgBox("le nom de l'instance a bien êtê modifier par: " & TextBox3.Text, MsgBoxStyle.Information)
    End Sub
End Class