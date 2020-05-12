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

        Form4.TextBox1.AppendText("Avalanche Method Report-" & Environment.NewLine) 'Prints report in Form4.TextBox1
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
        'Bubble sort
        For i As Integer = 0 To copyloans.Length - 1
            For j As Integer = i + 1 To copyloans.Length - 1
                If copyloans(i).interest < copyloans(j).interest Then
                    'swapem
                    'temp=a
                    tempname = copyloans(i).name
                    tempprinciple = copyloans(i).principle
                    tempinterest = copyloans(i).interest
                    'a=b
                    copyloans(i).name = copyloans(j).name
                    copyloans(i).principle = copyloans(j).principle
                    copyloans(i).interest = copyloans(j).interest
                    'b=a
                    copyloans(j).name = tempname
                    copyloans(j).principle = tempprinciple
                    copyloans(j).interest = tempinterest
                End If
            Next
        Next

        Dim monthnum As Integer = 1
        '6)Repeat process until size of loop is empty
        While copyloans.Length <> 0
            Form4.TextBox1.Text += "Month-" + monthnum.ToString + Environment.NewLine
            Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
            '2) Calculate monthly interest on each loan 
            Dim monthlyinterest As Double = 0 'Interest from all loans from one month
            Dim loaninterest As Double        'Interest from one individual loan 
            'Get interest from all loans in a month
            For x As Integer = 0 To copyloans.Length - 1
                loaninterest = copyloans(x).principle * copyloans(x).interest
                Form4.TextBox1.Text += copyloans(x).name.ToString + " Interest-$" + loaninterest.ToString 'Output to textbox report
                Form4.TextBox1.Text += Environment.NewLine
                outputstring += copyloans(x).name.ToString + " Interest-$" + loaninterest.ToString + "\n"
                monthlyinterest += loaninterest
            Next
            Form4.TextBox1.Text += "Total Monthly Interest-$" + monthlyinterest.ToString + Environment.NewLine
            outputstring += "Total Monthly Interest-$" + monthlyinterest.ToString + "\n"

            If (paymentamount < monthlyinterest) Then

                Form4.TextBox1.Text += "Loans will never be paid off with this payment because monthly interest is greater than payment" + Environment.NewLine
                Form4.Show()

                Me.Hide()

                Exit Sub

            End If

            '3) Subtract interest from monthly payment
            Dim monthlypayment As Double = paymentamount
            Dim principlepayment As Double = monthlypayment - monthlyinterest

            Form4.TextBox1.Text += "Left over monthly payment after paying interest-$" + principlepayment.ToString + Environment.NewLine
            outputstring += "Left over monthly payment after paying interest-$" + principlepayment.ToString + "\n"

            '4) Take remainder of payment and subtract from the principle of loan on top

            'For k As Integer = 0 To copyloans.Length - 1
            'Console.WriteLine(copyloans(k).principle)
            'Next


            Form4.TextBox1.Text += "Principle on loan-   " + copyloans(0).name + "=$" + copyloans(0).principle.ToString + Environment.NewLine
            outputstring += "Principle on loan-   " + copyloans(0).name + "=$" + copyloans(0).principle.ToString + "\n"
            copyloans(0).principle = copyloans(0).principle - principlepayment
            Form4.TextBox1.Text += "Principle after payment on loan-   " + copyloans(0).name + "=$" + copyloans(0).principle.ToString + Environment.NewLine


            If copyloans.Length < 2 Then
                If copyloans(0).principle < 0 Then
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Loan-   " + copyloans(0).name + " has been paid off!" + Environment.NewLine
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Remainder of payment -$" + Math.Abs(copyloans(0).principle).ToString + Environment.NewLine
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Congratulations You are now student debt free!" + Environment.NewLine
                    Form4.Show()
                    Me.Hide()
                    Exit Sub
                ElseIf copyloans(0).principle = 0 Then
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Congratulations You are now student debt free!" + Environment.NewLine
                    Form4.Show()
                    Me.Hide()
                    Exit Sub
                End If
            Else
                If copyloans(0).principle < 0 Then
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Loan-   " + copyloans(0).name + " has been paid off!" + Environment.NewLine
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Moving on to Loan-   " + copyloans(1).name + Environment.NewLine
                    copyloans(1).principle = copyloans(1).principle + copyloans(0).principle
                    Form4.TextBox1.Text += "Remainder of payment -$" + Math.Abs(copyloans(0).principle).ToString + Environment.NewLine
                    Form4.TextBox1.Text += "Principle after payment on loan-   " + copyloans(1).name + "=$" + copyloans(1).principle.ToString + Environment.NewLine
                    copyloans = copyloans.Skip(1).ToArray() 'https://stackoverflow.com/questions/7169259/vb-net-remove-first-element-from-array
                ElseIf copyloans(0).principle = 0 Then
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Loan-   " + copyloans(0).name + " has been paid off!" + Environment.NewLine
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    copyloans = copyloans.Skip(1).ToArray()
                End If
            End If

            monthnum = monthnum + 1
        End While
        'For k As Integer = 0 To copyloans.Length - 1
        'sole.WriteLine(copyloans(k).principle)
        'Next

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