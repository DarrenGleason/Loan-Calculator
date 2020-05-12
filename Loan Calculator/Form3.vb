Imports System.IO
Public Class Form3

    Public outputstring As String = ""
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Avalanche Method-Pay off highest interest loans first
        'Algorithm steps
        '1) Sort array (Form2.loans) in descending order in terms of interest
        '2) Calculate monthly interest on each loan 
        '3) Subtract interest from monthly payment
        '4) Take remainder of payment and subtract from the principle of loan on top
        '5) When principle of loan reaches 0, move on to next loan 
        '6) Repeat steps until principle of last loan <=0

        Dim copyloans() As loan = Form2.loans
        'Console.WriteLine(Form2.loans.Length)
        'Console.WriteLine(copyloans.Length)

        If TextBox1.Text = "" Then
            Label3.Show()
            Label3.Text = "Must enter monthly payment to continue!"
            Exit Sub
        End If

        Form4.TextBox1.AppendText("Avalanche Method Report" & Environment.NewLine) 'Prints report in Form4.TextBox1
        outputstring += "Avalanche Method Report\n"   'Also saves report into string to output to some text file if the user wants to save a report
        Dim paymentamount As Double = TextBox1.Text
        Form4.TextBox1.AppendText("Monthly Payment-$" + paymentamount.ToString & Environment.NewLine)
        'Form4.TextBox1.Text += Environment.NewLine

        'For k As Integer = 0 To Form5.loanNum - 1
        'Console.WriteLine(copyloans(k).interest)
        'Next

        '1) Sort array (Form2.loans) in descending order in terms of interest
        Dim tempname As String
        Dim tempprinciple As String
        Dim tempinterest As Double
        Dim tempperiod As Integer
        'Bubble sort
        For i As Integer = 0 To copyloans.Length - 1
            For j As Integer = i + 1 To copyloans.Length - 1
                If copyloans(i).interest < copyloans(j).interest Then
                    'swapem
                    'temp=a
                    tempname = copyloans(i).name
                    tempprinciple = copyloans(i).principle
                    tempinterest = copyloans(i).interest
                    tempperiod = copyloans(i).period
                    'a=b
                    copyloans(i).name = copyloans(j).name
                    copyloans(i).principle = copyloans(j).principle
                    copyloans(i).interest = copyloans(j).interest
                    copyloans(i).period = copyloans(j).period
                    'b=a
                    copyloans(j).name = tempname
                    copyloans(j).principle = tempprinciple
                    copyloans(j).interest = tempinterest
                    copyloans(j).period = tempperiod
                End If
            Next
        Next


        '2) Calculate monthly interest on each loan 
        Dim monthlyinterest As Double = 0 'Interest from all loans from one month
        Dim loaninterest As Double        'Interest from one individual loan 
        'Get interest from all loans in a month
        For x As Integer = 0 To Form5.loanNum - 1
            loaninterest = copyloans(x).principle * copyloans(x).interest
            Form4.TextBox1.Text += copyloans(x).name.ToString + " Interest-$" + loaninterest.ToString 'Output to textbox report
            Form4.TextBox1.Text += Environment.NewLine
            outputstring += copyloans(x).name.ToString + " Interest-$" + loaninterest.ToString + "\n"
            monthlyinterest += loaninterest
        Next
        Form4.TextBox1.Text += "Total Monthly Interest-$" + monthlyinterest.ToString + Environment.NewLine
        outputstring += "Total Monthly Interest-$" + monthlyinterest.ToString + "\n"


        '3) Subtract interest from monthly payment
        Dim monthlypayment As Double = paymentamount
        Dim principlepayment As Double = monthlypayment - monthlyinterest

        Form4.TextBox1.Text += "Left over monthly payment after paying interest-$" + principlepayment.ToString + Environment.NewLine
        outputstring += "Left over monthly payment after paying interest-$" + principlepayment.ToString + "\n"

        '4) Take remainder of payment and subtract from the principle of loan on top

        'Using mywriter As New StreamWriter("C:\Users\Paul\source\repos\Loan-Calculator\Loan Calculator\Report.txt")
        'ywriter.WriteLine("This is a test string")
        'mywriter.Close()
        'End Using

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

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class