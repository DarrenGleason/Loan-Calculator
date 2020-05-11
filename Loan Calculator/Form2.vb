Public Structure loan
    Public name As String
    Public principle As String
    Public interest As Double
    Public period As Integer
End Structure

Public Class Form2
    Public loans(Form5.loanNum + 1) As loan  'Array of loan structs which contains as many loans as are entered on Form2
    Dim i As Integer 'i is initialized in FormLoad



    Public Sub initem()  'Initialize loans struct based on what is entered on Form5(The number of loans)
        Dim count As Integer = 0
        For num As Integer = 0 To Form5.loanNum - 1
            loans(num).name = "N/A"
            loans(num).principle = "000"
            loans(num).interest = 0.0
            loans(num).period = -1
            count = count + 1
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Moves from Form2->Form3
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loans(i).name = TextBox1.Text       'Enters info from textboxes/combo boxes into loans array of structs
        loans(i).principle = TextBox2.Text
        loans(i).interest = ComboBox2.Text
        loans(i).period = ComboBox1.Text

        If i = Form5.loanNum - 1 Then 'Checks if all loans have been entered
            Label7.Show()             'Shows "All loans have been entered" message
            Label8.Hide()             'Hides "Please enter loan#" message
            Button1.Hide()            'Hides enter new loan button
            Button3.Show()            'Shows Continue Button
            Exit Sub
        End If

        i = i + 1                           'Increments i


        TextBox1.Text = ""                  'Resets Textboxes/Comboboxes
        TextBox2.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        Label8.Text = "Please enter Loan# " + (i + 1).ToString 'Prints message


    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initem()            'Calls initem function above to initialize array of structs
        Label7.Hide()       'Hides All Loans entered message\
        Button3.Hide()      'Hides finished button
        Label9.Text = "Number of loans-" + (Form5.loanNum).ToString 'Shows # of loans 
        i = 0               'Initializes i
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class