<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ConfirmarComisiones" CodeBehind="ConfirmarComisiones.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirmar Comisiones</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
</head> 

<body style="background-color: #F1F5FB;">
    <script type="text/javascript">

        function RefreshParentPage() {
            GetRadWindow().Close();
            GetRadWindow().BrowserWindow.location.reload();
        }

        function RedirectParentPage(newUrl) {
            GetRadWindow().BrowserWindow.document.location.href = newUrl;
            GetRadWindow().Close();
        }

        function CallFunctionOnParentPage(fnName) {
            alert("Calling the function " + fnName + " defined on the parent page");
            var oWindow = GetRadWindow();
            if (oWindow.BrowserWindow[fnName] && typeof (oWindow.BrowserWindow[fnName]) == "function") {
                oWindow.BrowserWindow[fnName](oWindow);
            }
        }


        function ClientClose() {
            $find("RadAjaxManager1").ajaxRequest();
        }

        function OnClientItemsRequesting(sender, e) {
            if (sender.get_appendItems()) e.get_context().CustomText = "";
            else e.get_context().CustomText = sender.get_text();
        }

        if (!document.all) {
            window.onbeforeunload = function () {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);
            }
        }

        function endRequest(sender, e) {
            err = e.get_error();
            if (err) {
                if (err.name == "Sys.WebForms.PageRequestManagerServerErrorException") {
                    e.set_errorHandled(true);
                }
            }
        }
    </script>
    <form id="form1" runat="server" style="background-color: #F1F5FB">
        <div>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <asp:TextBox ID="Codigo" runat="server" Enabled="False" ReadOnly="True" Width="61px" Visible="False"></asp:TextBox>
        </div>
        <div>
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif" Text="Confirmar" ToolTip="Confirmar Información" Value="0"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 1"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif" Text="Cancelar" ToolTip="Cancelar Edición" Value="1"></telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div>
            <telerik:RadFilter ID="RadFilter1" runat="server" FilterContainerID="RadGridComisiones"
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
                    <telerik:RadFilterDateFieldEditor FieldName="FechaFactura" PickerType="DatePicker" />  
                </FieldEditors>

            </telerik:RadFilter>
            <telerik:RadGrid ID="RadGridComisiones" runat="server" AllowSorting="True"
                AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlComisiones" PageSize="20" GroupPanelPosition="Top" ShowFooter="True">
                <GroupingSettings CollapseAllTooltip="Collapse all groups" ></GroupingSettings>

                <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True"
                    ReorderColumnsOnClient="True">
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                </ClientSettings>
                <MasterTableView AllowSorting="True" CommandItemDisplay="Bottom"
                    CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="ComisionHistoricoId"
                    DataSourceID="SqlComisiones" NoMasterRecordsText="No hay información para mostrar.">
                    <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                        ShowExportToPdfButton="True" ShowExportToCsvButton="True" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                        Visible="True">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filtrar Columnas Expandidas"
                        Visible="True">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="RNC"
                            FilterControlAltText="Filtrar RNC columna" HeaderText="RNC"
                            SortExpression="RNC" UniqueName="RNC">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="participante"
                            FilterControlAltText="Filtrar Participante columna" HeaderText="Participante"
                            SortExpression="Participante" UniqueName="Participante">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CodigoServicio"
                            FilterControlAltText="Filtrar CodigoServicio columna" HeaderText="Código Servicio"
                            SortExpression="CodigoServicio" UniqueName="CodigoServicio">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaFactura"
                            FilterControlAltText="Filtrar FechaFactura columna" HeaderText="Fecha Factura"
                            SortExpression="FechaFactura" UniqueName="FechaFactura">
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn DataField="Monto" DataFormatString="{0:###,##0.00}" Aggregate="Sum" FooterAggregateFormatString="{0:###,##0.00}"
                            FilterControlAltText="Filter Monto column" HeaderText="Monto"
                            SortExpression="Monto" UniqueName="Monto">
                        </telerik:GridBoundColumn>--%>

                        <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" Aggregate="Sum" FooterAggregateFormatString="{0:###,##0.00}" DataField="Monto"
                            DataType="System.Decimal"
                            FilterControlAltText="Filtrar la columna Monto"
                            HeaderText="Monto" SortExpression="Monto"
                            UniqueName="Monto" ItemStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>

                        <telerik:GridBoundColumn DataField="Moneda"
                            FilterControlAltText="Filter Moneda column" HeaderText="Moneda"
                            SortExpression="Moneda" UniqueName="Moneda">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DiasVencimiento"
                            FilterControlAltText="Filter Moneda column" HeaderText="Dias Vencimiento"
                            SortExpression="DiasVencimiento" UniqueName="DiasVencimiento">
                        </telerik:GridBoundColumn>


                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
            <asp:SqlDataSource ID="SqlComisiones" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                SelectCommand="select C.ComisionHistoricoId,C.RNC,C.CodigoServicio
                                                          ,CONVERT(VARCHAR(10),C.FechaFactura,103) as FechaFactura
                                                          ,C.Monto,C.Moneda,C.DiasVencimiento, P.NOMBRE as Participante 
                                                          from dbo.ComisionHistoricoArchivo C INNER JOIN  vPuestoBolsayEmisores P ON P.RNC = C.RNC AND P.RNC IS NOT NULL
                                                    where C.ComisionHistoricoId=@ComisionHistoricoId">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Codigo" Name="ComisionHistoricoId" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>

</body>
</html>
