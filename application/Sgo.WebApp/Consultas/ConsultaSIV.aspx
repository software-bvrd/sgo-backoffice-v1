<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Consultas_ConsultaSIV" CodeBehind="ConsultaSIV.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta SIV</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
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
                CssClass="RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default " Culture="es-DO">
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
                    <telerik:RadFilterDateFieldEditor FieldName="FechaOperacion" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaVencimiento" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaLiquidacion" PickerType="DatePicker" />
                </FieldEditors>

            </telerik:RadFilter>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowGroupPanel="False"
                CellSpacing="0" DataSourceID="SqlvOperacionesCSV" GridLines="None"
                Culture="es-DO" EnableHeaderContextMenu="True"
                ShowFooter="True" AllowPaging="True">
                <GroupingSettings CaseSensitive="False" />
                
                
                <ExportSettings ExportOnlyData="True" FileName="Operaciones Realizadas" OpenInNewWindow="True" IgnorePaging="True" UseItemStyles="true" >
                    <Pdf PageTitle="Operaciones Realizadas" DefaultFontFamily="Arial Narrow" PageLeftMargin="5" PageRightMargin="5" FontType="Embed" PageWidth="297mm" PageHeight="210mm"  />
                     <%--<Excel Format="Xlsx" />--%>
                    <Word Format="Docx" />
                </ExportSettings>

                <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True" />
                    <Resizing EnableRealTimeResize="True" AllowColumnResize="True" AllowResizeToFit="True" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
                </ClientSettings>
                <MasterTableView DataSourceID="SqlvOperacionesCSV" CommandItemDisplay="TopAndBottom" ShowGroupFooter="true" ShowFooter="true">
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
                        <telerik:GridBoundColumn DataField="FechaOperacion" DataType="System.DateTime" FooterText="Totales:" FilterControlAltText="Filter FechaOperacion column" HeaderText="Fecha Operación" SortExpression="FechaOperacion" UniqueName="FechaOperacion" DataFormatString="{0:dd/MM/yyyy} ">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NumeroOperacion" DataFormatString="{0:###,##0}" FilterControlAltText="Filter NumeroOperacion column" HeaderText="Número Operacion" SortExpression="NumeroOperacion" UniqueName="NumeroOperacion">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ISIN" FilterControlAltText="Filter ISIN column" HeaderText="ISIN" ReadOnly="True" SortExpression="ISIN" UniqueName="ISIN">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaVencimiento" DataType="System.DateTime" FilterControlAltText="Filter FechaVencimiento column" HeaderText="Fecha Vencimiento" SortExpression="FechaVencimiento" UniqueName="FechaVencimiento" DataFormatString="{0:dd/MM/yyyy} ">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaLiquidacion" DataType="System.DateTime" FilterControlAltText="Filter FechaLiquidacion column" HeaderText="Fecha Liquidación" SortExpression="FechaLiquidacion" UniqueName="FechaLiquidacion" DataFormatString="{0:dd/MM/yyyy} ">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Hora" Display="False" FilterControlAltText="Filter Hora column" HeaderText="Hora" ReadOnly="True" SortExpression="Hora" UniqueName="Hora" DataFormatString="{0:hh:mm:ss}">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MercadoNegociacion" FilterControlAltText="Filter MercadoNegociacion column" HeaderText="Mercado Negociación" SortExpression="MercadoNegociacion" UniqueName="MercadoNegociacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MonedaLiquidacion" FilterControlAltText="Filter MonedaLiquidacion column" HeaderText="Moneda Liquidación" SortExpression="MonedaLiquidacion" UniqueName="MonedaLiquidacion">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Periodicidad" FilterControlAltText="Filter Periodicidad column" HeaderText="Periodicidad" SortExpression="Periodicidad" UniqueName="Periodicidad">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PlazoOperacion" DataType="System.Int32" Display="False" FilterControlAltText="Filter PlazoOperacion column" HeaderText="Plazo Operación" ReadOnly="True" SortExpression="PlazoOperacion" UniqueName="PlazoOperacion">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Precio" DataFormatString="{0:###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter Precio column" HeaderText="Precio" SortExpression="Precio" UniqueName="Precio">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FormaNegociacion" Display="False" FilterControlAltText="Filter FormaNegociacion column" HeaderText="Forma Negociación" ReadOnly="True" SortExpression="FormaNegociacion" UniqueName="FormaNegociacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Spread" DataType="System.Decimal" Display="False" FilterControlAltText="Filter Spread column" HeaderText="Spread" ReadOnly="True" SortExpression="Spread" UniqueName="Spread">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RendimientoNominal" DataFormatString="{0:###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter RendimientoNominal column" HeaderText="Rendimiento Nominal" SortExpression="RendimientoNominal" UniqueName="RendimientoNominal">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RuedaNegociacion" FilterControlAltText="Filter RuedaNegociacion column" HeaderText="Rueda Negociación" SortExpression="RuedaNegociacion" UniqueName="RuedaNegociacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TasaVenta" DataFormatString="{0:###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter TasaVenta column" HeaderText="Tasa Venta" ReadOnly="True" SortExpression="TasaVenta" UniqueName="TasaVenta">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipoOperacion" Display="False" FilterControlAltText="Filter TipoOperacion column" HeaderText="Tipo Operación" SortExpression="TipoOperacion" UniqueName="TipoOperacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorFacial" DataFormatString="{0:###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter ValorFacial column" HeaderText="Valor Facial" SortExpression="ValorFacial" UniqueName="ValorFacial" Display="false">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorTransado" DataFormatString="{0:###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter ValorTransado column" HeaderText="Valor Transado" SortExpression="ValorTransado" UniqueName="ValorTransado" Display="false">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreEmisor" FilterControlAltText="Filter NombreEmisor column" HeaderText="Nombre Emisor" SortExpression="NombreEmisor" UniqueName="NombreEmisor">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SectorEmisor" Display="False" FilterControlAltText="Filter SectorEmisor column" HeaderText="Sector Emisor" SortExpression="SectorEmisor" UniqueName="SectorEmisor">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SectorEspecifico" Display="False" FilterControlAltText="Filter SectorEspecifico column" HeaderText="Sector Específico" SortExpression="SectorEspecifico" UniqueName="SectorEspecifico">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipoInstrumento" Display="False" FilterControlAltText="Filter TipoInstrumento column" HeaderText="Tipo Instrumento" ReadOnly="True" SortExpression="TipoInstrumento" UniqueName="TipoInstrumento">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MonedaInstrumento" FilterControlAltText="Filter MonedaInstrumento column" HeaderText="Moneda Instrumento" SortExpression="MonedaInstrumento" UniqueName="MonedaInstrumento">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridNumericColumn DataField="ValorNominalPesos" DataType="System.Decimal" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" FilterControlAltText="Filter ValorNominalPesos column" HeaderText=" Valor Nominal en Pesos" SortExpression="ValorNominalPesos" UniqueName="ValorNominalPesos">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorNominalDolares" DataType="System.Decimal" FooterAggregateFormatString="{0:US$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" FilterControlAltText="Filter ValorNominalDolares column" HeaderText="Valor Nominal en Dólares" SortExpression="ValorNominalDolares" UniqueName="ValorNominalDolares">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorTransadoPesos" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorTransadoPesos column" HeaderText="Valor Transado en Pesos" SortExpression="ValorTransadoPesos" UniqueName="ValorTransadoPesos">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorTransadoDolares" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:US$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorTransadoDolares column" HeaderText="Valor Transado en Dólares" SortExpression="ValorTransadoDolares" UniqueName="ValorTransadoDolares">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorNominalEquivalentePesos" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorNominalEquivalentePesos column" HeaderText="Valor Nominal Equivalente en Pesos" SortExpression="ValorNominalEquivalentePesos" UniqueName="ValorNominalEquivalentePesos">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorTransadoEquivalentePesos" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorTransadoEquivalentePesos column" HeaderText="Valor Transado Equivalente en Pesos" SortExpression="ValorTransadoEquivalentePesos" UniqueName="ValorTransadoEquivalentePesos">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0}" DataField="T" DataType="System.Decimal" FilterControlAltText="Filtar T column" HeaderText="T" SortExpression="T" UniqueName="T" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    <%--                    <GroupFooterTemplate>
                        Total VN Pesos:
                            <asp:Label ID="Label7" runat="server" Font-Bold="true" Text='<%# Eval("ValorNominalPesos", "{0:RD$###,###.00}")%>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; Total VN Dólares:
                            <asp:Label ID="Label8" runat="server" Font-Bold="true" Text='<%# Eval("ValorNominalDolares", "{0:US$###,###.00}")%>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; Total VT Pesos:
                            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text='<%# Eval("ValorTransadoPesos", "{0:RD$###,###.00}")%>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; Total VT Dólares.:
                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text='<%# Eval("ValorTransadoDolares", "{0:US$###,###.00}")%>'></asp:Label>

                    </GroupFooterTemplate>--%>
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
            <asp:SqlDataSource ID="SqlvOperacionesCSV" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT * FROM [vConsultaSIV]" DataSourceMode="DataReader">
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
