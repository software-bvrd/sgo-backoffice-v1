Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class EditarUsuariosSiopel
    Inherits System.Web.UI.Page
    Private oper As New operation

#Region "Inicio de la Página"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        ViewState("EsNuevo") = Request.QueryString("EsNuevo")

        If Session("Ajax") = True Then
            ViewState("Code") = Session("Code")
        Else
            ViewState("Code") = Request.QueryString("BO_Usuarios_Siopel_TID")
        End If

        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = True
        End If

        If IsPostBack = False Then
            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If
        End If

        'Borrar istrumento  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If



    End Sub

    Private Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then ' Guardar

            If ViewState("EsNuevo") = True Then
                Call Nuevo()
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Actualizar()
            End If

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then  ' Borrar
            InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

#End Region

#Region "Procedimientos del Usuario"

    Sub Nuevo()
        Try
            If ViewState("EsNuevo") = True Then
                Dim Check As String
                Check = CheckBox1.Checked

                oper.ExecuteNonQuery("INSERT INTO BO_Usuarios_Siopel_T (Nombre,CodigoEntidad, Agente,BO_TipoUsuarios_Siopel_TID, PuestoBolsaID, UsuarioSiopelID, Activo) VALUES ('" _
                                     & txtNombre.Text & "','" _
                                     & txtCodigoEntidad.Text & "','" _
                                     & txtAgente.Text & "','" _
                                     & Me.RadComboBox1.SelectedValue & "','" _
                                     & IIf(Me.RadComboPuestoBolsa.SelectedValue = 999, "NULL", Me.RadComboPuestoBolsa.SelectedValue) & "','" _
                                     & txtNombre.SelectedValue & "','" _
                                     & Check & "')")


            End If
        Catch ex As Exception

        End Try


    End Sub

    Sub Editar()

        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [BO_Usuarios_Siopel_T]  where BO_Usuarios_Siopel_TID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows

            ' If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))

            ' 2017.11.14
            ' Código que combina corredores y ejecutivos de participantes de mercado
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.SelectedValue = Trim(MyRow.Item("UsuarioSiopelID"))


            If Not IsDBNull(MyRow.Item("Agente")) Then Me.txtAgente.Text = Trim(MyRow.Item("Agente"))
            If Not IsDBNull(MyRow.Item("BO_TipoUsuarios_Siopel_TID")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("BO_TipoUsuarios_Siopel_TID"))

            If Not IsDBNull(MyRow.Item("PuestoBolsaID")) Then
                Me.RadComboPuestoBolsa.SelectedValue = Trim(MyRow.Item("PuestoBolsaID"))
                txtCodigoEntidad.Enabled = True
            End If

            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activo"))

            '2016.02.23
            If Not IsDBNull(MyRow.Item("CodigoEntidad")) Then Me.txtCodigoEntidad.Text = Trim(MyRow.Item("CodigoEntidad"))


        Next

    End Sub

    Sub Actualizar()
        Dim Check As String
        Check = CheckBox1.Checked

        Dim cSql As String = "Update [BO_Usuarios_Siopel_T] set  Nombre='" & txtNombre.SelectedValue _
                                                                           & "', CodigoEntidad='" _
                                                                           & txtCodigoEntidad.Text _
                                                                           & "', Agente='" _
                                                                           & txtAgente.Text _
                                                                           & "', BO_TipoUsuarios_Siopel_TID = '" _
                                                                           & RadComboBox1.SelectedValue _
                                                                           & "', PuestoBolsaID = '" _
                                                                           & IIf(RadComboPuestoBolsa.SelectedValue = 999, "NULL", RadComboPuestoBolsa.SelectedValue) _
                                                                           & "', Activo='" _
                                                                           & Check _
                                                                           & "'  where BO_Usuarios_Siopel_TID='" _
                                                                           & CInt(ViewState("Code")) _
                                                                           & "'"

        oper.ExecuteNonQuery(cSql)

        ViewState("EsNuevo") = False
    End Sub

    Sub Borrar()
        If oper.ExecuteNonQuery("delete from dbo.BO_Usuarios_Siopel_T where BO_Usuarios_Siopel_TID='" & ViewState("Code") & "'") Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro.')</" + "script>"
        End If
    End Sub

#End Region

#Region "Operaciones Globales"
    Protected Sub RadComboPuestoBolsa_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboPuestoBolsa.SelectedIndexChanged


    End Sub

    Protected Function BuscarNombreAgenteSiopel()

        Dim cNombreAgente As String = ""

        Dim constring As String = ConfigurationManager.ConnectionStrings("CNSIOPEL").ConnectionString
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("SELECT deno FROM [siopel_owner].[agentes] where agente ='" + txtAgente.Text.Trim() + "'", con)
                cmd.CommandType = CommandType.Text
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    cNombreAgente = dr("deno").ToString()
                End While
                con.Close()
            End Using
        End Using

        Return cNombreAgente

    End Function

    Protected Sub txtNombre_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles txtNombre.SelectedIndexChanged
        Dim cTexto As String = txtNombre.SelectedValue

    End Sub

#End Region

End Class