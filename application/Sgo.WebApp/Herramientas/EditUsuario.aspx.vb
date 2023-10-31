Imports System.Data.SqlClient
Imports Telerik.Web.UI

''' <summary>
''' 
''' </summary>
Partial Class EditUsuario
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("cmd") = Request.QueryString("cmd")
            If ViewState("cmd") = "" Then
                ViewState("cmd") = Session("Editar")
            End If

            If ViewState("cmd") = "new" Then
                txtFind.Focus()
            End If
            If ViewState("cmd") = "edit" Then
                ViewState("Id") = Session("Code")
                CargaDetalles(ViewState("Id"))
            End If
        End If
    End Sub
    Function Actualizar(Id As String) As String
        Dim _strFecha As String
        If (RadComboBox3.SelectedValue = "I") Then
            _strFecha = "getdate()"

        Else
            _strFecha = "FechaInactivo"
        End If



        Dim Cnx As SqlConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("CN").ConnectionString)
        Dim Sql As String

        Sql = "UPDATE  TBL_Usuarios  SET  Nombre=@Nombre,CorreoElectronico=@CorreoElectronico,NombreUsuario =@NombreUsuario,IdPerfil=@IdPerfil,IdEstatus=@IdEstatus,FechaInactivo= " & _strFecha & ",IdUsuarioModifica = " & Session("IdUsuario") & "  where  IdUsuario ='" & Id & "'"

        Try
            Cnx.Open()
            Dim Cmd As New SqlCommand(Sql, Cnx)
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = IIf(Me.txtNombre.Text.Length > 0, Me.txtNombre.Text, DBNull.Value)
            Cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = IIf(Me.txtCorreoElectronico.Text.Length > 0, Me.txtCorreoElectronico.Text, DBNull.Value)
            Cmd.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = IIf(Me.txtNombreUsuario.Text.Length > 0, Me.txtNombreUsuario.Text, DBNull.Value)
            Cmd.Parameters.Add("@IdPerfil", SqlDbType.VarChar).Value = IIf(RadComboBox1.SelectedValue <> Nothing, RadComboBox1.SelectedValue, DBNull.Value)
            Cmd.Parameters.Add("@IdEstatus", SqlDbType.VarChar).Value = IIf(RadComboBox3.SelectedValue <> Nothing, RadComboBox3.SelectedValue, DBNull.Value)

            Cmd.ExecuteNonQuery()

            Return ""

        Catch ex As Exception
            Return ex.Message

        Finally
            Cnx.Close()
        End Try
    End Function
    Function Insertar() As String
        Dim Sql As String = "INSERT INTO   TBL_Usuarios  (Nombre,CorreoElectronico,NombreUsuario,IdPerfil,IdEstatus,IdUsuarioCreacion) VALUES (@Nombre,@CorreoElectronico,@NombreUsuario,@IdPerfil,@IdEstatus,@IdUsuarioCreacion)"
        Dim Cnx As SqlConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("CN").ConnectionString)
        Try
            Cnx.Open()
            Dim Cmd As New SqlCommand(Sql, Cnx)
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = IIf(Me.txtNombre.Text.Length > 0, Me.txtNombre.Text, DBNull.Value)
            Cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = IIf(Me.txtCorreoElectronico.Text.Length > 0, Me.txtCorreoElectronico.Text, DBNull.Value)
            Cmd.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = IIf(Me.txtNombreUsuario.Text.Length > 0, Me.txtNombreUsuario.Text, DBNull.Value)
            Cmd.Parameters.Add("@IdPerfil", SqlDbType.VarChar).Value = IIf(RadComboBox1.SelectedValue <> Nothing, RadComboBox1.SelectedValue, DBNull.Value)
            Cmd.Parameters.Add("@IdEstatus", SqlDbType.VarChar).Value = IIf(RadComboBox3.SelectedValue <> Nothing, RadComboBox3.SelectedValue, DBNull.Value)
            Cmd.Parameters.Add("@IdUsuarioCreacion", SqlDbType.Int).Value = IIf(Session("IdUsuario") <> Nothing, Session("IdUsuario"), DBNull.Value)
            Cmd.ExecuteNonQuery()
            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cnx.Close()
        End Try
    End Function

    Sub CargaDetalles(ByVal Id As String)
        On Error Resume Next
        Dim Sql As String = "Select * from TBL_Usuarios where IdUsuario='" & Id & "'"
        Dim Ds As DataSet = oper.ExDataSet(Sql)
        Dim Row As DataRow
        For Each Row In Ds.Tables(0).Rows

            If Not IsDBNull(Row.Item("Nombre")) Then Me.txtNombre.Text = Row.Item("Nombre")
            If Not IsDBNull(Row.Item("CorreoElectronico")) Then Me.txtCorreoElectronico.Text = Row.Item("CorreoElectronico")
            If Not IsDBNull(Row.Item("NombreUsuario")) Then Me.txtNombreUsuario.Text = Row.Item("NombreUsuario")
            If Not IsDBNull(Row.Item("IdPerfil")) Then RadComboBox1.SelectedValue = Row.Item("IdPerfil")
            If Not IsDBNull(Row.Item("IdEstatus")) Then RadComboBox3.SelectedValue = Row.Item("IdEstatus")

            RadToolBar1.Enabled = True
        Next
    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar
            Me.Validate()
            If Me.IsValid = False Then Exit Sub
            lblmsg.Text = ""
            If ViewState("cmd") = "edit" Then
                Dim Resultado As String = Actualizar(ViewState("Id"))
                If Resultado = "" Then
                    With lblmsg
                        .ForeColor = Drawing.Color.Blue
                        .Text = "Guardado correctamente."
                        .CssClass = "correcto"
                    End With

                Else

                End If
            End If

            If ViewState("cmd") = "new" Then
                Dim Resultado As String = Insertar()
                'MsgBox(GuardoBien)
                If Resultado = "" Then
                    With lblmsg
                        .ForeColor = Drawing.Color.Blue
                        .Text = "Guardado correctamente."
                        .CssClass = "correcto"
                    End With
                    ViewState("cmd") = "edit"
                Else

                End If
            End If

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then ' Borrar
            InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If
    End Sub

    Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim aAuthent As BVRD.Security.Utils.LDapAuthenticate
        aAuthent = New BVRD.Security.Utils.LDapAuthenticate()

        Dim seachPatter As String = txtFind.Text

        RadToolBar1.Enabled = False
        lblmsg.Text = ""

        txtFind.Text = String.Empty
        txtNombre.Text = String.Empty
        txtCorreoElectronico.Text = String.Empty
        txtNombreUsuario.Text = String.Empty

        If seachPatter.Length >= 3 Then
            Dim AppDomain As String = ConfigurationManager.AppSettings("AppDomain").ToString()

            If (Not aAuthent.SetDomain(AppDomain)) Then
                Return
            End If

            aAuthent.SetAuthenticationType(False)

            Dim users As List(Of BVRD.Security.Utils.Users)

            users = aAuthent.GetADUsers

            Dim item As BVRD.Security.Utils.Users
            item = New BVRD.Security.Utils.Users()

            For Each item In users
                Dim DisplayName As String = item.DisplayName
                Dim UserName As String = item.UserName

                If DisplayName.ToLower.Contains(seachPatter.ToLower) Or UserName.ToLower.Contains(seachPatter.ToLower) Then
                    txtNombre.Text = item.DisplayName

                    Dim _Email As String()

                    _Email = item.Email.Split("^")

                    txtCorreoElectronico.Text = _Email(0)
                    txtNombreUsuario.Text = item.UserName

                    Dim Sql As String = "Select * from TBL_Usuarios where NombreUsuario ='" & UserName & "'"
                    Dim Ds As DataSet = oper.ExDataSet(Sql)

                    If Ds.Tables(0).Rows.Count > 0 Then
                        lblmsg.Text = "Usuario " + UserName + " existe en el sistema, Verifique!"

                        RadToolBar1.Enabled = False
                    Else
                        RadToolBar1.Enabled = True
                    End If

                End If
            Next
        End If

    End Sub
End Class
