<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_EditarCambiosTasas" CodeBehind="EditarCambiosTasas.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Editar Tasas de Cambios</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        .style1
        {
            width: 187px;
        }

        .style2
        {
            width: 215px;
        }

        .style3
        {
            width: 185px;
        }

        .style4
        {
            width: 138px;
            text-align: right;
        }
    </style>
</head>
<body style="background-color: #F1F5FB;">
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)				
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

        function CloseAndRebind() {
            GetRadWindow().Close();
            GetRadWindow().BrowserWindow.refreshGrid(null);
        }


        function CancelEdit() {
            GetRadWindow().Close();
        }


        function onFocus(sender) {
            sender.showDropDown();
        }
    </script>
    <form id="form1" runat="server" style="background-color: #F1F5FB">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        </div>
        <div>
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Guardar" ToolTip="Guardar Información" Value="0">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div>
            <table class="style1">
                <tr>
                    <td class="style4">&nbsp;</td>
                    <td class="style2">&nbsp;</td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Fecha :"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadDatePicker ID="txtFecha" runat="server" Style="margin-left: 0px"
                            Culture="es-DO" Height="22px" Width="169px">
                            <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                ViewSelectorText="x" runat="server">
                            </Calendar>
                            <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%" Height="22px" runat="server">
                            </DateInput>
                            <DatePopupButton></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label8" runat="server" Text="Moneda :" Width="125px" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoMoneda"
                            DataTextField="Nombre" DataValueField="TipoMonedaID" EmptyMessage="Buscando..."
                            Filter="Contains" Height="70px" Width="267px" Style="margin-left: 4px"
                            LoadingMessage="Cargando..." OnClientFocus="onFocus" TabIndex="1">
                        </telerik:RadComboBox>
                    </td>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="RadComboBox1" ErrorMessage="Tipo Instrumento" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="21px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label9" runat="server" Text="Tasa Compra :"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadNumericTextBox ID="txtTasaCompra" runat="server" TabIndex="2" DataType="System.Decimal">
                            <NumberFormat ZeroPattern="n" DecimalDigits="14"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtTasaCompra" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="22px" ToolTip="valor de compra.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label10" runat="server" Text="Tasa Venta :"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadNumericTextBox ID="txtTasaVenta" runat="server" TabIndex="3" DataType="System.Decimal">
                            <NumberFormat ZeroPattern="n" DecimalDigits="14"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label12" runat="server" Text="TIPP :" ToolTip="Tasa de interés promedio ponderado."></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadNumericTextBox ID="txtTIPP" runat="server" TabIndex="4" DataType="System.Decimal">
                            <NumberFormat ZeroPattern="n" DecimalDigits="14"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">&nbsp;</td>
                    <td class="style2">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlTipoMoneda" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT * FROM [TipoMoneda] WHERE ([Local] = @Local)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="False" Name="Local" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>


</html>
