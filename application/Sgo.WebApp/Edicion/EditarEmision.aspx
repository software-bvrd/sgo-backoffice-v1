<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Edicion_EditarEmision" CodeBehind="EditarEmision.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <title>Edición Programa de Emisión</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        .style1 {
        }

        .style3 {
            width: 208px;
            height: 28px;
        }

        .style5 {
            height: 23px;
        }

        .style13 {
            width: 433px;
        }

        .style14 {
            width: 31px;
        }

        .style16 {
            width: 236px;
        }

        .style17 {
            width: 84px;
        }

        .style18 {
            width: 369px;
        }

        .style19 {
            width: 8px;
        }

        .style23 {
            width: 385px;
            margin-left: 40px;
        }

        .style24 {
            width: 385px;
            height: 28px;
        }

        .style27 {
            width: 434px;
        }

        .style28 {
            width: 202px;
        }

        .style29 {
            width: 202px;
            height: 28px;
        }

        .style31 {
            width: 420px;
        }

        .style32 {
            width: 434px;
            height: 23px;
        }

        .style33 {
            width: 420px;
            height: 23px;
        }

        .style34 {
            width: 202px;
            height: 26px;
        }

        .style35 {
            width: 385px;
            height: 26px;
        }

        .style36 {
            width: 208px;
            height: 26px;
        }

        .style39 {
            width: 277px;
        }

        .style41 {
            width: 223px;
        }

        .style42 {
            height: 161px;
        }

        .style45 {
            width: 100%;
        }

        .style46 {
        }

        .style47 {
            width: 138px;
        }

        .auto-style1 {
            height: 39px;
        }

        .auto-style2 {
            width: 434px;
            height: 39px;
        }

        .auto-style3 {
            width: 420px;
            height: 39px;
        }

        .auto-style4 {
            width: 253px;
        }

        .auto-style5 {
            width: 253px;
            height: 26px;
        }

        .auto-style6 {
            width: 253px;
            height: 28px;
        }
    </style>
    <script type="text/javascript" id="telerikClientEvents1">

    </script>



    <script type="text/javascript" id="telerikClientEvents2">
        //<![CDATA[

        function LinkButton3_Click(sender, args) {
            $find("RadAjaxManager1").ajaxRequest();
            var oWnd = window.radopen("EditarEmision.aspx");
            oWnd.setSize(1300, 600);
            oWnd.moveTo(10, 1);
            oWnd.maximize();
            oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Maximize);

        }
        //]]>
    </script>



    <script type="text/javascript" id="telerikClientEvents3">
        //<![CDATA[

        function RadGridSerie_OnRowDblClick(sender, args) {
            __doPostBack("EditarSerie");
        }
        //]]>
    </script>



</head>

<body style="background-color: #F1F5FB;">


    <%-- Funciones JS --%>
    <script type="text/javascript">


        var lastClickedItem = null;
        var clickCalledAfterRadconfirm = false;

        function onClientButtonClicking(sender, args) {
            if (args.get_item().get_text() == "Borrar") {
                if (!clickCalledAfterRadconfirm) {
                    args.set_cancel(true);
                    lastClickedItem = args.get_item();
                    radconfirm("Está seguro querer borrar ?", confirmCallbackFunction, 330, 140, null, "SGO: Emisiones");
                }
            }
        }


        function confirmCallbackFunction(args) {
            if (args) {
                clickCalledAfterRadconfirm = true;
                lastClickedItem.click();
            }
            else
                clickCalledAfterRadconfirm = false;
            lastClickedItem = null;
        }




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
            alert("Dialog is about to close itself");
            GetRadWindow().close();
        }

        function RefreshGrid() {
            var masterTable = $find("<%= RadGridSerie.ClientID %>").get_masterTableView();
            masterTable.rebind();
        }


    </script>


    <%-- Formulario --%>
    <form id="form1" runat="server" style="background-color: #F1F5FB">


        <div>

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

            <%-- TAB Manager --%>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server"
                SelectedIndex="2" MultiPageID="RadMultiPage1" CausesValidation="False"
                Width="100%">


                <Tabs>
                    <telerik:RadTab runat="server" Text="Datos Programa" PageViewID="RadPageView1"
                        SelectedIndex="1">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" Text="Puestos Bolsa" PageViewID="RadPageView5"
                        SelectedIndex="6">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" Text="Emisiones" PageViewID="RadPageView2"
                        SelectedIndex="3" Selected="True">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" PageViewID="RadPageView4"
                        Text="Documentos" SelectedIndex="4">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" PageViewID="RadPageView3"
                        Text="Calificación de Riesgo" SelectedIndex="5">
                    </telerik:RadTab>

                </Tabs>

            </telerik:RadTabStrip>

            <%-- ToolBar --%>
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                <Items>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png"
                        Text="Nuevo" ToolTip="Crear Nuevo" Value="2" CausesValidation="False">
                    </telerik:RadToolBarButton>


                    <telerik:RadToolBarButton runat="server"
                        Text="Button 4" IsSeparator="True">
                    </telerik:RadToolBarButton>


                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Guardar" ToolTip="Guardar Información" Value="0"
                        CausesValidation="false">
                    </telerik:RadToolBarButton>


                    <telerik:RadToolBarButton runat="server"
                        ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="3">
                    </telerik:RadToolBarButton>


                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1">
                    </telerik:RadToolBarButton>


                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False">
                    </telerik:RadToolBarButton>

                </Items>

            </telerik:RadToolBar>


            <br />
            <%-- Paginas --%>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Height="16px"
                SelectedIndex="1" Width="165px">

                <%--Emisión Datos Generales--%>
                <telerik:RadPageView ID="RadPageView1" runat="server" Selected="True" TabIndex="1" Width="922px">
                    <table cellpadding="0px 0px 8px 0px" class="style1">
                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Cód Emisión BVRD  :" Width="151px"></asp:Label></td>
                            <td class="style23">
                                <telerik:RadTextBox ID="txtCodEmisionBVRD" runat="server" Height="24px" LabelWidth="64px" TabIndex="1" Width="113px"></telerik:RadTextBox><asp:Label ID="Guardado" runat="server" Font-Bold="True" ForeColor="Red" Width="209px"></asp:Label></td>
                            <td class="auto-style4">
                                <asp:TextBox ID="Codigo" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="35px"></asp:TextBox></td>
                            <td>
                                <asp:Label ID="Label66" runat="server" Text="Monto Total  :"></asp:Label></td>
                            <td>
                                <telerik:RadNumericTextBox ID="txtMontoTotalDeLaEmision" runat="server" TabIndex="17"></telerik:RadNumericTextBox><asp:RequiredFieldValidator ID="ValidatorMontoTotalDeLaEmision" runat="server" ControlToValidate="txtMontoTotalDeLaEmision" ErrorMessage="Monto Tota lDe La Emision" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Ingrese un monto total válido." Width="184px">Ingrese un monto total válido.</asp:RequiredFieldValidator></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label41" runat="server" Text="Cód. SIV:"></asp:Label>&nbsp;</td>
                            <td class="style23">
                                <telerik:RadTextBox ID="txtCodEnSistema" runat="server" Height="24px" LabelWidth="64px" TabIndex="2" Width="113px"></telerik:RadTextBox><asp:RequiredFieldValidator ID="ValidatorCodigoSistema" runat="server" ControlToValidate="txtCodEnSistema" ErrorMessage="Codigo" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Ingrese Cód. SIV válido." Width="177px">Ingrese Cód. SIV válido.</asp:RequiredFieldValidator></td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>
                                <asp:Label ID="Label67" runat="server" Text="Monto Ofertado  :"></asp:Label></td>
                            <td>
                                <telerik:RadNumericTextBox ID="txtMontoOfertadoAlPublico" runat="server" Enabled="False" Font-Bold="True" TabIndex="18"></telerik:RadNumericTextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label45" runat="server" Font-Bold="True" Text="Emisor :" Width="70px"></asp:Label></td>
                            <td class="style23">
                                <telerik:RadComboBox ID="RadComboBoxEmisorID" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlEmisorID" DataTextField="NombreEmisor" DataValueField="EmisorID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="348px" TabIndex="3"></telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="ValidatorRadComboBoxEmisorID" runat="server" ControlToValidate="RadComboBoxEmisorID" ErrorMessage="Emisor" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar un emisor válido." Width="290px">Debe ingresar un emisor válido.</asp:RequiredFieldValidator></td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>
                                <asp:Label ID="Label68" runat="server" Text="Valor Nominal"></asp:Label></td>
                            <td>
                                <telerik:RadNumericTextBox ID="txtValorNominal" runat="server" TabIndex="19"></telerik:RadNumericTextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style34" rowspan="2">
                                <asp:Label ID="Label9" runat="server" Font-Bold="False" Text="Descripción :" Width="137px"></asp:Label></td>
                            <td class="style35" rowspan="2">
                                <telerik:RadTextBox ID="txtDescripcionEmision" runat="server" Height="52px" LabelWidth="64px" TabIndex="4" TextMode="MultiLine" Width="348px"></telerik:RadTextBox><asp:RequiredFieldValidator ID="ValidatorDireccionEmision" runat="server" ControlToValidate="txtDescripcionEmision" ErrorMessage="Descripcion" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Ingrese una descripción" Width="245px">Ingrese una descripción</asp:RequiredFieldValidator></td>
                            <td class="auto-style5" rowspan="2">&nbsp;</td>
                            <td class="style36">
                                <asp:Label ID="Label57" runat="server" Font-Bold="False" Text="Base Liquidación :" Width="121px"></asp:Label></td>
                            <td class="style36">
                                <telerik:RadComboBox ID="RadcomboBoxBaseLiquidacion" runat="server" Culture="es-DO" DataSourceID="SqlBaseLiquidacion" DataTextField="Nombre" DataValueField="BaseLiquidacionID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="20" Width="266px">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Activo" Value="Activo" />
                                        <telerik:RadComboBoxItem runat="server" Text="Inactivo" Value="Inactivo" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td class="style36" rowspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style36">&nbsp;</td>
                            <td class="style36">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label46" runat="server" Font-Bold="False" Text="Cantidad Tramos :" Width="137px"></asp:Label></td>
                            <td class="style24">
                                <telerik:RadNumericTextBox ID="txtCantidadTramos" runat="server" TabIndex="5"></telerik:RadNumericTextBox></td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="style3">
                                <asp:Label ID="Label58" runat="server" Font-Bold="False" Text="Estatus :" Width="137px"></asp:Label></td>
                            <td class="style3">
                                <telerik:RadComboBox ID="RadComboBoxEstatus" runat="server" EmptyMessage="Buscar..." Filter="Contains" TabIndex="21" DataSourceID="SqlEmisionEstatus" DataTextField="Descripcion" DataValueField="CodigoEstatus">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Activo" Value="Activo" />
                                        <telerik:RadComboBoxItem runat="server" Text="Inactivo" Value="Inactivo" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label47" runat="server" Font-Bold="False" Text="Fecha Aprobación BVRD :" Width="171px"></asp:Label></td>
                            <td class="style24">
                                <telerik:RadDatePicker ID="txtFechaAprobacionBVRD" runat="server" Culture="es-DO" TabIndex="6">
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                    <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="6"></DateInput><DatePopupButton TabIndex="6" />
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="ValidatorFechaAprobacionBVRD" runat="server" ControlToValidate="txtFechaAprobacionBVRD" ErrorMessage="Fecha Aprobacion BVRD" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Ingrese Fecha Aprobación BVRD" Width="250px">Ingrese Fecha Aprobación BVRD</asp:RequiredFieldValidator></td>
                            <td class="auto-style6" rowspan="2">&nbsp;</td>
                            <td class="style3" rowspan="2">
                                <asp:Label ID="Label59" runat="server" Font-Bold="False" Text="Nota1 :" Width="137px"></asp:Label></td>
                            <td class="style3" rowspan="2">
                                <telerik:RadTextBox ID="txtNota1" runat="server" Height="52px" LabelWidth="64px" TabIndex="22" TextMode="MultiLine" Width="388px"></telerik:RadTextBox></td>
                            <td class="style3" rowspan="2"></td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label48" runat="server" Font-Bold="False" Text="Fecha Aprobación SIV :" Width="161px"></asp:Label></td>
                            <td class="style24">
                                <telerik:RadDatePicker ID="txtFechaAprobacionSIV" runat="server" Culture="en-US" TabIndex="7">
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                    <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="7"></DateInput><DatePopupButton TabIndex="7" />
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="ValidatorFechaAprobacionSIV" runat="server" ControlToValidate="txtFechaAprobacionSIV" ErrorMessage="Fecha Aprobacion SIV" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Ingrese Fecha Aprobación SIV" Width="195px">Ingrese Fecha Aprobación SIV</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label49" runat="server" Font-Bold="False" Text="Tipo Amortización :" Width="137px"></asp:Label></td>
                            <td class="style24">
                                <telerik:RadComboBox ID="RadComboBoxTipoAmortizacionCapitalID" runat="server" DataSourceID="SqlTipoAmortizacionCapitalID" DataTextField="Nombre" DataValueField="TipoAmortizacionCapitalID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="8"></telerik:RadComboBox>
                            </td>
                            <td class="auto-style6" rowspan="2">&nbsp;</td>
                            <td class="style3" rowspan="2">
                                <asp:Label ID="Label60" runat="server" Font-Bold="False" Text="Nota2 :" Width="137px"></asp:Label></td>
                            <td class="style3" rowspan="2">
                                <telerik:RadTextBox ID="txtNota2" runat="server" Height="52px" LabelWidth="64px" TabIndex="23" TextMode="MultiLine" Width="388px"></telerik:RadTextBox></td>
                            <td class="style3" rowspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label50" runat="server" Font-Bold="False" Text="Finalidad De La Emisión :" Width="179px"></asp:Label></td>
                            <td class="style24">
                                <telerik:RadTextBox ID="txtFinalidadDeLaEmision" runat="server" Height="36px" LabelWidth="64px" TabIndex="9" TextMode="MultiLine" Width="334px"></telerik:RadTextBox></td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label51" runat="server" Font-Bold="False" Text="Subir AOP  :" Width="137px"></asp:Label></td>
                            <td class="style24">
                                <telerik:RadComboBox ID="RadComboBoxSubirAOP" runat="server" Culture="es-DO" EmptyMessage="Buscar..." Filter="Contains" TabIndex="10" Width="119px">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Si" Value="S" />
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="No" Value="N" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="style3">
                                <asp:Label ID="Label61" runat="server" Font-Bold="False" Text="Tipo De Emisión :" Width="137px"></asp:Label></td>
                            <td class="style3">
                                <telerik:RadComboBox ID="RadComboBoxTipoDeEmisionID" runat="server" DataSourceID="SqlTipoDeEmisionID" DataTextField="Nombre" DataValueField="TipoDeEmisionID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="24" Width="260px">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Activo" Value="Activo" />
                                        <telerik:RadComboBoxItem runat="server" Text="Inactivo" Value="Inactivo" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label74" runat="server" Font-Bold="False" Text="Garantía del Programa de Emisión :" Width="137px"></asp:Label></td>
                            <td class="style24">
                                <telerik:RadTextBox ID="txtGarantiaProgramaEmision" runat="server" Height="36px" LabelWidth="64px" TabIndex="10" TextMode="MultiLine" Width="334px"></telerik:RadTextBox></td>
                            <td class="auto-style6" rowspan="2">&nbsp;</td>
                            <td class="style3" rowspan="2">
                                <asp:Label ID="Label73" runat="server" Font-Bold="False" Text="Tipo Instrumento :" Width="137px"></asp:Label></td>
                            <td class="style3" rowspan="2">
                                <telerik:RadComboBox ID="RadComboBoxTipoInstrumentoID" runat="server" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoInstrumento" DataTextField="Nombre" DataValueField="TipoInstrumentoID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="25" Width="260px"></telerik:RadComboBox>
                            </td>
                            <td class="style3" rowspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label75" runat="server" Font-Bold="False" Text="Fecha Final Colocación:" Width="161px"></asp:Label></td>
                            <td class="style24">
                                <telerik:RadDatePicker ID="rdpFechaFinalColocacion" runat="server" Culture="en-US" TabIndex="11">
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                    <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="11">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput><DatePopupButton TabIndex="11" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label76" runat="server" Font-Bold="False" Text="Calcular Comisión:" Width="161px"></asp:Label></td>
                            <td class="style24">
                                <asp:CheckBox ID="cbCalcularComision" runat="server" TabIndex="12" /></td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="style3">
                                <asp:Label ID="Label63" runat="server" Font-Bold="False" Text="Instrumento :" Width="137px"></asp:Label></td>
                            <td class="style3">
                                <telerik:RadComboBox ID="RadComboBoxInstrumentoID" runat="server" DataSourceID="SqlInstrumentoID" DataTextField="Nombre" DataValueField="InstrumentoID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="26" Width="260px"></telerik:RadComboBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label77" runat="server" Font-Bold="False" Text="En base a colocación:" Width="169px"></asp:Label></td>
                            <td class="style24">
                                <asp:CheckBox ID="cbAplicarComisionEnBaseTramosVigentes" runat="server" TabIndex="13" /></td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="style3">
                                <asp:Label ID="Label64" runat="server" Font-Bold="False" Text="Tipo Moneda :" Width="137px"></asp:Label></td>
                            <td class="style3">
                                <telerik:RadComboBox ID="RadComboBoxTipoMonedaID" runat="server" DataSourceID="SqlTipoMonedaID" DataTextField="Nombre" DataValueField="TipoMonedaID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="27" Width="260px"></telerik:RadComboBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">Neg. Mercado Secundario</td>
                            <td class="style24">
                                <telerik:RadComboBox ID="rcbTipoNegMercadoSecundario" runat="server" DataSourceID="SqlTipoNegociacion" DataTextField="Nombre" DataValueField="TipoNegociacionID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="14"></telerik:RadComboBox>
                            </td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="style3">
                                <asp:Label ID="Label65" runat="server" Font-Bold="False" Text="Forma Colocación  :" Width="137px"></asp:Label></td>
                            <td class="style3">
                                <telerik:RadComboBox ID="RadComboBoxFormaColocacionID" runat="server" DataSourceID="SqlFormaColocacionID" DataTextField="Nombre" DataValueField="FormaColocacionID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="28" Width="260px"></telerik:RadComboBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">Contempla Redención</td>
                            <td class="style24">
                                <asp:CheckBox ID="cbContemplaRedencion" runat="server" TabIndex="15" /></td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">Fecha Contempla Redención</td>
                            <td class="style24">
                                <telerik:RadDatePicker ID="txtFechaContemplaRedencion" runat="server" Culture="es-DO" TabIndex="16">
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                    <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="16">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput><DatePopupButton TabIndex="16" />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style28">
                                <asp:SqlDataSource ID="SqlEmisorID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [EmisorID], [NombreEmisor] FROM [Emisor] ORDER BY [NombreEmisor]"></asp:SqlDataSource>
                            </td>
                            <td class="style23">
                                <asp:SqlDataSource ID="SqlBaseLiquidacion" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT RTRIM([Nombre]) AS Nombre, [BaseLiquidacionID] FROM [BaseLiquidacion] WHERE ([Activo] = @Activo) ORDER BY Nombre ">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="True" Name="Activo" Type="Boolean" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlTipoAmortizacionCapitalID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [TipoAmortizacionCapitalID], [Nombre] FROM [TipoAmortizacionCapital] ORDER BY [Nombre]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlTipoMonedaID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [TipoMonedaID], [Nombre] FROM [TipoMoneda] ORDER BY [Nombre]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlTipoInstrumento" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT TipoInstrumentoID, RTRIM(Nombre) AS Nombre, Activo FROM TipoInstrumento WHERE (Activo = @Activo) ORDER BY Nombre ">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="True" Name="Activo" Type="Boolean" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <asp:SqlDataSource ID="SqlTipoNegociacion" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT TipoNegociacionID, RTRIM(Nombre) AS Nombre, Activo FROM TipoNegociacion WHERE (Activo = @Activo) ORDER BY Nombre ">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="True" Name="Activo" Type="Boolean" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:SqlDataSource ID="SqlTipoDeEmisionID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [TipoDeEmisionID], RTRIM([Nombre]) AS Nombre FROM [TipoEmision] ORDER BY Nombre "></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlInstrumentoID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [InstrumentoID], RTRIM([Nombre]) AS Nombre, [TipoInstrumentoID] FROM [Instrumento] WHERE ([TipoInstrumentoID] = @TipoInstrumentoID) ORDER BY Nombre ">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="RadComboBoxTipoInstrumentoID" Name="TipoInstrumentoID" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlFormaColocacionID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [MercadoID], [FormaColocacionID], RTRIM([Nombre]) AS Nombre, [Activo] FROM [FormaColocacion] ORDER BY Nombre "></asp:SqlDataSource>
                                <br />
                                <asp:SqlDataSource ID="SqlEmisionEstatus" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" DataSourceMode="DataReader" SelectCommand="SELECT [EmisionEstatusID] ,RTRIM([CodigoEstatus]) as CodigoEstatus ,RTRIM([Descripcion]) as Descripcion ,[MostrarEnEdicion] ,[Activo] FROM [dbo].[EmisionEstatus]  ORDER BY [Descripcion]"></asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </telerik:RadPageView>

                <%-- Tramos y Series --%>
                <telerik:RadPageView ID="RadPageView2" runat="server" Width="1200px" TabIndex="2">
                    <table class="style1">
                        <tr>
                            <td class="style1" colspan="9">

                                <telerik:RadGrid ID="RadGridSerie" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" DataSourceID="SqlEmisionSerie" GridLines="None" PageSize="20" Width="100%">

                                    <ExportSettings ExportOnlyData="True" FileName="Emision Series" OpenInNewWindow="True">
                                        <Pdf PageTitle="Emisión Series" Title="Emisión Series" />
                                    </ExportSettings>

                                    <ClientSettings ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <ClientEvents OnRowDblClick="RadGridSerie_OnRowDblClick" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                        <Resizing AllowColumnResize="True" AllowResizeToFit="True" EnableRealTimeResize="True" />
                                    </ClientSettings>

                                    <MasterTableView AllowSorting="True" Caption="Emisión(s) [Series]" CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="EmisionSerieID" DataSourceID="SqlEmisionSerie" NoMasterRecordsText="No hay información para mostrar." CommandItemDisplay="Bottom">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridTemplateColumn FilterControlAltText="Filter column column" HeaderText="Editar" UniqueName="column" Visible="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Editar</asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridBoundColumn DataField="EmisionTramoID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionTramoID column" HeaderText="EmisionTramoID" SortExpression="EmisionTramoID" UniqueName="EmisionTramoID"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmisionSerieID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionSerieID column" HeaderText="EmisionSerieID" ReadOnly="True" SortExpression="EmisionSerieID" UniqueName="EmisionSerieID"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Serie" FilterControlAltText="Filter Serie column" HeaderText="Serie" SortExpression="Serie" UniqueName="Serie"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CodigoSerie" FilterControlAltText="Filter CodigoSerie column" HeaderText="Nemotécnico" SortExpression="CodigoSerie" UniqueName="CodigoSerie"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="idTipotasa" DataType="System.Int32" FilterControlAltText="Filter idTipotasa column" HeaderText="idTipotasa" SortExpression="idTipotasa" UniqueName="idTipotasa" Visible="False"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoTasa" FilterControlAltText="Filter TipoTasa column" HeaderText="Tipo Tasa" SortExpression="TipoTasa" UniqueName="TipoTasa"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tasa" FilterControlAltText="Filter Tasa column" HeaderText="Tasa" SortExpression="Tasa" UniqueName="Tasa"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CodigoISIN" FilterControlAltText="Filter CodigoISIN column" HeaderText="Código ISIN" SortExpression="CodigoISIN" UniqueName="CodigoISIN"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaEmision" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter FechaEmision column" HeaderText="Fecha Emisión" SortExpression="FechaEmision" UniqueName="FechaEmision"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaVencimiento" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter FechaVencimiento column" HeaderText="Fecha Vencimiento" SortExpression="FechaVencimiento" UniqueName="FechaVencimiento"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaLiquidacion" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter FechaLiquidacion column" HeaderText="Fecha Liquidación" SortExpression="FechaLiquidacion" UniqueName="FechaLiquidacion"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoLiquidacionID" DataType="System.Int32" FilterControlAltText="Filter TipoLiquidacionID column" HeaderText="TipoLiquidacionID" SortExpression="TipoLiquidacionID" UniqueName="TipoLiquidacionID" Visible="False"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CodigoInterno" FilterControlAltText="Filter CodigoInterno column" HeaderText="Tipo Liquidación" SortExpression="CodigoInterno" UniqueName="CodigoInterno"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUnitarioNominal" DataFormatString="{0:$###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter ValorUnitarioNominal column" HeaderText="Monto" SortExpression="ValorUnitarioNominal" UniqueName="ValorUnitarioNominal"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="InversionMinima" DataFormatString="{0:$###,##0.00}" DataType="System.Decimal" FilterControlAltText="Filter InversionMinima column" HeaderText="Inversión Mínima" SortExpression="InversionMinima" UniqueName="InversionMinima"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescripcionEstatus" FilterControlAltText="Filter Estatus column" HeaderText="Estatus" SortExpression="Estatus" UniqueName="Estatus"></telerik:GridBoundColumn>

                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid></td>
                        </tr>
                        <tr>
                            <td class="style17">&#160;</td>
                            <td class="style41">
                                <asp:SqlDataSource ID="SqlEmisionTramo" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT * FROM [EmisionTramo] where EmisionID = @EmisionID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="EmisionID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                            </td>
                            <td class="style19">&#160;</td>
                            <td>
                                <asp:SqlDataSource ID="SqlEmisionSerie" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="select * from [vEmisionSerie]  es
                                            left outer join [EmisionTramo]  et on et.EmisionTramoID=es.EmisionTramoID
                                            where et.EmisionID=@EmisionID
                                            order by es.FechaEmision desc">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="EmisionID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td class="style13">&#160;</td>
                            <td class="style13">&#160;</td>
                            <td class="style39">
                                <telerik:RadWindowManager ID="RadWindowManager2" runat="server" BackColor="#F1F5FB" Behaviors="Close, Maximize, Move" EnableViewState="false" Height="300px" Modal="True" OnClientClose="RefreshGrid" VisibleStatusbar="False" Width="550px"></telerik:RadWindowManager>
                            </td>
                            <td class="style13">&nbsp;</td>
                            <td class="style13">&#160;</td>
                        </tr>
                    </table>
                    <br />
                </telerik:RadPageView>

                <%-- Documentos --%>
                <telerik:RadPageView ID="RadPageView4" runat="server" TabIndex="2" Width="923px">
                    <table class="style1">
                        <tr>
                            <td class="style5"></td>
                            <td class="style32"></td>
                            <td class="style33"></td>
                            <td class="style5"></td>
                            <td class="style5"></td>
                            <td class="style5"></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label38" runat="server" Font-Bold="False" Text="Fecha :" Width="70px"></asp:Label></td>
                            <td class="auto-style2">
                                <telerik:RadDatePicker ID="txtFechaDocumento" runat="server" Culture="en-US">
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                    <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="ValidatorFechaDocumento" runat="server" ControlToValidate="txtFechaDocumento" ErrorMessage="Fecha" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido." Width="46px">*</asp:RequiredFieldValidator><asp:Label ID="Label39" runat="server" Font-Bold="False" Text="Tipo Documento :" Width="124px"></asp:Label>&nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoDocumento" DataTextField="Nombre" DataValueField="TipoDocumentoID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="274px"></telerik:RadComboBox>
                            </td>
                            <td class="auto-style1"></td>
                            <td class="auto-style1"></td>
                            <td class="auto-style1">
                                <asp:RequiredFieldValidator ID="ValidatorTipoDocumento" runat="server" ControlToValidate="RadComboBox1" ErrorMessage="Tipo Documento" Font-Size="Small" ForeColor="Red" Height="16px" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido." Width="19px">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label40" runat="server" Font-Bold="False" Text="Nombre Documento :" Width="88px"></asp:Label></td>
                            <td class="style27">
                                <asp:TextBox ID="txtNombreDoc" runat="server" Width="214px"></asp:TextBox></td>
                            <td class="style31">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtArchivo" runat="server" Visible="False" Width="30px"></asp:TextBox></td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label33" runat="server" Font-Bold="False" Text="Archivo :" Width="70px"></asp:Label></td>
                            <td class="style27">
                                <telerik:RadUpload ID="RadUpload1" runat="server" ControlObjectsVisibility="None" EnableTheming="True" Height="25px" Width="230px">
                                    <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover" Select="Seleccionar" />
                                </telerik:RadUpload>
                                <asp:Button ID="Button2" runat="server" CausesValidation="False" Text="Subir" Width="59px" /></td>
                            <td class="style31">
                                <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Culture="es-DO" HeaderText="Información de Progreso" Width="363px">
                                    <Localization Cancel="Cancelar" CurrentFileName="Subiendo Archivo: " ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: " TotalFiles="Total Archivos: " TransferSpeed="Velocidad: " Uploaded="Cargado" UploadedFiles="Archivos Cargados:"></Localization>
                                </telerik:RadProgressArea>
                            </td>
                            <td>
                                <telerik:RadProgressManager ID="RadProgressManager1" runat="server" Width="99px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">
                                <telerik:RadGrid ID="RadGridDocumento" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" DataSourceID="SqlDocumentos" GridLines="None" PageSize="20">
                                    <ExportSettings ExportOnlyData="True" FileName="Lista de Documentos" OpenInNewWindow="True">
                                        <Pdf PageTitle="Lista de Documentos" Subject="Lista de Documentos" />
                                    </ExportSettings>
                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True" ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Lista Documentos" CommandItemDisplay="Bottom" CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="EmisionID,EmisionDocumentoID" DataSourceID="SqlDocumentos" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EmisionID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionID column" HeaderText="Emisión " ReadOnly="True" SortExpression="EmisionID" UniqueName="EmisionID"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmisionDocumentoID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionDocumentoID column" HeaderText="Documento" ReadOnly="True" SortExpression="EmisionDocumentoID" UniqueName="EmisionDocumentoID"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter Fecha column" HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="nombre" FilterControlAltText="Filter nombre column" HeaderText="Nombre" SortExpression="nombre" UniqueName="nombre"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoDocumentoID" DataType="System.Int32" FilterControlAltText="Filter TipoDocumentoID column" HeaderText="Tipo Documento " SortExpression="TipoDocumentoID" UniqueName="TipoDocumentoID" Visible="False"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreTipoDocumento" FilterControlAltText="Filter NombreTipoDocumento column" HeaderText="Tipo Documento" SortExpression="NombreTipoDocumento" UniqueName="NombreTipoDocumento"></telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn DataField="Archivo" FilterControlAltText="Filter Archivo column" HeaderText="Archivo" SortExpression="Archivo" UniqueName="Archivo">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Eval("Archivo") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="NombreDocumento" Display="False" FilterControlAltText="Filter NombreDocumento column" HeaderText="Nombre Documento" ReadOnly="True" SortExpression="NombreDocumento" UniqueName="NombreDocumento"></telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView><FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid></td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>
                            <td class="style27">
                                <asp:SqlDataSource ID="SqlTipoDocumento" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT TipoDocumentoID, Nombre, Activo FROM TipoDocumento ORDER BY Nombre"></asp:SqlDataSource>
                                <br />
                            </td>
                            <td class="style31">
                                <asp:SqlDataSource ID="SqlDocumentos" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT EmisionID, EmisionDocumentoID, Fecha, nombre, Adjunto, TipoDocumentoID, NombreDocumento, Archivo, NombreTipoDocumento FROM vEmisionDocumento WHERE (EmisionID = @EmisionID) ORDER BY Fecha DESC">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="EmisionID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                </telerik:RadPageView>

                <%-- Calificación de Riersgo --%>
                <telerik:RadPageView ID="RadPageView3" runat="server" TabIndex="2" Width="923px">
                    <table class="style1">
                        <tr>
                            <td class="style1">&#160;</td>
                            <td class="style16">&#160;</td>
                            <td class="style14">&#160;</td>
                            <td class="style17">&#160;</td>
                            <td class="style18">&#160;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label27" runat="server" Font-Bold="False" Text="Empresa Calificadora :" Width="159px"></asp:Label></td>
                            <td class="style16">
                                <telerik:RadComboBox ID="RadComboBoxEmpresaCalificadoraID" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlEmpresaCalificadora" DataTextField="Nombre" DataValueField="EmpresaCalificadoraID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="267px"></telerik:RadComboBox>
                            </td>
                            <td class="style14">
                                <asp:RequiredFieldValidator ID="ValidatorEmpresaCalificadora" runat="server" ControlToValidate="RadComboBoxEmpresaCalificadoraID" ErrorMessage="Empresa Calificadora" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido." Width="27px">*</asp:RequiredFieldValidator></td>
                            <td class="style17">&#160;</td>
                            <td class="style18">&#160;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label70" runat="server" Font-Bold="False" Text="Rango Calificación :" Width="145px"></asp:Label></td>
                            <td class="style16">
                                <telerik:RadComboBox ID="RadComboBoxRangoCalificacion" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlRangoCalificacionRiesgo" DataTextField="Nombre" DataValueField="RangoCalificacionID" EmptyMessage="Buscar..." Filter="Contains" Height="100px" Style="margin-left: 0px" Width="267px"></telerik:RadComboBox>
                            </td>
                            <td class="style14">
                                <asp:RequiredFieldValidator ID="ValidatorFechaCalificacionRiesgo" runat="server" ControlToValidate="txtFechaCalificacionRiesgo" ErrorMessage="Fecha Calificacion Riesgo" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido." Width="31px">*</asp:RequiredFieldValidator></td>
                            <td class="style17">&#160;</td>
                            <td class="style18">&#160;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label29" runat="server" Font-Bold="False" Text="Tipo Calificación :" Width="145px"></asp:Label></td>
                            <td class="style16">
                                <telerik:RadComboBox ID="RadComboBoxTipoCalificacionRiesgo" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoCalificacionRiesgoID" DataTextField="CodEnSistema" DataValueField="TipoCalificacionRiesgoID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="267px"></telerik:RadComboBox>
                            </td>
                            <td class="style14">&#160;</td>
                            <td class="style17">&#160;</td>
                            <td class="style18">&#160;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label28" runat="server" Font-Bold="False" Text="Fecha :" Width="99px"></asp:Label></td>
                            <td class="style16">
                                <telerik:RadDatePicker ID="txtFechaCalificacionRiesgo" runat="server" Culture="es-DO">
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                    <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style14">&#160;</td>
                            <td class="style17">&#160;</td>
                            <td class="style18">&#160;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label30" runat="server" Font-Bold="False" Text="Nota :" Width="83px"></asp:Label></td>
                            <td class="style16">
                                <telerik:RadTextBox ID="txtNota" runat="server" Height="71px" LabelWidth="64px" TextMode="MultiLine" Width="323px"></telerik:RadTextBox></td>
                            <td class="style14">&#160;</td>
                            <td class="style17">
                                <asp:SqlDataSource ID="SqlRangoCalificacionRiesgo" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT RangoCalificacionID, Nombre, EmpresaCalificadoraID FROM RangoCalificacion WHERE (EmpresaCalificadoraID = ISNULL(@EmpresaCalificadoraID, 0))">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="RadComboBoxEmpresaCalificadoraID" Name="EmpresaCalificadoraID" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlTipoCalificacionRiesgoID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT TipoCalificacionRiesgoID, Nombre, CodEnSistema FROM TipoCalificacionRiesgo WHERE (EmpresaCalificadoraID = ISNULL(@EmpresaCalificadoraID, 0)) AND (RangoCalificacionID = ISNULL(@RangoCalificacionID, 0))">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="RadComboBoxEmpresaCalificadoraID" Name="EmpresaCalificadoraID" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="RadComboBoxRangoCalificacion" Name="RangoCalificacionID" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlEmpresaCalificadora" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [EmpresaCalificadoraID], [Nombre] FROM [EmpresaCalificadora]"></asp:SqlDataSource>
                            </td>
                            <td class="style18">&#160;</td>
                        </tr>
                        <tr>
                            <td class="style5" colspan="5">
                                <telerik:RadGrid ID="RadGridEmisionCalificacionRiesgo" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" DataSourceID="SqlEmisionCalificacionRiesgo" GridLines="None" PageSize="20">
                                    <ExportSettings ExportOnlyData="True" FileName="Calificación de Riesgo Emisión" OpenInNewWindow="True">
                                        <Pdf PageTitle="Calificación de Riesgo Emisión" Title="Calificación de Riesgo Emisión" />
                                    </ExportSettings>
                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True" ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Calificación de Riesgo" CommandItemDisplay="Bottom" CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="EmisionCalificacionRiesgoID" DataSourceID="SqlEmisionCalificacionRiesgo" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EmisionID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionID column" HeaderText="EmisionID" SortExpression="EmisionID" UniqueName="EmisionID"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmisionCalificacionRiesgoID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionCalificacionRiesgoID column" HeaderText="EmisionCalificacionRiesgoID" ReadOnly="True" SortExpression="EmisionCalificacionRiesgoID" UniqueName="EmisionCalificacionRiesgoID"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmpresaCalificadoraID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmpresaCalificadoraID column" HeaderText="EmpresaCalificadoraID" SortExpression="EmpresaCalificadoraID" UniqueName="EmpresaCalificadoraID"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter Fecha column" HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreEmpresaCalificadora" FilterControlAltText="Filter NombreEmpresaCalificadora column" HeaderText="Empresa Calificadora" SortExpression="NombreEmpresaCalificadora" UniqueName="NombreEmpresaCalificadora"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoCalificacionRiesgoID" DataType="System.Int32" FilterControlAltText="Filter TipoCalificacionRiesgoID column" HeaderText="TipoCalificacionRiesgoID" SortExpression="TipoCalificacionRiesgoID" UniqueName="TipoCalificacionRiesgoID" Visible="False"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreTipoCalificacionRiesgo" FilterControlAltText="Filter NombreTipoCalificacionRiesgo column" HeaderText="Tipo Calificación" SortExpression="NombreTipoCalificacionRiesgo" UniqueName="NombreTipoCalificacionRiesgo"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CodEnSistema" FilterControlAltText="Filter CodEnSistema column" HeaderText="Escala" SortExpression="CodEnSistema" UniqueName="CodEnSistema"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Nota" FilterControlAltText="Filter Nota column" HeaderText="Nota" SortExpression="Nota" UniqueName="Nota" Visible="False"></telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid></td>
                        </tr>
                        <tr>
                            <td class="style1">&#160;</td>
                            <td class="style16">
                                <asp:SqlDataSource ID="SqlEmisionCalificacionRiesgo" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT EmisionID, EmisionCalificacionRiesgoID, EmpresaCalificadoraID, Fecha, TipoCalificacionRiesgoID, Nota, NombreEmpresaCalificadora, NombreTipoCalificacionRiesgo, CodEnSistema, RangoCalificacionID FROM vEmisionCalificacionRiesgo WHERE (EmisionID = @EmisionID) ORDER BY Fecha DESC">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="EmisionID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                            </td>
                            <td class="style14">&nbsp;</td>
                            <td class="style17">&nbsp;</td>
                            <td class="style18">&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                </telerik:RadPageView>

                <%--Puesto(s) de Bolsa --%>
                <telerik:RadPageView ID="RadPageView5" runat="server" TabIndex="2" Width="923px">
                    <table class="style45">
                        <tr>
                            <td class="style47">
                                <asp:Label ID="Label71" runat="server" Font-Bold="False" Text="Puesto Bolsa :" Width="137px"></asp:Label></td>
                            <td>
                                <telerik:RadComboBox ID="RadComboBoxPuestoBolsaID" runat="server" DataSourceID="SqlPuestoBolsaID" DataTextField="Nombre" DataValueField="PuestoBolsaID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="23" Width="287px"></telerik:RadComboBox>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="style47">
                                <asp:Label ID="Label72" runat="server" Text="Nota :"></asp:Label></td>
                            <td>
                                <telerik:RadTextBox ID="txtNotaPuestoBolsa" runat="server" Height="75px" TextMode="MultiLine" Width="402px"></telerik:RadTextBox></td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="style47">&#160;</td>
                            <td>&#160;</td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="style46" colspan="3">
                                <telerik:RadGrid ID="RadGridEmisionPuestoBolsa" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" DataSourceID="SqlvEmisionPuestoBolsa" GridLines="None" PageSize="20">
                                    <ExportSettings ExportOnlyData="True" FileName="Puestos Bolsa Emisión" OpenInNewWindow="True">
                                        <Pdf PageTitle="Puestos Bolsa Emisión" Title="Puestos Bolsa Emisión" />
                                    </ExportSettings>
                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True" ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Puestos Bolsa Emisión" CommandItemDisplay="Bottom" CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="EmisionPuestoBolsaID" DataSourceID="SqlvEmisionPuestoBolsa" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EmisionID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionID column" HeaderText="EmisionID" SortExpression="EmisionID" UniqueName="EmisionID"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmisionPuestoBolsaID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionPuestoBolsaID column" HeaderText="EmisionPuestoBolsaID" ReadOnly="True" SortExpression="EmisionPuestoBolsaID" UniqueName="EmisionPuestoBolsaID"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PuestoBolsa" FilterControlAltText="Filter PuestoBolsa column" HeaderText="Puesto Bolsa" SortExpression="PuestoBolsa" UniqueName="PuestoBolsa"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Nota" FilterControlAltText="Filter Nota column" HeaderText="Nota" SortExpression="Nota" UniqueName="Nota"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaID" DataType="System.Int32" Display="False" FilterControlAltText="Filter PuestoBolsaID column" HeaderText="PuestoBolsaID" SortExpression="PuestoBolsaID" UniqueName="PuestoBolsaID"></telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <PagerStyle PageSizeControlType="RadComboBox" />
                                    </MasterTableView>
                                    <PagerStyle PageSizeControlType="RadComboBox" />
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid></td>
                        </tr>
                        <tr>
                            <td class="style47">&#160;</td>
                            <td>
                                <asp:SqlDataSource ID="SqlPuestoBolsaID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [PuestoBolsaID], [Nombre] FROM [PuestoBolsa]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlvEmisionPuestoBolsa" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT * FROM [vEmisionPuestoBolsa] where EmisionID=@EmisionID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="EmisionID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <%--<td>&#160;</td>--%>
                        </tr>
                    </table>
                </telerik:RadPageView>

            </telerik:RadMultiPage>

            <%-- Declaraciones --%>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
            <asp:Label ID="InjectScript" runat="server"></asp:Label>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>

            <br />
            <br />
            <br />

        </div>

        <%-- Administracion de ventana flotante --%>
        <div>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            </telerik:RadWindowManager>
        </div>

        <%-- Ventana de Notificaciones --%>
        <div>
            <telerik:RadNotification ID="Notification1" runat="server" Position="BottomRight"
                AutoCloseDelay="5000" Width="350" Title="Información" EnableRoundedCorners="true">
            </telerik:RadNotification>
        </div>

    </form>
</body>

</html>
