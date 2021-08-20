<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Herramientas_ConsultaOrdenesFirme" Codebehind="ConsultaOrdenesFirme.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta Ordenes en Firme</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>

    <style type="text/css">
        .filterDiv
        {
            margin: 20px 0px 10px 0px;
        }
    </style>

</head>

<body style="background-color: #F1F5FB">

    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

            <script type="text/javascript">

                function ActualizarFiltrosConsultas(sender, args) {

                    __doPostBack("ActualizarFiltros");
                }
                function applyExpression(sender, args) {
                    if (args.get_keyCode() == 13) {
                        setTimeout(function () {
                            $find('<%=RadFilter1.ClientID %>').applyExpressions();
                        }, 10);
                    }
                }


                function onRequestStart(sender, args) {
                    if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 || args.get_eventTarget().indexOf("ExportToWordButton") >= 0 || args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
                        args.set_enableAjax(false);
                    }
                }


                function pageLoad() {
                    var grid = $find("RadGrid1");
                    var columns = grid.get_masterTableView().get_columns();

                    var radFilter = $find('<%=RadFilter1.ClientID %>');
                    var pickers = radFilter.get_element().getElementsByClassName("RadPicker");

                    for (var i = 0; i < columns.length; i++) {
                        columns[i].resizeToFit();
                    }


                    for (var i = 0; i < pickers.length; i++) {
                        var picker = $find(pickers[i].firstElementChild.id);
                        picker.get_timePopupButton().style.display = "none";
                        picker.get_dateInput().set_displayDateFormat("dd/MM/yyyy");
                    }


                }



            </script>
        </telerik:RadCodeBlock>

        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

        <telerik:RadAjaxManager ID="RadAjaxManager1"
            runat="server">

            <ClientEvents OnRequestStart="onRequestStart"></ClientEvents>

            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>

        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

        <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
            <Items>

                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                    Text="Acción" ToolTip="Nuevo,Guardar y Borrar consulta" Value="2">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 5">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                    Text="Mover" ToolTip="Mover a Ventana" Value="0">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Sep 1">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" Text="Excel" Value="4" ToolTip="Exportar a Excel" ImageUrl="~/Images/excel.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 7">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" Text="PDF" ToolTip="Exportar a PDF" Value="5" ImageUrl="~/Images/pdf.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 9">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" Text="CSV" ToolTip="Exportar a CSV" Value="6" ImageUrl="~/Images/csv.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 11">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                    Text="Cancelar" ToolTip="Cancelar Edición" Value="1">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Sep 2">
                </telerik:RadToolBarButton>

            </Items>

        </telerik:RadToolBar>

        <div class="FilterContainer">

            <telerik:RadFilter ID="RadFilter1" runat="server" FilterContainerID="RadGrid1"
                CssClass="RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default " Culture="es-DO">
                <Localization FilterFunctionBetween="Entre"
                    FilterFunctionContains="Contiene"
                    FilterFunctionDoesNotContain="No Contiene"
                    FilterFunctionEndsWith="Finaliza Con"
                    FilterFunctionEqualTo="Igual a"
                    FilterFunctionGreaterThan="Mayor que"
                    FilterFunctionGreaterThanOrEqualTo="Es Mayor o Igual a"
                    FilterFunctionIsEmpty="Está vacio"
                    FilterFunctionIsNull="Es Nulo"
                    FilterFunctionLessThan="Menor que"
                    FilterFunctionLessThanOrEqualTo="Es Menor o Igual a"
                    FilterFunctionNotBetween="No Entre"
                    FilterFunctionNotEqualTo="No es Igual a "
                    FilterFunctionNotIsEmpty="No está vacio"
                    FilterFunctionNotIsNull="No es Nulo"
                    FilterFunctionStartsWith="Inicia Con"
                    GroupOperationAnd="Y"
                    GroupOperationNotAnd="No Y"
                    GroupOperationNotOr="No O"
                    GroupOperationOr="O" />

                <FieldEditors>
                    <telerik:RadFilterDateFieldEditor FieldName="FechaVencimiento" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaPostura" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaModificacion" PickerType="DatePicker" />
                </FieldEditors>


            </telerik:RadFilter>

            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowGroupPanel="True"
                CellSpacing="0" DataSourceID="SqlvConsultaOrdenesFirme" GridLines="None"
                Culture="es-DO" EnableHeaderContextMenu="True"
                ShowFooter="True" AllowPaging="True">

                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Operaciones Realizadas" OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Operaciones Realizadas" />
                </ExportSettings>

                <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True" />
                    <Resizing EnableRealTimeResize="True" AllowColumnResize="True" AllowResizeToFit="True" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
                </ClientSettings>


                <MasterTableView DataSourceID="SqlvConsultaOrdenesFirme" CommandItemDisplay="TopAndBottom" ShowGroupFooter="true" ShowFooter="true">

                    <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                        ShowExportToCsvButton="false" ShowExportToExcelButton="false" ShowExportToPdfButton="false" ShowRefreshButton="false" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>

                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                        Visible="True" Created="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>

                    <Columns>
                        <telerik:GridBoundColumn DataField="Nemotecnico" FilterControlAltText="Filter Nemotecnico column" HeaderText="Código Local" FooterText="Totales:" SortExpression="Nemotecnico" UniqueName="Nemotecnico">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ISIN" FilterControlAltText="Filter ISIN column" HeaderText="Código ISIN" ReadOnly="True" SortExpression="ISIN" UniqueName="ISIN">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaPostura" DataType="System.DateTime" FilterControlAltText="Filter FechaOferta column" HeaderText="Fecha de Postura" SortExpression="FechaPostura" UniqueName="FechaPostura" DataFormatString="{0:dd/MM/yyyy}">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaVencimiento" DataType="System.DateTime" FilterControlAltText="Filter FechaVencimiento column" HeaderText="Fecha de Vencimiento" SortExpression="FechaVencimiento" UniqueName="FechaVencimiento" DataFormatString="{0:dd/MM/yyyy}">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HoraPostura" FilterControlAltText="Filter HoraPostura column" HeaderText="Hora " ReadOnly="True" SortExpression="HoraPostura" UniqueName="HoraPostura" DataFormatString="{0:hh:mm:ss}">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MonedaLiquidacion" FilterControlAltText="Filter MonedaLiquidacion column" HeaderText="Moneda de Liquidación" SortExpression="MonedaLiquidacion" UniqueName="MonedaLiquidacion">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PosicionCompraVenta" Display="False" FilterControlAltText="Filter PosicionCompraVenta column" HeaderText="Posición Compra/Venta" ReadOnly="True" SortExpression="PosicionCompraVenta" UniqueName="PosicionCompraVenta">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Precio" DataType="System.Decimal" FilterControlAltText="Filter Precio column" HeaderText="Precio" SortExpression="Precio" UniqueName="Precio" DataFormatString="{0:###,##0.0000}">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RuedaNegociacion" FilterControlAltText="Filter RuedaNegociacion column" HeaderText="Rueda Negociación" ReadOnly="True" SortExpression="RuedaNegociacion" UniqueName="RuedaNegociacion" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Rendimiento" DataType="System.Decimal" FilterControlAltText="Filter Rendimiento column" HeaderText="Rendimiento" SortExpression="Rendimiento" UniqueName="Rendimiento" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorNominal" DataType="System.Decimal" FilterControlAltText="Filter ValorNominal column" HeaderText="Valor Nominal" SortExpression="ValorNominal" UniqueName="ValorNominal" DataFormatString="{0:###,##0.00}" Display="false">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorTransado" DataType="System.Decimal" FilterControlAltText="Filter ValorTransado column" HeaderText="Valor Transado" SortExpression="ValorTransado" UniqueName="ValorTransado" DataFormatString="{0:###,##0.00}" Display="false">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FormaNegociacion" Display="False" FilterControlAltText="Filter FormaNegociacion column" HeaderText="Forma Negociación" ReadOnly="True" SortExpression="FormaNegociacion" UniqueName="FormaNegociacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaModificacion" DataType="System.DateTime" FilterControlAltText="Filter FechaModificacion column" HeaderText="Fecha de Modificación" SortExpression="FechaModificacion" UniqueName="FechaModificacion" DataFormatString="{0:dd/MM/yyyy}">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Vendedor" FilterControlAltText="Filter Vendedor column" HeaderText="Vendedor" SortExpression="Vendedor" UniqueName="Vendedor">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Comprador" FilterControlAltText="Filter Comprador column" HeaderText="Comprador" SortExpression="Comprador" UniqueName="Comprador">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Mercado" FilterControlAltText="Filter Mercado column" HeaderText="Mercado" ReadOnly="True" SortExpression="Mercado" UniqueName="Mercado">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Duracion" DataType="System.DateTime" FilterControlAltText="Filter Duracion column" HeaderText="Duracion" SortExpression="Duracion" UniqueName="Duracion" DataFormatString="{0:hh:mm:ss}">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorNominalPesos" Aggregate="Sum" FooterAggregateFormatString="{0:RD$###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter ValorNominalPesos column" HeaderText="Valor Nominal Pesos" FooterText="Total:" ReadOnly="True" SortExpression="ValorNominalPesos" UniqueName="ValorNominalPesos" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorNominalDolares" Aggregate="Sum" FooterAggregateFormatString="{0:US$###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter ValorNominalDolares column" HeaderText="Valor Nominal Dólares" FooterText="Total:" ReadOnly="True" SortExpression="ValorNominalDolares" UniqueName="ValorNominalDolares" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorTransadoPesos" Aggregate="Sum" FooterAggregateFormatString="{0:RD$###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter ValorTransadoPesos column" HeaderText="Valor Transado Pesos" FooterText="Total:" ReadOnly="True" SortExpression="ValorTransadoPesos" UniqueName="ValorTransadoPesos" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorTransadoDolares" Aggregate="Sum" FooterAggregateFormatString="{0:US$###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter ValorTransadoDolares column" HeaderText="Valor Transado Dólares" FooterText="Total:" ReadOnly="True" SortExpression="ValorTransadoDolares" UniqueName="ValorTransadoDolares" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                </MasterTableView>

                <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                <FilterMenu EnableImageSprites="False"></FilterMenu>

            </telerik:RadGrid>

            <telerik:RadToolBar ID="RadToolBar2" runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                        Text="Acción" ToolTip="Nuevo,Guardar y Borrar consulta" Value="2">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 5">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                        Text="Mover" ToolTip="Mover a Ventana" Value="0">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Sep 1">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Text="Excel" Value="4" ToolTip="Exportar a Excel" ImageUrl="~/Images/excel.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 7">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Text="PDF" ToolTip="Exportar a PDF" Value="5" ImageUrl="~/Images/pdf.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 9">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Text="CSV" ToolTip="Exportar a CSV" Value="6" ImageUrl="~/Images/csv.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 11">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Sep 2">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>

        <div>
            <asp:SqlDataSource ID="SqlvConsultaOrdenesFirme" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT [CodigoLocal], [ISIN], [FechaPostura], [FechaVencimiento], [HoraPostura], [MonedaLiquidacion], [PosicionCompraVenta], [Precio], [RuedaNegociacion], [Rendimiento], [ValorNominal], [ValorTransado], [FormaNegociacion], [FechaModificacion], [Vendedor], [Comprador], [Mercado], [Duracion], [ValorNominalPesos], [ValorNominalDolares], [ValorTransadoPesos], [ValorTransadoDolares] FROM [vOrdenesEnFirmeTemporal]" DataSourceMode="DataReader">
                <SelectParameters>
                    <asp:Parameter Name="SqlWhere" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>


        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behaviors="Close, Move" InitialBehaviors="Close" VisibleStatusbar="False" Width="300px" OnClientClose="ActualizarFiltrosConsultas">
        </telerik:RadWindowManager>

        <telerik:RadTextBox ID="txtNombreConsultaUsuario" runat="server" Visible="False">
        </telerik:RadTextBox>

        <telerik:RadTextBox ID="txtIdUsuario" runat="server" Visible="False">
        </telerik:RadTextBox>

        <telerik:RadTextBox ID="txtIdConsulta" runat="server" Visible="False">
        </telerik:RadTextBox>

    </form>
</body>
</html>
