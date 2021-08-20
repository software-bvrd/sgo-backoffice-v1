Imports System.Data
Imports Telerik.Web.UI
Imports System.Data.SqlClient

Partial Class Herramientas_NombreConsultaUsuario
    Inherits System.Web.UI.Page
    Private oper As New operation
    Dim TipoAccion As String = ""

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If IsPostBack = False Then
            ViewState("IdConsulta") = Request.QueryString("ID")
            ViewState("NombreConsulta") = Request.QueryString("NC")
            ViewState("NombreConsultaUsuario") = Request.QueryString("NCU")
            ViewState("UsuarioID") = Request.QueryString("U")
            txtNombre.Text = ViewState("NombreConsultaUsuario")
        End If
        'Borrar filtro  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            If BorrarFiltro() Then
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            End If
        End If

        If Request.Params("__EVENTTARGET") = "ActualizarConsulta" Then
            TipoAccion = "A"
            GuardarInformacionFiltro(Session("Filtro"), TipoAccion)
        End If
        txtNombre.Focus()
        txtNombre.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll
    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar

            Dim VerificarExistencia As String = ""
            If txtNombre.Text <> "" Then
                VerificarExistencia = oper.ExecuteScalar("select count(*) as conteo from [vFiltrosConsultas] where NombreConsultaUsuario='" & txtNombre.Text & "' AND IdUsuario='" & CStr(ViewState("UsuarioID")) & "' AND NombreConsulta='" & ViewState("NombreConsulta") & "'")

                If Integer.Parse(VerificarExistencia) > 0 Then
                    InjectScriptLabel.Text = "<script>ActualizarConsulta()</" + "script>"
                Else
                    TipoAccion = "I"

                    GuardarInformacionFiltro(Session("Filtro"), TipoAccion)

                End If
            Else
                lblMensaje.ForeColor = Drawing.Color.Red
                lblMensaje.Text = "Ingrese un nombre de consulta"

            End If



        ElseIf e.Item.Value = 2 Then ' Borrar filtro

            If CInt(ViewState("IdConsulta")) > 0 Then
                InjectScriptLabel.Text = "<script>Delete()</" + "script>"
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('No hay consulta para borrar.') </" + "script>"
            End If



        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If
    End Sub
    Protected Sub GuardarInformacionFiltro(cFiltro As String, cTipoAccion As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = ""
            If cTipoAccion = "A" Then
                Sql = "Update [FiltrosConsultas] set  [Filtro]=@Filtro, [EstruturaGrid]=@EstruturaGrid" &
                                               " where  [NombreConsultaUsuario]='" & txtNombre.Text & "' AND NombreConsulta='" & ViewState("NombreConsulta") & "' AND IdUsuario='" & CStr(ViewState("UsuarioID")) & "'"
            ElseIf cTipoAccion = "I" Then
                Sql = "INSERT INTO [FiltrosConsultas]" &
                                    "([NombreConsulta],[Filtro],[NombreConsultaUsuario],[IdUsuario],[EstruturaGrid])" &
                                    " VALUES " &
                                    "(@NombreConsulta,@Filtro,@NombreConsultaUsuario,@IdUsuario, @EstruturaGrid)"

            End If

            Cnx.Open()

            Dim cmd As New SqlCommand(Sql, Cnx)
            cmd.Parameters.Add(New SqlParameter("@NombreConsulta", SqlDbType.VarChar)).Value = ViewState("NombreConsulta")
            cmd.Parameters.Add(New SqlParameter("@Filtro", SqlDbType.VarChar)).Value = cFiltro
            cmd.Parameters.Add(New SqlParameter("@NombreConsultaUsuario", SqlDbType.VarChar)).Value = IIf(txtNombre.Text.Length > 0, txtNombre.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@IdUsuario", SqlDbType.Int)).Value = ViewState("UsuarioID")
            cmd.Parameters.Add(New SqlParameter("@EstruturaGrid", SqlDbType.VarChar)).Value = Session("EstruturaGrid")


            cmd.ExecuteNonQuery()
            Session("NombreConsultaTemp") = txtNombre.Text
            Session.Remove("Filtro")
            Session.Remove("EstruturaGrid")
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
    Function BorrarFiltro() As Boolean

        If CInt(ViewState("IdConsulta")) > 0 Then
            Try

                Dim csql As String = "delete from dbo.FiltrosConsultas where idConsulta='" & CInt(ViewState("IdConsulta")) & "'"
                oper.ExecuteNonQuery(csql)
                Session("FiltroBorrado") = 1
                Return True
            Catch ex As Exception
                InjectScriptLabel.Text = "<script>alert('No se puede borrar esta consulta')</" + "script>"
                Return False
            End Try

        End If

        Return True

    End Function

End Class
