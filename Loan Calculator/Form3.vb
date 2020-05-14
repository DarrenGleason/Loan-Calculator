Imports System.IO
Public Class Form3

    Public outputstring As String = ""
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Avalanche Method-Pay off highest interest loans first
        'Algorithm steps
        '1)Create Copy of loans struct to work with called copyloans
        '2) Sort array (copyloans) in descending order in terms of interest
        '3) Calculate monthly interest on each loan 
        '4) Subtract interest from monthly payment
        '5) Take remainder of payment and subtract from the principle of loan on top
        '6) When principle of loan reaches 0, move on to next loan 
        '7) Repeat steps until principle of last loan <=0

        'The output for the report is sent to From4.TextBox1.Text to be displayed
        'outputstring is for the purpose of writing to a .txt file which can be saved

        'Checks that monthly payment info has been entered
        If TextBox1.Text = "" Then
            Label3.Show()
            Label3.Text = "Must enter monthly payment to continue!"
            Exit Sub
        End If

        '1)Create Copy of loans struct to work with called copyloans
        Dim copyloans() As loan = Form2.loans

        'Prints report header in Form4.TextBox1
        Form4.TextBox1.AppendText("Avalanche Method Report-" & Environment.NewLine)

        'Stores Payment amount
        Dim paymentamount As Double = TextBox1.Text
        Form4.TextBox1.AppendText("Monthly Payment-$" + paymentamount.ToString & Environment.NewLine)

        '2) Sort array (Form2.loans) in descending order in terms of interest
        Dim tempname As String
        Dim tempprinciple As String
        Dim tempinterest As Double

        'Bubble sort for interest
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

        'Keeps track of how many months
        Dim monthnum As Integer = 1
        'Keeps track of how many interest dollars paid
        Dim totalinterestdollars As Double = 0
        '7) Repeat steps until principle of last loan <=0
        While copyloans.Length <> 0

            Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
            Form4.TextBox1.Text += "Month-" + monthnum.ToString + "               Paying $" + paymentamount.ToString + " Per Month" + Environment.NewLine
            Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
            '3) Calculate monthly interest on each loan 
            Dim monthlyinterest As Double = 0 'Interest from all loans from one month
            Dim loaninterest As Double        'Interest from one individual loan 

            'Get interest from all loans in a month
            For x As Integer = 0 To copyloans.Length - 1
                loaninterest = copyloans(x).principle * copyloans(x).interest
                Form4.TextBox1.Text += copyloans(x).name.ToString + " Interest=$" + FormatNumber(loaninterest, 2).ToString + Environment.NewLine 'Output to textbox report
                monthlyinterest += loaninterest
            Next
            Form4.TextBox1.Text += "Total Monthly Interest=$" + FormatNumber(monthlyinterest, 2).ToString + Environment.NewLine
            totalinterestdollars += monthlyinterest
            'Checks that payment is sufficient to pay off loans
            If (paymentamount < monthlyinterest) Then
                Form4.TextBox1.Text += "Loans will never be paid off with this payment because monthly interest is greater than payment" + Environment.NewLine
                Form4.Show()
                Me.Hide()
                Exit Sub
            End If

            '4) Subtract interest from monthly payment
            Dim monthlypayment As Double = paymentamount 'Copy of monthlypayment
            Dim principlepayment As Double = monthlypayment - monthlyinterest 'Amount of payment to go toward principle

            Form4.TextBox1.Text += "Left over monthly payment after paying interest=$" + FormatNumber(principlepayment, 2).ToString + Environment.NewLine

            '5) Take remainder of payment and subtract from the principle of loan on top

            Form4.TextBox1.Text += "Principle on loan- " + copyloans(0).name + "=$" + FormatNumber(copyloans(0).principle, 2).ToString + Environment.NewLine
            copyloans(0).principle = copyloans(0).principle - principlepayment
            Form4.TextBox1.Text += "Principle after payment on loan- " + copyloans(0).name + "=$" + FormatNumber(copyloans(0).principle, 2).ToString + Environment.NewLine
            '6) When loan principle reaches 0 go to next loan
            If copyloans.Length < 2 Then
                If copyloans(0).principle < 0 Then
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Loan- " + copyloans(0).name + " has been paid off!" + Environment.NewLine
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Left Over Money =$" + FormatNumber(Math.Abs(copyloans(0).principle), 2) + Environment.NewLine
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Congratulations You are now student debt free!" + Environment.NewLine
                    Form4.TextBox1.Text += "Number Of months=" + monthnum.ToString + Environment.NewLine
                    Form4.TextBox1.Text += "Total Interest Dollars Paid=" + FormatNumber(totalinterestdollars, 2).ToString + Environment.NewLine
                    Form4.TextBox2.Text = "Number Of months to pay off all loans=" + monthnum.ToString + Environment.NewLine
                    Form4.TextBox2.Text += "Total Interest Dollars Paid=$" + FormatNumber(totalinterestdollars, 2) + Environment.NewLine
                    Form4.Show()
                    Me.Hide()
                    Exit Sub
                ElseIf copyloans(0).principle = 0 Then
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Congratulations You are now student debt free!" + Environment.NewLine
                    Form4.TextBox1.Text += "Number Of months=" + monthnum.ToString + Environment.NewLine
                    Form4.TextBox1.Text += "Total Interest Dollars Paid=" + FormatNumber(totalinterestdollars, 2) + Environment.NewLine
                    Form4.TextBox2.Text = "Number Of months to pay off all loans=" + monthnum.ToString + Environment.NewLine
                    Form4.TextBox2.Text += "Total Interest Dollars Paid=$" + FormatNumber(totalinterestdollars, 2) + Environment.NewLine
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
                    Form4.TextBox1.Text += "Remainder of payment =$" + FormatNumber(Math.Abs(copyloans(0).principle), 2).ToString + Environment.NewLine
                    Form4.TextBox1.Text += "Principle after payment on loan- " + copyloans(1).name + "=$" + FormatNumber(copyloans(1).principle, 2).ToString + Environment.NewLine
                    'Gets rid of array element copyloans(0)
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

        Form4.TextBox2.Text = "Number Of months=" + monthnum.ToString + Environment.NewLine
        Form4.TextBox2.Text = "Total Interest Dollars Paid=" + FormatNumber(totalinterestdollars, 2) + Environment.NewLine
        'Using mywriter As New StreamWriter("C:\Users\Paul\source\repos\Loan-Calculator\Loan Calculator\Report.txt")
        'mywriter.WriteLine(outputstring)
        'riter.Close()
        'End Using

        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Snowball Method-Pay off lowest loan amounts first
        'Algorithm steps
        '1)Create Copy of loans struct to work with called copyloans
        '2) Sort array (copyloans) in descending order in terms of smallest loan amount
        '3) Calculate monthly interest on each loan 
        '4) Subtract interest from monthly payment
        '5) Take remainder of payment and subtract from the principle of loan on top
        '6) When principle of loan reaches 0, move on to next loan 
        '7) Repeat steps until principle of last loan <=0

        'The output for the report is sent to From4.TextBox1.Text to be displayed
        'outputstring is for the purpose of writing to a .txt file which can be saved

        'Checks that monthly payment info has been entered
        If TextBox1.Text = "" Then
            Label3.Show()
            Label3.Text = "Must enter monthly payment to continue!"
            Exit Sub
        End If

        '1)Create Copy of loans struct to work with called copyloans
        Dim copyloans() As loan = Form2.loans

        'Prints report header in Form4.TextBox1
        Form4.TextBox1.AppendText("Snowball Method Report-" & Environment.NewLine)
        'Also saves report into string to output to some text file if the user wants to save a report
        'Stores Payment amount
        Dim paymentamount As Double = TextBox1.Text
        Form4.TextBox1.AppendText("Monthly Payment-$" + paymentamount.ToString & Environment.NewLine)

        '2) Sort array (Form2.loans) in descending order in terms of interest
        Dim tempname As String
        Dim tempprinciple As String
        Dim tempinterest As Double

        'Bubble sort for smallest amount
        For i As Integer = 0 To copyloans.Length - 1
            For j As Integer = i + 1 To copyloans.Length - 1
                If copyloans(i).principle > copyloans(j).principle Then
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

        'Keeps track of how many months
        Dim monthnum As Integer = 1
        'Keeps track of how many interest dollars paid
        Dim totalinterestdollars As Double = 0
        '7) Repeat steps until principle of last loan <=0
        While copyloans.Length <> 0

            Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
            Form4.TextBox1.Text += "Month-" + monthnum.ToString + "               Paying $" + paymentamount.ToString + " Per Month" + Environment.NewLine
            Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
            '3) Calculate monthly interest on each loan 
            Dim monthlyinterest As Double = 0 'Interest from all loans from one month
            Dim loaninterest As Double        'Interest from one individual loan 

            'Get interest from all loans in a month
            For x As Integer = 0 To copyloans.Length - 1
                loaninterest = copyloans(x).principle * copyloans(x).interest
                Form4.TextBox1.Text += copyloans(x).name.ToString + " Interest=$" + FormatNumber(loaninterest, 2).ToString + Environment.NewLine 'Output to textbox report
                monthlyinterest += loaninterest
            Next
            Form4.TextBox1.Text += "Total Monthly Interest=$" + FormatNumber(monthlyinterest, 2).ToString + Environment.NewLine
            totalinterestdollars += monthlyinterest
            'Checks that payment is sufficient to pay off loans
            If (paymentamount < monthlyinterest) Then
                Form4.TextBox1.Text += "Loans will never be paid off with this payment because monthly interest is greater than payment" + Environment.NewLine
                Form4.Show()
                Me.Hide()
                Exit Sub
            End If

            '4) Subtract interest from monthly payment
            Dim monthlypayment As Double = paymentamount 'Copy of monthlypayment
            Dim principlepayment As Double = monthlypayment - monthlyinterest 'Amount of payment to go toward principle

            Form4.TextBox1.Text += "Left over monthly payment after paying interest=$" + FormatNumber(principlepayment, 2).ToString + Environment.NewLine

            '5) Take remainder of payment and subtract from the principle of loan on top

            Form4.TextBox1.Text += "Principle on loan- " + copyloans(0).name + "=$" + FormatNumber(copyloans(0).principle, 2).ToString + Environment.NewLine
            copyloans(0).principle = copyloans(0).principle - principlepayment
            Form4.TextBox1.Text += "Principle after payment on loan- " + copyloans(0).name + "=$" + FormatNumber(copyloans(0).principle, 2).ToString + Environment.NewLine
            '6) When loan principle reaches 0 go to next loan
            If copyloans.Length < 2 Then
                If copyloans(0).principle < 0 Then
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Loan- " + copyloans(0).name + " has been paid off!" + Environment.NewLine
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Left Over Money =$" + FormatNumber(Math.Abs(copyloans(0).principle), 2) + Environment.NewLine
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Congratulations You are now student debt free!" + Environment.NewLine
                    Form4.TextBox1.Text += "Number Of months=" + monthnum.ToString + Environment.NewLine
                    Form4.TextBox1.Text += "Total Interest Dollars Paid=" + FormatNumber(totalinterestdollars, 2).ToString + Environment.NewLine
                    Form4.TextBox2.Text = "Number Of months to pay off all loans=" + monthnum.ToString + Environment.NewLine
                    Form4.TextBox2.Text += "Total Interest Dollars Paid=$" + FormatNumber(totalinterestdollars, 2) + Environment.NewLine
                    Form4.Show()
                    Me.Hide()
                    Exit Sub
                ElseIf copyloans(0).principle = 0 Then
                    Form4.TextBox1.Text += "--------------------------------------------------------" + Environment.NewLine
                    Form4.TextBox1.Text += "Congratulations You are now student debt free!" + Environment.NewLine
                    Form4.TextBox1.Text += "Number Of months=" + monthnum.ToString + Environment.NewLine
                    Form4.TextBox1.Text += "Total Interest Dollars Paid=" + FormatNumber(totalinterestdollars, 2) + Environment.NewLine
                    Form4.TextBox2.Text = "Number Of months to pay off all loans=" + monthnum.ToString + Environment.NewLine
                    Form4.TextBox2.Text += "Total Interest Dollars Paid=$" + FormatNumber(totalinterestdollars, 2) + Environment.NewLine
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
                    Form4.TextBox1.Text += "Remainder of payment =$" + FormatNumber(Math.Abs(copyloans(0).principle), 2).ToString + Environment.NewLine
                    Form4.TextBox1.Text += "Principle after payment on loan- " + copyloans(1).name + "=$" + FormatNumber(copyloans(1).principle, 2).ToString + Environment.NewLine
                    'Gets rid of array element copyloans(0)
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

        'Using mywriter As New StreamWriter("C:\Users\Paul\source\repos\Loan-Calculator\Loan Calculator\Report.txt")
        'mywriter.WriteLine(outputstring)
        'mywriter.Close()
        'End Using

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