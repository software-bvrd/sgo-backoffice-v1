Imports System.Globalization
Imports Telerik.Reporting
Imports Telerik.Web.UI
Public Class ReportedeOperacionesMPyMSFechas
    Inherits System.Web.UI.Page

    Dim oper As New operation

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub

    ''' <summary>
    ''' Reporte de Operaciones MP y MS Rango de Fechas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InjectScriptLabelImprimir.Text = ""
        InjectScriptLabel.Text = ""


        If Not IsPostBack Then
            Dim InstaciaReportSource As New InstanceReportSource
            Dim ReportBookReporteOperaciones As New ReportBook

            ' MP
            ReportBookReporteOperaciones.Reports.Add(New MyReportLib.OperacionesMercadoPrimarioFechas)
            ' MS
            ReportBookReporteOperaciones.Reports.Add(New MyReportLib.OperacionesMercadoSecundarioFechas)


            ReportBookReporteOperaciones.DocumentName = "ReporteOperacionesMPMS"

            InstaciaReportSource.ReportDocument = ReportBookReporteOperaciones

            ReportViewer1.ReportSource = InstaciaReportSource
            ReportViewer1.RefreshReport()

            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Reporte", "Reporte de Operaciones MP y MS Fechas", "")


        End If

    End Sub





End Class