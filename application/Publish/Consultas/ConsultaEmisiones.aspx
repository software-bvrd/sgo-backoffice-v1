<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Edicion_ConsultaEmisiones" Codebehind="ConsultaEmisiones.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Consulta de Emisiones</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <script src="../Scripts/TamanoObjetos.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
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
                CssClass="RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default RadFilter RadFilter_Default " Culture="es-DO" AddExpressionToolTip="Agregar Expresión" AddGroupToolTip="Agregar Grupo" ApplyButtonText="Aplicar">
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
                    <telerik:RadFilterDateFieldEditor FieldName="FechaAprobacionBVRD" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaEmision" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaVencimiento" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaLiquidacion" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaInicioColocacion" PickerType="DatePicker" />
                    <telerik:RadFilterDateFieldEditor FieldName="FechaFinalColocacion" PickerType="DatePicker" />
                </FieldEditors>

            </telerik:RadFilter>

            <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                CellSpacing="0" DataSourceID="SqlvConsultaEmisiones" GridLines="None"
                ShowGroupPanel="True" Culture="es-DO" EnableHeaderContextMenu="True" AllowPaging="True">
                <GroupingSettings CaseSensitive="False" />
                <ExportSettings ExportOnlyData="True" FileName="Consulta de Emisiones" OpenInNewWindow="True" IgnorePaging="True">
                    <Pdf PageTitle="Operaciones Realizadas" />
                </ExportSettings>

                <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <Resizing AllowColumnResize="True" AllowRowResize="false" ResizeGridOnColumnResize="false"
                        ClipCellContentOnResize="true" EnableRealTimeResize="false" AllowResizeToFit="true" />
                </ClientSettings>

                <MasterTableView DataSourceID="SqlvConsultaEmisiones"
                    CommandItemDisplay="TopAndBottom">
                    <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                        ShowExportToCsvButton="False" ShowExportToExcelButton="False" ShowExportToPdfButton="False" ShowRefreshButton="False" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                        Visible="True">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>

                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                        Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>

                    <Columns>

                        <telerik:GridBoundColumn DataField="CodEmisionBVRD"
                            FilterControlAltText="Filter CodEmisionBVRD column" HeaderText="Cod. Emisión" SortExpression="CodEmisionBVRD" UniqueName="CodEmisionBVRD">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="FechaAprobacionBVRD" DataType="System.DateTime"
                            FilterControlAltText="Filter FechaAprobacionBVRD column" HeaderText="Fecha BVRD"
                            SortExpression="FechaAprobacionBVRD" UniqueName="FechaAprobacionBVRD"
                            DataFormatString="{0:dd/MM/yyyy} " Display="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" DataField="MontoTotalDeLaEmision"
                            DataType="System.Decimal"
                            FilterControlAltText="Filter MontoTotalDeLaEmision column"
                            HeaderText="Valor Total" SortExpression="MontoTotalDeLaEmision"
                            UniqueName="MontoTotalDeLaEmision" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridNumericColumn>


                        <telerik:GridBoundColumn DataField="GarantiaProgramaEmision"
                            FilterControlAltText="Filter GarantiaProgramaEmision column" HeaderText="Garantía"
                            SortExpression="GarantiaProgramaEmision" UniqueName="GarantiaProgramaEmision" ReadOnly="True" Display="false">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="Nemotecnico"
                            FilterControlAltText="Filter Nemotecnico column" HeaderText="Nemotécnico"
                            SortExpression="Nemotecnico" UniqueName="Nemotecnico" ReadOnly="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="CodigoISIN"
                            FilterControlAltText="Filter CodigoISIN column" HeaderText="ISIN"
                            SortExpression="CodigoISIN" UniqueName="CodigoISIN" ReadOnly="True">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="FechaEmision" DataType="System.DateTime"
                            FilterControlAltText="Filter FechaEmision column" HeaderText="Fecha Emisión"
                            SortExpression="FechaEmision" UniqueName="FechaEmision"
                            DataFormatString="{0:dd/MM/yyyy} ">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="FechaVencimiento" DataType="System.DateTime"
                            FilterControlAltText="Filter FechaVencimiento column" HeaderText="Fecha Vence"
                            SortExpression="FechaVencimiento" UniqueName="FechaVencimiento"
                            DataFormatString="{0:dd/MM/yyyy} ">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="FechaLiquidacion" DataType="System.DateTime"
                            FilterControlAltText="Filter FechaLiquidacion column" HeaderText="Fecha Liq."
                            SortExpression="FechaLiquidacion" UniqueName="FechaLiquidacion"
                            DataFormatString="{0:dd/MM/yyyy} ">
                        </telerik:GridBoundColumn>


                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" DataField="Monto_Emitido"
                            DataType="System.Decimal"
                            FilterControlAltText="Filter Monto_Emitido column"
                            HeaderText="Monto Emitido" SortExpression="Monto_Emitido"
                            UniqueName="Monto_Emitido" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridNumericColumn>

                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" DataField="InversionMinima"
                            DataType="System.Decimal"
                            FilterControlAltText="Filter InversionMinima column"
                            HeaderText="Inversión Mínima" SortExpression="InversionMinima"
                            UniqueName="InversionMinima" Display="False" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridNumericColumn>

                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" DataField="InversionMaxima"
                            DataType="System.Decimal"
                            FilterControlAltText="Filter InversionMaxima column"
                            HeaderText="Inversión Máxima" SortExpression="InversionMaxima"
                            UniqueName="InversionMaxima" Display="False" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridNumericColumn>

                        <telerik:GridBoundColumn DataField="TipoTasa"
                            FilterControlAltText="Filter TipoTasa column" HeaderText="TipoTasa"
                            SortExpression="TipoTasa" UniqueName="TipoTasa" ReadOnly="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Cupon"
                            FilterControlAltText="Filter Cupon column" HeaderText="Cupon"
                            SortExpression="Cupon" UniqueName="Cupon" DataType="System.Decimal" ReadOnly="True" Display="False" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FechaInicioColocacion" DataType="System.DateTime"
                            FilterControlAltText="Filter FechaInicioColocacion column" HeaderText="Fecha Incio Col."
                            SortExpression="FechaInicioColocacion" UniqueName="FechaLiquidacion"
                            DataFormatString="{0:dd/MM/yyyy} ">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FechaFinalColocacion" DataType="System.DateTime"
                            FilterControlAltText="Filter FechaFinalColocacion column" HeaderText="Fecha Final Col."
                            SortExpression="FechaFinalColocacion" UniqueName="FechaFinalColocacion"
                            DataFormatString="{0:dd/MM/yyyy} ">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Emisor"
                            FilterControlAltText="Filter Emisor column" HeaderText="Emisor"
                            SortExpression="Emisor" UniqueName="Emisor" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="BaseLiquidacion"
                            FilterControlAltText="Filter BaseLiquidacion column" HeaderText="Base Liquidación"
                            SortExpression="BaseLiquidacion" UniqueName="BaseLiquidacion" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NombreInstrumento"
                            FilterControlAltText="Filter NombreInstrumento column" HeaderText="Instrumento"
                            SortExpression="NombreInstrumento" UniqueName="NombreInstrumento" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Moneda"
                            FilterControlAltText="Filter Moneda column" HeaderText="Moneda"
                            SortExpression="Moneda" UniqueName="Moneda" ReadOnly="True">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Spread" DataType="System.Decimal"
                            FilterControlAltText="Filter Spread column" HeaderText="Spread"
                            SortExpression="Spread" UniqueName="Spread" ReadOnly="True" Display="False" ItemStyle-HorizontalAlign="Right">
                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="TipoEmisor" 
                            FilterControlAltText="Filter TipoEmisor column" HeaderText="Tipo Emisor" ReadOnly="True"
                             SortExpression="TipoEmisor" UniqueName="TipoEmisor" Display="False">
                        </telerik:GridBoundColumn>
 
                        <telerik:GridBoundColumn DataField="NombrePeriodo" 
                            FilterControlAltText="Filter NombrePeriodo column" HeaderText="Periodicidad" 
                            SortExpression="NombrePeriodo" UniqueName="NombrePeriodo" Display="False">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="FechaUltimaCalificacion"
                            FilterControlAltText="Filter FechaUltimaCalificacion column" HeaderText="Ultima Fecha Calif."
                            SortExpression="FechaUltimaCalificacion" UniqueName="FechaUltimaCalificacion" ReadOnly="True" 
                            DataFormatString="{0:dd/MM/yyyy} ">                            
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Calificacion"
                            FilterControlAltText="Filter Calificacion column" HeaderText="Ultima Calif."
                            SortExpression="Calificacion" UniqueName="Calificacion" ReadOnly="True" >
                        </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="EmpresaCalificadora"
                            FilterControlAltText="Filter EmpresaCalificadora column" HeaderText="Empresa Calificadora"
                            SortExpression="EmpresaCalificadora" UniqueName="EmpresaCalificadora" ReadOnly="True" >
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="PuestoBolsaCodigos"
                            FilterControlAltText="Filter PuestoBolsaCodigos column" HeaderText="Código/os Puesto Bolsa"
                            SortExpression="PuestoBolsaCodigos" UniqueName="PuestoBolsaCodigos" ReadOnly="True" >
                        </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="NombresPuestoBolsa"
                            FilterControlAltText="Filter NombresPuestoBolsa column" HeaderText="Nombre/es Puesto Bolsa"
                            SortExpression="NombresPuestoBolsa" UniqueName="NombresPuestoBolsa" ReadOnly="True" >
                        </telerik:GridBoundColumn>

                          <telerik:GridBoundColumn DataField="TipoNegociacion"
                            FilterControlAltText="Filter Tipo Negociacion column" HeaderText="Tipo Negociacion"
                            SortExpression="TipoNegociacion" UniqueName="TipoNegociacion" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>

                           <telerik:GridBoundColumn DataField="Descripcion"
                            FilterControlAltText="Filter Descripcion column" HeaderText="Descripcion"
                            SortExpression="Descripcion" UniqueName="Descripcion" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>

                                     <telerik:GridBoundColumn DataField="CantidadTramos"
                            FilterControlAltText="Filter CantidadTramos column" HeaderText="CantidadTramos"
                            SortExpression="CantidadTramos" UniqueName="CantidadTramos" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>

                        
                                     <telerik:GridBoundColumn DataField="MontoOfertadoAlPublico"
                            FilterControlAltText="Filter MontoOfertadoAlPublico column" HeaderText="MontoOfertadoAlPublico"
                            SortExpression="MontoOfertadoAlPublico" UniqueName="MontoOfertadoAlPublico" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>
                        
                        
                                     <telerik:GridBoundColumn DataField="MontoPendienteDeColocacionDelAOP"
                            FilterControlAltText="Filter Monto Pendiente Colocacion OP column" HeaderText="MontoPendienteDeColocacionDelAOP"
                            SortExpression="MontoPendienteDeColocacionDelAOP" UniqueName="MontoPendienteDeColocacionDelAOP" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>
                        
                                     <telerik:GridBoundColumn DataField="ValorNominal"
                            FilterControlAltText="Filter ValorNominal column" HeaderText="ValorNominal"
                            SortExpression="ValorNominal" UniqueName="ValorNominal" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>

                        
                                     <telerik:GridBoundColumn DataField="FinalidadDeLaEmision"
                            FilterControlAltText="Filter FinalidadDeLaEmision column" HeaderText="FinalidadDeLaEmision"
                            SortExpression="FinalidadDeLaEmision" UniqueName="FinalidadDeLaEmision" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>

                        
                                     <telerik:GridBoundColumn DataField="TipoAmortizacionCapital"
                            FilterControlAltText="Filter TipoAmortizacionCapital column" HeaderText="TipoAmortizacionCapital"
                            SortExpression="TipoAmortizacionCapital" UniqueName="TipoAmortizacionCapital" ReadOnly="True" Display="False">
                        </telerik:GridBoundColumn>
                        
                        
                                     <telerik:GridBoundColumn DataField="Estatus"
                            FilterControlAltText="Filter Estatus column" HeaderText="Estatus"
                            SortExpression="Estatus" UniqueName="Estatus" ReadOnly="True" Display="True">
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
            <asp:SqlDataSource ID="SqlvConsultaEmisiones" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="SELECT * FROM [vConsultaEmisiones]" DataSourceMode="DataReader"></asp:SqlDataSource>
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
