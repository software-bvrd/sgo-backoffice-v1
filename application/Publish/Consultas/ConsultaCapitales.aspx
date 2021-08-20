<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ConsultaCapitales" Codebehind="ConsultaCapitales.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
    <title>Consulta de Capitales</title>
    <style type="text/css">
        .filterDiv
        {
            margin: 20px 0px 10px 0px;
        }

        #NombreConsultaUsuario
        {
            float: left;
            margin-left: 130px;
            margin-top: 3px;
            position: absolute;
        }
    </style>



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
                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
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
                    <telerik:RadFilterDateFieldEditor FieldName="fecha_oper" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="fecha_liquid" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="fecha_venc" PickerType="DatePicker" />
                </FieldEditors>

            </telerik:RadFilter>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowGroupPanel="True"
                CellSpacing="0" DataSourceID="SqlvConsultaCapitales" GridLines="None"
                Culture="es-DO" EnableHeaderContextMenu="True"
                ShowFooter="True" AllowPaging="True">
                <GroupingSettings CaseSensitive="False" />
                <ExportSettings ExportOnlyData="True" FileName="Operaciones Realizadas" OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Operaciones Realizadas" FontType="Embed" />
                </ExportSettings>

                <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True" />
                    <Resizing EnableRealTimeResize="True" AllowColumnResize="True" AllowResizeToFit="True" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
                </ClientSettings>

                <MasterTableView DataSourceID="SqlvConsultaCapitales" CommandItemDisplay="TopAndBottom" DataKeyNames="num_oper,fecha_oper" ShowGroupFooter="true" ShowFooter="true">
                    <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                        ShowExportToCsvButton="false" ShowExportToExcelButton="false" ShowExportToPdfButton="false" ShowRefreshButton="false" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                        Visible="True" Created="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                    <Columns>
                        <telerik:GridBoundColumn DataField="num_oper" FilterControlAltText="Filter num_oper column" HeaderText="NUM_OPE" ReadOnly="True" SortExpression="num_oper" UniqueName="num_oper">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TIPO_OPE" FilterControlAltText="Filter TIPO_OPE column" HeaderText="TIPO_OPE" ReadOnly="True" SortExpression="TIPO_OPE" UniqueName="TIPO_OPE">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MERCADO" FilterControlAltText="Filter MERCADO column" HeaderText="MERCADO" ReadOnly="True" SortExpression="MERCADO" UniqueName="MERCADO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="nemo_emisor" FilterControlAltText="Filter nemo_emisor column" HeaderText="EMISOR" SortExpression="nemo_emisor" UniqueName="nemo_emisor">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="nemo_ins" FilterControlAltText="Filter nemo_ins column" HeaderText="INSTRUMENTO" SortExpression="nemo_ins" UniqueName="nemo_ins">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="periodicidad" FilterControlAltText="Filter periodicidad column" HeaderText="PERIO" SortExpression="periodicidad" UniqueName="periodicidad">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dias_alvenci" DataType="System.String" FilterControlAltText="Filter dias_alvenci column" HeaderText="DIAS VENC" SortExpression="dias_alvenci" UniqueName="dias_alvenci">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dias_acum" DataType="System.String" FilterControlAltText="Filter dias_acum column" HeaderText="DIAS ACUM" SortExpression="dias_acum" UniqueName="dias_acum">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridNumericColumn DataField="tasa_interes" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter tasa_interes column" HeaderText="TASA_FACIAL" SortExpression="tasa_interes" UniqueName="tasa_interes">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" DataField="valor_nom_tot" DataType="System.Decimal" FilterControlAltText="Filter valor_nom_tot column" HeaderText="VAL_FACIAL" SortExpression="valor_nom_tot" UniqueName="valor_nom_tot">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>

                        <telerik:GridNumericColumn DataField="precio_limp" DataType="System.String" FilterControlAltText="Filter precio_limp column" HeaderText="PRECIO" SortExpression="precio_limp" UniqueName="precio_limp" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" DataField="valor_tran" DataType="System.Decimal" FilterControlAltText="Filter valor_tran column"
                            HeaderText="VAL TRANSADO" SortExpression="valor_tran" UniqueName="valor_tran" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridBoundColumn DataField="yield" DataType="System.String" FilterControlAltText="Filter yield column" HeaderText="TIR" SortExpression="yield" UniqueName="yield">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fecha_oper" DataType="System.DateTime" FilterControlAltText="Filter fecha_oper column" HeaderText="FEC OPE"
                            ReadOnly="True" SortExpression="fecha_oper" UniqueName="fecha_oper" DataFormatString="{0:dd/MM/yyyy} ">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataFormatString="{0:hh:mm:ss}" DataField="hora_oper" DataType="System.DateTime" FilterControlAltText="Filter hora_oper column" HeaderText="HORA OPE" SortExpression="hora_oper" UniqueName="hora_oper">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FEC_RENO" FilterControlAltText="Filter FEC_RENO column" HeaderText="FEC RENO" ReadOnly="True" SortExpression="FEC_RENO" UniqueName="FEC_RENO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FEC_ULTI" FilterControlAltText="Filter FEC_ULTI column" HeaderText="FEC ULTI" ReadOnly="True" SortExpression="FEC_ULTI" UniqueName="FEC_ULTI">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FEC_PROX" FilterControlAltText="Filter FEC_PROX column" HeaderText="FEC PROX" ReadOnly="True" SortExpression="FEC_PROX" UniqueName="FEC_PROX">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fecha_venc" DataType="System.DateTime" FilterControlAltText="Filter fecha_venc column" HeaderText="FEC_VEN" SortExpression="fecha_venc" UniqueName="fecha_venc"
                            DataFormatString="{0:dd/MM/yyyy}">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fecha_liquid" DataType="System.DateTime" FilterControlAltText="Filter fecha_liquid column" HeaderText="FEC PLAZO" SortExpression="fecha_liquid" UniqueName="fecha_liquid"
                            DataFormatString="{0:dd/MM/yyyy}">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FORMA_PAGO" FilterControlAltText="Filter FORMA_PAGO column" HeaderText="FORMA PAGO" ReadOnly="True" SortExpression="FORMA_PAGO" UniqueName="FORMA_PAGO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DIAS_RECO" FilterControlAltText="Filter DIAS_RECO column" HeaderText="DIAS RECO" ReadOnly="True" SortExpression="DIAS_RECO" UniqueName="DIAS_RECO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="GAR_RECO" FilterControlAltText="Filter GAR_RECO column" HeaderText="GAR RECO" ReadOnly="True" SortExpression="GAR_RECO" UniqueName="GAR_RECO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REND_RECO" FilterControlAltText="Filter REND_RECO column" HeaderText="REND RECO" ReadOnly="True" SortExpression="REND_RECO" UniqueName="REND_RECO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TasaCompra" DataType="System.String" FilterControlAltText="Filter TasaCompra column" HeaderText="TC COMPRA" ReadOnly="True" SortExpression="TasaCompra" UniqueName="TasaCompra">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TasaVenta" DataType="System.String" FilterControlAltText="Filter TasaVenta column" HeaderText="TC VENTA" ReadOnly="True" SortExpression="TasaVenta" UniqueName="TasaVenta">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CODE_MONE" FilterControlAltText="Filter CODE_MONE column" HeaderText="CODE MONE" ReadOnly="True" SortExpression="CODE_MONE" UniqueName="CODE_MONE">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MONE_LIQUI" FilterControlAltText="Filter MONE_LIQUI column" HeaderText="MONE LIQUI" ReadOnly="True" SortExpression="MONE_LIQUI" UniqueName="MONE_LIQUI">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Serie" FilterControlAltText="Filter Serie column" HeaderText="SERIE" SortExpression="Serie" UniqueName="Serie">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cod_isin" FilterControlAltText="Filter cod_isin column" HeaderText="ISIN" SortExpression="cod_isin" UniqueName="cod_isin">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="INDICE_ACCIONARIO" FilterControlAltText="Filter INDICE_ACCIONARIO column" HeaderText="INDICE ACCIONARIO" ReadOnly="True" SortExpression="INDICE_ACCIONARIO" UniqueName="INDICE_ACCIONARIO">
                        </telerik:GridBoundColumn>
                    </Columns>

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
            <asp:SqlDataSource ID="SqlvConsultaCapitales" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT * FROM [vConsultaCapitales] ORDER BY [fecha_oper] DESC" DataSourceMode="DataReader">
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
