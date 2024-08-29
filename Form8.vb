Imports System.ComponentModel
Imports System.IO
Public Class Form8
    Dim CLMpronom2 As String = ""
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Try
            Dim lines1() As String = File.ReadAllLines(dosprogramefile & "/" & CLMpronom2 & "/nom.txt")
            Process.Start(dosprogramefile & "/" & CLMpronom2 & "/programe/" & lines1(0))
        Catch ex As Exception
            MsgBox("Une erreur est survenue", MsgBoxStyle.Critical, nom)
        End Try
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Dim msg = MsgBox("Voulez-vous vraiment Désinstaller " & CLMpronom2 & " ?", MsgBoxStyle.YesNo, nom)
        If msg = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteDirectory(dosprogramefile & "/" & CLMpronom2 & "/", FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.DeleteDirectory(dosinstall & "/page" & Form1.pagesacctuel2 & "/" & CLMpronom2 & "/", FileIO.DeleteDirectoryOption.DeleteAllContents)
            MsgBox(CLMpronom2 & " a bien été désinstaller", MsgBoxStyle.Information, nom)
            Dim lines1() As String = File.ReadAllLines(dosinstall & "/page" & Form1.pagesacctuel2 & "/logi.txt")
            If lines1(0) - 1 = 0 Then
                Dim lines2() As String = File.ReadAllLines(dosinstall & "/page.txt")
                If lines2(0) - 1 = 0 Then
                    Dim sw112 As New StreamWriter(dosinstall & "/page1/logi.txt")
                    sw112.WriteLine(0)
                    sw112.Close()
                    Form1.PictureBox12.Image.Dispose()
                    Form1.PictureBox12.Hide()
                    My.Computer.FileSystem.DeleteDirectory(dosinstall & "/page1/image/", FileIO.DeleteDirectoryOption.DeleteAllContents)
                Else
                    Dim sw11 As New StreamWriter(dosinstall & "/page.txt")
                    sw11.WriteLine(lines2(0) - 1)
                    sw11.Close()
                    File.Delete(dosinstall & "/page" & Form1.pagesacctuel2 & "/logi.txt")
                    Form1.PictureBox12.Image.Dispose()
                    My.Computer.FileSystem.DeleteDirectory(dosinstall & "/page" & Form1.pagesacctuel2 & "/", FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
            End If
            Form1.pagesacctuel2 = 1
            Form1.vérifiinstall()
            Close()
        Else
            MsgBox("action annulée", MsgBoxStyle.Information, nom)
        End If
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CLMpronom2 = Text.Replace(nom.ToString & " / ", "")
    End Sub
End Class