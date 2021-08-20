Imports Telerik.Reporting.InstanceReportSource
Imports Telerik.Web.UI
Imports Telerik.Reporting
Imports MyReportLib
Imports System.Globalization
Public Class ReportONETotal
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
            Dim ReportBookONE As New ReportBook


      
            'Aviso + Portada
            ReportBookONE.Reports.Add(New MyReportLib.RO_Aviso)
            ReportBookONE.Reports.Add(New MyReportLib.RO_Portada)
           

            'Operaciones de Renta Fija
            ReportBookONE.Reports.Add(New MyReportLib.RO_OperacionesRentaFija)
           
                  
            'Instrumentos negociados
            ReportBookONE.Reports.Add(New MyReportLib.RO_InstrumentosNegociados)
       
                     
            'Operaciones por entidades Emisoras
            ReportBookONE.Reports.Add(New MyReportLib.RO_EntidadesEmisoras)

            'Resumen Mensual por Tipo de Monedas
            ReportBookONE.Reports.Add(New MyReportLib.RO_ResumenMensualporTipodeMonedas)
   
            'Operaciones por Puesto de Bolsa
             ReportBookONE.Reports.Add(New MyReportLib.RO_PuestoBolsa)
   


            'Operaciones Puesto Bolsa 
            ReportBookONE.Reports.Add(New MyReportLib.RO_OperacionesPorPuestoBolsa)
            'Operaciones Entidad Emisioras 
            ReportBookONE.Reports.Add(New MyReportLib.RO_OperacionesPorEntidadesEmisoras)
            'Operaciones Por Instrumento
            ReportBookONE.Reports.Add(New MyReportLib.RO_OperacionesPorInstrumento)
            'Operaciones Actividad Economica
            ReportBookONE.Reports.Add(New MyReportLib.RO_OperacionesActividadEconomica)


            'Lista de Puestos de Bolsa
            ReportBookONE.Reports.Add(New MyReportLib.RO_ListadodePuestosdeBolsa)


            ReportBookONE.DocumentName = "REP ONE - TOTAL" & Format(Now(), "dd-MM-yyyy")

            InstaciaReportSource.ReportDocument = ReportBookONE

            ReportViewer1.ReportSource = InstaciaReportSource
            ReportViewer1.RefreshReport()



            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Reporte", "Reporte Oficina Nacional de Estadística (ONE) - Total", "")




        End If
    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 7 Then 'Mover

            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../reportes/ReportONETotal.aspx','1000','600')</" + "script>"

        ElseIf e.Item.Value = 2 Then 'Cancelar
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
        End If
    End Sub
End Class


