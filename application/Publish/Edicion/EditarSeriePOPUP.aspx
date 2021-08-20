<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Edicion_EditarSeriePOPUP" Codebehind="EditarSeriePOPUP.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/OpenWindows.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
     

    <style type="text/css">
        .style1 {
            width: 100%;
        }

        .style2 {
            width: 139px;
        }

        .style3 {
            width: 527px;
        }


        .style4 {
            width: 192px;
        }

        .style5 {
            width: 139px;
            height: 24px;
        }

        .style6 {
            width: 527px;
            height: 24px;
        }

        .style7 {
            width: 192px;
            height: 24px;
        }

        .style8 {
            height: 24px;
        }
        .auto-style3 {
            width: 419px;
        }
        .auto-style4 {
            width: 419px;
            height: 24px;
        }
        .auto-style5 {
            width: 245px;
        }
        .auto-style6 {
            width: 245px;
            height: 24px;
        }
    </style>

</head>
<body style="background-color: #F1F5FB;">
    <form id="form1" runat="server">

        <script type="text/javascript">


            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            }


            function RefreshParentPage() {
                GetRadWindow().Close();
                GetRadWindow().BrowserWindow.location.reload();
            }

            function ClosePage() {
                GetRadWindow().Close();
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
                $find("RadAjaxPanel1").ajaxRequest();
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

            function CloseAndRebind() {
                GetRadWindow().Close();
                GetRadWindow().BrowserWindow.refreshGrid(null);
            }


            function CancelEdit() {
                GetRadWindow().Close();
            }


            function CloseOnReload() {
               GetRadWindow().close();
            }


        </script>
        <div>

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnablePageMethods="True">
          
            </telerik:RadScriptManager>
            
            <div>
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">

                    <Items>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                            Text="Guardar" ToolTip="Guardar Información" Value="0" />

                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 1" />

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="2" />

                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 1" />

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False" />

                    </Items>

                </telerik:RadToolBar>
            </div>

            <table class="style1">

                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label1" runat="server" Text="Serie :" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadTextBox ID="Serie" runat="server" MaxLength="10" TabIndex="1"
                            Rows="1" SelectionOnFocus="CaretToBeginning" AutoPostBack="True">
                        </telerik:RadTextBox>
                                <asp:Label ID="txtMensajeSerie" runat="server" Font-Bold="True"
                                    ForeColor="Red" Width="209px"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:RequiredFieldValidator ID="ValidatorSerie" runat="server"
                            ControlToValidate="Serie" ErrorMessage="Serie  :" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido."
                            Width="18px" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Text="Nemotécnico :" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadTextBox ID="CodigoSerie" runat="server" Width="250px"
                            MaxLength="20" TabIndex="2">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td colspan="2">
                        <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Fechas"
                            Style="text-align: center" Width="287px"></asp:Label>
                        <hr />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label6" runat="server" Text="Codigo ISIN :"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <telerik:RadTextBox ID="CodigoISIN" runat="server" Width="250px" MaxLength="20"
                            TabIndex="3">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style7">&nbsp;</td>
                    <td class="style8">
                        <asp:Label ID="Label7" runat="server" Text="Emisión :"></asp:Label>
                    </td>
                    <td class="style8">
                        <telerik:RadDatePicker ID="FechaEmision" runat="server" TabIndex="12"
                            Culture="es-DO">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="12"
                                runat="server">
                            </DateInput>

                            <DatePopupButton TabIndex="12"></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label5" runat="server" Text="Tipo tasa :" Width="95px" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <telerik:RadComboBox ID="RadComboBoxIdTipotasa" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlDataSourceTipoTasa"
                            DataTextField="Descripcion" DataValueField="idTipotasa"
                            EmptyMessage="Buscar..." Filter="Contains"
                            Width="250px" TabIndex="4">
                        </telerik:RadComboBox>
                    </td>
                    <td class="style7">
                        <asp:RequiredFieldValidator ID="ValidatorIdTipotasa" runat="server"
                            ControlToValidate="RadComboBoxIdTipotasa"
                            ErrorMessage="Tipo tasa" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar un tipo de tasa válido."
                            Width="21px">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style8">
                        <asp:Label ID="Label8" runat="server" Text="Vencimiento :"></asp:Label>
                    </td>
                    <td class="style8">
                        <telerik:RadDatePicker ID="FechaVencimiento" runat="server" TabIndex="13"
                            Culture="es-DO" Style="margin-bottom: 0px">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="13"
                                runat="server">
                            </DateInput>

                            <DatePopupButton  TabIndex="13"></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="style8">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label11" runat="server" Text="Tasa :"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadNumericTextBox ID="txtTasa" runat="server" Culture="en-US"
                            DbValueFactor="1" LabelWidth="64px" TabIndex="5" Type="Percent"
                            Width="160px">
                            <NumberFormat ZeroPattern="n %" DecimalDigits="4"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4">&nbsp;</td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Tipo Liquidación :" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="RadComboBoxTipoLiquidacionID"
                            runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlDataSourceTipoLiquidacion"
                            DataTextField="CodigoInterno" DataValueField="TipoLiquidacionID"
                            EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px"
                            Width="250px" TabIndex="6">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label58" runat="server" Text="Spread :"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadNumericTextBox ID="txtSpread" runat="server" Culture="en-US"
                            DbValueFactor="1" LabelWidth="64px" TabIndex="5" Type="Percent"
                            Width="160px">
                            <NumberFormat ZeroPattern="n %"  DecimalDigits="4"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4">&nbsp;</td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Liquidación :" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="FechaLiquidacion" runat="server" TabIndex="14"
                            Culture="es-DO">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="14"
                                runat="server">
                            </DateInput>

                            <DatePopupButton  TabIndex="14"></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="ValidatorFechaLiquidacion" runat="server"
                            ControlToValidate="FechaLiquidacion"
                            ErrorMessage="Fecha Liquidacion" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar una fecha válida."
                            Width="20px">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label12" runat="server" Text="Periodicidad  :" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadComboBox ID="RadComboBoxTipoPeriodoID"
                            runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoPeriodo"
                            DataTextField="Nombre" DataValueField="TipoPeriodoID"
                            EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px"
                            Width="250px" TabIndex="7">
                        </telerik:RadComboBox>
                    </td>
                    <td class="style4"></td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Inicio Colocación :" Width="122px"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="FechaInicioColocacion" runat="server" TabIndex="15"
                            Culture="es-DO">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="15"
                                runat="server">
                            </DateInput>

                            <DatePopupButton  TabIndex="15"></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label57" runat="server" Font-Bold="True"
                            Text="Base Liquidación :" Width="139px"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadComboBox ID="RadcomboBoxBaseLiquidacion" runat="server"
                            DataSourceID="SqlBaseLiquidacion" DataTextField="Nombre"
                            DataValueField="BaseLiquidacionID" EmptyMessage="Buscar..."
                            Filter="Contains" TabIndex="8" Width="250px" CausesValidation="False"
                            Culture="es-DO" AllowCustomText="True" AutoPostBack="True" style="margin-bottom: 0">
                            <Items>
                                <telerik:RadComboBoxItem runat="server"
                                    Text="Activo" Value="Activo" />
                                <telerik:RadComboBoxItem runat="server"
                                    Text="Inactivo" Value="Inactivo" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td class="style4">
                        <asp:RequiredFieldValidator ID="ValidatorIdTipoLiquidacion" runat="server"
                            ControlToValidate="RadComboBoxTipoLiquidacionID"
                            ErrorMessage="Tipo Liquidación" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar un tipo de Liquidación válido."
                            Width="21px">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Final Colocación :"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="FechaFinalColocacion" runat="server" TabIndex="16"
                            Culture="es-DO">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="16"
                                runat="server">
                            </DateInput>

                            <DatePopupButton  TabIndex="16"></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label9" runat="server" Text="Monto Serie :"
                            Width="131px"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadNumericTextBox ID="ValorUnitarioNominal" runat="server"
                            TabIndex="9">
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4">
                        <asp:RequiredFieldValidator ID="ValidatorPeriodicidad" runat="server"
                            ControlToValidate="RadComboBoxTipoPeriodoID"
                            ErrorMessage="Tipo Periodo" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar un tipo de Periodicidad válido."
                            Width="21px">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label62" runat="server" Text="Fecha de Redención :"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="FechaRedencion" runat="server" TabIndex="16"
                            Culture="es-DO">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="16"
                                runat="server">
                            </DateInput>

                            <DatePopupButton  TabIndex="16"></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label60" runat="server" Text="Valor Nominal Unitario:"
                            Width="153px"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadNumericTextBox ID="txtValorNominalUnitarioSerie" runat="server"
                            TabIndex="9" AutoPostBack="True">
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4">
                        <asp:RequiredFieldValidator ID="ValidatorBaseLiquidacion" runat="server"
                            ControlToValidate="RadcomboBoxBaseLiquidacion"
                            ErrorMessage="Base Liquidación" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar una Base de Liquidación válido."
                            Width="21px">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label63" runat="server" Text="Monto de Redención :"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadNumericTextBox ID="ValorRedencion" runat="server"
                            TabIndex="9">
                        </telerik:RadNumericTextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label61" runat="server" Text="Cantidad de títulos:"
                            Width="131px"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadNumericTextBox ID="txtCantidadTitulos" runat="server"
                            TabIndex="9">
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4">&nbsp;</td>
                    <td>
                        <asp:Label ID="Label64" runat="server" Text="Nota de Redención :"></asp:Label>
                    </td>
                    <td rowspan="3" valign="top">
                                <telerik:RadTextBox ID="txtNotaRedencion" runat="server" Height="54px" LabelWidth="64px" TabIndex="9" TextMode="MultiLine" Width="177px">
                                </telerik:RadTextBox>
                            </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label13" runat="server" Text="Inversión Mínima :"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadNumericTextBox ID="InversionMinima" runat="server" TabIndex="10">
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label10" runat="server" Text="Inversión Máxima :"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadNumericTextBox ID="InversionMaxima" runat="server" TabIndex="11">
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label65" runat="server" Text="Monto Máximo Día(IG):"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadNumericTextBox ID="InversionMaximaIG" runat="server" TabIndex="11">
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4">&nbsp;</td>
                    <td>
                        <asp:Label ID="Guardado" runat="server" Font-Bold="True"
                            ForeColor="Red" Width="130px"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label66" runat="server" Text="Cantidad Días Máximo(IG)"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <telerik:RadComboBox ID="RadComboBoxDiasInversionMaximaIG"
                            runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False"
                            DataTextField="CodigoInterno" DataValueField="TipoLiquidacionID"
                            EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px"
                            Width="156px" TabIndex="6" Height="16px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="1" Value="1" />
                                <telerik:RadComboBoxItem runat="server" Text="2" Value="2" />
                                <telerik:RadComboBoxItem runat="server" Text="3" Value="3" />
                                <telerik:RadComboBoxItem runat="server" Text="4" Value="4" />
                                <telerik:RadComboBoxItem runat="server" Text="5" Value="5" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td class="style4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">

                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:SqlDataSource ID="SqlTipoPeriodo" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT [TipoPeriodoID], [TipoPeriodoCodigo], RTRIM([Nombre]) AS Nombre FROM [TipoPeriodo] WHERE ([Activo] = @Activo) ORDER BY Nombre">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="True" Name="Activo" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlBaseLiquidacion" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT RTRIM([Nombre]) AS Nombre, [BaseLiquidacionID] FROM [BaseLiquidacion] WHERE ([Activo] = @Activo) ORDER BY Nombre">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="True" Name="Activo" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td class="style4">&nbsp;</td>
                    <td colspan="2">
                        <asp:SqlDataSource ID="SqlDataSourceTipoLiquidacion" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT [TipoLiquidacionID], RTRIM([Nombre]) AS Nombre, [CodigoInterno] FROM [TipoLiquidacion]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSourceTipoTasa" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT [idTipotasa], [Descripcion], [Atributo] FROM [TipoTasa] ORDER BY [Descripcion]"></asp:SqlDataSource>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
