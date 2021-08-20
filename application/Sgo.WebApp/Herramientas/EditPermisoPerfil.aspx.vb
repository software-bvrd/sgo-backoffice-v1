Imports System.Data.SqlClient
Imports System.Data
Imports Telerik.Web.UI


Partial Class EditPermiso_Perfil
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            
            ViewState("cmd") = Request.QueryString("cmd")
            If ViewState("cmd") = "" Then
                ViewState("cmd") = Session("Editar")
            End If

            If ViewState("cmd") = "new" Then
                ViewState("Id") = ""
            End If
            If ViewState("cmd") = "edit" Then
                ViewState("Id") = Session("IdPerfil")
            End If
        End If
    End Sub

    Private Sub InsertarPermisos(pIdOpcion As Integer, pIdPerfil As Integer)
        Dim Cnx As SqlConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("CN").ConnectionString)
        Try
            Dim Sql As String = "INSERT INTO   PermisosPorPerfil  (IdOpcion,IdPerfil)VALUES (@IdOpcion,@IdPerfil)"
            Cnx.Open()
            Dim Cmd As New SqlCommand(Sql, Cnx)
            Cmd.Parameters.Add("@IdOpcion", SqlDbType.Int).Value = pIdOpcion
            Cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = pIdPerfil
            Cmd.ExecuteNonQuery()
        Catch ex As Exception

        Finally
            Cnx.Close()
        End Try

    End Sub
    Private Function VerificarPerfil(pIdPerfil As Integer) As Boolean
        Dim PerfilAsignado As String = oper.ExecuteScalar("SELECT Count(*) FROM dbo.PermisosPorPerfil WHERE IdPerfil='" & CStr(pIdPerfil) & "'")
        If Integer.Parse(PerfilAsignado) > 0 Then
            Return True
        End If
        Return False
    End Function
    Private Function OpcionMenu(pNombreMenu As String) As Integer
        Dim IdOpcion As String = oper.ExecuteScalar("SELECT IdOpcion FROM OpcionesMenu WHERE Nombre='" & pNombreMenu & "'")
        Return IdOpcion
    End Function


    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar
            lblMsg.Text = ""
            If rtvOpcionesMenu.CheckedNodes.Count = 0 Then
                lblMsg.ForeColor = Drawing.Color.Red
                lblMsg.Text = "No hay opciones de menu seleccionadas."
                Exit Sub
            End If
            If ViewState("cmd") = "new" Then

                If VerificarPerfil(RadComboBox3.SelectedValue) Then
                    lblMsg.ForeColor = Drawing.Color.Red
                    lblMsg.Text = "El perfil ya tiene intems de menu asignados, seleccione uno nuevo."
                Else
                    For Each Val As RadTreeNode In rtvOpcionesMenu.GetAllNodes
                        If Val.Checked Then
                            Dim res As String = oper.ExecuteScalar(" SELECT COUNT(*)  FROM dbo.PermisosPorPerfil  WHERE     (IdPerfil = '" & RadComboBox3.SelectedValue & "') AND (IdOpcion = '" & CStr(OpcionMenu(Val.Text)) & "') ")
                            If res = 0 Then
                                InsertarPermisos(OpcionMenu(Val.Text), RadComboBox3.SelectedValue)
                            End If

                        End If
                    Next
                    RadComboBox3.Enabled = False
                    lblMsg.ForeColor = Drawing.Color.Blue
                    lblMsg.Text = "Guardado correctamente."

                    ViewState("cmd") = "edit"
                    Exit Sub
                End If


            End If

            If ViewState("cmd") = "edit" Then

                For Each Val As RadTreeNode In rtvOpcionesMenu.GetAllNodes
                    If Val.Checked Then
                        Dim res As String = oper.ExecuteScalar(" SELECT COUNT(*)  FROM dbo.PermisosPorPerfil  WHERE     (IdPerfil = '" & RadComboBox3.SelectedValue & "') AND (IdOpcion = '" & CStr(OpcionMenu(Val.Text)) & "') ")
                        If res = 0 Then
                            InsertarPermisos(OpcionMenu(Val.Text), RadComboBox3.SelectedValue)
                        End If
                    Else
                        oper.ExecuteScalar("DELETE  FROM dbo.PermisosPorPerfil  WHERE     (IdPerfil = '" & RadComboBox3.SelectedValue & "') AND (IdOpcion = '" & CStr(OpcionMenu(Val.Text)) & "') ")

                    End If
                    RadComboBox3.Enabled = False
                    lblMsg.ForeColor = Drawing.Color.Blue
                    lblMsg.Text = "Guardado correctamente."
                Next

            End If

        ElseIf e.Item.Value = 2 Then
            'InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then
            ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        End If
    End Sub
    Protected Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        rtvOpcionesMenu.ExpandAllNodes()
        If ViewState("Id") <> "" Then
            Dim Sql As String = "Select Nombre from vPermisosPorPerfil where IdPerfil='" & ViewState("Id") & "'"
            Dim Ds As DataSet = oper.ExDataSet(Sql)
            Dim Row As DataRow
            For Each Row In Ds.Tables(0).Rows
                Dim p As String = Row.Item("Nombre")
                If Not IsDBNull(Row.Item("Nombre")) Then
                    Dim pa As RadTreeNode = rtvOpcionesMenu.FindNodeByText(Row.Item("Nombre"))
                    Dim paa As Integer = pa.Value
                    pa.Checked = True
                End If
            Next
        End If
    End Sub

    Protected Sub RadComboBox3_DataBound(sender As Object, e As EventArgs) Handles RadComboBox3.DataBound
        If ViewState("cmd") = "edit" Then
            RadComboBox3.SelectedValue = ViewState("Id")
            RadComboBox3.Enabled = False
        Else
            Dim Sql As String = "Select distinct IdPerfil from dbo.vPermisosPorPerfil"
            Dim Ds As DataSet = oper.ExDataSet(Sql)
            Dim Row As DataRow
            RadComboBox3.FindItemByValue(0).Enabled = False
            For Each Row In Ds.Tables(0).Rows
                Dim p As Integer = CInt(Row.Item("IdPerfil"))
                RadComboBox3.FindItemByValue(CInt(Row.Item("IdPerfil"))).Enabled = False
            Next
            RadComboBox3.SelectedValue = "-1"
        End If

    End Sub
End Class





