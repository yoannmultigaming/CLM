Imports System.IO
Imports System.Net
Imports System.Windows

Public Class Form3
    Public etap As Integer = 0
    Public ipserveur As String = ""
    Public idftp As String = ""
    Public passftp As String = ""
    Public ipsite As String = ""
    Public desnoméro() As Char = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("Avant de commencer assurez-vous d'avoir un serveur web et un serveur FTP qui pointe vers le même serveur web", MsgBoxStyle.Exclamation, "CLM / Inisialiser un serveur")
        Text = nom & " / Inisialiser un serveur"
        etap1()
    End Sub
    Sub etap1()
        Label1.Text = "étape 1: Connextion au serveur FTP"
        Label2.Text = "Addresse IP / nom de domaine:"
        Label3.Text = "Identifiant:"
        Label4.Text = "Mots de passe:"
        Label5.Text = "Le port"
        TextBox4.Text = "21"
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If etap = 0 Then
            Dim sw1 As New StreamWriter(dosrepertoire & "testco.txt")
            sw1.WriteLine("CML")
            sw1.Close()
            Try
                My.Computer.Network.UploadFile(dosrepertoire & "testco.txt", "ftp://" & TextBox2.Text & ":" & TextBox3.Text & "@" & TextBox1.Text & ":" & TextBox4.Text & "/testco.txt")
                ipserveur = "ftp://" & TextBox2.Text & ":" & TextBox3.Text & "@" & TextBox1.Text & ":" & TextBox4.Text
                idftp = TextBox2.Text
                passftp = TextBox3.Text
                etap = 1
                Button1.Hide()
                etap2()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        ElseIf etap = 1 Then
            Try
                My.Computer.Network.DownloadFile(TextBox1.Text & ":" & TextBox4.Text & "/testco.txt", dosrepertoire & "/testco.txt")
                File.Delete(dosrepertoire & "/testco.txt")
                ipsite = TextBox1.Text & ":" & TextBox4.Text

                Dim MaRequete8 As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/testco.txt"), System.Net.FtpWebRequest)
                Dim ftpStream8 As Stream = Nothing

                MaRequete8.Credentials = New System.Net.NetworkCredential(idftp, passftp)
                MaRequete8.Method = System.Net.WebRequestMethods.Ftp.DeleteFile

                Dim response8 As FtpWebResponse = CType(MaRequete8.GetResponse, FtpWebResponse)
                ftpStream8 = response8.GetResponseStream
                ftpStream8.Close()
                response8.Close()

                MsgBox("La connexion au serveur FTP et au serveur web est parfaite", MsgBoxStyle.Information, nom & " / Inisialiser un serveur")
                Dim msg = MsgBox("Voulez-vous vraiment initialiser ce serveur ?", MsgBoxStyle.YesNo, nom & " / Inisialiser un serveur")
                If msg = MsgBoxResult.Yes Then
                    etap3()
                Else
                    Close()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    Sub etap2()
        File.Delete(dosrepertoire & "testco.txt")
        Label1.Text = "étape 2: Connextion au serveur web"
        Label2.Text = "Addresse IP / nom de domaine:"
        TextBox1.Text = "http://" & TextBox1.Text
        TextBox2.Hide()
        TextBox3.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Text = "Le port"
        TextBox4.Text = "80"
    End Sub
    Sub etap3()
        Try
            Dim MaRequete As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/CLM/"), System.Net.FtpWebRequest)
            Dim ftpStream As Stream = Nothing

            MaRequete.Credentials = New System.Net.NetworkCredential(idftp, passftp)
            MaRequete.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response As FtpWebResponse = CType(MaRequete.GetResponse, FtpWebResponse)
            ftpStream = response.GetResponseStream
            ftpStream.Close()
            response.Close()

            Dim MaRequete2 As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/CLM/utilisateur/"), System.Net.FtpWebRequest)
            Dim ftpStream2 As Stream = Nothing

            MaRequete2.Credentials = New System.Net.NetworkCredential(idftp, passftp)
            MaRequete2.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response2 As FtpWebResponse = CType(MaRequete2.GetResponse, FtpWebResponse)
            ftpStream2 = response2.GetResponseStream
            ftpStream2.Close()
            response2.Close()

            Dim MaRequete3 As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/CLM/logiciel/"), System.Net.FtpWebRequest)
            Dim ftpStream3 As Stream = Nothing

            MaRequete3.Credentials = New System.Net.NetworkCredential(idftp, passftp)
            MaRequete3.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response3 As FtpWebResponse = CType(MaRequete3.GetResponse, FtpWebResponse)
            ftpStream3 = response3.GetResponseStream
            ftpStream3.Close()
            response3.Close()

            Dim MaRequete9 As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/CLM/logiciel/profil/"), System.Net.FtpWebRequest)
            Dim ftpStream9 As Stream = Nothing

            MaRequete9.Credentials = New System.Net.NetworkCredential(idftp, passftp)
            MaRequete9.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response9 As FtpWebResponse = CType(MaRequete9.GetResponse, FtpWebResponse)
            ftpStream9 = response9.GetResponseStream
            ftpStream9.Close()
            response9.Close()

            Dim MaRequete10 As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/CLM/logiciel/profil/default/"), System.Net.FtpWebRequest)
            Dim ftpStream10 As Stream = Nothing

            MaRequete10.Credentials = New System.Net.NetworkCredential(idftp, passftp)
            MaRequete10.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response10 As FtpWebResponse = CType(MaRequete9.GetResponse, FtpWebResponse)
            ftpStream10 = response10.GetResponseStream
            ftpStream10.Close()
            response10.Close()

            Dim MaRequete4 As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/CLM/logiciel/profil/default/tout/"), System.Net.FtpWebRequest)
            Dim ftpStream4 As Stream = Nothing

            MaRequete4.Credentials = New System.Net.NetworkCredential(idftp, passftp)
            MaRequete4.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response4 As FtpWebResponse = CType(MaRequete4.GetResponse, FtpWebResponse)
            ftpStream4 = response4.GetResponseStream
            ftpStream4.Close()
            response4.Close()

            Dim MaRequete5 As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/CLM/logiciel/profil/default/categorie/"), System.Net.FtpWebRequest)
            Dim ftpStream5 As Stream = Nothing

            MaRequete5.Credentials = New System.Net.NetworkCredential(idftp, passftp)
            MaRequete5.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response5 As FtpWebResponse = CType(MaRequete5.GetResponse, FtpWebResponse)
            ftpStream5 = response5.GetResponseStream
            ftpStream5.Close()
            response5.Close()

            Dim MaRequete6 As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/CLM/mail/"), System.Net.FtpWebRequest)
            Dim ftpStream6 As Stream = Nothing

            MaRequete6.Credentials = New System.Net.NetworkCredential(idftp, passftp)
            MaRequete6.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response6 As FtpWebResponse = CType(MaRequete6.GetResponse, FtpWebResponse)
            ftpStream6 = response6.GetResponseStream
            ftpStream6.Close()
            response6.Close()

            Dim MaRequete7 As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(ipserveur & "/CLM/config/"), System.Net.FtpWebRequest)
            Dim ftpStream7 As Stream = Nothing

            MaRequete7.Credentials = New System.Net.NetworkCredential(idftp, passftp)
            MaRequete7.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory

            Dim response7 As FtpWebResponse = CType(MaRequete7.GetResponse, FtpWebResponse)
            ftpStream7 = response7.GetResponseStream
            ftpStream7.Close()
            response7.Close()

            Dim sw1 As New StreamWriter(dosrepertoire & "index.html")
            sw1.WriteLine("")
            sw1.Close()

            My.Computer.Network.UploadFile(dosrepertoire & "index.html", ipserveur & "/CLM/logiciel/profil/default/categorie/index.html")
            My.Computer.Network.UploadFile(dosrepertoire & "index.html", ipserveur & "/CLM/logiciel/profil/default/tout/index.html")
            My.Computer.Network.UploadFile(dosrepertoire & "index.html", ipserveur & "/CLM/logiciel/profil/default/index.html")
            My.Computer.Network.UploadFile(dosrepertoire & "index.html", ipserveur & "/CLM/logiciel/profil/index.html")
            My.Computer.Network.UploadFile(dosrepertoire & "index.html", ipserveur & "/CLM/logiciel/index.html")
            My.Computer.Network.UploadFile(dosrepertoire & "index.html", ipserveur & "/CLM/utilisateur/index.html")
            My.Computer.Network.UploadFile(dosrepertoire & "index.html", ipserveur & "/CLM/mail/index.html")
            My.Computer.Network.UploadFile(dosrepertoire & "index.html", ipserveur & "/CLM/config/index.html")
            My.Computer.Network.UploadFile(dosrepertoire & "index.html", ipserveur & "/CLM/index.html")
            File.Delete(dosrepertoire & "index.html")
            MsgBox("L'initialisation est terminée", MsgBoxStyle.Information, nom & " / Inisialiser un serveur")
            Form4.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not desnoméro.Contains(e.KeyChar) And Not Asc(e.KeyChar) = 8 Then
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