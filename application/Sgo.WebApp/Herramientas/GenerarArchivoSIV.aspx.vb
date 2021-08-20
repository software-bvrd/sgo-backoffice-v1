Imports System.Xml.Serialization
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml

Public Class GenerarArchivoSIV
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function ConsultaDataSIV(fechainicio As Object, fechafin As Object) As DataSet
        Dim dsOperacionesSIV As New DataSet
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Dim Sql As String = "select * from viw_operaciones_siv where fecha_oper between @fechainicio and @fechafin"
        Dim cmd As New SqlCommand(Sql, Cnx)
        Dim sqlAdap As New SqlDataAdapter

        cmd.Parameters.Add(New SqlParameter("@fechainicio", SqlDbType.DateTime)).Value = fechainicio
        cmd.Parameters.Add(New SqlParameter("@fechafin", SqlDbType.DateTime)).Value = fechafin
        sqlAdap.SelectCommand = cmd
        sqlAdap.Fill(dsOperacionesSIV)
        Return dsOperacionesSIV

    End Function
    ' ------------------------------------------------------------------------
    ' Barra de Botonos superior
    ' ------------------------------------------------------------------------
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then 'Guardar


        ElseIf e.Item.Value = 1 Then ' Descargar

            Dim dsOperacionesSIV As New DataSet
            Dim fileName As String = "SIV_" + Format(txtFechaInicial.DbSelectedDate, "yyyy-MM-dd") + "_" + Format(txtFechaFinal.DbSelectedDate, "yyyy-MM-dd") + ".xml"

            dsOperacionesSIV = ConsultaDataSIV(txtFechaInicial.DbSelectedDate, txtFechaFinal.DbSelectedDate)



            If dsOperacionesSIV.Tables(0).Rows.Count = 0 Then
                lblmsg.Text = "No se encuentran registros para el rango de fecha definido."
            Else

                Dim objBvvrd As New BvrdType
                Dim objTransaccion As transaccion
                Dim transaccionesList As New List(Of transaccion)

                For Each myRow In dsOperacionesSIV.Tables(0).Rows

                    objTransaccion = New transaccion

                    '  objTransaccion.cant_valor_nominal = 5
                    If Not IsDBNull(myRow.Item("cant_valor_nominal")) Then objTransaccion.cant_valor_nominal = Trim(myRow.Item("cant_valor_nominal"))

                    '   objTransaccion.cod_isin = "test"
                    If Not IsDBNull(myRow.Item("cod_isin")) Then objTransaccion.cod_isin = Trim(myRow.Item("cod_isin"))

                    objTransaccion.rnc_puesto = "001211"
                    If Not IsDBNull(myRow.Item("rnc_puesto")) Then objTransaccion.rnc_puesto = Trim(myRow.Item("rnc_puesto"))


                    ' objTransaccion.rnc_emisor = "00321"
                    If Not IsDBNull(myRow.Item("rnc_emisor")) Then objTransaccion.rnc_emisor = Trim(myRow.Item("rnc_emisor"))


                    '  objTransaccion.cod_siv_emision = "dsdsfd"
                    If Not IsDBNull(myRow.Item("cod_siv_emision")) Then objTransaccion.cod_siv_emision = Trim(myRow.Item("cod_siv_emision"))


                    '   objTransaccion.cod_isin = "2222"
                    If Not IsDBNull(myRow.Item("cod_isin")) Then objTransaccion.cod_isin = Trim(myRow.Item("cod_isin"))


                    '   objTransaccion.serie = "3444"
                    If Not IsDBNull(myRow.Item("serie")) Then objTransaccion.serie = Trim(myRow.Item("serie"))


                    '  objTransaccion.cod_moneda = "5555"
                    If Not IsDBNull(myRow.Item("cod_moneda")) Then objTransaccion.cod_moneda = Trim(myRow.Item("cod_moneda"))


                    '  objTransaccion.num_operacion = "5555"
                    If Not IsDBNull(myRow.Item("num_operacion")) Then objTransaccion.num_operacion = Trim(myRow.Item("num_operacion"))

                    objTransaccion.tasas = New tipotasa()

                    ' objTransaccion.tasas.tasa_int_facial = 2
                    If Not IsDBNull(myRow.Item("tasa_int_facial")) Then objTransaccion.tasas.tasa_int_facial = Trim(myRow.Item("tasa_int_facial"))

                    ' objTransaccion.tasas.tasa_int_rendimiento = 4
                    If Not IsDBNull(myRow.Item("tasa_int_rendimiento")) Then objTransaccion.tasas.tasa_int_rendimiento = Trim(myRow.Item("tasa_int_rendimiento"))

                    objTransaccion.fechas = New tipofecha()

                    If Not IsDBNull(myRow.Item("fecha_valor")) Then objTransaccion.fechas.fecha_valor = Trim(myRow.Item("fecha_valor"))

                    ''   objTransaccion.fechas.fecha_venc_mutuo = Date.Now


                    If Not IsDBNull(myRow.Item("fecha_venc_mutuo")) Then objTransaccion.fechas.fecha_venc_mutuo = Trim(myRow.Item("fecha_venc_mutuo"))

                    '   objTransaccion.unidad_valor_nominal = 1
                    If Not IsDBNull(myRow.Item("unidad_valor_nominal")) Then objTransaccion.unidad_valor_nominal = Trim(myRow.Item("unidad_valor_nominal"))

                    '   objTransaccion.valor_nominal = 1
                    If Not IsDBNull(myRow.Item("valor_nominal")) Then objTransaccion.valor_nominal = Trim(myRow.Item("valor_nominal"))

                    ' objTransaccion.cant_valor_nominal = 1
                    If Not IsDBNull(myRow.Item("cant_valor_nominal")) Then objTransaccion.cant_valor_nominal = Trim(myRow.Item("cant_valor_nominal"))

                    '  objTransaccion.precio_mercado = 1
                    If Not IsDBNull(myRow.Item("precio_mercado")) Then objTransaccion.precio_mercado = Trim(myRow.Item("precio_mercado"))

                    ' objTransaccion.valor_mercado = 23
                    If Not IsDBNull(myRow.Item("valor_mercado")) Then objTransaccion.valor_mercado = Trim(myRow.Item("valor_mercado"))


                    Select Case myRow.Item("clasif_operacion")
                        Case "ND"
                            objTransaccion.clasif_operacion = clasifoperacion.ND
                        Case "PRP"
                            objTransaccion.clasif_operacion = clasifoperacion.PRP
                        Case "REQ"
                            objTransaccion.clasif_operacion = clasifoperacion.REQ

                    End Select
                    objTransaccion.clasif_operacionSpecified = True

                    '   objTransaccion.tipo_transaccion = tipotransaccion.CPR

                    Select Case myRow.Item("tipo_transaccion")
                        Case "CPR"
                            objTransaccion.tipo_transaccion = tipotransaccion.CPR
                        Case "VNT"
                            objTransaccion.tipo_transaccion = tipotransaccion.VNT
                        Case "MNT"
                            objTransaccion.tipo_transaccion = tipotransaccion.MNT
                        Case "MTR"
                            objTransaccion.tipo_transaccion = tipotransaccion.MTR
                        Case "OTR"
                            objTransaccion.tipo_transaccion = tipotransaccion.OTR
                    End Select

                    objTransaccion.tipo_transaccionSpecified = True

                    '       objTransaccion.tipo_contrato() = tipocontrato.DIVHE
                    If Not IsDBNull(myRow.Item("tipo_contrato")) Then

                        Select Case myRow.Item("tipo_contrato")
                            Case "SPT"
                                objTransaccion.tipo_contrato = tipocontrato.SPT
                            Case "FRW"
                                objTransaccion.tipo_contrato = tipocontrato.FRW
                            Case "MTO"
                                objTransaccion.tipo_contrato = tipocontrato.MTO
                            Case "HEREN"
                                objTransaccion.tipo_contrato = tipocontrato.HEREN
                            Case "DIVHE"
                                objTransaccion.tipo_contrato = tipocontrato.DIVHE
                            Case "SPSCC"
                                objTransaccion.tipo_contrato = tipocontrato.SPSCC
                            Case "DONAC"
                                objTransaccion.tipo_contrato = tipocontrato.DONAC
                            Case "DIVPP"
                                objTransaccion.tipo_contrato = tipocontrato.DIVPP
                            Case "FUSES"
                                objTransaccion.tipo_contrato = tipocontrato.FUSES
                            Case "FUNFM"
                                objTransaccion.tipo_contrato = tipocontrato.FUNFM
                            Case "EFCDP"
                                objTransaccion.tipo_contrato = tipocontrato.EFCDP
                            Case "MNDLJ"
                                objTransaccion.tipo_contrato = tipocontrato.MNDLJ
                            Case "TRCOP"
                                objTransaccion.tipo_contrato = tipocontrato.TRCOP

                        End Select
                        objTransaccion.tipo_contratoSpecified = True
                    End If

                    '   objTransaccion.tipo_mercado() = tipomercado.PRI
                    If Not IsDBNull(myRow.Item("tipo_mercado")) Then
                        Select Case myRow.Item("tipo_mercado")
                            Case "PRI"
                                objTransaccion.tipo_mercado = tipomercado.PRI
                            Case "SEC"
                                objTransaccion.tipo_mercado = tipomercado.SEC
                        End Select
                        objTransaccion.tipo_mercadoSpecified = True
                    End If

                    If Not IsDBNull(myRow.Item("tipo_operacion")) Then
                        Select Case myRow.Item("tipo_operacion")
                            Case "CTER"

                                objTransaccion.tipo_operacion = tipooperacion.CTER
                            Case "CPROP"
                                objTransaccion.tipo_operacion = tipooperacion.CPROP
                        End Select
                        objTransaccion.tipo_operacionSpecified = True
                    End If


                    transaccionesList.Add(objTransaccion)
                Next

                objBvvrd.fecha = Date.Now
                objBvvrd.transaccion = transaccionesList.ToArray
                objBvvrd.rnc = "101-87151-2"
                objBvvrd.version = "1"

                Dim serializer As New XmlSerializer(objBvvrd.GetType)
                Dim targetFolder As String = Server.MapPath("~/tmp/")
                Dim filePath As String = targetFolder + fileName

                Dim stream As New StreamWriter(filePath)
                Using stream
                    serializer.Serialize(stream, objBvvrd)
                End Using

                With HttpContext.Current.Response
                    .AddHeader("Content-disposition", "attachment;filename=" + fileName)
                    '.AddHeader("Content-Length", btFile.Length.ToString)
                    .ContentType = "text/xml"
                    .ContentEncoding = System.Text.Encoding.UTF8
                    .TransmitFile(filePath)
                    '.BinaryWrite(btFile)
                    .End()
                End With
            End If


        ElseIf e.Item.Value = 2 Then  ' Cancelar
            Me.txtFechaInicial.SelectedDate = Nothing
            Me.txtFechaFinal.SelectedDate = Nothing
            Me.lblmsg.Text = ""
        ElseIf e.Item.Value = 3 Then
           
            bindGVoperaciones()
        End If

    End Sub
    Public Sub bindGVoperaciones()
        Dim dsOperacionesSIV As New DataSet
        dsOperacionesSIV = ConsultaDataSIV(txtFechaInicial.DbSelectedDate, txtFechaFinal.DbSelectedDate)

        RadGrid1.DataSource = dsOperacionesSIV
        RadGrid1.DataBind()
    End Sub
    Protected Sub RadToolBar2_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar2.ButtonClick
        If e.Item.Value <> "" Then

            If e.Item.Value = 4 Then 'Exportar excel
                Dim dsOperacionesSIV As New DataSet
                dsOperacionesSIV = ConsultaDataSIV(txtFechaInicial.DbSelectedDate, txtFechaFinal.DbSelectedDate)

                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                bindGVoperaciones()
                RadGrid1.MasterTableView.ExportToExcel()
            End If
        End If
    End Sub

    Protected Sub RadGrid1_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        RadGrid1.CurrentPageIndex = e.NewPageIndex

        bindGVoperaciones()
    End Sub
End Class