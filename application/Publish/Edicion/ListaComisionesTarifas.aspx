<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Edicion_ListaComisionesTarifas" Codebehind="ListaComisionesTarifas.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Comisiones y Tarifas</title>
    <script src="../Scripts/OpenWindows.js"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
        <script type="text/javascript">
            //<![CDATA[
            window.onload = function () {
                var el = null;
                if (document.all) {
                    el = document.all('RadGrid1_GridData');
                    el.style.height = 'auto';
                } else if (document.getElementById) {
                    el = document.getElementById('RadGrid1_GridData');
                    el.style.height = 'auto';
                }
            }
            //]]>
</script>
</head>

<body>

    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function ClientClose2() {

                    $find("RadAjaxManager1")
                        .ajaxRequest();

                    var oWnd = window.radopen("EditarTipoDocumento.aspx");
                    oWnd.setSize(550, 200);
                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close);
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>")
                        .get_masterTableView();
                    masterTable.rebind();
                }
            </script>
        </telerik:RadCodeBlock>
        <div lang="es-do">
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server"></telerik:RadScriptManager>
        </div>
        <div>
            <div style="height: 30px">
                <telerik:RadToolBar ID="RadToolBar1" Runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" Text="Nuevo"
                        Value="0"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                        Text="Editar" ToolTip="Editar Información" Value="1"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 3"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                        Text="Mover" ToolTip="Mover a Ventana" Value="7" ></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="2"></telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
            </div>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
            AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
            CellSpacing="0" Culture="es-DO" DataSourceID="SqlvComisionesyTarifas" GridLines="None"
            AllowFilteringByColumn="True" PageSize="20" AllowSorting="True">
                <GroupingSettings CaseSensitive="False" />
                <ExportSettings ExportOnlyData="True" FileName="Lista Tipo de Documentos"
                OpenInNewWindow="True">
                    <Pdf PageTitle="Lista Tipo de Documentos" Title="Lista Tipo de Documentos"
                    />
                </ExportSettings>
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <ClientEvents OnRowDblClick="ClientClose2" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                </ClientSettings>
                <MasterTableView Caption="Lista Comisiones Tarifas" CommandItemDisplay="Bottom"
                DataKeyNames="ComisionesTarifasID" DataSourceID="SqlvComisionesyTarifas" NoMasterRecordsText="No hay información para mostrar."
                CommandItemSettings-ShowAddNewRecordButton="False">
                    <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True"
                    ShowExportToExcelButton="True" ShowExportToPdfButton="True"></CommandItemSettings>
                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="ComisionesTarifasID" DataType="System.Int32"
                        FilterControlAltText="Filter ComisionesTarifasID column" HeaderText="ComisionesTarifasID"
                        ReadOnly="True" SortExpression="ComisionesTarifasID" UniqueName="ComisionesTarifasID"
                        display="false"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Concepto"
                        FilterControlAltText="Filter Concepto column" HeaderText="Concepto" SortExpression="Concepto"
                        UniqueName="Concepto"  CurrentFilterFunction="Contains" FilterControlWidth="220px" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Entidad" 
                            FilterControlAltText="Filter Entidad column" HeaderText="Entidad" 
                            SortExpression="Entidad" UniqueName="Entidad" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="Activo"
                        DataType="System.Boolean" FilterControlAltText="Filter Activo column" HeaderText="Activo"
                        SortExpression="Activo" UniqueName="Activo" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True"></telerik:GridCheckBoxColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
        <div>
            <asp:SqlDataSource ID="SqlvComisionesyTarifas" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
            SelectCommand="SELECT * FROM [vComisionesTarifas]"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
            Behaviors="Close, Move" Height="300px" Width="440px" BackColor="#F1F5FB"
            VisibleStatusbar="False" Modal="True" EnableViewState="false" 
                OnClientClose="RefreshGrid"></telerik:RadWindowManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1"
            runat="server"></telerik:RadAjaxManager>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>

        </div>
        <p>
           <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
        </p>
    </form>
</body>

</html>
