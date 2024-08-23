
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text

Public Class Form4
    Dim etap As Integer = 0
    Public clés As String = ""
    Dim mdp As String = ""
    Public user1234 As String = ""
    Public encours As Integer = 1
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = nom & " / configuration du serveur"
        encours = 1
        etap = 0
        Label1.Text = "Enterer une clés de chiffrage"
        GunaButton1.Text = "Suivant"
        TextBox1.MaxLength = 8
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If etap = 0 Then
            If TextBox1.TextLength < 8 Then
                MsgBox("Il faut 8 carataire", MsgBoxStyle.Critical, Text)
            Else
                clés = TextBox1.Text
                TextBox1.Clear()
                etap = 1
                etap2()
            End If
        ElseIf etap = 1 Then
            If TextBox1.TextLength < 8 Then
                MsgBox("Il faut 8 carataire", MsgBoxStyle.Critical, Text)
            Else
                If TextBox1.Text = clés Then
                    etap3()
                Else
                    MsgBox("Les clés de chiffrage correspond pas", MsgBoxStyle.Critical, Text)
                    TextBox1.Clear()
                    TextBox1.MaxLength = 8
                    etap = 0
                    Label1.Text = "Enterer une clés de chiffrage"
                    GunaButton1.Text = "Suivant"
                End If
            End If
        ElseIf etap = 2 Then
            user1234 = TextBox1.Text
            TextBox1.Clear()
            etap4()
        ElseIf etap = 3 Then
            mdp = TextBox1.Text
            TextBox1.Clear()
            etap5()
        ElseIf etap = 4 Then
            If TextBox1.Text = mdp Then
                etap6()
            Else
                MsgBox("Les mots de passe ne corresponds pas", MsgBoxStyle.Critical, Text)
                TextBox1.Clear()
                etap = 3
                Label1.Text = "Enterer un mots de passe"
                GunaButton1.Text = "Suivant"
                TextBox1.MaxLength = 999999999
            End If
        End If
    End Sub
    Sub etap2()
        Label1.Text = "Confirmer la clés de chiffrage"
        GunaButton1.Text = "Confirmer"
    End Sub
    Sub etap3()
        Try
            Dim texteEnBytes() As Byte = Encoding.UTF8.GetBytes(clés.ToString)
            Dim keyBytes() As Byte = Encoding.UTF8.GetBytes(crypCLM.ToString)
            Dim Crypto As New DESCryptoServiceProvider()
            Crypto.Key = keyBytes
            Crypto.IV = keyBytes
            Dim Icrypto As ICryptoTransform = Crypto.CreateEncryptor
            Dim Resultatbytes() As Byte = Icrypto.TransformFinalBlock(texteEnBytes, 0, texteEnBytes.Length)
            Dim passecrypt = Convert.ToBase64String(Resultatbytes)
            Dim sw1 As New StreamWriter(dosconnextion & "clecrypt.txt")
            sw1.WriteLine(passecrypt)
            sw1.Close()
            etap = 2
            TextBox1.Clear()
            Label1.Text = "Enterer un nom de compte"
            GunaButton1.Text = "Suivant"
            TextBox1.MaxLength = 999999999
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub etap4()
        etap = 3
        Label1.Text = "Enterer un mots de passe"
        GunaButton1.Text = "Suivant"
        TextBox1.MaxLength = 999999999
    End Sub
    Sub etap5()
        etap = 4
        Label1.Text = "Confimer le mots de passe"
        GunaButton1.Text = "Confirmer"
        TextBox1.MaxLength = 999999999
    End Sub
    Sub etap6()
        Try
            Dim MaRequete As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(Form3.ipserveur & "/CLM/utilisateur/" & user1234.ToString & "/"), System.Net.FtpWebRequest)
            Dim ftpStream As Stream = Nothing

            MaRequete.Credentials = New System.Net.NetworkCredential(Form3.idftp, Form3.passftp)
            MaRequete.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response As FtpWebResponse = CType(MaRequete.GetResponse, FtpWebResponse)
            ftpStream = response.GetResponseStream
            ftpStream.Close()
            response.Close()

            Dim texteEnBytes() As Byte = Encoding.UTF8.GetBytes(mdp)
            Dim keyBytes() As Byte = Encoding.UTF8.GetBytes(clés)
            Dim Crypto As New DESCryptoServiceProvider()
            Crypto.Key = keyBytes
            Crypto.IV = keyBytes
            Dim Icrypto As ICryptoTransform = Crypto.CreateEncryptor
            Dim Resultatbytes() As Byte = Icrypto.TransformFinalBlock(texteEnBytes, 0, texteEnBytes.Length)
            Dim passecrypt = Convert.ToBase64String(Resultatbytes)
            Dim sw1 As New StreamWriter(dosrepertoire & "mdp.txt")
            sw1.WriteLine(passecrypt)
            sw1.Close()
            Dim sw2 As New StreamWriter(dosrepertoire & "grade.txt")
            sw2.WriteLine(2)
            sw2.Close()
            My.Computer.Network.UploadFile(dosrepertoire & "mdp.txt", Form3.ipserveur & "/CLM/utilisateur/" & user1234 & "/mdp.txt")
            My.Computer.Network.UploadFile(dosrepertoire & "grade.txt", Form3.ipserveur & "/CLM/utilisateur/" & user1234 & "/grade.txt.txt")
            My.Computer.Network.UploadFile(dosconnextion & "clecrypt.txt", Form3.ipserveur & "/CLM/config/clecrypt.txt")
            File.Delete(dosrepertoire & "mdp.txt")
            File.Delete(dosrepertoire & "grade.txt")
            Dim sw3 As New StreamWriter(dosconnextion & "compte.txt")
            sw3.WriteLine(user1234)
            sw3.WriteLine(passecrypt)
            sw3.Close()

            Dim sw4 As New StreamWriter(dosconnextion & "connecter.txt")
            sw4.WriteLine(1)
            sw4.Close()

            Dim texteEnBytes2() As Byte = Encoding.UTF8.GetBytes(Form3.ipserveur)
            Dim keyBytes2() As Byte = Encoding.UTF8.GetBytes(clés)
            Dim Crypto2 As New DESCryptoServiceProvider()
            Crypto2.Key = keyBytes2
            Crypto2.IV = keyBytes2
            Dim Icrypto2 As ICryptoTransform = Crypto2.CreateEncryptor
            Dim Resultatbytes2() As Byte = Icrypto2.TransformFinalBlock(texteEnBytes2, 0, texteEnBytes2.Length)
            Dim ipserveurcrypte = Convert.ToBase64String(Resultatbytes2)

            Dim texteEnBytes3() As Byte = Encoding.UTF8.GetBytes(Form3.ipsite)
            Dim keyBytes3() As Byte = Encoding.UTF8.GetBytes(clés)
            Dim Crypto3 As New DESCryptoServiceProvider()
            Crypto3.Key = keyBytes3
            Crypto3.IV = keyBytes3
            Dim Icrypto3 As ICryptoTransform = Crypto3.CreateEncryptor
            Dim Resultatbytes3() As Byte = Icrypto3.TransformFinalBlock(texteEnBytes3, 0, texteEnBytes3.Length)
            Dim ipsitecrypte = Convert.ToBase64String(Resultatbytes3)

            Dim texteEnBytes4() As Byte = Encoding.UTF8.GetBytes(Form3.idftp)
            Dim keyBytes4() As Byte = Encoding.UTF8.GetBytes(clés)
            Dim Crypto4 As New DESCryptoServiceProvider()
            Crypto4.Key = keyBytes4
            Crypto4.IV = keyBytes4
            Dim Icrypto4 As ICryptoTransform = Crypto4.CreateEncryptor
            Dim Resultatbytes4() As Byte = Icrypto4.TransformFinalBlock(texteEnBytes4, 0, texteEnBytes4.Length)
            Dim idftpcrypte = Convert.ToBase64String(Resultatbytes4)

            Dim texteEnBytes5() As Byte = Encoding.UTF8.GetBytes(Form3.passftp)
            Dim keyBytes5() As Byte = Encoding.UTF8.GetBytes(clés)
            Dim Crypto5 As New DESCryptoServiceProvider()
            Crypto5.Key = keyBytes5
            Crypto5.IV = keyBytes5
            Dim Icrypto5 As ICryptoTransform = Crypto5.CreateEncryptor
            Dim Resultatbytes5() As Byte = Icrypto5.TransformFinalBlock(texteEnBytes5, 0, texteEnBytes5.Length)
            Dim passftpcrypte = Convert.ToBase64String(Resultatbytes5)


            Dim sw5 As New StreamWriter(dosconnextion & "serveur.txt")
            sw5.WriteLine(ipserveurcrypte)
            sw5.WriteLine(ipsitecrypte)
            sw5.WriteLine(idftpcrypte)
            sw5.WriteLine(passftpcrypte)
            sw5.Close()

            MsgBox("L'administrateur: " & user1234 & " a bien êtê créer", MsgBoxStyle.Information, Text)
            Dim msg = MsgBox("voulez vous configurer le service mail ?", MsgBoxStyle.YesNo, Text)
            If msg = MsgBoxResult.Yes Then
                Form5.ShowDialog()
                encours = 0
                Form3.Close()
                Form2.Close()
                Form1.Visible = True
                Form1.Show()
                Form1.ShowInTaskbar = True
                Form1.start()
                Close()
            Else
                encours = 0
                Form3.Close()
                Form2.Close()
                Form1.Visible = True
                Form1.Show()
                Form1.ShowInTaskbar = True
                Form1.start()
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Form4_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If encours = 1 Then
            e.Cancel = True
        End If
    End Sub
End Class