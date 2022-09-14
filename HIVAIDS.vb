Public Class HIVAIDS
    Inherits Disease

    Private _Origin As String
    Private _Stages As Integer
    Private _CD4_Count As Integer

    Public Sub New()

    End Sub
    Public Sub New(stage As Integer, CD4_Count As Integer, origin As String)
        _Stages = stage
        _CD4_Count = CD4_Count
        _Origin = origin
    End Sub

    Public ReadOnly Property Origin As String
        Get
            Return _Origin
        End Get
    End Property
    Public ReadOnly Property Stage As Integer
        Get
            Return _Stages
        End Get
    End Property

    Public Property CD4_Count As Integer
        Get
            Return _CD4_Count
        End Get
        Set(value As Integer)
            _CD4_Count = value
        End Set
    End Property

    Public Function DetermineStage(CD4_Count As Integer) As Integer
        Dim stage As Integer
        Select Case CD4_Count
            Case Is >= 500
                stage = 1
            Case 350 To 499
                stage = 2
            Case 200 To 349
                stage = 3
            Case Is < 200
                stage = 4
        End Select
        Return stage
    End Function
    Public Overrides Sub WayOfGettingInfected()
        Dim ans As Integer
        Dim way As String
        ans = CInt(InputBox("Please choose way of infection" & vbNewLine & "1. Through a needle" &
                            vbNewLine & "2.Sexual activty" & vbNewLine & "3.Passed on from parent"))
        Select Case ans
            Case 1
                way = "Tansmitted through needle"
            Case 2
                way = "Tansmitted through sexual activty"
            Case 3
                way = "Tansmitted through genetics"
        End Select
    End Sub
End Class
