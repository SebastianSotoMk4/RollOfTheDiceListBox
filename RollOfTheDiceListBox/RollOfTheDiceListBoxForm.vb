'Sebastian Soto
'RCET0265
'Fall 2021
'Roll Of The Dice ListBox
'https://github.com/SebastianSotoMk4/RollOfTheDiceListBox.git
Option Strict On
Option Explicit On

Public Class RollOfTheDiceListBoxForm
    'The RollOneDie() function will return a random number between 1 and a maximum inputed number 
    'Example, RollOneDie(10) will return a number between 1 and 10
    Function RollOneDie(max As Integer) As Integer
        Dim randomDouble As Double
        Dim randomInteger As Integer
        Randomize(Now.Millisecond)
        'This random Numbeer will round down to a whole number
        randomDouble = System.Math.Floor(CDbl(Rnd() * (max + 1)))
        randomInteger = CInt(randomDouble)
        '1 is added to the number to prevent 0's
        randomInteger += 1
        Return randomInteger
    End Function

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        'Closes the program when exit button is clicked
        Me.Close()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        'Runs Roll sub
        Roll()
    End Sub

    Sub Roll()
        Dim currentRoll(12) As Integer
        Dim linePrint As Integer
        Dim addLine As String
        'Two Random numbers between 1 and 6 and added together and corresponding Array variable is incremented by 1
        For i = 1 To 1000
            currentRoll((RollOneDie(5)) + (RollOneDie(5))) += 1
        Next
        DisplayListBox.Items.Add(StrDup(19, " ") & "Roll Of The Dice")
        DisplayListBox.Items.Add(StrDup(55, "="))
        'This for loop will create the Roll Number line
        For i = LBound(currentRoll) To UBound(currentRoll)
            linePrint += 1
            If linePrint > 2 Then
                addLine += CStr(i).PadLeft(4) & "|"
                If i = 12 Then
                    DisplayListBox.Items.Add(addLine)
                End If
            End If
        Next
        addLine = Nothing
        DisplayListBox.Items.Add(StrDup(55, "-"))
        'Adds Line with the amount of rolls per value
        For i = LBound(currentRoll) To UBound(currentRoll)
            Select Case currentRoll(i)
                Case = 0
                    'If 0 then do nothing
                Case <> 0
                    addLine += CStr(currentRoll(i)).PadLeft(4) & "|"
                    If i = 12 Then
                        DisplayListBox.Items.Add(addLine)
                    End If
            End Select
        Next
        DisplayListBox.Items.Add(StrDup(55, "="))
    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        'Clears the ListBox when the clear button is clicked
        DisplayListBox.Items.Clear()
    End Sub
End Class