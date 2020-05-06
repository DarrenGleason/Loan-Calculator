Public Structure loan
    Public name As String
    Public principle As String
    Public interest As Double
    Public period As Integer
End Structure

Public Class Form2
    Public maxloans As Integer
    Public loans(Form5.loanNum + 1) As loan  'Array of loan structs which contains as many loans as are entered on Form2
    Dim i As Integer 'i is initialized in FormLoad

    Sub initem()  'Initialize loans struct 
        For num As Integer = 0 To Form5.loanNum - 1
            loans(num).name = "N/A"
            loans(num).principle = "000"
            loans(num).interest = 0.0
            loans(num).period = -1
        Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
        Me.Hide()
        Dim P, A, i, N As Double


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        maxloans = Form5.loanNum - 1


        If i = maxloans Then 'Checks if max amount has been implemented
            Label7.Show()
            Label7.Text = "All loans have been entered!"
            Label8.Hide()
            Button1.Hide()
            Button3.Show()
            Exit Sub
        End If

        loans(i).name = TextBox1.Text
        loans(i).principle = TextBox2.Text
        loans(i).principle = ComboBox2.Text
        loans(i).period = ComboBox1.Text

        i = i + 1


        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        Label8.Text = "Please enter Loan# " + (i + 1).ToString


    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initem() 'Calls initem function above to initialize array of structs
        Label7.Hide()
        Button3.Hide()
        Label9.Text = "Number of loans-" + (Form5.loanNum + 2).ToString
        i = 0
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class