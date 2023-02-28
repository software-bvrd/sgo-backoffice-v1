<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ConsultaNAV" CodeBehind="ConsultaNAV.aspx.vb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta NAV</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <sfcript src="../Scripts/TamanoObjetos.js" type="text/javascript"></sfcript>
</head>
<body style="background-color: #F1F5FB">
    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function ActualizarFiltrosConsultas(sender, args) {
                    __doPostBack("ActualizarFiltros");
                }

                function applyExpression(sender, args) {
                    if (args.get_keyCode() == 13) {
                        setTimeout(function () {
                            $find('<%=RadFilter1.ClientID %>').applyExpressions();
                        }, 10);
                    }
                }

                function onRequestStart(sender, args) {
                    if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 || args.get_eventTarget().indexOf("ExportToWordButton") >= 0 || args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
                        args.set_enableAjax(false);
                    }
                }

                function pageLoad() {
                    var grid = $find("RadGrid1");
                    var columns = grid.get_masterTableView().get_columns();
                    var radFilter = $find('<%=RadFilter1.ClientID %>');
                    var pickers = radFilter.get_element().getElementsByClassName("RadPicker");

                    for (var i = 0; i < columns.length; i++) {
                        columns[i].resizeToFit();
                    }

                    for (var i = 0; i < pickers.length; i++) {
                        var picker = $find(pickers[i].firstElementChild.id);
                        picker.get_timePopupButton().style.display = "none";
                        picker.get_dateInput().set_displayDateFormat("dd/MM/yyyy");
                    }
                }
            </script>
        </telerik:RadCodeBlock>
        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

        <telerik:RadAjaxManager ID="RadAjaxManager1"
            runat="server">
            <ClientEvents OnRequestStart="onRequestStart"></ClientEvents>
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                    <UpdatedControls>
                        <%--<telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>--%>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>

        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
        <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
            <Items>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                    Text="Acción" ToolTip="Nuevo,Guardar y Borrar consulta" Value="2">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 5">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                    Text="Mover" ToolTip="Mover a Ventana" Value="0">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Sep 1">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" Text="Excel" Value="4" ToolTip="Exportar a Excel" ImageUrl="~/Images/excel.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 7">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" Text="PDF" ToolTip="Exportar a PDF" Value="5" ImageUrl="~/Images/pdf.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 9">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" Text="CSV" ToolTip="Exportar a CSV" Value="6" ImageUrl="~/Images/csv.png">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 11">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                    Text="Cancelar" ToolTip="Cancelar Edición" Value="1">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Sep 2">
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
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
                    <telerik:RadFilterDateFieldEditor FieldName="Fecha" PickerType="DatePicker" />
                </FieldEditors>
            </telerik:RadFilter>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlvNAV"
                Culture="es-DO" EnableHeaderContextMenu="True"
                ShowFooter="True" AllowPaging="True" PageSize="12" RenderMode="Auto" GroupPanelPosition="Top">
                <GroupingSettings CaseSensitive="False" />
                <ExportSettings ExportOnlyData="True" FileName="Consulta NAV" OpenInNewWindow="True" IgnorePaging="True" UseItemStyles="true">
                    <Pdf PageTitle="NAV" DefaultFontFamily="Arial Narrow" PageLeftMargin="5" PageRightMargin="5" FontType="Embed" PageWidth="297mm" PageHeight="210mm" />
                    <%--<Excel Format="Xlsx" />--%>
                    <Word Format="Docx" />
                </ExportSettings>
                <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True" />
                    <Resizing EnableRealTimeResize="True" AllowColumnResize="True" AllowResizeToFit="True" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
                </ClientSettings>
                <MasterTableView DataSourceID="SqlvNAV" CommandItemDisplay="TopAndBottom" ShowGroupFooter="true" ShowFooter="true" DataKeyNames="EmisorID">
                    <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                        ShowExportToCsvButton="false" ShowExportToExcelButton="false" ShowExportToPdfButton="false" ShowRefreshButton="false" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                        Visible="True" Created="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="Fecha" FilterControlAltText="Fecha" HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha" DataFormatString="{0:dd/MM/yyyy} " DataType="System.DateTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CodEmisionBVRD" FilterControlAltText="Filter CodEmisionBVRD column" HeaderText="Código BVRD" SortExpression="CodEmisionBVRD" UniqueName="CodEmisionBVRD" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EmisorNombre" FilterControlAltText="Filter NombreEmisor column" HeaderText="Nombre Emisor" SortExpression="NombreEmisor" UniqueName="NombreEmisor" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CodigoSerie" FilterControlAltText="Filter CodigoSerie column" HeaderText="Serie" SortExpression="CodigoSerie" UniqueName="CodigoSerie">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAV" DataFormatString="{0:###,##0.##############}" FilterControlAltText="Filter NAV column" HeaderText="NAV" SortExpression="NAV" UniqueName="NAV" DataType="System.Decimal">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CodigoISIN" FilterControlAltText="Filter CodigoISIN column" HeaderText="ISIN" SortExpression="CodigoISIN" UniqueName="CodigoISIN">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Instrumento" FilterControlAltText="Filter Instrumento column" HeaderText="Instrumento" SortExpression="CodigoISIN" UniqueName="Instrumento">
                        </telerik:GridBoundColumn>
                        <%-- 2016.07.04 --%>
                         <%--"{0:###,##0.000000}"--%> 
                        <telerik:GridBoundColumn DataField="NavAnterior" DataFormatString="{0:###,##0.00000000000000}" FilterControlAltText="Filter NavAnterior column" HeaderText="NAV Anterior" SortExpression="NavAnterior" UniqueName="NavAnterior" DataType="System.Decimal">
                        </telerik:GridBoundColumn>
                        <telerik:GridNumericColumn DataField="VariacionPorcentual"
                            DataFormatString="{0:###,##0.000000}%"
                            FilterControlAltText="Filter VariacionPorcentual column"
                            HeaderText="Variación Porcentual" SortExpression="VariacionPorcentual"
                            UniqueName="VariacionPorcentual">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox" Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu RenderMode="Auto"></HeaderContextMenu>
            </telerik:RadGrid>
            <telerik:RadToolBar ID="RadToolBar2" runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                        Text="Acción" ToolTip="Nuevo,Guardar y Borrar consulta" Value="2">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 5">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                        Text="Mover" ToolTip="Mover a Ventana" Value="0">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Sep 1">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Text="Excel" Value="4" ToolTip="Exportar a Excel" ImageUrl="~/Images/excel.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 7">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Text="PDF" ToolTip="Exportar a PDF" Value="5" ImageUrl="~/Images/pdf.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 9">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Text="CSV" ToolTip="Exportar a CSV" Value="6" ImageUrl="~/Images/csv.png">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 11">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Sep 2">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div>
            <asp:SqlDataSource ID="SqlvNAV" runat="server" DataSourceMode="DataReader">
                <SelectParameters>
                    <asp:Parameter Name="SqlWhere" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behaviors="Close, Move" InitialBehaviors="Close" VisibleStatusbar="False" Width="300px" OnClientClose="ActualizarFiltrosConsultas">
        </telerik:RadWindowManager>
        <telerik:RadTextBox ID="txtNombreConsultaUsuario" runat="server" Visible="False">
        </telerik:RadTextBox>
        <telerik:RadTextBox ID="txtIdUsuario" runat="server" Visible="False">
        </telerik:RadTextBox>
        <telerik:RadTextBox ID="txtIdConsulta" runat="server" Visible="False">
        </telerik:RadTextBox>
    </form>
</body>
</html>
