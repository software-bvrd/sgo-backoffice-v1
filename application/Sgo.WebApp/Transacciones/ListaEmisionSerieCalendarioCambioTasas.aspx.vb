Imports System.Globalization
Imports Telerik.Web.UI


Partial Class Transacciones_ListaEmisionSerieCalendarioCambioTasas

    Inherits System.Web.UI.Page
    Private oper As New operation
    Private Const AppointmentsLimit As Integer = 1
    Dim IDPrint As Integer
 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim newCulture As CultureInfo = CultureInfo.CreateSpecificCulture("es-DO")
            RadScheduler1.Culture = newCulture

        End If

    End Sub
    Protected Function ExceedsLimit(ByVal apt As Appointment) As Boolean
        Dim appointmentsCount As Integer = RadScheduler1.Appointments.GetAppointmentsInRange(apt.Start, apt.End).Count
        Return (appointmentsCount > (AppointmentsLimit - 1))
    End Function
    Protected Sub RadScheduler1_AppointmentUpdate(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentUpdateEventArgs) Handles RadScheduler1.AppointmentUpdate
        If ExceedsLimit(e.ModifiedAppointment) Then
            For Each a As Appointment In RadScheduler1.Appointments.GetAppointmentsInRange(e.ModifiedAppointment.Start, e.ModifiedAppointment.[End])
                If Val(a.ID) <> e.Appointment.ID Then
                    e.Cancel = True
                End If
            Next
        End If
    End Sub
    Protected Sub RadScheduler1_AppointmentDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerEventArgs) Handles RadScheduler1.AppointmentDataBound

        If e.Appointment.Resources.GetResourceByType("Estatus") <> Nothing Then
            Select Case e.Appointment.Resources.GetResourceByType("Estatus").Text
                Case "Realizada"
                    e.Appointment.CssClass = "rsCategoryGreen " + e.Appointment.Subject
                    Exit Select
                Case "Cancelada"
                    e.Appointment.CssClass = "rsCategoryRed " + e.Appointment.Subject
                    Exit Select
                Case "Pendiente"
                    e.Appointment.CssClass = "rsCategoryYellow " + e.Appointment.Subject
                    Exit Select
                Case Else
                    Exit Select
            End Select
        End If


    End Sub
 


    Protected Sub RadScheduler1_AppointmentContextMenuItemClicked(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentContextMenuItemClickedEventArgs) Handles RadScheduler1.AppointmentContextMenuItemClicked

        If e.MenuItem.Value = "CommandPrint" Then
            'Session("ReportFile") = "CitaTicket.rpt"
            'IDPrint = Val(e.Appointment.ID)
            'Session("sqlString") = "Select *  from vAppointmentsReport where Id=" & IDPrint & "  "
            ''Session("sqlString") = "Select *  from vAppointmentsReport where Id='" & e.Appointment.ID & "'  "

            'Dim MyWindow As New Telerik.Web.UI.RadWindow
            'MyWindow.NavigateUrl = "ViewReports.aspx"
            'MyWindow.VisibleOnPageLoad = True
            'RadWindowManager1.Windows.Add(MyWindow)

            '' MsgBox("Nitido")
            '' CitaTicket()
        End If
        
        If e.MenuItem.Value = "Editar" Then

            Session("NewUrlParent") = "ListaEmisionSerieCalendarioCambioTasas.aspx"
            Session("EsNuevo") = False

            Dim MyWindow As New Telerik.Web.UI.RadWindow
            '   MyWindow.ID  = "01"

            MyWindow.Title = "Modificación de Citas"
            'If e.Appointment.ID > 0 Then

            MyWindow.NavigateUrl = "EditarEmisionSerieCalendarioCambioTasas.aspx?Cod=" & e.Appointment.ID & " "
            'Else
            '    Session("Nuevo") = True
            'End If
            MyWindow.VisibleOnPageLoad = True
            Me.RadWindowManager1.Windows.Add(MyWindow)
        End If

        If e.MenuItem.Value = "BR" Then
            oper.ExecuteNonQuery("DELETE FROM  EmisionSerieCalendarioCambioTasas WHERE EmisionSerieCalendarioCambioTasasID='" & e.Appointment.ID & "' ")

            Me.RadScheduler1.Rebind()
        End If
    End Sub

    Protected Sub SqlEmisionSerieCalendarioCambioTasas_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlEmisionSerieCalendarioCambioTasas.Selecting
        e.Command.Parameters("@RangeStart").Value = RadScheduler1.VisibleRangeStart
        e.Command.Parameters("@RangeEnd").Value = RadScheduler1.VisibleRangeEnd

    End Sub

    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Nuevo

            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "EditarEmisionSerieCalendarioCambioTasas.aspx?EsNuevo=" & True
            MyWindow.VisibleOnPageLoad = True
            MyWindow.AutoSize = True

            RadWindowManager1.Windows.Clear()
            RadWindowManager1.Windows.Add(MyWindow)

        ElseIf e.Item.Value = 1 Then  ' Borrar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If


       
    End Sub
End Class
