Imports Telerik.Reporting.InstanceReportSource
Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports MyReportLib
Imports System.Globalization

Partial Class ComparativoPreciosBonos
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
            ReportBookDiario.Reports.Add(New MyReportLib.ComparativoPreciosBonos)


            ReportBookDiario.DocumentName = "PreciosVolumenesBonosMasTransados" & Format(Now(), "dd-MM-yy")
            InstaciaReportSource.ReportDocument = ReportBookDiario
            ReportViewer1.ReportSource = InstaciaReportSource
            ReportViewer1.RefreshReport()
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Reporte", "Comparativo Precios Volúmenes de Bonos Mas Transados", "")
        End If
    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 7 Then 'Mover
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../reportes/PreciosVolumenesBonosMasTransados.aspx','1000','600')</" + "script>"
        ElseIf e.Item.Value = 2 Then 'Cancelar
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
        End If
    End Sub
End Class
