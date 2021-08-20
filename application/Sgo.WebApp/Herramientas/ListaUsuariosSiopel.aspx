<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListaUsuariosSiopel.aspx.vb" Inherits="Sgo.WebApp.ListaUsuariosSiopel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Usuarios Siopel</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
</head>

<body>

    <form id="form1" runat="server">

        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">

                function CargarVentanaEditarUsuariosSiopel(sender, args) {
                    VentanaEditarFlotante("EditarUsuariosSiopel.aspx", 600, 300, "RadAjaxManager1")
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                    masterTable.rebind();
                }


                function pageLoad() {
                    var grid = $find("RadGrid1");
                    var columns = grid.get_masterTableView().get_columns();


                    for (var i = 0; i < columns.length; i++) {
                        columns[i].resizeToFit();
                    }



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
                AllowAutomaticInserts="True" AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlListaUsuariosSiopel"
                AllowFilteringByColumn="True" AllowSorting="True" EnableHeaderContextMenu="True" AllowPaging="True" Height="300px" GroupPanelPosition="Top">
                <GroupingSettings CaseSensitive="False" />
                <ExportSettings ExportOnlyData="True" FileName="Lista Usuarios Siopel"
                    OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Lista Usuarios Siopel" Title="Lista Usuarios Siopel" />
                    <%--<Excel Format="Xlsx" />--%>
                    <Word Format="Docx" />
                </ExportSettings>

                <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                    <Selecting AllowRowSelect="True" />
                    <ClientEvents OnRowDblClick="CargarVentanaEditarUsuariosSiopel" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                </ClientSettings>

                <MasterTableView Caption="Lista Usuarios Siopel" CommandItemDisplay="None" DataSourceID="SqlListaUsuariosSiopel"
                    NoMasterRecordsText="No hay información para mostrar."
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

                        <telerik:GridBoundColumn DataField="Nombre"
                            FilterControlAltText="Filter Nombre column"
                            HeaderText="Nombre"
                            SortExpression="Nombre"
                            UniqueName="Nombre" ReadOnly="True"
                            AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            <ItemStyle Width="20px" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Agente"
                            FilterControlAltText="Filter Agente column"
                            HeaderText="Agente"
                            SortExpression="Agente"
                            UniqueName="Agente"
                            AndCurrentFilterFunction="Contains" 
                            AutoPostBackOnFilter="True">

                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="TipoUsuarios_Siopel" FilterControlAltText="Filter TipoUsuarios_Siopel column" HeaderText="Tipo Usuario Siopel" SortExpression="TipoUsuarios_Siopel" UniqueName="TipoUsuarios_Siopel" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            <ItemStyle Width="20px" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="PuestoBolsa"
                            FilterControlAltText="Filter PuestoBolsa column"
                            HeaderText="Puesto Bolsa"
                            SortExpression="PuestoBolsa"
                            UniqueName="PuestoBolsa" 
                            AndCurrentFilterFunction="Contains" 
                            AutoPostBackOnFilter="True">
                            <ItemStyle Width="35px" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FechaCreacion"
                            DataType="System.DateTime"
                            FilterControlAltText="Filter FechaCreacion column"
                            HeaderText="Fecha Creacion"
                            SortExpression="FechaCreacion"
                            UniqueName="FechaCreacion"
                            AndCurrentFilterFunction="Contains" 
                            AutoPostBackOnFilter="True"
                            >
                        </telerik:GridBoundColumn>

                        <telerik:GridCheckBoxColumn DataField="Activo"
                            DataType="System.Boolean"
                            FilterControlAltText="Filter Activo column"
                            HeaderText="Activo"
                            SortExpression="Activo"
                            UniqueName="Activo"
                            AndCurrentFilterFunction="Contains" 
                            AutoPostBackOnFilter="True">
                        </telerik:GridCheckBoxColumn>

                        <telerik:GridBoundColumn DataField="BO_Usuarios_Siopel_TID" FilterControlAltText="Filter BO_Usuarios_Siopel_TID column" HeaderText="ID Siopel" UniqueName="BO_Usuarios_Siopel_TID">
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

            <asp:SqlDataSource ID="SqlListaUsuariosSiopel" runat="server" ConnectionString="<%$ ConnectionStrings:MyReportLib.My.MySettings.CN %>"
                SelectCommand="SELECT BO_Usuarios_Siopel_TID, BO_TipoUsuarios_Siopel_TID, Nombre, TipoUsuarios_Siopel, Activo, Agente, PuestoBolsa, FechaCreacion FROM vUsuariosSiopel" DataSourceMode="DataReader" ProviderName="<%$ ConnectionStrings:MyReportLib.My.MySettings.CN.ProviderName %>"></asp:SqlDataSource>

            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Move" Height="420px" Width="520px" BackColor="#F1F5FB"
                VisibleStatusbar="False" Modal="True" EnableViewState="false"
                OnClientClose="RefreshGrid" AutoSize="True">
            </telerik:RadWindowManager>

            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>

        </div>

        <p>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
