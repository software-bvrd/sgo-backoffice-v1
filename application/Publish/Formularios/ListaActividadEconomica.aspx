﻿<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_ListaActividadEconomica" Codebehind="ListaActividadEconomica.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sector</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function CargarVentanaEditarActEco(sender, args) {

                    VentanaEditarFlotante("EditarActividadEconomica.aspx", 440, 200, "RadAjaxManager1")
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
                            ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="3" ToolTip="Cancelar Edición" Visible="False">
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
                CellSpacing="0" Culture="es-DO" DataSourceID="SqlActividadEconomica" GridLines="None"
                AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True">
                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Lista de Sector"
                    OpenInNewWindow="True">
                    <Pdf PageTitle="Lista de Sector" Title="Lista de Sector" />
                </ExportSettings>

                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <ClientEvents OnRowDblClick="CargarVentanaEditarActEco" />
                    
                </ClientSettings>

                <MasterTableView Caption="Lista de Sector" CommandItemDisplay="Bottom"
                    DataKeyNames="ActividadEconomicaID" DataSourceID="SqlActividadEconomica" NoMasterRecordsText="No hay información para mostrar."
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
                        <telerik:GridBoundColumn DataField="ActividadEconomicaID" DataType="System.Int32"
                            FilterControlAltText="Filter ActividadEconomicaID column" HeaderText="ActividadEconomicaID"
                            ReadOnly="True" SortExpression="ActividadEconomicaID" UniqueName="ActividadEconomicaID"
                            display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Nombre"
                            FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre"
                            UniqueName="Nombre" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="Activo" DataType="System.Boolean"
                            FilterControlAltText="Filter Activo column" HeaderText="Activo"
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
            <asp:SqlDataSource ID="SqlActividadEconomica" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT * FROM [ActividadEconomica]"></asp:SqlDataSource>
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
