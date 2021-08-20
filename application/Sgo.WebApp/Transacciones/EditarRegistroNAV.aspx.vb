Imports System.Data


Partial Class Transacciones_EditaRegistroNAV
    Inherits System.Web.UI.Page

    Private oper As New operation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("NAVID")
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            Else
                txtFecha.DbSelectedDate = Today.Date
            End If

            RadComboBoxEmisorID.Focus()
        End If

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

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

    Sub Nuevo()

        Try
            If ViewState("EsNuevo") = True Then

                'Dim sql As String
                'sql = "INSERT INTO [TBL_NAV] ([EmisionID], [EmisionSerieID], [Fecha], [NAV])"
                'sql = sql + " VALUES"
                'sql = sql + " ({0}, '{1}', '{2}', '{3}')"

                'sql = String.Format(sql, Me.RadComboBoxEmisionID.SelectedValue,
                '                    Me.RadComboBoxEmisionSerie.SelectedValue,
                '                    Me.txtFecha.SelectedDate,
                '                    Me.txtNav.Text)


                ' --------------------------------------------------------------                
                ' 2016.11.24 : Insertar Nav Masivo
                ' --------------------------------------------------------------



                Dim sql As String
                sql = "INSERT INTO [TBL_NAV] ([EmisionID], [EmisionSerieID], [Fecha], [NAV]) "
                sql = sql + "("
                sql = sql + "Select et.EmisionID, es.EmisionSerieID, '" + oper.FormatoFechayymmdd(txtFecha.SelectedDate.Value) + "' as fecha,"
                sql = sql + txtNav.Text.ToString() + " as nav  from EmisionSerie AS es "
                sql = sql + "join EmisionTramo AS et "
                sql = sql + "on et.EmisionTramoID = es.EmisionTramoID "
                sql = sql + "where et.EmisionID = " + Me.RadComboBoxEmisionID.SelectedValue.ToString()
                sql = sql + " )"

                oper.ExecuteNonQuery(sql)



            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM [vNAV]  where [ID]='" & CInt(ViewState("Code")) & "'")


        Dim vEmisorId As String = String.Empty
        Dim vEmisionId As String = String.Empty

        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows

            If Not IsDBNull(MyRow.Item("EmisorID")) Then vEmisorId = Trim(MyRow.Item("EmisorID"))
            If Not IsDBNull(MyRow.Item("EmisionID")) Then vEmisionId = Trim(MyRow.Item("EmisionID"))
            ' If Not IsDBNull(MyRow.Item("EmisionSerieID")) Then RadComboBoxEmisionSerie.SelectedValue = Trim(MyRow.Item("EmisionSerieID"))
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFecha.SelectedDate = Trim(MyRow.Item("Fecha"))
            If Not IsDBNull(MyRow.Item("NAV")) Then Me.txtNav.Text = Trim(MyRow.Item("NAV"))
        Next

        If vEmisorId.Length > 0 Then
            Dim strSql As String = "SELECT count(EmisorID) as EmisionID FROM [Emisor] 
                                             where EmisorID
                                             in (
                                             select EmisorId 
                                             from Emision where Estatus = 'VI' and TipoInstrumentoID in (Select TipoInstrumentoID from TipoInstrumento where TipoMercadoID =6) 
                                             ) And EmisorID='" & vEmisorId & "'"

            Dim vExiste As String = oper.ExecuteScalar(strSql)
            If Convert.ToInt32(vExiste) > 0 Then
                Me.RadComboBoxEmisorID.SelectedValue = vEmisorId
                Me.RadComboBoxEmisionID.SelectedValue = vEmisionId
            End If

        End If

    End Sub

    Sub Actualizar()
        Try

            'Dim cStringSQL As String = ""

            'cStringSQL = "UPDATE [TBL_NAV]"
            'cStringSQL = cStringSQL + " SET [EmisionID] = {1}"
            'cStringSQL = cStringSQL + " ,[EmisionSerieID] = '{2}'"
            'cStringSQL = cStringSQL + " ,[Fecha] = '{3}'"
            'cStringSQL = cStringSQL + " ,[NAV] = '{4}'"
            'cStringSQL = cStringSQL + " WHERE ID = {0}"

            'cStringSQL = String.Format(cStringSQL, CInt(ViewState("Code")),
            '                           Me.RadComboBoxEmisionID.SelectedValue,
            '                           Me.RadComboBoxEmisionSerie.SelectedValue,
            '                           Me.txtFecha.SelectedDate,
            '                           Me.txtNav.Text)



            ' --------------------------------------------------------------                
            ' 2016.11.24 : Actualizar Nav Masivo
            ' --------------------------------------------------------------
            Dim sql As String = "UPDATE TBL_NAV"
            sql = sql + "    SET [EmisionID] = " + RadComboBoxEmisionID.SelectedValue.ToString() + ", "
            sql = sql + "        [Fecha] = '" + oper.FormatoFechayymmdd(txtFecha.SelectedDate.Value) + "', "
            sql = sql + "        [NAV] = " + txtNav.Text.ToString()
            sql = sql + "    WHERE [EmisionID] = (select n.EmisionID from TBL_NAV AS n where n.ID = " + ViewState("Code").ToString() + ")"
            sql = sql + "         and Fecha = ( select n.Fecha from TBL_NAV AS n where n.ID = " + ViewState("Code").ToString() + ")"


            oper.ExecuteNonQuery(sql)


            ViewState("EsNuevo") = False

        Catch ex As Exception
        End Try
    End Sub

End Class
