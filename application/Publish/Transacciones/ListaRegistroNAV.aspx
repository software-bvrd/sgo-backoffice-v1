<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ListaRegistroNAV" Codebehind="ListaRegistroNAV.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro NAV</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/OpenWindows.js" type="text/javascript"></script>
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function ClientClose2() {

                    $find("RadAjaxManager1").ajaxRequest();
                    var oWnd = window.radopen("EditaRegistroNAV.aspx");
                    oWnd.setSize(500, 350);
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close);
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid.ClientID%>").get_masterTableView();
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
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server"></telerik:RadScriptManager>
        </div>

        <div>
            <div>
                <telerik:RadToolBar ID="RadToolBar1" Runat="server" Width="100%" SingleClick="None">
                  
                      <Items>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" Text="Nuevo"
                        Value="0"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                        Text="Editar" ToolTip="Editar Información" Value="1"></telerik:RadToolBarButton>
                         <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                        Text="Mover" ToolTip="Mover a Ventana" Value="7" ></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 3"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="2"></telerik:RadToolBarButton>
                        
                        <telerik:RadToolBarButton runat="server" 
                            ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="5">
                        </telerik:RadToolBarButton>   

                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="SEPARADOR" Visible="False"></telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/chart.gif"
                        Text="Hístorico" ToolTip="Hístorico de Cambios" Value="4" Visible="False"></telerik:RadToolBarButton>
                        
                    </Items>
                </telerik:RadToolBar>
            </div>

            <telerik:RadGrid ID="RadGrid" runat="server" AllowAutomaticDeletes="True"
            AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
            CellSpacing="0" Culture="es-DO" DataSourceID="SqlVNav" GridLines="None"
            AllowFilteringByColumn="True" PageSize="12" AllowSorting="True" EnableHeaderContextMenu="True"
                AllowPaging="True">
                
                <GroupingSettings CaseSensitive="False" />
                
                <ExportSettings ExportOnlyData="True" FileName="Lista de Registros NAV" 
                    OpenInNewWindow="True">
                    <Pdf PageTitle="Lista de Registros NAV" Title="Lista de Registros NAV" />
                </ExportSettings>

                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <ClientEvents OnRowDblClick="ClientClose2" />
                </ClientSettings>
                
                <MasterTableView Caption="Lista de Registros NAV" CommandItemDisplay="Bottom" DataSourceID="SqlVNav" NoMasterRecordsText="No hay información para mostrar."
                CommandItemSettings-ShowAddNewRecordButton="False" AllowSorting="True" DataKeyNames="ID">
                    <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                    ShowExportToPdfButton="True" showexporttocsvbutton="True"></CommandItemSettings>
                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                                                       
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <Columns>
                        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column" HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EmisorID" DataType="System.Int32" FilterControlAltText="Filter EmisorID column" HeaderText="EmisorID" SortExpression="EmisorID" UniqueName="EmisorID">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EmisionID" FilterControlAltText="Filter EmisionID column" HeaderText="EmisionID" SortExpression="EmisionID" UniqueName="EmisionID" DataType="System.Int32">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CodEmisionBVRD" FilterControlAltText="Filter CodEmisionBVRD column" HeaderText="CodEmisionBVRD" SortExpression="CodEmisionBVRD" UniqueName="CodEmisionBVRD">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EmisorNombre" FilterControlAltText="Filter EmisorNombre column" HeaderText="EmisorNombre" SortExpression="EmisorNombre" UniqueName="EmisorNombre">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Fecha" DataType="System.DateTime" FilterControlAltText="Filter Fecha column" HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAV" FilterControlAltText="Filter NAV column" HeaderText="NAV" SortExpression="NAV" UniqueName="NAV" DataType="System.Decimal">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CodigoSerie" FilterControlAltText="Filter CodigoSerie column" HeaderText="CodigoSerie" SortExpression="CodigoSerie" UniqueName="CodigoSerie">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Estatus" FilterControlAltText="Filter Estatus column" HeaderText="Estatus" SortExpression="Estatus" UniqueName="Estatus">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <PagerStyle AlwaysVisible="True" />
                </MasterTableView>

                <PagerStyle AlwaysVisible="True" Mode="NextPrevNumericAndAdvanced" />
                <FilterMenu EnableImageSprites="False"></FilterMenu>

            </telerik:RadGrid>
        </div>
        <div>
            <asp:SqlDataSource ID="SqlVNav" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
            SelectCommand="SELECT [ID]
      ,[EmisorID]
      ,[EmisionID]
      ,[CodEmisionBVRD]
      ,[EmisorNombre]
      ,[Fecha]
      ,[NAV]
      ,[EmisionSerieID]
      ,[CodigoSerie]
      ,[Estatus]
  FROM [vNAV]" DataSourceMode="DataReader"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
            Behaviors="Close, Move" Height="350px" Width="500px" BackColor="#F1F5FB"
            VisibleStatusbar="False" Modal="True" EnableViewState="false" 
                OnClientClose="RefreshGrid"></telerik:RadWindowManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
        </div>

        <div>
           <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
        </div>


    </form>

</body>

</html>
