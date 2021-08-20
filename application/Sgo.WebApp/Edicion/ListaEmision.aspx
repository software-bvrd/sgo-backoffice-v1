<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ListaEmision" CodeBehind="ListaEmision.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Programas de Emisiones</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
</head>

<body>

    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

            <%-- Scripts --%>

            <script type="text/javascript">

                function CargarVentanaEditar() {
                    VentanaEditar("EditarEmision.aspx", 1300, 600, "RadAjaxManager1");
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                    masterTable.rebind();
                }


                function pageLoad() {
                    var grid = $find("RadGrid1");
                    var columns = grid.get_masterTableView().get_columns();
                    var radFilter = $find('<%=RadFilter1.ClientID %>');
                    var pickers = radFilter.get_element().getElementsByClassName("RadPicker");



                    for (var i = 0; i < pickers.length; i++) {
                        var picker = $find(pickers[i].firstElementChild.id);
                        picker.get_timePopupButton().style.display = "none";
                        picker.get_dateInput().set_displayDateFormat("dd/MM/yyyy");
                    }
                }


            </script>

        </telerik:RadCodeBlock>

        <%-- Script Manager --%>
        <div lang="es-do">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
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
        </div>

        <div>

            <%-- ToolBar --%>
            <div>
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                    <Items>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" Text="Nuevo"
                            Value="0">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 1">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                            Text="Editar" ToolTip="Editar Información" Value="1">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/ActivarEmision.png"
                            Text="Cambiar Estatus" ToolTip="Activar Emisión" Value="8">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 3">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                            Text="Mover" ToolTip="Mover a Ventana" Value="7">
                        </telerik:RadToolBarButton>

                        <%-- Exportar --%>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 90">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" Text="Excel" Value="90" ToolTip="Exportar a Excel" ImageUrl="~/Images/excel.png">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 91">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" Text="PDF" ToolTip="Exportar a PDF" Value="91" ImageUrl="~/Images/pdf.png">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 92">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" Text="CSV" ToolTip="Exportar a CSV" Value="92" ImageUrl="~/Images/csv.png">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 93">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" Text="Word" ToolTip="Exportar a Word" Value="93" ImageUrl="~/Images/ExportWord.png">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 94">
                        </telerik:RadToolBarButton>
                        <%-- Fin Exportar --%>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>

                    </Items>
                </telerik:RadToolBar>
            </div>

            <%-- Control de Filtros --%>

            <div class="FilterContainer">

                <telerik:RadFilter ID="RadFilter1" runat="server" FilterContainerID="RadGrid1"
                    CssClass="RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default " Culture="es-DO" ApplyButtonText="Aplicar Filtro">
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
                        <telerik:RadFilterDateFieldEditor FieldName="Fecha" PickerType="DatePicker" />
                    </FieldEditors>
                </telerik:RadFilter>
            </div>


            <%-- Grid --%>
            <div style="height: auto" id="gridContainer">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                    AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
                    CellSpacing="0" Culture="es-DO" DataSourceID="SqlEmision" GridLines="None"
                    AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True"
                    AllowPaging="True">
                    <GroupingSettings CaseSensitive="False" />
                    <ExportSettings ExportOnlyData="True" FileName="Lista de Emisores"
                        OpenInNewWindow="True" IgnorePaging="True">
                        <Pdf PageTitle="Lista de Emision" Title="Lista de Emision" DefaultFontFamily="Arial Narrow" PageLeftMargin="5" PageRightMargin="5" FontType="Embed" PageWidth="297mm" PageHeight="210mm" />
                        <%--<Excel Format="Xlsx" />--%>
                        <Word Format="Docx" />
                    </ExportSettings>

                    <ClientSettings EnableRowHoverStyle="false" Scrolling-UseStaticHeaders="True">
                        <Selecting AllowRowSelect="True" />
                        <ClientEvents OnRowDblClick="CargarVentanaEditar" />
                        <Scrolling AllowScroll="True" ScrollHeight="290px" UseStaticHeaders="True" />
                        <Resizing AllowColumnResize="True" AllowResizeToFit="True" />
                    </ClientSettings>

                    <MasterTableView Caption="Lista de Emisiones" CommandItemDisplay="None"
                        DataKeyNames="EmisionID" DataSourceID="SqlEmision" NoMasterRecordsText="No hay información para mostrar."
                        CommandItemSettings-ShowAddNewRecordButton="False" AllowSorting="True">

                        <CommandItemSettings
                            ShowExportToExcelButton="True"
                            ShowExportToPdfButton="True"
                            ShowExportToCsvButton="True"
                            ShowExportToWordButton="True"
                            ShowRefreshButton="True"
                            ExportToExcelText="Exportar a Excel"
                            ExportToWordText="Exportar a Word"
                            ExportToPdfText="Exportar a PDF"
                            ExportToCsvText="Exportar a CSV"></CommandItemSettings>

                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>

                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>

                        <Columns>

                            <telerik:GridBoundColumn DataField="EmisionID" DataType="System.Int32"
                                FilterControlAltText="Filter EmisionID column" HeaderText="EmisionID"
                                ReadOnly="True" SortExpression="EmisionID" UniqueName="EmisionID"
                                Display="false">
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="FechaAprobacionBVRD"
                                FilterControlAltText="Filter Fecha column" HeaderText="Fecha BVRD"
                                SortExpression="FechaAprobacionBVRD" UniqueName="FechaAprobacionBVRD" DataFormatString="{0:dd/MM/yyyy} " DataType="System.DateTime"
                                AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="CodEmisionBVRD"
                                FilterControlAltText="Filter CodEmisionBVRD column" HeaderText="Código BVRD"
                                SortExpression="CodEmisionBVRD" UniqueName="CodEmisionBVRD" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombreEmisor"
                                FilterControlAltText="Filter NombreEmisor column" HeaderText="Empresa Emisora"
                                SortExpression="NombreEmisor" UniqueName="NombreEmisor" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True"
                                HeaderStyle-Width="300px" FilterControlWidth="250">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombreInstrumento"
                                FilterControlAltText="Filter NombreInstrumento column" HeaderText="Instrumento"
                                SortExpression="NombreInstrumento" UniqueName="NombreInstrumento" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            </telerik:GridBoundColumn>

                            <telerik:GridNumericColumn DataFormatString="{0:$###,##0.00}" DataField="MontoTotalDeLaEmision"
                                DataType="System.Decimal"
                                FilterControlAltText="Filter MontoTotalDeLaEmision column"
                                HeaderText="Monto Total" SortExpression="MontoTotalDeLaEmision"
                                UniqueName="MontoTotalDeLaEmision" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </telerik:GridNumericColumn>

                            <telerik:GridNumericColumn DataFormatString="{0:$###,##0.00}" DataField="ValorNominal"
                                DataType="System.Decimal"
                                FilterControlAltText="Filter ValorNominal column"
                                HeaderText="Valor Nominal" SortExpression="ValorNominal"
                                UniqueName="ValorNominal" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </telerik:GridNumericColumn>

                            <telerik:GridBoundColumn DataField="CantidadTramos" DataType="System.Int32"
                                FilterControlAltText="Filter CantidadTramos column"
                                HeaderText="Cantidad Tramos" SortExpression="CantidadTramos"
                                UniqueName="CantidadTramos" AutoPostBackOnFilter="True" AndCurrentFilterFunction="Contains"
                                HeaderStyle-Width="120px">
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="UltimoNAV"
                                DataType="System.Int32"
                                FilterControlAltText="Filter UltimoNAV column"
                                HeaderText="Ultimo NAV"
                                SortExpression="UltimoNAV"
                                UniqueName="UltimoNAV"
                                AutoPostBackOnFilter="True"
                                AndCurrentFilterFunction="Contains"
                                HeaderStyle-Width="120px">
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="TipoMercado"
                                FilterControlAltText="Filter TipoMercado column"
                                HeaderText="Tipo Mercado"
                                SortExpression="TipoMercado"
                                UniqueName="TipoMercado"
                                AndCurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="True"
                                Display="false">
                            </telerik:GridBoundColumn>


                            <telerik:GridBoundColumn DataField="Estatus"
                                FilterControlAltText="Filter Estatus column"
                                HeaderText="Estatus"
                                SortExpression="Estatus"
                                UniqueName="Estatus"
                                AndCurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="True"
                                Display="false">
                            </telerik:GridBoundColumn>


                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                        </EditFormSettings>

                        <PagerStyle PageSizeControlType="RadComboBox" Mode="NextPrevNumericAndAdvanced"></PagerStyle>

                    </MasterTableView>

                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
            </div>


        </div>

        <%-- Data --%>
        <div>
            <asp:SqlDataSource ID="SqlEmision" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT EmisionID, CodEmisionBVRD, CodEnSistema, EmisorID, vEmisionTab.Descripcion, CantidadTramos, FechaAprobacionBVRD, FechaAprobacionSIV, TipoAmortizacionCapitalID, FinalidadDeLaEmision, SubirAOP, MontoTotalDeLaEmision, MontoOfertadoAlPublico, MontoPendienteDeColocacionDelAOP, MontoPendienteDeOfertarAlPublico, BaseLiquidacionID, ee.Descripcion as Estatus, Nota1, Nota2, TipoDeEmisionID, InstrumentoID, TipoMonedaID, PuestoBolsaID, FormaColocacionID, NombreEmisor, ValorNominal, NombreInstrumento, UltimoNAV, TipoMercado FROM vEmisionTab inner join EmisionEstatus ee on ee.CodigoEstatus = Estatus  WHERE (ee.MostrarEnEdicion =1) ORDER BY FechaAprobacionBVRD desc" DataSourceMode="DataReader"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Maximize, Move" Height="300px" Width="390px" BackColor="#F1F5FB"
                VisibleStatusbar="False" Modal="True" EnableViewState="false"
                OnClientClose="RefreshGrid">
            </telerik:RadWindowManager>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </div>


        <div>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
        </div>


    </form>

</body>

</html>
