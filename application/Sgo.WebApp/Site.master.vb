Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.IO

Partial Class Site
    Inherits MasterPage
    Private oper As New operation
    Private nCantidadOpcionesMenu As Integer = 0

    Dim boConn As Connection.Connection.DBConnection = New Connection.Connection.DBConnection()

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim nIdPadre As Integer = 0
        Dim nOrden As Integer = 0
        Dim nIdHijo As Integer = 0
        Dim nIdHijo1 As Integer = 0


        ' Verificar si la carpeta tmp Existe

        Dim directoryPath As String = Server.MapPath(String.Format("~/{0}/", "tmp"))
        If Not Directory.Exists(directoryPath) Then
            Directory.CreateDirectory(directoryPath)
        End If
               

        '-------------------------------------------------------------------------------------------------------------------------
        'If Session("IdPerfil") = Nothing Then
        '    Session.Abandon()
        '    FormsAuthentication.SignOut()
        '    Exit Sub
        'End If

        '' Los usuarios SuperAdministradores no tienen restrincion de acceso
        'If Session("IdPerfil") = "0" Then
        '    SqlDataSource1.SelectCommand = "Select * from OpcionesMenu order by OrdenDespliegue"
        '    SqlDataSource1.DataBind()
        'End If

        ''Validacion de acceso
        'Dim Pag As String = Path.GetFileName(Request.Path)
        'If Session("IdPerfil") <> "0" Then
        '    If Pag.ToLower <> "default.aspx" Then
        '        Dim Res As String = oper.ExecuteScalar("Select Url from vPermisosPorPerfil where IdPerfil='" & Session("IdPerfil") & "' and Url='" & Pag.ToLower & "'")
        '        If Res = "" Then Response.Redirect("Default.aspx")
        '    End If
        'End If
        '------------------------------------------------------------------------------------------------------------------------
        If Session("MyUserName") = Nothing Then
            RadMenu1.Visible = False
            HeadLoginView.Visible = False
        Else
            RadMenu1.Visible = True
            HeadLoginView.Visible = True

            ' LBUserName.text = ""
        End If
        ' -----------------------------------------------------------------------------
        ' Evaluar menu para determinar si las opciones de su perfil estan disponibles.
        ' -----------------------------------------------------------------------------
        If IsPostBack = False Then
            ' CantidadRegistrosMenuOpciones()
            If oper.ExecuteScalar("Select count(*) from OpcionesMenu") = 0 Then
                With RadMenu1
                    For Each item As RadMenuItem In .GetAllItems()
                        nOrden += 1
                        If item.Level = 0 Then
                            nIdPadre = 0
                            If Not item.IsSeparator Then
                                ActualizarTablaOpcionesMenu(item.Text, nIdPadre, nOrden)
                            End If
                        End If
                        If item.Level = 0 Then
                            nIdPadre = RetornarIdMenuPadre(item.Text)
                        End If
                        If item.Level = 1 Then
                            If Not item.IsSeparator Then
                                ActualizarTablaOpcionesMenu(item.Text, nIdPadre, nOrden)
                                nIdHijo = RetornarIdMenuPadre(item.Text)
                            End If
                        End If
                        If item.Level = 2 Then
                            If Not item.IsSeparator Then
                                ActualizarTablaOpcionesMenu(item.Text, nIdHijo, nOrden)
                                nIdHijo1 = RetornarIdMenuPadre(item.Text)
                            End If
                        End If
                        If item.Level = 3 Then
                            If Not item.IsSeparator Then
                                ActualizarTablaOpcionesMenu(item.Text, nIdHijo1, nOrden)
                            End If
                        End If
                    Next
                    .DataBind()
                End With
                oper.ExecuteScalar("update dbo.OpcionesMenu set [IdPadre]  = NULL where IdPadre = 0")
            End If

            For Each item As RadMenuItem In RadMenu1.GetAllItems()
                If item.Level > 0 Then 'Opciones de Menú fuera de la barra principal, si se desea evaluar el menu principal, comentar esta línea. 
                    ' Evaluar cada opción, si no esta en el perfíl del usuario deshabilitar.
                    ' <-- -->
                    If Not item.IsSeparator Then
                        If CInt(Session("IdPerfil")) > 0 Then
                            If Not VerificarOpcionAsignadaAusuario(item.Text, Session("IdPerfil")) Then
                                item.Enabled = False
                            End If
                        End If
                    End If
                End If
            Next
        End If

    End Sub

    ' --------------------------------------------------------------------------------
    ' Retornar ID Menu Padre.
    ' --------------------------------------------------------------------------------
    Private Function RetornarIdMenuPadre(ByVal cNombreOpcion As String) As Integer
        Dim MenuID As Integer = 0
        Try
            Dim cStringSql As String = String.Format("Select IdOpcion from OpcionesMenu where Nombre = '{0}'", cNombreOpcion.Trim)
            Dim cmd As New SqlCommand(cStringSql, boConn.Connect())
            MenuID = cmd.ExecuteScalar()
        Catch ex As Exception
        Finally
            boConn.Disconnect()
        End Try

        Return MenuID
    End Function

    ' --------------------------------------------------------------------------------
    ' Verificar si la versión del programa cambio y actualizar las opciones del menú.
    ' --------------------------------------------------------------------------------
    Private Sub ActualizarTablaOpcionesMenu(ByVal cNombreOpcion As String, ByVal nIdMenuPadre As Integer, ByVal nOrden As Integer)
        Dim MenuID As Integer = 0
        Dim stringInsert As String = ""

        Try
            Dim cStringSql As String = String.Format("Select IdOpcion from OpcionesMenu where Nombre = '{0}' and IdPadre={1}", cNombreOpcion.Trim, nIdMenuPadre)
            Dim cmd As New SqlCommand(cStringSql, boConn.Connect())
            MenuID = cmd.ExecuteScalar()
            If MenuID = 0 Then
                ' ---------------------------------------------------------------------------------------------
                ' Insertar en la tabla de opciones : Si la opción cambia de padre puede probocar una repetición
                ' ---------------------------------------------------------------------------------------------
                stringInsert = String.Format("INSERT INTO OpcionesMenu ([Nombre],[Estatus],[IdPadre],[url],[Parametro],[OrdenDespliegue]) VALUES ('{0}',1,{1},'','',{2})", cNombreOpcion.Trim, nIdMenuPadre, nOrden)
                cmd.CommandText = stringInsert
                cmd.ExecuteNonQuery()

            End If

        Catch ex As Exception
        Finally
            boConn.Disconnect()
        End Try

    End Sub

    'Cantidad de opciones de menu en la base de datos
    Private Sub CantidadRegistrosMenuOpciones()
        Try
            Dim cmd As New SqlCommand("Select count(*) from OpcionesMenu", boConn.Connect())
            nCantidadOpcionesMenu = cmd.ExecuteScalar()
        Catch ex As Exception
        Finally
            boConn.Disconnect()
        End Try

    End Sub

    ' --------------------------------------------------------------------------------
    ' Verificar si la Opción del menú esta asociada al Perfil.
    ' --------------------------------------------------------------------------------
    Private Function VerificarOpcionAsignadaAusuario(ByVal cOpcion As String, ByVal nPerfil As Integer) As Boolean
        Dim lRetorna As Boolean = False
        Dim nCantidadOpcionesMenu As Integer = 0

        Try


            Dim cStringSql As String = String.Format("Select count(*) from vValidarPerfilOpcionesMenu where Nombre ='{0}' And IdPerfil = {1}", cOpcion.Trim, nPerfil)
            Dim cmd As New SqlCommand(cStringSql, boConn.Connect())
            nCantidadOpcionesMenu = cmd.ExecuteScalar()
            If nCantidadOpcionesMenu > 0 Then
                lRetorna = True
            End If


        Catch ex As Exception

        Finally
            boConn.Disconnect()
        End Try

        Return lRetorna

    End Function

End Class

