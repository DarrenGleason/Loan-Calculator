Public Structure loans
    Public name As String
    Public principle As String
    Public interest As Double
    Public period As Integer
End Structure

Public Class Form2
    Dim i As Integer
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Show()
        Button3.Show()
        If i = 0 Then
            Dim first As loans = New loans
            first.name = TextBox1.Text
            first.principle = TextBox2.Text
            first.interest = ComboBox2.Text
            first.period = ComboBox1.Text
        End If
        If i = 1 Then
            Dim second As loans = New loans
            second.name = TextBox1.Text
            second.principle = TextBox2.Text
            second.interest = ComboBox2.Text
            second.period = ComboBox1.Text
        End If
        If i = 2 Then
            Dim third As loans = New loans
            third.name = TextBox1.Text
            third.principle = TextBox2.Text
            third.interest = ComboBox2.Text
            third.period = ComboBox1.Text
        End If
        i = i + 1

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Hide()
        Button3.Hide()
        i = 0
    End Sub

End Class