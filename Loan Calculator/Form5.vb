﻿Public Class Form5
    Public loanNum As Integer 'The number of loans to be used later

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()


        loanNum = TextBox1.Text

    End Sub
End Class