' *****************************************************************
' Team Number: 37
' Team Member 1 Details: Mpiana, MK (219062231)
' Team Member 2 Details: Gaffar, M (222083957)
' Team Member 3 Details: Khumalo, LS (222049196)
' Team Member 4 Details: Dibilwane, P (222019464)
' Practical: Team Project
' Class name: Form1
' *****************************************************************
'Option Statements
Option Strict On
Option Explicit On
Option Infer Off
Public Class frmPatient
    Private PatientSymptops() As String 'Array to store patient Symptomps
    Private nPatientSymptomps As Integer
    Private Country As String

    Private Sub frmPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbCountry.DropDownStyle = ComboBoxStyle.DropDownList 'lock the combobox so that the text can not be deleted/erased or modified
    End Sub

    Private Sub btnRecord_Click(sender As Object, e As EventArgs) Handles btnRecord.Click

        Country = cbCountry.Text 'get value of combo box
        MessageBox.Show(Country, "Country")

        nPatientSymptomps = clbSymptomps.CheckedItems.Count 'gives as the number of checked items
        MessageBox.Show(CStr(nPatientSymptomps), "Number of Symptops")
        ReDim PatientSymptops(nPatientSymptomps)

        'Store checked items of 

    End Sub

    Private Sub btnShowNGOForm_Click(sender As Object, e As EventArgs) Handles btnShowNGOForm.Click
        Dim frmNGO As New Form2 'declare a new form
        frmNGO.Show() 'Show form to user
    End Sub


End Class
