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

        'For k As Integer = 0 To Form2.loans.Length
        'Console.WriteLine(Form2.loans(k).interest)
        ' Next


        For i As Integer = 0 To Form2.loans.Length - 1
            For j As Integer = i + 1 To Form2.loans.Length - 1
                If Form2.loans(i).interest > Form2.loans(j).interest Then
                    swapem(Form2.loans(i), Form2.loans(j))
                End If
            Next
        Next



        'Console.WriteLine(Form2.loans(0).interest)

        'Form4.Label1.Text = Form2.loans.Length

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