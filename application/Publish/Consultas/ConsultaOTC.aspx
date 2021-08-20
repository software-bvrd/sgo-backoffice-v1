<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ConsultaOTC" Codebehind="ConsultaOTC.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta Operaciones OTC</title>
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
                    <telerik:RadFilterDateFieldEditor FieldName="FechadeOperacion" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaVencimiento" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaLiquidacion" PickerType="DatePicker" />
                </FieldEditors>

            </telerik:RadFilter>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowGroupPanel="True"
                CellSpacing="0" DataSourceID="SqlvOperacionesCSV" GridLines="None"
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
                        <telerik:GridBoundColumn DataField="ISIN" FilterControlAltText="Filter ISIN column" HeaderText="ISIN" SortExpression="ISIN" UniqueName="ISIN" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechadeOperacion" FilterControlAltText="Filter FechadeOperacion column" HeaderText="FechadeOperacion" SortExpression="FechadeOperacion" UniqueName="FechadeOperacion" DataType="System.DateTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Fechadevencimiento" FilterControlAltText="Filter Fechadevencimiento column" HeaderText="Fechadevencimiento" SortExpression="Fechadevencimiento" UniqueName="Fechadevencimiento" DataType="System.DateTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechadeLiquidacion" DataType="System.DateTime" FilterControlAltText="Filter FechadeLiquidacion column" HeaderText="FechadeLiquidacion" SortExpression="FechadeLiquidacion" UniqueName="FechadeLiquidacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Hora" FilterControlAltText="Filter Hora column" HeaderText="Hora" SortExpression="Hora" UniqueName="Hora" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MercadodeNegociacion" FilterControlAltText="Filter MercadodeNegociacion column" HeaderText="MercadodeNegociacion" ReadOnly="True" SortExpression="MercadodeNegociacion" UniqueName="MercadodeNegociacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Monedadeliquidacion" FilterControlAltText="Filter Monedadeliquidacion column" HeaderText="Monedadeliquidacion" SortExpression="Monedadeliquidacion" UniqueName="Monedadeliquidacion" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NúmerodeOperacion" FilterControlAltText="Filter NúmerodeOperacion column" HeaderText="NúmerodeOperacion" SortExpression="NúmerodeOperacion" UniqueName="NúmerodeOperacion" DataType="System.Int32">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Periodicidad" FilterControlAltText="Filter Periodicidad column" HeaderText="Periodicidad" SortExpression="Periodicidad" UniqueName="Periodicidad" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Plazodelaoperacion" DataType="System.Int32" FilterControlAltText="Filter Plazodelaoperacion column" HeaderText="Plazodelaoperacion" ReadOnly="True" SortExpression="Plazodelaoperacion" UniqueName="Plazodelaoperacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Precio" DataType="System.Decimal" FilterControlAltText="Filter Precio column" HeaderText="Precio" SortExpression="Precio" UniqueName="Precio" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Formadenegociacion" FilterControlAltText="Filter Formadenegociacion column" HeaderText="Formadenegociacion" ReadOnly="True" SortExpression="Formadenegociacion" UniqueName="Formadenegociacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PremiooSpread" DataType="System.Decimal" FilterControlAltText="Filter PremiooSpread column" HeaderText="PremiooSpread" ReadOnly="True" SortExpression="PremiooSpread" UniqueName="PremiooSpread">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RendimientoNominal" DataType="System.Decimal" FilterControlAltText="Filter RendimientoNominal column" HeaderText="RendimientoNominal" SortExpression="RendimientoNominal" UniqueName="RendimientoNominal" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RuedadeNegociacion" FilterControlAltText="Filter RuedadeNegociacion column" HeaderText="RuedadeNegociacion" SortExpression="RuedadeNegociacion" UniqueName="RuedadeNegociacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipoCambioVenta" DataType="System.Decimal" FilterControlAltText="Filter TipoCambioVenta column" HeaderText="TipoCambioVenta" ReadOnly="True" SortExpression="TipoCambioVenta" UniqueName="TipoCambioVenta">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipodeOperacion" FilterControlAltText="Filter TipodeOperacion column" HeaderText="TipodeOperacion" SortExpression="TipodeOperacion" UniqueName="TipodeOperacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Valorfacial" DataType="System.Decimal" FilterControlAltText="Filter Valorfacial column" HeaderText="Valorfacial" SortExpression="Valorfacial" UniqueName="Valorfacial" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ValorTransado" DataType="System.Decimal" FilterControlAltText="Filter ValorTransado column" HeaderText="ValorTransado" SortExpression="ValorTransado" UniqueName="ValorTransado" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombredelEmisor" FilterControlAltText="Filter NombredelEmisor column" HeaderText="NombredelEmisor" SortExpression="NombredelEmisor" UniqueName="NombredelEmisor" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SectordelEmisor" FilterControlAltText="Filter SectordelEmisor column" HeaderText="SectordelEmisor" SortExpression="SectordelEmisor" UniqueName="SectordelEmisor" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SectorEspecifico" FilterControlAltText="Filter SectorEspecifico column" HeaderText="SectorEspecifico" SortExpression="SectorEspecifico" UniqueName="SectorEspecifico">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipodelInstrumento" FilterControlAltText="Filter TipodelInstrumento column" HeaderText="TipodelInstrumento" ReadOnly="True" SortExpression="TipodelInstrumento" UniqueName="TipodelInstrumento">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Monedadelinstrumento" FilterControlAltText="Filter Monedadelinstrumento column" HeaderText="Monedadelinstrumento" SortExpression="Monedadelinstrumento" UniqueName="Monedadelinstrumento">
                        </telerik:GridBoundColumn>
                    <%--    <telerik:GridNumericColumn DataField="ValorNominalPesos" DataType="System.Decimal" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" FilterControlAltText="Filter ValorNominalPesos column" HeaderText=" Valor Nominal en Pesos" SortExpression="ValorNominalPesos" UniqueName="ValorNominalPesos">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>--%>
                     <%--   <telerik:GridNumericColumn DataField="ValorNominalDolares" DataType="System.Decimal" FooterAggregateFormatString="{0:US$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" FilterControlAltText="Filter ValorNominalDolares column" HeaderText="Valor Nominal en Dólares" SortExpression="ValorNominalDolares" UniqueName="ValorNominalDolares">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>--%>
                    <%--    <telerik:GridNumericColumn DataField="ValorTransadoPesos" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorTransadoPesos column" HeaderText="Valor Transado en Pesos" SortExpression="ValorTransadoPesos" UniqueName="ValorTransadoPesos">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>--%>
                   <%--     <telerik:GridNumericColumn DataField="ValorTransadoDolares" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:US$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorTransadoDolares column" HeaderText="Valor Transado en Dólares" SortExpression="ValorTransadoDolares" UniqueName="ValorTransadoDolares">
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
                        </telerik:GridNumericColumn>--%>
                         <telerik:GridBoundColumn DataField="PuestoBolsaVendedor" FilterControlAltText="Filter Puesto Bolsa Vendedor column" HeaderText="Puesto Bolsa Vendedor" SortExpression="PuestoBolsaVendedor" UniqueName="PuestoBolsaVendedor">
                        </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="PuestoBolsaComprador" FilterControlAltText="Filter Puesto Bolsa Comprador column" HeaderText="Puesto Bolsa Comprador" SortExpression="PuestoBolsaComprador" UniqueName="PuestoBolsaComprador">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CantidadOperaciones" DataType="System.Int32" FilterControlAltText="Filter CantidadOperaciones column" HeaderText="CantidadOperaciones" ReadOnly="True" SortExpression="CantidadOperaciones" UniqueName="CantidadOperaciones">
                        </telerik:GridBoundColumn>
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
                SelectCommand="SELECT * FROM [vProveedoraPreciosHechos_OTC]" DataSourceMode="DataReader">
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
