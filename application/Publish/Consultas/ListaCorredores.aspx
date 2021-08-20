<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Edicion_ListaCorredores" Codebehind="ListaCorredores.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta Corredores</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"> </script>

</head>
<body style="background-color: #F1F5FB">

    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function CargarEditarVentana(sender, args) {
                    VentanaEditar("../Edicion/EditarPuestoBolsaCorredor.aspx", 1300, 600, "RadAjaxManager1");
                }

                function ClientClose2() {

                    $find("RadAjaxManager1")
                        .ajaxRequest();
                    return;

                    var oWnd = window.radopen("");
                    oWnd.setSize(550, 200);
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close);
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>")
                        .get_masterTableView();
                    masterTable.rebind();
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
        <div lang="es-do">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        </div>
        <div>
            <div>
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                            Text="Editar" ToolTip="Editar Información" Value="1">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 3">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                            Text="Mover" ToolTip="Mover a Ventana" Value="7">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
            </div>

            <div>

                <telerik:RadFilter ID="RadFilter1" runat="server" AllowFilterOnBlur="True"
                    ApplyButtonText="Aplicar" FilterContainerID="RadGrid1"
                    CssClass="RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default "
                    AddExpressionToolTip="Agregar Expresión" AddGroupToolTip="Agregar Grupo"
                    BetweenDelimeterText="Y" RemoveToolTip="Remover Elemento">
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
                        <telerik:RadFilterDateFieldEditor FieldName="FechaLicencia" PickerType="DatePicker" />
                        <telerik:RadFilterDateFieldEditor FieldName="FechaLicenciaVence" PickerType="DatePicker" />
                        <telerik:RadFilterDateFieldEditor FieldName="FechaLicenciaSIV" PickerType="DatePicker" />
                        <telerik:RadFilterDateFieldEditor FieldName="FechaLicenciaSIVVence" PickerType="DatePicker" />
                    </FieldEditors>

                </telerik:RadFilter>

            </div>

            <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True"
                CellSpacing="0" Culture="es-DO" DataSourceID="SqlvPuestoBolsaCorredores" GridLines="None"
                AllowFilteringByColumn="True" AllowSorting="True" EnableHeaderContextMenu="True"
                ShowGroupPanel="True" GroupingSettings-CaseSensitive="False" AutoGenerateColumns="False" AllowPaging="True">

                <GroupingSettings CaseSensitive="False"></GroupingSettings>

                <ExportSettings FileName="Lista de Corredores"
                    OpenInNewWindow="True" IgnorePaging="True" ExportOnlyData="True">
                    <Pdf PageTitle="Lista de corredores" DefaultFontFamily="Arial Narrow"  PageLeftMargin="5"   PageRightMargin="5"  FontType="Embed"  PaperSize="A4" />
                 
                </ExportSettings>

                <ClientSettings AllowDragToGroup="True">
                    <Selecting AllowRowSelect="True" />
                    <Resizing EnableRealTimeResize="True" AllowColumnResize="True" AllowResizeToFit="True" />
                    <ClientEvents OnRowDblClick="CargarEditarVentana" />
                </ClientSettings>

                <MasterTableView CommandItemDisplay="TopAndBottom" DataSourceID="SqlvPuestoBolsaCorredores" NoMasterRecordsText="No hay información para mostrar."
                    CommandItemSettings-ShowAddNewRecordButton="False" Width="100%">
                    <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                        ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" ShowRefreshButton="false" />

                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>

                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>

                    <Columns>
                        <telerik:GridBoundColumn Display="False" FilterControlAltText="Filter PuestoBolsaCorredorID column" HeaderText="PuestoBolsaCorredorID" SortExpression="PuestoBolsaCorredorID" UniqueName="PuestoBolsaCorredorID" DataField="PuestoBolsaCorredorID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PuestoBolsaNombre" FilterControlAltText="Filter PuestoBolsaNombre column" HeaderText="Puesto de Bolsa" SortExpression="PuestoBolsaNombre" UniqueName="PuestoBolsaNombre" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBinaryImageColumn AllowFiltering="False" DataField="Foto"    FilterControlAltText="Filter Foto column" HeaderText="Foto" ImageAlign="Middle" ImageHeight="40px" ImageWidth="40px" ResizeMode="Crop" UniqueName="Foto"  >
                          
                            <HeaderStyle Width="60px"></HeaderStyle>
                        </telerik:GridBinaryImageColumn>
                        <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre" UniqueName="Nombre" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Telefono" FilterControlAltText="Filter Telefono column" HeaderText="Teléfono" SortExpression="Telefono" UniqueName="Telefono" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Activo" FilterControlAltText="Filter Activo column" HeaderText="Estado" SortExpression="Activo" UniqueName="Activo" AutoPostBackOnFilter="True" AndCurrentFilterFunction="Contains">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Licencia" FilterControlAltText="Filter Licencia column" HeaderText="Licencia" SortExpression="Licencia" UniqueName="Licencia" AutoPostBackOnFilter="True" AndCurrentFilterFunction="Contains">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaLicencia" DataFormatString="{0:dd/MM/yyyy} " DataType="System.DateTime" FilterControlAltText="Filter FechaLicencia column" HeaderText="Fecha Inicio Licencia" SortExpression="FechaLicencia" UniqueName="FechaLicencia" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaLicenciaVence" DataFormatString="{0:dd/MM/yyyy} " DataType="System.DateTime" FilterControlAltText="Filter FechaLicenciaVence column" HeaderText="Fecha Venc Licencia" SortExpression="FechaLicenciaVence" UniqueName="FechaLicenciaVence" AutoPostBackOnFilter="True" AndCurrentFilterFunction="Contains">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LicenciaSIV" FilterControlAltText="Filter LicenciaSIV column" HeaderText="Licencia SIV" SortExpression="LicenciaSIV" UniqueName="LicenciaSIV" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaLicenciaSIV" DataFormatString="{0:dd/MM/yyyy} " DataType="System.DateTime" FilterControlAltText="Filter FechaLicenciaSIV column" HeaderText="Fecha Inicio Licencia SIV" SortExpression="FechaLicenciaSIV" UniqueName="FechaLicenciaSIV" AutoPostBackOnFilter="True" AndCurrentFilterFunction="Contains">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaLicenciaSIVVence" DataFormatString="{0:dd/MM/yyyy} " DataType="System.DateTime" FilterControlAltText="Filter FechaLicenciaSIVVence column" HeaderText="Fecha Venc Licencia SIV" SortExpression="FechaLicenciaSIVVence" UniqueName="FechaLicenciaSIVVence" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                     
                     
                     
                     <%--   <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Handler.ashx?id=" + Eval("PuestoBolsaCorredorID").ToString%>' Width="30px" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                     --%>
                     
                     
                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                </MasterTableView>

                <ItemStyle Wrap="True" />

                <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>

                <FilterMenu EnableImageSprites="False"></FilterMenu>

            </telerik:RadGrid>
        </div>
        <div>
            <asp:SqlDataSource ID="SqlvPuestoBolsaCorredores" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT  P.[PuestoBolsaCorredorID], P.[Nombre],P.[Foto], P.[Telefono],(CASE WHEN P.Activo=1 THEN 'Activo' ELSE 'Inactivo' END) AS Activo,
P.[Licencia], P.[PuestoBolsaNombre], P.[FechaLicencia], P.[FechaLicenciaVence], P.[LicenciaSIV], P.[FechaLicenciaSIV], P.[FechaLicenciaSIVVence] 
FROM dbo.vPuestoBolsaCorredores  AS P
WHERE (P.Movimiento IN ('C','T')) 
AND P.FechaMovimiento = (SELECT TOP(1) FechaMovimiento from dbo.HistorialCorredor WHERE (PuestoBolsaCorredorID =P.PuestoBolsaCorredorID ) AND (Movimiento IN ('C','T')) ORDER BY FechaMovimiento DESC) 
ORDER BY P.FechaMovimiento DESC"
                DataSourceMode="DataReader"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Move" Height="300px" Width="390px" BackColor="#F1F5FB"
                VisibleStatusbar="False" Modal="True" EnableViewState="false" OnClientClose="RefreshGrid">
            </telerik:RadWindowManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1"
                runat="server">
            </telerik:RadAjaxManager>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>

        </div>
        <p>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
        </p>
    </form>
</body>

</html>
