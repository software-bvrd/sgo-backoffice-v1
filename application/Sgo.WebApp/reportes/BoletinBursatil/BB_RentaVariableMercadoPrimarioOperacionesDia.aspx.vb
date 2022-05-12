Imports Telerik.Reporting.InstanceReportSource
Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports MyReportLib
Imports System.Globalization

Public Class BB_RentaVariableMercadoPrimarioOperacionesDia
    Inherits System.Web.UI.Page
    Dim oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InjectScriptLabelImprimir.Text = ""
        InjectScriptLabel.Text = ""
        If Not IsPostBack Then
            Dim InstaciaReportSource As New InstanceReportSource
            Dim ReportBookDiario As New ReportBook
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVMPOperDia)

            ReportBookDiario.DocumentName = "BB_RentaVariableMercadoPrimarioOperacionesDia" & Format(Now(), "dd-MM-yy")
            InstaciaReportSource.ReportDocument = ReportBookDiario
            ReportViewer1.ReportSource = InstaciaReportSource
            ReportViewer1.RefreshReport()
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Reporte", "BB - Lista de Registro de Operaciones del dia Mercado Primario", "")

        End If

    End Sub

End Class