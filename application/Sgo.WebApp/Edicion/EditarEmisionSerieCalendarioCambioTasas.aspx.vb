Imports System.Data
Imports System.Data.Sqlclient
'Imports ThePhoenixLibrary
Imports System.IO
Imports Telerik.Web.UI

Partial Class EditarEmisionSerieCalendarioCambioTasas
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            'Me.RadDateTimePicker1.MinDate = Now.Date
            'Me.RadDateTimePicker2.MinDate = Now.Date

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            If ViewState("EsNuevo") = False Then
                ViewState("EmisionSerieCalendarioCambioTasasID") = Request.QueryString("Cod")
                Me.RadComboBoxEmisionSerie.Enabled = False
                Call Editar()
            End If


        End If

    End Sub
    Sub Editar()
        'On Error Resume Next
        'Dim sql As String = "SELECT * FROM vAppointments where ID=" & ViewState("CodigoCita") & ""
        Dim sql As String = "SELECT * FROM vEmisionSerieCalendarioCambioTasas where EmisionSerieCalendarioCambioTasasID=" & ViewState("EmisionSerieCalendarioCambioTasasID") & ""
        Dim ds As DataSet = oper.ExDataSet(sql)
        If oper.CheckDataSet(ds) Then
            Dim MyRow As DataRow
            For Each MyRow In ds.Tables(0).Rows


                If Not IsDBNull(MyRow.Item("Tasa")) Then Me.Tasa.Text = MyRow.Item("Tasa")
                'If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = MyRow.Item("Activo")

                If Not IsDBNull(MyRow.Item("FechaStart")) Then Me.RadDateTimePickerFechaStart.DbSelectedDate = MyRow.Item("FechaStart")
                'If Not IsDBNull(MyRow.Item("FechaEnd")) Then Me.FechaEnd.Text = MyRow.Item("FechaEnd")
             
                If Not IsDBNull(MyRow.Item("Description")) Then Me.Description.Text = MyRow.Item("Description")
                If Not IsDBNull(MyRow.Item("Subject")) Then Me.Subject.Text = MyRow.Item("Subject")
 
                Dim FechaInicio As String = DateAdd(DateInterval.Minute, +0, MyRow.Item("FechaStart"))
                'Dim FechaFin As String = DateAdd(DateInterval.Minute, +1, MyRow.Item("FechaFin"))

                If Not IsDBNull(MyRow.Item("EmisionSerieID")) Then Me.RadComboBoxEmisionSerie.SelectedValue = Trim(MyRow.Item("EmisionSerieID"))
                If Not IsDBNull(MyRow.Item("StatusId")) Then Me.RadComboBoxStatus.SelectedValue = Trim(MyRow.Item("StatusId"))
 




            Next
        End If

    End Sub
    

    'Protected Sub RadComboBox1_ItemsRequested(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxEmisionSerie.ItemsRequested

    '    Dim sql As String = "SELECT   DISTINCT TOP (100) PERCENT CitizenId,  (CitizenName + ' ' + CitizeMiddleName + ' '+ isnull(CitizenLastName,''))    as CitizenFullName,IdentificationNumber FROM   vCitizens WHERE TipoSolicitanteId=1 and HomeCityCode='" & Session("CityCode") & "' and CitizenName + ' ' + isnull(CitizenLastName,'') LIKE N'%" + e.Context("CustomText").ToString() + "%' ORDER BY CitizenFullName "

    '    Dim adapter As New SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings("CN").ConnectionString)
    '    Dim data As New DataTable()
    '    adapter.Fill(data)

    '    Try

    '        Dim itemsPerRequest As Integer = 10
    '        Dim itemOffset As Integer = e.NumberOfItems
    '        Dim endOffset As Integer = itemOffset + itemsPerRequest
    '        If endOffset > data.Rows.Count Then
    '            endOffset = data.Rows.Count
    '        End If

    '        If endOffset = data.Rows.Count Then
    '            e.EndOfItems = True
    '        End If
    '        Dim i As Integer = itemOffset
    '        RadComboBoxEmisionSerie.Items.Clear()
    '        While i < endOffset
    '            RadComboBoxEmisionSerie.Items.Add(New RadComboBoxItem(data.Rows(i)("CitizenFullName").ToString(), data.Rows(i)("CitizenId").ToString()))
    '            i = i + 1
    '        End While

    '        If data.Rows.Count > 0 Then
    '            e.Message = [String].Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", endOffset.ToString(), data.Rows.Count.ToString())
    '        Else
    '            e.Message = "No encontrado"
    '        End If
    '    Catch
    '        e.Message = "No encontrado"
    '    End Try
    'End Sub

    Sub Insert()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try

            Dim Sql As String = "INSERT INTO  EmisionSerieCalendarioCambioTasas ([EmisionSerieID]  " &
           ",[Tasa] " &
           ",[StatusId] " &
           ",[FechaStart]" &
           ",[FechaEnd]" &
           ",[Subject]" &
           ",[Description]" &
           ",[RecurrenceRule]" &
           ",[RecurrenceParentID]" &
           ",[Reminder]) VALUES(@EmisionSerieID, @Tasa " &
           ",@StatusId " &
           ",@FechaStart" &
           ",@FechaEnd" &
           ",@Subject" &
           ",@Description" &
           ",@RecurrenceRule" &
           ",@RecurrenceParentID " &
           ",@Reminder)"



            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            'Dim Check As String

            'Check = CheckBox1.Checked


            cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmisionSerie.Text.Length > 0, Me.RadComboBoxEmisionSerie.SelectedValue, DBNull.Value)


            cmd.Parameters.Add(New SqlParameter("@Tasa", SqlDbType.BigInt)).Value = IIf(Tasa.Text.Length > 0, Tasa.Text, DBNull.Value)
            'cmd.Parameters.Add(New SqlParameter("@", SqlDbType.Bit)).Value = Check
            cmd.Parameters.Add(New SqlParameter("@StatusId", SqlDbType.NVarChar)).Value = IIf(Me.RadComboBoxStatus.Text.Length > 0, Me.RadComboBoxStatus.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@FechaStart", SqlDbType.DateTime)).Value = IIf(RadDateTimePickerFechaStart.IsEmpty = False, RadDateTimePickerFechaStart.DbSelectedDate, DBNull.Value)
            'cmd.Parameters.Add(New SqlParameter("@FechaEnd", SqlDbType.DateTime)).Value = RadDateTimePickerFechaStart.DbSelectedDate
            Dim FechaFin As String = DateAdd(DateInterval.Minute, +60, RadDateTimePickerFechaStart.DbSelectedDate)
            cmd.Parameters.Add(New SqlParameter("@FechaEnd", SqlDbType.NVarChar)).Value = IIf(RadDateTimePickerFechaStart.IsEmpty = False, FechaFin, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Subject", SqlDbType.NVarChar)).Value = IIf(Subject.Text.Length > 0, Subject.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar)).Value = IIf(Description.Text.Length > 0, Description.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RecurrenceRule", SqlDbType.NVarChar)).Value = 1
            cmd.Parameters.Add(New SqlParameter("@RecurrenceParentID", SqlDbType.BigInt)).Value = 1
            cmd.Parameters.Add(New SqlParameter("@Reminder", SqlDbType.BigInt)).Value = 1


            cmd.ExecuteNonQuery()

        Catch ex As Exception

        Finally
            Cnx.Close()
        End Try
    End Sub
  
    Sub Update()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            'Call prc_ConvertFileToBinary()


            '           Dim Sql As String = "UPDATE EmisionSerieCalendarioCambioTasas  SET [EmisionSerieID] = @EmisionSerieID,[Tasa] = @Tasa,[StatusId] = @StatusId,[FechaStart] = @FechaStart " &
            '",[FechaEnd] = @FechaEnd,[Subject] = @Subject,[Description] = @Description,[RecurrenceRule] = @RecurrenceRule,[RecurrenceParentID] = @RecurrenceParentID,[Reminder] = @Reminder where [EmisionSerieCalendarioCambioTasasID] = @EmisionSerieCalendarioCambioTasasID"

            Dim Sql As String = "UPDATE EmisionSerieCalendarioCambioTasas  SET [Tasa] = @Tasa,[StatusId] = @StatusId,[FechaStart] = @FechaStart " &
",[FechaEnd] = @FechaEnd,[Subject] = @Subject,[Description] = @Description,[RecurrenceRule] = @RecurrenceRule,[RecurrenceParentID] = @RecurrenceParentID,[Reminder] = @Reminder where [EmisionSerieCalendarioCambioTasasID] = @EmisionSerieCalendarioCambioTasasID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieCalendarioCambioTasasID", SqlDbType.BigInt)).Value = ViewState("EmisionSerieCalendarioCambioTasasID")
            'cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmisionSerie.Text.Length > 0, Me.RadComboBoxEmisionSerie.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Tasa", SqlDbType.BigInt)).Value = IIf(Tasa.Text.Length > 0, Tasa.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@StatusId", SqlDbType.NVarChar)).Value = IIf(Me.RadComboBoxStatus.Text.Length > 0, Me.RadComboBoxStatus.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@FechaStart", SqlDbType.DateTime)).Value = IIf(RadDateTimePickerFechaStart.IsEmpty = False, RadDateTimePickerFechaStart.DbSelectedDate, DBNull.Value)

            Dim FechaFin As String = DateAdd(DateInterval.Minute, +60, RadDateTimePickerFechaStart.DbSelectedDate)
            cmd.Parameters.Add(New SqlParameter("@FechaEnd", SqlDbType.DateTime)).Value = IIf(RadDateTimePickerFechaStart.IsEmpty = False, FechaFin, DBNull.Value)

            'cmd.Parameters.Add(New SqlParameter("@FechaEnd", SqlDbType.DateTime)).Value = RadDateTimePickerFechaStart.DbSelectedDate
            cmd.Parameters.Add(New SqlParameter("@Subject", SqlDbType.NVarChar)).Value = IIf(Subject.Text.Length > 0, Subject.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar)).Value = IIf(Description.Text.Length > 0, Description.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RecurrenceRule", SqlDbType.NVarChar)).Value = 1
            cmd.Parameters.Add(New SqlParameter("@RecurrenceParentID", SqlDbType.BigInt)).Value = 1
            cmd.Parameters.Add(New SqlParameter("@Reminder", SqlDbType.BigInt)).Value = 1

            cmd.ExecuteNonQuery()



        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                'ValidatorFechaPuestoBolsa.ErrorMessage = "Registro no pudo ser actualizado."
                'ValidatorFechaPuestoBolsa.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
            'Response.Redirect("EsperaAlcaldia.aspx?Fecha=" & RadDateFecha.DbSelectedDate.ToString)
        End Try
    End Sub

        'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        '    If TextBox2.Text.Length <= 0 And Me.RadComboBox1.Text.Length <= 0 And Me.RadComboBox2.Text.Length <= 0 Then
    '        RequiredFieldValidator8.ErrorMessage = "Ciudadano ó Organización"
    '        RequiredFieldValidator8.IsValid = False
    '        ValidationSummary1.Visible = True
    '        Exit Sub

    '    End If
    '    'If TextBox2.Text.Length <= 0 And Me.RadComboBox2.Text.Length > 0 And Me.RadComboBox2.Text.Length <= 0 Then
    '    '    RequiredFieldValidator8.ErrorMessage = "Nombre..."
    '    '    RequiredFieldValidator8.IsValid = False
    '    '    ValidationSummary1.Visible = True
    '    '    Exit Sub
    '    'End If



    '    If Me.RadDateTimePicker1.DbSelectedDate >= Me.RadDateTimePicker2.DbSelectedDate Then
    '        RequiredFieldValidator2.ErrorMessage = "Fecha Fin debe ser mayor o igual a Fecha Inicio"
    '        RequiredFieldValidator2.IsValid = False
    '        ValidationSummary1.Visible = True
    '        Exit Sub
    '    End If

    '    If Session("EsNuevo") = True Then

    '        Dim SSN As String = oper.ExecuteScalar("SELECT * FROM vAppointments where FechaFin BETWEEN '" & Me.RadDateTimePicker1.DbSelectedDate & "' AND '" & Me.RadDateTimePicker2.DbSelectedDate & "'  ")
    '        If SSN <> "" Then
    '            RequiredFieldValidator1.ErrorMessage = "Existe cita para este rango de fecha y hora"
    '            RequiredFieldValidator1.IsValid = False
    '            ValidationSummary1.Visible = True
    '            Exit Sub
    '        End If

    '        Dim SSNDO As String = oper.ExecuteScalar("SELECT * FROM vAppointments where  Start BETWEEN '" & Me.RadDateTimePicker1.DbSelectedDate & "' AND '" & Me.RadDateTimePicker2.DbSelectedDate & "'  ")
    '        If SSNDO <> "" Then
    '            RequiredFieldValidator2.ErrorMessage = "Existe cita para este rango de fecha y hora"
    '            RequiredFieldValidator2.IsValid = False
    '            ValidationSummary1.Visible = True
    '            Exit Sub
    '        End If


    '        Dim DiferenciaEntreFecha As Integer = DateDiff(DateInterval.Day, Me.RadDateTimePicker1.DbSelectedDate, Now.Date)

    '        If DiferenciaEntreFecha > 0 Then
    '            RequiredFieldValidator1.ErrorMessage = "No puede crear citas a fechas anteriores"
    '            RequiredFieldValidator1.IsValid = False
    '            ValidationSummary1.Visible = True
    '            Exit Sub
    '        End If




    '        Call Insert()
    '    Else

    '        Dim FechaFin As String = DateAdd(DateInterval.Minute, -1, Me.RadDateTimePicker2.DbSelectedDate)

    '        Dim SSND As String = oper.ExecuteScalar("SELECT * FROM vAppointments where ID <> " & ViewState("CodigoCita") & " and FechaFin BETWEEN '" & Me.RadDateTimePicker1.DbSelectedDate & "' AND '" & FechaFin & "'  ")
    '        If SSND <> "" Then
    '            RequiredFieldValidator1.ErrorMessage = "Existe cita para este rango de fecha y hora"
    '            RequiredFieldValidator1.IsValid = False
    '            ValidationSummary1.Visible = True
    '            Exit Sub
    '        End If

    '        Dim SSNDO As String = oper.ExecuteScalar("SELECT * FROM vAppointments where ID <> " & ViewState("CodigoCita") & " and Start BETWEEN '" & Me.RadDateTimePicker1.DbSelectedDate & "' AND '" & FechaFin & "'  ")
    '        If SSNDO <> "" Then
    '            RequiredFieldValidator2.ErrorMessage = "Existe cita para este rango de fecha y hora"
    '            RequiredFieldValidator2.IsValid = False
    '            ValidationSummary1.Visible = True
    '            Exit Sub
    '        End If


    '        Call Update()
    '    End If
    '    InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
    '    InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

    'End Sub

    'Protected Sub RadComboBox1_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBox1.SelectedIndexChanged
    '    If Me.RadComboBox1.Text.Length > 0 Then
    '        Me.RadComboBox2.SelectedValue = 0

    '        RadComboBox2.Items.Clear()
    '        Me.RadComboBox2.Enabled = False
    '        RequiredFieldValidator4.Enabled = False
    '        'RequiredFieldValidator6.Enabled = False
    '    Else

    '        Me.RadComboBox1.Items.Clear()
    '        RadComboBox2.Enabled = True
    '        'RequiredFieldValidator4.Enabled = True
    '    End If
    'End Sub

    'Protected Sub RadComboBox2_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBox2.SelectedIndexChanged
    '    If Me.RadComboBox2.Text.Length > 0 Then
    '        Me.RadComboBox1.SelectedValue = 0
    '        RadComboBox1.Items.Clear()
    '        Me.RadComboBox1.Enabled = False
    '        RequiredFieldValidator4.Enabled = True
    '        'RequiredFieldValidator6.Enabled = False
    '    Else

    '        Me.RadComboBox2.Items.Clear()
    '        Me.RadComboBox1.Enabled = True
    '        'RequiredFieldValidator4.Enabled = True
    '    End If
    'End Sub

 

    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar
            If ViewState("EsNuevo") = True Then
                Insert()
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            Else
                Update()
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            End If

        ElseIf e.Item.Value = 1 Then  ' Borrar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If
    End Sub
End Class
