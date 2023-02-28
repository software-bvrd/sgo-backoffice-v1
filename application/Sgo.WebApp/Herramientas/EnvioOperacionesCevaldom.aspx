<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.EnvioOperacionesCevaldom" CodeBehind="EnvioOperacionesCevaldom.aspx.vb" %>

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
                    Text="Enviar" ToolTip="Enviar Operaciones a Celvadom" Value="2">
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
                Culture="es-DO" EnableHeaderContextMenu="True" AllowPaging="True"
                ShowFooter="True" GroupPanelPosition="Top" CellSpacing="-1" GridLines="Both">
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

                <MasterTableView DataSourceID="SqlvOperacionesCSV" CommandItemDisplay="TopAndBottom" ShowGroupFooter="true" ShowFooter="true">
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
                        <telerik:GridBoundColumn DataField="CORTE" FilterControlAltText="Filter CORTE column" HeaderText="CORTE" ReadOnly="True" SortExpression="CORTE" UniqueName="CORTE">
                        </telerik:GridBoundColumn>

                         <telerik:GridBoundColumn Display="true" FilterControlAltText="Filter NUMERO OPERACION column" HeaderText="NUMERO OPERACION" ReadOnly="True" SortExpression="numopersgo" UniqueName="numopersgo" DataField="numopersgo">
                        </telerik:GridBoundColumn>

<%--                        <telerik:GridBoundColumn DataField="NUMERO_OPERACION" FilterControlAltText="Filter REFEERENCIA column" HeaderText="Referencia" ReadOnly="True" SortExpression="NUMERO_OPERACION" UniqueName="NUMERO_OPERACION">
                            <FooterStyle HorizontalAlign="Right" /> 
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>--%>

                        <telerik:GridBoundColumn DataField="ID_CONSECUTIVO_OPERACION" DataType="System.Decimal"
                            FilterControlAltText="Filter ID_CONSECUTIVO_OPERACION column" HeaderText="ID_CONSECUTIVO_OPERACION"
                            SortExpression="ID_CONSECUTIVO_OPERACION" UniqueName="ID_CONSECUTIVO_OPERACION">
                        </telerik:GridBoundColumn> 


                        <telerik:GridBoundColumn DataField="FECHA_TRANSACCION"
                            FilterControlAltText="Filter FECHA_TRANSACCION column" HeaderText="FECHA_TRANSACCION" SortExpression="FECHA_TRANSACCION" UniqueName="FECHA_TRANSACCION" ReadOnly="True">
                        </telerik:GridBoundColumn> 

                        <telerik:GridBoundColumn DataField="FECHA_LIQUIDACION"
                            FilterControlAltText="Filter FECHA_LIQUIDACION column" HeaderText="FECHA_LIQUIDACION"
                            SortExpression="FECHA_LIQUIDACION" UniqueName="FECHA_LIQUIDACION" ReadOnly="True">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="INDICADOR_OPERACION"
                            FilterControlAltText="Filter INDICADOR_OPERACION column" HeaderText="INDICADOR_OPERACION"
                            SortExpression="INDICADOR_OPERACION" UniqueName="INDICADOR_OPERACION" >
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="ID_DEPOSITANTE_COMPRADOR" FilterControlAltText="Filter ID_DEPOSITANTE_COMPRADOR column" HeaderText="ID_DEPOSITANTE_COMPRADOR" SortExpression="ID_DEPOSITANTE_COMPRADOR" UniqueName="ID_DEPOSITANTE_COMPRADOR" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="ID_DEPOSITANTE_VENDEDOR" FilterControlAltText="Filter ID_DEPOSITANTE_VENDEDOR column" HeaderText="ID_DEPOSITANTE_VENDEDOR " SortExpression="ID_DEPOSITANTE_VENDEDOR" UniqueName="ID_DEPOSITANTE_VENDEDOR" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        


                        <telerik:GridBoundColumn DataField="ID_MONEDA_EMISION" FilterControlAltText="Filter ID_MONEDA_EMISION column" HeaderText="ID_MONEDA_EMISION" SortExpression="ID_MONEDA_EMISION" UniqueName="ID_MONEDA_EMISION">
                        </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="ID_MONEDA_LIQUIDACION"
                            FilterControlAltText="Filter ID_MONEDA_LIQUIDACION column" HeaderText="ID_MONEDA_LIQUIDACION"
                            SortExpression="ID_MONEDA_LIQUIDACION" UniqueName="ID_MONEDA_LIQUIDACION">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="CODIGO_ISIN" FilterControlAltText="Filter CODIGO_ISIN column" HeaderText="CODIGO_ISIN" SortExpression="CODIGO_ISIN" UniqueName="CODIGO_ISIN" ReadOnly="True">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="CANTIDAD_TITULOS"
                            FilterControlAltText="Filter CANTIDAD_TITULOS column" HeaderText="CANTIDAD_TITULOS"
                            SortExpression="CANTIDAD_TITULOS" UniqueName="CANTIDAD_TITULOS" DataType="System.Decimal">
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="PRECIO_PRIMA"
                            FilterControlAltText="Filter PRECIO_PRIMA column" HeaderText="PRECIO_PRIMA"
                            SortExpression="PRECIO_PRIMA" UniqueName="PRECIO_PRIMA" DataType="System.Decimal">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="TIPO_CAMBIO" DataType="System.Int32" FilterControlAltText="Filter TIPO_CAMBIO column" HeaderText="TIPO_CAMBIO" ReadOnly="True" SortExpression="TIPO_CAMBIO" UniqueName="TIPO_CAMBIO">
                        </telerik:GridBoundColumn>


                           <telerik:GridBoundColumn DataField="IMPORTE_BRUTO" DataFormatString="{0:###,##0.000000}"  
                            Aggregate="Sum" FooterAggregateFormatString="{0:###,##0.00}" 
                            ItemStyle-HorizontalAlign="Right" DataType="System.Decimal" FilterControlAltText="Filter IMPORTE_BRUTO column" HeaderText="IMPORTE_BRUTO" ReadOnly="True" SortExpression="IMPORTE_BRUTO" UniqueName="IMPORTE_BRUTO">
                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="MECANISMO" FilterControlAltText="Filter MECANISMO column" HeaderText="Mecanismo" ReadOnly="True" SortExpression="MECANISMO" UniqueName="MECANISMO">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="MODALIDAD" FilterControlAltText="Filter MODALIDAD column" HeaderText="Modalidad" ReadOnly="True" SortExpression="MODALIDAD" UniqueName="MODALIDAD">
                        </telerik:GridBoundColumn>                   

                        <telerik:GridBoundColumn DataField="NUMERO_OPERACION" FilterControlAltText="Filter REFEERENCIA column" HeaderText="Referencia" ReadOnly="True" SortExpression="NUMERO_OPERACION" UniqueName="NUMERO_OPERACION">
                            <FooterStyle HorizontalAlign="Right" /> 
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridBoundColumn>
                         
                        <telerik:GridBoundColumn DataField="FECHA_TRANSACCION"
                            FilterControlAltText="Filter ACORDADA column" HeaderText="Acordada" SortExpression="FECHA_TRANSACCION" UniqueName="FECHA_TRANSACCION" ReadOnly="True">
                        </telerik:GridBoundColumn> 

                        <telerik:GridBoundColumn DataField="HORA" FilterControlAltText="Filter HORA column" HeaderText="Hora" ReadOnly="True" SortExpression="HORA" UniqueName="HORA">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="OBSERVACIONES" FilterControlAltText="Filter OBSERVACIONES column" HeaderText="Observaciones" ReadOnly="True" SortExpression="OBSERVACIONES" UniqueName="OBSERVACIONES">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="FECHA_LIQUIDACION"
                            FilterControlAltText="Filter LIQUIDACION column" HeaderText="Liquidación"
                            SortExpression="FECHA_LIQUIDACION" UniqueName="FECHA_LIQUIDACION" ReadOnly="True">
                        </telerik:GridBoundColumn>



                        <telerik:GridBoundColumn DataField="FACIAL" DataType="System.Decimal" FilterControlAltText="Filter FACIAL column" HeaderText="Facial" ReadOnly="True" SortExpression="FACIAL" UniqueName="FACIAL">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="LIMPIO" DataFormatString="{0:###,##0.000000}"  ItemStyle-HorizontalAlign="Right" DataType="System.Decimal" FilterControlAltText="Filter LIMPIO column" HeaderText="Limpio" SortExpression="LIMPIO" UniqueName="LIMPIO">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="SUCIO" DataFormatString="{0:###,##0.000000}"  ItemStyle-HorizontalAlign="Right" DataType="System.Decimal" FilterControlAltText="Filter SUCIO column" HeaderText="Sucio" ReadOnly="True" SortExpression="SUCIO" UniqueName="SUCIO">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="RENDIMIENTO" DataFormatString="{0:###,##0.000000}"  ItemStyle-HorizontalAlign="Right" DataType="System.Decimal" FilterControlAltText="Filter RENDIMIENTO column" HeaderText="Rendimiento" SortExpression="RENDIMIENTO" UniqueName="RENDIMIENTO">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="ORIGEN" FilterControlAltText="Filter ORIGEN column" HeaderText="Origen" ReadOnly="True" SortExpression="ORIGEN" UniqueName="ORIGEN">
                        </telerik:GridBoundColumn>

                        
                     

                        <telerik:GridBoundColumn DataField="DIAS_PLAZO" FilterControlAltText="Filter DIAS PLAZO column" HeaderText="Dias Plazo" ReadOnly="True" SortExpression="DIAS_PLAZO" UniqueName="DIAS_PLAZO">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="LIMPIO_PLAZO" FilterControlAltText="Filter LIMPIO PLAZO column" HeaderText="Limpio Plazo" ReadOnly="True" SortExpression="LIMPIO_PLAZO" UniqueName="LIMPIO_PLAZO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SUCIO_PLAZO" FilterControlAltText="Filter SUCIO PLAZO column" HeaderText="Sucio Plazo" ReadOnly="True" SortExpression="SUCIO_PLAZO" UniqueName="SUCIO_PLAZO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RENDIMIENTO_PLAZO" FilterControlAltText="Filter RENDIMIENTO PLAZO column" HeaderText="Rendimiento Plazo" ReadOnly="True" SortExpression="RENDIMIENTO_PLAZO" UniqueName="RENDIMIENTO_PLAZO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IMPORTE_PLAZO"  FilterControlAltText="Filter IMPORTE PLAZO column" HeaderText="Importe Plazo" ReadOnly="True" SortExpression="IMPORTE_PLAZO" UniqueName="IMPORTE_PLAZO">
                        </telerik:GridBoundColumn>
                        
<%--                                                 

                        

                        <telerik:GridBoundColumn DataField="FECHA_TRANSACCION2"
                            FilterControlAltText="Filter FECHA_TRANSACCION2 column" HeaderText="FECHA_TRANSACCION2"
                            SortExpression="FECHA_TRANSACCION2" UniqueName="FECHA_TRANSACCION2">
                        </telerik:GridBoundColumn>




                        <telerik:GridBoundColumn DataField="CUENTA_COMPRADOR" FilterControlAltText="Filter CUENTA_COMPRADOR column" HeaderText="CUENTA_COMPRADOR" SortExpression="CUENTA_COMPRADOR" UniqueName="CUENTA_COMPRADOR" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CUENTA_VENDEDOR" FilterControlAltText="Filter CUENTA_VENDEDOR column" HeaderText="CUENTA_VENDEDOR" SortExpression="CUENTA_VENDEDOR" UniqueName="CUENTA_VENDEDOR" ReadOnly="True">
                        </telerik:GridBoundColumn>

                    

                        


                  


                        
                        <telerik:GridBoundColumn DataField="RUEDA" FilterControlAltText="Filter RUEDA column" HeaderText="RUEDA" SortExpression="RUEDA" UniqueName="RUEDA">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TIPONEGOACION" FilterControlAltText="Filter TIPONEGOACION column" HeaderText="TIPONEGOACION" SortExpression="TIPONEGOACION" UniqueName="TIPONEGOACION">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DIA" FilterControlAltText="Filter DIA column" HeaderText="DIA" ReadOnly="True" SortExpression="DIA" UniqueName="DIA">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MES" FilterControlAltText="Filter MES column" HeaderText="MES" ReadOnly="True" SortExpression="MES" UniqueName="MES">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ANIO" FilterControlAltText="Filter ANIO column" HeaderText="ANIO" ReadOnly="True" SortExpression="ANIO" UniqueName="ANIO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MINUTO" FilterControlAltText="Filter MINUTO column" HeaderText="MINUTO" ReadOnly="True" SortExpression="MINUTO" UniqueName="MINUTO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SEGUNDO" FilterControlAltText="Filter SEGUNDO column" HeaderText="SEGUNDO" ReadOnly="True" SortExpression="SEGUNDO" UniqueName="SEGUNDO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ESTADO" FilterControlAltText="Filter ESTADO column" HeaderText="ESTADO" ReadOnly="True" SortExpression="ESTADO" UniqueName="ESTADO">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TIPO_LIQUIDACION" FilterControlAltText="Filter TIPO_LIQUIDACION column" HeaderText="TIPO_LIQUIDACION" ReadOnly="True" SortExpression="TIPO_LIQUIDACION" UniqueName="TIPO_LIQUIDACION">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ENVIADO" DataType="System.Int32" FilterControlAltText="Filter ENVIADO column" HeaderText="ENVIADO" ReadOnly="True" SortExpression="ENVIADO" UniqueName="ENVIADO">
                        </telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn DataField="FECHA_FILTRO" DataType="System.DateTime" FilterControlAltText="Filter FECHA OPERACION column" HeaderText="Fecha Operación" ReadOnly="True" SortExpression="FECHA_FILTRO" UniqueName="FECHA_FILTRO">
                        </telerik:GridBoundColumn>
                       
                        <telerik:GridBoundColumn DataField="CADENA" FilterControlAltText="Filter CADENA column" HeaderText="Cadena" ReadOnly="True" SortExpression="CADENA" UniqueName="CADENA">
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
                SelectCommand="SELECT TOP(1)  * FROM  SIOPEL_INTERFACE_DB.dbo.vGen_XML_CEVALDOM_MONEYMARKET  order by FECHA_FILTRO desc" DataSourceMode="DataReader">
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
