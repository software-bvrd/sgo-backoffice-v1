<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ProrrateoLibrodeOrdenes" CodeBehind="ProrrateoLibrodeOrdenes.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head id="Head1" runat="server">
    <title>Prorrateo Libro de Ordenes</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        /**/
        .auto-style1 {
            width: 279px;
        }

        .auto-style3 {
            width: 156px;
            height: 23px;
        }

        .auto-style4 {
            width: 279px;
            height: 23px;
        }

        .auto-style5 {
            width: 224px;
        }

        .auto-style6 {
            height: 23px;
            width: 224px;
        }

        .rdfd_ {
            position: absolute;
        }

        .rdfd_ {
            position: absolute;
        }

        .rdfd_ {
            position: absolute;
        }

        div.RadPicker table.rcSingle .rcInputCell {
            padding-right: 0;
        }

        div.RadPicker table.rcSingle .rcInputCell {
            padding-right: 0;
        }

        div.RadPicker table.rcSingle .rcInputCell {
            padding-right: 0;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
        }

            .RadInput .riTextBox {
                height: 17px;
            }

            .RadInput .riTextBox {
                height: 17px;
            }

            .RadInput .riTextBox {
                height: 17px;
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
                        Text="Procesar" ToolTip="Procesar Información" Value="0">
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
            <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label></div>
        <div>
            <table class="style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Tipo Libro Ordenes :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="cboTipoLibroOrdenes" runat="server"
                            DataSourceID="SqlTipoLibroOrdenes" DataTextField="TipoLibroOrdenes"
                            DataValueField="TipoLibroOrdenes" EmptyMessage="Buscar..." Filter="Contains"
                            Width="230px" AllowCustomText="True" Style="margin-left: 0px" AutoPostBack="True" CausesValidation="False">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label45" runat="server" Font-Bold="False" Text="Emisor :"
                            Width="101px"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="RadComboBoxEmisorID" runat="server"
                            DataSourceID="SqlEmisorID" DataTextField="NombreEmisor"
                            DataValueField="EmisorID" EmptyMessage="Buscar..." Filter="Contains"
                            Width="358px" AllowCustomText="True" AutoPostBack="True"
                            CausesValidation="False" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label46" runat="server" Font-Bold="False" Text="Emisión :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="RadComboBoxEmisionID" runat="server"
                            DataSourceID="SqlEmision" DataTextField="CodEmisionBVRD"
                            DataValueField="EmisionID" EmptyMessage="Buscar..." Filter="Contains"
                            Width="230px" AllowCustomText="True" AutoPostBack="True"
                            CausesValidation="False" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="VakidadorEmision" runat="server"
                            ControlToValidate="RadComboBoxEmisionID" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="208px" ToolTip="Debe seleccionar una Emisión.">Debe seleccionar una Emisión.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label51" runat="server" Font-Bold="False" Text="Serie :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="cbEmisionSerie" runat="server"
                            DataSourceID="SqlEmisionSerie" DataTextField="CodigoSerie"
                            DataValueField="CodigoSerie" EmptyMessage="Buscar..." Filter="Contains"
                            Width="230px" AllowCustomText="True" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Fecha prorrateo :"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <telerik:RadDatePicker ID="txtFechaProrrateo" runat="server" Style="margin-left: 0px"
                            Culture="es-DO" Width="169px">
                            <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                ViewSelectorText="x" runat="server">
                            </Calendar>
                            <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%" runat="server" value="">
                                <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                <FocusedStyle Resize="None"></FocusedStyle>

                                <DisabledStyle Resize="None"></DisabledStyle>

                                <InvalidStyle Resize="None"></InvalidStyle>

                                <HoveredStyle Resize="None"></HoveredStyle>

                                <EnabledStyle Resize="None"></EnabledStyle>
                            </DateInput>
                            <DatePopupButton></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtFechaProrrateo" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="209px" ToolTip="Debe seleccionar una Fecha Inicial.">Debe seleccionar una Fecha Inicial.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label47" runat="server" Font-Bold="False" Text="Fecha inicial :"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <telerik:RadDatePicker ID="txtFechaInicial" runat="server" Style="margin-left: 0px"
                            Culture="es-DO" Width="169px">
                            <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                ViewSelectorText="x" runat="server">
                            </Calendar>
                            <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%" runat="server">
                                <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                <FocusedStyle Resize="None"></FocusedStyle>

                                <DisabledStyle Resize="None"></DisabledStyle>

                                <InvalidStyle Resize="None"></InvalidStyle>

                                <HoveredStyle Resize="None"></HoveredStyle>

                                <EnabledStyle Resize="None"></EnabledStyle>
                            </DateInput>
                            <DatePopupButton></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="VakidadorFechaInicial" runat="server"
                            ControlToValidate="txtFechaInicial" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="209px" ToolTip="Debe seleccionar una Fecha Inicial.">Debe seleccionar una Fecha Inicial.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label48" runat="server" Font-Bold="False" Text="Fecha Final :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadDatePicker ID="txtFechaFinal" runat="server" Style="margin-left: 0px"
                            Culture="es-DO" Width="169px">
                            <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                ViewSelectorText="x" runat="server">
                            </Calendar>
                            <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%" runat="server">
                                <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                <FocusedStyle Resize="None"></FocusedStyle>

                                <DisabledStyle Resize="None"></DisabledStyle>

                                <InvalidStyle Resize="None"></InvalidStyle>

                                <HoveredStyle Resize="None"></HoveredStyle>

                                <EnabledStyle Resize="None"></EnabledStyle>
                            </DateInput>
                            <DatePopupButton></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="VakidadorFechaFinal" runat="server"
                            ControlToValidate="txtFechaFinal" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="215px" ToolTip="Debe seleccionar una Fecha Final.">Debe seleccionar una Fecha Final.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label49" runat="server" Font-Bold="False" Text="Minimo de Inversión :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadNumericTextBox ID="txtValorMinimoInversion" runat="server" TabIndex="2" DataType="System.Decimal" Enabled="False" Culture="en-US" DbValueFactor="1" LabelWidth="64px" Width="160px">
                            <NegativeStyle Resize="None"></NegativeStyle>

                            <NumberFormat ZeroPattern="n" DecimalDigits="2"></NumberFormat>

                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                            <FocusedStyle Resize="None"></FocusedStyle>

                            <DisabledStyle Resize="None"></DisabledStyle>

                            <InvalidStyle Resize="None"></InvalidStyle>

                            <HoveredStyle Resize="None"></HoveredStyle>

                            <EnabledStyle Resize="None"></EnabledStyle>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label50" runat="server" Font-Bold="False" Text="% de la Emisión :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadNumericTextBox ID="txtPorcentajeEmision" runat="server" TabIndex="2" DataType="System.Decimal" Culture="es-DO" DbValueFactor="1" LabelWidth="64px" MaxValue="100" MinValue="0" Type="Percent" Width="160px" Value="50">
                            <NegativeStyle Resize="None"></NegativeStyle>

                            <NumberFormat ZeroPattern="n" DecimalDigits="2"></NumberFormat>

                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                            <FocusedStyle Resize="None"></FocusedStyle>

                            <DisabledStyle Resize="None"></DisabledStyle>

                            <InvalidStyle Resize="None"></InvalidStyle>

                            <HoveredStyle Resize="None"></HoveredStyle>

                            <EnabledStyle Resize="None"></EnabledStyle>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="VakidadorPorcentajeEmision" runat="server"
                            ControlToValidate="txtPorcentajeEmision" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="250px" ToolTip="Debe ingresar un % de la Emisión." Height="16px">Debe ingresar un % de la Emisión.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:CheckBox ID="chkSobrescribirArchivo" runat="server" Text="Sobrescribir Prorrateo:" TextAlign="Left" Enabled="False" />
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlEmision" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [CodEmisionBVRD], [EmisorID], [Estatus], [EmisionID] FROM [Emision] WHERE (([Estatus] = @Estatus) AND ([EmisorID] = @EmisorID))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="VI" Name="Estatus" Type="String" />
                                <asp:ControlParameter ControlID="RadComboBoxEmisorID" Name="EmisorID" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlEmisorID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [EmisorID], [NombreEmisor] FROM [Emisor] ORDER BY [NombreEmisor]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlEmisionSerie" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT rtrim(CodigoSerie) as CodigoSerie
FROM [EmisionSerie]   inner join EmisionTramo  on EmisionTramo.EmisionTramoID=EmisionSerie.EmisionTramoID
WHERE (EmisionTramo.EmisionID = @EmisionID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="RadComboBoxEmisionID" Name="EmisionID" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlTipoLibroOrdenes" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT DISTINCT TipoLibroOrdenes FROM dbo.Subasta  "></asp:SqlDataSource>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>


</html>
