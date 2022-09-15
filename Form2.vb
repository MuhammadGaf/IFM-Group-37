' *****************************************************************
' Team Number: 37
' Team Member 1 Details: Mpiana, MK (219062231)
' Team Member 2 Details: Gaffar, M (222083957)
' Team Member 3 Details: Khumalo, LS (222049196)
' Team Member 4 Details: Dibilwane, P (222019464)
' Practical: Team Project
' Class name: Form2
' *****************************************************************
'Option Statements
Option Strict On
Option Explicit On
Option Infer Off

Public Class frmNGO
    Inherits System.Windows.Forms.Form
    Public myCaller As frmPatient
    Public Sub AssignVolunteer()

    End Sub
    Private Sub frmNGO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbCountry.DropDownStyle = ComboBoxStyle.DropDownList 'lock the combobox so that the text can not be deleted/erased or modified
        'myCaller.nPersons
    End Sub

End Class