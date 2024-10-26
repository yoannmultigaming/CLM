Imports System.ComponentModel
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.ComponentModel.Com2Interop


Public Class Form9
    Dim etap As Integer = 0
    Dim codegener As String = ""
    Dim srvsmtp As String = ""
    Dim usersmtp As String = ""
    Dim portsmtp As Integer = 0
    Dim mdpsmtp As String = ""
    Dim mailadmin As String = ""
    Dim mdpuser As Integer = 0
    Dim mdcuser As Integer = 0
    Dim mdouser As Integer = 0
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox3.Hide()
        TextBox10.UseSystemPasswordChar = True
        TextBox11.UseSystemPasswordChar = True
        mdpuser = 0
        mdcuser = 0
        mdouser = 0
        etap = 0
        ComboBox1.SelectedItem = "Uploader"
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
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        Dim fwr As FtpWebRequest
        fwr = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/")
        fwr.Credentials = New NetworkCredential(CLMid, CLMpass)
        fwr.Method = WebRequestMethods.Ftp.ListDirectory
        Dim sr As New StreamReader(fwr.GetResponse().GetResponseStream())

        Dim str As String = sr.ReadLine()
        While Not str Is Nothing

            ListBox1.Items.Add(str)
            ComboBox3.Items.Add(str)
            ComboBox2.Items.Add(str)


            str = sr.ReadLine()

        End While

        ListBox1.Items.Remove("index.html")
        ComboBox3.Items.Remove("index.html")
        ComboBox2.Items.Remove("index.html")
        sr.Close()
        Label6.Text = "Nombre de compte: " & ListBox1.Items.Count
        ListBox1.Items.Clear()
        ComboBox5.Items.Clear()
        Dim fwr1 As FtpWebRequest
        fwr1 = FtpWebRequest.Create(CLMPipserveur & "/CLM/logiciel/profil/")
        fwr1.Credentials = New NetworkCredential(CLMid, CLMpass)
        fwr1.Method = WebRequestMethods.Ftp.ListDirectory
        Dim sr1 As New StreamReader(fwr1.GetResponse().GetResponseStream())

        Dim str1 As String = sr1.ReadLine()
        While Not str1 Is Nothing

            ListBox1.Items.Add(str1)
            ComboBox5.Items.Add(str1)


            str1 = sr1.ReadLine()

        End While

        ListBox1.Items.Remove("index.html")
        ComboBox5.Items.Remove("index.html")
        sr.Close()
        Label7.Text = "Nombre de profils: " & ListBox1.Items.Count
        GroupBox4.Hide()

        If CLMsmtp = "" Then
            TextBox12.Hide()
            Label20.Hide()
        Else
            GunaButton1.Text = "Modifier"
            TextBox8.Text = CLMsmtp
            TextBox5.Text = CLMsmtpprot
            TextBox7.Text = CLMsmtpuser
            TextBox6.Text = CLMsmtpuserpass
            GunaButton1.Text = "Modifier"
            Label16.Show()
            Label14.Show()
            Label13.Show()
            Label12.Show()
            Label15.Show()
            TextBox8.Show()
            TextBox7.Show()
            TextBox6.Show()
            TextBox4.Show()
            TextBox5.Show()
            Button5.Show()
            Button5.Text = "Afficher"
            TextBox6.UseSystemPasswordChar = True
            TextBox12.Show()
            Label20.Show()
        End If

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

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If etap = 0 Then
            srvsmtp = TextBox8.Text
            usersmtp = TextBox7.Text
            portsmtp = TextBox5.Text
            mdpsmtp = TextBox6.Text
            Dim NumRandom As Integer
            Dim Rand As Random = New Random
            Dim NumStr As String
            Dim code As String = ""

            NumRandom = (Rand.Next(1, 999999))
            NumStr = Strings.Right("" & NumRandom.ToString(), 6)
            code = nom & "-" & NumStr

            Try
                Dim MyMailMessage As New MailMessage()
                Dim SMTPServer As New SmtpClient(TextBox8.Text)
                Dim mail = TextBox4.Text
                Dim message = "Bonjour et félicitation si vous recevez ce mail c'est que tout est correctement configuré." & vbNewLine & vbNewLine & "voici le code de confirmation: " & code
                MyMailMessage.From = New MailAddress(TextBox7.Text)
                MyMailMessage.To.Add(mail)
                MyMailMessage.Subject = ("configuration du service mail pour " & nom)
                MyMailMessage.Body = (message)
                SMTPServer.Port = (TextBox5.Text) 'Port
                SMTPServer.Credentials = New System.Net.NetworkCredential(TextBox7.Text, TextBox6.Text)
                SMTPServer.EnableSsl = True
                SMTPServer.Send(MyMailMessage) 'Envoi

                codegener = code
                MsgBox("Un mail de test à êtê envoyé à " & mail, MsgBoxStyle.Information, nom & "/ configuration du service mail")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Dim msg = MsgBox("Avez-vous bien reçu le mail ?", MsgBoxStyle.YesNo, nom & "/ configuration du service mail")
            If msg = MsgBoxResult.Yes Then
                etap = 1
                etap1()
            Else

            End If
        ElseIf etap = 1 Then
            If codegener = TextBox8.Text Then
                Dim texteEnBytes() As Byte = Encoding.UTF8.GetBytes(srvsmtp)
                Dim keyBytes() As Byte = Encoding.UTF8.GetBytes(clescrypte)
                Dim Crypto As New DESCryptoServiceProvider()
                Crypto.Key = keyBytes
                Crypto.IV = keyBytes
                Dim Icrypto As ICryptoTransform = Crypto.CreateEncryptor
                Dim Resultatbytes() As Byte = Icrypto.TransformFinalBlock(texteEnBytes, 0, texteEnBytes.Length)
                Dim srvsmtpcrypt = Convert.ToBase64String(Resultatbytes)

                Dim texteEnBytes2() As Byte = Encoding.UTF8.GetBytes(usersmtp)
                Dim keyBytes2() As Byte = Encoding.UTF8.GetBytes(clescrypte)
                Dim Crypto2 As New DESCryptoServiceProvider()
                Crypto2.Key = keyBytes2
                Crypto2.IV = keyBytes2
                Dim Icrypto2 As ICryptoTransform = Crypto2.CreateEncryptor
                Dim Resultatbytes2() As Byte = Icrypto2.TransformFinalBlock(texteEnBytes2, 0, texteEnBytes2.Length)
                Dim usersmtpcrypt = Convert.ToBase64String(Resultatbytes2)

                Dim texteEnBytes3() As Byte = Encoding.UTF8.GetBytes(portsmtp)
                Dim keyBytes3() As Byte = Encoding.UTF8.GetBytes(clescrypte)
                Dim Crypto3 As New DESCryptoServiceProvider()
                Crypto3.Key = keyBytes3
                Crypto3.IV = keyBytes3
                Dim Icrypto3 As ICryptoTransform = Crypto3.CreateEncryptor
                Dim Resultatbytes3() As Byte = Icrypto3.TransformFinalBlock(texteEnBytes3, 0, texteEnBytes3.Length)
                Dim portsmtpcrypt = Convert.ToBase64String(Resultatbytes3)

                Dim texteEnBytes4() As Byte = Encoding.UTF8.GetBytes(mdpsmtp)
                Dim keyBytes4() As Byte = Encoding.UTF8.GetBytes(clescrypte)
                Dim Crypto4 As New DESCryptoServiceProvider()
                Crypto4.Key = keyBytes4
                Crypto4.IV = keyBytes4
                Dim Icrypto4 As ICryptoTransform = Crypto4.CreateEncryptor
                Dim Resultatbytes4() As Byte = Icrypto4.TransformFinalBlock(texteEnBytes4, 0, texteEnBytes4.Length)
                Dim mdpsmtpcrypt = Convert.ToBase64String(Resultatbytes4)

                Dim sw1 As New StreamWriter(dosconnextion & "mailconfig.txt")
                sw1.WriteLine(srvsmtpcrypt)
                sw1.WriteLine(usersmtpcrypt)
                sw1.WriteLine(portsmtpcrypt)
                sw1.WriteLine(mdpsmtpcrypt)
                sw1.Close()

                My.Computer.Network.UploadFile(dosconnextion & "mailconfig.txt", CLMPipserveur & "/CLM/mail/mailconfig.txt")
                File.Delete(dosconnextion & "mailconfig.txt")
                CLMsmtp = srvsmtp
                CLMsmtpprot = portsmtp
                CLMsmtpuserpass = mdpsmtp
                CLMsmtpuser = usersmtp
                GunaButton1.Text = "Modifier"
                Label16.Show()
                Label14.Show()
                Label13.Show()
                Label12.Show()
                Label15.Show()
                TextBox8.Show()
                TextBox7.Show()
                TextBox6.Show()
                TextBox4.Show()
                TextBox5.Show()
                Button1.Show()
                Button1.Text = "afficher"
                TextBox6.UseSystemPasswordChar = True
                TextBox8.Text = CLMsmtp
                TextBox7.Text = CLMsmtpuser
                TextBox6.Text = CLMsmtpuserpass
                TextBox5.Text = CLMsmtpprot
                TextBox12.Show()
                Label20.Show()
                MsgBox("La configuration du mail est terminée", MsgBoxStyle.Information)
            Else
                MsgBox("Le code ne correspond pas", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Sub etap1()
        TextBox7.Hide()
        TextBox6.Hide()
        TextBox4.Hide()
        TextBox5.Hide()
        Label15.Hide()
        Label14.Hide()
        Label13.Hide()
        Label12.Hide()
        TextBox8.Clear()
        Label16.Text = "Entrer le code:"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Button5.Text = "afficher" Then
            TextBox6.UseSystemPasswordChar = False
            Button5.Text = "cacher"
        Else
            TextBox6.UseSystemPasswordChar = True
            Button5.Text = "afficher"
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If mdpuser = 0 Then
            TextBox11.UseSystemPasswordChar = False
            mdpuser = 1
            PictureBox2.Image = My.Resources.erggr
        Else
            TextBox11.UseSystemPasswordChar = True
            mdpuser = 0
            PictureBox2.Image = My.Resources.gyugcdyug
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If mdcuser = 0 Then
            TextBox10.UseSystemPasswordChar = False
            mdcuser = 1
            PictureBox3.Image = My.Resources.erggr
        Else
            TextBox10.UseSystemPasswordChar = True
            mdcuser = 0
            PictureBox3.Image = My.Resources.gyugcdyug
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        GunaButton2.Text = "Ajouter: " & TextBox9.Text
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        If TextBox9.Text = "" Then
            MsgBox("entrer un nom de compte", MsgBoxStyle.Exclamation, nom & " / ajouter un compte")
        Else
            If TextBox11.Text = "" Then
                MsgBox("entrer un mot de passe", MsgBoxStyle.Exclamation, nom & " / ajouter un compte")
            Else
                If TextBox10.Text = "" Then
                    MsgBox("Confirmer votre mot de passe", MsgBoxStyle.Exclamation, nom & " / ajouter un compte")
                Else
                    If TextBox11.Text = TextBox10.Text Then
                        If TextBox12.Visible = True Then
                            If TextBox12.Text = "" Then
                                MsgBox("entrer une adresse mail", MsgBoxStyle.Exclamation, nom & " / ajouter un compte")
                            Else
                                If TextBox12.Text.Contains(".") And TextBox12.Text.Contains("@") Then
                                    GunaButton2.Enabled = False
                                    createcompte()
                                Else
                                    MsgBox("entrer une adresse mail valide", MsgBoxStyle.Exclamation, nom & " / ajouter un compte")
                                End If
                            End If
                        Else
                            GunaButton2.Enabled = False
                            createcompte()
                        End If
                    Else
                        MsgBox("Les mots de passe ne corresponds pas", MsgBoxStyle.Exclamation, nom & " / ajouter un compte")
                    End If
                End If
            End If
        End If
    End Sub
    Sub createcompte()
        Try
            Dim MaRequete As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(CLMPipserveur & "/CLM/utilisateur/" & TextBox9.Text & "/"), System.Net.FtpWebRequest)
            Dim ftpStream As Stream = Nothing

            MaRequete.Credentials = New System.Net.NetworkCredential(CLMid, CLMpass)
            MaRequete.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response As FtpWebResponse = CType(MaRequete.GetResponse, FtpWebResponse)
            ftpStream = response.GetResponseStream
            ftpStream.Close()
            response.Close()

            If GunaGoogleSwitch1.Checked = True Then
                Dim sw1 As New StreamWriter(dosrepertoire & "\lock.txt")
                sw1.WriteLine(1)
                sw1.Close()
            Else
                Dim sw1 As New StreamWriter(dosrepertoire & "\lock.txt")
                sw1.WriteLine(0)
                sw1.Close()
            End If

            If ComboBox1.SelectedItem = "Administrateur" Then
                Dim sw2 As New StreamWriter(dosrepertoire & "\grade.txt")
                sw2.WriteLine(2)
                sw2.Close()
            Else
                Dim sw2 As New StreamWriter(dosrepertoire & "\grade.txt")
                sw2.WriteLine(1)
                sw2.Close()
            End If

            Dim texteEnBytes() As Byte = Encoding.UTF8.GetBytes(TextBox11.Text)
            Dim keyBytes() As Byte = Encoding.UTF8.GetBytes(clescrypte)
            Dim Crypto As New DESCryptoServiceProvider()
            Crypto.Key = keyBytes
            Crypto.IV = keyBytes
            Dim Icrypto As ICryptoTransform = Crypto.CreateEncryptor
            Dim Resultatbytes() As Byte = Icrypto.TransformFinalBlock(texteEnBytes, 0, texteEnBytes.Length)
            Dim motdepasse = Convert.ToBase64String(Resultatbytes)
            Dim sw4 As New StreamWriter(dosrepertoire & "\mdp.txt")
            sw4.WriteLine(motdepasse)
            sw4.Close()

            If TextBox12.Visible = True Then
                Dim texteEnBytes2() As Byte = Encoding.UTF8.GetBytes(TextBox12.Text)
                Dim keyBytes2() As Byte = Encoding.UTF8.GetBytes(clescrypte)
                Dim Crypto2 As New DESCryptoServiceProvider()
                Crypto2.Key = keyBytes2
                Crypto2.IV = keyBytes2
                Dim Icrypto2 As ICryptoTransform = Crypto2.CreateEncryptor
                Dim Resultatbytes2() As Byte = Icrypto2.TransformFinalBlock(texteEnBytes2, 0, texteEnBytes2.Length)
                Dim mail = Convert.ToBase64String(Resultatbytes2)
                Dim sw3 As New StreamWriter(dosrepertoire & "\mail.txt")
                sw3.WriteLine(mail)
                sw3.Close()
                My.Computer.Network.UploadFile(dosrepertoire & "\mail.txt", CLMPipserveur & "/CLM/utilisateur/" & TextBox9.Text & "/mail.txt")
                File.Delete(dosrepertoire & "\mail.txt")

                Try
                    Dim MyMailMessage As New MailMessage()
                    Dim SMTPServer As New SmtpClient(CLMsmtp)
                    Dim mail2 = TextBox12.Text
                    Dim message = "Bonjour; " & TextBox9.Text & vbNewLine & vbNewLine & "Votre compte " & nom & " a bien êtê créer, votre grade: " & ComboBox1.SelectedItem & vbNewLine & vbNewLine & "Votre nom d'utilisateur est: " & TextBox9.Text & vbNewLine & vbNewLine & "Votre mot de passe est: " & TextBox11.Text & vbNewLine & vbNewLine & "Nous vous souhaiton une bonne journée" & vbNewLine & vbNewLine & "Cordialement" & vbNewLine & "- " & TextBox1.Text
                    MyMailMessage.From = New MailAddress(CLMsmtpuser)
                    MyMailMessage.To.Add(mail2)
                    MyMailMessage.Subject = ("Création de votre compte " & nom)
                    MyMailMessage.Body = (message)
                    SMTPServer.Port = (TextBox5.Text) 'Port
                    SMTPServer.Credentials = New System.Net.NetworkCredential(CLMsmtpuser, CLMsmtpuserpass)
                    SMTPServer.EnableSsl = True
                    SMTPServer.Send(MyMailMessage) 'Envoi
                Catch ex As Exception

                End Try

            End If
            My.Computer.Network.UploadFile(dosrepertoire & "\mdp.txt", CLMPipserveur & "/CLM/utilisateur/" & TextBox9.Text & "/mdp.txt")
            My.Computer.Network.UploadFile(dosrepertoire & "\grade.txt", CLMPipserveur & "/CLM/utilisateur/" & TextBox9.Text & "/grade.txt")
            My.Computer.Network.UploadFile(dosrepertoire & "\lock.txt", CLMPipserveur & "/CLM/utilisateur/" & TextBox9.Text & "/lock.txt")
            File.Delete(dosrepertoire & "\mdp.txt")
            File.Delete(dosrepertoire & "\grade.txt")
            File.Delete(dosrepertoire & "\lock.txt")

            ListBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            Dim fwr As FtpWebRequest
            fwr = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/")
            fwr.Credentials = New NetworkCredential(CLMid, CLMpass)
            fwr.Method = WebRequestMethods.Ftp.ListDirectory
            Dim sr As New StreamReader(fwr.GetResponse().GetResponseStream())

            Dim str As String = sr.ReadLine()
            While Not str Is Nothing

                ListBox1.Items.Add(str)
                ComboBox2.Items.Add(str)
                ComboBox3.Items.Add(str)

                str = sr.ReadLine()

            End While

            ListBox1.Items.Remove("index.html")
            ComboBox2.Items.Remove("index.html")
            ComboBox3.Items.Remove("index.html")
            sr.Close()
            Label6.Text = "Nombre de compte: " & ListBox1.Items.Count
            ListBox1.Items.Clear()
            GunaButton2.Enabled = True
            GroupBox3.Hide()
            MsgBox("Le compte: " & TextBox9.Text & " a bien êtê créer", MsgBoxStyle.Information, nom & " / ajouter un compte")
            TextBox9.Clear()
            TextBox11.Clear()
            TextBox10.Clear()
            If TextBox12.Visible = True Then
                TextBox12.Clear()
            End If
            TextBox11.UseSystemPasswordChar = True
            TextBox10.UseSystemPasswordChar = True
            ComboBox1.SelectedItem = "Uploader"
            PictureBox3.Image = My.Resources.gyugcdyug
            PictureBox2.Image = My.Resources.gyugcdyug

        Catch ex As Exception
            GunaButton2.Enabled = True
            MsgBox("une erreur est survenue (il est possible que le compte: " & TextBox9.Text & " exsite Déjà)", MsgBoxStyle.Critical, nom & " / ajouter un compte")
        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        MsgBox("Bloquer le compte signifie que ce compte poura êtres modifier que par le compte, il ne poura pas être supprimer ou modifier par le panel administrateur.", MsgBoxStyle.Information, nom & " / ajouter un compte")
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        If ComboBox1.SelectedItem = "Administrateur" Then
            GunaGoogleSwitch1.Checked = True
        Else
            GunaGoogleSwitch1.Checked = False
        End If
    End Sub
    Private Sub ComboBox3_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedValueChanged
        GunaButton3.Text = "Supprimer: " & ComboBox3.SelectedItem
        My.Computer.Network.DownloadFile(CLMipsite & "/CLM/utilisateur/" & ComboBox3.SelectedItem & "/lock.txt", dosrepertoire & "/lock.txt")
        Dim lines() As String = File.ReadAllLines(dosrepertoire & "/lock.txt")
        File.Delete(dosrepertoire & "/lock.txt")
        If lines(0) = 1 Then
            GunaButton3.Enabled = False
            MsgBox("Le compte: " & ComboBox3.SelectedItem & " est blocker vous ne pouvez pas le supprimer", MsgBoxStyle.Exclamation, nom & " / suprimer un compte")
        Else
            GunaButton3.Enabled = True
        End If
    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        Dim msg = MsgBox("Voulez-vous vraiment supprimer: " & ComboBox3.SelectedItem & " ?", MsgBoxStyle.YesNo, nom & " / suprimer un compte")
        If msg = MsgBoxResult.Yes Then
            GunaButton3.Enabled = False
            Try
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/utilisateur/" & ComboBox3.SelectedItem & "/mail.txt", dosrepertoire & "/mail.txt")
                File.Delete(dosrepertoire & "/mail.txt")

                Dim ftreq2 As FtpWebRequest = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/" & ComboBox3.SelectedItem & "/mail.txt")
                ftreq2.Method = WebRequestMethods.Ftp.DeleteFile
                ftreq2.Credentials = New NetworkCredential(CLMid, CLMpass)
                Dim ftpresp2 As FtpWebResponse = ftreq2.GetResponse

                delcompte()
            Catch ex As Exception
                delcompte()
            End Try
        Else
            MsgBox("Action annuler", MsgBoxStyle.Information, nom & " / suprimer un compte")
        End If
    End Sub
    Sub delcompte()
        Dim ftreq2 As FtpWebRequest = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/" & ComboBox3.SelectedItem & "/grade.txt")
        ftreq2.Method = WebRequestMethods.Ftp.DeleteFile
        ftreq2.Credentials = New NetworkCredential(CLMid, CLMpass)
        Dim ftpresp2 As FtpWebResponse = ftreq2.GetResponse

        Dim ftreq3 As FtpWebRequest = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/" & ComboBox3.SelectedItem & "/lock.txt")
        ftreq3.Method = WebRequestMethods.Ftp.DeleteFile
        ftreq3.Credentials = New NetworkCredential(CLMid, CLMpass)
        Dim ftpresp3 As FtpWebResponse = ftreq3.GetResponse

        Dim ftreq4 As FtpWebRequest = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/" & ComboBox3.SelectedItem & "/mdp.txt")
        ftreq4.Method = WebRequestMethods.Ftp.DeleteFile
        ftreq4.Credentials = New NetworkCredential(CLMid, CLMpass)
        Dim ftpresp4 As FtpWebResponse = ftreq4.GetResponse

        Dim ftreq5 As FtpWebRequest = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/" & ComboBox3.SelectedItem & "/")
        ftreq5.Method = WebRequestMethods.Ftp.RemoveDirectory
        ftreq5.Credentials = New NetworkCredential(CLMid, CLMpass)
        Dim ftpresp5 As FtpWebResponse = ftreq5.GetResponse

        GunaButton2.Enabled = True
        GroupBox3.Hide()
        MsgBox("Le compte: " & ComboBox3.SelectedItem & " a bien êtê supprimer", MsgBoxStyle.Information, nom & " / suppirmer un compte")

        ListBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        Dim fwr As FtpWebRequest
        fwr = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/")
        fwr.Credentials = New NetworkCredential(CLMid, CLMpass)
        fwr.Method = WebRequestMethods.Ftp.ListDirectory
        Dim sr As New StreamReader(fwr.GetResponse().GetResponseStream())

        Dim str As String = sr.ReadLine()
        While Not str Is Nothing

            ListBox1.Items.Add(str)
            ComboBox2.Items.Add(str)
            ComboBox3.Items.Add(str)

            str = sr.ReadLine()

        End While

        ListBox1.Items.Remove("index.html")
        ComboBox2.Items.Remove("index.html")
        ComboBox3.Items.Remove("index.html")
        sr.Close()
        Label6.Text = "Nombre de compte: " & ListBox1.Items.Count
        ListBox1.Items.Clear()
        GunaButton3.Text = "Supprimer:"
    End Sub
    Private Sub ComboBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
        GroupBox3.Show()
        TextBox14.UseSystemPasswordChar = True
        PictureBox5.Image = My.Resources.gyugcdyug
        mdouser = 0
        My.Computer.Network.DownloadFile(CLMipsite & "/CLM/utilisateur/" & ComboBox2.SelectedItem & "/lock.txt", dosrepertoire & "/lock.txt")
        Dim lines() As String = File.ReadAllLines(dosrepertoire & "/lock.txt")
        File.Delete(dosrepertoire & "/lock.txt")
        GroupBox3.Text = "Information du compte: " & ComboBox2.SelectedItem
        If lines(0) = 1 Then
            GroupBox3.Enabled = False
            MsgBox("Le compte: " & ComboBox2.SelectedItem & " est blocker vous ne pouvez pas le modifier", MsgBoxStyle.Exclamation, nom & " / modifier un compte")
        Else
            GroupBox3.Enabled = True
        End If
        TextBox13.Text = ComboBox2.SelectedItem
        My.Computer.Network.DownloadFile(CLMipsite & "/CLM/utilisateur/" & ComboBox2.SelectedItem & "/mdp.txt", dosrepertoire & "/mdp.txt")
        Dim lines2() As String = File.ReadAllLines(dosrepertoire & "/mdp.txt")
        File.Delete(dosrepertoire & "/mdp.txt")
        Dim Resultatbyte2() As Byte = Convert.FromBase64String(lines2(0))
        Dim keyBytes2() As Byte = Encoding.UTF8.GetBytes(clescrypte)
        Dim Crypto2 As New DESCryptoServiceProvider()
        Crypto2.Key = keyBytes2
        Crypto2.IV = keyBytes2
        Dim Icrypto2 As ICryptoTransform = Crypto2.CreateDecryptor()
        Dim donné2() As Byte = Icrypto2.TransformFinalBlock(Resultatbyte2, 0, Resultatbyte2.Length)
        Dim motsdepasseclient = Encoding.UTF8.GetString(donné2)
        TextBox14.Text = motsdepasseclient

        My.Computer.Network.DownloadFile(CLMipsite & "/CLM/utilisateur/" & ComboBox2.SelectedItem & "/grade.txt", dosrepertoire & "/grade.txt")
        Dim lines3() As String = File.ReadAllLines(dosrepertoire & "/grade.txt")
        File.Delete(dosrepertoire & "/grade.txt")
        If lines3(0) = 2 Then
            ComboBox4.SelectedItem = "Administrateur"
        Else
            ComboBox4.SelectedItem = "Uploader"
        End If

        If CLMsmtp = "" Then

        Else
            Try
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/utilisateur/" & ComboBox2.SelectedItem & "/mail.txt", dosrepertoire & "/mail.txt")
                Dim lines4() As String = File.ReadAllLines(dosrepertoire & "/mail.txt")
                File.Delete(dosrepertoire & "/mail.txt")
                Dim Resultatbyte3() As Byte = Convert.FromBase64String(lines4(0))
                Dim keyBytes3() As Byte = Encoding.UTF8.GetBytes(clescrypte)
                Dim Crypto3 As New DESCryptoServiceProvider()
                Crypto3.Key = keyBytes3
                Crypto3.IV = keyBytes3
                Dim Icrypto3 As ICryptoTransform = Crypto3.CreateDecryptor()
                Dim donné3() As Byte = Icrypto3.TransformFinalBlock(Resultatbyte3, 0, Resultatbyte3.Length)
                Dim mail = Encoding.UTF8.GetString(donné3)
                TextBox15.Text = mail
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If mdouser = 0 Then
            TextBox14.UseSystemPasswordChar = False
            PictureBox5.Image = My.Resources.erggr
            mdouser = 1
        Else
            TextBox14.UseSystemPasswordChar = True
            PictureBox5.Image = My.Resources.gyugcdyug
            mdouser = 0
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If ComboBox4.SelectedItem = "Administrateur" Then
            Dim sw1 As New StreamWriter(dosrepertoire & "\grade.txt")
            sw1.WriteLine(2)
            sw1.Close()
        Else
            Dim sw1 As New StreamWriter(dosrepertoire & "\grade.txt")
            sw1.WriteLine(1)
            sw1.Close()
        End If
        My.Computer.Network.UploadFile(dosrepertoire & "\grade.txt", CLMPipserveur & "/CLM/utilisateur/" & ComboBox2.SelectedItem & "/grade.txt")
        File.Delete(dosrepertoire & "\grade.txt")
        MsgBox("Le grade du compte: " & ComboBox2.SelectedItem & " est maintenant: " & ComboBox4.SelectedItem, MsgBoxStyle.Information, nom & " / modifier un compte")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox14.Text = "" Then
            MsgBox("Entrer un mots de passe", MsgBoxStyle.Critical, nom & " / modifier un compte")
        Else
            Dim texteEnBytes() As Byte = Encoding.UTF8.GetBytes(TextBox14.Text)
            Dim keyBytes() As Byte = Encoding.UTF8.GetBytes(clescrypte)
            Dim Crypto As New DESCryptoServiceProvider()
            Crypto.Key = keyBytes
            Crypto.IV = keyBytes
            Dim Icrypto As ICryptoTransform = Crypto.CreateEncryptor
            Dim Resultatbytes() As Byte = Icrypto.TransformFinalBlock(texteEnBytes, 0, texteEnBytes.Length)
            Dim motdepasse = Convert.ToBase64String(Resultatbytes)
            Dim sw1 As New StreamWriter(dosrepertoire & "\mdp.txt")
            sw1.WriteLine(motdepasse)
            sw1.Close()
            My.Computer.Network.UploadFile(dosrepertoire & "\mdp.txt", CLMPipserveur & "/CLM/utilisateur/" & ComboBox2.SelectedItem & "/mdp.txt")
            File.Delete(dosrepertoire & "\mdp.txt")
            MsgBox("Le mots de passe du compte: " & ComboBox2.SelectedItem & " est maintenant: " & TextBox14.Text, MsgBoxStyle.Information, nom & " / modifier un compte")
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox15.Text = "" Then
            MsgBox("Entrer une addresse mail", MsgBoxStyle.Critical, nom & " / modifier un compte")
        Else
            If TextBox15.Text.Contains("@") And TextBox15.Text.Contains(".") Then
                Dim texteEnBytes() As Byte = Encoding.UTF8.GetBytes(TextBox15.Text)
                Dim keyBytes() As Byte = Encoding.UTF8.GetBytes(clescrypte)
                Dim Crypto As New DESCryptoServiceProvider()
                Crypto.Key = keyBytes
                Crypto.IV = keyBytes
                Dim Icrypto As ICryptoTransform = Crypto.CreateEncryptor
                Dim Resultatbytes() As Byte = Icrypto.TransformFinalBlock(texteEnBytes, 0, texteEnBytes.Length)
                Dim motdepasse = Convert.ToBase64String(Resultatbytes)
                Dim sw1 As New StreamWriter(dosrepertoire & "\mail.txt")
                sw1.WriteLine(motdepasse)
                sw1.Close()
                My.Computer.Network.UploadFile(dosrepertoire & "\mail.txt", CLMPipserveur & "/CLM/utilisateur/" & ComboBox2.SelectedItem & "/mail.txt")
                File.Delete(dosrepertoire & "\mail.txt")
                MsgBox("L'addresse mail du compte: " & ComboBox2.SelectedItem & " est maintenant: " & TextBox15.Text, MsgBoxStyle.Information, nom & " / modifier un compte")
            Else
                MsgBox("Entrer une addresse mail valide", MsgBoxStyle.Critical, nom & " / modifier un compte")
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox13.Text = "" Then

        Else
            Try
                Dim ftreq As FtpWebRequest = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/" & ComboBox2.SelectedItem)
                ftreq.Method = WebRequestMethods.Ftp.Rename
                ftreq.RenameTo = TextBox13.Text
                ftreq.Credentials = New NetworkCredential(CLMid, CLMpass)
                Dim ftpresp As FtpWebResponse = ftreq.GetResponse
                MsgBox("Le compte: " & ComboBox2.SelectedItem & " a êtê renomer en: " & TextBox13.Text, MsgBoxStyle.Information, nom & " / modifier un compte")
                ListBox1.Items.Clear()
                ComboBox2.Items.Clear()
                ComboBox3.Items.Clear()
                Dim fwr As FtpWebRequest
                fwr = FtpWebRequest.Create(CLMPipserveur & "/CLM/utilisateur/")
                fwr.Credentials = New NetworkCredential(CLMid, CLMpass)
                fwr.Method = WebRequestMethods.Ftp.ListDirectory
                Dim sr As New StreamReader(fwr.GetResponse().GetResponseStream())

                Dim str As String = sr.ReadLine()
                While Not str Is Nothing

                    ListBox1.Items.Add(str)
                    ComboBox2.Items.Add(str)
                    ComboBox3.Items.Add(str)

                    str = sr.ReadLine()

                End While

                ListBox1.Items.Remove("index.html")
                ComboBox2.Items.Remove("index.html")
                ComboBox3.Items.Remove("index.html")
                sr.Close()
                Label6.Text = "Nombre de compte: " & ListBox1.Items.Count
                ListBox1.Items.Clear()
                ComboBox2.SelectedItem = TextBox13.Text
                GunaButton3.Enabled = False
            Catch ex As Exception
                MsgBox("Une erreur est survenue (il est possible de le compte: " & TextBox13.Text & " exsite déjà)", MsgBoxStyle.Exclamation, nom & " / modifier un compte")
            End Try
        End If
    End Sub
    Private Sub ComboBox5_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedValueChanged
        GroupBox4.Text = "Modification de " & ComboBox5.SelectedItem
        TextBox16.Text = ComboBox5.SelectedItem
        GroupBox4.Show()
        If ComboBox5.Text = "default" Then
            TextBox16.Enabled = False
            Button10.Enabled = False
        Else
            TextBox16.Enabled = True
            Button10.Enabled = True
        End If

        ListBox2.Items.Clear()
        ComboBox6.Items.Clear()
        ComboBox7.Items.Clear()
        Dim fwr As FtpWebRequest
        fwr = FtpWebRequest.Create(CLMPipserveur & "/CLM/logiciel/profil/" & ComboBox5.SelectedItem & "/categorie/")
        fwr.Credentials = New NetworkCredential(CLMid, CLMpass)
        fwr.Method = WebRequestMethods.Ftp.ListDirectory
        Dim sr As New StreamReader(fwr.GetResponse().GetResponseStream())

        Dim str As String = sr.ReadLine()
        While Not str Is Nothing

            ListBox2.Items.Add(str)
            ComboBox6.Items.Add(str)
            ComboBox7.Items.Add(str)


            str = sr.ReadLine()

        End While

        ListBox2.Items.Remove("index.html")
        ComboBox6.Items.Remove("index.html")
        ComboBox7.Items.Remove("index.html")
        sr.Close()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If ComboBox7.SelectedItem = "" Then
            MsgBox("Merci de selection une catégorie", MsgBoxStyle.Exclamation, nom & " / modifier une catégorie")
        Else
            If TextBox18.Text = "" Then
                MsgBox("Merci d'entre un nom", MsgBoxStyle.Exclamation, nom & " / modifier une catégorie")
            Else
                Try
                    Dim ftreq As FtpWebRequest = FtpWebRequest.Create(CLMPipserveur & "/CLM/logiciel/profil/" & ComboBox5.SelectedItem & "/categorie/" & ComboBox7.SelectedItem)
                    ftreq.Method = WebRequestMethods.Ftp.Rename
                    ftreq.RenameTo = TextBox18.Text
                    ftreq.Credentials = New NetworkCredential(CLMid, CLMpass)
                    Dim ftpresp As FtpWebResponse = ftreq.GetResponse
                    MsgBox("La catégoire: " & ComboBox7.SelectedItem & " a êtê renomer en: " & TextBox18.Text, MsgBoxStyle.Information, nom & " / modifier une catégorie")
                    ListBox2.Items.Clear()
                    ComboBox6.Items.Clear()
                    ComboBox7.Items.Clear()
                    Dim fwr As FtpWebRequest
                    fwr = FtpWebRequest.Create(CLMPipserveur & "/CLM/logiciel/profil/" & ComboBox5.SelectedItem & "/categorie/")
                    fwr.Credentials = New NetworkCredential(CLMid, CLMpass)
                    fwr.Method = WebRequestMethods.Ftp.ListDirectory
                    Dim sr As New StreamReader(fwr.GetResponse().GetResponseStream())

                    Dim str As String = sr.ReadLine()
                    While Not str Is Nothing

                        ListBox2.Items.Add(str)
                        ComboBox6.Items.Add(str)
                        ComboBox7.Items.Add(str)


                        str = sr.ReadLine()

                    End While

                    ListBox2.Items.Remove("index.html")
                    ComboBox6.Items.Remove("index.html")
                    ComboBox7.Items.Remove("index.html")
                    sr.Close()
                    ComboBox7.SelectedItem = TextBox18.Text
                    TextBox18.Clear()
                Catch ex As Exception
                    MsgBox("Une erreur est survenue (il est possible que la catégorie: " & TextBox18.Text & " exsite déjà)", MsgBoxStyle.Exclamation, nom & " / modifier une catégorie")
                End Try
            End If
        End If
    End Sub
End Class