﻿<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ListaCambiosTasas" Codebehind="ListaCambiosTasas.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="SEPARADOR">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                            Text="Mover" ToolTip="Mover a Ventana" Value="7">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/chart.gif"
                            Text="Fluctuación" ToolTip="Flutuación Moneda" Value="4">
                        </telerik:RadToolBarButton>

                    </Items>
                </telerik:RadToolBar>
            </div>

            <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
                CellSpacing="0" Culture="es-DO" DataSourceID="SqlMonedasHistoricoTasas" GridLines="None"
                AllowFilteringByColumn="True" PageSize="12" AllowSorting="True" EnableHeaderContextMenu="True"
                AllowPaging="True">

                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Lista de Tasas de Cambios"
                    OpenInNewWindow="True">
                    <Pdf PageTitle="Lista de Cambios de Tasas a Series" Title="Lista de Cambios de Tasas a Series" />
                </ExportSettings>

                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <ClientEvents OnRowDblClick="ClientClose2" />
                    <Resizing AllowColumnResize="True" AllowResizeToFit="True"/>
                </ClientSettings>


                <MasterTableView Caption="Lista de Tasas de Cambio" CommandItemDisplay="Bottom"
                    DataKeyNames="MonedasHistoricoTasasID" DataSourceID="SqlMonedasHistoricoTasas" NoMasterRecordsText="No hay información para mostrar."
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
                            SortExpression="Fecha" UniqueName="Fecha" DataFormatString="{0:dd/MM/yyyy} " DataType="System.DateTime">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="TasaCompra" DataType="System.Decimal"
                            FilterControlAltText="Filter TasaCompra column" HeaderText="Tasa Compra"
                            SortExpression="TasaCompra" UniqueName="TasaCompra" DataFormatString="{0:###,##0.0000}">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TasaVenta" DataType="System.Decimal"
                            FilterControlAltText="Filter TasaVenta column" HeaderText="Tasa Venta"
                            SortExpression="TasaVenta" UniqueName="TasaVenta" DataFormatString="{0:###,##0.00000000000000}">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre" UniqueName="Nombre">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TIPP" DataType="System.Decimal" FilterControlAltText="Filter TIPP column" HeaderText="TIPP" SortExpression="TIPP" UniqueName="TIPP" DataFormatString="{0:###,##0.0000}">
                        </telerik:GridBoundColumn>

                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle AlwaysVisible="True" />
                </MasterTableView>

                <PagerStyle AlwaysVisible="True" Mode="NextPrevNumericAndAdvanced" />
                <FilterMenu EnableImageSprites="False"></FilterMenu>


            </telerik:RadGrid>
        </div>
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
