Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Telerik.Web.UI
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Telerik.Web.UI.Upload

Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports System.IO.Path
Imports System.Collections
Imports System.ComponentModel

Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI

Imports System.Globalization

Partial Class Formularios_EditarEmpresaCalificadora
    Inherits System.Web.UI.Page
    Private oper As New operation
    Private Documento As String
    Private RutaDocumento As String
    Private CodigoEmpresaCalificadora As New Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If IsPostBack = False Then
            ViewState("EsNuevo") = Request.QueryString("EsNuevo")
            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("EmpresaCalificadoraID")
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If
            RadProgressArea1.ProgressIndicators = RadProgressArea1.ProgressIndicators And Not ProgressIndicators.SelectedFilesCount
        End If

        If Not IsPostBack Then
            Dim RutaN As String = ""
            Dim FileNameN As String = ""
            '0 para cargar desde una bd
            LeerImagen(0)
        End If

        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = False
        End If

        'Borrar empresa calificadora  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If

        txtCodigo.Focus()
        txtCodigo.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll

    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar

            If ViewState("EsNuevo") = True Then
                Call Nuevo()
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Actualizar()
            End If

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then ' Borrar
            InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub
    Sub Nuevo()
        Dim csql As String = ""

        If ViewState("EsNuevo") = True Then
            Dim Check As String
            Check = CheckBox1.Checked
            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            Try
                Documento = ViewState("FileName")
                RutaDocumento = Path.GetTempPath() + Documento

                Dim Sql As String = "INSERT INTO  [EmpresaCalificadora] ([EmpresaCalificadoraCodigo],[Nombre],[Direccion],[Telefono],[Email],[Web],[Activa],[Logo])  VALUES" &
                                                                        "(@EmpresaCalificadoraCodigo,@Nombre,@Direccion,@Telefono,@Email,@Web,@Activa,@Logo)"

                Cnx.Open()
                Dim cmd As New SqlCommand(Sql, Cnx)

                cmd.Parameters.Add(New SqlParameter("@EmpresaCalificadoraID", SqlDbType.BigInt)).Value = IIf(CInt(ViewState("Code")) > 0, CInt(ViewState("Code")), DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@EmpresaCalificadoraCodigo", SqlDbType.VarChar)).Value = IIf(Me.txtCodigo.Text.Length > 0, Me.txtCodigo.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombre.Text.Length > 0, Me.txtNombre.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(Me.txtDireccion.Text.Length > 0, Me.txtDireccion.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(Me.txtTelefono.Text.Length > 0, Me.txtTelefono.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(Me.txtEmail.Text.Length > 0, Me.txtEmail.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Web", SqlDbType.VarChar)).Value = IIf(Me.txtWeb.Text.Length > 0, Me.txtWeb.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Activa", SqlDbType.Bit)).Value = Check

                If RutaDocumento <> Nothing And Documento <> "" Then
                    cmd.Parameters.Add(New SqlParameter("@Logo", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
                Else
                    cmd.Parameters.Add(New SqlParameter("@Logo", SqlDbType.VarBinary)).Value = DBNull.Value
                End If

                cmd.ExecuteNonQuery()
                ViewState("EsNuevo") = True

                csql = oper.CovertirComandoATexto(cmd)
                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Empresa Calificadora", "EmpresaCalificadora", csql)



            Catch sql_ex As SqlClient.SqlException

                If sql_ex.ErrorCode = -2146232060 Then
                    Exit Sub
                End If

            Catch ex As Exception
            Finally
                Guardado.Text = "Guardado con éxito"
                Cnx.Close()
            End Try

        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [EmpresaCalificadora]  where EmpresaCalificadoraID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("EmpresaCalificadoraCodigo")) Then Me.txtCodigo.Text = Trim(MyRow.Item("EmpresaCalificadoraCodigo"))
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Direccion")) Then Me.txtDireccion.Text = Trim(MyRow.Item("Direccion"))
            If Not IsDBNull(MyRow.Item("Telefono")) Then Me.txtTelefono.Text = Trim(MyRow.Item("Telefono"))
            If Not IsDBNull(MyRow.Item("Email")) Then Me.txtEmail.Text = Trim(MyRow.Item("Email"))
            If Not IsDBNull(MyRow.Item("Web")) Then Me.txtWeb.Text = Trim(MyRow.Item("Web"))
            If Not IsDBNull(MyRow.Item("Activa")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activa"))

        Next
    End Sub
    Sub Actualizar()
        Dim Check As String
        Check = CheckBox1.Checked
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""

        Try

            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento
            Dim Sql As String
            If RutaDocumento <> Nothing And Documento <> "" Then
                Sql = "UPDATE  [EmpresaCalificadora] SET [EmpresaCalificadoraCodigo] = @EmpresaCalificadoraCodigo" &
                     ",[Nombre] = @Nombre" &
                     ",[Direccion] = @Direccion" &
                     ",[Telefono] = @Telefono" &
                     ",[Email] = @Email" &
                     ",[Web] = @Web" &
                     ",[Activa] = @Activa" &
                     ",[Logo] = @Logo" &
                     " WHERE EmpresaCalificadoraID = @EmpresaCalificadoraID"
            Else
                Sql = "UPDATE  [EmpresaCalificadora] SET [EmpresaCalificadoraCodigo] = @EmpresaCalificadoraCodigo" &
                     ",[Nombre] = @Nombre" &
                     ",[Direccion] = @Direccion" &
                     ",[Telefono] = @Telefono" &
                     ",[Email] = @Email" &
                     ",[Web] = @Web" &
                     ",[Activa] = @Activa" &
                     " WHERE EmpresaCalificadoraID = @EmpresaCalificadoraID"
            End If

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)
            cmd.Parameters.Add(New SqlParameter("@EmpresaCalificadoraID", SqlDbType.BigInt)).Value = IIf(CInt(ViewState("Code")) > 0, CInt(ViewState("Code")), DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@EmpresaCalificadoraCodigo", SqlDbType.VarChar)).Value = IIf(Me.txtCodigo.Text.Length > 0, Me.txtCodigo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombre.Text.Length > 0, Me.txtNombre.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(Me.txtDireccion.Text.Length > 0, Me.txtDireccion.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(Me.txtTelefono.Text.Length > 0, Me.txtTelefono.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(Me.txtEmail.Text.Length > 0, Me.txtEmail.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Web", SqlDbType.VarChar)).Value = IIf(Me.txtWeb.Text.Length > 0, Me.txtWeb.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Activa", SqlDbType.Bit)).Value = Check

            If RutaDocumento <> Nothing And Documento <> "" Then
                cmd.Parameters.Add(New SqlParameter("@Logo", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
            Else
                cmd.Parameters.Add(New SqlParameter("@Logo", SqlDbType.VarBinary)).Value = DBNull.Value
            End If


            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Empresa Calificadora", "EmpresaCalificadora", csql)



        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Guardado.ForeColor = Color.Blue
            Guardado.Text = "Guardado con éxito"
            LeerImagen(0)
            Cnx.Close()
        End Try

        ViewState("EsNuevo") = False
    End Sub
    Sub Borrar()
        Dim cSql As String = "delete from dbo.EmpresaCalificadora where EmpresaCalificadoraID='" & ViewState("Code") & "'"
        If oper.ExecuteNonQuery(cSql) Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Empresa Calificadora", "EmpresaCalificadora", cSql)

        Else
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro.')</" + "script>"
        End If
    End Sub
    Sub LeerImagen(Metodo As Integer)

        If Metodo = 1 Then '1 Para cargar la imagen desde la carpeta temp
            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento
            ImagenEmpresaCalificadora.DataValue = ConvierteBinario(RutaDocumento)
            ImagenEmpresaCalificadora.Visible = True
        Else '0 para cargar imagen desde bd
            Try
                ImagenEmpresaCalificadora.Visible = True
                Using Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

                    Dim SQL As String = "SELECT Logo FROM EmpresaCalificadora WHERE EmpresaCalificadoraID = " & CInt(ViewState("Code")) & ""
                    Dim myCommand As New SqlCommand(SQL, Cnx)

                    Cnx.Open()
                    Dim myReader As SqlDataReader = myCommand.ExecuteReader()

                    If myReader.Read() Then
                        ImagenEmpresaCalificadora.DataValue = DirectCast(myReader("Logo"), Byte())
                    End If

                    myReader.Close()
                    Cnx.Close()
                End Using
            Catch ex As Exception
                ImagenEmpresaCalificadora.Visible = False
                MensajeLogo.ForeColor = Color.Blue
                MensajeLogo.Text = "Esta empresa calificadora no tiene logo."

            End Try
        End If


    End Sub
    Function SubidaArchivo() As Boolean
        If RadUpload1.UploadedFiles.Count > 0 Then
            Try
                For Each validFile As UploadedFile In RadUpload1.UploadedFiles
                    LooongMethodWhichUpdatesTheProgressContext(validFile)
                    Dim targetFolder As String = Path.GetTempPath()
                    validFile.SaveAs(System.IO.Path.Combine(targetFolder, validFile.GetName()), True)
                    ViewState("FileName") = validFile.GetName()
                    BtnSubirLogo.Enabled = False
                    RadUpload1.Visible = False
                    RadProgressArea1.Visible = False
                    'El numero 1 es cuando se carga la imagen desde un path
                    LeerImagen(1)
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
    Public Function ConvierteBinario(ByVal Path As String) As Byte()
        Dim sPath As String
        sPath = Path
        Dim Ruta As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim Binario(CInt(Ruta.Length)) As Byte
        Ruta.Read(Binario, 0, CInt(Ruta.Length))
        Ruta.Close()
        Return Binario
    End Function
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

            progress.CurrentOperationText = file.GetName() + " is being processed..."
            If Not Response.IsClientConnected Then
                Exit While
            End If
            System.Threading.Thread.Sleep(100)
            i = i + 1
        End While
    End Sub
    Protected Sub BtnSubirLogo_Click(sender As Object, e As EventArgs) Handles BtnSubirLogo.Click
        If SubidaArchivo() = True Then
            Try
                Dim targetFolder As String = Path.GetTempPath()
                Dim dt As New DataTable()
                Dim line As String = Nothing
                Dim i As Integer = 0

                MensajeLogo.Text = ""

                Using sr As StreamReader = File.OpenText(targetFolder & ViewState("FileName"))
                    line = sr.ReadLine()
                    Do While line IsNot Nothing
                        Dim data() As String = line.Split(","c)
                        If data.Length > 0 Then
                            If i = 0 Then
                                For Each item In data
                                    dt.Columns.Add(New DataColumn())
                                Next item
                                i += 1
                            End If
                            Dim row As DataRow = dt.NewRow()
                            row.ItemArray = data

                            dt.Rows.Add(row)
                        End If

                        line = sr.ReadLine()
                    Loop

                End Using

            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
