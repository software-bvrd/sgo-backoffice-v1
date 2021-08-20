Imports System.Globalization
Imports Telerik.Web.UI
Public Class ListaOperacionesCancelarBO
    Inherits System.Web.UI.Page
    'Inherits Page
    Private oper As New operation
    Private cStringWhere As String = ""
    Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        If Not IsPostBack Then
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Consulta: Operaciones", "Consulta de Operaciones", "")
            txtIdUsuario.Text = Session("IdUsuario")
            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With


            ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            ' Iniciar con la fecha del día 
            Dim FechaOperacion As Date = oper.ExecuteScalar("Select Top(1) fecha_oper from [vConsultaOperacionesCSV] order by fecha_oper desc")
            cStringWhere = String.Format("[fecha_oper]='{0}'", FechaOperacion)

            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            'Filtro por defecto 
            Dim editor As New RadFilterTextFieldEditor()
            RadFilter1.FieldEditors.Add(editor)
            If Not IsPostBack Then
                editor.FieldName = "Fecha operación"
                editor.DataType = GetType(Date)

                Dim expr As New RadFilterEqualToFilterExpression(Of Date)("fecha_oper")
                Dim Fecha As String = oper.FormatoFechayymmdd(FechaOperacion)
                expr.Value = Fecha
                RadFilter1.RootGroup.Expressions.Add(expr)
            End If
            txtIdConsulta.Text = 0

            'With RadFilter1
            '    .FireApplyCommand()
            'End With
        End If


    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick, RadToolBar2.ButtonClick
        If e.Item.Value <> "" Then

            RadWindowManager1.Windows.Clear()

            If e.Item.Value = 0 Then 'Mover
                InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Herramientas/ListaOperacionesCancelarBO.aspx','1000','600')</" + "script>"
            ElseIf e.Item.Value = 1 Then 'Cancelar
                InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
            ElseIf e.Item.Value = 2 Then 'Guardar


                ViewState("Seleccionado") = 0

                For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
                    ViewState("Code") = dataItem("IdOperacion").Text
                    ViewState("num_oper") = dataItem("num_oper").Text
                    ViewState("fecha_oper") = dataItem("fecha_oper").Text
                    ViewState("mercado") = dataItem("mercado").Text
                    ViewState("Seleccionado") = 1
                Next

                If ViewState("Seleccionado") = 1 Then


                    Dim MyWindow As New RadWindow
                    MyWindow.NavigateUrl = "EditarCancelarOperacion.aspx?ID=" & ViewState("Code") & "&NO=" & ViewState("num_oper") & "&FO=" & ViewState("fecha_oper") & "&ME=" & ViewState("mercado")
                    MyWindow.VisibleOnPageLoad = True
                    MyWindow.AutoSize = True
                    RadWindowManager1.Windows.Clear()
                    RadWindowManager1.Windows.Add(MyWindow)


                Else
                    InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para Cancelar Operación.')</" + "script>"
                End If

            ElseIf e.Item.Value = 4 Then 'Exportar excel

                ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
                Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count

                RadGrid1.MasterTableView.ExportToExcel()
                ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
                Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            ElseIf e.Item.Value = 5 Then 'Exportar pdf
                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                RadGrid1.MasterTableView.ExportToPdf()

            ElseIf e.Item.Value = 6 Then 'Exportar csv
                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                RadGrid1.MasterTableView.ExportToCSV()

            End If

        End If
    End Sub

    Protected Sub RadGrid1_ExportCellFormatting(sender As Object, e As ExportCellFormattingEventArgs) Handles RadGrid1.ExportCellFormatting
        If (e.FormattedColumn.UniqueName) = "fecha_oper" Then
            e.Cell.Style("mso-number-format") = "mm\/dd\/yy"
        End If
    End Sub

    Protected Sub RadGrid1_GroupsChanging(sender As Object, e As GridGroupsChangingEventArgs) Handles RadGrid1.GroupsChanging
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_ColumnsReorder(sender As Object, e As GridColumnsReorderEventArgs) Handles RadGrid1.ColumnsReorder
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGrid1.PageSizeChanged
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub



End Class