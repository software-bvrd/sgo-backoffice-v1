Imports Telerik.Reporting.InstanceReportSource
Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports MyReportLib
Imports System.Globalization

Partial Class MK_BoletinDiario
    Inherits System.Web.UI.Page
    Dim oper As New operation
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InjectScriptLabelImprimir.Text = ""
        InjectScriptLabel.Text = ""
        If Not IsPostBack Then
            Dim InstaciaReportSource As New InstanceReportSource
            Dim ReportBookDiario As New ReportBook
            ReportBookDiario.Reports.Add(New MyReportLib.MK_BoletinPortada)
            ReportBookDiario.Reports.Add(New MyReportLib.MK_ResumenDiario)
            ReportBookDiario.Reports.Add(New MyReportLib.MK_MontosNegociadosInstrumentos)
            ReportBookDiario.Reports.Add(New MyReportLib.MK_MontosTransadosParticipantesInstrumentos)
            ReportBookDiario.Reports.Add(New MyReportLib.MK_CantidadOperacionesParticipante)
            ReportBookDiario.Reports.Add(New MyReportLib.MK_ValorTransadoOperacionesParticipante)
            ReportBookDiario.Reports.Add(New MyReportLib.MK_PreciosUltimoMejorPeor)
            ReportBookDiario.Reports.Add(New MyReportLib.MK_MontosTransadosParticipanteInstrumentosMonedaEmision)
            ReportBookDiario.Reports.Add(New MyReportLib.MK_OperacionesDiarias)
            ReportBookDiario.Reports.Add(New MyReportLib.MK_TitulosMasTransados)

            ReportBookDiario.DocumentName = "BDMM BO2 " & Format(Now(), "dd-MM-yy")
            InstaciaReportSource.ReportDocument = ReportBookDiario
            ReportViewer1.ReportSource = InstaciaReportSource
            ReportViewer1.RefreshReport()
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Reporte", "BoletinDiarioMK", "")
        End If
    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 7 Then 'Mover
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../reportes/BoletinDiario.aspx','1000','600')</" + "script>"
        ElseIf e.Item.Value = 2 Then 'Cancelar
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
        End If
    End Sub
End Class
