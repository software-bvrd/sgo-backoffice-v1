<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_ListaPuestoBolsa" Codebehind="ListaPuestoBolsa.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Participantes del Mercado</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/OpenWindows.js" type="text/javascript"></script>

</head>

<body>
    <form id="form1" runat="server">

        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function ClientClose2() {

                    $find("RadAjaxManager1").ajaxRequest();
                    var oWnd = window.radopen("EditarPuestoBolsa.aspx", "Editar Puesto Bolsa");
                    oWnd.setSize(970, 600);
                    oWnd.moveTo(200, 1);
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Maximize);
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                    masterTable.rebind();
                }

                function OpenConfirm() {
                    radconfirm('<h3 style=\'color: #333399;\'>Are you sure?</h3>', confirmCallBackFn, 330, 100, null, 'RadConfirm custom title');
                    return false;
                }

            </script>
        </telerik:RadCodeBlock>

        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <telerik:RadToolBar ID="RadToolBar1" runat="server"
                Width="100%">
                
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
                    <telerik:RadToolBarButton runat="server" CheckOnClick="True"
                        ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="3">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 5">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                        Text="Mover" ToolTip="Mover a Ventana" Value="7">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                    </telerik:RadToolBarButton>
                </Items>

            </telerik:RadToolBar>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                AllowAutomaticInserts="True" AutoGenerateColumns="False" CellSpacing="0"
                Culture="es-DO" DataSourceID="SqlListaPuestoBolsa" GridLines="None" AllowFilteringByColumn="True" EnableHeaderContextMenu="True"
                PageSize="20" AllowSorting="True" GroupingSettings-CaseSensitive="False">

<GroupingSettings CaseSensitive="False"></GroupingSettings>

                <ExportSettings ExportOnlyData="True" FileName="Lista Puestos de Bolsa"
                    OpenInNewWindow="True">
                    <Pdf PageTitle="Lista Puestos de Bolsa" Title="Lista Puestos de Bolsa" />
                </ExportSettings>

                <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                    <Selecting AllowRowSelect="True" />
                    <ClientEvents OnRowDblClick="ClientClose2" />
                    <Scrolling AllowScroll="True" />
                    <Resizing AllowColumnResize="True" AllowResizeToFit="True"/>
                </ClientSettings>

                <MasterTableView Caption="Lista Puestos de Bolsa" CommandItemDisplay="Bottom"
                    DataKeyNames="PuestoBolsaID" DataSourceID="SqlListaPuestoBolsa" NoMasterRecordsText="No hay información para mostrar."
                    CommandItemSettings-ShowAddNewRecordButton="False" AllowSorting="True">
                    <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                        ShowExportToPdfButton="True" ShowExportToCsvButton="True"></CommandItemSettings>
                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>

                    <Columns>

                        <telerik:GridBoundColumn DataField="PuestoBolsaID" DataType="System.Int32"
                            FilterControlAltText="Filter PuestoBolsaID column" HeaderText="PuestoBolsaID"
                            ReadOnly="True" SortExpression="PuestoBolsaID" UniqueName="PuestoBolsaID"
                            display="false">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="Nombre"
                            FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre"
                            UniqueName="Nombre" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                       
                        <telerik:GridBoundColumn DataField="Descripcion"
                            FilterControlAltText="Filter Nombre column" HeaderText="Tipo Participante" SortExpression="Descripcion"
                            UniqueName="Descripcion" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Direccion"
                            FilterControlAltText="Filter Direccion column" HeaderText="Dirección" SortExpression="Direccion"
                            UniqueName="Direccion" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Telefono"
                            FilterControlAltText="Filter Telefono column" HeaderText="Teléfono" SortExpression="Telefono"
                            UniqueName="Telefono" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="Web" FilterControlAltText="Filter Web column"
                            HeaderText="Web" SortExpression="Web" UniqueName="Web" Visible="True" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>


                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
            <br />
        </div>
        <asp:SqlDataSource ID="SqlListaPuestoBolsa" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
            SelectCommand="SELECT * FROM [vPuestoBolsa] order by Nombre" DataSourceMode="DataReader"></asp:SqlDataSource>
        <telerik:RadAjaxManager ID="RadAjaxManager1"
            runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
            BackColor="#F1F5FB" Behaviors="Close, Maximize, Move" EnableViewState="false"
            Height="300px" VisibleStatusbar="False" Width="390px"
            OnClientClose="RefreshGrid" AnimationDuration="100"
            AutoSize="True" Style="z-index: 3000">
        </telerik:RadWindowManager>
        <p>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
        </p>
    </form>
</body>

</html>
