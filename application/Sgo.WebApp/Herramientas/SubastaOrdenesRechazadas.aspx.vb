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
Public Class SubastaOrdenesRechazadas
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            ViewState("EsNuevo") = True
            With RadGridOrdenesRechazadas
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With
            RadToolBar1.Items.Item(0).Enabled = False
        End If

        'Borrar Serie  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            If BorrarEmisor() Then
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            End If
        End If

    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick


        If e.Item.Value = 0 Then ' G U A R D A R

            Mensaje.Text = ""
            If Validar() Then
                If ViewState("EsNuevo") = True Then
                    Insertar()

                ElseIf ViewState("EsNuevo") = False Then
                    If txtSubastaOrdenesRechazadasID.Text.Trim().Length > 0 Then
                        Actualizar()
                    Else
                        Mensaje.ForeColor = Color.Red
                        Mensaje.Text = "No hay registro para actualizar."
                    End If
                End If
            Else
                Mensaje.ForeColor = Color.Red
                Mensaje.Text = "Todos los campos son obligatorios."
            End If


        ElseIf e.Item.Value = 1 Then  ' C A N C E L A R
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then  ' N U E V O
            Mensaje.Text = ""
            Me.txtFecha.DbSelectedDate = Nothing
            With cboTipoLibroOrdenes
                .Text = ""
                .ClearSelection()
            End With
            With cboEmision
                .Text = ""
                .ClearSelection()
            End With
            Me.txtMonto.Text = String.Empty
            txtSubastaOrdenesRechazadasID.Text = String.Empty
            ViewState("EsNuevo") = True
            RadToolBar1.Items.Item(0).Enabled = False
        ElseIf e.Item.Value = 3 Then  ' B O R R A R

            'Select Case Me.RadTabStrip1.SelectedIndex

            '    Case 0

            '        InjectScriptLabel.Text = "<script>Delete()</" + "script>"

            '    Case 1 ' Documentos



            '    Case 2
            '        BorrarCalificacionRiesgo()
            '        RadGridCalificaciones.DataBind()
            'End Select

        End If


    End Sub

    Function BorrarEmisor() As Boolean


        Return True
    End Function
    Sub Insertar()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""

        Try
            Dim Sql As String = "INSERT INTO [SubastaOrdenesRechazadas] ([Fecha] ,[TipoLibroOrdenes] ,[CodEmisionBVRD] ,[Monto]) VALUES (@Fecha,@TipoLibroOrdenes,@CodEmisionBVRD,@Monto)"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFecha.DbSelectedDate.ToString.Length > 0, Me.txtFecha.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoLibroOrdenes", SqlDbType.VarChar)).Value = IIf(Me.cboTipoLibroOrdenes.Text.Length > 0, Me.cboTipoLibroOrdenes.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodEmisionBVRD", SqlDbType.VarChar)).Value = IIf(Me.cboEmision.Text.Length > 0, Me.cboEmision.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Monto", SqlDbType.VarChar)).Value = IIf(Me.txtMonto.Text.Length > 0, Me.txtMonto.Text, DBNull.Value)

            cmd.ExecuteNonQuery()
            txtSubastaOrdenesRechazadasID.Text = oper.ExecuteScalar("select IDENT_CURRENT('SubastaOrdenesRechazadas')")

            csql = oper.CovertirComandoATexto(cmd)
            Mensaje.ForeColor = Color.Blue
            Mensaje.Text = "Guardado con éxito"
            ViewState("EsNuevo") = False
            RadToolBar1.Items.Item(0).Enabled = True
            RadGridOrdenesRechazadas.Rebind()
            Cnx.Close()

        Catch sql_ex As SqlClient.SqlException
            If sql_ex.ErrorCode = -2146232060 Then
                Mensaje.ForeColor = Color.Red
                Mensaje.Text = "Error al guardar el registro."
                Exit Sub
            End If
        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try

    End Sub

    Sub Actualizar()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""

        Try

            Dim Sql As String = "Update [SubastaOrdenesRechazadas] set [Fecha]=@Fecha,[TipoLibroOrdenes]=@TipoLibroOrdenes,[CodEmisionBVRD]=@CodEmisionBVRD, [Monto]=@Monto  WHERE  [SubastaOrdenesRechazadasID]=@SubastaOrdenesRechazadasID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@SubastaOrdenesRechazadasID", SqlDbType.BigInt)).Value = ViewState("SubastaOrdenesRechazadasID")

            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFecha.DbSelectedDate.ToString.Length > 0, Me.txtFecha.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoLibroOrdenes", SqlDbType.VarChar)).Value = IIf(Me.cboTipoLibroOrdenes.Text.Length > 0, Me.cboTipoLibroOrdenes.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodEmisionBVRD", SqlDbType.VarChar)).Value = IIf(Me.cboEmision.Text.Length > 0, Me.cboEmision.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Monto", SqlDbType.VarChar)).Value = IIf(Me.txtMonto.Text.Length > 0, Me.txtMonto.Text, DBNull.Value)


            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            ' oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Emisor CalificacionRiesgo", "Editar", csql)
            Mensaje.ForeColor = Color.Blue
            Mensaje.Text = "Registro actualizado con éxito."
            RadGridOrdenesRechazadas.Rebind()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Mensaje.ForeColor = Color.Red
                Mensaje.Text = "Error al actualizar el registro."
                Exit Sub
            End If

        Catch ex As Exception

        Finally
            Cnx.Close()

        End Try


    End Sub
    Sub Editar(ByVal pSubastaOrdenesRechazadasID)
        Dim ds As DataSet = oper.ExDataSet("SELECT [SubastaOrdenesRechazadasID] ,[Fecha] ,[TipoLibroOrdenes] ,[CodEmisionBVRD] ,[Monto] FROM [dbo].[SubastaOrdenesRechazadas] where  SubastaOrdenesRechazadasID ='" & pSubastaOrdenesRechazadasID & "'")
        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows
            '----------------------------------------------Calificacion Riesgo -------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFecha.DbSelectedDate = Trim(MyRow.Item("Fecha"))
            If Not IsDBNull(MyRow.Item("TipoLibroOrdenes")) Then Me.cboTipoLibroOrdenes.SelectedValue = Trim(MyRow.Item("TipoLibroOrdenes"))
            If Not IsDBNull(MyRow.Item("CodEmisionBVRD")) Then Me.cboEmision.SelectedValue = Trim(MyRow.Item("CodEmisionBVRD"))
            If Not IsDBNull(MyRow.Item("Monto")) Then Me.txtMonto.Text = Trim(MyRow.Item("Monto"))
            txtSubastaOrdenesRechazadasID.Text = pSubastaOrdenesRechazadasID
        Next


    End Sub
    Function Validar() As Boolean
        Dim vRes As Boolean = True
        If Me.txtFecha.DbSelectedDate = Nothing Then
            vRes = False
        ElseIf Me.cboTipoLibroOrdenes.SelectedValue.Trim().Length <= 0 Then
            vRes = False
        ElseIf Me.cboEmision.SelectedValue.Trim().Length <= 0 Then

            vRes = False
        ElseIf Me.txtMonto.Text.Trim().Length <= 0 Then

            vRes = False
        Else
            vRes = True
        End If
        Return vRes
    End Function

    Protected Sub RadGridOrdenesRechazadas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridOrdenesRechazadas.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridOrdenesRechazadas.SelectedItems(0)
        Dim ID = dataitem("SubastaOrdenesRechazadasID").Text
        ViewState("EsNuevo") = False
        Editar(ID)
        RadToolBar1.Items.Item(0).Enabled = True
    End Sub
End Class