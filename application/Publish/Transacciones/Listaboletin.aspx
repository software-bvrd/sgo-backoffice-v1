<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_Listaboletin" Codebehind="Listaboletin.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generación boletín</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/OpenWindows.js" type="text/javascript"></script>

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


                function ventanaSecundaria(URL, ancho, alto) {
                    //window.open(URL, "ventana1", "width=auto,height=auto,scrollbars=NO")
                    derecha = (screen.width - ancho) / 2;
                    arriba = (screen.height - alto) / 2;
                    string = "toolbar=0,scrollbars=1,location=no,statusbar=0,menubar=0,resizable=0,width=" + ancho + ",height=" + alto + ",left=" + derecha + ",top=" + arriba + "";
                    fin = window.open(URL, "", string);
                }


                function ClientClose2() {

                    $find("RadAjaxManager1").ajaxRequest();
                    var oWnd = window.radopen("EditarBoletin.aspx");
                    oWnd.setSize(460, 200);
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close);
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
                CellSpacing="0" Culture="es-DO" DataSourceID="SqlBoletin" GridLines="None"
                AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True"
                AllowPaging="True" AllowCustomPaging="True">
                <GroupingSettings CaseSensitive="False" />
                
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <ClientEvents OnRowDblClick="ClientClose2" />
                    <Resizing AllowColumnResize="True" AllowResizeToFit="True"/>
                </ClientSettings>

                <MasterTableView Caption="Lista de Boletines" CommandItemDisplay="Bottom"
                    DataKeyNames="BoletinID" DataSourceID="SqlBoletin" NoMasterRecordsText="No hay información para mostrar."
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
                        <telerik:GridBoundColumn DataField="BoletinID" DataType="System.Int32"
                            FilterControlAltText="Filter BoletinID column" HeaderText="BoletinID"
                            ReadOnly="True" SortExpression="BoletinID" UniqueName="BoletinID"
                            Display="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Fecha" DataType="System.DateTime"
                            FilterControlAltText="Filter Fecha column" HeaderText="Fecha"
                            SortExpression="Fecha" UniqueName="Fecha"
                            FilterControlWidth="95px"
                            DataFormatString="{0:dd/MM/yyyy} " AndCurrentFilterFunction="EqualTo" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Secuencial" DataType="System.Int64"
                            FilterControlAltText="Filter Secuencial column" HeaderText="Rueda No."
                            SortExpression="Secuencial" UniqueName="Secuencial" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipoReporte" DataType="System.String"
                            FilterControlAltText="Filter TipoReporte column" HeaderText="Rueda No."
                            SortExpression="TipoReporte" UniqueName="TipoReporte" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
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
            <asp:SqlDataSource ID="SqlBoletin" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT BoletinID, Fecha, Secuencial,TipoReporte FROM vBoletin ORDER BY Fecha DESC" DataSourceMode="DataReader"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Move" Height="300px" Width="390px" BackColor="#F1F5FB"
                VisibleStatusbar="False" Modal="True" EnableViewState="false" OnClientClose="RefreshGrid">
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
