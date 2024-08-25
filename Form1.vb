Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Dim pagesacctuel As Integer = 1
    Dim pagesacctuel2 As Integer = 1
    Dim nbimage As Integer = 0
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

        CLMipsite = ipsite
        CLMPipserveur = ipserveur
        CLMid = idftp
        CLMpass = passftp

        Dim fwr As FtpWebRequest
        fwr = FtpWebRequest.Create(ipserveur & "/CLM/logiciel/profil/default/categorie/")
        fwr.Credentials = New NetworkCredential(CLMid, CLMpass)
        fwr.Method = WebRequestMethods.Ftp.ListDirectory
        Dim sr As New StreamReader(fwr.GetResponse().GetResponseStream())

        Dim str As String = sr.ReadLine()
        While Not str Is Nothing

            ComboBox1.Items.Add(str)



            str = sr.ReadLine()

        End While
        sr.Close()
        ComboBox1.Items.Add("tout")
        ComboBox1.Items.Remove("index.html")
        ComboBox1.SelectedItem = "tout"
        vérifiinstall()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "tout" Then
            If nbimage = 1 Then
                PictureBox2.Image.Dispose()
            ElseIf nbimage = 2 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
            ElseIf nbimage = 3 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
            ElseIf nbimage = 4 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
            ElseIf nbimage = 5 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
            ElseIf nbimage = 6 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
            ElseIf nbimage = 7 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
                PictureBox8.Image.Dispose()
            ElseIf nbimage = 8 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
                PictureBox8.Image.Dispose()
                PictureBox9.Image.Dispose()
            ElseIf nbimage = 9 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
                PictureBox8.Image.Dispose()
                PictureBox9.Image.Dispose()
                PictureBox10.Image.Dispose()
            ElseIf nbimage = 10 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
                PictureBox8.Image.Dispose()
                PictureBox9.Image.Dispose()
                PictureBox10.Image.Dispose()
                PictureBox11.Image.Dispose()
            End If

            For Each fichier As String In IO.Directory.GetFiles(dostemp)
                Dim info As New IO.FileInfo(fichier)
                File.Delete(fichier)
            Next
            Dim maj1 As New WebClient
            Dim vri1 As String = maj1.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page.txt")
            Label1.Text = "/" & vri1
            Text = nom & ": " & ComboBox1.SelectedItem & " 1" & "/" & vri1

            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi.txt")
            nbimage = vri2
            If vri2 = 1 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                PictureBox3.Hide()
                PictureBox4.Hide()
                PictureBox5.Hide()
                PictureBox6.Hide()
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 2 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                PictureBox4.Hide()
                PictureBox5.Hide()
                PictureBox6.Hide()
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 3 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                PictureBox5.Hide()
                PictureBox6.Hide()
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 4 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                PictureBox6.Hide()
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 5 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 6 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 7 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi7/image.jpg", dostemp & "/image7.jpg")
                PictureBox8.Image = Image.FromFile(dostemp & "/image7.jpg")
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 8 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi7/image.jpg", dostemp & "/image7.jpg")
                PictureBox8.Image = Image.FromFile(dostemp & "/image7.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi8/image.jpg", dostemp & "/image8.jpg")
                PictureBox9.Image = Image.FromFile(dostemp & "/image8.jpg")
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 9 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi7/image.jpg", dostemp & "/image7.jpg")
                PictureBox8.Image = Image.FromFile(dostemp & "/image7.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi8/image.jpg", dostemp & "/image8.jpg")
                PictureBox9.Image = Image.FromFile(dostemp & "/image8.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi9/image.jpg", dostemp & "/image9.jpg")
                PictureBox10.Image = Image.FromFile(dostemp & "/image9.jpg")
                PictureBox11.Hide()
            ElseIf vri2 = 10 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi7/image.jpg", dostemp & "/image7.jpg")
                PictureBox8.Image = Image.FromFile(dostemp & "/image7.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi8/image.jpg", dostemp & "/image8.jpg")
                PictureBox9.Image = Image.FromFile(dostemp & "/image8.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi9/image.jpg", dostemp & "/image9.jpg")
                PictureBox10.Image = Image.FromFile(dostemp & "/image9.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi10/image.jpg", dostemp & "/image10.jpg")
                PictureBox11.Image = Image.FromFile(dostemp & "/image10.jpg")
            End If
        Else
            If nbimage = 1 Then
                PictureBox2.Image.Dispose()
            ElseIf nbimage = 2 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
            ElseIf nbimage = 3 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
            ElseIf nbimage = 4 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
            ElseIf nbimage = 5 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
            ElseIf nbimage = 6 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
            ElseIf nbimage = 7 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
                PictureBox8.Image.Dispose()
            ElseIf nbimage = 8 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
                PictureBox8.Image.Dispose()
                PictureBox9.Image.Dispose()
            ElseIf nbimage = 9 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
                PictureBox8.Image.Dispose()
                PictureBox9.Image.Dispose()
                PictureBox10.Image.Dispose()
            ElseIf nbimage = 10 Then
                PictureBox2.Image.Dispose()
                PictureBox3.Image.Dispose()
                PictureBox4.Image.Dispose()
                PictureBox5.Image.Dispose()
                PictureBox6.Image.Dispose()
                PictureBox7.Image.Dispose()
                PictureBox8.Image.Dispose()
                PictureBox9.Image.Dispose()
                PictureBox10.Image.Dispose()
                PictureBox11.Image.Dispose()
            End If
            For Each fichier As String In IO.Directory.GetFiles(dostemp)
                Dim info As New IO.FileInfo(fichier)
                File.Delete(fichier)
            Next
            Dim maj1 As New WebClient
            Dim vri1 As String = maj1.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page.txt")
            Label1.Text = "/" & vri1
            Text = nom & ": " & ComboBox1.SelectedItem & " 1" & "/" & vri1

            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi.txt")
            nbimage = vri2
            If vri2 = 1 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                PictureBox3.Hide()
                PictureBox4.Hide()
                PictureBox5.Hide()
                PictureBox6.Hide()
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 2 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                PictureBox4.Hide()
                PictureBox5.Hide()
                PictureBox6.Hide()
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 3 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                PictureBox5.Hide()
                PictureBox6.Hide()
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 4 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                PictureBox6.Hide()
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 5 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 6 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                PictureBox8.Hide()
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 7 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi7/image.jpg", dostemp & "/image7.jpg")
                PictureBox8.Image = Image.FromFile(dostemp & "/image7.jpg")
                PictureBox9.Hide()
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 8 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi7/image.jpg", dostemp & "/image7.jpg")
                PictureBox8.Image = Image.FromFile(dostemp & "/image7.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi8/image.jpg", dostemp & "/image8.jpg")
                PictureBox9.Image = Image.FromFile(dostemp & "/image8.jpg")
                PictureBox10.Hide()
                PictureBox11.Hide()
            ElseIf vri2 = 9 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi7/image.jpg", dostemp & "/image7.jpg")
                PictureBox8.Image = Image.FromFile(dostemp & "/image7.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi8/image.jpg", dostemp & "/image8.jpg")
                PictureBox9.Image = Image.FromFile(dostemp & "/image8.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi9/image.jpg", dostemp & "/image9.jpg")
                PictureBox10.Image = Image.FromFile(dostemp & "/image9.jpg")
                PictureBox11.Hide()
            ElseIf vri2 = 10 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/image.jpg", dostemp & "/image2.jpg")
                PictureBox3.Image = Image.FromFile(dostemp & "/image2.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi3/image.jpg", dostemp & "/image3.jpg")
                PictureBox4.Image = Image.FromFile(dostemp & "/image3.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi4/image.jpg", dostemp & "/image4.jpg")
                PictureBox5.Image = Image.FromFile(dostemp & "/image4.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi5/image.jpg", dostemp & "/image5.jpg")
                PictureBox6.Image = Image.FromFile(dostemp & "/image5.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi6/image.jpg", dostemp & "/image6.jpg")
                PictureBox7.Image = Image.FromFile(dostemp & "/image6.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi7/image.jpg", dostemp & "/image7.jpg")
                PictureBox8.Image = Image.FromFile(dostemp & "/image7.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi8/image.jpg", dostemp & "/image8.jpg")
                PictureBox9.Image = Image.FromFile(dostemp & "/image8.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi9/image.jpg", dostemp & "/image9.jpg")
                PictureBox10.Image = Image.FromFile(dostemp & "/image9.jpg")
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi10/image.jpg", dostemp & "/image10.jpg")
                PictureBox11.Image = Image.FromFile(dostemp & "/image10.jpg")
            End If
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If nbimage = 1 Then
            PictureBox2.Image.Dispose()
        ElseIf nbimage = 2 Then
            PictureBox2.Image.Dispose()
            PictureBox3.Image.Dispose()
        ElseIf nbimage = 3 Then
            PictureBox2.Image.Dispose()
            PictureBox3.Image.Dispose()
            PictureBox4.Image.Dispose()
        ElseIf nbimage = 4 Then
            PictureBox2.Image.Dispose()
            PictureBox3.Image.Dispose()
            PictureBox4.Image.Dispose()
            PictureBox5.Image.Dispose()
        ElseIf nbimage = 5 Then
            PictureBox2.Image.Dispose()
            PictureBox3.Image.Dispose()
            PictureBox4.Image.Dispose()
            PictureBox5.Image.Dispose()
            PictureBox6.Image.Dispose()
        ElseIf nbimage = 6 Then
            PictureBox2.Image.Dispose()
            PictureBox3.Image.Dispose()
            PictureBox4.Image.Dispose()
            PictureBox5.Image.Dispose()
            PictureBox6.Image.Dispose()
            PictureBox7.Image.Dispose()
        ElseIf nbimage = 7 Then
            PictureBox2.Image.Dispose()
            PictureBox3.Image.Dispose()
            PictureBox4.Image.Dispose()
            PictureBox5.Image.Dispose()
            PictureBox6.Image.Dispose()
            PictureBox7.Image.Dispose()
            PictureBox8.Image.Dispose()
        ElseIf nbimage = 8 Then
            PictureBox2.Image.Dispose()
            PictureBox3.Image.Dispose()
            PictureBox4.Image.Dispose()
            PictureBox5.Image.Dispose()
            PictureBox6.Image.Dispose()
            PictureBox7.Image.Dispose()
            PictureBox8.Image.Dispose()
            PictureBox9.Image.Dispose()
        ElseIf nbimage = 9 Then
            PictureBox2.Image.Dispose()
            PictureBox3.Image.Dispose()
            PictureBox4.Image.Dispose()
            PictureBox5.Image.Dispose()
            PictureBox6.Image.Dispose()
            PictureBox7.Image.Dispose()
            PictureBox8.Image.Dispose()
            PictureBox9.Image.Dispose()
            PictureBox10.Image.Dispose()
        Else
            PictureBox2.Image.Dispose()
            PictureBox3.Image.Dispose()
            PictureBox4.Image.Dispose()
            PictureBox5.Image.Dispose()
            PictureBox6.Image.Dispose()
            PictureBox7.Image.Dispose()
            PictureBox8.Image.Dispose()
            PictureBox9.Image.Dispose()
            PictureBox10.Image.Dispose()
            PictureBox11.Image.Dispose()
        End If

        For Each fichier As String In IO.Directory.GetFiles(dostemp)
            Dim info As New IO.FileInfo(fichier)
            File.Delete(fichier)
        Next
        Directory.Delete(dostemp)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi1/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi1/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image1.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image1.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub
    Sub vérifiinstall()
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page.txt")
        Label2.Text = "/" & lines1(0)
        Dim lines2() As String = File.ReadAllLines(dosinstall & "/page1/logi.txt")
        If lines2(0) = 0 Then
            Label3.Show()
        Else
            Label3.Hide()
        End If
    End Sub
End Class
