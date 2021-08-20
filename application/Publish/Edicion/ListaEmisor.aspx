<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ListaEmisor" Codebehind="ListaEmisor.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Emisor</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>


</head>

<body>

    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">

                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow;
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                    return oWindow;
                }

                function ClosePage() {
                    GetRadWindow().Close();
                }

                function ClientClose2() {

                    $find("RadAjaxManager1").ajaxRequest();
                    var oWnd = window.radopen("EditarEmisor.aspx", "Editar Emisor");
                    oWnd.setSize(1300, 600);
                    oWnd.moveTo(10, 1);
                    oWnd.maximize();
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Maximize);
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                    masterTable.rebind();
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
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" Text="Nuevo"
                            Value="0" ToolTip="Mover ventana">
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
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                            Text="Mover" ToolTip="Mover a Ventana" Value="7">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>


                    </Items>
                </telerik:RadToolBar>
            </div>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
                CellSpacing="0" Culture="es-DO" DataSourceID="SqlEmisor" GridLines="None"
                AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True"
                AllowPaging="True">
                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Lista de Emisores"
                    OpenInNewWindow="True">
                    <Pdf PageTitle="Lista de Emisores" Title="Lista de Emisores" />
                </ExportSettings>

                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <ClientEvents OnRowDblClick="ClientClose2" />
                    <Resizing AllowColumnResize="True" AllowResizeToFit="True" />
                </ClientSettings>

                <MasterTableView Caption="Lista de Emisores" CommandItemDisplay="Bottom"
                    DataKeyNames="EmisorID" DataSourceID="SqlEmisor" NoMasterRecordsText="No hay información para mostrar."
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
                        <telerik:GridBoundColumn DataField="EmisorID" DataType="System.Int32"
                            FilterControlAltText="Filter EmisorID column" HeaderText="EmisorID"
                            ReadOnly="True" SortExpression="EmisorID" UniqueName="EmisorID"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreEmisor"
                            FilterControlAltText="Filter NombreEmisor column" HeaderText="Nombre" SortExpression="NombreEmisor"
                            UniqueName="NombreEmisor" HeaderStyle-Width="390px" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True" FilterControlWidth="300">
                            <HeaderStyle Width="390px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Direccion"
                            FilterControlAltText="Filter Direccion column" HeaderText="Dirección"
                            SortExpression="Direccion" UniqueName="Direccion" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Telefono"
                            FilterControlAltText="Filter Telefono column" HeaderText="Teléfono"
                            SortExpression="Telefono" UniqueName="Telefono" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipoEmisorNombre"
                            FilterControlAltText="Filter TipoEmisorNombre column" HeaderText="Tipo Emisor"
                            SortExpression="TipoEmisorNombre" UniqueName="TipoEmisorNombre" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SectorNombre"
                            FilterControlAltText="Filter SectorNombre column" HeaderText="Actividad Económica"
                            SortExpression="SectorNombre" UniqueName="SectorNombre" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

                </MasterTableView>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
        <div>
            <asp:SqlDataSource ID="SqlEmisor" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT * FROM [vEmisor] order by NombreEmisor" DataSourceMode="DataReader"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Maximize, Move" Height="300px" Width="390px" BackColor="#F1F5FB"
                VisibleStatusbar="False" Modal="True" EnableViewState="false"
                OnClientClose="RefreshGrid">
            </telerik:RadWindowManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </div>

        <p>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
        </p>
    </form>

</body>

</html>
