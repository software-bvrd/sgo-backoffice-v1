<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ListaEmision" Codebehind="ListaEmision.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Programas de Emisiones</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
</head>

<body>

    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

            <script type="text/javascript">

                function CargarVentanaEditar() {
                    VentanaEditar("EditarEmision.aspx", 1300, 600, "RadAjaxManager1");
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                    masterTable.rebind();
                }

            </script>
        </telerik:RadCodeBlock>

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
                            Text="Activar" ToolTip="Activar Emisión" Value="8">
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
            <div style="height: auto" id="gridContainer">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                    AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
                    CellSpacing="0" Culture="es-DO" DataSourceID="SqlEmision" GridLines="None"
                    AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True"
                    AllowPaging="True">
                    <GroupingSettings CaseSensitive="False" />
                    <ExportSettings ExportOnlyData="True" FileName="Lista de Emisores"
                        OpenInNewWindow="True">
                        <Pdf PageTitle="Lista de Emision" Title="Lista de Emision" />
                    </ExportSettings>

                    <ClientSettings EnableRowHoverStyle="false" Scrolling-UseStaticHeaders="True">
                        <Selecting AllowRowSelect="True" />
                        <ClientEvents OnRowDblClick="CargarVentanaEditar" />
                        <Scrolling AllowScroll="True" ScrollHeight="300px" UseStaticHeaders="True" />
                        <Resizing AllowColumnResize="True" AllowResizeToFit="True"/>
                    </ClientSettings>

                    <MasterTableView Caption="Lista de Emisiones" CommandItemDisplay="Bottom"
                        DataKeyNames="EmisionID" DataSourceID="SqlEmision" NoMasterRecordsText="No hay información para mostrar."
                        CommandItemSettings-ShowAddNewRecordButton="False" AllowSorting="True">
                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                            ShowExportToPdfButton="True" ShowExportToCsvButton="True"></CommandItemSettings>
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
                                display="false">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="CodEmisionBVRD"
                                FilterControlAltText="Filter CodEmisionBVRD column" HeaderText="Código BVRD"
                                SortExpression="CodEmisionBVRD" UniqueName="CodEmisionBVRD" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="NombreEmisor"
                                FilterControlAltText="Filter NombreEmisor column" HeaderText="Empresa Emisora"
                                SortExpression="NombreEmisor" UniqueName="NombreEmisor" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
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
                            </telerik:GridNumericColumn>

                            <telerik:GridNumericColumn DataFormatString="{0:$###,##0.00}" DataField="ValorNominal"
                                DataType="System.Decimal"
                                FilterControlAltText="Filter ValorNominal column"
                                HeaderText="Valor Nominal" SortExpression="ValorNominal"
                                UniqueName="ValorNominal" ItemStyle-HorizontalAlign="Right">
                            </telerik:GridNumericColumn>

                            <telerik:GridBoundColumn DataField="CantidadTramos" DataType="System.Int32"
                                FilterControlAltText="Filter CantidadTramos column"
                                HeaderText="Cantidad Tramos" SortExpression="CantidadTramos"
                                UniqueName="CantidadTramos" AutoPostBackOnFilter="True" AndCurrentFilterFunction="Contains">
                            </telerik:GridBoundColumn>

                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
            </div>
        </div>
        <div>
            <asp:SqlDataSource ID="SqlEmision" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT EmisionID, CodEmisionBVRD, CodEnSistema, EmisorID, Descripcion, CantidadTramos, FechaAprobacionBVRD, FechaAprobacionSIV, TipoAmortizacionCapitalID, FinalidadDeLaEmision, SubirAOP, MontoTotalDeLaEmision, MontoOfertadoAlPublico, MontoPendienteDeColocacionDelAOP, MontoPendienteDeOfertarAlPublico, BaseLiquidacionID, Estatus, Nota1, Nota2, TipoDeEmisionID, InstrumentoID, TipoMonedaID, PuestoBolsaID, FormaColocacionID, NombreEmisor, ValorNominal, NombreInstrumento FROM vEmisionTab WHERE (Estatus = N'Activo') ORDER BY NombreEmisor" DataSourceMode="DataReader"></asp:SqlDataSource>
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
