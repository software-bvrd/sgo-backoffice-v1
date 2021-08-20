Imports System.Globalization
Imports Telerik.Web.UI
Imports System.Data
Imports System.Data.SqlClient

Public Class MoverCorredorPuestoBolsa
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("PuestoBolsaID") = Request.QueryString("PuestoBolsaID")
            ViewState("PuestoBolsaCorredorID") = Request.QueryString("PuestoBolsaCorredorID")

        End If

    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then 'Guardar
            If txtNota.Text.Length > 0 Then
                ViewState("NuevoPuestoBolsaID") = String.Empty
                For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
                    ViewState("NuevoPuestoBolsaID") = dataItem("PuestoBolsaID").Text

                Next
                If ViewState("NuevoPuestoBolsaID").ToString.Length > 0 Then
                    Call Nuevo()
                Else
                    Mensaje.ForeColor = Drawing.Color.Red
                    Mensaje.Text = "Seleccione un puesto de bolsa."
                End If

            End If

        ElseIf e.Item.Value = 2 Then 'Cancelar

        End If

        Session("Ajax") = False

    End Sub

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub

#Region "Procesos personalizados"
    Sub Nuevo()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "INSERT INTO  [HistorialCorredor] ([FechaMovimiento] ,[PuestoBolsaCorredorID] ,[PuestoBolsaID] ,[NuevoPuestoBolsaID] ,[Movimiento] ,[Nota],[UsuarioID] ) VALUES(@FechaMovimiento,@PuestoBolsaCorredorID,@PuestoBolsaID,@NuevoPuestoBolsaID,@Movimiento,@Nota,@UsuarioID) "
            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)
            cmd.Parameters.Add(New SqlParameter("@FechaMovimiento", SqlDbType.DateTime)).Value = DateAndTime.Now()
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCorredorID", SqlDbType.Int)).Value = ViewState("PuestoBolsaCorredorID")
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.Int)).Value = ViewState("PuestoBolsaID")
            cmd.Parameters.Add(New SqlParameter("@NuevoPuestoBolsaID", SqlDbType.Int)).Value = ViewState("NuevoPuestoBolsaID")
            cmd.Parameters.Add(New SqlParameter("@Movimiento", SqlDbType.VarChar)).Value = "T"
            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(txtNota.Text.Length > 0, txtNota.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@UsuarioID", SqlDbType.Int)).Value = IIf(Session("IdUsuario").ToString.Length > 0, Session("IdUsuario"), DBNull.Value)
            cmd.ExecuteNonQuery()

            Mensaje.ForeColor = Drawing.Color.Blue
            Mensaje.Text = "Guardado con éxito"

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Mensaje.ForeColor = Drawing.Color.Red
                Mensaje.Text = "Error SQL al procesar la solicitud. La sesión ha caducado."
                Exit Sub
            End If
        Catch ex As Exception
            Mensaje.ForeColor = Drawing.Color.Red
            Mensaje.Text = "Error al procesar la solicitud."
        Finally
            Cnx.Close()
        End Try

    End Sub

#End Region

End Class