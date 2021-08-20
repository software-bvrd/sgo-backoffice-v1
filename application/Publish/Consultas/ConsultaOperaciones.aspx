<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ConsultaOperaciones" Codebehind="ConsultaOperaciones.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
    <title>Cubo de Operaciones Bursátiles</title>
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
                    <telerik:RadFilterDateFieldEditor FieldName="fecha_emi" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="fecha_venc" PickerType="DatePicker" />
                </FieldEditors>
            </telerik:RadFilter>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowGroupPanel="True"
                CellSpacing="0" DataSourceID="SqlvOperacionesCSV" GridLines="None"
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

                <MasterTableView DataSourceID="SqlvOperacionesCSV" CommandItemDisplay="TopAndBottom" DataKeyNames="fecha_oper,num_oper" ShowGroupFooter="true" ShowFooter="true">
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
                        
                        <telerik:GridBoundColumn DataField="fecha_oper" DataType="System.DateTime" FooterText="Totales:"
                            FilterControlAltText="Filter fecha_oper column" HeaderText="Fecha operación"
                            ReadOnly="True" SortExpression="fecha_oper" UniqueName="fecha_oper"
                            DataFormatString="{0:dd/MM/yyyy} " AutoPostBackOnFilter="True" AndCurrentFilterFunction="Contains">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="hora_oper" DataType="System.DateTime" 
                            FilterControlAltText="Filter hora_oper column" HeaderText="Hora operación"
                            ReadOnly="True" SortExpression="hora_oper" UniqueName="hora_oper"
                            DataFormatString="{0:hh:mm:ss} " >
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="num_oper"
                            FilterControlAltText="Filter num_oper column" HeaderText="No. Operación"
                            ReadOnly="True" SortExpression="num_oper" UniqueName="num_oper">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="mone_trans"
                            FilterControlAltText="Filter mone_trans column" HeaderText="Moneda"
                            SortExpression="mone_trans" UniqueName="mone_trans">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="nemo_ins"
                            FilterControlAltText="Filter nemo_ins column" HeaderText="Nemotécnico"
                            SortExpression="nemo_ins" UniqueName="nemo_ins">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cod_isin"
                            FilterControlAltText="Filter cod_isin column" HeaderText="ISIN"
                            SortExpression="cod_isin" UniqueName="cod_isin">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fecha_emi" DataType="System.DateTime"
                            FilterControlAltText="Filter fecha_emi column" HeaderText="Fecha Emisión"
                            SortExpression="fecha_emi" UniqueName="fecha_emi"
                            DataFormatString="{0:dd/MM/yyyy} ">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fecha_venc" DataType="System.DateTime"
                            FilterControlAltText="Filter fecha_venc column" HeaderText="Fecha Vence"
                            SortExpression="fecha_venc" UniqueName="fecha_venc"
                            DataFormatString="{0:dd/MM/yyyy} ">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridNumericColumn DataField="tasa_interes" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter tasa_interes column" HeaderText="Tasa Nom" SortExpression="tasa_interes" UniqueName="tasa_interes">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" Aggregate="Sum" FooterAggregateFormatString="{0:###,##0.00}" DataField="valor_nom_tot"
                            DataType="System.Decimal"
                            FilterControlAltText="Filtar la columna valor nominal"
                            HeaderText="Valor Nominal" SortExpression="valor_nom_tot"
                            UniqueName="valor_nom_tot" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.0000}" DataField="precio_limp"
                            DataType="System.Decimal"
                            FilterControlAltText="Filtar la columna valor nominal"
                            HeaderText="Precio" SortExpression="precio_limp"
                            UniqueName="precio_limp" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" Aggregate="Sum" FooterAggregateFormatString="{0:###,##0.00}" DataField="valor_tran"
                            DataType="System.Decimal"
                            FilterControlAltText="Filtar la columna valor nominal"
                            HeaderText="Valor Transado" SortExpression="valor_tran"
                            UniqueName="valor_tran" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridBoundColumn DataField="fecha_liquid" DataType="System.DateTime"
                            FilterControlAltText="Filter fecha_liquid column" HeaderText="Fecha Liq."
                            SortExpression="fecha_liquid" UniqueName="fecha_liquid"
                            DataFormatString="{0:dd/MM/yyyy} ">
                            <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" DataField="yield"
                            DataType="System.Decimal"
                            FilterControlAltText="Filtar la columna valor nominal"
                            HeaderText="Yield" SortExpression="yield"
                            UniqueName="yield" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="dias_alvenci" DataFormatString="{0:###,##0}" DataType="System.Decimal" FilterControlAltText="Filter dias_alvenci column" HeaderText="Dias al vencimiento" SortExpression="dias_alvenci" UniqueName="dias_alvenci">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridBoundColumn DataField="pues_comp"
                            FilterControlAltText="Filter pues_comp column" HeaderText="Comprador"
                            SortExpression="pues_comp" UniqueName="pues_comp">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="pues_vend"
                            FilterControlAltText="Filter pues_vend column" HeaderText="Vendedor"
                            SortExpression="pues_vend" UniqueName="pues_vend">
                        </telerik:GridBoundColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" DataField="TasaCompra"
                            DataType="System.Decimal"
                            FilterControlAltText="Filtar la columna Tasa Compra"
                            HeaderText="Tasa Compra" SortExpression="TasaCompra"
                            UniqueName="TasaCompra" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00000000000000}" DataField="TasaVenta"
                            DataType="System.Decimal"
                            FilterControlAltText="Filtar la columna Tasa Venta"
                            HeaderText="Tasa Venta" SortExpression="TasaVenta"
                            UniqueName="TasaVenta" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorNominalEquivalentePesos" DataType="System.Decimal" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" FilterControlAltText="Filter ValorNominalEquivalentePesos column" HeaderText="Nom Equiv en DOP" SortExpression="ValorNominalEquivalentePesos" UniqueName="ValorNominalEquivalentePesos">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorTransadoEquivalentePesos" DataType="System.Decimal" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" FilterControlAltText="Filter ValorTransadoEquivalentePesos column" HeaderText="Trans Equiv en DOP" SortExpression="ValorTransadoEquivalentePesos" UniqueName="ValorTransadoEquivalentePesos">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridBoundColumn DataField="Mercado"
                            FilterControlAltText="Filter mercado column" HeaderText="Mercado"
                            SortExpression="mercado" UniqueName="mercado">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="descrip_emisor"
                            FilterControlAltText="Filter descrip_emisor column" HeaderText="Emisor"
                            SortExpression="descrip_emisor" UniqueName="descrip_emisor">
                        </telerik:GridBoundColumn>
                        <telerik:GridNumericColumn DataField="ValorNominalPesos" DataType="System.Decimal" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" FilterControlAltText="Filter ValorNominalPesos column" HeaderText="Nominal DOP" SortExpression="ValorNominalPesos" UniqueName="ValorNominalPesos" Display="False">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorTransadoPesos" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:RD$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorTransadoPesos column" HeaderText="Transado DOP" SortExpression="ValorTransadoPesos" UniqueName="ValorTransadoPesos" Display="False">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorNominalDolares" DataType="System.Decimal" FooterAggregateFormatString="{0:US$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" FilterControlAltText="Filter ValorNominalDolares column" HeaderText="Nominal USD" SortExpression="ValorNominalDolares" UniqueName="ValorNominalDolares" Display="False">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorTransadoDolares" DataType="System.Decimal" Aggregate="Sum" FooterAggregateFormatString="{0:US$###,##0.00}" DataFormatString="{0:###,##0.00}" FilterControlAltText="Filter ValorTransadoDolares column" HeaderText="Transado USD" SortExpression="ValorTransadoDolares" UniqueName="ValorTransadoDolares" Display="False">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorNominalEquivalenteDolares" DataType="System.Decimal" FooterAggregateFormatString="{0:US$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" Display="False" FilterControlAltText="Filter ValorNominalEquivalenteDolares column" HeaderText="Total Nom Equiv USD" SortExpression="ValorNominalEquivalenteDolares" UniqueName="ValorNominalEquivalenteDolares">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataField="ValorTransadoEquivalenteDolares" DataType="System.Decimal" FooterAggregateFormatString="{0:US$###,##0.00}" DataFormatString="{0:###,##0.00}" Aggregate="Sum" Display="False" FilterControlAltText="Filter ValorTransadoEquivalenteDolares column" HeaderText="Total Trans Equiv USD" SortExpression="ValorTransadoEquivalenteDolares" UniqueName="ValorTransadoEquivalenteDolares">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridNumericColumn DataFormatString="{0:###,##0}" DataField="Conteo" DataType="System.Decimal" FilterControlAltText="Filtar Conteo column" HeaderText="Frecuencia Negociación" SortExpression="Conteo" UniqueName="Conteo" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                        <telerik:GridBoundColumn DataField="CodRueda" FilterControlAltText="Filter CodRueda column" HeaderText="Codigo Rueda" SortExpression="CodRueda" UniqueName="CodRueda">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipoNegociacion" FilterControlAltText="Filter TipoNegociacion column" HeaderText="Tipo Negociacion" SortExpression="TipoNegociacion" UniqueName="TipoNegociacion">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TipoNegociacionDesc" FilterControlAltText="Filter TipoNegociacionDesc column" HeaderText="Tipo Negociacion Descripcion" SortExpression="TipoNegociacionDesc" UniqueName="TipoNegociacionDesc">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="pues_comp_siopel" FilterControlAltText="Filter pues_comp_siopel column" HeaderText="Puesto Compra Siopel" SortExpression="pues_comp_siopel" UniqueName="pues_comp_siopel">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="pues_vend_siopel" FilterControlAltText="Filter pues_vend_siopel column" HeaderText="Puesto Venta Siopel" SortExpression="pues_vend_siopel" UniqueName="pues_vend_siopel">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Especie" FilterControlAltText="Filter Especie column" HeaderText="Especie" SortExpression="Especie" UniqueName="Especie">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cant_tit" FilterControlAltText="Filter cant_tit column" HeaderText="Cantidad de títulos" SortExpression="cant_tit" UniqueName="cant_tit">
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
                SelectCommand="SELECT TOP(1) * FROM [vConsultaOperacionesCSV] ORDER BY [fecha_oper] DESC" DataSourceMode="DataReader">
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
