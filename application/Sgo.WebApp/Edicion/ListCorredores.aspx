﻿<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ListCorredores" CodeBehind="ListCorredores.aspx.vb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Corredores</title>
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
                    var oWnd = window.radopen("EditarCorredor.aspx", "Editar Corredor");
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
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlCorredor"
                AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True"
                AllowPaging="True" GroupPanelPosition="Top">
                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Lista de Corredores"
                    OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Lista de Corredores" Title="Lista de Corredores" DefaultFontFamily="Arial Narrow" PageLeftMargin="5" PageRightMargin="5" FontType="Embed" PageWidth="297mm" PageHeight="210mm" />
                    <%--<Excel Format="Xlsx" />--%>
                    <Word Format="Docx" />
                </ExportSettings>

                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <ClientEvents OnRowDblClick="ClientClose2" />
                    <Resizing AllowColumnResize="True" AllowResizeToFit="True" />
                </ClientSettings>

                <MasterTableView Caption="Lista de Corredores" CommandItemDisplay="None"
                    DataKeyNames="PuestoBolsaCorredorID" DataSourceID="SqlCorredor" NoMasterRecordsText="No hay información para mostrar."
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
                        <telerik:GridBoundColumn DataField="PuestoBolsaCorredorID" DataType="System.Int32"
                            FilterControlAltText="Filter PuestoBolsaCorredorID column" HeaderText="EmisorID"
                            ReadOnly="True" SortExpression="PuestoBolsaCorredorID" UniqueName="PuestoBolsaCorredorID"
                            Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Nombre"
                            FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre"
                            UniqueName="Nombre" HeaderStyle-Width="390px" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True" FilterControlWidth="300">
                            <HeaderStyle Width="390px"></HeaderStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="PuestoBolsa"
                            FilterControlAltText="Filter PuestoBolsa column" HeaderText="Puesto Bolsa" SortExpression="PuestoBolsa"
                            UniqueName="PuestoBolsa" HeaderStyle-Width="390px" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True" FilterControlWidth="300">
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

                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

                    <PagerStyle PageSizeControlType="RadComboBox" Mode="NextPrevNumericAndAdvanced"></PagerStyle>


                </MasterTableView>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
        <div>
            <asp:SqlDataSource ID="SqlCorredor" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT  p.NuevoPuestoBolsaID AS PuestoBolsaID
                , isnull(p.PuestoBolsaNombre,'No Asignado') as PuestoBolsa
                , P.[PuestoBolsaCorredorID]
                , P.[Nombre]
                , P.[Direccion]
                , P.[Telefono] 
                FROM dbo.vPuestoBolsaCorredores  AS P
                WHERE (P.Movimiento IN ('C','T')) 
                AND P.FechaMovimiento = (SELECT TOP(1) FechaMovimiento from dbo.HistorialCorredor WHERE (PuestoBolsaCorredorID =P.PuestoBolsaCorredorID ) AND (Movimiento IN ('C','T')) ORDER BY FechaMovimiento DESC) 
                AND P.[Nombre] is not null
                ORDER BY P.Nombre "
                DataSourceMode="DataReader"></asp:SqlDataSource>
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