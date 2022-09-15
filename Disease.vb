' *****************************************************************
' Team Number: 37
' Team Member 1 Details: Mpiana, MK (219062231)
' Team Member 2 Details: Gaffar, M (222083957)
' Team Member 3 Details: Khumalo, LS (222049196)
' Team Member 4 Details: Dibilwane, P (222019464)
' Practical: Team Project
' Class name: Disease
' *****************************************************************
'Option Statements
Option Strict On
Option Explicit On
Option Infer Off

Public Enum ClassArray 'enum that lists arrays in class and gives them a constant value
    Symptoms = 0
    Treatments = 1
End Enum
Public Enum DiseaseNo
    Malaria = 1
    HIVAIDS = 2
End Enum

Public MustInherit Class Disease 'Abstract Class
    'Member Attributes
    Protected _Name As String
    Protected _Symptoms() As String
    Protected _Treatments() As String
    Protected _Death_Rate As Double 'ReadOnly
    Protected _nDiseases As Integer = 2
    Protected Shared _nInfected() As Integer ' 1 = Malaria , 2 = HIVAIDS ' Store nInfected separately for each disease
    Protected Shared _nDead() As Integer

    'Constructors
    Public Sub New()
        ReDim _nDead(_nDiseases)
        ReDim _nInfected(_nDiseases)
    End Sub
    Public Sub New(Name As String, nSymptoms As Integer, nTreatments As Integer)
        _Name = Name
        'Allocate memory for Arrays
        ReDim _Symptoms(nSymptoms)
        ReDim _Treatments(nTreatments)
        ReDim _nDead(_nDiseases)
        ReDim _nInfected(_nDiseases)
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
    Public Property Symptoms(index As Integer) As String
        Get
            Return _Symptoms(index)
        End Get
        Set(value As String)
            _Symptoms(index) = value
        End Set
    End Property

    Public Property Treatment(index As Integer) As String
        Get
            Return _Treatments(index)
        End Get
        Set(value As String)
            _Treatments(index) = value
        End Set
    End Property

    Public ReadOnly Property Death_Rate() As Double 'can't change value outside the class
        Get
            Return _Death_Rate
        End Get
    End Property

    Public Shared Property nInfected(index As Integer) As Integer
        Get
            Return _nInfected(index)
        End Get
        Set(value As Integer)
            ValidateInt(value)
            _nInfected(index) = value
        End Set
    End Property
    Public Shared Property nDead(index As Integer) As Integer
        Get
            Return _nDead(index)
        End Get
        Set(value As Integer)
            _nDead(index) = value
        End Set
    End Property

    'Utility Methods
    Public Sub CalculateDeathRate(DiseaseNo As Integer)
        _Death_Rate = _nDead(DiseaseNo) / _nInfected(DiseaseNo)
    End Sub

    Public MustOverride Function WayOfGettingInfected() As String 'Implementation done in derived classes
    Public Shared Sub ValidateInt(ByRef num As Integer) 'What to change parameter value within the subroutine
        'shared between class, only one copy exists in memory
        While num < 0
            num = CInt(InputBox("Please enter a postive number"))
        End While
    End Sub
    Public Sub ResizeArray(size As Integer, e As ClassArray) 'use enumeration to determine which array to resize
        If e = ClassArray.Symptoms Then
            ReDim _Symptoms(size)
        ElseIf e = ClassArray.Treatments Then
            ReDim _Treatments(size)
        End If
    End Sub
End Class
