<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Consultas_ConsultaVectorPrecios" Codebehind="ConsultaCevaldom.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta Cevaldom </title>
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
                    <telerik:RadFilterDateFieldEditor FieldName="FECHA_LIQUIDACION" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FECHA_EMISION" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FECHA_VENCIMIENTO" PickerType="DatePicker" />
                </FieldEditors>

            </telerik:RadFilter>

            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowGroupPanel="True"
                CellSpacing="0" DataSourceID="SqlvOperacionesCSV" GridLines="None"
                Culture="es-DO" EnableHeaderContextMenu="True"
                ShowFooter="True" AllowPaging="True">
                <GroupingSettings CaseSensitive="False" />
                <ExportSettings ExportOnlyData="True" FileName="Operaciones Cevaldom" OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Operaciones Cevaldom" />
                </ExportSettings>
                <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True" />
                    <Resizing EnableRealTimeResize="True" AllowColumnResize="True" AllowResizeToFit="True" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
                </ClientSettings>
                <MasterTableView DataSourceID="SqlvOperacionesCSV" CommandItemDisplay="TopAndBottom" ShowGroupFooter="true" ShowFooter="true">
                    <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                        ShowExportToCsvButton="false" ShowExportToExcelButton="false" ShowExportToPdfButton="false" ShowRefreshButton="false" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                        Visible="True">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                        Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="FECHA_REGISTRO" DataType="System.DateTime" FooterText="Totales:"
                            FilterControlAltText="Filter FECHA_REGISTRO column" HeaderText="Fecha Registro" SortExpression="FECHA_REGISTRO" UniqueName="FECHA_REGISTRO" DataFormatString="{0:dd/MM/yyyy} ">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HORA_REGISTRO"
                            FilterControlAltText="Filter HORA_REGISTRO column" HeaderText="Hora Registro" SortExpression="HORA_REGISTRO" UniqueName="HORA_REGISTRO" Display="False" DataType="System.DateTime" DataFormatString="{0:hh:mm:ss}">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FECHA_LIQUIDACION"
                            FilterControlAltText="Filter FECHA_LIQUIDACION column" HeaderText="Fecha Liquidación" DataFormatString="{0:dd/MM/yyyy} "
                            SortExpression="FECHA_LIQUIDACION" UniqueName="FECHA_LIQUIDACION" DataType="System.DateTime">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NEMOTECNICO_EMISION"
                            FilterControlAltText="Filter NEMOTECNICO_EMISION column" HeaderText="Nemotécnico"
                            SortExpression="NEMOTECNICO_EMISION" UniqueName="NEMOTECNICO_EMISION">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CODIGO_ISIN"
                            FilterControlAltText="Filter CODIGO_ISIN column" HeaderText="Codigo ISIN"
                            SortExpression="CODIGO_ISIN" UniqueName="CODIGO_ISIN">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TIPO_INSTRUMENTO"
                            FilterControlAltText="Filter TIPO_INSTRUMENTO column" HeaderText="Tipo Instrumento"
                            SortExpression="TIPO_INSTRUMENTO" UniqueName="TIPO_INSTRUMENTO" Display="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EMISOR"
                            FilterControlAltText="Filter EMISOR column" HeaderText="Emisor"
                            SortExpression="EMISOR" UniqueName="EMISOR">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FECHA_EMISION"
                            FilterControlAltText="Filter FECHA_EMISION column" HeaderText="Fecha Emisión" DataFormatString="{0:dd/MM/yyyy} "
                            SortExpression="FECHA_EMISION" UniqueName="FECHA_EMISION" DataType="System.DateTime">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FECHA_VENCIMIENTO"
                            FilterControlAltText="Filter FECHA_VENCIMIENTO column" HeaderText="Fecha Vencimiento" DataFormatString="{0:dd/MM/yyyy} "
                            SortExpression="FECHA_VENCIMIENTO" UniqueName="FECHA_VENCIMIENTO" DataType="System.DateTime">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CANTIDAD_VALORES" Aggregate="Sum" FooterText="Total CV: "
                            FilterControlAltText="Filter CANTIDAD_VALORES column" HeaderText="Cantidad Valores"
                            SortExpression="CANTIDAD_VALORES" UniqueName="CANTIDAD_VALORES" DataType="System.Decimal" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VALOR_NOMINAL"
                            FilterControlAltText="Filter VALOR_NOMINAL column" HeaderText="Valor Nominal" Display="false" DataFormatString="{0:###,##0.00}"
                            SortExpression="VALOR_NOMINAL" UniqueName="VALOR_NOMINAL" DataType="System.Decimal">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VALOR_NOMINAL_TOTAL"
                            FilterControlAltText="Filter VALOR_NOMINAL_TOTAL column" HeaderText="Valor Nominal Total" Display="false" DataFormatString="{0:###,##0.00}"
                            SortExpression="VALOR_NOMINAL_TOTAL" UniqueName="VALOR_NOMINAL_TOTAL" DataType="System.Decimal">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VALOR_TRANSADO" Display="false" DataType="System.Decimal" FilterControlAltText="Filter VALOR_TRANSADO column" HeaderText="Valor Transado" SortExpression="VALOR_TRANSADO" UniqueName="VALOR_TRANSADO" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MONEDA_TRANSACCION" FilterControlAltText="Filter MONEDA_TRANSACCION column" HeaderText="Moneda" SortExpression="MONEDA_TRANSACCION" UniqueName="MONEDA_TRANSACCION" Display="False">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PeriodicidadEmision" DataType="System.Int32" FilterControlAltText="Filter PeriodicidadEmision column" HeaderText="Periodicidad Emisión" SortExpression="PeriodicidadEmision" UniqueName="PeriodicidadEmision" Display="False">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Tasa" FilterControlAltText="Filter Tasa column" HeaderText="Tasa" SortExpression="Tasa" UniqueName="Tasa" DataType="System.Decimal" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Precio" DataType="System.Decimal" FilterControlAltText="Filter Precio column" HeaderText="Precio" SortExpression="Precio" UniqueName="Precio" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Yield" DataType="System.Decimal" FilterControlAltText="Filter Yield column" HeaderText="Yield" SortExpression="Yield" UniqueName="Yield" DataFormatString="{0:###,##0.00}">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridNumericColumn DataField="ValorNominalPesos" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorNominalPesos column" HeaderText="Valor Nominal en Pesos" SortExpression="ValorNominalPesos" UniqueName="ValorNominalPesos">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorNominalDolares" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:US$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorNominalDolares column" HeaderText="Valor Nominal en Dólares" SortExpression="ValorNominalDolares" UniqueName="ValorNominalDolares">
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
                        Sub Total VN Pesos:
                                <asp:Label ID="Label6" runat="server" Font-Bold ="true"  Text='<%#Eval("ValorNominalPesos", "{0:RD$###,###.00}")%>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; Sub Total VN Dólares:
                            <asp:Label ID="Label7" runat="server"  Font-Bold ="true" Text='<%# Eval("ValorNominalDolares", "{0:US$###,###.00}")%>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; Sub Total VT Pesos:
                            <asp:Label ID="Label8" runat="server"  Font-Bold ="true" Text='<%# Eval("ValorTransadoPesos", "{0:RD$###,###.00}")%>'></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp; Sub Total VT Dólares:
                            <asp:Label ID="Label1" runat="server"  Font-Bold ="true" Text='<%# Eval("ValorTransadoDolares", "{0:US$###,###.00}")%>'></asp:Label>
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
                SelectCommand="SELECT * FROM [vConsultaVectorPreciosDetalleCevaldom]" DataSourceMode="DataReader">
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
