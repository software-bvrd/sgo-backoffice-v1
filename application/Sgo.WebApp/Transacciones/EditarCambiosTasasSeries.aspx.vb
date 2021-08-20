Imports System.Data
Imports System.Globalization

Partial Class Transacciones_EditarCambiosTasasSeries
    Inherits System.Web.UI.Page


    Private oper As New operation

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("EmisionSerieCalendarioCambioTasasID")
            End If


            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            Else
                txtFecha.DbSelectedDate = Today.Date
            End If

            RadComboBoxEmisorID.Focus()
        End If




    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar

            If ViewState("EsNuevo") = True Then
                Call Nuevo()
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Actualizar()
            End If

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

    Sub Nuevo()
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        If ViewState("EsNuevo") = True Then

            oper.ExecuteNonQuery("INSERT INTO EmisionSerieCalendarioCambioTasas ([EmisorID],[EmisionID],[EmisionSerieID],[Fecha],[FechaStart],[Tasa],[Description]) VALUES ('" _
                                 & Me.RadComboBoxEmisorID.SelectedValue & "','" & Me.RadComboBoxEmisionID.SelectedValue & "','" _
                                 & Me.RadComboBoxEmisionSerie.SelectedValue & "','" & txtFecha.SelectedDate.ToString & "','" _
                                 & txtFecha.SelectedDate.ToString & "'," _
                                 & txtTasa.Text & ",'" & txtDescripcion.Text & "')")
        End If


        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat


    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [EmisionSerieCalendarioCambioTasas]  where EmisionSerieCalendarioCambioTasasID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow

        Try
            For Each MyRow In ds.Tables(0).Rows

                If Not IsDBNull(MyRow.Item("EmisorID")) Then Me.RadComboBoxEmisorID.SelectedValue = Trim(MyRow.Item("EmisorID"))
                If Not IsDBNull(MyRow.Item("EmisionID")) Then Me.RadComboBoxEmisionID.SelectedValue = Trim(MyRow.Item("EmisionID"))
                If Not IsDBNull(MyRow.Item("EmisionSerieID")) Then Me.RadComboBoxEmisionSerie.SelectedValue = Trim(MyRow.Item("EmisionSerieID"))
                If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFecha.SelectedDate = Trim(MyRow.Item("Fecha"))
                If Not IsDBNull(MyRow.Item("Tasa")) Then Me.txtTasa.Text = Trim(MyRow.Item("Tasa"))
                If Not IsDBNull(MyRow.Item("Description")) Then Me.txtDescripcion.Text = Trim(MyRow.Item("Description"))

            Next

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
        End Try

    End Sub
    Sub Actualizar()

        Dim cStringSQL As String = ""
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        Try

            ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            cStringSQL = "Update [EmisionSerieCalendarioCambioTasas] set EmisorID = '" & Me.RadComboBoxEmisorID.SelectedValue &
                                                                         "', Tasa=" & txtTasa.Text & ", Description ='" &
                                                                                      txtDescripcion.Text & "'  where EmisionSerieCalendarioCambioTasasID='" & CInt(ViewState("Code")) & "'"
            oper.ExecuteNonQuery(cStringSQL)

            ViewState("EsNuevo") = False

            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat


        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
