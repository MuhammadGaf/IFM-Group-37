' *****************************************************************
' Team Number: 37
' Team Member 1 Details: Mpiana, MK (219062231)
' Team Member 2 Details: Gaffar, M (222083957)
' Team Member 3 Details: Khumalo, LS (222049196)
' Team Member 4 Details: Dibilwane, P (222019464)
' Practical: Team Project
' Class name: Person
' *****************************************************************
'Option Statements
Option Strict On
Option Explicit On
Option Infer Off

Public Enum Status 'enum to give const value to person state 
    Infected = 0
    Recovered = 1
    Deceased = 2
End Enum
Public Class Person
    'Attributes
    Private _Name As String
    Private _Age As Integer
    Private _Country As String
    Private _Symptoms As New List(Of String) 'symptoms person presenting
    Private _State As Status
    Private _Illness As Disease = Nothing 'Intialise object to null

    'Constructors
    Public Sub New()

    End Sub
    Public Sub New(Name As String, Age As Integer, Country As String, nSymptoms As Integer, State As Status)
        _Name = Name
        _Age = Age
        _Country = Country
        _State = State
        ValidateInt(nSymptoms)
    End Sub

    'Property Methods
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property
    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(value As String)
            _Country = value
        End Set
    End Property

    Public Property Age() As Integer
        Get
            Return _Age
        End Get
        Set(value As Integer)
            ValidateInt(value)
            _Age = value
        End Set
    End Property
    Public Property Symptom(index As Integer) As String
        Get
            Return _Symptoms(index)
        End Get
        Set(value As String)
            _Symptoms(index) = value
        End Set
    End Property
    Public Property Symptoms() As List(Of String)
        Get
            Return _Symptoms
        End Get
        Set(value As List(Of String))
            _Symptoms = value
        End Set
    End Property
    Public Property State() As Status
        Get
            Return _State
        End Get
        Set(value As Status)
            _State = value
        End Set
    End Property

    Public ReadOnly Property Illness As Disease
        Get
            Return _Illness
        End Get
    End Property

    'Utility Methods
    Public Sub DetermineInfection()
        Dim mscount As Integer 'store number of symptoms for malaria
        Dim hscount As Integer 'store number of symptoms for HIVAIDS
        For i As Integer = 0 To _Symptoms.Count - 1
            If _Symptoms(i) = "Rash" Or _Symptoms(i).Contains("Flu-like illness") Or Symptoms(i).Contains("Shaking chills") Or Symptoms(i) = "Tiredness" Or Symptoms(i) = "Nausea" Or Symptoms(i) = "Vomiting" Or Symptoms(i).Contains("Yellow skin(jaundice)") Or Symptoms(i).Contains("Bloody stools") Then
                mscount += 1
            Else
                hscount += 1
            End If
        Next
        If mscount > hscount Then 'create object based on disease with the highest number of symptoms checked 
            Dim objMalaria As Malaria
            objMalaria = New Malaria() ''create an instance of Malaria
            objMalaria.Name = "Malaria"
            Dim choice As Integer
            choice = CInt(InputBox("What is the type of parasite person infected with?" & vbNewLine & "1. Plasmodium vivax" & vbNewLine & "2. P. falciparum" & vbNewLine & "3. P. malariae" & vbNewLine & "4. P. ovale"))

            Select Case choice
                Case 1
                    objMalaria.MalariaParasite = "Plasmodium vivax"
                Case 2
                    objMalaria.MalariaParasite = "P. falciparum"
                Case 3
                    objMalaria.MalariaParasite = "P. malariae"
                Case 4
                    objMalaria.MalariaParasite = "P. ovale"
            End Select

            _Illness = objMalaria
        Else
            Dim objHIVAIDS As HIVAIDS
            objHIVAIDS = New HIVAIDS() 'create an instance of HIVAIDS 
            objHIVAIDS.Name = "HIVAIDS"
            objHIVAIDS.CD4_Count = CInt(InputBox("What is the person's CD4 count?"))
            _Illness = objHIVAIDS
        End If
    End Sub

    Public Shared Sub ValidateInt(ByRef num As Integer) 'What to change parameter value within the subroutine
        While num < 0
            num = CInt(InputBox("Please enter a postive number"))
        End While
    End Sub

End Class
