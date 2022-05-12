<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Edicion_EditarSeriePOPUP" CodeBehind="EditarSeriePOPUP.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<%-- Encabezado --%>
<head runat="server">

    <title>Emisión</title>

    <%-- Include(s) --%>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/OpenWindows.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <%-- Estilos --%>
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
            width: 233px;
            height: 24px;
        }

        .auto-style10 {
            height: 133px;
        }

        .auto-style11 {
            width: 185px;
        }

        .auto-style14 {
            width: 233px;
            height: 42px;
        }

        .auto-style15 {
            width: 419px;
            height: 42px;
        }

        .auto-style16 {
            width: 245px;
            height: 20px;
        }

        .auto-style17 {
            width: 419px;
            height: 20px;
        }

        .auto-style18 {
            width: 192px;
            height: 20px;
        }

        .auto-style19 {
            width: 185px;
            height: 20px;
        }

        .auto-style20 {
            height: 20px;
        }

        .auto-style21 {
            width: 233px;
            height: 27px;
        }

        .auto-style22 {
            width: 419px;
            height: 27px;
        }

        .auto-style24 {
            width: 270px;
        }

        .auto-style25 {
            width: 47px;
        }

        .auto-style26 {
            width: 233px;
        }

        .auto-style27 {
            width: 154px;
        }

        .auto-style29 {
            width: 213px;
        }

        .auto-style30 {
            width: 157px;
        }

        .auto-style31 {
            width: 233px;
            height: 26px;
        }

        .auto-style32 {
            width: 419px;
            height: 26px;
        }

        .auto-style33 {
            width: 192px;
            height: 26px;
        }

        .auto-style34 {
            height: 26px;
        }

        .auto-style35 {
            width: 152px;
        }

        .auto-style36 {
            width: 257px;
        }

        .auto-style37 {
            width: 211px;
        }

        .auto-style38 {
            width: 152px;
            height: 20px;
        }

        .auto-style39 {
            width: 257px;
            height: 20px;
        }

        .auto-style40 {
            width: 211px;
            height: 20px;
        }

        .auto-style41 {
            width: 233px;
            height: 36px;
        }

        .auto-style42 {
            width: 419px;
            height: 36px;
        }

        .auto-style43 {
            width: 192px;
            height: 36px;
        }

        .auto-style44 {
            height: 36px;
        }

        .auto-style45 {
            width: 404px;
            height: 36px;
        }

        .auto-style46 {
            width: 152px;
            height: 19px;
        }

        .auto-style47 {
            width: 257px;
            height: 19px;
        }

        .auto-style48 {
            width: 211px;
            height: 19px;
        }

        .auto-style49 {
            height: 19px;
        }
    </style>

</head>

<body style="background-color: #F1F5FB;">


    <form id="form1" runat="server">

        <%-- Funciones Js --%>
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


            <%-- TAB Manager --%>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server"
                SelectedIndex="0" MultiPageID="RadMultiPage1" CausesValidation="False"
                Width="100%"> 
                <Tabs> 
                    <telerik:RadTab runat="server" Text="Datos Emisión" PageViewID="Pagina1"
                        SelectedIndex="1" Selected="True">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" Text="Incrementos" PageViewID="Pagina2"
                        SelectedIndex="2">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" Text="Redenciones" PageViewID="Pagina3"
                        SelectedIndex="3">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" Text="Amortizaciones" PageViewID="Pagina4"
                        SelectedIndex="4">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" Text="Titularizado" PageViewID="Pagina5"
                        SelectedIndex="5">
                    </telerik:RadTab>


                </Tabs>

            </telerik:RadTabStrip>


            <%-- ToolBar --%>
            <telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="all" DecorationZoneID="decorationZone"></telerik:RadFormDecorator>

            <div id="decorationZone">
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">

                    <Items>


                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png"
                            Text="Nuevo" ToolTip="Crear Nuevo" Value="3" CausesValidation="False" Visible="False">
                        </telerik:RadToolBarButton>


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

            <br />

            <%-- Botón nuevo, solo debe ser visible en el TAB de Incrementos --%>

            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Height="16px"
                SelectedIndex="0" Width="165px">

                <%--Datos Generales --%>
                <telerik:RadPageView ID="Pagina1" runat="server" Selected="True" TabIndex="1" Width="922px">
                    <%-- Datos Emisión --%>

                    <table class="style1">

                        <tr>
                            <td class="auto-style26">
                                <asp:Label ID="Label1" runat="server" Text="Serie :" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style3" colspan="2">
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
                            <td class="style4">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style41">
                                <asp:Label ID="Label2" runat="server" Text="Nemotécnico :" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style42">
                                <telerik:RadTextBox ID="CodigoSerie" runat="server" Width="206px"
                                    MaxLength="20" TabIndex="2">
                                </telerik:RadTextBox>
                            </td>
                            <td class="auto-style45">
                                <telerik:RadButton ID="ActualizarNemo" CausesValidation="false" runat="server" Style="top: 0px; left: 0px;" Text="..." Image-ImageUrl="~/Images/refresh.png" Height="16px" Width="64px"
                                    click="ActualizarNemo_Click">
                                </telerik:RadButton>
                            </td>
                            <td class="auto-style43"></td>
                            <td colspan="2" class="auto-style44">
                                <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Fechas"
                                    Style="text-align: center" Width="287px"></asp:Label>
                                <hr />
                            </td>
                            <td class="auto-style44"></td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Label ID="Label6" runat="server" Text="Codigo ISIN :"></asp:Label>
                            </td>
                            <td class="auto-style4" colspan="2">
                                <telerik:RadTextBox ID="CodigoISIN" runat="server" Width="250px" MaxLength="20"
                                    TabIndex="3">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style7">&nbsp;</td>
                            <td class="style7">
                                <asp:Label ID="Label7" runat="server" Text="Emisión :"></asp:Label>
                            </td>
                            <td class="style8">
                                <telerik:RadDatePicker ID="FechaEmision" runat="server" TabIndex="19"
                                    Culture="es-DO">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="19"
                                        runat="server">
                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                        <FocusedStyle Resize="None"></FocusedStyle>

                                        <DisabledStyle Resize="None"></DisabledStyle>

                                        <InvalidStyle Resize="None"></InvalidStyle>

                                        <HoveredStyle Resize="None"></HoveredStyle>

                                        <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>

                                    <DatePopupButton TabIndex="19"></DatePopupButton>
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style8">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Label ID="Label5" runat="server" Text="Tipo tasa :" Width="95px" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style4" colspan="2">
                                <telerik:RadComboBox ID="RadComboBoxIdTipotasa" runat="server" AllowCustomText="True"
                                    AutoPostBack="True" CausesValidation="False" DataSourceID="SqlDataSourceTipoTasa"
                                    DataTextField="Descripcion" DataValueField="idTipotasa"
                                    EmptyMessage="Buscar..." Filter="Contains"
                                    Width="250px" TabIndex="4">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style7">
                                <asp:RequiredFieldValidator ID="ValidatorIdTipotasa" runat="server"
                                    ControlToValidate="RadComboBoxTipoPeriodoID"
                                    ErrorMessage="Tipo tasa" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar un tipo de tasa válido."
                                    Width="21px">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style7">
                                <asp:Label ID="Label8" runat="server" Text="Vencimiento :"></asp:Label>
                            </td>
                            <td class="style8">
                                <telerik:RadDatePicker ID="FechaVencimiento" runat="server" TabIndex="20"
                                    Culture="es-DO" Style="margin-bottom: 0px">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="20"
                                        runat="server">
                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                        <FocusedStyle Resize="None"></FocusedStyle>

                                        <DisabledStyle Resize="None"></DisabledStyle>

                                        <InvalidStyle Resize="None"></InvalidStyle>

                                        <HoveredStyle Resize="None"></HoveredStyle>

                                        <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>

                                    <DatePopupButton TabIndex="20"></DatePopupButton>
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style8">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style26">
                                <asp:Label ID="Label11" runat="server" Text="Tasa :"></asp:Label>
                            </td>
                            <td class="auto-style3" colspan="2">
                                <telerik:RadNumericTextBox ID="txtTasa" runat="server" Culture="en-US"
                                    DbValueFactor="1" LabelWidth="64px" TabIndex="5" Type="Percent"
                                    Width="160px">
                                    <NumberFormat ZeroPattern="n %" DecimalDigits="4"></NumberFormat>
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="ValidatorTasa" runat="server"
                                    ControlToValidate="txtTasa"
                                    ErrorMessage="Tasa "
                                    ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar una tasa ."
                                    Width="21px">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style4">
                                <asp:Label ID="Label4" runat="server" Text="Tipo Liquidación :" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="RadComboBoxTipoLiquidacionID"
                                    runat="server" AllowCustomText="True"
                                    AutoPostBack="True" CausesValidation="False" DataSourceID="SqlDataSourceTipoLiquidacion"
                                    DataTextField="CodigoInterno" DataValueField="TipoLiquidacionID"
                                    EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px"
                                    Width="250px" TabIndex="21">
                                </telerik:RadComboBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style26">
                                <asp:Label ID="Label58" runat="server" Text="Spread :"></asp:Label>
                            </td>
                            <td class="auto-style3" colspan="2">
                                <telerik:RadNumericTextBox ID="txtSpread" runat="server" Culture="en-US"
                                    DbValueFactor="1" LabelWidth="64px" TabIndex="6" Type="Percent"
                                    Width="160px">
                                    <NumberFormat ZeroPattern="n %" DecimalDigits="4"></NumberFormat>
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style4">&nbsp;</td>
                            <td class="style4">
                                <asp:Label ID="Label3" runat="server" Text="Liquidación :" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="FechaLiquidacion" runat="server" TabIndex="22"
                                    Culture="es-DO">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="22"
                                        runat="server">
                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                        <FocusedStyle Resize="None"></FocusedStyle>

                                        <DisabledStyle Resize="None"></DisabledStyle>

                                        <InvalidStyle Resize="None"></InvalidStyle>

                                        <HoveredStyle Resize="None"></HoveredStyle>

                                        <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>

                                    <DatePopupButton TabIndex="22"></DatePopupButton>
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
                            <td class="auto-style26">
                                <asp:Label ID="Label12" runat="server" Text="Periodicidad  :" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style3" colspan="2">
                                <telerik:RadComboBox ID="RadComboBoxTipoPeriodoID"
                                    runat="server" AllowCustomText="True"
                                    AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoPeriodo"
                                    DataTextField="Nombre" DataValueField="TipoPeriodoID"
                                    EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px"
                                    Width="250px" TabIndex="7">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style4"></td>
                            <td class="style4">
                                <asp:Label ID="Label16" runat="server" Text="Inicio Colocación :" Width="122px"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="FechaInicioColocacion" runat="server" TabIndex="23"
                                    Culture="es-DO">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="23"
                                        runat="server">
                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                        <FocusedStyle Resize="None"></FocusedStyle>

                                        <DisabledStyle Resize="None"></DisabledStyle>

                                        <InvalidStyle Resize="None"></InvalidStyle>

                                        <HoveredStyle Resize="None"></HoveredStyle>

                                        <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>

                                    <DatePopupButton TabIndex="23"></DatePopupButton>
                                </telerik:RadDatePicker>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style26">
                                <asp:Label ID="Label57" runat="server" Font-Bold="True"
                                    Text="Base Liquidación :" Width="139px"></asp:Label>
                            </td>
                            <td class="auto-style3" colspan="2">
                                <telerik:RadComboBox ID="RadcomboBoxBaseLiquidacion" runat="server"
                                    DataSourceID="SqlBaseLiquidacion" DataTextField="Nombre"
                                    DataValueField="BaseLiquidacionID" EmptyMessage="Buscar..."
                                    Filter="Contains" TabIndex="8" Width="250px" CausesValidation="False"
                                    Culture="es-DO" AllowCustomText="True" AutoPostBack="True" Style="margin-bottom: 0">
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
                            <td class="style4">
                                <asp:Label ID="Label17" runat="server" Text="Final Colocación :"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="FechaFinalColocacion" runat="server" TabIndex="24"
                                    Culture="es-DO">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="24"
                                        runat="server">
                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                        <FocusedStyle Resize="None"></FocusedStyle>

                                        <DisabledStyle Resize="None"></DisabledStyle>

                                        <InvalidStyle Resize="None"></InvalidStyle>

                                        <HoveredStyle Resize="None"></HoveredStyle>

                                        <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>

                                    <DatePopupButton TabIndex="24"></DatePopupButton>
                                </telerik:RadDatePicker>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style26">
                                <asp:Label ID="Label9" runat="server" Text="Monto Serie :"
                                    Width="131px"></asp:Label>
                            </td>
                            <td class="auto-style3" colspan="2">
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
                            <td class="style4">
                                <asp:Label ID="Label62" runat="server" Text="Fecha de Redención :"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="FechaRedencion" runat="server" TabIndex="25"
                                    Culture="es-DO">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="25"
                                        runat="server">
                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                        <FocusedStyle Resize="None"></FocusedStyle>

                                        <DisabledStyle Resize="None"></DisabledStyle>

                                        <InvalidStyle Resize="None"></InvalidStyle>

                                        <HoveredStyle Resize="None"></HoveredStyle>

                                        <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>

                                    <DatePopupButton TabIndex="25"></DatePopupButton>
                                </telerik:RadDatePicker>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style26">
                                <asp:Label ID="Label60" runat="server" Text="Valor Nominal Unitario:"
                                    Width="153px"></asp:Label>
                            </td>
                            <td class="auto-style3" colspan="2">
                                <telerik:RadNumericTextBox ID="txtValorNominalUnitarioSerie" runat="server"
                                    TabIndex="10" AutoPostBack="True">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style4">
                                <asp:RequiredFieldValidator ID="ValidatorBaseLiquidacion" runat="server"
                                    ControlToValidate="RadcomboBoxBaseLiquidacion"
                                    ErrorMessage="Base Liquidación" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar una Base de Liquidación válido."
                                    Width="21px">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style4">
                                <asp:Label ID="Label63" runat="server" Text="Monto de Redención :"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="ValorRedencion" runat="server"
                                    TabIndex="26">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style31">
                                <asp:Label ID="Label61" runat="server" Text="Cantidad de títulos:"
                                    Width="131px"></asp:Label>
                            </td>
                            <td class="auto-style32" colspan="2">
                                <telerik:RadNumericTextBox ID="txtCantidadTitulos" runat="server"
                                    TabIndex="11">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="auto-style33"></td>
                            <td class="auto-style33">
                                <asp:Label ID="Label64" runat="server" Text="Nota de Redención :"></asp:Label>
                            </td>

                            <td rowspan="3">
                                <telerik:RadTextBox ID="txtNotaRedencionx" runat="server" Height="54px" LabelWidth="64px" TabIndex="27" TextMode="MultiLine" Width="211px">
                                </telerik:RadTextBox>
                            </td>

                            <td class="auto-style34"></td>
                        </tr>
                        <tr>
                            <td class="auto-style26">
                                <asp:Label ID="Label13" runat="server" Text="Inversión Mínima :"></asp:Label>
                            </td>
                            <td class="auto-style3" colspan="2">
                                <telerik:RadNumericTextBox ID="InversionMinima" runat="server" TabIndex="12">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style4">&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style26">
                                <asp:Label ID="Label10" runat="server" Text="Inversión Máxima :"></asp:Label>
                            </td>
                            <td class="auto-style3" colspan="2">
                                <telerik:RadNumericTextBox ID="InversionMaxima" runat="server" TabIndex="13">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style4">&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Label ID="Label65" runat="server" Text="Monto Máximo Día(IG):"></asp:Label>
                            </td>
                            <td class="auto-style15" colspan="2">
                                <telerik:RadNumericTextBox ID="InversionMaximaIG" runat="server" TabIndex="14">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="auto-style10" rowspan="2" colspan="2">
                                <fieldset>
                                    <legend><b>Fechas Colocación IP</b></legend>
                                    <label>Inicial:&nbsp;</label>
                                    <telerik:RadDatePicker ID="FechaInicioColocacionIP" runat="server" TabIndex="28"
                                        Culture="es-DO">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="28"
                                            runat="server">
                                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                            <FocusedStyle Resize="None"></FocusedStyle>

                                            <DisabledStyle Resize="None"></DisabledStyle>

                                            <InvalidStyle Resize="None"></InvalidStyle>

                                            <HoveredStyle Resize="None"></HoveredStyle>

                                            <EnabledStyle Resize="None"></EnabledStyle>
                                        </DateInput>

                                        <DatePopupButton TabIndex="28"></DatePopupButton>
                                    </telerik:RadDatePicker>
                                    <div>
                                        &nbsp;
                                    </div>
                                    <label>Final:&nbsp;</label>
                                    <telerik:RadDatePicker ID="FechaFinalColocacionIP" runat="server" TabIndex="29"
                                        Culture="es-DO">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="29"
                                            runat="server">
                                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                            <FocusedStyle Resize="None"></FocusedStyle>

                                            <DisabledStyle Resize="None"></DisabledStyle>

                                            <InvalidStyle Resize="None"></InvalidStyle>

                                            <HoveredStyle Resize="None"></HoveredStyle>

                                            <EnabledStyle Resize="None"></EnabledStyle>
                                        </DateInput>

                                        <DatePopupButton TabIndex="29"></DatePopupButton>
                                    </telerik:RadDatePicker>
                                    <div>
                                        &nbsp;
                                    </div>
                                </fieldset>

                            </td>
                            <td class="auto-style10" rowspan="2">
                                <fieldset style="width: 150px;">
                                    <legend><b>Fechas Colocación IG</b></legend>
                                    <label>Inicial:&nbsp;</label>
                                    <telerik:RadDatePicker ID="FechaInicioColocacionIG" runat="server" TabIndex="30"
                                        Culture="es-DO">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="30"
                                            runat="server">
                                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                            <FocusedStyle Resize="None"></FocusedStyle>

                                            <DisabledStyle Resize="None"></DisabledStyle>

                                            <InvalidStyle Resize="None"></InvalidStyle>

                                            <HoveredStyle Resize="None"></HoveredStyle>

                                            <EnabledStyle Resize="None"></EnabledStyle>
                                        </DateInput>

                                        <DatePopupButton TabIndex="30"></DatePopupButton>
                                    </telerik:RadDatePicker>
                                    <div>
                                        &nbsp;
                                    </div>
                                    <label>Final:&nbsp;</label>
                                    <telerik:RadDatePicker ID="FechaFinalColocacionIG" runat="server" TabIndex="31"
                                        Culture="es-DO">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="31"
                                            runat="server">
                                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                            <FocusedStyle Resize="None"></FocusedStyle>

                                            <DisabledStyle Resize="None"></DisabledStyle>

                                            <InvalidStyle Resize="None"></InvalidStyle>

                                            <HoveredStyle Resize="None"></HoveredStyle>

                                            <EnabledStyle Resize="None"></EnabledStyle>
                                        </DateInput>

                                        <DatePopupButton TabIndex="31"></DatePopupButton>
                                    </telerik:RadDatePicker>
                                    <div>
                                        &nbsp;
                                    </div>
                                </fieldset>
                            </td>

                            <td class="auto-style10" rowspan="2"></td>
                        </tr>
                        <tr>
                            <td class="auto-style21">
                                <asp:Label ID="Label66" runat="server" Text="Cantidad Días Máximo(IG)"></asp:Label>
                            </td>
                            <td class="auto-style22" colspan="2">
                                <telerik:RadComboBox ID="RadComboBoxDiasInversionMaximaIG"
                                    runat="server" AllowCustomText="True"
                                    AutoPostBack="True" CausesValidation="False"
                                    DataTextField="CodigoInterno" DataValueField="TipoLiquidacionID"
                                    EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px"
                                    Width="156px" TabIndex="15" Height="16px">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="1" Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="2" Value="2" />
                                        <telerik:RadComboBoxItem runat="server" Text="3" Value="3" />
                                        <telerik:RadComboBoxItem runat="server" Text="4" Value="4" />
                                        <telerik:RadComboBoxItem runat="server" Text="5" Value="5" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                    </table>
                    <table class="style1">
                        <tr>
                            <td class="auto-style27">
                                <asp:Label ID="Label49" runat="server" Font-Bold="False" Text="Tipo Amortización :" Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style24">
                                <telerik:RadComboBox ID="RadComboBoxTipoAmortizacionCapitalID" runat="server" DataSourceID="SqlTipoAmortizacionCapitalID" DataTextField="Nombre" DataValueField="TipoAmortizacionCapitalID" EmptyMessage="Buscar..." Filter="Contains" TabIndex="16" Width="205px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="auto-style25">&nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="Label68" runat="server" Font-Bold="True" Text="Cálculo de Comisión"
                                    Style="text-align: center" Width="366px"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style27" rowspan="2">
                                <asp:Label ID="Label67" runat="server" Font-Bold="False" Text="Nota Amortización :" Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style24" rowspan="2">
                                <telerik:RadTextBox ID="txtNotaTipoAmortizacionCapital" runat="server" Height="54px" LabelWidth="64px" TabIndex="17" TextMode="MultiLine" Width="234px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="auto-style25" rowspan="2">&nbsp;</td>
                            <td class="auto-style30">Monto Base Comisión :</td>
                            <td class="auto-style29">
                                <telerik:RadNumericTextBox ID="MontoBaseParaComision" runat="server"
                                    TabIndex="32">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td rowspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style30">Fecha Hasta Monto Base:</td>
                            <td class="auto-style29">
                                <telerik:RadDatePicker ID="FechaMontoBase" runat="server" TabIndex="33"
                                    Culture="es-DO">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" runat="server"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="33"
                                        runat="server">
                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                        <FocusedStyle Resize="None"></FocusedStyle>

                                        <DisabledStyle Resize="None"></DisabledStyle>

                                        <InvalidStyle Resize="None"></InvalidStyle>

                                        <HoveredStyle Resize="None"></HoveredStyle>

                                        <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>

                                    <DatePopupButton TabIndex="33"></DatePopupButton>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style27">
                                <asp:Label ID="Label75" runat="server" Font-Bold="False" Text="Estatus :" Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style24">
                                <telerik:RadComboBox ID="cbEstatus" runat="server" DataSourceID="SqlEmisionEstatus" DataTextField="Descripcion" DataValueField="CodigoEstatus" EmptyMessage="Buscar..." Filter="Contains" TabIndex="16" Width="205px">
                                </telerik:RadComboBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="cbEstatus"
                                    ErrorMessage="Estatus" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar un estatus válido."
                                    Width="21px">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style25">&nbsp;</td>
                            <td class="auto-style30">&nbsp;</td>
                            <td class="auto-style29">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style27">
                                <asp:Label ID="Label76" runat="server" Font-Bold="False" Text="Índice Conversión:" Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style24">
                                <telerik:RadComboBox ID="cbIndiceConversionLiquidacion" runat="server" DataTextField="Descripcion" DataValueField="CodigoEstatus" EmptyMessage="Buscar..." Filter="Contains" TabIndex="16" ToolTip="Índice Conversión para liquidación" Width="205px">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="0-No Asignado" Value="0" />
                                        <telerik:RadComboBoxItem runat="server" Text="1-Tasa Compra" Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="2-Tasa Venta" Value="2" />
                                        <telerik:RadComboBoxItem runat="server" Text="3-TIPP" Value="3" />
                                        <telerik:RadComboBoxItem runat="server" Text="4-Tasa Promedio Ultimos 10 C/V" Value="4" />
                                        <telerik:RadComboBoxItem runat="server" Text="5-Tasa Promedio Ultima C/V" Value="5" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
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
                            <td class="auto-style25">&nbsp;</td>
                            <td class="auto-style30">&nbsp;</td>
                            <td class="auto-style29">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table class="style1">

                        <tr>
                            <td class="auto-style16"></td>
                            <td class="auto-style17"></td>
                            <td class="auto-style18"></td>
                            <td class="auto-style19"></td>
                            <td class="auto-style20"></td>
                            <td class="auto-style20"></td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td class="auto-style11">
                                <asp:Label ID="Guardado" runat="server" Font-Bold="True"
                                    ForeColor="Red" Width="130px"></asp:Label>
                            </td>
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
                                <asp:SqlDataSource ID="SqlTipoAmortizacionCapitalID" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT [TipoAmortizacionCapitalID], [Nombre] FROM [TipoAmortizacionCapital] ORDER BY [Nombre]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlEmisionEstatus" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT [EmisionEstatusID] ,RTRIM([CodigoEstatus]) as CodigoEstatus ,RTRIM([Descripcion]) as Descripcion ,[MostrarEnEdicion] ,[Activo] FROM [dbo].[EmisionEstatus]  ORDER BY [Descripcion]"></asp:SqlDataSource>
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
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>

                </telerik:RadPageView>

                <%--Montos--%>
                <telerik:RadPageView ID="Pagina2" runat="server" TabIndex="2" Width="922px">
                    <div>

                        <%-- Encabezado --%>
                        <table class="style1">
                            <tr>
                                <td class="auto-style35">
                                    <asp:Label ID="InjectScriptLabelIncrem" runat="server"></asp:Label>
                                    <asp:Label ID="Label73" runat="server" Text="Cantidad Cuotas :"></asp:Label>
                                </td>

                                <td class="auto-style36">
                                    <telerik:RadNumericTextBox ID="txtCantidadCuotas" runat="server" AutoPostBack="True">
                                    </telerik:RadNumericTextBox>
                                </td>

                                <td class="auto-style37">
                                    <asp:Label ID="Label74" runat="server" Height="16px" Text="Precio :" Width="122px"></asp:Label>
                                </td>

                                <td>

                                    <telerik:RadNumericTextBox ID="txtPrecio" runat="server" AutoPostBack="True" DataType="System.Decimal">
                                        <NumberFormat ZeroPattern="n" DecimalDigits="6"></NumberFormat>
                                    </telerik:RadNumericTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style35">
                                    <asp:Label ID="Label69" runat="server" Text="Monto Incremento:"></asp:Label>
                                </td>
                                <td class="auto-style36">
                                    <telerik:RadNumericTextBox ID="txtMonto" runat="server" Enabled="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style37">
                                    <asp:Label ID="Label70" runat="server" Text="Inicio Colocación :" Width="122px"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="FechaInicioColocacionMonto" runat="server" Culture="es-DO" TabIndex="23">
                                        <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="23">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton TabIndex="23" />
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label72" runat="server" Text="Vencimiento :"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <telerik:RadDatePicker ID="FechaVencimientoMonto" runat="server" Culture="es-DO" Style="margin-bottom: 0px" TabIndex="20">
                                        <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="20">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton TabIndex="20" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td class="auto-style40">
                                    <asp:Label ID="Label71" runat="server" Text="Final Colocación :"></asp:Label>
                                </td>
                                <td class="auto-style20">
                                    <telerik:RadDatePicker ID="FechaFinalColocacionMonto" runat="server" Culture="es-DO" TabIndex="24">
                                        <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="24">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton TabIndex="24" />
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style38">&nbsp;</td>
                                <asp:TextBox ID="Codigo" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="35px"></asp:TextBox>
                                <td class="auto-style39">&nbsp;</td>
                                <td class="auto-style40">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                        </table>

                        <%-- Grid --%>
                        <div>

                            <telerik:RadGrid ID="RadGridIncrementoMonto" runat="server" AllowSorting="True" AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlEmisionSerieMonto" PageSize="20" GroupPanelPosition="Top">

                                <ExportSettings ExportOnlyData="True" FileName="Incrementos de Monto Emisión" OpenInNewWindow="True">
                                    <Pdf PageTitle="Incrementos de Monto Emisión" Title="Incrementos de Monto Emisión" />

                                </ExportSettings>

                                <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True" ReorderColumnsOnClient="True">
                                    <Selecting AllowRowSelect="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>

                                <MasterTableView AllowSorting="True" Caption="Incrementos de Monto Emisión" CommandItemDisplay="TopAndBottom" CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="EmisionSerieMontoID" DataSourceID="SqlEmisionSerieMonto" NoMasterRecordsText="No hay información para mostrar.">
                                    <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>

                                    <Columns>

                                        <%-- ID's --%>

                                        <telerik:GridBoundColumn DataField="EmisionSerieID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionSerieID column" HeaderText="EmisionSerieID" SortExpression="EmisionSerieID" UniqueName="EmisionSerieID"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EmisionSerieMontoID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionSerieMontoID column" HeaderText="EmisionSerieMontoID" ReadOnly="True" SortExpression="EmisionSerieMontoID" UniqueName="EmisionSerieMontoID"></telerik:GridBoundColumn>

                                        <%-- Montos --%>

                                        <telerik:GridBoundColumn DataField="CantidadCuotas" FilterControlAltText="Filter CantidadCuotas column" HeaderText="Cantidad Cuotas" SortExpression="CantidadCuotas" UniqueName="CantidadCuotas"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Precio" FilterControlAltText="Filter Precio column" HeaderText="Precio" SortExpression="Precio" UniqueName="Precio" DataFormatString="{0:###,##0.000000}"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Monto" FilterControlAltText="Filter Monto column" HeaderText="Monto" SortExpression="Monto" UniqueName="Monto"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TasaVenta" FilterControlAltText="Filter TasaVenta column" HeaderText="Tasa de Día" SortExpression="TasaVenta" UniqueName="TasaVenta" DataFormatString="{0:###,##0.0000}"></telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="Simbolo" FilterControlAltText="Filter Simbolo column" HeaderText="Símbolo" SortExpression="Simbolo" UniqueName="Simbolo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MontoEquivalentePesos" FilterControlAltText="Filter MontoEquivalentePesos column" HeaderText="Valor en RD$" SortExpression="MontoEquivalentePesos" UniqueName="MontoEquivalentePesos"></telerik:GridBoundColumn>

                                        <%-- Fechas --%>

                                        <telerik:GridBoundColumn DataField="FechaInicioColocacion" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter FechaInicioColocacion column" HeaderText="Fecha Inicio Colocación" SortExpression="FechaInicioColocacion" UniqueName="FechaInicioColocacion"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FechaFinalColocacion" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter FechaFinalColocacion column" HeaderText="Fecha Final Colocación" SortExpression="FechaFinalColocacion" UniqueName="FechaFinalColocacion"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FechaVencimiento" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter FechaVencimiento column" HeaderText="Fecha Vencimiento" SortExpression="FechaVencimiento" UniqueName="FechaVencimiento"></telerik:GridBoundColumn>


                                    </Columns>

                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>

                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>

                            </telerik:RadGrid>

                            <div>

                                <asp:SqlDataSource ID="SqlEmisionSerieMonto" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT EmisionSerieID, EmisionSerieMontoID, Monto, FechaInicioColocacion, FechaFinalColocacion, FechaVencimiento, CantidadCuotas, Precio, TasaVenta, MontoEquivalentePesos, Simbolo FROM vEmisionSerieMonto WHERE (EmisionSerieID = @EmisionSerieID) ORDER BY FechaInicioColocacion DESC">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="EmisionSerieID" QueryStringField="EmisionSerieID" />
                                    </SelectParameters>
                                </asp:SqlDataSource>


                            </div>


                        </div>

                    </div>
                </telerik:RadPageView>

                <%-- Redenciones --%>
                <telerik:RadPageView ID="Pagina3" runat="server" TabIndex="3" Width="922px">

                    <div>

                        <%-- Encabezado --%>
                        <table class="style1">
                            <tr>
                                <td class="auto-style35">
                                    <asp:Label ID="Label20" runat="server" Text="Fecha Redención:"></asp:Label>
                                </td>
                                <td class="auto-style36">
                                    <telerik:RadDatePicker ID="txtFechaRedencion" runat="server" Culture="es-DO" Style="margin-bottom: 0px" TabIndex="20">
                                        <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="20">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton TabIndex="20" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td class="auto-style37">
                                    <asp:Label ID="Label21" runat="server" Text="Nota de Redención :" Width="122px"></asp:Label>
                                </td>
                                <td rowspan="2">
                                    <telerik:RadTextBox ID="txtNotaRedencion" runat="server" Height="54px" LabelWidth="64px" TabIndex="27" TextMode="MultiLine" Width="211px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label22" runat="server" Text="Monto :"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <telerik:RadNumericTextBox ID="txtValorRedencion" runat="server" Enabled="False" AutoPostBack="True">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style40">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label80" runat="server" Text="Dias S/Redención:"></asp:Label>
                                </td>
                                <asp:TextBox ID="TextBox1" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="35px"></asp:TextBox>
                                <td class="auto-style39">
                                    <telerik:RadNumericTextBox ID="txtDiasSinRedencion" runat="server" Enabled="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style40">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label81" runat="server" Text="Dias C/Redención :"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <telerik:RadNumericTextBox ID="txtDiasConRedencion" runat="server" Enabled="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style40">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label82" runat="server" Text="Monto D/Redención :"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <telerik:RadNumericTextBox ID="txtMontoDespuesRedencion" runat="server" Enabled="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style40">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                        </table>

                        <%-- Grid --%>
                        <div>

                            <telerik:RadGrid ID="RadGridEmisionSerieRedencion" runat="server" AllowSorting="True" AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlEmisionSerieMonto" PageSize="20" GroupPanelPosition="Top">

                                <ExportSettings ExportOnlyData="True" FileName="Redenciones Emisión" OpenInNewWindow="True">
                                    <Pdf PageTitle="Redenciones Emisión" Title="Redenciones Emisión" />

                                </ExportSettings>

                                <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True" ReorderColumnsOnClient="True">
                                    <Selecting AllowRowSelect="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>

                                <MasterTableView AllowSorting="True" Caption="Redenciones Emisión" CommandItemDisplay="TopAndBottom" CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="EmisionSerieRedencionID" DataSourceID="SqlEmisionSerieRedencion" NoMasterRecordsText="No hay información para mostrar.">
                                    <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>

                                    <Columns>

                                        <%-- ID's --%>

                                        <telerik:GridBoundColumn DataField="EmisionSerieID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionSerieID column" HeaderText="EmisionSerieID" SortExpression="EmisionSerieID" UniqueName="EmisionSerieID"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EmisionSerieRedencionID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionSerieRedencionID column" HeaderText="EmisionSerieRedencionID" ReadOnly="True" SortExpression="EmisionSerieRedencionID" UniqueName="EmisionSerieRedencionID"></telerik:GridBoundColumn>

                                        <%-- Montos --%>

                                        <telerik:GridBoundColumn DataField="ValorRedencion" FilterControlAltText="Filter ValorRedencion column" HeaderText="Valor Redención" SortExpression="ValorRedencion" UniqueName="ValorRedencion"></telerik:GridBoundColumn>


                                        <%-- Fechas --%>

                                        <telerik:GridBoundColumn DataField="FechaRedencion" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter FechaRedencion column" HeaderText="Fecha Redención" SortExpression="FechaRedencion" UniqueName="FechaRedencion"></telerik:GridBoundColumn>

                                        <%-- Valores Calculados --%>

                                        <telerik:GridBoundColumn DataField="DiasSinRedencion" FilterControlAltText="Filter DiasSinRedencion column" HeaderText="Dias S/Redención" SortExpression="DiasSinRedencion" UniqueName="DiasSinRedencion"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DiasConRedencion" FilterControlAltText="Filter DiasConRedencion column" HeaderText="Dias C/Redención" SortExpression="DiasConRedencion" UniqueName="DiasConRedencion"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MontoDespuesRedencion" FilterControlAltText="Filter MontoDespuesRedencion column" HeaderText="Monto D/Redención" SortExpression="MontoDespuesRedencion" UniqueName="MontoDespuesRedencion"></telerik:GridBoundColumn>


                                        <%-- Nota(s) --%>

                                        <telerik:GridBoundColumn DataField="NotaRedencion" FilterControlAltText="Filter NotaRedencion column" HeaderText="Nota(S) Redención" SortExpression="ValorRedencion" UniqueName="ValorRedencion"></telerik:GridBoundColumn>


                                    </Columns>

                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>

                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>

                            </telerik:RadGrid>

                            <div>

                                <asp:SqlDataSource ID="SqlEmisionSerieRedencion" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT EmisionSerieRedencionID, EmisionSerieID, FechaRedencion, NotaRedencion, ValorRedencion, DiasSinRedencion, DiasConRedencion, MontoDespuesRedencion FROM dbo.EmisionSerieRedencion WHERE (EmisionSerieID = @EmisionSerieID) ORDER BY FechaRedencion DESC">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="EmisionSerieID" QueryStringField="EmisionSerieID" />
                                    </SelectParameters>
                                </asp:SqlDataSource>


                            </div>

                        </div>

                    </div>

                </telerik:RadPageView>

                <%-- Amortizaciones --%>
                <telerik:RadPageView ID="Pagina4" runat="server" TabIndex="4" Width="922px">
                    <div>

                        <%-- Encabezado --%>
                        <table class="style1">
                            <tr>
                                <td class="auto-style35">
                                    <asp:Label ID="Label14" runat="server" Text="Fecha Amortización:"></asp:Label>
                                </td>
                                <td class="auto-style36">
                                    <telerik:RadDatePicker ID="txtFechaAmortizacion" runat="server" Culture="es-DO" Style="margin-bottom: 0px" TabIndex="20">
                                        <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="20">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton TabIndex="20" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td class="auto-style37">
                                    <asp:Label ID="Label18" runat="server" Text="Nota  Amortización :" Width="122px"></asp:Label>
                                </td>
                                <td rowspan="2">
                                    <telerik:RadTextBox ID="txtNotaAmortizacion" runat="server" Height="54px" LabelWidth="64px" TabIndex="27" TextMode="MultiLine" Width="211px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label19" runat="server" Text="Monto :"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <telerik:RadNumericTextBox ID="txtValorAmortizacion" runat="server" Enabled="False" AutoPostBack="True" Height="22px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style40"></td>
                            </tr>
                            <tr>
                                <td class="auto-style46">
                                    <asp:Label ID="Label77" runat="server" Text="Dias S/Amortización :"></asp:Label>
                                </td>
                                <asp:TextBox ID="TextBox2" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="35px"></asp:TextBox>
                                <td class="auto-style47">
                                    <telerik:RadNumericTextBox ID="txtDiasSinAmortizacion" runat="server" Enabled="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style48"></td>
                                <td class="auto-style49"></td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label78" runat="server" Text="Dias C/Amortización :"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <telerik:RadNumericTextBox ID="txtDiasConAmortizacion" runat="server" Enabled="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style40"></td>
                                <td class="auto-style20"></td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label79" runat="server" Text="Monto D/Amortización :"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <telerik:RadNumericTextBox ID="txtMontoDespuesAmortizacion" runat="server" Enabled="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style40">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                        </table>

                        <%-- Grid --%>
                        <div>

                            <telerik:RadGrid ID="RadGridAmortizaciones" runat="server" AllowSorting="True" AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlEmisionSerieAmortizacion" PageSize="20" GroupPanelPosition="Top">

                                <GroupingSettings CollapseAllTooltip="Collapse all groups" />

                                <ExportSettings ExportOnlyData="True" FileName="Amortizaciones Emisión" OpenInNewWindow="True">
                                    <Pdf PageTitle="Amortizaciones Emisión" Title="Amortizaciones Emisión" />

                                </ExportSettings>

                                <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True" ReorderColumnsOnClient="True">
                                    <Selecting AllowRowSelect="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>

                                <MasterTableView AllowSorting="True" Caption="Amortizaciones Emisión" CommandItemDisplay="TopAndBottom" CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="EmisionSerieAmortizacionID" DataSourceID="SqlEmisionSerieAmortizacion" NoMasterRecordsText="No hay información para mostrar.">
                                    <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>

                                    <Columns>

                                        <%-- ID's --%>

                                        <telerik:GridBoundColumn DataField="EmisionSerieID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionSerieID column" HeaderText="EmisionSerieID" SortExpression="EmisionSerieID" UniqueName="EmisionSerieID"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EmisionSerieAmortizacionID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionSerieAmortizacionID column" HeaderText="EmisionSerieAmortizacionID" ReadOnly="True" SortExpression="EmisionSerieAmortizacionID" UniqueName="EmisionSerieAmortizacionID"></telerik:GridBoundColumn>

                                        <%-- Montos --%>

                                        <telerik:GridBoundColumn DataField="ValorAmortizacion" FilterControlAltText="Filter ValorAmortizacion column" HeaderText="Valor Amortización" SortExpression="ValorRedencion" UniqueName="ValorRedencion"></telerik:GridBoundColumn>


                                        <%-- Fechas --%>

                                        <telerik:GridBoundColumn DataField="FechaAmortizacion" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter FechaAmortizacion column" HeaderText="Fecha Amortización" SortExpression="FechaAmortizacion" UniqueName="FechaAmortizacion"></telerik:GridBoundColumn>


                                        <%-- Valores Calculados --%>

                                        <telerik:GridBoundColumn DataField="DiasSinAmortizacion" FilterControlAltText="Filter DiasSinAmortizacion column" HeaderText="Dias S/Amortización" SortExpression="DiasSinAmortizacion" UniqueName="DiasSinAmortizacion"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DiasConAmortizacion" FilterControlAltText="Filter DiasConAmortizacion column" HeaderText="Dias C/Amortización" SortExpression="DiasConAmortizacion" UniqueName="DiasConAmortizacion"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MontoDespuesAmortizacion" FilterControlAltText="Filter MontoDespuesAmortizacion column" HeaderText="Monto D/Amortización" SortExpression="MontoDespuesAmortizacion" UniqueName="MontoDespuesAmortizacion"></telerik:GridBoundColumn>



                                        <%-- Nota(s) --%>

                                        <telerik:GridBoundColumn DataField="NotaAmortizacion" FilterControlAltText="Filter NotaRedencion column" HeaderText="Nota(S) Amortización" SortExpression="ValorAmortizacion" UniqueName="ValorAmortizacion"></telerik:GridBoundColumn>


                                    </Columns>

                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>

                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>

                            </telerik:RadGrid>

                            <div>

                                <asp:SqlDataSource ID="SqlEmisionSerieAmortizacion"
                                    runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT EmisionSerieAmortizacionID, EmisionSerieID, FechaAmortizacion, ValorAmortizacion, NotaAmortizacion, DiasSinAmortizacion, DiasConAmortizacion, MontoDespuesAmortizacion FROM vEmisionSerieAmortizacion WHERE (EmisionSerieID = @EmisionSerieID) ORDER BY FechaAmortizacion">

                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="EmisionSerieID" QueryStringField="EmisionSerieID" />
                                    </SelectParameters>

                                </asp:SqlDataSource>


                            </div>

                        </div>

                    </div>
                </telerik:RadPageView>

                <%-- Titularizado --%>
                <telerik:RadPageView ID="Pagina5" runat="server" TabIndex="5" Width="922px">
                    <div>

                        <%-- Encabezado --%>
                        <table class="style1">
                            <tr>
                                <td class="auto-style35">
                                    <asp:Label ID="Label23" runat="server" Text="Fecha Titularizado:"></asp:Label>
                                </td>
                                <td class="auto-style36">
                                    <telerik:RadDatePicker ID="txtFechaTitularizado" runat="server" Culture="es-DO" Style="margin-bottom: 0px" TabIndex="20">
                                        <Calendar runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="20">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton TabIndex="20" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td class="auto-style37">
                                    <asp:Label ID="Label24" runat="server" Text="Nota   :" Width="122px"></asp:Label>
                                </td>
                                <td rowspan="2">
                                    <telerik:RadTextBox ID="txtNotaTitularizado" runat="server" Height="54px" LabelWidth="64px" TabIndex="27" TextMode="MultiLine" Width="211px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label25" runat="server" Text="Monto :"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <telerik:RadNumericTextBox ID="txtValorTitularizado" runat="server" Enabled="False">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="auto-style40">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style20" colspan="4"></td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label40" runat="server" Font-Bold="False" Text="Nombre Documento :" Width="137px"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <asp:TextBox ID="txtNombreDoc" runat="server" Width="214px"></asp:TextBox>
                                </td>
                                <td class="auto-style40"></td>
                                <td class="auto-style20"></td>
                            </tr>
                            <tr>
                                <td class="auto-style38">
                                    <asp:Label ID="Label33" runat="server" Font-Bold="False" Text="Archivo :" Width="70px"></asp:Label>
                                </td>
                                <td class="auto-style39">
                                    <telerik:RadUpload ID="RadUpload1" runat="server" ControlObjectsVisibility="None" EnableTheming="True" Height="25px" Width="230px">
                                        <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover" Select="Seleccionar" />
                                    </telerik:RadUpload>
                                </td>
                                <td class="auto-style37" rowspan="6">
                                    <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Culture="es-DO" HeaderText="Información de Progreso" Width="363px">
                                        <Localization Cancel="Cancelar" CurrentFileName="Subiendo Archivo: " ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: " TotalFiles="Total Archivos: " TransferSpeed="Velocidad: " Uploaded="Cargado" UploadedFiles="Archivos Cargados:" />
                                    </telerik:RadProgressArea>
                                </td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style38">&nbsp;</td>
                                <td class="auto-style39">
                                    <asp:Button ID="Button2" runat="server" CausesValidation="False" Text="Subir" Width="59px" />
                                </td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style38">&nbsp;</td>
                                <asp:TextBox ID="TextBox3" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="35px"></asp:TextBox>
                                <td class="auto-style39">&nbsp;</td>
                                <td class="auto-style20">
                                    <telerik:RadProgressManager ID="RadProgressManager1" runat="server" Width="99px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style38">&nbsp;</td>
                                <td class="auto-style39">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style38">&nbsp;</td>
                                <td class="auto-style39">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style38">&nbsp;</td>
                                <td class="auto-style39">&nbsp;</td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                        </table>

                        <%-- Grid --%>
                        <div>

                            <telerik:RadGrid ID="RadGridEmisionSerieTitularizado" runat="server" AllowSorting="True" AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlEmisionSerieTitularizado" PageSize="20" GroupPanelPosition="Top">

                                <ExportSettings ExportOnlyData="True" FileName="Titularizados Emisión" OpenInNewWindow="True">
                                    <Pdf PageTitle="Titularizados Emisión" Title="Titularizados Emisión" />

                                </ExportSettings>

                                <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True" ReorderColumnsOnClient="True">
                                    <Selecting AllowRowSelect="True" />
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>

                                <MasterTableView AllowSorting="True" Caption="Titularizados Emisión" CommandItemDisplay="TopAndBottom" CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="EmisionSerieTitularizadoID" DataSourceID="SqlEmisionSerieTitularizado" NoMasterRecordsText="No hay información para mostrar.">
                                    <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>

                                    <Columns>

                                        <%-- ID's --%>

                                        <telerik:GridBoundColumn DataField="EmisionSerieID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionSerieID column" HeaderText="EmisionSerieID" SortExpression="EmisionSerieID" UniqueName="EmisionSerieID"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EmisionSerieTitularizadoID" DataType="System.Int32" Display="false" FilterControlAltText="Filter EmisionSerieTitularizadoID column" HeaderText="EmisionSerieTitularizadoID" ReadOnly="True" SortExpression="EmisionSerieTitularizadoID" UniqueName="EmisionSerieTitularizadoID"></telerik:GridBoundColumn>

                                        <%-- Montos --%>

                                        <telerik:GridBoundColumn DataField="ValorTitularizado" FilterControlAltText="Filter ValorTitularizado column" HeaderText="Valor Titularizado" SortExpression="ValorTitularizado" UniqueName="ValorTitularizado"></telerik:GridBoundColumn>


                                        <%-- Fechas --%>

                                        <telerik:GridBoundColumn DataField="FechaTitularizado" DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" FilterControlAltText="Filter FechaTitularizado column" HeaderText="Fecha Titularizado" SortExpression="FechaTitularizado" UniqueName="FechaTitularizado"></telerik:GridBoundColumn>

                                        <%-- Para Abrir Documento --%>

                                        <telerik:GridTemplateColumn DataField="Archivo" FilterControlAltText="Filter Archivo column" HeaderText="Archivo" SortExpression="Archivo" UniqueName="Archivo">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Eval("Archivo") %>' OnClientClick="LinkButton1_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <%-- Nota(s) --%>

                                        <telerik:GridBoundColumn DataField="NotaTitularizado" FilterControlAltText="Filter NotaTitularizado column" HeaderText="Nota(S) Titularizado" SortExpression="NotaTitularizado" UniqueName="NotaTitularizado"></telerik:GridBoundColumn>


                                        <%-- Nombre Archivo --%>

                                        <telerik:GridBoundColumn DataField="Nombre" Display="false" FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre" UniqueName="Nombre"></telerik:GridBoundColumn>


                                    </Columns>

                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>

                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>

                            </telerik:RadGrid>

                            <div>

                                <asp:SqlDataSource ID="SqlEmisionSerieTitularizado" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT EmisionSerieTitularizadoID, EmisionSerieID, FechaTitularizado, ValorTitularizado, NotaTitularizado, Nombre, Adjunto, Archivo FROM vEmisionSerieTitularizado WHERE (EmisionSerieID = @EmisionSerieID) ORDER BY FechaTitularizado DESC">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="EmisionSerieID" QueryStringField="EmisionSerieID" />
                                    </SelectParameters>
                                </asp:SqlDataSource>


                            </div>

                        </div>

                    </div>
                </telerik:RadPageView>


            </telerik:RadMultiPage>


        </div>

        <%-- Nota(s) --%>
        <div>
            <telerik:RadNotification ID="Notification1" runat="server" Position="BottomRight"
                AutoCloseDelay="4000" Width="350" Title="Información"
                EnableRoundedCorners="true" ContentIcon="deny" EnableShadow="True"
                Opacity="95" RenderMode="Lightweight" TitleIcon="warning" Animation="Fade">
            </telerik:RadNotification>
        </div>


    </form>

</body>
</html>
