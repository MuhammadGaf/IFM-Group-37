' *****************************************************************
' Team Number: 37
' Team Member 1 Details: Mpiana, MK (219062231)
' Team Member 2 Details: Gaffar, M (222083957)
' Team Member 3 Details: Khumalo, LS (222049196)
' Team Member 4 Details: Dibilwane, P (222019464)
' Practical: Team Project
' Class name: Malaria
' *****************************************************************
'Option Statements
Option Strict On
Option Explicit On
Option Infer Off

Public Class Malaria
    Inherits Disease
    Private _TypeOfMosquito As String
    Private _AreasAffected As Integer 'size of affected area array, number of areas that have malaria cases, comes from person details 
    Private _AreaName() As String
    Private _MalariaParasite As String

    Public Sub New()
        'increase the number of people infected by disease
        _nInfected(DiseaseNo.Malaria) += 1
    End Sub
    Public Sub New(Type As String, NoAreas As Integer, Parasite As String)
        _TypeOfMosquito = Type
        AreasAffected = NoAreas
        _MalariaParasite = Parasite
        ReDim _AreaName(NoAreas)
        'increase the number of people infected by disease
        _nInfected(DiseaseNo.Malaria) += 1
    End Sub
    Public Property TypeOfMosquito As String
        Set(value As String)
            _TypeOfMosquito = value
        End Set
        Get
            Return _TypeOfMosquito
        End Get
    End Property
    Public Property AreaName(IDX As Integer) As String
        Set(value As String)
            _AreaName(IDX) = value
        End Set
        Get
            Return _AreaName(IDX)
        End Get
    End Property
    Public Property AreasAffected As Integer
        Set(value As Integer)
            ValidateInt(value)
            _AreasAffected = value
        End Set
        Get
            Return _AreasAffected
        End Get
    End Property

    Public Property MalariaParasite As String
        Set(value As String)
            _MalariaParasite = value
        End Set
        Get
            Return _MalariaParasite
        End Get
    End Property

    'Utilty Methods
    Public Function HighRiskArea() As String
        'person instnace
        ' if statement if in congo, 

        Dim NumInfected() As Integer
        ReDim NumInfected(_AreasAffected)
        Dim HighRisk As Integer
        Dim HighRiskIDX As String
        NumInfected(1) = nInfected(DiseaseNo.Malaria) '???????
        HighRisk = NumInfected(1)
        HighRiskIDX = _AreaName(1)
        For A As Integer = 1 To _AreasAffected
            NumInfected(A) = nInfected(DiseaseNo.Malaria)
            If NumInfected(A) >= HighRisk Then
                HighRisk = NumInfected(A)
                HighRiskIDX = _AreaName(A)
            End If
        Next A
        Return HighRiskIDX
    End Function
    Public Overrides Function WayOfGettingInfected() As String 'infected by mosquitos or other
        'Dim Ans As String
        Select Case _MalariaParasite
            Case "Plasmodium vivax"
                Return "Mosquito Bite."
            Case "P. falciparum"
                Return "Mosquito Bite."
            Case "P. malariae"
                Return "Mosquito Bite."
            Case "P. ovale"
                Return "Mosquito Bite."
            Case Else
                Return "Blood Transfusion."

        End Select
    End Function

End Class
