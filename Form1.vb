Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreen1.Close()
        Dim lines1() As String = File.ReadAllLines(connecter)
        If lines1(0) = 1 Then
            start()
        Else
            Form2.Show()
            Visible = False
            Hide()
            ShowInTaskbar = False
        End If
    End Sub
    Sub start()
        Dim lines1() As String = File.ReadAllLines(dosconnextion & "clecrypt.txt")
        Dim Resultatbytes() As Byte = Convert.FromBase64String(lines1(0))
        Dim keyBytes() As Byte = Encoding.UTF8.GetBytes(crypCLM)
        Dim Crypto As New DESCryptoServiceProvider()
        Crypto.Key = keyBytes
        Crypto.IV = keyBytes
        Dim Icrypto As ICryptoTransform = Crypto.CreateDecryptor()
        Dim donné() As Byte = Icrypto.TransformFinalBlock(Resultatbytes, 0, Resultatbytes.Length)
        clescrypte = Encoding.UTF8.GetString(donné)
        Dim lines2() As String = File.ReadAllLines(dosconnextion & "serveur.txt")

        Dim Resultatbyte2() As Byte = Convert.FromBase64String(lines2(0))
        Dim keyBytes2() As Byte = Encoding.UTF8.GetBytes(clescrypte)
        Dim Crypto2 As New DESCryptoServiceProvider()
        Crypto2.Key = keyBytes2
        Crypto2.IV = keyBytes2
        Dim Icrypto2 As ICryptoTransform = Crypto2.CreateDecryptor()
        Dim donné2() As Byte = Icrypto2.TransformFinalBlock(Resultatbyte2, 0, Resultatbyte2.Length)
        Dim ipserveur = Encoding.UTF8.GetString(donné2)

        Dim Resultatbyte3() As Byte = Convert.FromBase64String(lines2(1))
        Dim keyBytes3() As Byte = Encoding.UTF8.GetBytes(clescrypte)
        Dim Crypto3 As New DESCryptoServiceProvider()
        Crypto3.Key = keyBytes3
        Crypto3.IV = keyBytes3
        Dim Icrypto3 As ICryptoTransform = Crypto3.CreateDecryptor()
        Dim donné3() As Byte = Icrypto3.TransformFinalBlock(Resultatbyte3, 0, Resultatbyte3.Length)
        Dim ipsite = Encoding.UTF8.GetString(donné3)

        Dim Resultatbyte4() As Byte = Convert.FromBase64String(lines2(2))
        Dim keyBytes4() As Byte = Encoding.UTF8.GetBytes(clescrypte)
        Dim Crypto4 As New DESCryptoServiceProvider()
        Crypto4.Key = keyBytes4
        Crypto4.IV = keyBytes4
        Dim Icrypto4 As ICryptoTransform = Crypto4.CreateDecryptor()
        Dim donné4() As Byte = Icrypto4.TransformFinalBlock(Resultatbyte4, 0, Resultatbyte4.Length)
        Dim idftp = Encoding.UTF8.GetString(donné4)

        Dim Resultatbyte5() As Byte = Convert.FromBase64String(lines2(3))
        Dim keyBytes5() As Byte = Encoding.UTF8.GetBytes(clescrypte)
        Dim Crypto5 As New DESCryptoServiceProvider()
        Crypto5.Key = keyBytes5
        Crypto5.IV = keyBytes5
        Dim Icrypto5 As ICryptoTransform = Crypto5.CreateDecryptor()
        Dim donné5() As Byte = Icrypto5.TransformFinalBlock(Resultatbyte5, 0, Resultatbyte5.Length)
        Dim passftp = Encoding.UTF8.GetString(donné5)

        MsgBox(ipserveur)
        MsgBox(ipsite)
        MsgBox(idftp)
        MsgBox(passftp)
        MsgBox(clescrypte)
    End Sub
End Class
