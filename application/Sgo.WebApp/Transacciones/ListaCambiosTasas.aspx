<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ListaCambiosTasas" CodeBehind="ListaCambiosTasas.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Tasas de Cambio</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/OpenWindows.js" type="text/javascript"></script>
</head>

<body>
    <form id="form1" runat="server">

        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">

                function ClientClose2() {
                    $find("RadAjaxManager1").ajaxRequest();
                    var oWnd = window.radopen("EditarCambiosTasas.aspx");
                    oWnd.setSize(500, 350);
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close);
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                    masterTable.rebind();
                }

                function ventanaSecundaria(URL, ancho, alto) {
                    derecha = (screen.width - ancho) / 2;
                    arriba = (screen.height - alto) / 2;
                    string = "toolbar=0,scrollbars=1,directories=0,location=0,statusbar=0,menubar=0,resizable=0,width=" + ancho + ",height=" + alto + ",left=" + derecha + ",top=" + arriba + "";
                    fin = window.open(URL, "", string);
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

        <div lang="es-do">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
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
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 3">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="SEPARADOR">
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
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/chart.gif"
                            Text="Fluctuación" ToolTip="Flutuación Moneda" Value="4">
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
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
                CellSpacing="0" Culture="es-DO" DataSourceID="SqlMonedasHistoricoTasas" GridLines="None"
                AllowFilteringByColumn="True" PageSize="08" AllowSorting="True" EnableHeaderContextMenu="True"
                AllowPaging="True">
                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Lista de Tasas de Cambios"
                    OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Lista de Cambios de Tasas a Series" Title="Lista de Cambios de Tasas a Series" />
                    <%--<Excel Format="Xlsx" />--%>
                    <Word Format="Docx" />
                </ExportSettings>

                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <ClientEvents OnRowDblClick="ClientClose2" />
                    <Resizing AllowColumnResize="True" AllowResizeToFit="True" />
                </ClientSettings>

                <MasterTableView Caption="Lista de Tasas de Cambio" CommandItemDisplay="None"
                    DataKeyNames="MonedasHistoricoTasasID" DataSourceID="SqlMonedasHistoricoTasas" NoMasterRecordsText="No hay información para mostrar."
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

                        <telerik:GridBoundColumn DataField="MonedasHistoricoTasasID" DataType="System.Int32"
                            FilterControlAltText="Filter MonedasHistoricoTasasID column" HeaderText="MonedasHistoricoTasasID"
                            ReadOnly="True" SortExpression="MonedasHistoricoTasasID" UniqueName="MonedasHistoricoTasasID"
                            Display="False">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="TipoMonedaID"
                            FilterControlAltText="Filter TipoMonedaID column" HeaderText="TipoMonedaID" SortExpression="TipoMonedaID"
                            UniqueName="TipoMonedaID" DataType="System.Int32" Display="False">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Fecha"
                            FilterControlAltText="Filter Fecha column" HeaderText="Fecha"
                            SortExpression="Fecha" UniqueName="Fecha" DataFormatString="{0:dd/MM/yyyy} " DataType="System.DateTime"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="TasaCompra" DataType="System.Decimal"
                            FilterControlAltText="Filter TasaCompra column" HeaderText="Tasa Compra"
                            SortExpression="TasaCompra" UniqueName="TasaCompra" DataFormatString="{0:###,##0.0000}"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="TasaVenta" DataType="System.Decimal"
                            FilterControlAltText="Filter TasaVenta column" HeaderText="Tasa Venta"
                            SortExpression="TasaVenta" UniqueName="TasaVenta" DataFormatString="{0:###,##0.0000}"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre" UniqueName="Nombre"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="TIPP" DataType="System.Decimal" FilterControlAltText="Filter TIPP column" HeaderText="TIPP" SortExpression="TIPP" UniqueName="TIPP" DataFormatString="{0:###,##0.0000}"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="TPCV10" DataType="System.Decimal" FilterControlAltText="Filter TPCV10 column" HeaderText="Tasa Prom. C/V 10" SortExpression="TPCV10" UniqueName="TPCV10" DataFormatString="{0:###,##0.0000}"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="TPCV01" DataType="System.Decimal" FilterControlAltText="Filter TPCV01 column" HeaderText="Tasa Prom. C/V 1" SortExpression="TPCV01" UniqueName="TPCV01" DataFormatString="{0:###,##0.0000}"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>




                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

                    <PagerStyle AlwaysVisible="True" PageSizeControlType="RadComboBox" Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                </MasterTableView>

                <PagerStyle AlwaysVisible="True" Mode="NextPrevNumericAndAdvanced" />
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>


        </div>

        <%-- DataSource --%>
        <div>
            <asp:SqlDataSource ID="SqlMonedasHistoricoTasas" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT * FROM [vMonedasHistoricoTasas] ORDER BY [Fecha] DESC" DataSourceMode="DataReader"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Move" Height="350px" Width="500px" BackColor="#F1F5FB"
                VisibleStatusbar="False" Modal="True" EnableViewState="false"
                OnClientClose="RefreshGrid">
            </telerik:RadWindowManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
        </div>


        <div>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </div>


    </form>
</body>
</html>
