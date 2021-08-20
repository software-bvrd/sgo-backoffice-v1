<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ConsultaOperacionesOTCCevaldom" CodeBehind="ConsultaOperacionesOTCCevaldom.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Consulta Emisores</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
</head>

<body style="background-color: #F1F5FB">
    <form id="form1" runat="server">

        <%-- JS --%>
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


        <%-- Scripts --%>
        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>


        <%-- Ajax Manager --%>
        <telerik:RadAjaxManager ID="RadAjaxManager1"
            runat="server">
            <ClientEvents OnRequestStart="onRequestStart"></ClientEvents>
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <%-- Loading Panel --%>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

        <%-- Barra de Herramientas Arriba --%>
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

            <%-- Filtros --%>
            <telerik:RadFilter ID="RadFilter1" runat="server" FilterContainerID="RadGrid1"
                CssClass="RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default " Culture="es-DO">
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
                    <telerik:RadFilterDateFieldEditor FieldName="Carga" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaCreacion" PickerType="DatePicker" />
                </FieldEditors>

            </telerik:RadFilter>

            <%-- Grid --%>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowGroupPanel="True"
                CellSpacing="0" DataSourceID="SqlvConsultaOperacionesOTCCevaldom" GridLines="None"
                Culture="es-DO" EnableHeaderContextMenu="True"
                ShowFooter="True" AllowPaging="True">

                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Operaciones OTC Aceptadas_Rechazadas Cevaldom" OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Operaciones OTC Aceptadas/Rechazadas Cevaldom" />
                    <%--<Excel Format="Xlsx" />--%>
                    <Word Format="Docx" />
                </ExportSettings>

                <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True" />
                    <Resizing EnableRealTimeResize="True" AllowColumnResize="True" AllowResizeToFit="True" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
                </ClientSettings>
                <MasterTableView DataSourceID="SqlvConsultaOperacionesOTCCevaldom" CommandItemDisplay="TopAndBottom" ShowGroupFooter="true" ShowFooter="true" DataKeyNames="PROCESO">
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

                        <telerik:GridBoundColumn DataField="PROCESO" FilterControlAltText="Filter PROCESO column" HeaderText="PROCESO" SortExpression="EmisorID" UniqueName="PROCESO" ReadOnly="True" DataType="System.Int32">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="PARTICIPANTE" FilterControlAltText="Filter PARTICIPANTE column" HeaderText="Participante" SortExpression="PARTICIPANTE" UniqueName="PARTICIPANTE" ReadOnly="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="MECANISMO" FilterControlAltText="Filter MECANISMO column" HeaderText="Mecanismo" SortExpression="MECANISMO" UniqueName="MECANISMO" ReadOnly="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Direccion" FilterControlAltText="Filter Direccion column" HeaderText="Direccion" SortExpression="Direccion" UniqueName="Direccion" ReadOnly="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="ARCHIVO" FilterControlAltText="Filter ARCHIVO column" HeaderText="Archivo" SortExpression="ARCHIVO" UniqueName="ARCHIVO">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="CARGA" FilterControlAltText="Filter CARGA column" HeaderText="Fecha Carga" SortExpression="CARGA" UniqueName="CARGA" DataFormatString="{0:dd/MM/yyyy hh:mm:ss}">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="REGISTROS" FilterControlAltText="Filter REGISTROS column" HeaderText="Registros" SortExpression="REGISTROS" UniqueName="REGISTROS" ReadOnly="True" DataType="System.Int32">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="ACEPTADOS" FilterControlAltText="Filter ACEPTADOS column" HeaderText="Aceptados" SortExpression="ACEPTADOS" UniqueName="ACEPTADOS" ReadOnly="True" DataType="System.Int32">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="RECHAZADOS" FilterControlAltText="Filter RECHAZADOS column" HeaderText="Rechazados" SortExpression="RECHAZADOS" UniqueName="RECHAZADOS" ReadOnly="True" DataType="System.Int32">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FECHACREACION" FilterControlAltText="Filter FECHACREACION column" HeaderText="Fecha Creación" SortExpression="FECHACREACION" UniqueName="FECHACREACION" DataFormatString="{0:dd/MM/yyyy}">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="REFERENCIA" FilterControlAltText="Filter REFERENCIA column" HeaderText="Referencia" SortExpression="REFERENCIA" UniqueName="REFERENCIA">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FECHA" FilterControlAltText="Filter FECHA column" HeaderText="Fecha" SortExpression="FECHA" UniqueName="FECHA" DataFormatString="{0:dd/MM/yyyy}">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="OPERACION" FilterControlAltText="Filter OPERACION column" HeaderText="Operación" SortExpression="OPERACION" UniqueName="OPERACION" ReadOnly="True" DataType="System.Int32">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="ISIN" FilterControlAltText="Filter ISIN column" HeaderText="ISIN" SortExpression="ISIN" UniqueName="ISIN">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="LINEA" FilterControlAltText="Filter LINEA column" HeaderText="Línea" SortExpression="LINEA" UniqueName="LINEA" ReadOnly="True" DataType="System.Int32">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="CAMPO" FilterControlAltText="Filter CAMPO column" HeaderText="Campo" SortExpression="ISIN" UniqueName="CAMPO">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="DESCRIPCION" FilterControlAltText="Filter DESCRIPCION column" HeaderText="Descripción" SortExpression="DESCRIPCION" UniqueName="DESCRIPCION">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="ESTADO" FilterControlAltText="Filter ESTADO column" HeaderText="Estado" SortExpression="ESTADO" UniqueName="ESTADO">
                        </telerik:GridBoundColumn>


                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                </MasterTableView>
                <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>

            <%-- Barra de Herramientas Abajo  --%>
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

        <%-- Fuente de Datos --%>
        <div>
            <asp:SqlDataSource ID="SqlvConsultaOperacionesOTCCevaldom" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT * FROM [vConsultaOperacionesOTCCevaldom]" DataSourceMode="DataReader">
                <SelectParameters>
                    <asp:Parameter Name="SqlWhere" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>

        <%-- Manejo de la Ventana --%>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behaviors="Close, Move" InitialBehaviors="Close" VisibleStatusbar="False" Width="300px" OnClientClose="ActualizarFiltrosConsultas">
        </telerik:RadWindowManager>

        <%-- Variable --%>
        <telerik:RadTextBox ID="txtNombreConsultaUsuario" runat="server" Visible="False">
        </telerik:RadTextBox>
        <telerik:RadTextBox ID="txtIdUsuario" runat="server" Visible="False">
        </telerik:RadTextBox>
        <telerik:RadTextBox ID="txtIdConsulta" runat="server" Visible="False">
        </telerik:RadTextBox>

    </form>
</body>
</html>
