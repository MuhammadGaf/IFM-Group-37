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
    'Variables
    Public nPersons As Integer = 0 'initialise to zero
    Private Persons() As Person 'declare an instance of type person

    Private PatientSymptomps As New List(Of String) 'Array to store patient Symptomps
    'Utility Methods
    Private Sub PIG(r As Integer, c As Integer, t As String)
        grdPatients.Row = r
        grdPatients.Col = c
        grdPatients.Text = t
    End Sub
    Private Sub SizeLabel(nRows As Integer)
        'Size
        grdPatients.Cols = 3 ' Number and Name + State
        grdPatients.Rows = 1 + nRows 'label + Patient details
        'Label
        PIG(0, 0, "Number")
        PIG(0, 1, "Name")
        PIG(0, 2, "State")
    End Sub
    'Events
    Private Sub frmPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbCountry.DropDownStyle = ComboBoxStyle.DropDownList 'lock the combobox so that the text can not be deleted/erased or modified
        ReDim Persons(0)
        SizeLabel(0)
    End Sub

    Private Sub DetermineIllness()
        For i As Integer = 0 To clbSymptoms.Items.Count - 1 'iterate through each item
            'We ask if this item is checked or not
            If clbSymptoms.GetItemChecked(i) Then
                'Store checked items
                PatientSymptomps.Add(clbSymptoms.Items(i).ToString) 'Add item to our list, populates array from index zero
                Persons(nPersons).Symptoms.Add(clbSymptoms.Items(i).ToString)
            End If
        Next i

        Persons(nPersons).DetermineInfection() ' calls determine infection function
        txtIllness.Text = Persons(nPersons).Illness.Name
        PIG(nPersons, 2, Persons(nPersons).State.ToString & " with " & Persons(nPersons).Illness.Name)
    End Sub

    Private Sub btnRecord_Click(sender As Object, e As EventArgs) Handles btnRecord.Click
        nPersons += 1
        SizeLabel(nPersons) 'increase grid rows
        'dynamically change size of array
        If Persons.Length = nPersons Then '.Length includes array position zero which we don't populate
            ReDim Preserve Persons(nPersons * 2) 'Resize array 
        End If

        Dim objPerson As Person
        objPerson = New Person() 'Instantiate Object
        objPerson.Name = txtFirstName.Text + " " + txtSurname.Text
        objPerson.Age = CInt(txtAge.Text)
        objPerson.Country = cbCountry.Text
        objPerson.State = Status.Infected 'Use of enumeration
        PIG(nPersons, 0, CStr(nPersons)) 'display patient number
        PIG(nPersons, 1, objPerson.Name)
        PIG(nPersons, 2, objPerson.State.ToString)

        Persons(nPersons) = objPerson 'Populate Array

        DetermineIllness()

        'Next
    End Sub

    'Reset values
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtFirstName.Text = Nothing
        txtSurname.Text = Nothing
        txtAge.Text = Nothing
        cbCountry.Text = Nothing
        txtIllness.Text = Nothing
        ' uncheck checklistbox
        For i As Integer = 0 To clbSymptoms.Items.Count - 1
            clbSymptoms.SetItemChecked(i, False)
        Next
    End Sub

    'Update person state from infected to recovered or dead
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim PatientNo As Integer
        Dim state As Status
        PatientNo = CInt(InputBox("What is Patient Number?"))

        state = CType(InputBox("What is the State of the Patient?" & vbNewLine & "Type #" & vbNewLine & "1 Recovered" & vbNewLine & "2 Deceased"), Status) 'Convert input to Status

        If TypeOf Persons(PatientNo).Illness Is HIVAIDS And state = Status.Recovered Then
            MessageBox.Show("Patient can't recover from HIV/AIDS as there is no cure as of now")
        Else
            Persons(PatientNo).State = state
            'Update UJGrid Patient State
            PIG(PatientNo, 2, Persons(PatientNo).State.ToString)
        End If

        'increase number of dead
        If Persons(PatientNo).State = Status.Deceased Then
            If TypeOf Persons(PatientNo).Illness Is Malaria Then
                Disease.nDead(CInt(DiseaseNo.Malaria)) += 1
            Else 'not malaria i.e HIVAIDS
                Disease.nDead(CInt(DiseaseNo.HIVAIDS)) += 1
            End If
        End If

    End Sub

    Private Sub btnShowNGOForm_Click(sender As Object, e As EventArgs) Handles btnShowNGOForm.Click
        Dim frmNGO As New frmNGO 'declare a new form
        frmNGO.myCaller = Me 'allows forms to communicate
        frmNGO.Show() 'Show form to user
    End Sub

    Private Sub btnWay_Click(sender As Object, e As EventArgs) Handles btnWay.Click
        Dim PatientNo As Integer
        PatientNo = CInt(InputBox("What is Patient Number?"))
        'If TypeOf Persons(PatientNo).Illness Is Malaria Then
        'End If
        MessageBox.Show(Persons(PatientNo).Illness.WayOfGettingInfected(), "Way of getting Infected")
    End Sub
End Class
