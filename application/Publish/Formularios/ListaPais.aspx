<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_ListaPais" Codebehind="ListaPais.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Paises</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
</head>

<body>

    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">

                function CargarVentanaEditar(sender, args) {
                    VentanaEditarFlotante("EditarPais.aspx", 520, 240, "RadAjaxManager1");
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
                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 5" Visible="False">
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
                CellSpacing="0" Culture="es-DO" DataSourceID="SqlPais" GridLines="None"
                AllowFilteringByColumn="True" AllowSorting="True" AllowPaging="True" EnableHeaderContextMenu="True">

                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Lista de Paises"
                    OpenInNewWindow="True">
                    <Pdf PageTitle="Lista de Paises" Title="Lista de Paises" />
                </ExportSettings>
                <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                    <Selecting AllowRowSelect="True" />
                    <ClientEvents OnRowDblClick="CargarVentanaEditar" />
                    <Scrolling AllowScroll="True" />
                </ClientSettings>
                <MasterTableView Caption="Lista de Paises" CommandItemDisplay="Bottom"
                    DataKeyNames="PaisID" DataSourceID="SqlPais" NoMasterRecordsText="No hay información para mostrar."
                    CommandItemSettings-ShowAddNewRecordButton="False" AllowSorting="True" EnableHeaderContextMenu="True">
                    <CommandItemSettings ExportToPdfText="Exportar a PDF"
                        ShowExportToCsvButton="True" ShowExportToExcelButton="True"
                        ShowExportToPdfButton="True"></CommandItemSettings>
                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="PaisID" DataType="System.Int32" FilterControlAltText="Filter PaisID column"
                            HeaderText="PaisID" ReadOnly="True" SortExpression="PaisID" UniqueName="PaisID"
                            display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter Nombre column"
                            HeaderText="Nombre" SortExpression="Nombre" UniqueName="Nombre" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ISONUM"
                            FilterControlAltText="Filter ISONUM column" HeaderText="ISONUM" SortExpression="ISONUM"
                            UniqueName="ISONUM" ItemStyle-Width="300px" DataType="System.Int32" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            <ItemStyle Width="300px"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ISO2" FilterControlAltText="Filter ISO2 column"
                            HeaderText="ISO2" SortExpression="ISO2" UniqueName="ISO2" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ISO3" FilterControlAltText="Filter ISO3 column"
                            HeaderText="ISO3" SortExpression="ISO3" UniqueName="ISO3" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
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
            <asp:SqlDataSource ID="SqlPais" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT PaisID, ISONUM, ISO2, ISO3, Nombre FROM Pais ORDER BY Nombre" DataSourceMode="DataReader"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Move" Height="300px" Width="390px" BackColor="#F1F5FB"
                VisibleStatusbar="False" Modal="True" EnableViewState="false">
            </telerik:RadWindowManager>
        </div>
        <p>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </p>

        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>

    </form>
</body>

</html>
