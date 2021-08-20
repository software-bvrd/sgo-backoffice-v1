<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_ListaBaseLiquidacion" Codebehind="ListaBaseLiquidacion.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Base Liquidación</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function CargarVentanaEditar(sender, args) {
                    VentanaEditarFlotante("EditarBaseLiquidacion.aspx", 500, 320, "RadAjaxManager1")
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
                            ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="3" Visible="False">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 6" Visible="False">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                            Text="Mover" ToolTip="Mover a Ventana" Value="7">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 8">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
            </div>

            <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
                CellSpacing="0" Culture="es-DO" DataSourceID="SqlBaseLiquidacion" GridLines="None"
                AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True"
                AllowPaging="True" Height="395px">
                <GroupingSettings CaseSensitive="False" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <ClientEvents OnRowDblClick="CargarVentanaEditar" />
                </ClientSettings>
                <MasterTableView Caption="Lista Base de Liquidación" CommandItemDisplay="Bottom"
                    DataKeyNames="BaseLiquidacionID" DataSourceID="SqlBaseLiquidacion" NoMasterRecordsText="No hay información para mostrar."
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
                        
                        <telerik:GridBoundColumn DataField="BaseLiquidacionID" DataType="System.Int32"
                            FilterControlAltText="Filter BaseLiquidacionID column" HeaderText="BaseLiquidacionID"
                            ReadOnly="True" SortExpression="BaseLiquidacionID" UniqueName="BaseLiquidacionID"
                            display="false">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Nombre"
                            FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre"
                            UniqueName="Nombre" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DiasNatural"
                            FilterControlAltText="Filter DiasNatural column" HeaderText="Días Natural" SortExpression="DiasNatural"
                            UniqueName="DiasNatural" DataType="System.Int32" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="AnoNatural" DataType="System.Int32"
                            FilterControlAltText="Filter AnoNatural column" HeaderText="Año Natural"
                            SortExpression="AnoNatural" UniqueName="AnoNatural" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Tipo"
                            FilterControlAltText="Filter Tipo column" HeaderText="Tipo"
                            SortExpression="Tipo" UniqueName="Tipo" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="Activo"
                            DataType="System.Boolean" FilterControlAltText="Filter Activo column" HeaderText="Activo"
                            SortExpression="Activo" UniqueName="Activo" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridCheckBoxColumn>
                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
        <div>

            <asp:SqlDataSource ID="SqlBaseLiquidacion" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT * FROM [BaseLiquidacion]"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Move" Height="300px" Width="390px" BackColor="#F1F5FB"
                VisibleStatusbar="False" Modal="True" EnableViewState="false" OnClientClose="RefreshGrid">
            </telerik:RadWindowManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1"
                runat="server">
            </telerik:RadAjaxManager>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>

            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>

        </div>
    </form>
</body>

</html>
