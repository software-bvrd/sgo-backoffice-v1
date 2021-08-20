Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI


Imports System.Globalization

Partial Class Edicion_EditarComisionesTarifas
    Inherits System.Web.UI.Page


    Private oper As New operation


    ' -----------------------------------------------------------------------------------
    ' Carga Inicial de la página.
    ' -----------------------------------------------------------------------------------

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            If Session("Ajax") = True Then

                ViewState("Code") = Session("Code")
                Session("Code") = Nothing
                Session("Ajax") = Nothing
                Codigo.Text = ViewState("Code")

            Else

                ViewState("Code") = Request.QueryString("ComisionesTarifasID")
                Codigo.Text = ViewState("Code")

            End If




            If ViewState("EsNuevo") = True Then

                HabilitarDetalles(False)
                chkActivo.Checked = True

            Else

                HabilitarDetalles(True)
                EditarComisionTarifa()

            End If

            With RadGridComisionesTarifasDetalles
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With


            ConceptoEncabezado.Focus()


        End If

    End Sub



    ' -----------------------------------------------------------------------------------
    ' B a r r a   S u p e r i o r
    ' -----------------------------------------------------------------------------------

    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick


        If e.Item.Value = 0 Then ' G U A R D A R

            Guardado.Text = ""


            If ViewState("EsNuevo") = True Then
                InsertarComisionTarifa()
            Else
                ActualizaComisionTarifa()
                LimpiaComisionTarifa()
            End If


        ElseIf e.Item.Value = 1 Then  ' C A N C E L A R

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        End If


    End Sub






#Region " Encabezado... "

    ' ------------------------------------------------------------------------
    ' Encabezado de Comisiones y Tarifas 
    ' ------------------------------------------------------------------------

    Sub EditarComisionTarifa()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [ComisionesTarifas]  where ComisionesTarifasID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Concepto")) Then Me.ConceptoEncabezado.Text = Trim(MyRow.Item("Concepto"))
            If Not IsDBNull(MyRow.Item("Entidad")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("Entidad"))
            If Not IsDBNull(MyRow.Item("Activo")) Then Me.chkActivo.Checked = Trim(MyRow.Item("Activo"))
        Next

    End Sub

    Sub InsertarComisionTarifa()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "INSERT INTO [ComisionesTarifas] ([Concepto] ,[Entidad] ,[Activo]) VALUES (@Concepto ,@Entidad ,@Activo)"
            Dim Sql2 As String = "Select @@Identity"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@Concepto", SqlDbType.VarChar)).Value = IIf(Me.ConceptoEncabezado.Text.Length > 0, Me.ConceptoEncabezado.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Entidad", SqlDbType.VarChar)).Value = IIf(Me.RadComboBox1.Text.Length > 0, Me.RadComboBox1.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Activo", SqlDbType.Bit)).Value = chkActivo.Checked


            cmd.ExecuteNonQuery()
            cmd.CommandText = Sql2
            Codigo.Text = cmd.ExecuteScalar()


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally


            HabilitarDetalles(True)
            Guardado.Text = "Guardado con éxito..."

            Cnx.Close()

        End Try

    End Sub

    Sub ActualizaComisionTarifa()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try

            Dim Sql As String = "UPDATE  [ComisionesTarifas] SET " &
                                "[Concepto] = @Concepto" &
                                ",[Entidad] = @Entidad" &
                                ",[Activo] = @Activo" &
                                " WHERE ComisionesTarifasID = @ComisionesTarifasID"


            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)



            cmd.Parameters.Add(New SqlParameter("@ComisionesTarifasID", SqlDbType.BigInt)).Value = IIf(CInt(ViewState("Code")) > 0, CInt(ViewState("Code")), DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Concepto", SqlDbType.VarChar)).Value = IIf(Me.ConceptoEncabezado.Text.Length > 0, Me.ConceptoEncabezado.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Entidad", SqlDbType.VarChar)).Value = IIf(Me.RadComboBox1.Text.Length > 0, Me.RadComboBox1.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Activo", SqlDbType.Bit)).Value = chkActivo.Checked


            cmd.ExecuteNonQuery()


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception

        Finally
            Guardado.Text = "Guardado con éxito..."
            Cnx.Close()
        End Try

    End Sub

    Sub LimpiaComisionTarifa()

        Concepto.Text = ""
        RadComboBox1.SelectedValue = "Emisor"
        chkActivo.Checked = True

    End Sub

#End Region

#Region " Detalle ..."

    ' ------------------------------------------------------------------------
    ' Detalle de Comisiones y Tarifas 
    ' ------------------------------------------------------------------------

    Sub EditarComisionTarifaDetalle()

    End Sub

    Sub InsertarComisionTarifaDetalle()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "INSERT INTO [ComisionesTarifasDetalle] ([ComisionesTarifasID],[Concepto] ,[ValorInicio] ,[ValorFinal],[PorcentajeCobrar],[ValorCobrar]) VALUES (@ComisionesTarifasID,@concepto ,@ValorInicio ,@ValorFinal,@PorcentajeCobrar,@ValorCobrar)"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)


            cmd.Parameters.Add(New SqlParameter("@ComisionesTarifasID", SqlDbType.BigInt)).Value = Codigo.Text

            cmd.Parameters.Add(New SqlParameter("@Concepto", SqlDbType.VarChar)).Value = IIf(Me.Concepto.Text.Length > 0, Me.Concepto.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@ValorInicio", SqlDbType.Money)).Value = IIf(ValorInicio.Text.Length > 0, ValorInicio.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@ValorFinal", SqlDbType.Money)).Value = IIf(ValorFinal.Text.Length > 0, ValorFinal.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@PorcentajeCobrar", SqlDbType.Decimal)).Value = IIf(PorcentajeCobrar.Text.Length > 0, PorcentajeCobrar.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@ValorCobrar", SqlDbType.Money)).Value = IIf(ValorCobrar.Text.Length > 0, ValorCobrar.Text, DBNull.Value)



            cmd.ExecuteNonQuery()


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally

            Cnx.Close()

        End Try

    End Sub


    Sub LimpiaComisionTarifaDetalle()

        Concepto.Text = ""
        ValorInicio.Text = 0
        ValorFinal.Text = 0
        ValorCobrar.Text = 0
        PorcentajeCobrar.Text = 0

    End Sub



    Sub HabilitarDetalles(lHabilitar As Boolean)
        Concepto.Enabled = lHabilitar
        ValorInicio.Enabled = lHabilitar
        ValorFinal.Enabled = lHabilitar
        PorcentajeCobrar.Enabled = lHabilitar
        ValorCobrar.Enabled = lHabilitar
        RadGridComisionesTarifasDetalles.Enabled = lHabilitar
    End Sub

    Protected Sub RadGridComisionesTarifasDetalles_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadGridComisionesTarifasDetalles.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridComisionesTarifasDetalles.SelectedItems(0)
        Dim ID = dataitem("ComisionesTarifasDetalleID").Text
        ViewState("CodComisionesTarifasDetalle") = ID
        ViewState("EsNuevo") = False
        EditarComisionTarifaDetalle()

    End Sub



#End Region


   

    ' -----------------------------------------------------------------------------------
    ' B a r r a   D e t a l l e
    ' -----------------------------------------------------------------------------------

   
    Protected Sub RadToolBar2_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar2.ButtonClick

        If e.Item.Value = 0 Then ' Nuevo

        ElseIf e.Item.Value = 1 Then  ' Guardar

            InsertarComisionTarifaDetalle()
            LimpiaComisionTarifaDetalle()

            RadGridComisionesTarifasDetalles.DataBind()

            Concepto.Focus()



        ElseIf e.Item.Value = 2 Then  ' Borrar


        End If


    End Sub


    Protected Sub Concepto_TextChanged(sender As Object, e As System.EventArgs) Handles Concepto.TextChanged
        Guardado.Text = ""
    End Sub
End Class
