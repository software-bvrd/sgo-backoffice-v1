<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ListaRegistroNAV" CodeBehind="ListaRegistroNAV.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro NAV</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/OpenWindows.js" type="text/javascript"></script>
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function ClientClose2() {

                    $find("RadAjaxManager1").ajaxRequest();
                    var oWnd = window.radopen("EditaRegistroNAV.aspx");
                    oWnd.setSize(500, 350);
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close);
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid.ClientID%>").get_masterTableView();
                    masterTable.rebind();
                }

                function ventanaSecundaria(URL, ancho, alto) {

                    derecha = (screen.width - ancho) / 2;
                    arriba = (screen.height - alto) / 2;
                    string = "toolbar=0,scrollbars=1,directories=0,location=0,statusbar=0,menubar=0,resizable=0,width=" + ancho + ",height=" + alto + ",left=" + derecha + ",top=" + arriba + "";
                    fin = window.open(URL, "", string);
                }


                function pageLoad() {
                    var grid = $find("RadGrid");
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
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%" SingleClick="None">

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
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                            Text="Mover" ToolTip="Mover a Ventana" Value="7">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 3">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server"
                            ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="5">
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
                    </Items>
                </telerik:RadToolBar>
            </div>

            <%-- Control de Filtros --%>

            <div class="FilterContainer">

                <telerik:RadFilter ID="RadFilter1" runat="server" FilterContainerID="RadGrid"
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
            <telerik:RadGrid ID="RadGrid" runat="server" AllowAutomaticDeletes="True"
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlVNav"
                AllowFilteringByColumn="True" PageSize="12" AllowSorting="True" EnableHeaderContextMenu="True"
                AllowPaging="True" GroupPanelPosition="Top">

                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Lista de Registros NAV"
                    OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Lista de Registros NAV" Title="Lista de Registros NAV" />
                    <Word Format="Docx" />
                </ExportSettings>

                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <ClientEvents OnRowDblClick="ClientClose2" />
                </ClientSettings>

                <MasterTableView Caption="Lista de Registros NAV" CommandItemDisplay="None" DataSourceID="SqlVNav" NoMasterRecordsText="No hay información para mostrar."
                    CommandItemSettings-ShowAddNewRecordButton="False" AllowSorting="True" DataKeyNames="ID">


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
                        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID" Display="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EmisorID" DataType="System.Int32" FilterControlAltText="Filter EmisorID column" HeaderText="EmisorID" SortExpression="EmisorID" UniqueName="EmisorID" Display="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EmisionID" FilterControlAltText="Filter EmisionID column" HeaderText="EmisionID" SortExpression="EmisionID" UniqueName="EmisionID" DataType="System.Int32" Display="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CodEmisionBVRD" FilterControlAltText="Filter CodEmisionBVRD column" HeaderText="Cód Prog. Emisión BVRD" SortExpression="CodEmisionBVRD" UniqueName="CodEmisionBVRD"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EmisorNombre" FilterControlAltText="Filter EmisorNombre column" HeaderText="Emisor" SortExpression="EmisorNombre" UniqueName="EmisorNombre"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Fecha" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" FilterControlAltText="Filter Fecha column" HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="NAV" FilterControlAltText="Filter NAV column" HeaderText="NAV" SortExpression="NAV" UniqueName="NAV" DataType="System.Decimal" DataFormatString="{0:###,##0.00000000000000}" ItemStyle-HorizontalAlign="Right"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="CodigoSerie" FilterControlAltText="Filter CodigoSerie column" HeaderText="Emisión" SortExpression="CodigoSerie" UniqueName="CodigoSerie"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Estatus" FilterControlAltText="Filter Estatus column" HeaderText="Estatus" SortExpression="Estatus" UniqueName="Estatus"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                    </Columns>

                    <PagerStyle PageSizeControlType="RadComboBox" Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                </MasterTableView>

                <FilterMenu EnableImageSprites="False"></FilterMenu>

            </telerik:RadGrid>

        </div>

        <%-- Data --%>
        <div>
            <asp:SqlDataSource ID="SqlVNav" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT [ID]
      ,[EmisorID]
      ,[EmisionID]
      ,[CodEmisionBVRD]
      ,[EmisorNombre]
      ,[Fecha]
      ,[NAV]
      ,[EmisionSerieID]
      ,[CodigoSerie]
      ,[Estatus]
  FROM [vNAV]"
                DataSourceMode="DataReader"></asp:SqlDataSource>
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
        </div>


    </form>

</body>

</html>
