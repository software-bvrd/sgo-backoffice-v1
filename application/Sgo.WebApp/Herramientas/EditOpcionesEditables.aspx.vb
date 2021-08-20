Imports System.Data.SqlClient
Imports System.Data
Imports Telerik.Web.UI


Partial Class EditOpcionesEditables
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
                ViewState("Id") = Session("Code")
                Dim NombreUsuario As String = oper.ExecuteScalar("Select NombreUsuario FROM  [dbo].[TBL_Usuarios] where IdUsuario='" & ViewState("Id") & "'")
                lbNombreUsuario.Text = NombreUsuario
            End If
        End If
    End Sub

    Private Sub InsertarPermisos(pIdUsuario As Integer, pIdOpcionesMenu As Integer)
        Dim Cnx As SqlConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("CN").ConnectionString)
        Try
            Dim Sql As String = "INSERT INTO   OpcionesEditables  (IdUsuario,IdOpcionesMenu)VALUES (@IdUsuario,@IdOpcionesMenu)"
            Cnx.Open()
            Dim Cmd As New SqlCommand(Sql, Cnx)
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = pIdUsuario
            Cmd.Parameters.Add("@IdOpcionesMenu", SqlDbType.Int).Value = pIdOpcionesMenu
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
        Dim IdOpcionesMenu As String = oper.ExecuteScalar("SELECT IdOpcion FROM OpcionesMenu WHERE Nombre='" & pNombreMenu & "'")
        Return IdOpcionesMenu
    End Function


    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar
            lblMsg.Text = ""


            If ViewState("cmd") = "edit" Then

                For Each Val As RadTreeNode In rtvOpcionesMenu.GetAllNodes
                    If Val.Checked Then
                        Dim res As String = oper.ExecuteScalar(" SELECT COUNT(*)  FROM dbo.OpcionesEditables  WHERE     (IdUsuario = '" & ViewState("Id") & "') AND (IdOpcionesMenu = '" & CStr(OpcionMenu(Val.Text)) & "') ")
                        If res = 0 Then
                            InsertarPermisos(ViewState("Id"), OpcionMenu(Val.Text))
                        End If
                    Else
                        oper.ExecuteScalar("DELETE  FROM dbo.OpcionesEditables  WHERE  (IdUsuario = '" & ViewState("Id") & "') AND (IdOpcionesMenu = '" & CStr(OpcionMenu(Val.Text)) & "') ")

                    End If
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

        ' Expandir el Arbol de opciones
        rtvOpcionesMenu.ExpandAllNodes()

        If ViewState("Id") <> "" Then
            Dim Sql As String = "SELECT om.Nombre
                                FROM [dbo].[OpcionesEditables] oe
                                inner join dbo.OpcionesMenu om 
                                on om.IdOpcion=oe.IdOpcionesMenu 
                                where om.Nombre not in ('Archivos','Edición','Herramientas') and oe.IdUsuario='" & ViewState("Id") & "'"
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


End Class





