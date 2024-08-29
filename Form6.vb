Imports System.ComponentModel
Imports System.IO
Imports System.Net

Public Class Form6
    Public CLMlient As String = ""
    Public CLMpronom As String = ""
    Dim encours As Integer = 0
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GunaButton1.Select()
        CLMpronom = Text.Replace(nom.ToString & " / ", "")
        My.Computer.Network.DownloadFile(CLMipsite & CLMlient & "/description.txt", dostemp & "/description.txt")
        My.Computer.Network.DownloadFile(CLMipsite & CLMlient & "/version/versionactuel.txt", dostemp & "/versionactuel.txt")
        Dim fileContent As String = File.ReadAllText(dostemp & "/description.txt")
        Dim lines2 As String = File.ReadAllText(dostemp & "/versionactuel.txt")
        TextBox1.Text = fileContent
        File.Delete(dostemp & "/description.txt")
        File.Delete(dostemp & "/versionactuel.txt")

        If Directory.Exists(dosprogramefile & CLMpronom) = True Then
            GunaButton1.Text = "Ouvrir: " & CLMpronom
            ComboBox1.Hide()
            Label2.Hide()
        Else
            ComboBox1.Show()
            Label2.Show()
            Dim fwr As FtpWebRequest
            fwr = FtpWebRequest.Create(CLMPipserveur & CLMlient & "/version/")
            fwr.Credentials = New NetworkCredential(CLMid, CLMpass)
            fwr.Method = WebRequestMethods.Ftp.ListDirectory
            Dim sr As New StreamReader(fwr.GetResponse().GetResponseStream())

            Dim str As String = sr.ReadLine()
            While Not str Is Nothing

                ComboBox1.Items.Add(str)


                str = sr.ReadLine()

            End While
            sr.Close()
            ComboBox1.Items.Remove("versionactuel.txt")
            ComboBox1.SelectedItem = lines2
        End If
    End Sub

    Private Sub Form6_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If encours = 1 Then
            e.Cancel = True
        Else
            CLMlient = ""
            CLMpronom = ""
            PictureBox1.Image.Dispose()
            ComboBox1.Items.Clear()
            TextBox1.Clear()
        End If
    End Sub
    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        GunaButton1.Text = "Télécharcher: " & CLMpronom & " " & ComboBox1.SelectedItem
    End Sub


    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If GunaButton1.Text.Contains("Ouvrir:") = True Then
            Dim lines1() As String = File.ReadAllLines(dosprogramefile.ToString & CLMpronom.ToString & "/nom.txt")
            Try
                Process.Start(dosprogramefile.ToString & CLMpronom.ToString & "/programe/" & lines1(0))
            Catch ex As Exception
                MsgBox("Une erreur est survenue", MsgBoxStyle.Critical, nom)
            End Try
        ElseIf GunaButton1.Text.Contains("Télécharcher:") Then
            encours = 1
            ComboBox1.Hide()
            Label2.Hide()
            Directory.CreateDirectory(dosprogramefile & CLMpronom)
            téléchargerfr = New WebClient
            téléchargerfr.DownloadFileTaskAsync(New Uri(CLMipsite.ToString & CLMlient.ToString & "/version/" & ComboBox1.SelectedItem.ToString & "/programe.zip"), (dosprogramefile & "\programe.zip"))
        End If
    End Sub

    Private Sub téléchargerfr_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles téléchargerfr.DownloadProgressChanged
        GunaButton1.Text = "Téléchargement: " & e.ProgressPercentage & "%"
    End Sub

    Private Sub téléchargerfr_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles téléchargerfr.DownloadFileCompleted
        GunaButton1.Text = "installation....."
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Dim WithEvents téléchargerfr As WebClient

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        IO.Compression.ZipFile.ExtractToDirectory(dosprogramefile.ToString & "\programe.zip", dosprogramefile.ToString & CLMpronom.ToString & "\programe")
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        File.Delete(dosprogramefile.ToString & "\programe.zip")
        Dim sw1 As New StreamWriter(dosprogramefile.ToString & CLMpronom.ToString & "/version.txt")
        sw1.WriteLine(ComboBox1.SelectedItem)
        sw1.Close()
        My.Computer.Network.DownloadFile(CLMipsite.ToString & CLMlient.ToString & "/version/" & ComboBox1.SelectedItem.ToString & "/nom.txt", dosprogramefile.ToString & CLMpronom.ToString & "/nom.txt")

        Dim lines2() As String = File.ReadAllLines(dosinstall & "/page.txt")


        Dim lines3() As String = File.ReadAllLines(dosinstall & "/page" & lines2(0) & "/logi.txt")

        Dim i As Integer = 1

        While i <= lines2(0)
            Dim lines4() As String = File.ReadAllLines(dosinstall & "/page" & i & "/logi.txt")
            If lines4(0) = 10 Then
                i = i + 1
            Else
                Directory.CreateDirectory(dosinstall & "/page" & i & "/" & CLMpronom & "/")
                PictureBox1.Image.Save(dosinstall & "/page" & i & "/" & CLMpronom & "/image.jpg")
                Dim sw23 As New StreamWriter(dosinstall & "/page" & i & "/" & CLMpronom & "/nom.txt")
                sw23.WriteLine(CLMpronom)
                sw23.Close()

                ListBox1.Items.Clear()

                For Each fichier As String In IO.Directory.GetDirectories(dosinstall & "/page" & i & "/")
                    Dim info As New IO.FileInfo(fichier)
                    ListBox1.Items.Add(info.Name)
                Next

                Dim sw2 As New StreamWriter(dosinstall & "/page" & i & "/logi.txt")
                sw2.WriteLine(ListBox1.Items.Count)
                sw2.Close()

                Form1.vérifiinstall()
                Exit While
            End If
        End While

        If lines3(0) = 10 Then
            Directory.CreateDirectory(dosinstall & "/page" & lines2(0).ToString + 1)
            Dim sw23 As New StreamWriter(dosinstall & "/page.txt")
            sw23.WriteLine(lines2(0).ToString + 1)
            sw23.Close()
            Dim lines2bis() As String = File.ReadAllLines(dosinstall & "/page.txt")
            Directory.CreateDirectory(dosinstall & "/page" & lines2bis(0) & "/" & CLMpronom & "/")
            PictureBox1.Image.Save(dosinstall & "/page" & lines2bis(0) & "/" & CLMpronom & "/image.jpg")
            Dim sw234 As New StreamWriter(dosinstall & "/page" & lines2bis(0) & "/" & CLMpronom & "/nom.txt")
            sw234.WriteLine(CLMpronom)
            sw234.Close()

            ListBox1.Items.Clear()

            For Each fichier As String In IO.Directory.GetDirectories(dosinstall & "/page" & lines2bis(0) & "/")
                Dim info As New IO.FileInfo(fichier)
                ListBox1.Items.Add(info.Name)
            Next

            Dim sw22 As New StreamWriter(dosinstall & "/page" & lines2bis(0) & "/logi.txt")
            sw22.WriteLine(ListBox1.Items.Count)
            sw22.Close()

            Form1.vérifiinstall()
        End If
        encours = 0
        Dim msg = MsgBox("Voulez-vous créer un racourçi pour " & CLMpronom & " ?", MsgBoxStyle.YesNo, nom)
        If msg = MsgBoxResult.Yes Then
            Dim lines1() As String = File.ReadAllLines(dosprogramefile.ToString & CLMpronom.ToString & "/nom.txt")
            Dim Bureau As IWshRuntimeLibrary.WshShell
            Dim Raccourci As IWshRuntimeLibrary.WshShortcut
            Dim VarTrav As String

            Bureau = New IWshRuntimeLibrary.WshShell

            ' Chemin et nom du raccourci
            VarTrav = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & lines1(0) & ".lnk"
            Raccourci = Bureau.CreateShortcut(VarTrav)

            ' Cible
            Raccourci.TargetPath = dosprogramefile.ToString & CLMpronom.ToString & "/programe/" & lines1(0)
            ' Enregistrement
            Raccourci.Save()
        End If
        GunaButton1.Text = "Ouvrir: " & CLMpronom
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Directory.CreateDirectory(dosprogramefile & "/imagetmp/")
        My.Computer.Network.DownloadFile(CLMipsite & CLMlient & "/image.zip", dosprogramefile & "/image.zip")
        IO.Compression.ZipFile.ExtractToDirectory(dosprogramefile & "/image.zip", dosprogramefile & "/imagetmp/")
        File.Delete(dosprogramefile & "/image.zip")
        Form7.Text = nom & " / image de " & CLMpronom
        Form7.ShowDialog()
    End Sub
End Class