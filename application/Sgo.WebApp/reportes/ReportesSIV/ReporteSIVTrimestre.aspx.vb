Imports Telerik.Reporting.InstanceReportSource
Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports MyReportLib
Imports System.Globalization
Public Class ReporteSIVTrimestre
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


            ' Reporte SIV Resumen Trimestre 
            Dim ResumenMes_Trim As New MyReportLib.ReporteSIV_Resumen
            ResumenMes_Trim.Name = "Resumen Mes-Trim"

            ResumenMes_Trim.ReportParameters("FechaInicial").Value = DateSerial(Year(Date.Now), Month(Date.Now), 1)
            ResumenMes_Trim.ReportParameters("FechaFinal").Value = DateSerial(Year(Date.Now), Month(Date.Now) + 1, 0)
            ResumenMes_Trim.ReportParameters("Periodo").Value = "T"


            ReportBookSIV.Reports.Add(ResumenMes_Trim)




            ' T R I M E S T R E 

            ' Reporte SIV RF MP TRIMESTRE
            Dim RFMPTrimestre As New MyReportLib.ReporteSIV_Detalle_RFMPTrimestre
            RFMPTrimestre.Name = "RF MP Trimestre"
            ReportBookSIV.Reports.Add(RFMPTrimestre)

            ' Reporte SIV RF MS TRIMESTRE
            Dim RFMSTrimestre As New MyReportLib.ReporteSIV_Detalle_RFMSTrimestre
            RFMSTrimestre.Name = "RF MS RFMSTrimestre"
            ReportBookSIV.Reports.Add(RFMSTrimestre)


            ' Reporte SIV MM TRIMESTRE
            Dim MMTrimestre As New MyReportLib.ReporteSIV_Detalle_MMTrimestre
            MMTrimestre.Name = "MM Trimestre"
            ReportBookSIV.Reports.Add(MMTrimestre)


            ' Reporte de Operaciones RV MP TRIMESTRE

            Dim RVMPTrimestre As New MyReportLib.ReporteSIV_Detalle_RVMPTrimestre
            RVMPTrimestre.Name = "RV MP Trimestre"
            ReportBookSIV.Reports.Add(RVMPTrimestre)


            ' Reporte de Operaciones RV MS TRIMESTRE

            Dim RVMSTrimestre As New MyReportLib.ReporteSIV_Detalle_RVMSTrimestre
            RVMSTrimestre.Name = "RV MS Trimestre"
            ReportBookSIV.Reports.Add(RVMSTrimestre)




            ' Asociar ReportBook a Visor
            ReportBookSIV.DocumentName = "Reporte SIV"

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