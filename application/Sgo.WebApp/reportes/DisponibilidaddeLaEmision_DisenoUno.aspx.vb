Imports Telerik.Web.UI
Imports System.Globalization
Public Class DisponibilidaddeLaEmision_DisenoUno
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InjectScriptLabelImprimir.Text = ""
        InjectScriptLabel.Text = ""

        If Not IsPostBack Then

            Dim instanceReportSource As New Telerik.Reporting.InstanceReportSource()
            instanceReportSource.ReportDocument = New MyReportLib.DisponibilidaddeLaEmision

            instanceReportSource.ReportDocument.DocumentName = "Disponibilidad de la Emisión (Fideicomiso, Fondos y Titularizado)"

            ReportViewer1.ReportSource = instanceReportSource
            ReportViewer1.RefreshReport()

        End If

    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 7 Then 'Mover
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../reportes/DisponibilidaddeLaEmision_DisenoUno.aspx','1000','600')</" + "script>"
        ElseIf e.Item.Value = 2 Then 'Cancelar
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
        End If

    End Sub




End Class