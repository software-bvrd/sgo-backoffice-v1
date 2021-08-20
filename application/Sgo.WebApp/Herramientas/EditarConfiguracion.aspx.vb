Imports System.Data.SqlClient
Imports Telerik.Web.UI
Public Class EditarConfiguracion
    Inherits System.Web.UI.Page
    Private oper As New operation

    ' Inicio del Formulario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            Call Editar()
        End If



    End Sub

    ' Barra de Opciones
    Private Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then ' Guardar


            Call Actualizar()

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"


        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub


    ' Operaciones
    Sub Editar()

        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  configuracion")
        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows

            If Not IsDBNull(MyRow.Item("NombreCompania")) Then Me.txtNombreCompania.Text = Trim(MyRow.Item("NombreCompania"))
            If Not IsDBNull(MyRow.Item("RNC")) Then Me.txtRNC.Text = Trim(MyRow.Item("RNC"))
            If Not IsDBNull(MyRow.Item("Telefono")) Then Me.txtTelefono.Text = Trim(MyRow.Item("Telefono"))
            If Not IsDBNull(MyRow.Item("Email")) Then Me.txtEmail.Text = Trim(MyRow.Item("Email"))
            If Not IsDBNull(MyRow.Item("Web")) Then Me.txtWeb.Text = Trim(MyRow.Item("Web"))
            If Not IsDBNull(MyRow.Item("RegistroMercantil")) Then Me.txtRegistroMercantil.Text = Trim(MyRow.Item("RegistroMercantil"))

            If Not IsDBNull(MyRow.Item("Representante")) Then Me.txtRepresentante.Text = Trim(MyRow.Item("Representante"))
            If Not IsDBNull(MyRow.Item("RepresentanteCargo")) Then Me.txtRepresentanteCargo.Text = Trim(MyRow.Item("RepresentanteCargo"))

            If Not IsDBNull(MyRow.Item("ResolucionCertificadoCorredor")) Then Me.txtResolucionCertificadoCorredor.Text = Trim(MyRow.Item("ResolucionCertificadoCorredor"))

            If Not IsDBNull(MyRow.Item("RepresentanteOperaciones")) Then Me.txtRepresentanteOperaciones.Text = Trim(MyRow.Item("RepresentanteOperaciones"))
            If Not IsDBNull(MyRow.Item("RepresentanteOperacionesCargo")) Then Me.txtRepresentanteOperacionesCargo.Text = Trim(MyRow.Item("RepresentanteOperacionesCargo"))
            If Not IsDBNull(MyRow.Item("RepresentanteOperacionesTelefono")) Then Me.txtRepresentanteOperacionesTelefono.Text = Trim(MyRow.Item("RepresentanteOperacionesTelefono"))
            If Not IsDBNull(MyRow.Item("RepresentanteOperacionesEmail")) Then Me.txtRepresentanteOperacionesEmail.Text = Trim(MyRow.Item("RepresentanteOperacionesEmail"))



        Next

    End Sub

    Sub Actualizar()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try

            Dim Sql As String
            Sql = "UPDATE Configuracion " &
                     "SET " &
                     "	NombreCompania = @NombreCompania, " &
                     "	RNC = @RNC, " &
                     "	Telefono = @Telefono, " &
                     "	Email = @Email, " &
                     "	Web = @Web, " &
                     "	Representante = @Representante, " &
                     "	RepresentanteCargo = @RepresentanteCargo, " &
                     "	RegistroMercantil = @RegistroMercantil, " &
                     "	ResolucionCertificadoCorredor = @ResolucionCertificadoCorredor, " &
                     "	RepresentanteOperaciones = @RepresentanteOperaciones, " &
                     "	RepresentanteOperacionesCargo = @RepresentanteOperacionesCargo, " &
                     "	RepresentanteOperacionesTelefono = @RepresentanteOperacionesTelefono, " &
                     "	RepresentanteOperacionesEmail = @RepresentanteOperacionesEmail"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)


            cmd.Parameters.Add(New SqlParameter("@NombreCompania", SqlDbType.NChar)).Value = IIf(Me.txtNombreCompania.Text.Length > 0, Me.txtNombreCompania.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RNC", SqlDbType.NChar)).Value = IIf(Me.txtRNC.Text.Length > 0, Me.txtRNC.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.NChar)).Value = IIf(Me.txtTelefono.Text.Length > 0, Me.txtTelefono.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.NChar)).Value = IIf(Me.txtEmail.Text.Length > 0, Me.txtEmail.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Web", SqlDbType.NChar)).Value = IIf(Me.txtWeb.Text.Length > 0, Me.txtWeb.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RegistroMercantil", SqlDbType.NChar)).Value = IIf(Me.txtRegistroMercantil.Text.Length > 0, Me.txtRegistroMercantil.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@ResolucionCertificadoCorredor", SqlDbType.NChar)).Value = IIf(Me.txtResolucionCertificadoCorredor.Text.Length > 0, Me.txtResolucionCertificadoCorredor.Text, DBNull.Value)


            cmd.Parameters.Add(New SqlParameter("@Representante", SqlDbType.NChar)).Value = IIf(Me.txtRepresentante.Text.Length > 0, Me.txtRepresentante.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RepresentanteCargo", SqlDbType.NChar)).Value = IIf(Me.txtRepresentanteCargo.Text.Length > 0, Me.txtRepresentanteCargo.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@RepresentanteOperaciones", SqlDbType.NChar)).Value = IIf(Me.txtRepresentanteOperaciones.Text.Length > 0, Me.txtRepresentanteOperaciones.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RepresentanteOperacionesCargo", SqlDbType.NChar)).Value = IIf(Me.txtRepresentanteOperacionesCargo.Text.Length > 0, Me.txtRepresentanteOperacionesCargo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RepresentanteOperacionesTelefono", SqlDbType.NChar)).Value = IIf(Me.txtRepresentanteOperacionesTelefono.Text.Length > 0, Me.txtRepresentanteOperacionesTelefono.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RepresentanteOperacionesEmail", SqlDbType.NChar)).Value = IIf(Me.txtRepresentanteOperacionesEmail.Text.Length > 0, Me.txtRepresentanteOperacionesEmail.Text, DBNull.Value)


            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Configuración", "EditarConfiguracion", csql)



        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try


    End Sub


End Class