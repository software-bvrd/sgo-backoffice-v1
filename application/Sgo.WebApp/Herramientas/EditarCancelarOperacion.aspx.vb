Imports System.Data
Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.IO
Imports System.Globalization

Public Class EditarCancelarOperacion
    Inherits System.Web.UI.Page
    Private oper As New operation


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If IsPostBack = False Then

            ViewState("IdOperacion") = Request.QueryString("ID")
            ViewState("num_oper") = Request.QueryString("NO")
            ViewState("fecha_oper") = Request.QueryString("FO")
            ViewState("mercado") = Request.QueryString("ME")

            txtFecha.Text = ViewState("fecha_oper")
            txtNoOper.Text = ViewState("num_oper")
            txtMercado.Text = ViewState("mercado")

            '' RadTabStrip1.Tabs(1).Enabled = False

        End If

        txtNombre.Focus()
        txtNombre.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll
    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar

            Dim VerificarExistencia As String = ""
            If txtNombre.Text <> "" Then
                VerificarExistencia = oper.ExecuteScalar("select count(*) as conteo from [vConsultaOperacionesCSV] where IdOperacion=" & CStr(ViewState("IdOperacion")))

                If Integer.Parse(VerificarExistencia) > 0 Then
                    GuardarInformacionCancelar(ViewState("IdOperacion"))
                End If
            Else
                lblMensaje.ForeColor = Drawing.Color.Red
                lblMensaje.Text = "Ingrese un motivo"
            End If

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            oper.ExecuteNonQuery("delete from OperacionesCSVDocumento where IdOperacion=" & CStr(ViewState("IdOperacion")))
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If
    End Sub
    Protected Sub GuardarInformacionCancelar(cFiltro As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""

        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        Dim dFechaCancelacion As Date = DateTime.Now

        Try

            Dim Sql As String = ""
            Dim Estatus As String = ""
            If ddlEstatus.SelectedText.ToString = "Cancelada" Then
                Estatus = "N"
            End If

            If ddlEstatus.SelectedText.ToString = "No Liquidada" Then
                Estatus = "NL"
            End If


            'Fecha

            ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat



            ' Actualizar Operación
            Cnx.Open()

            If Estatus = "N" Then
                Sql = "Update [OperacionesCSV] set  Estatus ='" & Estatus.ToString() & "',mercado ='" & Estatus.ToString() & "', Numero_operDCV= '" & txtNoOperDCV.Text.Trim() & "', Mercadoa = '" & txtMercado.Text.TrimEnd() & "' where  [IdOperacion]='" & CStr(ViewState("IdOperacion")) & "'"
            Else
                Sql = "Update [OperacionesCSV] set  Estatus ='" & Estatus.ToString() & "', Numero_operDCV= '" & txtNoOperDCV.Text.Trim() & "', Mercadoa = '" & txtMercado.Text.TrimEnd() & "' where  [IdOperacion]='" & CStr(ViewState("IdOperacion")) & "'"
            End If

            Dim cmd As New SqlCommand(Sql, Cnx)
            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Cancelar Operaciones", "EditarCancelarOperaciones", csql)



            ' Actualizar Operación
            Sql = "Insert into [OperacionesCSVCancelacion] (IdOperacion,FechaActualizacion,MotivoCancelacion,Mercado) values  (" & ViewState("IdOperacion") & ",'" &
                   dFechaCancelacion.ToString("MM/dd/yyyy HH:mm:ss") & "','" & txtNombre.Text & "','" & txtMercado.Text.TrimEnd() & "' ) "

            Dim cmd2 As New SqlCommand(Sql, Cnx)
            cmd2.ExecuteNonQuery()


            csql = oper.CovertirComandoATexto(cmd2)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Cancelar Operaciones Motivo", "EditarCancelarOperaciones", csql)



            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat



            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally

            Cnx.Close()
        End Try


    End Sub



    Public Sub AgregarDatosDocumentos(cDocumento As String, cArchivo As String, cRtutaCompletaArchivo As String)
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""

        Try
            Cnx.Open()
            '' Guardar Información de documentos


            csql = "Insert into [OperacionesCSVDocumento] values (@IdOperacion, @nombre, @Adjunto, @Archivo) "



            Dim cmDocumento As New SqlCommand(csql, Cnx)


            cmDocumento.Parameters.Add(New SqlParameter("@IdOperacion", SqlDbType.BigInt)).Value = CInt(ViewState("IdOperacion"))
            cmDocumento.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = cDocumento
            cmDocumento.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(cRtutaCompletaArchivo)
            cmDocumento.Parameters.Add(New SqlParameter("@Archivo", SqlDbType.VarChar)).Value = cArchivo

            cmDocumento.ExecuteNonQuery()



        Catch ex As Exception

        Finally
            Cnx.Close()
            RadGridDocumento.MasterTableView.Rebind()
        End Try

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If SubidaArchivo() = True Then

            Try
                Dim targetFolder As String = Server.MapPath("~/tmp/")


                AgregarDatosDocumentos(txtNombreDoc.Text, txtArchivo.Text, targetFolder & ViewState("FileName"))

                txtArchivo.Text = ""
                txtNombreDoc.Text = ""


            Catch ex As Exception

            End Try
        End If



    End Sub


#Region "Manejo de Archivos ..."
    Public Function ConvierteBinario(ByVal Path As String) As Byte()
        Dim sPath As String
        sPath = Path
        Dim Ruta As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim Binario(CInt(Ruta.Length)) As Byte
        Ruta.Read(Binario, 0, CInt(Ruta.Length))
        Ruta.Close()
        Return Binario
    End Function
    Function SubidaArchivo() As Boolean
        If RadUpload1.UploadedFiles.Count > 0 Then
            Try

                For Each validFile As UploadedFile In RadUpload1.UploadedFiles
                    LooongMethodWhichUpdatesTheProgressContext(validFile)
                    Dim targetFolder As String = Server.MapPath("~/tmp/")
                    validFile.SaveAs(System.IO.Path.Combine(targetFolder, validFile.GetName()), True)
                    ViewState("FileName") = validFile.GetName()
                    txtArchivo.Text = ViewState("FileName")
                    'Button2.Enabled = False
                    'RadUpload1.Visible = False
                    RadProgressArea1.Visible = False
                    Return True
                Next
            Catch ex As Exception
                Return False
            End Try
        Else
            Return False
        End If

        Return True

    End Function
    Private Sub DeleteFiles()
        Dim targetFolder As String = Server.MapPath("~/tmp/")
        Dim targetDir As New DirectoryInfo(targetFolder)
        Try
            For Each file As FileInfo In targetDir.GetFiles()
                If (file.Attributes And FileAttributes.[ReadOnly]) = 0 Then
                    file.Delete()
                End If
            Next
        Catch generatedExceptionName As IOException
        End Try
    End Sub
    Private Sub LooongMethodWhichUpdatesTheProgressContext(ByVal file As UploadedFile)
        Const total As Integer = 100
        Dim progress As RadProgressContext = RadProgressContext.Current
        Dim i As Integer = 0
        While i < total
            progress.PrimaryTotal = 1
            progress.PrimaryValue = 1
            progress.PrimaryPercent = 100

            progress.SecondaryTotal = total
            progress.SecondaryValue = i
            progress.SecondaryPercent = i

            progress.CurrentOperationText = file.GetName() + " está siendo procesado..."
            If Not Response.IsClientConnected Then
                Exit While
            End If
            System.Threading.Thread.Sleep(100)
            i = i + 1
        End While
    End Sub


#End Region



End Class
