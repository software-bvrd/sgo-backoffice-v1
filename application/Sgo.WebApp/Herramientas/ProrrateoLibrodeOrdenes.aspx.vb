Imports Telerik.Web.UI
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization

Partial Class Transacciones_ProrrateoLibrodeOrdenes
    Inherits System.Web.UI.Page
    Private oper As New operation
    Dim MontoTotal As Decimal
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call ConfiguracionControles()
        End If

    End Sub
    Public Sub ShowCheckedItems(ByVal comboBox As RadComboBox)

        Dim collection As IList(Of RadComboBoxItem) = comboBox.CheckedItems

        If (collection.Count <> 0) Then
            oper.ExecuteNonQuery("truncate table dbo.SubastaEmisionSerie")

            For Each item As RadComboBoxItem In collection
                Dim SqlMonto As String = "Select ValorUnitarioNominal from dbo.EmisionSerie where CodigoSerie ='" + item.Text + "'"
                Dim SqlCodigoISIN As String = "Select rtrim(CodigoISIN) as CodigoISIN  from dbo.EmisionSerie where CodigoSerie ='" + item.Text + "'"
                Dim ResSlqMonto As String = oper.ExecuteScalar(SqlMonto)
                Dim ResSqlCodigoISIN As String = oper.ExecuteScalar(SqlCodigoISIN)

                Dim Sql As String = "insert into dbo.SubastaEmisionSerie (EmisionSerie,CodigoISIN,Monto) values ('" + item.Text + "','" + ResSqlCodigoISIN + "'," + Str(ResSlqMonto) + ")"
                oper.ExecuteNonQuery(Sql)
                MontoTotal = MontoTotal + ResSlqMonto
            Next

        Else
            lblMensaje.Text = "No items selected"

        End If


    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then ' Procesar
            Try
                If cboTipoLibroOrdenes.SelectedValue.Trim() = "LOPI" Then
                    Call ProcesarProrrateo("LOPI")

                ElseIf cboTipoLibroOrdenes.SelectedValue.Trim() = "LOIG" Then
                    Call ProcesarProrrateo("LOIG")

                Else
                    'If txtValorMinimoInversion.Text.Trim().Length <= 0 Then
                    '    lblMensaje.ForeColor = Drawing.Color.Red
                    '    lblMensaje.Text = "Ingrese un monto mínimo de inversión."
                    '    Exit Sub
                    'End If

                    'ShowCheckedItems(cbEmisionSerie)

                    'Dim cmd As New SqlCommand
                    'Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())


                    'cmd.CommandText = "dbo.SP_Prorrogateo"
                    'cmd.CommandType = CommandType.StoredProcedure


                    'Dim paramfi As System.Data.SqlClient.SqlParameter
                    'paramfi = New System.Data.SqlClient.SqlParameter()

                    'paramfi.ParameterName = "@pFechaInicio"
                    'paramfi.SqlDbType = SqlDbType.Date
                    'paramfi.Value = txtFechaInicial.SelectedDate
                    'cmd.Parameters.Add(paramfi)

                    'Dim paramff As System.Data.SqlClient.SqlParameter
                    'paramff = New System.Data.SqlClient.SqlParameter()

                    'paramff.ParameterName = "@pFechaFinal"
                    'paramff.SqlDbType = SqlDbType.Date
                    'paramff.Value = txtFechaFinal.SelectedDate
                    'cmd.Parameters.Add(paramff)

                    'Dim paramEm As System.Data.SqlClient.SqlParameter
                    'paramEm = New System.Data.SqlClient.SqlParameter()

                    'paramEm.ParameterName = "@pEmision"
                    'paramEm.SqlDbType = SqlDbType.Char
                    'paramEm.Value = RadComboBoxEmisionID.Text
                    'cmd.Parameters.Add(paramEm)

                    'Dim paramMT As System.Data.SqlClient.SqlParameter
                    'paramMT = New System.Data.SqlClient.SqlParameter()

                    'paramMT.ParameterName = "@pMontoTotal"
                    'paramMT.SqlDbType = SqlDbType.Decimal
                    'paramMT.Value = MontoTotal
                    'cmd.Parameters.Add(paramMT)


                    'Dim paramIm As System.Data.SqlClient.SqlParameter
                    'paramIm = New System.Data.SqlClient.SqlParameter()

                    'paramIm.ParameterName = "@pInversionMinima"
                    'paramIm.SqlDbType = SqlDbType.Decimal
                    'paramIm.Value = txtValorMinimoInversion.Text
                    'cmd.Parameters.Add(paramIm)

                    'Dim paramPe As System.Data.SqlClient.SqlParameter
                    'paramPe = New System.Data.SqlClient.SqlParameter()

                    'paramPe.ParameterName = "@pPorcentajeEmision"
                    'paramPe.SqlDbType = SqlDbType.Decimal
                    'paramPe.Value = Val(txtPorcentajeEmision.Text) / 100
                    'cmd.Parameters.Add(paramPe)

                    'Cnx.Open()

                    'cmd.Connection = Cnx
                    'cmd.ExecuteScalar()

                    'lblMensaje.ForeColor = Drawing.Color.Blue
                    'lblMensaje.Text = "La información ha sido generada correctamente."

                    lblMensaje.ForeColor = Drawing.Color.Blue
                    lblMensaje.Text = "Este proceso no esta habilitado."
                End If
            Catch ex As Exception
                lblMensaje.ForeColor = Drawing.Color.Red
                lblMensaje.Text = "Ha ocurrido un error al generar la información deseada." + ex.Message

            End Try

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub
    Private Sub ProcesarProrrateo(ByVal pTipoLibroOrdenes)
        Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
        Try
            Dim vTipoLibroOrdenes As String = cboTipoLibroOrdenes.SelectedValue.Trim()
            Dim vCodigoEmision As String = cbEmisionSerie.SelectedValue.Trim()

            Dim vFechaProrrateoDate As New Date
            vFechaProrrateoDate = txtFechaProrrateo.SelectedDate

            'Validar repeticion archivo

            'Habilitar para produccion
            If oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) CodigoProrrateo  FROM ResultadoProrrateo WHERE TipoLibroOrdenes ='" & vTipoLibroOrdenes & "' AND [FechaProrrateo]='" & vFechaProrrateoDate.ToString() & "' AND CodEmisionBVRD='" & vCodigoEmision & "') BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 1 Then
                'Linea solo para local
                'If oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) CodigoProrrateo  FROM ResultadoProrrateo WHERE TipoLibroOrdenes ='" & vTipoLibroOrdenes & "' AND CONVERT(VARCHAR(10),[FechaProrrateo],121)='" & vFechaProrrateoDate.ToString() & "' AND CodEmisionBVRD='" & vCodigoEmision & "') BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 1 Then
                chkSobrescribirArchivo.Enabled = True
                If chkSobrescribirArchivo.Checked = False Then
                    Throw New Exception("Debe seleccionar Sobrescribir prorrateo, para generar nuevamente dicho proceso que ya existe en el sistema.")
                ElseIf chkSobrescribirArchivo.Checked = True Then
                    If Not SobrescribirProrrateo(vTipoLibroOrdenes, vFechaProrrateoDate, vCodigoEmision) Then
                        Throw New Exception("Error al sobrescribir el prorrateo.")
                    Else
                        chkSobrescribirArchivo.Checked = False
                        chkSobrescribirArchivo.Enabled = False
                    End If
                End If
            End If


            ''Validar repeticion archivo proceso No.1
            'If oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) CodigoProrrateo  FROM ResultadoProrrateo WHERE TipoLibroOrdenes ='" & vTipoLibroOrdenes & "' AND CONVERT(VARCHAR(10),[FechaProrrateo],121)='" & vFechaProrrateo & "' AND CodEmisionBVRD='" & vCodigoEmision & "') BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 1 Then
            '    chkSobrescribirArchivo.Enabled = True
            '    If chkSobrescribirArchivo.Checked = False Then
            '        Throw New Exception("Debe seleccionar Sobrescribir prorrateo, para generar nuevamente dicho proceso que ya existe en el sistema.")
            '    ElseIf chkSobrescribirArchivo.Checked = True Then
            '        If Not SobrescribirProrrateo(vTipoLibroOrdenes, vFechaProrrateo, vCodigoEmision) Then
            '            Throw New Exception("Error al sobrescribir el prorrateo.")
            '        Else
            '            chkSobrescribirArchivo.Checked = False
            '            chkSobrescribirArchivo.Enabled = False
            '        End If
            '    End If
            'End If


            Dim cmd As New SqlCommand
            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            If pTipoLibroOrdenes = "LOPI" Then
                cmd.CommandText = "dbo.SP_ProrrogateoOrdenesLOPI"
            ElseIf pTipoLibroOrdenes = "LOIG" Then
                cmd.CommandText = "dbo.SP_ProrrogateoOrdenesLOIG"
            End If


            cmd.CommandType = CommandType.StoredProcedure

            Dim paramFe As System.Data.SqlClient.SqlParameter
            paramFe = New System.Data.SqlClient.SqlParameter()
            paramFe.ParameterName = "@pFechaProrrateo"
            paramFe.SqlDbType = SqlDbType.Date
            paramFe.Value = txtFechaProrrateo.SelectedDate.Value 'txtFechaProrrateo.SelectedDate.Value.ToString("dd/MM/yyyy")
            cmd.Parameters.Add(paramFe)

            Dim paramfi As System.Data.SqlClient.SqlParameter
            paramfi = New System.Data.SqlClient.SqlParameter()
            paramfi.ParameterName = "@pFechaInicio"
            paramfi.SqlDbType = SqlDbType.Date
            paramfi.Value = txtFechaInicial.SelectedDate
            cmd.Parameters.Add(paramfi)

            Dim paramff As System.Data.SqlClient.SqlParameter
            paramff = New System.Data.SqlClient.SqlParameter()
            paramff.ParameterName = "@pFechaFinal"
            paramff.SqlDbType = SqlDbType.Date
            paramff.Value = txtFechaFinal.SelectedDate
            cmd.Parameters.Add(paramff)

            Dim paramEm As System.Data.SqlClient.SqlParameter
            paramEm = New System.Data.SqlClient.SqlParameter()
            paramEm.ParameterName = "@pEmision"
            paramEm.SqlDbType = SqlDbType.Char
            paramEm.Value = vCodigoEmision
            cmd.Parameters.Add(paramEm)

            If pTipoLibroOrdenes = "LOPI" Then
                Dim paramPe As System.Data.SqlClient.SqlParameter
                paramPe = New System.Data.SqlClient.SqlParameter()
                paramPe.ParameterName = "@pPorcentajeEmision"
                paramPe.SqlDbType = SqlDbType.Decimal
                paramPe.Value = Val(txtPorcentajeEmision.Text) / 100
                cmd.Parameters.Add(paramPe)
            End If
            Cnx.Open()

            cmd.Connection = Cnx
            cmd.ExecuteScalar()

            Mensaje.ForeColor = Drawing.Color.Blue
            Mensaje.Text = "La información ha sido generada correctamente."
        Catch ex As Exception
            Mensaje.ForeColor = Drawing.Color.Red
            Mensaje.Text = "Error: No se realizado el proceso. " & ex.Message
        End Try

    End Sub

    Private Sub ProcesarProrrateoLOIG()
        Try
            Dim CodigoEmisionSerie As String = cbEmisionSerie.SelectedValue.Trim()

            Dim cmd As New SqlCommand
            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            cmd.CommandText = "dbo.SP_ProrrogateoOrdenesLOIG"

            cmd.CommandType = CommandType.StoredProcedure

            Dim paramfi As System.Data.SqlClient.SqlParameter
            paramfi = New System.Data.SqlClient.SqlParameter()
            paramfi.ParameterName = "@pFechaInicio"
            paramfi.SqlDbType = SqlDbType.Date
            paramfi.Value = txtFechaInicial.SelectedDate
            cmd.Parameters.Add(paramfi)

            Dim paramff As System.Data.SqlClient.SqlParameter
            paramff = New System.Data.SqlClient.SqlParameter()
            paramff.ParameterName = "@pFechaFinal"
            paramff.SqlDbType = SqlDbType.Date
            paramff.Value = txtFechaFinal.SelectedDate
            cmd.Parameters.Add(paramff)

            Dim paramEm As System.Data.SqlClient.SqlParameter
            paramEm = New System.Data.SqlClient.SqlParameter()
            paramEm.ParameterName = "@pEmision"
            paramEm.SqlDbType = SqlDbType.Char
            paramEm.Value = CodigoEmisionSerie
            cmd.Parameters.Add(paramEm)

            Cnx.Open()

            cmd.Connection = Cnx
            cmd.ExecuteScalar()

            lblMensaje.ForeColor = Drawing.Color.Blue
            lblMensaje.Text = "La información ha sido generada correctamente."
        Catch ex As Exception
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Text = ex.Message
        End Try

    End Sub

#Region "Metodos personalizados"
    Function SobrescribirProrrateo(ByVal pTipoLibroOrdenes, ByVal pFechaProrrateo, ByVal pEmision) As Boolean
        Dim vRetorno As Boolean = False
        Try
            Dim cmd As New SqlCommand
            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            cmd.CommandText = "PA_SobrescribirProrrateo"

            cmd.CommandType = CommandType.StoredProcedure
            Dim paramEm As System.Data.SqlClient.SqlParameter
            paramEm = New System.Data.SqlClient.SqlParameter()
            paramEm.ParameterName = "@pTipoLibroOrdenes"
            paramEm.SqlDbType = SqlDbType.Char
            paramEm.Value = pTipoLibroOrdenes
            cmd.Parameters.Add(paramEm)

            Dim paramff As System.Data.SqlClient.SqlParameter
            paramff = New System.Data.SqlClient.SqlParameter()
            paramff.ParameterName = "@pFechaProrrateo"
            paramff.SqlDbType = SqlDbType.Date
            paramff.Value = pFechaProrrateo
            cmd.Parameters.Add(paramff)


            Dim paramSerie As System.Data.SqlClient.SqlParameter
            paramSerie = New System.Data.SqlClient.SqlParameter()
            paramSerie.ParameterName = "@pEmision"
            paramSerie.SqlDbType = SqlDbType.Char
            paramSerie.Value = pEmision
            cmd.Parameters.Add(paramSerie)

            Cnx.Open()

            cmd.Connection = Cnx
            cmd.ExecuteScalar()
            vRetorno = True
        Catch ex As Exception
            vRetorno = False
        End Try
        Return vRetorno
    End Function
#End Region
    Protected Sub LimpiarMensaje()
        lblMensaje.Text = ""
    End Sub

    Protected Sub txtFechaInicial_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles txtFechaInicial.SelectedDateChanged
        LimpiarMensaje()
    End Sub


    Protected Sub txtFechaFinal_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles txtFechaFinal.SelectedDateChanged
        LimpiarMensaje()
    End Sub


    Protected Sub txtValorMinimoInversion_TextChanged(sender As Object, e As EventArgs) Handles txtValorMinimoInversion.TextChanged
        LimpiarMensaje()
    End Sub


    Protected Sub txtPorcentajeEmision_TextChanged(sender As Object, e As EventArgs) Handles txtPorcentajeEmision.TextChanged
        LimpiarMensaje()
    End Sub

    Protected Sub RadComboBoxEmisionID_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEmisionID.SelectedIndexChanged
        LimpiarMensaje()
    End Sub

    Protected Sub cboTipoLibroOrdenes_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cboTipoLibroOrdenes.SelectedIndexChanged
        Call ConfiguracionControles()

    End Sub

#Region "Funciones"
    Private Sub ConfiguracionControles()
        txtFechaProrrateo.SelectedDate = Date.Now().Date()
        If cboTipoLibroOrdenes.SelectedValue = "" Or cboTipoLibroOrdenes.SelectedValue.Trim().Length <= 0 Then
            cbEmisionSerie.CheckBoxes = True
            txtValorMinimoInversion.Enabled = True
        Else
            cbEmisionSerie.CheckBoxes = False
            txtValorMinimoInversion.Enabled = False
        End If
    End Sub
#End Region
End Class
