Imports Telerik.Reporting.InstanceReportSource
Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports MyReportLib
Imports System.Globalization
Public Class InformacionMensual
    Inherits System.Web.UI.Page

    Dim oper As New operation

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabelImprimir.Text = ""
        InjectScriptLabel.Text = ""


        If Not IsPostBack Then

            Dim InstaciaReportSource As New InstanceReportSource
            Dim ReportBookFIABMensual As New ReportBook

            'Portada
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Portada)

            'Página(s)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_02)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_03)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_04)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_05)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_06)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_07)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_08)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_10)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_09)
            ReportBookFIABMensual.Reports.Add(New MyReportLib.FIAB_Mensual_Pagina_11)

            ReportBookFIABMensual.DocumentName = "FIAB Mensual"

            InstaciaReportSource.ReportDocument = ReportBookFIABMensual

            ReportViewer1.DocumentMapVisible = False
            ReportViewer1.ReportSource = InstaciaReportSource
            ReportViewer1.RefreshReport()

            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Reporte", "BoletinDiario", "")



        End If
    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 7 Then 'Mover

            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../reportes/FIAB/BoletinMensual/InformacionMensual.aspx','1000','600')</" + "script>"

        ElseIf e.Item.Value = 2 Then 'Cancelar
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
        End If
    End Sub

End Class