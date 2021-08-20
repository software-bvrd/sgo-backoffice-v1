<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditarOperacionesValoresEnFirme.aspx.vb" Inherits="Sgo.WebApp.EditarOperacionesValoresEnFirme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Editar Operaciones Valores En Firme</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        .auto-style1 {
            width: 333px;
        }

        .auto-style3 {
            width: 152px;
            height: 23px;
        }

        .auto-style4 {
            width: 333px;
            height: 23px;
        }

        .auto-style5 {
            width: 16px;
        }

        .auto-style6 {
            height: 23px;
            width: 16px;
        }

        .auto-style10 {
            width: 537px;
        }

        .auto-style11 {
            height: 23px;
            width: 537px;
        }

        .auto-style13 {
            width: 241px;
        }

        .auto-style14 {
            height: 23px;
            width: 241px;
        }

        .auto-style15 {
            width: 981px;
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


        function MensajeGuardar(texto) {

            alert(texto);

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

        var toolbar;
        function OnClientButtonClicked(sender, args) {
            sender.set_enabled(false);
            toolbar = sender;
            setTimeout('toolbar.set_enabled(true);', 1000);
        }




    </script>
    <form id="form1" runat="server" style="background-color: #F1F5FB">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
            </telerik:RadWindowManager>


        </div>

        <div>
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%" OnClientButtonClicked="OnClientButtonClicked">

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
            <table class="auto-style15">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label45" runat="server" Font-Bold="True" Text="Emisor :"
                            Width="101px"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="RadComboBoxEmisorID" runat="server" DataTextField="NombreEmisor"
                            DataValueField="EmisorID" EmptyMessage="Buscar..." Filter="Contains"
                            Width="358px" AllowCustomText="True" AutoPostBack="True"
                            CausesValidation="False" Style="margin-left: 0px" DataSourceID="SqlEmisorID">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldEmisor" runat="server"
                            ControlToValidate="txtFecha" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="Debe Seleccionar un Emisor">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label46" runat="server" Font-Bold="True" Text="Emisión :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="RadComboBoxEmisionID" runat="server" DataTextField="CodEmisionBVRD"
                            DataValueField="EmisionID" EmptyMessage="Buscar..." Filter="Contains"
                            Width="230px" AllowCustomText="True" AutoPostBack="True"
                            CausesValidation="False" Style="margin-left: 0px" TabIndex="1" DataSourceID="SqlEmision">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldEmision" runat="server"
                            ControlToValidate="txtFecha" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="Debe Seleccionar un programa de Emisiones">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label47" runat="server" Font-Bold="True" Text="Nemotécnico :"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <telerik:RadComboBox ID="RadComboBoxEmisionSerie" runat="server"
                            AllowCustomText="True" CausesValidation="False" DataTextField="CodigoSerie"
                            DataValueField="EmisionSerieID" EmptyMessage="Buscar..." Filter="Contains"
                            Style="margin-left: 0px" Width="215px" Culture="es-DO" TabIndex="2" DataSourceID="SqlEmisionSerie" AutoPostBack="True">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="RequiredFieldEmisionSerie" runat="server"
                            ControlToValidate="txtFecha" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="Debe Seleccionar una Emisión">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label58" runat="server" Font-Bold="True" Text="ISIN :"></asp:Label>
                    </td>
                    <td class="auto-style1" style="margin-left: 0px">

                        <telerik:RadTextBox ID="txtISIN" runat="server" Style="margin-left: 0px" TabIndex="3" Enabled="False"></telerik:RadTextBox>


                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Fecha :"></asp:Label>
                    </td>
                    <td class="auto-style1" style="margin-left: 0px">
                        <telerik:RadDatePicker ID="txtFecha" runat="server" Style="margin-left: 0px"
                            Culture="es-DO" Height="22px" Width="169px" TabIndex="3">
                            <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                ViewSelectorText="x" runat="server" Style="margin-left: 0px">
                            </Calendar>
                            <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%" Height="22px" runat="server" TabIndex="3">
                            </DateInput>
                            <DatePopupButton TabIndex="3"></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldFecha" runat="server"
                            ControlToValidate="txtFecha" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="Fecha Incorrecta">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="Label49" runat="server" Text="Puesto Comprador:"></asp:Label>
                    </td>
                    <td class="auto-style13">

                        <telerik:RadComboBox ID="RadComboPuestoBolsaComprador" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlPuestoBolsaComprador"
                            DataTextField="Nombre" DataValueField="PuestoBolsaID"
                            EmptyMessage="Buscando..." Filter="Contains" Width="303px"
                            LoadingMessage="Cargando..."
                            OnClientFocus="onFocus" TabIndex="10" Sort="Ascending">
                        </telerik:RadComboBox>

                    </td>
                    <td class="auto-style13">

                        <asp:RequiredFieldValidator ID="RequiredFieldPuestoComprador" runat="server"
                            ControlToValidate="txtFecha" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="Debe Seleccionar un comprador">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label53" runat="server" Text="Cantidad Títulos:"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadNumericTextBox ID="txtCantidadTitulos" runat="server" Style="margin-left: 0px" TabIndex="4" DataType="System.Int32">
                            <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldCantidadTitulos" runat="server"
                            ControlToValidate="txtCantidadTitulos" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="Debe colocar Cantidad de Títulos">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="Label50" runat="server" Text="Puesto Vendedor:"></asp:Label>
                    </td>
                    <td class="auto-style13">

                        <telerik:RadComboBox ID="RadComboPuestoBolsaVendedor" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlPuestoBolsaVendedor"
                            DataTextField="Nombre" DataValueField="PuestoBolsaID"
                            EmptyMessage="Buscando..." Filter="Contains" Width="301px"
                            LoadingMessage="Cargando..."
                            OnClientFocus="onFocus" TabIndex="11" Sort="Ascending" Enabled="False">
                        </telerik:RadComboBox>

                    </td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label9" runat="server" Text="Valor Transado:"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadNumericTextBox ID="txtValorTransado" runat="server" Style="margin-left: 0px" TabIndex="5">
                            <NumberFormat ZeroPattern="n" DecimalDigits="2"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValorTransado" runat="server"
                            ControlToValidate="txtValorTransado" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="Debe colocar Valor Transado">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="Label55" runat="server" Text="Número Oferta Compra:"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <telerik:RadTextBox ID="txtNumeroOfertaCompra" runat="server" Style="margin-left: 0px" TabIndex="12" Enabled="False"></telerik:RadTextBox>



                    </td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label48" runat="server" Text="Precio  :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadNumericTextBox ID="txtPrecio" runat="server" Style="margin-left: 0px" TabIndex="6">
                            <NumberFormat ZeroPattern="n" DecimalDigits="4"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldPrecio" runat="server"
                            ControlToValidate="txtPrecio" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="Debe colocar Precio">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="Label56" runat="server" Text="Número Oferta Venta:"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <telerik:RadTextBox ID="txtNumeroOfertaVenta" runat="server" Style="margin-left: 0px" TabIndex="13" Enabled="False"></telerik:RadTextBox>

                    </td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label10" runat="server" Text="Moneda :"></asp:Label>
                    </td>
                    <td class="auto-style1">

                        <telerik:RadComboBox ID="RadComboMoneda" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoMoneda"
                            DataTextField="Nombre" DataValueField="TipoMonedaID" EmptyMessage="Buscando..."
                            Filter="Contains" Height="70px" Width="267px"
                            LoadingMessage="Cargando..." OnClientFocus="onFocus" TabIndex="7">
                        </telerik:RadComboBox>


                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldMoneda" runat="server"
                            ControlToValidate="txtPrecio" ErrorMessage="Name" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="Debe seleccionar una moneda">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="Label51" runat="server" Text="Origen :"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <telerik:RadComboBox ID="RadComboOrigen" runat="server" Width="267px" TabIndex="14" Enabled="False">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="CARTERA PROPIA" Value="CARTERA PROPIA" />
                                <telerik:RadComboBoxItem runat="server" Text="TERCERO" Value="TERCERO" Selected="True" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label54" runat="server" Text="Mercado :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="RadComboMercado" runat="server" Width="267px" DataSourceID="SqlMercado" DataTextField="Nombre" DataValueField="MercadoID" TabIndex="8">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="Label52" runat="server" Text="Destino :"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <telerik:RadComboBox ID="RadComboDestino" runat="server" Width="267px" TabIndex="15">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="CARTERA PROPIA" Value="CARTERA PROPIA" />
                                <telerik:RadComboBoxItem runat="server" Text="TERCERO" Value="TERCERO" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label57" runat="server" Text="Rueda :"></asp:Label>
                    </td>
                    <td class="auto-style1">

                        <telerik:RadComboBox ID="RadComboRueda" runat="server" DataSourceID="SqlRueda" DataTextField="Nombre" DataValueField="RuedaID" TabIndex="9" Width="261px" Enabled="False">
                        </telerik:RadComboBox>

                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>

                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style14"></td>
                    <td class="auto-style14">&nbsp;</td>
                </tr>

                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>

                        <asp:SqlDataSource ID="SqlEmisionSerie" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT EmisionSerieID, CodigoSerie, EmisionID FROM vEmisionSerieConsulta WHERE (EmisionID = @EmisionID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="RadComboBoxEmisionID" Name="EmisionID" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <asp:SqlDataSource ID="SqlEmision" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [CodEmisionBVRD], [EmisorID], [Estatus], [EmisionID] FROM [Emision] WHERE (([Estatus] = @Estatus) AND ([EmisorID] = @EmisorID))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="VI" Name="Estatus" Type="String" />
                                <asp:ControlParameter ControlID="RadComboBoxEmisorID" Name="EmisorID" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>


                        <asp:SqlDataSource ID="SqlEmisorID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT EmisorID, NombreEmisor, CodEmisorBVRD FROM Emisor ORDER BY NombreEmisor"></asp:SqlDataSource>

                        <asp:SqlDataSource ID="SqlTipoMoneda" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT * FROM [TipoMoneda] ">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="False" Name="Local" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <%-- Puesto Bolsa Comprador  --%>
                        <asp:SqlDataSource ID="SqlPuestoBolsaComprador" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT PuestoBolsaID, Nombre, TipoParticipanteID, PuestoBolsaCodigo FROM PuestoBolsa WHERE (Activo = 1) AND (TipoParticipanteID = 1) ORDER BY Nombre"></asp:SqlDataSource>


                        <%-- Puesto Bolsa Vendedor  --%>
                        <asp:SqlDataSource ID="SqlPuestoBolsaVendedor" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT PuestoBolsaID, Nombre, TipoParticipanteID, PuestoBolsaCodigo FROM PuestoBolsa WHERE (Activo = 1) AND (TipoParticipanteID = 1) ORDER BY Nombre"></asp:SqlDataSource>


                        <asp:SqlDataSource ID="SqlMercado" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [Nombre], [CodigoMercado], [MercadoID] FROM [vMercado] where Nombre Like '%Firme%' ORDER BY [Nombre]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlRueda" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [CodRueda], [Nombre], [RuedaID] FROM [Rueda] ORDER BY [Nombre]"></asp:SqlDataSource>


                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                </tr>
            </table>
        </div>





    </form>
</body>
</html>

