<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ListaComisiones" CodeBehind="ListaComisiones.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista Comisiones</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
</head>

<body>

    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

            <%-- Scripts --%>

            <script type="text/javascript">

                function CargarVentanaEditar() {
                    VentanaEditar("ConfirmarComisiones.aspx", 1300, 600, "RadAjaxManager1");
                }

                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                    masterTable.rebind();
                }


                function pageLoad() {
                    var grid = $find("RadGrid1");
                    var columns = grid.get_masterTableView().get_columns();
                    var radFilter = $find('<%=RadFilter1.ClientID %>');
                    var pickers = radFilter.get_element().getElementsByClassName("RadPicker");



                    for (var i = 0; i < pickers.length; i++) {
                        var picker = $find(pickers[i].firstElementChild.id);
                        picker.get_timePopupButton().style.display = "none";
                        picker.get_dateInput().set_displayDateFormat("dd/MM/yyyy");
                    }
                }
                function Generate(sender, e) {
                    $find("<%= RadAjaxManager1.ClientID %>").__doPostBack(sender.name, "");
                }

            </script>

        </telerik:RadCodeBlock>

        <%-- Script Manager --%>
        <div lang="es-do">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                <ClientEvents OnRequestStart="onRequestStart"></ClientEvents>
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadGrid1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>

                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>

            </telerik:RadAjaxManager>

            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
        </div>
        <div>

            <%-- ToolBar --%>
            <div>
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                            Text="Mover" ToolTip="Mover a Ventana" Value="7">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 1">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                            Text="Confirmar/Ver" ToolTip="Confirmar Comisiones" Value="1">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/icon-download.png"
                            Text="Decargar CSV por lote" ToolTip="Confirmar Comisiones" Value="2">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>
                <asp:Label ID="lblmsg" runat="server" Width="95%" ForeColor="#FF3300"></asp:Label>
            </div>

            <%-- Control de Filtros --%>

            <div class="FilterContainer">

                <telerik:RadFilter ID="RadFilter1" runat="server" FilterContainerID="RadGrid1"
                    CssClass="RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default " Culture="es-DO" ApplyButtonText="Aplicar Filtro">
                    <Localization FilterFunctionBetween="Entre"
                        FilterFunctionContains="Contiene"
                        FilterFunctionDoesNotContain="No Contiene"
                        FilterFunctionEndsWith="Finaliza Con"
                        FilterFunctionEqualTo="Igual a"
                        FilterFunctionGreaterThan="Mayor que"
                        FilterFunctionGreaterThanOrEqualTo="Es Mayor o Igual a"
                        FilterFunctionIsEmpty="Está vacio"
                        FilterFunctionIsNull="Es Nulo"
                        FilterFunctionLessThan="Menor que"
                        FilterFunctionLessThanOrEqualTo="Es Menor o Igual a"
                        FilterFunctionNotBetween="No Entre"
                        FilterFunctionNotEqualTo="No es Igual a "
                        FilterFunctionNotIsEmpty="No está vacio"
                        FilterFunctionNotIsNull="No es Nulo"
                        FilterFunctionStartsWith="Inicia Con"
                        GroupOperationAnd="Y"
                        GroupOperationNotAnd="No Y"
                        GroupOperationNotOr="No O"
                        GroupOperationOr="O" />
                    <FieldEditors>
                        <telerik:RadFilterDateFieldEditor FieldName="FechaInclusion" PickerType="DatePicker" />
                        <telerik:RadFilterDateFieldEditor FieldName="Concepto"  />
                        <telerik:RadFilterDateFieldEditor FieldName="Estatus" /> 
                    </FieldEditors>
                </telerik:RadFilter>
            </div>


            <%-- Grid --%>
            <div style="height: auto" id="gridContainer">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="True"
                    AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlComision"
                    AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True"
                    AllowPaging="True" GroupPanelPosition="Top" CellSpacing="-1" GridLines="Both">
                    <GroupingSettings CaseSensitive="False" />
                    <ExportSettings ExportOnlyData="True" FileName="Lista de Comisiones"
                        OpenInNewWindow="True" IgnorePaging="True">
                        <Pdf PageTitle="Lista de comisioens" Title="Lista de Comisiones" DefaultFontFamily="Arial Narrow" PageLeftMargin="5" PageRightMargin="5" FontType="Embed" PageWidth="297mm" PageHeight="210mm" />
                        <%--<Excel Format="Xlsx" />--%>
                        <Word Format="Docx" />
                    </ExportSettings>

                    <ClientSettings EnableRowHoverStyle="false" Scrolling-UseStaticHeaders="True">
                        <Selecting AllowRowSelect="True" />
                        <ClientEvents OnRowDblClick="CargarVentanaEditar" />
                        <Scrolling AllowScroll="True" ScrollHeight="290px" UseStaticHeaders="True" />
                        <Resizing AllowColumnResize="True" AllowResizeToFit="True" />
                    </ClientSettings>

                    <MasterTableView CommandItemDisplay="None"
                        DataKeyNames="ComisionHistoricoID" DataSourceID="SqlComision" NoMasterRecordsText="No hay información para mostrar."
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
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                                <FooterStyle Width="35px" />
                                <HeaderStyle Width="35px" />
                                <ItemStyle Width="35px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="FechaInclusion"
                                FilterControlAltText="Filter FechaInclusion column" HeaderText="Fecha Generaciòn"
                                SortExpression="FechaInclusion" UniqueName="FechaInclusion" DataFormatString="{0:dd/MM/yyyy} " DataType="System.DateTime"
                                AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                                <FooterStyle Width="155px" />
                                <HeaderStyle Width="155px" />
                                <ItemStyle Width="155px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Concepto"
                                FilterControlAltText="Filter Concepto column" HeaderText="Concepto"
                                SortExpression="Concepto" UniqueName="Concepto" AndCurrentFilterFunction="Contains" AutoPostBackOnFilter="True">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EstatusDescripcion"
                                FilterControlAltText="Filter EstatusDescripcion column"
                                HeaderText="Estatus Descripción"
                                SortExpression="EstatusDescripcion"
                                UniqueName="EstatusDescripcion"
                                AndCurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="True">
                                <FooterStyle Width="185px" />
                                <HeaderStyle Width="185px" />
                                <ItemStyle Width="185px" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Estatus"
                                FilterControlAltText="Filter Estatus column" HeaderText="Estatus"
                                SortExpression="Estatus" UniqueName="Estatus" AndCurrentFilterFunction="Contains" Display="false" AutoPostBackOnFilter="True">
                            
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ComisionHistoricoID"
                                FilterControlAltText="Filter ComisionHistoricoID column" HeaderText="ComisionHistoricoID"
                                SortExpression="ComisionHistoricoID" UniqueName="ComisionHistoricoID" AndCurrentFilterFunction="Contains" Display="false" AutoPostBackOnFilter="True">
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn HeaderText="Descargar"> 
                                <ItemTemplate> 
                                    <asp:Button runat="server" CommandName="Generate" ID="btnFile" Text="CSV" OnClientClick="Generate(this, event); return false;" />
                                </ItemTemplate>
                                 <FooterStyle Width="155px" />
                                <HeaderStyle Width="155px" />
                                <ItemStyle Width="155px" />
                            </telerik:GridTemplateColumn>

                             <telerik:GridTemplateColumn HeaderText="Enviar">
                                <ItemTemplate>
                                         <asp:Button runat="server" CommandName="Enviar" ID="btnenviar" Text="Finanza" OnClientClick="Generate(this, event); return false;" />
                                </ItemTemplate>
                                  <FooterStyle Width="155px" />
                                <HeaderStyle Width="155px" />
                                <ItemStyle Width="155px" />
                            </telerik:GridTemplateColumn>

                            <telerik:GridBoundColumn DataField="Identificador" FilterControlAltText="Filter column column" UniqueName="Identificador" Visible="True" HeaderText="Tipo">
                             <FooterStyle Width="185px" />
                                <HeaderStyle Width="185px" />
                                <ItemStyle Width="185px" />
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


        </div>

        <%-- Data --%>
        <div>
            <asp:SqlDataSource ID="SqlComision" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT CH.[ComisionHistoricoID]
                    ,CT.Concepto
                    ,CH.[FechaInicial]
                    ,CH.[FechaFinal]
                    ,CH.[Estatus] 
                    ,CASE WHEN CH.[Estatus] ='P' THEN 'Pendiente'
                    WHEN CH.[Estatus] ='C' THEN 'Confirmado no enviado'
                    WHEN CH.[Estatus] ='E' THEN 'Confirmado y enviado' END AS EstatusDescripcion
                    ,CH.[KeyComision]
                    ,CH.[FechaInclusion]
                    ,REPLACE(CT.IDENTIFICADOR,'#','') AS IDENTIFICADOR
                    FROM [dbo].[ComisionHistorico] CH
                    INNER JOIN [dbo].[ComisionesTarifas] CT ON CT.ComisionesTarifasID= CH.[ComisionesTarifasID]"
                DataSourceMode="DataReader"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
                Behaviors="Close, Maximize, Move" Height="300px" Width="390px" BackColor="#F1F5FB"
                VisibleStatusbar="False" Modal="True" EnableViewState="false"
                OnClientClose="RefreshGrid">
            </telerik:RadWindowManager>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </div>


        <div>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
        </div>


    </form>

</body>

</html>
