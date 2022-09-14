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
Public MustInherit Class Disease 'Abstract Class
    Public Enum Array 'enum that lists arrays in class and gives them a constant value
        Symtomps = 0
        Treatments = 1
    End Enum

    'Member Attributes
    Protected _Name As String
    Protected _Symtomps() As String
    Protected _Treatments() As String
    Protected _Death_Rate As Double 'ReadOnly
    Protected _nInfected As Integer
    Protected _nRecovered As Integer
    'Constructors
    Public Sub New()

    End Sub
    Public Sub New(Name As String, nSymptops As Integer, nTreatments As Integer, nInfected As Integer, nRecovered As Integer)
        _Name = Name

        'Allocate memory for Arrays
        ReDim _Symtomps(nSymptops)
        ReDim _Treatments(nTreatments)

        'Validate Input to ensure +ve value
        ValidateInt(nInfected)
        ValidateInt(nRecovered)

        _nInfected = nInfected
        _nRecovered = nRecovered
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
    Public Property Symptops(index As Integer) As String
        Get
            Return _Symtomps(index)
        End Get
        Set(value As String)
            _Symtomps(index) = value
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
    Public Property nInfected() As Integer
        Get
            Return _nInfected
        End Get
        Set(value As Integer)
            ValidateInt(value)
            _nInfected = value
        End Set
    End Property
    Public Property nRecovered() As Integer
        Get
            Return _nRecovered
        End Get
        Set(value As Integer)
            ValidateInt(value)
            _nRecovered = value
        End Set
    End Property
    Public ReadOnly Property Death_Rate() As Double 'can't change value outside the class
        Get
            Return _Death_Rate
        End Get
    End Property

    'Utility Methods
    Public Sub CalculateDeathRate()
        _Death_Rate = 1 - _nRecovered / _nInfected
    End Sub
    Public MustOverride Function WayOfGettingInfected() As String 'Implementation done in derived classes
    Public Shared Sub ValidateInt(ByRef num As Integer) 'What to change parameter value within the subroutine
        While num < 0
            num = CInt(InputBox("Please enter a postive number"))
        End While
    End Sub
    Public Sub ResizeArray(size As Integer, e As Array) 'use enumeration to determine which array to resize
        If e = Array.Symtomps Then
            ReDim _Symtomps(size)
        ElseIf e = Array.Treatments Then
            ReDim _Treatments(size)
        End If
    End Sub
End Class
