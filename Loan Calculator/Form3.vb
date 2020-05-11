Public Class Form3


    Sub swapem(a As loan, b As loan) 'Takes two loan structs. Loan is defined on Form2
        Dim temp As loan
        temp = a
        a = b
        b = temp
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Avalanche Method-Pay off highest interest loans first
        'Algorithm steps
        '1) Sort array (Form2.loans) in descending order in terms of interest
        '2) Calculate monthly interest on each loan 
        '3) Subtract interest from monthly payment
        '4) Take remainder of payment and subtract from the principle of loan on top
        '5) When principal of loan reaches 0, move on to next loan 
        '6) Repeat steps until principle of last loan <=0


        For k As Integer = 0 To Form5.loanNum - 1
            Console.WriteLine(Form2.loans(k).interest)
        Next


        Dim tempname As String
        Dim tempprinciple As String
        Dim tempinterest As Double
        Dim tempperiod As Integer

        ' For i As Integer = Form2.loans.Length - 1 To 1 Step -1
        'For j As Integer = 0 To i - 1
        'If Form2.loans(j).interest > Form2.loans(j + 1).interest Then

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


        For k As Integer = 0 To Form5.loanNum - 1
            Console.WriteLine(Form2.loans(k).interest)
        Next

        'Console.WriteLine(tempname)
        'Console.WriteLine(tempprinciple)
        'Console.WriteLine(tempinterest)
        'Console.WriteLine(tempperiod)

        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub
End Class