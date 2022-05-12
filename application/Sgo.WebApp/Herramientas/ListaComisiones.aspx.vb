Imports System.Data.SqlClient
Imports System.Globalization
Imports Telerik.Web.UI


Partial Class ListaComisiones

    Inherits System.Web.UI.Page
    Private oper As New operation
    Private ComisionHistoricoKey As String = ""
    Public FechaInclusion As Date


    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then 'Nuevo

            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "ConfirmarComisiones.aspx?EsNuevo=" & True
            MyWindow.VisibleOnPageLoad = True
            MyWindow.AutoSize = True
            MyWindow.InitialBehaviors = WindowBehaviors.Maximize
            RadWindowManager1.Windows.Clear()
            RadWindowManager1.Windows.Add(MyWindow)

        ElseIf e.Item.Value = 1 Then 'Editar

            ViewState("Seleccionado") = 0

            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("ComisionHistoricoID").Text
                ViewState("Estatus") = dataItem("Estatus").Text
                ViewState("Seleccionado") = 1
            Next

            If ViewState("Seleccionado") = 1 Then
                Dim MyWindow As New Telerik.Web.UI.RadWindow
                MyWindow.NavigateUrl = "ConfirmarComisiones.aspx?ComisionHistoricoID=" & ViewState("Code") & "&Estatus=" & ViewState("Estatus") & "&EsNuevo=" & False
                MyWindow.VisibleOnPageLoad = True
                MyWindow.InitialBehaviors = WindowBehaviors.Maximize
                MyWindow.AutoSize = True
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para editar.')</" + "script>"
            End If
        ElseIf e.Item.Value = 2 Then 'Descargar

            DescargarLote()

        ElseIf e.Item.Value = 7 Then 'Mover

            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Herramientas/ListaComisiones.aspx','1000','600')</" + "script>"
        ElseIf e.Item.Value = 2 Then 'Cancelar 
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
        End If

        Session("Ajax") = False

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not IsPostBack Then
            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With
            InjectScriptLabelImprimir.Text = ""
            'Filtro por defecto 
            FechaInclusion = oper.ExecuteScalar("Select Top(1) fechainclusion from ComisionHistorico order by fechainclusion desc")
            Dim editor As New RadFilterTextFieldEditor()
            RadFilter1.FieldEditors.Add(editor)
            editor.FieldName = "Fecha Generación"
            editor.DataType = GetType(Date)

            Dim expr As New RadFilterEqualToFilterExpression(Of Date)("FechaInclusion")
            Dim Fecha As String = oper.FormatoFechayymmdd(FechaInclusion)
            expr.Value = Fecha
            RadFilter1.RootGroup.Expressions.Add(expr)
            RadGrid1.Rebind()
            'Dim Grid As RadGrid = CType(FindControl("RadGrid1"), RadGrid)
            'RadFilter1.FilterContainerID = Grid.ID
            RadFilter1.FireApplyCommand()
            RenderGridFilters()
        End If


    End Sub

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub

    Protected Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        Dim ditem As GridDataItem = CType(e.Item, GridDataItem)
        ' Dim value As String = ditem("identificador").Text

        Dim dsOperacionesGP As New DataSet
        Dim vComisionHistoricoID As Integer = Convert.ToInt32(ditem("ComisionHistoricoID").Text)
        Dim videntificador As String = Convert.ToString(ditem("identificador").Text).Trim()
        Dim fileName As String = videntificador & "_" & DateAndTime.Now.ToString("yyyyMMddhhmmss") & ".csv"
        ' Dim fileName As String = Server.MapPath("~/tmp/") + videntificador & "_" & DateAndTime.Now.ToString("yyyyMMddhhmmss") & ".csv"
        'Dim fileName As String = videntificador & "_" & DateAndTime.Now.ToString("yyyyMMddhhmmss") & ".csv"
        Dim fileNamedest As String = videntificador & "_" & DateAndTime.Now.ToString("yyyyMMdd") & ".csv"
        Dim url As String = "\\10.1.0.51\FilesShared\Interface\"
        ' Dim url As String = "\\ADB00\Interface\"

        Dim vEstatus As String = ditem("Estatus").Text

        lblmsg.Text = String.Empty
        If e.CommandName = "Generate" Then
            dsOperacionesGP = ConsultaDataGP(vComisionHistoricoID)

            If dsOperacionesGP.Tables(0).Rows.Count = 0 Then
                lblmsg.Text = "No se encuentran registros para el rango de fecha definido."
                'Else
                '    If vEstatus = "C" Then
                '        Dim cSql As String = "Update ComisionHistorico set  Estatus = 'E' where ComisionHistoricoID=" & vComisionHistoricoID
                '        oper.ExecuteNonQuery(cSql)
                'End If
            Else

                Dim myData As Byte() = csvBytesWriter(dsOperacionesGP.Tables(0))
                Response.Clear()
                Response.ClearHeaders()
                Response.AddHeader("Content-Type", "Application/octet-stream")
                Response.AddHeader("Content-Length", myData.Length.ToString())
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName)
                Response.BinaryWrite(myData)
                Response.Flush()
                Response.End()
            End If

            'Else
            '    'Refresco la Pantalla 
            '    dsOperacionesGP = ConsultaDataGP(vComisionHistoricoID)
            '    Dim myData As Byte() = csvBytesWriter(dsOperacionesGP.Tables(0))
        End If

        If e.CommandName = "Enviar" Then
            dsOperacionesGP = ConsultaDataGP(vComisionHistoricoID)

            If dsOperacionesGP.Tables(0).Rows.Count = 0 Then
                lblmsg.Text = "No se encuentran registros para enviar."
            End If

            If vEstatus <> "C" Then
                InjectScriptLabel.Text = "<script>MensajePopup('El archivo no ha sido confirmado.')</" + "script>"
            Else
                If dsOperacionesGP.Tables(0).Rows.Count > 0 Then
                    If vEstatus = "C" Then
                        Dim cSql As String = "Update ComisionHistorico set  Estatus = 'E' where ComisionHistoricoID=" & vComisionHistoricoID
                        oper.ExecuteNonQuery(cSql)
                    End If

                    Dim myData As Byte() = csvBytesWriter(dsOperacionesGP.Tables(0))
                    Response.Clear()
                    Response.ClearHeaders()
                    Response.AddHeader("Content-Type", "Application/octet-stream")
                    Response.AddHeader("Content-Length", myData.Length.ToString())
                    Response.AddHeader("Content-Disposition", "inline;filename=" & fileName)
                    Response.BinaryWrite(myData)
                    Response.Flush()
                    System.IO.File.Copy(Server.MapPath("~/tmp/") & "testcsv.csv", url + fileNamedest)
                    Response.End()
                End If
            End If
        End If
    End Sub

    Public Function GetFileContent(ByVal Filepath As String) As Byte()
        Return System.IO.File.ReadAllBytes(Filepath)
    End Function

    Public Function ConsultaDataGP(id As Int32) As DataSet
        Dim dsOperacionesGP As New DataSet
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Dim Sql As String = "SELECT a.RNC ,a.CodigoServicio,
        CONVERT(VARCHAR(10), a.FechaFactura, 112) AS FechaFactura ,
        a.Monto ,a.Moneda ,a.DiasVencimiento ,h.Estatus FROM dbo.ComisionHistoricoArchivo a
        INNER JOIN dbo.ComisionHistorico h ON a.ComisionHistoricoId= h.ComisionHistoricoID
        Where a.ComisionHistoricoId=@ComisionHistoricoId"

        Dim cmd As New SqlCommand(Sql, Cnx)
        Dim sqlAdap As New SqlDataAdapter

        cmd.Parameters.Add(New SqlParameter("@ComisionHistoricoId", SqlDbType.Int)).Value = id
        sqlAdap.SelectCommand = cmd
        sqlAdap.Fill(dsOperacionesGP)
        Return dsOperacionesGP

    End Function

    ''' <summary>
    ''' Para consultar una lista
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function ConsultaDataLoteGP(id As String) As DataSet
        Dim dsOperacionesGP As New DataSet
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Dim Sql As String = "select  RNC
            ,CodigoServicio
             ,CONVERT(VARCHAR(10),FechaFactura,103) as FechaFactura
            ,Monto
            ,Moneda
            ,DiasVencimiento
            from dbo.ComisionHistoricoArchivo 
            where ComisionHistoricoId in (" + id + ")"
        Dim cmd As New SqlCommand(Sql, Cnx)
        Dim sqlAdap As New SqlDataAdapter

        'cmd.Parameters.Add(New SqlParameter("@ComisionHistoricoId", SqlDbType.VarChar)).Value = id
        sqlAdap.SelectCommand = cmd
        sqlAdap.Fill(dsOperacionesGP)
        Return dsOperacionesGP

    End Function
    Function csvBytesWriter(ByRef dTable As DataTable) As Byte()

        '--------Columns Name---------------------------------------------------------------------------

        Dim sb As StringBuilder = New StringBuilder()
        Dim intClmn As Integer = dTable.Columns.Count

        Dim i As Integer = 0
        For i = 0 To intClmn - 1 Step i + 1
            sb.Append("" + dTable.Columns(i).ColumnName.ToString() + "")
            'sb.Append("""" + dTable.Columns(i).ColumnName.ToString() + """") 'Activar comillas Encabezado
            If i = intClmn - 1 Then
                sb.Append(" ")
            Else
                sb.Append(",")
            End If
        Next
        sb.Append(vbNewLine)

        '--------Data By  Columns---------------------------------------------------------------------------

        Dim row As DataRow
        For Each row In dTable.Rows
            Dim ir As Integer = 0
            For ir = 0 To intClmn - 1 Step ir + 1
                sb.Append("""" + row(ir).ToString().Replace("""", """""") + """")
                If ir = intClmn - 1 Then
                    sb.Append(" ")
                Else
                    sb.Append(",")
                End If

            Next
            'For ir = 0 To intClmn - 1 Step ir + 1
            '    sb.Append("" + row(ir).ToString().Replace("""", """""") + "")
            '    If ir = intClmn - 1 Then
            '        sb.Append(" ")
            '    Else
            '        sb.Append(",")
            '    End If

            'Next
            sb.Append(vbNewLine)
        Next

        Return System.Text.Encoding.UTF8.GetBytes(sb.ToString)

    End Function

    Protected Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        Dim status As String = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Estatus"))
        Dim item As GridDataItem = TryCast(e.Item, GridDataItem)

        If TypeOf e.Item Is GridDataItem Then
            'Dim link2 As Button = CType(item.FindControl("btnFile"), Button)
            'Dim link3 As Button = CType(item.FindControl("btnenviar"), Button)
            Dim chb As CheckBox = CType(item.FindControl("CheckBox1"), CheckBox)

            If status = "P" Then
                'link2.Visible = False
                chb.Enabled = False
                '   link3.Visible = False
            End If
        End If

    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            Session("Code") = dataItem("ComisionHistoricoID").Text
            Session("Ajax") = True
        Next
    End Sub

    Protected Sub RadAjaxManager1_Command(sender As Object, e As CommandEventArgs) Handles RadAjaxManager1.Command

    End Sub

    Private Sub DescargarLote()
        Dim dsOperacionesGP As New DataSet
        Dim fileName As String = "Requisiciones_" & DateAndTime.Now.ToString("yyyyMMdd") & ".csv"
        ComisionHistoricoKey = String.Empty


        For Each item As GridDataItem In RadGrid1.MasterTableView.Items
            Dim CheckBox1 As CheckBox = TryCast(item.FindControl("CheckBox1"), CheckBox)

            If CheckBox1 IsNot Nothing AndAlso CheckBox1.Checked Then
                ComisionHistoricoKey = ComisionHistoricoKey + item.GetDataKeyValue("ComisionHistoricoID").ToString() + ","
            End If
        Next

        If Not String.IsNullOrEmpty(ComisionHistoricoKey) Then
            ComisionHistoricoKey = ComisionHistoricoKey.Substring(0, ComisionHistoricoKey.Length - 1)




            dsOperacionesGP = ConsultaDataLoteGP(ComisionHistoricoKey)

            If dsOperacionesGP.Tables(0).Rows.Count = 0 Then
                lblmsg.Text = "No se encuentran registros para el rango de fecha definido."
            Else


                Dim cSql As String = "Update ComisionHistorico set  Estatus = 'E' where ComisionHistoricoID in (" & ComisionHistoricoKey & ")"
                oper.ExecuteNonQuery(cSql)


                Dim myData As Byte() = csvBytesWriter(dsOperacionesGP.Tables(0))

                Response.Clear()
                Response.ClearHeaders()
                Response.AddHeader("Content-Type", "Application/octet-stream")
                Response.AddHeader("Content-Length", myData.Length.ToString())
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName)
                Response.BinaryWrite(myData)
                Response.Flush()
                Response.End()

            End If
        Else
            lblmsg.Text = "Debe seleccionar por lo menos un registro."
        End If



    End Sub

    Protected Sub RadGrid1_PreRender(sender As Object, e As EventArgs) Handles RadGrid1.PreRender

        'If (Not Page.IsPostBack) Then
        '    RadGrid1.MasterTableView.FilterExpression = "([fechainclusion] ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'" '%Germany%') "
        '    Dim column As GridColumn = RadGrid1.MasterTableView.GetColumnSafe("fechainclusion")
        '    column.CurrentFilterFunction = GridKnownFunction.EqualTo
        '    column.CurrentFilterValue = FechaInclusion.ToString("yyyy-MM-dd")
        '    RadGrid1.MasterTableView.Rebind()
        'End If
    End Sub
    Private Sub RenderGridFilters()
        'Dim expr As New RadFilterEqualToFilterExpression(Of Date)("FechaInclusion")
        'Dim Fecha As String = oper.FormatoFechayymmdd(FechaInclusion)
        'expr.Value = Fecha
        'RadFilter1.RootGroup.Expressions.Add(expr)

        'Dim dtConcepto As New RadFilterEqualToFilterExpression(Of String)("Concepto")
        ''Dim Concepto As String = oper.FormatoFechayymmdd(FechaInclusion)
        ''dtexpr.Value = Fecha
        'RadFilter1.RootGroup.Expressions.Add(dtConcepto) 
    End Sub

End Class
