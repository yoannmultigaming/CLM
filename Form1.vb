﻿Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Dim pagesacctuel As Integer = 1
    Public pagesacctuel2 As Integer = 1
    Public pagesacctuel3 As Integer = 1
    Dim nbimage As Integer = 0
    Dim nbmiage2 As Integer = 0
    Dim nbmiage3 As Integer = 0
    Dim nmlogup As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPage3.Text = "Mise a jour (4)"
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
        NotifyIcon1.Text = nom
        vérifiinstall()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        pagesacctuel = 1
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

            If vri1 = 1 Then
                Button1.Enabled = False
                Button2.Enabled = False
            Else
                Button1.Enabled = False
                Button2.Enabled = True
            End If

            Label1.Text = pagesacctuel & "/" & vri1
            Text = nom & ": " & ComboBox1.SelectedItem & " " & pagesacctuel & "/" & vri1

            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi.txt")
            nbimage = vri2
            If vri2 = 1 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                PictureBox2.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
                PictureBox11.Show()
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

            If vri1 = 1 Then
                Button1.Enabled = False
                Button2.Enabled = False
            Else
                Button1.Enabled = False
                Button2.Enabled = True
            End If

            Label1.Text = pagesacctuel & "/" & vri1
            Text = nom & ": " & ComboBox1.SelectedItem & " " & pagesacctuel & "/" & vri1

            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi.txt")
            nbimage = vri2
            If vri2 = 1 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                PictureBox2.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
                PictureBox11.Show()
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
        Label2.Text = pagesacctuel2 & "/" & lines1(0)
        Dim lines2() As String = File.ReadAllLines(dosinstall & "/page1/logi.txt")
        If lines1(0) = 1 Then
            Button4.Enabled = False
            Button3.Enabled = False
        Else
            Button4.Enabled = False
            Button3.Enabled = True
        End If

        If lines2(0) = 0 Then
            Label3.Show()
            updatelogi()
        Else
            Label3.Hide()
            vérifiinstall2()
        End If
    End Sub
    Sub vérifiinstall2()
        If nbmiage2 = 1 Then
            PictureBox12.Image.Dispose()
        ElseIf nbmiage2 = 2 Then
            PictureBox12.Image.Dispose()
            PictureBox13.Image.Dispose()
        ElseIf nbmiage2 = 3 Then
            PictureBox12.Image.Dispose()
            PictureBox13.Image.Dispose()
            PictureBox14.Image.Dispose()
        ElseIf nbmiage2 = 4 Then
            PictureBox12.Image.Dispose()
            PictureBox13.Image.Dispose()
            PictureBox14.Image.Dispose()
            PictureBox15.Image.Dispose()
        ElseIf nbmiage2 = 5 Then
            PictureBox12.Image.Dispose()
            PictureBox13.Image.Dispose()
            PictureBox14.Image.Dispose()
            PictureBox15.Image.Dispose()
            PictureBox16.Image.Dispose()
        ElseIf nbmiage2 = 6 Then
            PictureBox12.Image.Dispose()
            PictureBox13.Image.Dispose()
            PictureBox14.Image.Dispose()
            PictureBox15.Image.Dispose()
            PictureBox16.Image.Dispose()
            PictureBox17.Image.Dispose()
        ElseIf nbmiage2 = 7 Then
            PictureBox12.Image.Dispose()
            PictureBox13.Image.Dispose()
            PictureBox14.Image.Dispose()
            PictureBox15.Image.Dispose()
            PictureBox16.Image.Dispose()
            PictureBox17.Image.Dispose()
            PictureBox18.Image.Dispose()
        ElseIf nbmiage2 = 8 Then
            PictureBox12.Image.Dispose()
            PictureBox13.Image.Dispose()
            PictureBox14.Image.Dispose()
            PictureBox15.Image.Dispose()
            PictureBox16.Image.Dispose()
            PictureBox17.Image.Dispose()
            PictureBox18.Image.Dispose()
            PictureBox19.Image.Dispose()
        ElseIf nbmiage2 = 9 Then
            PictureBox12.Image.Dispose()
            PictureBox13.Image.Dispose()
            PictureBox14.Image.Dispose()
            PictureBox15.Image.Dispose()
            PictureBox16.Image.Dispose()
            PictureBox17.Image.Dispose()
            PictureBox18.Image.Dispose()
            PictureBox19.Image.Dispose()
            PictureBox20.Image.Dispose()
        ElseIf nbmiage2 = 10 Then
            PictureBox12.Image.Dispose()
            PictureBox13.Image.Dispose()
            PictureBox14.Image.Dispose()
            PictureBox15.Image.Dispose()
            PictureBox16.Image.Dispose()
            PictureBox17.Image.Dispose()
            PictureBox18.Image.Dispose()
            PictureBox19.Image.Dispose()
            PictureBox20.Image.Dispose()
            PictureBox21.Image.Dispose()
        Else

        End If

        If Directory.Exists(dosinstall & "/page" & pagesacctuel2 & "/image/") = True Then
            For Each fichier As String In IO.Directory.GetFiles(dosinstall & "/page" & pagesacctuel2 & "/image/")
                Dim info As New IO.FileInfo(fichier)
                File.Delete(fichier)
            Next
            Directory.Delete(dosinstall & "/page" & pagesacctuel2 & "/image/")
        End If

        ListBox1.Items.Clear()

        For Each fichier As String In IO.Directory.GetDirectories(dosinstall & "/page" & pagesacctuel2 & "/")
            Dim info As New IO.FileInfo(fichier)
            ListBox1.Items.Add(fichier)
        Next
        Dim sw11 As New StreamWriter(dosinstall & "/page" & pagesacctuel2 & "/logi.txt")
        sw11.WriteLine(ListBox1.Items.Count)
        sw11.Close()

        Dim i As Integer = 1
        While i <= ListBox1.Items.Count
            ListBox1.SelectedIndex = i - 1
            My.Computer.FileSystem.CopyFile(ListBox1.SelectedItem & "/image.jpg", dosinstall & "/page" & pagesacctuel2 & "/image/image" & i & ".jpg")
            Dim sw1 As New StreamWriter(dosinstall & "/page" & pagesacctuel2 & "/image/lient" & i & ".txt")
            sw1.WriteLine(ListBox1.SelectedItem)
            sw1.Close()
            i = i + 1
        End While

        If ListBox1.Items.Count = 1 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox12.Show()
            PictureBox13.Hide()
            PictureBox14.Hide()
            PictureBox15.Hide()
            PictureBox16.Hide()
            PictureBox17.Hide()
            PictureBox18.Hide()
            PictureBox19.Hide()
            PictureBox20.Hide()
            PictureBox21.Hide()
        ElseIf ListBox1.Items.Count = 2 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox13.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image2.jpg")
            PictureBox12.Show()
            PictureBox13.Show()
            PictureBox14.Hide()
            PictureBox15.Hide()
            PictureBox16.Hide()
            PictureBox17.Hide()
            PictureBox18.Hide()
            PictureBox19.Hide()
            PictureBox20.Hide()
            PictureBox21.Hide()
        ElseIf ListBox1.Items.Count = 3 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox13.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image2.jpg")
            PictureBox14.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image3.jpg")
            PictureBox12.Show()
            PictureBox13.Show()
            PictureBox14.Show()
            PictureBox15.Hide()
            PictureBox16.Hide()
            PictureBox17.Hide()
            PictureBox18.Hide()
            PictureBox19.Hide()
            PictureBox20.Hide()
            PictureBox21.Hide()
        ElseIf ListBox1.Items.Count = 4 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox13.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image2.jpg")
            PictureBox14.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image3.jpg")
            PictureBox15.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image4.jpg")
            PictureBox12.Show()
            PictureBox13.Show()
            PictureBox14.Show()
            PictureBox15.Show()
            PictureBox16.Hide()
            PictureBox17.Hide()
            PictureBox18.Hide()
            PictureBox19.Hide()
            PictureBox20.Hide()
            PictureBox21.Hide()
        ElseIf ListBox1.Items.Count = 5 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox13.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image2.jpg")
            PictureBox14.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image3.jpg")
            PictureBox15.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image4.jpg")
            PictureBox16.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image5.jpg")
            PictureBox12.Show()
            PictureBox13.Show()
            PictureBox14.Show()
            PictureBox15.Show()
            PictureBox16.Show()
            PictureBox17.Hide()
            PictureBox18.Hide()
            PictureBox19.Hide()
            PictureBox20.Hide()
            PictureBox21.Hide()
        ElseIf ListBox1.Items.Count = 6 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox13.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image2.jpg")
            PictureBox14.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image3.jpg")
            PictureBox15.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image4.jpg")
            PictureBox16.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image5.jpg")
            PictureBox17.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image6.jpg")
            PictureBox12.Show()
            PictureBox13.Show()
            PictureBox14.Show()
            PictureBox15.Show()
            PictureBox16.Show()
            PictureBox17.Show()
            PictureBox18.Hide()
            PictureBox19.Hide()
            PictureBox20.Hide()
            PictureBox21.Hide()
        ElseIf ListBox1.Items.Count = 7 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox13.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image2.jpg")
            PictureBox14.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image3.jpg")
            PictureBox15.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image4.jpg")
            PictureBox16.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image5.jpg")
            PictureBox17.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image6.jpg")
            PictureBox18.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image7.jpg")
            PictureBox12.Show()
            PictureBox13.Show()
            PictureBox14.Show()
            PictureBox15.Show()
            PictureBox16.Show()
            PictureBox17.Show()
            PictureBox18.Show()
            PictureBox19.Hide()
            PictureBox20.Hide()
            PictureBox21.Hide()
        ElseIf ListBox1.Items.Count = 8 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox13.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image2.jpg")
            PictureBox14.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image3.jpg")
            PictureBox15.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image4.jpg")
            PictureBox16.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image5.jpg")
            PictureBox17.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image6.jpg")
            PictureBox18.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image7.jpg")
            PictureBox19.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image8.jpg")
            PictureBox12.Show()
            PictureBox13.Show()
            PictureBox14.Show()
            PictureBox15.Show()
            PictureBox16.Show()
            PictureBox17.Show()
            PictureBox18.Show()
            PictureBox19.Show()
            PictureBox20.Hide()
            PictureBox21.Hide()
        ElseIf ListBox1.Items.Count = 9 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox13.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image2.jpg")
            PictureBox14.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image3.jpg")
            PictureBox15.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image4.jpg")
            PictureBox16.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image5.jpg")
            PictureBox17.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image6.jpg")
            PictureBox18.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image7.jpg")
            PictureBox19.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image8.jpg")
            PictureBox20.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image9.jpg")
            PictureBox12.Show()
            PictureBox13.Show()
            PictureBox14.Show()
            PictureBox15.Show()
            PictureBox16.Show()
            PictureBox17.Show()
            PictureBox18.Show()
            PictureBox19.Show()
            PictureBox20.Show()
            PictureBox21.Hide()
        ElseIf ListBox1.Items.Count = 10 Then
            PictureBox12.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image1.jpg")
            PictureBox13.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image2.jpg")
            PictureBox14.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image3.jpg")
            PictureBox15.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image4.jpg")
            PictureBox16.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image5.jpg")
            PictureBox17.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image6.jpg")
            PictureBox18.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image7.jpg")
            PictureBox19.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image8.jpg")
            PictureBox20.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image9.jpg")
            PictureBox21.Image = Image.FromFile(dosinstall & "/page" & pagesacctuel2 & "/image/image10.jpg")
            PictureBox12.Show()
            PictureBox13.Show()
            PictureBox14.Show()
            PictureBox15.Show()
            PictureBox16.Show()
            PictureBox17.Show()
            PictureBox18.Show()
            PictureBox19.Show()
            PictureBox20.Show()
            PictureBox21.Show()
        Else
            PictureBox12.Hide()
            PictureBox13.Hide()
            PictureBox14.Hide()
            PictureBox15.Hide()
            PictureBox16.Hide()
            PictureBox17.Hide()
            PictureBox18.Hide()
            PictureBox19.Hide()
            PictureBox20.Hide()
        End If
        nbmiage2 = ListBox1.Items.Count

        updatelogi()
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient1.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox12.Image
        Form8.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi2/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi2/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image2.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi2/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image2.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi3/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi3/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image3.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi3/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image3.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi4/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi4/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image4.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi4/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image4.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi5/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi5/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image5.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi5/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image5.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi6/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi6/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image6.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi6/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image6.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi7/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi7/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image7.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi7/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image7.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi8/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi8/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image8.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi8/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image8.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi9/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi9/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image9.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi9/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image9.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        If ComboBox1.SelectedItem = "tout" Then
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi10/nom.txt")
            Form6.CLMlient = "/CLM/logiciel/profil/" & CLMprofil & "/tout/" & "/page" & pagesacctuel & "/logi10/"
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image10.jpg")
            Form6.ShowDialog()
        Else
            My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi10/url.txt", dostemp & "/url.txt")
            Dim lines1() As String = File.ReadAllLines(dostemp & "/url.txt")
            File.Delete(dostemp & "/url.txt")
            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & lines1(0) & "/nom.txt")
            Form6.CLMlient = lines1(0)
            Form6.Text = nom & " / " & vri2
            Form6.PictureBox1.Image = Image.FromFile(dostemp & "/image10.jpg")
            Try
                Form6.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient2.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox13.Image
        Form8.ShowDialog()
    End Sub

    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient3.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox14.Image
        Form8.ShowDialog()
    End Sub

    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient4.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox15.Image
        Form8.ShowDialog()
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient5.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox16.Image
        Form8.ShowDialog()
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient6.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox17.Image
        Form8.ShowDialog()
    End Sub

    Private Sub PictureBox18_Click(sender As Object, e As EventArgs) Handles PictureBox18.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient7.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox18.Image
        Form8.ShowDialog()
    End Sub

    Private Sub PictureBox19_Click(sender As Object, e As EventArgs) Handles PictureBox19.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient8.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox19.Image
        Form8.ShowDialog()
    End Sub

    Private Sub PictureBox20_Click(sender As Object, e As EventArgs) Handles PictureBox20.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient9.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox20.Image
        Form8.ShowDialog()
    End Sub

    Private Sub PictureBox21_Click(sender As Object, e As EventArgs) Handles PictureBox21.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & pagesacctuel2 & "/image/lient10.txt")
        Dim lines2() As String = File.ReadAllLines(lines1(0) & "/nom.txt")
        Form8.Text = nom & " / " & lines2(0)
        Form8.Label2.Text = lines2(0)
        Dim lines3() As String = File.ReadAllLines(dosprogramefile & "/" & lines2(0) & "/version.txt")
        Form8.Label4.Text = lines3(0)
        Form8.GunaButton1.Text = "Ouvrir: " & lines2(0)
        Form8.GunaButton2.Text = "Désinstaller: " & lines2(0)
        Form8.PictureBox1.Image = PictureBox21.Image
        Form8.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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


            If pagesacctuel + 1 = vri1 Then
                Button2.Enabled = False
                Button1.Enabled = True
            Else
                Button2.Enabled = True
                Button1.Enabled = True
            End If
            pagesacctuel = pagesacctuel + 1

            Label1.Text = pagesacctuel & "/" & vri1
            Text = nom & ": " & ComboBox1.SelectedItem & " " & pagesacctuel & "/" & vri1

            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi.txt")
            nbimage = vri2
            If vri2 = 1 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                PictureBox2.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
                PictureBox11.Show()
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

            If pagesacctuel + 1 = vri1 Then
                Button2.Enabled = False
                Button1.Enabled = True
            Else
                Button2.Enabled = True
                Button1.Enabled = True
            End If
            pagesacctuel = pagesacctuel + 1

            Label1.Text = pagesacctuel & "/" & vri1
            Text = nom & ": " & ComboBox1.SelectedItem & " " & pagesacctuel & "/" & vri1

            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi.txt")
            nbimage = vri2
            If vri2 = 1 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                PictureBox2.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
                PictureBox11.Show()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page.txt")
        pagesacctuel2 = pagesacctuel2 + 1
        If pagesacctuel2 = lines1(0) Then
            Button4.Enabled = True
            Button3.Enabled = False
        Else
            Button3.Enabled = True
            Button4.Enabled = True
        End If
        Label2.Text = pagesacctuel2 & "/" & lines1(0)
        vérifiinstall2()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim lines1() As String = File.ReadAllLines(dosinstall & "/page.txt")
        pagesacctuel2 = pagesacctuel2 - 1
        If pagesacctuel2 = 1 Then
            Button4.Enabled = False
            Button3.Enabled = True
        Else
            Button3.Enabled = True
            Button4.Enabled = True
        End If
        Label2.Text = pagesacctuel2 & "/" & lines1(0)
        vérifiinstall2()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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


            If pagesacctuel - 1 = 1 Then
                Button2.Enabled = True
                Button1.Enabled = False
            Else
                Button2.Enabled = True
                Button1.Enabled = True
            End If
            pagesacctuel = pagesacctuel - 1

            Label1.Text = pagesacctuel & "/" & vri1
            Text = nom & ": " & ComboBox1.SelectedItem & " " & pagesacctuel & "/" & vri1

            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi.txt")
            nbimage = vri2
            If vri2 = 1 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/tout/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                PictureBox2.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
                PictureBox11.Show()
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

            If pagesacctuel + 1 = vri1 Then
                Button2.Enabled = False
                Button1.Enabled = True
            Else
                Button2.Enabled = True
                Button1.Enabled = True
            End If
            pagesacctuel = pagesacctuel + 1

            Label1.Text = pagesacctuel & "/" & vri1
            Text = nom & ": " & ComboBox1.SelectedItem & " " & pagesacctuel & "/" & vri1

            Dim maj2 As New WebClient
            Dim vri2 As String = maj2.DownloadString(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi.txt")
            nbimage = vri2
            If vri2 = 1 Then
                My.Computer.Network.DownloadFile(CLMipsite & "/CLM/logiciel/profil/" & CLMprofil & "/categorie/" & ComboBox1.SelectedItem & "/page" & pagesacctuel & "/logi1/image.jpg", dostemp & "/image1.jpg")
                PictureBox2.Image = Image.FromFile(dostemp & "/image1.jpg")
                PictureBox2.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
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
                PictureBox2.Show()
                PictureBox3.Show()
                PictureBox4.Show()
                PictureBox5.Show()
                PictureBox6.Show()
                PictureBox7.Show()
                PictureBox8.Show()
                PictureBox9.Show()
                PictureBox10.Show()
                PictureBox11.Show()
            End If
        End If
    End Sub
    Private Sub ChromeTabcontrol1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChromeTabcontrol1.SelectedIndexChanged
        If ChromeTabcontrol1.SelectedIndex = 0 Then
            Text = nom & ": " & ComboBox1.SelectedItem & " " & Label1.Text
        ElseIf ChromeTabcontrol1.SelectedIndex = 1 Then
            Text = nom & ": " & TabPage2.Text & " " & Label2.Text
        ElseIf ChromeTabcontrol1.SelectedIndex = 2 Then
            Text = nom & ": " & TabPage3.Text
        ElseIf ChromeTabcontrol1.SelectedIndex = 3 Then
            Text = nom & ": " & TabPage4.Text
        ElseIf ChromeTabcontrol1.SelectedIndex = 4 Then
            Text = nom & ": " & TabPage5.Text
        End If
    End Sub
    Sub updatelogi()
        pagesacctuel3 = 1
        If nbmiage3 = 1 Then
            PictureBox23.Image.Dispose()
        ElseIf nbmiage3 = 2 Then
            PictureBox23.Image.Dispose()
            PictureBox24.Image.Dispose()
        ElseIf nbmiage3 = 3 Then
            PictureBox23.Image.Dispose()
            PictureBox24.Image.Dispose()
            PictureBox25.Image.Dispose()
        ElseIf nbmiage3 = 4 Then
            PictureBox23.Image.Dispose()
            PictureBox24.Image.Dispose()
            PictureBox25.Image.Dispose()
            PictureBox26.Image.Dispose()
        Else

        End If

        If Directory.Exists(dosupdate) = True Then
            My.Computer.FileSystem.DeleteDirectory(dosupdate, FileIO.DeleteDirectoryOption.DeleteAllContents)
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

        ListBox2.Items.Clear()

        For Each fichier As String In IO.Directory.GetDirectories(dosprogramefile)
            Dim info As New IO.FileInfo(fichier)
            ListBox2.Items.Add(fichier)
        Next

        If ListBox2.Items.Count = 0 Then
            TabPage3.Text = "Mise a jour"
            GroupBox1.Hide()
            GroupBox2.Hide()
            GroupBox3.Hide()
            GroupBox4.Hide()
            GunaButton5.Hide()
            Label17.Show()
            Button5.Enabled = False
            Button6.Enabled = False
        Else
            Label17.Hide()
            nmlogup = 0
            Dim i As Integer = 0
            While i <= ListBox2.Items.Count - 1
                ListBox2.SelectedIndex = i
                Dim lines1() As String = File.ReadAllLines(ListBox2.SelectedItem & "\version.txt")
                Dim lines2() As String = File.ReadAllLines(ListBox2.SelectedItem & "\updatedl.txt")
                Dim maj2 As New WebClient
                Dim vri2 As String = maj2.DownloadString(lines2(0) & "/version/versionactuel.txt")
                If lines1(0) = vri2 Then

                Else
                    nmlogup = nmlogup + 1
                    Dim CLMpronom = ListBox2.SelectedItem.ToString.Replace(dosprogramefile, "")

                    Dim lines21() As String = File.ReadAllLines(dosupdate & "/page.txt")

                    Dim lines3() As String = File.ReadAllLines(dosupdate & "/page" & lines21(0) & "/logi.txt")


                    If lines3(0) = 4 Then
                        Directory.CreateDirectory(dosupdate & "/page" & lines21(0).ToString + 1)
                        Dim sw23 As New StreamWriter(dosupdate & "/page.txt")
                        sw23.WriteLine(lines21(0).ToString + 1)
                        sw23.Close()
                        Dim lines2bis() As String = File.ReadAllLines(dosupdate & "/page.txt")
                        Directory.CreateDirectory(dosupdate & "/page" & lines2bis(0) & "/" & CLMpronom & "/")
                        My.Computer.Network.DownloadFile(lines2(0) & "/image.jpg", (dosupdate & "/page" & lines2bis(0) & "/" & CLMpronom & "/image.jpg"))
                        Dim sw234 As New StreamWriter(dosupdate & "/page" & lines2bis(0) & "/" & CLMpronom & "/nom.txt")
                        sw234.WriteLine(CLMpronom)
                        sw234.Close()

                        ListBox3.Items.Clear()

                        For Each fichier As String In IO.Directory.GetDirectories(dosupdate & "/page" & lines2bis(0) & "/")
                            Dim info As New IO.FileInfo(fichier)
                            ListBox3.Items.Add(info.Name)
                        Next

                        Dim sw22 As New StreamWriter(dosupdate & "/page" & lines2bis(0) & "/logi.txt")
                        sw22.WriteLine(ListBox3.Items.Count)
                        sw22.Close()
                    Else
                        If Directory.Exists(dosupdate & "/page" & lines21(0) & "/" & CLMpronom & "/") = False Then
                            Directory.CreateDirectory(dosupdate & "/page" & lines21(0) & "/" & CLMpronom & "/")
                            My.Computer.Network.DownloadFile(lines2(0) & "/image.jpg", (dosupdate & "/page" & lines21(0) & "/" & CLMpronom & "/image.jpg"))
                            Dim sw23 As New StreamWriter(dosupdate & "/page" & lines21(0) & "/" & CLMpronom & "/nom.txt")
                            sw23.WriteLine(CLMpronom)
                            sw23.Close()
                        End If
                        ListBox3.Items.Clear()

                        For Each fichier As String In IO.Directory.GetDirectories(dosupdate & "/page" & lines21(0) & "/")
                            Dim info As New IO.FileInfo(fichier)
                            ListBox3.Items.Add(info.Name)
                        Next

                        Dim sw22 As New StreamWriter(dosupdate & "/page" & lines21(0) & "/logi.txt")
                        sw22.WriteLine(ListBox3.Items.Count)
                        sw22.Close()
                    End If
                End If
                i = i + 1
            End While
            If ListBox2.Items.Count = 1 Then
                TabPage3.Text = "Mise a jour (" & nmlogup & ")"

                GunaButton5.Text = "Mètre à jour le logiciel"
                NotifyIcon1.BalloonTipTitle = "Mise a jour disponible"
                NotifyIcon1.Text = nom & ": Unemise a jour disponible"
                NotifyIcon1.BalloonTipText = "une mise a jour est disponible"
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.ShowBalloonTip(1)
            Else
                TabPage3.Text = "Mise a jours (" & nmlogup & ")"

                GunaButton5.Text = "Mètre à jour les (" & nmlogup & ") logiciels"
                NotifyIcon1.Text = nom & ": " & nmlogup & " mise a jours sont disponible"
                NotifyIcon1.BalloonTipTitle = "Des mise a jour sont disponible"
                NotifyIcon1.BalloonTipText = nmlogup & " mise a jours sont disponible"
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.ShowBalloonTip(1)
            End If
            teste()
        End If
    End Sub
    Sub teste()

        If nbmiage3 = 1 Then
            PictureBox23.Image.Dispose()
        ElseIf nbmiage3 = 2 Then
            PictureBox23.Image.Dispose()
            PictureBox24.Image.Dispose()
        ElseIf nbmiage3 = 3 Then
            PictureBox23.Image.Dispose()
            PictureBox24.Image.Dispose()
            PictureBox25.Image.Dispose()
        ElseIf nbmiage3 = 4 Then
            PictureBox23.Image.Dispose()
            PictureBox24.Image.Dispose()
            PictureBox25.Image.Dispose()
            PictureBox26.Image.Dispose()
        Else

        End If

        Dim lines1() As String = File.ReadAllLines(dosupdate & "/page.txt")
        Label7.Text = pagesacctuel3 & "/" & lines1(0)


        If Label7.Text = 1 & "/" & lines1(0) And pagesacctuel3.ToString = lines1(0) Then
            Button6.Enabled = False
            Button5.Enabled = False
        ElseIf Label7.Text = lines1(0) & "/" & lines1(0) Then
            Button6.Enabled = True
            Button5.Enabled = False
        ElseIf Label7.Text = 1 & "/" & lines1(0) Then
            Button6.Enabled = False
            Button5.Enabled = True
        Else
            Button5.Enabled = True
            Button6.Enabled = True
        End If


        If Directory.Exists(dosupdate & "/page" & pagesacctuel3 & "/image/") = True Then
            For Each fichier As String In IO.Directory.GetFiles(dosupdate & "/page" & pagesacctuel3 & "/image/")
                Dim info As New IO.FileInfo(fichier)
                File.Delete(fichier)
            Next
            Directory.Delete(dosupdate & "/page" & pagesacctuel3 & "/image/")
        End If

        ListBox3.Items.Clear()

        For Each fichier As String In IO.Directory.GetDirectories(dosupdate & "/page" & pagesacctuel3 & "/")
            Dim info As New IO.FileInfo(fichier)
            ListBox3.Items.Add(fichier)
        Next
        Dim sw11 As New StreamWriter(dosupdate & "/page" & pagesacctuel3 & "/logi.txt")
        sw11.WriteLine(ListBox3.Items.Count)
        sw11.Close()

        Dim i As Integer = 1
        While i <= ListBox3.Items.Count
            ListBox3.SelectedIndex = i - 1
            My.Computer.FileSystem.CopyFile(ListBox3.SelectedItem & "/image.jpg", dosupdate & "/page" & pagesacctuel3 & "/image/image" & i & ".jpg")
            Dim sw1 As New StreamWriter(dosupdate & "/page" & pagesacctuel3 & "/image/lient" & i & ".txt")
            sw1.WriteLine(ListBox3.SelectedItem)
            sw1.Close()
            i = i + 1
        End While

        If ListBox3.Items.Count = 1 Then
            PictureBox23.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image1.jpg")
            Dim lines3() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient1.txt")
            Dim blabla = lines3(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox1.Text = blabla
            Label4.Text = blabla
            Dim lines4() As String = File.ReadAllLines(dosprogramefile & blabla & "/version.txt")
            Label5.Text = "Version installer: " & lines4(0)
            Dim lines5() As String = File.ReadAllLines(dosprogramefile & blabla & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label6.Text = "Nouvelle version: " & lines6(0)
            PictureBox23.Show()
            PictureBox24.Hide()
            PictureBox25.Hide()
            PictureBox26.Hide()
            GroupBox1.Show()
            GroupBox2.Hide()
            GroupBox3.Hide()
            GroupBox4.Hide()
        ElseIf ListBox3.Items.Count = 2 Then
            PictureBox23.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image1.jpg")
            PictureBox24.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image2.jpg")
            Dim lines3() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient1.txt")
            Dim blabla = lines3(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox1.Text = blabla
            Label4.Text = blabla
            Dim lines4() As String = File.ReadAllLines(dosprogramefile & blabla & "/version.txt")
            Label5.Text = "Version installer: " & lines4(0)
            Dim lines5() As String = File.ReadAllLines(dosprogramefile & blabla & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label6.Text = "Nouvelle version: " & lines6(0)
            Dim lines3a() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient2.txt")
            Dim blabla2 = lines3a(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox2.Text = blabla2
            Label10.Text = blabla2
            Dim lines4a() As String = File.ReadAllLines(dosprogramefile & blabla2 & "/version.txt")
            Label9.Text = "Version installer: " & lines4(0)
            Dim lines5a() As String = File.ReadAllLines(dosprogramefile & blabla2 & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5a(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6a() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label8.Text = "Nouvelle version: " & lines6a(0)
            PictureBox23.Show()
            PictureBox24.Show()
            PictureBox25.Hide()
            PictureBox26.Hide()
            GroupBox1.Show()
            GroupBox2.Show()
            GroupBox3.Hide()
            GroupBox4.Hide()
        ElseIf ListBox3.Items.Count = 3 Then
            PictureBox23.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image1.jpg")
            PictureBox24.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image2.jpg")
            PictureBox25.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image3.jpg")
            Dim lines3() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient1.txt")
            Dim blabla = lines3(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox1.Text = blabla
            Label4.Text = blabla
            Dim lines4() As String = File.ReadAllLines(dosprogramefile & blabla & "/version.txt")
            Label5.Text = "Version installer: " & lines4(0)
            Dim lines5() As String = File.ReadAllLines(dosprogramefile & blabla & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label6.Text = "Nouvelle version: " & lines6(0)
            Dim lines3a() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient2.txt")
            Dim blabla2 = lines3a(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox2.Text = blabla2
            Label10.Text = blabla2
            Dim lines4a() As String = File.ReadAllLines(dosprogramefile & blabla2 & "/version.txt")
            Label9.Text = "Version installer: " & lines4(0)
            Dim lines5a() As String = File.ReadAllLines(dosprogramefile & blabla2 & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5a(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6a() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label8.Text = "Nouvelle version: " & lines6a(0)
            Dim lines3b() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient3.txt")
            Dim blabla3 = lines3b(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox3.Text = blabla3
            Label13.Text = blabla3
            Dim lines4b() As String = File.ReadAllLines(dosprogramefile & blabla3 & "/version.txt")
            Label12.Text = "Version installer: " & lines4b(0)
            Dim lines5b() As String = File.ReadAllLines(dosprogramefile & blabla3 & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5b(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6b() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label11.Text = "Nouvelle version: " & lines6b(0)
            PictureBox23.Show()
            PictureBox24.Show()
            PictureBox25.Show()
            PictureBox26.Hide()
            GroupBox1.Show()
            GroupBox2.Show()
            GroupBox3.Show()
            GroupBox4.Hide()
        ElseIf ListBox3.Items.Count = 4 Then
            PictureBox23.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image1.jpg")
            PictureBox24.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image2.jpg")
            PictureBox25.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image3.jpg")
            PictureBox26.Image = Image.FromFile(dosupdate & "/page" & pagesacctuel3 & "/image/image4.jpg")
            Dim lines3() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient1.txt")
            Dim blabla = lines3(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox1.Text = blabla
            Label4.Text = blabla
            Dim lines4() As String = File.ReadAllLines(dosprogramefile & blabla & "/version.txt")
            Label5.Text = "Version installer: " & lines4(0)
            Dim lines5() As String = File.ReadAllLines(dosprogramefile & blabla & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label6.Text = "Nouvelle version: " & lines6(0)
            Dim lines3a() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient2.txt")
            Dim blabla2 = lines3a(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox2.Text = blabla2
            Label10.Text = blabla2
            Dim lines4a() As String = File.ReadAllLines(dosprogramefile & blabla2 & "/version.txt")
            Label9.Text = "Version installer: " & lines4(0)
            Dim lines5a() As String = File.ReadAllLines(dosprogramefile & blabla2 & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5a(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6a() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label8.Text = "Nouvelle version: " & lines6a(0)
            Dim lines3b() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient3.txt")
            Dim blabla3 = lines3b(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox3.Text = blabla3
            Label13.Text = blabla3
            Dim lines4b() As String = File.ReadAllLines(dosprogramefile & blabla3 & "/version.txt")
            Label12.Text = "Version installer: " & lines4b(0)
            Dim lines5b() As String = File.ReadAllLines(dosprogramefile & blabla3 & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5b(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6b() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label11.Text = "Nouvelle version: " & lines6b(0)
            Dim lines3c() As String = File.ReadAllLines(dosupdate & "/page" & pagesacctuel3 & "/image/lient4.txt")
            Dim blabla4 = lines3c(0).ToString.Replace(dosupdate & "/page" & pagesacctuel3 & "/", "")
            GroupBox4.Text = blabla4
            Label16.Text = blabla4
            Dim lines4c() As String = File.ReadAllLines(dosprogramefile & blabla4 & "/version.txt")
            Label15.Text = "Version installer: " & lines4c(0)
            Dim lines5c() As String = File.ReadAllLines(dosprogramefile & blabla4 & "/updatedl.txt")
            My.Computer.Network.DownloadFile(lines5c(0) & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
            Dim lines6c() As String = File.ReadAllLines(dostemp & "/versionactuel.txt")
            File.Delete(dostemp & "/versionactuel.txt")
            Label14.Text = "Nouvelle version: " & lines6c(0)
            PictureBox23.Show()
            PictureBox24.Show()
            PictureBox25.Show()
            PictureBox26.Show()
            GroupBox1.Show()
            GroupBox2.Show()
            GroupBox3.Show()
            GroupBox4.Show()
        Else
            PictureBox23.Hide()
            PictureBox24.Hide()
            PictureBox25.Hide()
            PictureBox26.Hide()
            GroupBox1.Hide()
            GroupBox2.Hide()
            GroupBox3.Hide()
            GroupBox4.Hide()
        End If
        nbmiage3 = ListBox3.Items.Count
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        updatelogi()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        pagesacctuel3 = pagesacctuel3 + 1
        teste()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        pagesacctuel3 = pagesacctuel3 - 1
        teste()
    End Sub
End Class
