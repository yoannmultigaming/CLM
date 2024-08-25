Imports System.ComponentModel
Imports System.IO

Public Class Form7
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        For Each fichier As String In IO.Directory.GetFiles(dosprogramefile & "/imagetmp/")
            Dim info As New IO.FileInfo(fichier)
            ListBox1.Items.Add(fichier)
        Next
        ListBox1.SetSelected(0, True)
        Text = nom & " / image de " & Form6.CLMpronom & " " & ListBox1.SelectedIndex + 1 & "/" & ListBox1.Items.Count
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        PictureBox3.Image.Dispose()
        PictureBox3.Image = Image.FromFile(ListBox1.SelectedItem)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Try
            ListBox1.SetSelected(ListBox1.SelectedIndex + 1, True)
        Catch ex As Exception
            ListBox1.SetSelected(0, True)
        End Try
        Text = nom & " / image de " & Form6.CLMpronom & " " & ListBox1.SelectedIndex + 1 & "/" & ListBox1.Items.Count
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            ListBox1.SetSelected(ListBox1.SelectedIndex - 1, True)
        Catch ex As Exception
            ListBox1.SetSelected(ListBox1.Items.Count - 1, True)
        End Try
        Text = nom & " / image de " & Form6.CLMpronom & " " & ListBox1.SelectedIndex + 1 & "/" & ListBox1.Items.Count
    End Sub

    Private Sub Form7_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        PictureBox3.Image.Dispose()
        For Each fichier As String In IO.Directory.GetFiles(dosprogramefile & "/imagetmp/")
            Dim info As New IO.FileInfo(fichier)
            File.Delete(fichier)
        Next
        Directory.Delete(dosprogramefile & "/imagetmp/")
        ListBox1.Items.Clear()

    End Sub
End Class