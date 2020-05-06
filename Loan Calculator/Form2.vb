Public Structure loan
    Public name As String
    Public principle As String
    Public interest As Double
    Public period As Integer
End Structure

Public Class Form2
    Dim maxloans As Integer = Form5.loanNum
    Dim loans(maxloans) As loan  'Array of loan structs which contains as many loans as are entered on Form2
    Dim i As Integer

    Sub initem()  'Initialize loans struct
        For num As Integer = 0 To maxloans
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
        Button2.Show()
        Button3.Show()




        loans(i).name = TextBox1.Text
        loans(i).principle = TextBox2.Text
        loans(i).principle = ComboBox2.Text
        loans(i).period = ComboBox1.Text

        'If i = 0 Then
        'Dim first As loans = New loans
        'first.name = TextBox1.Text
        'first.principle = TextBox2.Text
        'first.interest = ComboBox2.Text
        'first.period = ComboBox1.Text
        ' End If
        ' If i = 1 Then
        'Dim second As loans = New loans
        ' Second.name = TextBox1.Text
        ' Second.principle = TextBox2.Text
        ' Second.interest = ComboBox2.Text
        ' Second.period = ComboBox1.Text
        ' End If
        'If i = 2 Then
        'Dim third As loans = New loans
        ' third.name = TextBox1.Text
        'third.principle = TextBox2.Text
        'third.interest = ComboBox2.Text
        'third.period = ComboBox1.Text
        ' End If
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
        initem() 'Calls initem function above to initialize array of structs
        Label7.Hide()
        Button2.Hide()
        Button3.Hide()
        i = 0
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class