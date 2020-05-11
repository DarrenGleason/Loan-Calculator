Public Class Form3

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Avalanche Method-Pay off highest interest loans first
        'Algorithm steps
        '1) Sort array (Form2.loans) in descending order in terms of interest
        '2) Calculate monthly interest on each loan 
        '3) Subtract interest from monthly payment
        '4) Take remainder of payment and subtract from the principle of loan on top
        '5) When principle of loan reaches 0, move on to next loan 
        '6) Repeat steps until principle of last loan <=0


        If TextBox1.Text = "" Then
            Label3.Show()
            Label3.Text = "Must enter monthly payment to continue!"
            Exit Sub
        End If

        For k As Integer = 0 To Form5.loanNum - 1
            Console.WriteLine(Form2.loans(k).interest)
        Next

        '1) Sort array (Form2.loans) in descending order in terms of interest
        Dim tempname As String
        Dim tempprinciple As String
        Dim tempinterest As Double
        Dim tempperiod As Integer

        For i As Integer = 0 To Form2.loans.Length - 1
            For j As Integer = i + 1 To Form2.loans.Length - 1
                If Form2.loans(i).interest < Form2.loans(j).interest Then
                    'swapem
                    'temp=a
                    tempname = Form2.loans(i).name
                    tempprinciple = Form2.loans(i).principle
                    tempinterest = Form2.loans(i).interest
                    tempperiod = Form2.loans(i).period
                    'a=b
                    Form2.loans(i).name = Form2.loans(j).name
                    Form2.loans(i).principle = Form2.loans(j).principle
                    Form2.loans(i).interest = Form2.loans(j).interest
                    Form2.loans(i).period = Form2.loans(j).period
                    'b=a
                    Form2.loans(j).name = tempname
                    Form2.loans(j).principle = tempprinciple
                    Form2.loans(j).interest = tempinterest
                    Form2.loans(j).period = tempperiod
                End If
            Next
        Next

        '2) Calculate monthly interest on each loan 
        Dim monthlyinterest As Double = 0 'Interest from all loans from one month
        Dim loaninterest As Double        'Interest from one individual loan 
        'Get interest from all loans in a month
        For x As Integer = 0 To Form5.loanNum - 1
            loaninterest = Form2.loans(x).principle * Form2.loans(x).interest
            monthlyinterest += loaninterest
        Next




        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            Label3.Show()
            Label3.Text = "Must enter monthly payment to continue!"
            Exit Sub
        End If

        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Hide()
    End Sub
End Class