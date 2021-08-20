<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ListaCambiosTasasSeries" Codebehind="ListaCambiosTasasSeries.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tasas de Emisiones</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/OpenWindows.js" type="text/javascript"></script>
</head>

<body>

    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">

                function ClientClose2() {

                    $find("RadAjaxManager1").ajaxRequest();
                    var oWnd = window.radopen("EditarCambiosTasasSeries.aspx");
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
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server"></telerik:RadScriptManager>
        </div>

        <div>
            <div>
                <telerik:RadToolBar ID="RadToolBar1" Runat="server" Width="100%">
                  
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
                        Text="SEPARADOR"></telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/chart.gif"
                        Text="Hístorico" ToolTip="Hístorico de Cambios" Value="4"></telerik:RadToolBarButton>
                        
                    </Items>
                </telerik:RadToolBar>
            </div>

            <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
            AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
            CellSpacing="0" Culture="es-DO" DataSourceID="SqlvEmisionSerieCalendarioCambioTasas" GridLines="None"
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
                </ClientSettings>
                
                <MasterTableView Caption="Lista de Tasas de Emisiones" CommandItemDisplay="Bottom"
                DataKeyNames="EmisionSerieCalendarioCambioTasasID" DataSourceID="SqlvEmisionSerieCalendarioCambioTasas" NoMasterRecordsText="No hay información para mostrar."
                CommandItemSettings-ShowAddNewRecordButton="False" AllowSorting="True">
                    <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                    ShowExportToPdfButton="True" showexporttocsvbutton="True"></CommandItemSettings>
                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    
                
                    
                    <Columns>

                        
                        <telerik:GridDateTimeColumn DataField="FechaStart" 
                            FilterControlAltText="Filter Fecha column" HeaderText="Fecha" 
                            SortExpression="FechaStart" UniqueName="FechaStart" AutoPostBackOnFilter="true" DataType="System.DateTime"
                            PickerType="DatePicker"
                            FilterControlWidth="100px"
                            DataFormatString="{0:dd/MM/yyyy} " AndCurrentFilterFunction="Contains">
                        </telerik:GridDateTimeColumn>


                        <telerik:GridBoundColumn DataField="Tasa" 
                            FilterControlAltText="Filter Tasa column" HeaderText="Tasa Interés" 
                            SortExpression="Tasa" UniqueName="Tasa" DataType="System.Decimal" AndCurrentFilterFunction="NotEqualTo" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Description" 
                            FilterControlAltText="Filter Description column" HeaderText="Descripción" 
                            SortExpression="Description" UniqueName="Description" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EmisionSerieCalendarioCambioTasasID" 
                            FilterControlAltText="Filter EmisionSerieCalendarioCambioTasasID column" HeaderText="EmisionSerieCalendarioCambioTasasID" 
                            SortExpression="EmisionSerieCalendarioCambioTasasID" UniqueName="EmisionSerieCalendarioCambioTasasID" DataType="System.Int32" ReadOnly="True"  Display="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreEmisor" FilterControlAltText="Filter NombreEmisor column" HeaderText="Emisor" SortExpression="NombreEmisor" UniqueName="NombreEmisor" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="CodEmisionBVRD" FilterControlAltText="Filter CodEmisionBVRD column" HeaderText="Cod. BVRD" SortExpression="CodEmisionBVRD" UniqueName="CodEmisionBVRD" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CodigoSerie" FilterControlAltText="Filter CodigoSerie column" HeaderText="Nemotécnico" SortExpression="CodigoSerie" UniqueName="CodigoSerie" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
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
            <asp:SqlDataSource ID="SqlvEmisionSerieCalendarioCambioTasas" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
            SelectCommand="SELECT [FechaStart], [Tasa], [Description], [EmisionSerieCalendarioCambioTasasID], [NombreEmisor], [CodEmisionBVRD], [CodigoSerie] FROM [vEmisionSerieCalendarioCambioTasas]" DataSourceMode="DataReader"></asp:SqlDataSource>
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
