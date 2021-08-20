Imports Telerik.Reporting.InstanceReportSource
Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports MyReportLib
Imports System.Globalization
Public Class ReportesSIVMensual
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
            Dim ReportBookSIV As New ReportBook

            'Parámetros

            Dim ReporteSIV_Parametros As New MyReportLib.ReporteSIV_Parametros
            ReporteSIV_Parametros.Name = "Parametros"

            ReporteSIV_Parametros.ReportParameters("FechaInicial").Value = DateSerial(Year(Date.Now), Month(Date.Now), 1)
            ReporteSIV_Parametros.ReportParameters("FechaFinal").Value = DateSerial(Year(Date.Now), Month(Date.Now) + 1, 0)


            ReportBookSIV.Reports.Add(ReporteSIV_Parametros)



            ' Reporte SIV Resumen Mensual 

            Dim ResumenMes As New MyReportLib.ReporteSIV_Resumen_Mes
            ResumenMes.Name = "Resumen Mes"
            ReportBookSIV.Reports.Add(ResumenMes)

            ' M E S


            ' Reporte SIV RF MP MES
            Dim RFMPMES As New MyReportLib.ReporteSIV_Detalle_RFMPMES
            RFMPMES.Name = "RF MP MES"
            ReportBookSIV.Reports.Add(RFMPMES)

            ' Reporte SIV RF MS MES
            Dim RFMSMES As New MyReportLib.ReporteSIV_Detalle_RFMSMES
            RFMSMES.Name = "RF MS MES"
            ReportBookSIV.Reports.Add(RFMSMES)


            ' Reporte SIV MM MES
            Dim MMMES As New MyReportLib.ReporteSIV_Detalle_MMMES
            MMMES.Name = "MM MES"
            ReportBookSIV.Reports.Add(MMMES)


            ' Reporte de Operaciones RV MP Mes

            Dim RVMPMES As New MyReportLib.ReporteSIV_Detalle_RVMPMES
            RVMPMES.Name = "RV MP MES"
            ReportBookSIV.Reports.Add(RVMPMES)


            ' Reporte de Operaciones RV MS Mes

            Dim RVMSMES As New MyReportLib.ReporteSIV_Detalle_RVMSMES
            RVMSMES.Name = "RV MS MES"
            ReportBookSIV.Reports.Add(RVMSMES)








            ' Asociar ReportBook a Visor
            ReportBookSIV.DocumentName = "Reporte SIV Mensual"

            InstaciaReportSource.ReportDocument = ReportBookSIV

            ReportViewer1.ReportSource = InstaciaReportSource
            ReportViewer1.RefreshReport()



            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Reporte", "Reporte SIV", "")

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