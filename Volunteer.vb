' *****************************************************************
' Team Number: 37
' Team Member 1 Details: Mpiana, MK (219062231)
' Team Member 2 Details: Gaffar, M (222083957)
' Team Member 3 Details: Khumalo, LS (222049196)
' Team Member 4 Details: Dibilwane, P (222019464)
' Practical: Team Project
' Class name: Volunteer
' *****************************************************************
'Option Statements
Option Strict On
Option Explicit On
Option Infer Off

Public Class Volunteer
    'Variables
    Private _Name As String
    Private _Country As String

    'Constructors
    Public Sub New()

    End Sub
    Public Sub New(Name As String, Country As String)
        _Name = Name
        _Country = Country
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
End Class
