'Option statements:
Option Strict On
Option Infer Off
Option Explicit On

Public Class Malaria
    Inherits Disease
    Private _TypeOfMosquito As String
    Private _AreasAffected As Integer 'size of affected area array, number of areas that have malaria cases, comes from person details 
    Private _AreaName() As String
    Private _MalariaParasite As String

    Public Sub New()
    End Sub
    Public Sub New(Type As String, NoAreas As Integer, Parasite As String)
        _TypeOfMosquito = Type
        AreasAffected = NoAreas
        _MalariaParasite = Parasite
        ReDim _AreaName(NoAreas)
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
    Public Function HighRiskArea() As String
        'person instnace
        ' if statement if in congo, 

        Dim NumInfected() As Integer
        ReDim NumInfected(_AreasAffected)
        Dim HighRisk As Integer
        Dim HighRiskIDX As String
        NumInfected(1) = nInfected
        HighRisk = NumInfected(1)
        HighRiskIDX = _AreaName(1)
        For A As Integer = 1 To _AreasAffected
            NumInfected(A) = nInfected
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
