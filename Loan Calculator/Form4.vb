Imports System.IO
Imports System.Text

Module Module1
    Sub Main()
        'Sets path to c:\Users\Public\Report.txt
        Dim path As String = "c:\Users\Public\Report.txt"

        'Creates the desired path as to where to save the file
        Dim fs As FileStream = File.Create(path)

        'Writes a simple space as a character
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(" ")
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub
End Module
Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim files As System.IO.StreamWriter
        'Opens the newly created text file
        files = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\Public\Report.txt", True)
        'Writes each line from the text box to the text file
        files.WriteLine(TextBox1.Text)
        'Closes the text file
        files.Close()
        'Runs the save dialog sequence, Does not use location that save dialog does...
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Public Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class