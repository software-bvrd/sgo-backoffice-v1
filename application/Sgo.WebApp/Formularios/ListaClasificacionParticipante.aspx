﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListaClasificacionParticipante.aspx.vb" Inherits="Sgo.WebApp.ListaClasificacionParticipante" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clasificación Participante</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function CargarVentanaEditarClaPar(sender, args) {

                    VentanaEditarFlotante("EditarClasificacionParticipante.aspx", 500, 320, "RadAjaxManager1")
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
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False"
                CellSpacing="0" Culture="es-DO" DataSourceID="SqlClasificacionParticipante" GridLines="None"
                AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True">
                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Lista de Clasificación Participantes"
                    OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Lista de Clasificación Participantes" Title="Lista de Clasificación Participantes" />
                    <%--<Excel Format="Xlsx" />--%>
                    <Word Format="Docx" />
                </ExportSettings>

                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <ClientEvents OnRowDblClick="CargarVentanaEditarClaPar" />
                </ClientSettings>

                <MasterTableView Caption="Lista de Clasificación Participante" CommandItemDisplay="None"
                    DataKeyNames="ClasificacionParticipanteID" DataSourceID="SqlClasificacionParticipante" NoMasterRecordsText="No hay información para mostrar."
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
                        <telerik:GridBoundColumn DataField="ClasificacionParticipanteID" DataType="System.Int32"
                            FilterControlAltText="Filter ClasificacionParticipanteID column" HeaderText="ClasificacionParticipanteID"
                            ReadOnly="True" SortExpression="ClasificacionParticipanteID" UniqueName="ClasificacionParticipanteID"
                            Display="false">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Descripcion"
                            FilterControlAltText="Filter Nombre column" HeaderText="Descripción" SortExpression="Descripcion"
                            UniqueName="Descripcion" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="CodigoMercado"
                            FilterControlAltText="Filter CodigoMercado column" HeaderText="Código Mercado" SortExpression="CodigoMercado"
                            UniqueName="CodigoMercado" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridCheckBoxColumn DataField="Estatus" DataType="System.Boolean"
                            FilterControlAltText="Filter Activo column" HeaderText="Activo"
                            SortExpression="Estatus" UniqueName="Estatus" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                        </telerik:GridCheckBoxColumn>
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
            <asp:SqlDataSource ID="SqlClasificacionParticipante" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT * FROM [ClasificacionParticipante]"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Move" Height="300px" Width="470px" BackColor="#F1F5FB"
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
