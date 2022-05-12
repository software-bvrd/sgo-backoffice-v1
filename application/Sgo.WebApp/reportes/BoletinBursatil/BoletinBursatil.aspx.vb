Imports System.Globalization
Imports Telerik.Reporting
Imports Telerik.Web.UI

Partial Class BoletinBursatil
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


            'Portada

            'Dim ReportePortada As New MyReportLib.BB_BoletinPortada
            'ReportePortada.Name="ReportePortada"

            ReportBookDiario.Reports.Add(New MyReportLib.BB_BoletinPortada)
            'Indice 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_BoletinIndice)
            'Glosario 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_BoletinGlosario)

            'Resumen General de Mercado (4)
            ReportBookDiario.Reports.Add(New MyReportLib.BB_ResumenGeneralMercado)

            'Resumen de Operaciones Reportadas (Registro) y Creadores de Mercado MH 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_ResOpesRepRegistro)

            '  Comparativo Volumen Mercado YTD RF (5)
            ReportBookDiario.Reports.Add(New MyReportLib.BB_Comp_VMYTDRF)


            ''''''
            '''''' RENTA FIJA
            ''''''


            'Renta Fija | Volumen Transado por Puesto de Bolsa (PB RF) MP
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFVTransPuestoBolsaMP)

            'Renta Fija | Volumen Transado por Puesto de Bolsa (PB RF) MS
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFMSVTPBolsa)

            'Renta Fija | Volumen Transado por Participante | Operaciones Reportadas (Registro) y Creadores de Mercado MH
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFRegistro)

            'Ranking BVRD Volumen Transado por Participante | CM del MH
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RentaFijaVolumenTransadoPuestoBolsaRanking)

            'Renta Fija | Volumen Transado Instrumentos de Entidades Emisoras (MP)
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFVolTransEntidadMP)

            'Renta Fija | Volumen Transado Instrumentos de Entidades Emisoras (EMI RF) (MS)
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFVolTransEntidad)

            'Renta Fija |Volumen Transado Mercado Secundario 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFVTransMS)

            'Renta Fija |Mercado Primario Operaciones del día  
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFMPOperDia)

            ' Renta Fija |Lista de Registro de  Operaciones Mercado Primario en FIRME 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFMPOperDiaFirme)

            'Renta Fija |Mercado Secundario Operaciones del día  
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFMSOperDia)


            'Renta Fija | Mercado Secundario Top N Títulos Transados en el Mes (8)
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFMSTopTitTransMes)

            'Renta Fija | Precios de Cierre del día por Rueda
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFPrecCierrediaRueda)

            'Renta Fija | Reporte de Operaciones por Plazo (Op X Plazo)
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFMSOperPlazos)

            'Renta Fija | Volúmenes Transados por Emisores Equivalentes en DOP
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFVolTransEmisoresDOP)

            'Renta Fija | Emisiones Corporativas Vigentes 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RFEmisionesCorpV)



            ''''''
            '''''' RENTA VARIABLE
            ''''''

            'Renta Variable | Volumen Transado Mercado Primario 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVVTransMPXIns)

            'Renta Variable | Volumen Transado Mercado Secundario 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVVTransMSXIns)


            'Renta Variable | Volumen Transado por Participante | Operaciones Reportadas (Registro) y Creadores de Mercado MH
            'ReportBookDiario.Reports.Add(New MyReportLib.BB_RVVolTranPBolsaReg)

            'Renta Variable | Volumen Transado por Puesto de Bolsa (PB RV)
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVVTransPuestoBolsa)

            'Renta Variable | Volumen Transado por Puesto de Bolsa (PB RV) MS
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVVTransPBolsa)

            'Renta Variable | Volumen Transado Instrumentos de Entidades Emisoras (EMI RV)
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVVolTransInsEEmisoras)

            'Renta Variable | Volumen Transado Instrumentos de Entidades Emisoras (EMI RV) MS
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVVTransInstEEmisoras)

            'Renta Variable | Mercado Primario Operaciones del día 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVMPOperDia)

            'Renta Variable | Lista de Registro de  Operaciones Mercado Primario en FIRME 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVMPOperDiaFirme)

            'Renta Variable | Mercado Secundario Operaciones del día 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVMSOperDia)

            'Renta Variable | Mercado Secundario Top N Títulos Transados al Mes 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVMSTopTitTransMes)

            'Renta Variable | Precios de Cierre del día 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVPreCierrediaIns)

            'Renta Variable | Resúmen Montos Transados por Instrumentos
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVMNegociadosIns)

            'Renta Variable | Resúmen Montos Transados por Participantes/Instrumentos
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVMTransParticIns)

            'Renta Variable | Cantidad de Operaciones por Participante
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVCanOperParticipante)

            'Renta Variable | Valor Transado Operaciones por Participante
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVValorTransOperPart)

            'Renta Variable | Precios Ultimo, Más Alto, Más Bajo y Ponderado
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVPrUltMejorPeor)

            'Renta Variable | Montos Transados por Participantes/Instrumentos Por Moneda Emisión
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVMTransParMoEmision)

            'Renta Variable | Volúmenes Transados por Emisores Equivalentes en DOP
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVVolTransEmisoresDOP)

            'Renta Variable | Emisiones Corporativas Vigentes 
            ReportBookDiario.Reports.Add(New MyReportLib.BB_RVEmisionesCorpV)

            ReportBookDiario.DocumentName = "BB BO2 " & Format(Now(), "dd-MM-yyyy")

            InstaciaReportSource.ReportDocument = ReportBookDiario

            ReportViewer1.ReportSource = InstaciaReportSource
            ReportViewer1.RefreshReport()



            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Reporte", "BoletinDiario", "")



            'Telerik Q2
            'ReportViewer1.ReportBookID = ReportBookControl1.ClientID
            'ReportViewer1.RefreshReport()


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
