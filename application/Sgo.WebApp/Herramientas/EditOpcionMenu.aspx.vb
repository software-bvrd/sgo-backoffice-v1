Imports System.Data.SqlClient
Imports System.Data
Imports Telerik.Web.UI

Partial Class EditOpcionMenu
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ViewState("cmd") = Request.QueryString("cmd")
            If ViewState("cmd") = "" Then
                ViewState("cmd") = Session("Editar")
            End If
            If ViewState("cmd") = "new" Then
                TextBox1.Text = oper.GetSecuence("OpcionesMenu", "IdOpcion")
                TextBox2.Focus()
            End If

            If ViewState("cmd") = "edit" Then
                ViewState("Id") = Session("Code")
                CargaDetalles(ViewState("Id"))
            End If

        End If
    End Sub
    Function Actualizar(Id As String) As String
        Dim Sql As String = " UPDATE  OpcionesMenu  SET Nombre =@Nombre,Url=@Url ,Parametro=@Parametro ,IdPadre=@IdPadre ,OrdenDespliegue=@OrdenDespliegue ,Estatus=@Estatus where  IdOpcion ='" & Id & "'"
        Dim Cnx As SqlConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("CN").ConnectionString)

        CambiarOrdenDespliegue(RadComboBox1.SelectedValue, cbOrdenDespliegue.SelectedValue)

        Try
            Cnx.Open()
            Dim Cmd As New SqlCommand(Sql, Cnx)
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = IIf(TextBox2.Text.Length > 0, TextBox2.Text, DBNull.Value)
            Cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = IIf(TextBox3.Text.Length > 0, TextBox3.Text, DBNull.Value)
            Cmd.Parameters.Add("@Parametro", SqlDbType.VarChar).Value = IIf(TextBox4.Text.Length > 0, TextBox4.Text, DBNull.Value)
            Cmd.Parameters.Add("@IdPadre", SqlDbType.VarChar).Value = IIf(RadComboBox1.SelectedValue <> "0", RadComboBox1.SelectedValue, DBNull.Value)
            Cmd.Parameters.Add("@OrdenDespliegue", SqlDbType.VarChar).Value = IIf(cbOrdenDespliegue.SelectedValue > 0, cbOrdenDespliegue.SelectedValue, DBNull.Value)
            Cmd.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = IIf(RadComboBox3.SelectedValue <> Nothing, RadComboBox3.SelectedValue, DBNull.Value)
            Cmd.ExecuteNonQuery()
            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cnx.Close()

            RenumerarOrdenDespliegue(RadComboBox1.SelectedValue)

        End Try
    End Function
    Function Insertar() As String
        Dim Sql As String = "INSERT INTO  OpcionesMenu (Nombre ,Url ,Parametro ,IdPadre ,OrdenDespliegue ,Estatus) VALUES (@Nombre ,@Url ,@Parametro ,@IdPadre ,@OrdenDespliegue ,@Estatus)"
        Dim Cnx As SqlConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("CN").ConnectionString)

        CambiarOrdenDespliegue(RadComboBox1.SelectedValue, cbOrdenDespliegue.SelectedValue)

        Try
            Cnx.Open()
            Dim Cmd As New SqlCommand(Sql, Cnx)
            'Cmd.Parameters.Add("@IdOpcion", SqlDbType.Int).Value = IIf(TextBox1.Text.Length > 0, TextBox1.Text, DBNull.Value) ''Now.Date
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = IIf(TextBox2.Text.Length > 0, TextBox2.Text, DBNull.Value)
            Cmd.Parameters.Add("@Url", SqlDbType.VarChar).Value = IIf(TextBox3.Text.Length > 0, TextBox3.Text, DBNull.Value)
            Cmd.Parameters.Add("@Parametro", SqlDbType.VarChar).Value = IIf(TextBox4.Text.Length > 0, TextBox4.Text, DBNull.Value)
            'Cmd.Parameters.Add("@IdPadre", SqlDbType.VarChar).Value = IIf(RadComboBox1.SelectedValue <> Nothing, RadComboBox1.SelectedValue, DBNull.Value)
            Cmd.Parameters.Add("@IdPadre", SqlDbType.VarChar).Value = IIf(RadComboBox1.SelectedValue <> "0", RadComboBox1.SelectedValue, DBNull.Value)
            Cmd.Parameters.Add("@OrdenDespliegue", SqlDbType.VarChar).Value = IIf(cbOrdenDespliegue.SelectedValue > 0, cbOrdenDespliegue.SelectedValue, DBNull.Value)
            Cmd.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = IIf(RadComboBox3.SelectedValue <> Nothing, RadComboBox3.SelectedValue, DBNull.Value)
            Cmd.ExecuteNonQuery()
            Return ""
        Catch ex As Exception
            Return ex.Message

        Finally
            Cnx.Close()

            RenumerarOrdenDespliegue(RadComboBox1.SelectedValue)
        End Try
    End Function

    Sub CargaDetalles(ByVal Id As String)
        On Error Resume Next
        Dim Sql As String = "Select * from OpcionesMenu where IdOpcion='" & Id & "'"
        Dim Ds As DataSet = oper.ExDataSet(Sql)
        Dim Row As DataRow
        For Each Row In Ds.Tables(0).Rows
            If Not IsDBNull(Row.Item("IdOpcion")) Then TextBox1.Text = Row.Item("IdOpcion")
            If Not IsDBNull(Row.Item("Nombre")) Then TextBox2.Text = Row.Item("Nombre")
            If Not IsDBNull(Row.Item("Url")) Then TextBox3.Text = Row.Item("Url")
            If Not IsDBNull(Row.Item("Parametro")) Then TextBox4.Text = Row.Item("Parametro")
            If Not IsDBNull(Row.Item("IdPadre")) Then RadComboBox1.SelectedValue = Row.Item("IdPadre")
            If Not IsDBNull(Row.Item("OrdenDespliegue")) Then cbOrdenDespliegue.SelectedValue = Row.Item("OrdenDespliegue")
            If Not IsDBNull(Row.Item("Estatus")) Then RadComboBox3.SelectedValue = Row.Item("Estatus")
        Next
    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then 'Guardar
            Me.Validate()
            If Me.IsValid = False Then Exit Sub
            'MsgBox(ViewState("cmd"))
            lblmsg.Text = ""
            If ViewState("cmd") = "edit" Then
                Dim Resultado As String = Actualizar(TextBox1.Text)
                If Resultado = "" Then
                    '   Call Volver()
                    lblmsg.Text = "Guardado correctamente."
                    lblmsg.CssClass = "correcto"
                Else
                    RequiredFieldValidator5.ErrorMessage = Resultado
                    RequiredFieldValidator5.IsValid = False
                End If
            End If
            If ViewState("cmd") = "new" Then
                Dim Resultado As String = Insertar()
                'MsgBox(GuardoBien)
                If Resultado = "" Then
                    ''   Response.Redirect("Default.aspx")
                    ' Call Volver()
                    lblmsg.Text = "Guardado correctamente."
                    lblmsg.CssClass = "correcto"
                    ViewState("cmd") = "edit"
                Else
                    RequiredFieldValidator5.ErrorMessage = Resultado
                    RequiredFieldValidator5.IsValid = False
                End If
            End If
        ElseIf e.Item.Value = 1 Then 'Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If
    End Sub
    Protected Sub CambiarOrdenDespliegue(nIdpadre As Integer, nOrdenDespliegue As Integer)
        Dim Sql As String = "Update OpcionesMenu Set OrdenDespliegue = OrdenDespliegue + 1 where IdPadre = " & nIdpadre.ToString & " And OrdenDespliegue >=" & nOrdenDespliegue.ToString
        oper.ExecuteNonQuery(Sql)
    End Sub
    Protected Sub RenumerarOrdenDespliegue(nIdpadre As Integer)
        Dim Sql As String = "Select * from OpcionesMenu where IdPadre = " & nIdpadre.ToString & " Order by OrdenDespliegue "
        Dim Ds As DataSet = oper.ExDataSet(Sql)
        Dim Row As DataRow
        Dim i As Integer = 1
        For Each Row In Ds.Tables(0).Rows
            Sql = "Update OpcionesMenu Set OrdenDespliegue = " & i.ToString & " where IdPadre = " & nIdpadre.ToString & " And OrdenDespliegue = " & Row.Item("OrdenDespliegue").ToString
            oper.ExecuteNonQuery(Sql)
            i = i + 1
        Next
    End Sub
End Class
