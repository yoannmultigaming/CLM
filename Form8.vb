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
            MsgBox(CLMpronom2 & " a bien été désinstaller")
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