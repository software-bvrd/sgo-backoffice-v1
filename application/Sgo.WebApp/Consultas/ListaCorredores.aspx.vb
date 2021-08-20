Imports System.Globalization
Imports Telerik.Web.UI

Partial Class Edicion_ListaCorredores
    Inherits Page
    Private oper As New operation

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 7 Then
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Consultas/ListaCorredores.aspx','1000','600')</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 1 Then

            ViewState("Seleccionado") = 0
            ViewState("Code") = 0


            For Each dataItem As GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("PuestoBolsaCorredorID").Text
                ViewState("Seleccionado") = 1
            Next

            If ViewState("Seleccionado") = 1 Then

                Session("Consulta") = "Consulta"

                Dim MyWindow As New RadWindow
                MyWindow.NavigateUrl = "../Edicion/EditarPuestoBolsaCorredor.aspx?PuestoBolsaCorredorID=" & ViewState("Code") & "&EsNuevo=" & False
                MyWindow.VisibleOnPageLoad = True
                MyWindow.BackColor = Drawing.Color.Blue
                MyWindow.AutoSize = True
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)

            Else
                InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para ver ficha.')</" + "script>"

            End If

        ElseIf e.Item.Value = 8 Then 'Activar Corredor


            For Each dataItem As GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("PuestoBolsaCorredorID").Text
                ViewState("Activo") = dataItem("Activo").Text
                ViewState("Nombre") = dataItem("Nombre").Text

                ViewState("Seleccionado") = 1
            Next

            If ViewState("Activo") = "Inactivo" Then

                Dim MyWindow As New Telerik.Web.UI.RadWindow
                MyWindow.NavigateUrl = "ActivarCorredor.aspx?PuestoBolsaCorredorID=" & ViewState("Code") & "&Nombre=" & ViewState("Nombre")
                MyWindow.VisibleOnPageLoad = True
                MyWindow.AutoSize = True
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)

            End If

        ElseIf e.Item.Value = 90 Then ' Exportar

            RadGrid1.MasterTableView.ExportToExcel()

        ElseIf e.Item.Value = 91 Then

            RadGrid1.MasterTableView.ExportToPdf()

        ElseIf e.Item.Value = 92 Then

            RadGrid1.MasterTableView.ExportToCSV()

        ElseIf e.Item.Value = 93 Then

            RadGrid1.MasterTableView.ExportToWord()
        End If
    End Sub

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub

    Protected Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If Not IsPostBack() Then
            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Consulta: Consulta Corredores", "Consulta Corredores", "")


        End If
    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As GridDataItem In RadGrid1.SelectedItems
            Session("Code") = dataItem("PuestoBolsaCorredorID").Text
            Session("Consulta") = "Consulta"
            Session("Ajax") = True
        Next
    End Sub

    Private isPdfExport As Boolean = False

    Protected Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = RadGrid.ExportToPdfCommandName Then
            isPdfExport = True
            RadGrid1.MasterTableView.GetColumn("Foto").Visible = False
            RadGrid1.MasterTableView.GetColumn("Foto").HeaderStyle.Width = Unit.Pixel(250)
            RadGrid1.MasterTableView.GetColumn("Nombre").HeaderStyle.Width = Unit.Pixel(100)
            RadGrid1.MasterTableView.GetColumn("PuestoBolsaNombre").HeaderStyle.Width = Unit.Pixel(100)
            RadGrid1.MasterTableView.GetColumn("Telefono").HeaderStyle.Width = Unit.Pixel(30)
            RadGrid1.MasterTableView.GetColumn("Activo").HeaderStyle.Width = Unit.Pixel(25)
            RadGrid1.MasterTableView.GetColumn("FechaLicencia").HeaderStyle.Width = Unit.Pixel(40)
            RadGrid1.MasterTableView.GetColumn("FechaLicenciaVence").HeaderStyle.Width = Unit.Pixel(40)
            RadGrid1.MasterTableView.GetColumn("FechaLicenciaSIV").HeaderStyle.Width = Unit.Pixel(40)
            RadGrid1.MasterTableView.GetColumn("FechaLicenciaSIVVence").HeaderStyle.Width = Unit.Pixel(40)

        End If
        If e.CommandName = RadGrid.ExportToExcelCommandName Or
           e.CommandName = RadGrid.ExportToWordCommandName Then
            RadGrid1.MasterTableView.GetColumn("Foto").Visible = False
        End If
    End Sub

    Protected Sub RadGrid1_ItemCreated(ByVal sender As Object, ByVal e As GridItemEventArgs) Handles RadGrid1.ItemCreated
        If isPdfExport Then
            FormatGridItem(e.Item)
        End If

    End Sub

    Protected Sub FormatGridItem(ByVal item As GridItem)
        item.Style("color") = "#eeeeee"

        If TypeOf item Is GridDataItem Then
            item.Style("vertical-align") = "middle"
            item.Style("font-size") = "6px"
            item.Style("font-family") = "Calibri"
            item.Style("background-color") = If(item.ItemType = GridItemType.AlternatingItem, "#F1F5FB", "#FFFFFF")
            item.Style("padding-left") = "2px"
            item.Style("padding-right") = "2px"
            item.Cells.Item(7).Style("text-align") = "center"
            item.Cells.Item(9).Style("text-align") = "center"
            item.Cells.Item(10).Style("text-align") = "center"
            item.Cells.Item(12).Style("text-align") = "center"
            item.Cells.Item(13).Style("text-align") = "center"
        End If

        Select Case item.ItemType 'Mimic RadGrid appearance for the exported PDF file
            Case GridItemType.Item
                item.Style("font-size") = "6px"
                item.Style("font-family") = "Calibri"

                Exit Select
            Case GridItemType.AlternatingItem
                item.Style("font-size") = "6px"
                item.Style("font-family") = "Calibri"


                Exit Select
            Case GridItemType.Header
                item.Style("font-size") = "6px"
                item.Style("font-family") = "Calibri"
                item.Style("background-color") = "#bfdbff"

                Exit Select
            Case GridItemType.CommandItem
                item.Style("font-size") = "6px"
                item.Style("font-family") = "Calibri"
                Exit Select
        End Select

        If TypeOf item Is GridCommandItem Then 'needed to span the image over the CommandItem cells
            item.PrepareItemStyle()
        End If
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
