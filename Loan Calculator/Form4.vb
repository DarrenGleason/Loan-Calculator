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
        TextBox2.Text = ""
        TextBox3.Text = ""
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Borrowed from https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.savefiledialog?view=netcore-3.1
        'And https://www.youtube.com/watch?v=qVRIyV5IKsc

        SaveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        SaveFileDialog1.ShowDialog()
        System.IO.File.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Public Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class