Imports System.ComponentModel
Imports System.IO
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text

Public Class Form5
    Dim etap As Integer = 0
    Dim codegener As String = ""
    Dim srvsmtp As String = ""
    Dim usersmtp As String = ""
    Dim portsmtp As Integer = 0
    Dim mdpsmtp As String = ""
    Dim mailadmin As String = ""
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = nom & " configuration du service mail"
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If etap = 0 Then
            srvsmtp = TextBox1.Text
            usersmtp = TextBox2.Text
            portsmtp = TextBox5.Text
            mdpsmtp = TextBox3.Text
            Dim NumRandom As Integer
            Dim Rand As Random = New Random
            Dim NumStr As String
            Dim code As String = ""

            NumRandom = (Rand.Next(1, 999999))
            NumStr = Strings.Right("" & NumRandom.ToString(), 6)
            code = nom & "-" & NumStr

            Dim MyMailMessage As New MailMessage()
            Dim SMTPServer As New SmtpClient(TextBox1.Text)
            Dim mail = TextBox4.Text
            Dim message = "Bonjour et félicitation si vous recevez ce mail c'est que tout est correctement configuré." & vbNewLine & vbNewLine & "voici le code de confirmation: " & code
            MyMailMessage.From = New MailAddress(TextBox2.Text)
            MyMailMessage.To.Add(mail)
            MyMailMessage.Subject = ("configuration du service mail pour " & nom)
            MyMailMessage.Body = (message)
            SMTPServer.Port = (TextBox5.Text) 'Port
            SMTPServer.Credentials = New System.Net.NetworkCredential(TextBox2.Text, TextBox3.Text)
            SMTPServer.EnableSsl = True
            SMTPServer.Send(MyMailMessage) 'Envoi
            codegener = code
            MsgBox("Le un mail de test à éter envoyé à " & mail, MsgBoxStyle.Information, nom & "/ configuration du service mail")
            Dim msg = MsgBox("Avez-vous bien reçu le mail ?", MsgBoxStyle.YesNo, nom & "/ configuration du service mail")
            If msg = MsgBoxResult.Yes Then
                etap = 1
                etap1()
            Else

            End If
        ElseIf etap = 1 Then
            If codegener = TextBox1.Text Then
                Dim texteEnBytes() As Byte = Encoding.UTF8.GetBytes(usersmtp)
                Dim keyBytes() As Byte = Encoding.UTF8.GetBytes(Form4.clés)
                Dim Crypto As New DESCryptoServiceProvider()
                Crypto.Key = keyBytes
                Crypto.IV = keyBytes
                Dim Icrypto As ICryptoTransform = Crypto.CreateEncryptor
                Dim Resultatbytes() As Byte = Icrypto.TransformFinalBlock(texteEnBytes, 0, texteEnBytes.Length)
                Dim srvsmtpcrypt = Convert.ToBase64String(Resultatbytes)

                Dim texteEnBytes2() As Byte = Encoding.UTF8.GetBytes(srvsmtp)
                Dim keyBytes2() As Byte = Encoding.UTF8.GetBytes(Form4.clés)
                Dim Crypto2 As New DESCryptoServiceProvider()
                Crypto2.Key = keyBytes2
                Crypto2.IV = keyBytes2
                Dim Icrypto2 As ICryptoTransform = Crypto2.CreateEncryptor
                Dim Resultatbytes2() As Byte = Icrypto2.TransformFinalBlock(texteEnBytes2, 0, texteEnBytes2.Length)
                Dim usersmtpcrypt = Convert.ToBase64String(Resultatbytes2)

                Dim texteEnBytes3() As Byte = Encoding.UTF8.GetBytes(portsmtp)
                Dim keyBytes3() As Byte = Encoding.UTF8.GetBytes(Form4.clés)
                Dim Crypto3 As New DESCryptoServiceProvider()
                Crypto3.Key = keyBytes3
                Crypto3.IV = keyBytes3
                Dim Icrypto3 As ICryptoTransform = Crypto3.CreateEncryptor
                Dim Resultatbytes3() As Byte = Icrypto3.TransformFinalBlock(texteEnBytes3, 0, texteEnBytes3.Length)
                Dim portsmtpcrypt = Convert.ToBase64String(Resultatbytes3)

                Dim texteEnBytes4() As Byte = Encoding.UTF8.GetBytes(mdpsmtp)
                Dim keyBytes4() As Byte = Encoding.UTF8.GetBytes(Form4.clés)
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
                sw1.WriteLine(portsmtpcrypt)
                sw1.WriteLine(mdpsmtpcrypt)
                sw1.Close()

                My.Computer.Network.UploadFile(dosconnextion & "mailconfig.txt", Form3.ipserveur & "/CLM/mail/mailconfig.txt")
                File.Delete(dosconnextion & "mailconfig.txt")
                etap2()
            End If
        ElseIf etap = 2 Then
            mailadmin = TextBox1.Text
            TextBox1.Clear()
            etap3()
        ElseIf etap = 3 Then
            If TextBox1.Text = mailadmin Then
                Dim texteEnBytes() As Byte = Encoding.UTF8.GetBytes(TextBox1.Text)
                Dim keyBytes() As Byte = Encoding.UTF8.GetBytes(Form4.clés)
                Dim Crypto As New DESCryptoServiceProvider()
                Crypto.Key = keyBytes
                Crypto.IV = keyBytes
                Dim Icrypto As ICryptoTransform = Crypto.CreateEncryptor
                Dim Resultatbytes() As Byte = Icrypto.TransformFinalBlock(texteEnBytes, 0, texteEnBytes.Length)
                Dim mailadmincrypt = Convert.ToBase64String(Resultatbytes)
                Dim sw1 As New StreamWriter(dosconnextion & "mail.txt")
                sw1.WriteLine(mailadmincrypt)
                sw1.Close()
                My.Computer.Network.UploadFile(dosconnextion & "mail.txt", Form3.ipserveur & "/CLM/utilisateur/" & Form4.user1234 & "/mail.txt")
                File.Delete(dosconnextion & "mail.txt")


                Dim MyMailMessage As New MailMessage()
                Dim SMTPServer As New SmtpClient(srvsmtp)
                Dim mail = TextBox1.Text
                Dim message = "Bonjour administrateur, " & Form4.user1234 & " votre adresse mail a bien été enregistrer, pour des raison de sécurité nous vous envoyons la clé de cryptage." & vbNewLine & vbNewLine & "Clé de cryptage: " & Form4.clés
                MyMailMessage.From = New MailAddress(usersmtp)
                MyMailMessage.To.Add(mail)
                MyMailMessage.Subject = (nom & " clé de cryptage")
                MyMailMessage.Body = (message)
                SMTPServer.Port = (portsmtp) 'Port
                SMTPServer.Credentials = New System.Net.NetworkCredential(usersmtp, mdpsmtp)
                SMTPServer.EnableSsl = True
                SMTPServer.Send(MyMailMessage) 'Envoi
                MsgBox("La configuration du serveur est terminée", MsgBoxStyle.Information)
                Form4.encours = 0
                Close()
            End If
        End If
    End Sub
    Sub etap1()
        TextBox2.Hide()
        TextBox3.Hide()
        TextBox4.Hide()
        TextBox5.Hide()
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Hide()
        TextBox1.Clear()
        Label1.Text = "Entrer le code:"
    End Sub
    Sub etap2()
        TextBox1.Clear()
        MsgBox("merci d'enterer un mail pour l'administrateur: " & Form4.user1234, MsgBoxStyle.Information, nom & "/ configuration service mail")
        Label1.Text = "Entrer un mail: "
        etap = 2
    End Sub
    Sub etap3()
        Label1.Text = "Confirmer"
        GunaButton1.Text = "confirmer"
        etap = 3
    End Sub

    Private Sub Form5_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Form4.encours = 1 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not Form3.desnoméro.Contains(e.KeyChar) And Not Asc(e.KeyChar) = 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "afficher" Then
            TextBox3.UseSystemPasswordChar = False
            Button1.Text = "cacher"
        Else
            TextBox3.UseSystemPasswordChar = True
            Button1.Text = "afficher"
        End If
    End Sub
End Class