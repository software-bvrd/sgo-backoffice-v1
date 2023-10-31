<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ConsultaOperacionesNotificacionesCevaldom" CodeBehind="ConsultaOperacionesNotificacionesCevaldom.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
    <title>Consulta de Notificaciones Operaciones Cevaldom</title>
    <style type="text/css">
        .filterDiv {
            margin: 20px 0px 10px 0px;
        }

        #NombreConsultaUsuario {
            float: left;
            margin-left: 130px;
            margin-top: 3px;
            position: absolute;
        }
    </style>
</head>

<body style="background-color: #F1F5FB">
    <form id="form1" runat="server">
        <input type="hidden" id="txtfecha" name="txtfecha" value="0" runat="server" />
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
                    else {
                        args.set_enableAjax(true);
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
                <telerik:RadToolBarButton runat="server" Text="XML" ToolTip="Exportar a XML" Value="12" ImageUrl="~/Images/xml.png">
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
                CssClass="RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default " Culture="es-DO" UseBetweenValidation="False">
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
                    <telerik:RadFilterDateFieldEditor FieldName="RNC" />
                </FieldEditors>

            </telerik:RadFilter>

            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowGroupPanel="True" DataSourceID="SqlvOperacionesCSV"
                Culture="es-DO" EnableHeaderContextMenu="True"
                ShowFooter="True" AllowPaging="True" GroupPanelPosition="Top" CellSpacing="-1" GridLines="Both">
                <GroupingSettings CaseSensitive="False" />

                <ExportSettings ExportOnlyData="True" FileName="Estatus Operaciones Webservices" OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Estatus Operaciones Webservices" FontType="Embed" />
                    <%--<Excel Format="Xlsx" />--%>
                    <Word Format="Docx" />

                </ExportSettings>

                <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True" />
                    <Resizing EnableRealTimeResize="True" AllowColumnResize="True" AllowResizeToFit="True" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
                </ClientSettings>

                <MasterTableView DataSourceID="SqlvOperacionesCSV" CommandItemDisplay="TopAndBottom" DataKeyNames="fecha" ShowGroupFooter="true" ShowFooter="true">
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

                        <%-- Tipo de Operación 2015.12.28 --%>

                        <%-- Plazo Liquidación 2016.06.21 --%>


                        <%-- 2017-03-13 Nuevas columnas comisiones --%>



                        <%-- Origen = Como vendió 2017.07.14  --%>


                        <%-- Destino = Como Compro 2017.07.14  --%>


                        <%-- Instrumento y Tipo Instrumento | 2017.11.14  --%>



                        <%-- Columna con Idice de conversión para liquidación Aplicada | 2018.03.09 --%>


                        <%-- Sector | 2018.06.05  --%>

                        <telerik:GridBoundColumn DataField="Proceso"
                            FilterControlAltText="Filter Proceso column" HeaderText="Proceso"
                            ReadOnly="True" SortExpression="Proceso" UniqueName="Proceso" FooterText="Totales:">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="fecha" DataType="System.DateTime"
                            FilterControlAltText="fecha" HeaderText="Fecha"
                            SortExpression="fecha" UniqueName="fecha"
                            DataFormatString="{0:dd/MM/yyyy}">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="nemo_ins" FilterControlAltText="NemoTecnico" HeaderText="NemoTecnico" SortExpression="nemo_ins" UniqueName="nemo_ins">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Referencia"
                            FilterControlAltText="Filter Referencia column" HeaderText="Referencia" SortExpression="Referencia" UniqueName="Referencia">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Descripcion"
                            FilterControlAltText="Filter  Mensaje column" HeaderText="Mensaje"
                            SortExpression="Descripcion" UniqueName="Descripcion">
                            <FooterStyle HorizontalAlign="Right"></FooterStyle>

                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Estado"
                            FilterControlAltText="Estado" HeaderText="Estado"
                            SortExpression="Estado" UniqueName="Estado">
                        </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="Enviado"
                            FilterControlAltText="Enviado" HeaderText="Enviado"
                            SortExpression="Enviado" UniqueName="Enviado" >
                        </telerik:GridBoundColumn>

                        <telerik:GridButtonColumn ButtonType="PushButton" CommandArgument="Reenviar" CommandName="Reenviar" HeaderText="Acción" SortExpression="REFERENCIA"  DataType="System.Decimal" FilterControlAltText="Filter BtReenviar column" Text="Reenviar" UniqueName="BtReenviar">
                        </telerik:GridButtonColumn>


                        <telerik:GridBoundColumn DataField="Vendedor" FilterControlAltText="Vendendor" HeaderText="Vendendor" SortExpression="Vendendor" UniqueName="Vendendor">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Comprador" FilterControlAltText="Comprador" HeaderText="Comprador" SortExpression="Comprador" UniqueName="Comprador">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Mecanismo" FilterControlAltText="Mecanismo" HeaderText="Mecanismo" SortExpression="Mecanismo" UniqueName="Mecanismo">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Modalidad" FilterControlAltText="Modalidad" HeaderText="Modalidad" SortExpression="Modalidad" UniqueName="Modalidad">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Operacion" FilterControlAltText="Operacion" HeaderText="Operacion" SortExpression="Operacion" UniqueName="Operacion">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="fechacreacion" DataType="System.DateTime"
                            FilterControlAltText="Filter fechacreacion column" HeaderText="Fecha  Creación"
                            SortExpression="fechacreacion" UniqueName="fechacreacion"
                            DataFormatString="{0:dd/MM/yyyy hh:mm:ss} ">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Solicitud" FilterControlAltText="Solicitud" HeaderText="Solicitud" SortExpression="Solicitud" UniqueName="Solicitud">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="ISIN"
                            FilterControlAltText="Filter  ISIN column" HeaderText="ISIN"
                            SortExpression="ISIN" UniqueName="ISIN">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Campo" FilterControlAltText="Campo" HeaderText="Campo" SortExpression="nemo_ins" UniqueName="Campo">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Archivo"
                            FilterControlAltText="Filter Archivo column" HeaderText="Archivo"
                            SortExpression="Archivo" UniqueName="Archivo">
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
                    <telerik:RadToolBarButton runat="server" Text="XML" ToolTip="Exportar a XML" Value="12" ImageUrl="~/Images/xml.png">
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
            <asp:SqlDataSource ID="SqlvOperacionesCSV" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT TOP(1) fecha FROM SIOPEL_INTERFACE_DB.dbo.vConsultaOperacionesCSV ORDER BY fecha DESC" DataSourceMode="DataReader">
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
