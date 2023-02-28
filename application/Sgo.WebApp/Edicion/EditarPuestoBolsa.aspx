<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_EditarPuestoBolsa" CodeBehind="EditarPuestoBolsa.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <title>Edición participante</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        .style1 {
        }

        .style2 {
            width: 252px;
        }

        .style3 {
            width: 208px;
        }

        .style5 {
            height: 23px;
        }

        .style7 {
            width: 208px;
            height: 25px;
        }

        .style8 {
            width: 385px;
            height: 25px;
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

        .style30 {
            width: 202px;
            height: 25px;
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
            width: 236px;
            height: 23px;
        }

        .style35 {
            width: 31px;
            height: 23px;
        }

        .style36 {
            width: 84px;
            height: 23px;
        }

        .style37 {
            width: 369px;
            height: 23px;
        }

        .style38 {
            width: 309px;
            height: 23px;
        }

        .style40 {
            width: 309px;
        }

        .auto-style1 {
            width: 330px;
            height: 23px;
        }

        .auto-style3 {
            width: 330px;
        }

        .auto-style4 {
            width: 202px;
            height: 20px;
        }

        .auto-style5 {
            width: 385px;
            margin-left: 40px;
            height: 20px;
        }

        .auto-style6 {
            width: 208px;
            height: 20px;
        }

        .auto-style7 {
            height: 20px;
        }
    </style>
    <script type="text/javascript" id="telerikClientEvents1">

    </script>
    <script type="text/javascript" id="telerikClientEvents2">
        //<![CDATA[

        function CargarVentanaEditarCorredor(sender, args) {
            //VentanaEditar("EditarPuestoBolsaCorredor.aspx", 1300, 600, "RadAjaxManager1");
            return;
        }
        //]]>
    </script>

</head>

<body style="background-color: #F1F5FB;">

    <%-- Bloque --%>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

        <script type="text/javascript">

            function ActualizarGridListaCorredores(sender, args) {
                var masterTable = $find("<%= RadGridCorredor.ClientID%>").get_masterTableView();
                masterTable.rebind();
            }

        </script>

    </telerik:RadCodeBlock>

    <%-- JS --%>
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


    </script>

    <form id="form1" runat="server" style="background-color: #F1F5FB">


        <div>

            <%-- Ajax Manager --%>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>

            <%-- Script Manager --%>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

            <%-- Definición Opciones TABS --%>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server"
                SelectedIndex="4" MultiPageID="RadMultiPage1" CausesValidation="False"
                Width="100%">
                <Tabs>

                    <telerik:RadTab runat="server" Text="Puesto Bolsa" PageViewID="RadPageView1"
                        SelectedIndex="1">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" Text="Directivos" PageViewID="RadPageView2"
                        SelectedIndex="2">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" PageViewID="RadPageView3"
                        Text="Corredores" SelectedIndex="3" >
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" PageViewID="RadPageView4"
                        Text="Documentos" SelectedIndex="4" ToolTip ="Documentos asociados al participante">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" PageViewID="RadPageView5"
                        Text="Cod. Part. BL." SelectedIndex="5" ToolTip ="Código Participante Bloomberg" Selected="True">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" PageViewID="RadPageView6"
                        Text="Mecanismos de Negociación" SelectedIndex="6">
                    </telerik:RadTab>

                </Tabs>
            </telerik:RadTabStrip>

            <%-- ToolBar --%>
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">

                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png"
                        Text="Nuevo" ToolTip="Crear Nuevo" Value="2">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server"
                        Text="Button 4" IsSeparator="True">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Guardar" ToolTip="Guardar Información" Value="0">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" CheckOnClick="True"
                        ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="3">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" CheckOnClick="True"
                        ImageUrl="~/Images/excel.png" Text="Exportar Excel" Value="4">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Text="" IsSeparator="True">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" Enabled="false"
                        Text="Mover corredor" ToolTip="Mover el corredor a otro puesto de bolsa" Value="5">
                    </telerik:RadToolBarButton>
                </Items>

            </telerik:RadToolBar>
            <br />

            <%-- TABS --%>
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Height="16px"
                SelectedIndex="4" Width="165px">

                <%-- Datos Generales --%>
                <telerik:RadPageView ID="RadPageView1" runat="server" Width="922px" TabIndex="1">
                    <table class="style1">
                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Código (Interno) :"
                                    Width="151px"></asp:Label>
                            </td>
                            <td class="style23">
                                <telerik:RadTextBox ID="txtCodSistema" runat="server" Height="24px" LabelWidth="64px"
                                    Style="margin-left: 4px" Width="113px">
                                </telerik:RadTextBox>
                                <asp:Label ID="Guardado" runat="server" Font-Bold="True"
                                    ForeColor="Red" Width="209px"></asp:Label>
                            </td>

                            <td class="style3">
                                <%--                                <asp:RequiredFieldValidator ID="ValidatorCodigoPuestoBolsa" runat="server"
                                    ControlToValidate="txtCodSistema" ErrorMessage="Codigo" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido."
                                    Width="70px">*</asp:RequiredFieldValidator>--%>
                            </td>



                            <td>
                                <asp:TextBox ID="Codigo" runat="server" Enabled="False" ReadOnly="True"
                                    Width="61px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label41" runat="server" Text="Código (Ordenes Firme):"></asp:Label>
                                &nbsp;</td>

                            <td class="style23">
                                <telerik:RadTextBox ID="txtPuestoBolsaCodigoOrden" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="113px">
                                </telerik:RadTextBox>
                            </td>

                            <td class="style3">&nbsp;</td>
                            <td rowspan="3">
                                <telerik:RadBinaryImage ID="ImagenPuestoBolsa" runat="server" AutoAdjustImageControlSize="False" ResizeMode="Fill" Width="100px" />
                                <asp:Label ID="MensajeLogo" runat="server" Font-Bold="False" Width="242px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Nombre :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style23">
                                <telerik:RadTextBox ID="txtNombre" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="300px" MaxLength="80">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">
                                <asp:RequiredFieldValidator ID="ValidatorNombrePuestoBolsa" runat="server"
                                    ControlToValidate="txtNombre" ErrorMessage="Name" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True"
                                    ToolTip="Debe ingresar un nombre válido." Width="70px">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label9" runat="server" Font-Bold="False" Text="Dirección :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadTextBox ID="txtDireccion" runat="server" Height="52px" LabelWidth="64px"
                                    Style="margin-left: 4px" Width="388px" TextMode="MultiLine">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">
                                <asp:RequiredFieldValidator ID="ValidatorDireccionPuestoBolsa" runat="server"
                                    ControlToValidate="txtDireccion" ErrorMessage="Direccion" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido."
                                    Width="70px">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label12" runat="server" Font-Bold="False" Text="Teléfono :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadMaskedTextBox ID="txtTelefono" runat="server" Mask="(###) ###-####"
                                    Style="margin-left: 4px">
                                </telerik:RadMaskedTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                            <td class="style3">
                                <telerik:RadUpload ID="RadUpload2" runat="server" ControlObjectsVisibility="None" EnableTheming="True" Height="25px" TabIndex="22" Width="230px">
                                    <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover" Select="Seleccionar" />
                                </telerik:RadUpload>
                            </td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label13" runat="server" Font-Bold="False" Text="Email :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadTextBox ID="txtEmail" runat="server" Height="24px" LabelWidth="64px"
                                    Style="margin-left: 4px" Width="300px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                            <td class="style3">
                                <asp:Button ID="BtnSubirLogo" runat="server" CausesValidation="False" Text="Subir" Width="59px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label14" runat="server" Font-Bold="False" Text="Web :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadTextBox ID="txtWeb" runat="server" Height="24px" LabelWidth="64px"
                                    Style="margin-left: 4px" Width="300px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">Notas:</td>
                            <td class="style3" rowspan="6">
                                <telerik:RadTextBox ID="txtNota" runat="server" Height="167px" LabelWidth="64px" Style="margin-left: 4px" TextMode="MultiLine" Width="388px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label15" runat="server" Font-Bold="False" Text="RNC :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadMaskedTextBox ID="txtRNC" runat="server" Mask="#-##-#####-#"
                                    Style="margin-left: 3px">
                                </telerik:RadMaskedTextBox>
                            </td>
                            <td class="style3"></td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label16" runat="server" Font-Bold="False" Text="No. Registro BVRD :"
                                    Width="168px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadTextBox ID="txtNoRegistroBV" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="300px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label17" runat="server" Font-Bold="False" Text="No. Registro SIV :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadTextBox ID="txtNoRegistroSIV" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="300px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label18" runat="server" Font-Bold="False" Text="Representante Legal :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadTextBox ID="txtRepresentanteLegal" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="300px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label42" runat="server" Text="Presidente/Director Gral. :"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadTextBox ID="txtPresidente" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="300px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label19" runat="server" Font-Bold="False"
                                    Text="Fecha Constitución :" Width="137px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadDatePicker ID="txtFechaConstitucion" runat="server"
                                    Style="margin-left: 4px" Culture="es-DO">
                                    <Calendar UseColumnHeadersAsSelectors="False" runat="server" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy"
                                        LabelWidth="40%">
                                    </DateInput>
                                    <DatePopupButton />
                                </telerik:RadDatePicker>
                            </td>



                            <td class="style3" rowspan="4">
                                <telerik:RadProgressArea ID="RadProgressArea2" runat="server" Culture="es-DO" HeaderText="Información de Progreso" Height="220px" Width="351px">
                                    <Localization Cancel="Cancelar" CurrentFileName="Subiendo Archivo: " ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: " TotalFiles="Total Archivos: " TransferSpeed="Velocidad: " Uploaded="Cargado" UploadedFiles="Archivos Cargados:" />
                                </telerik:RadProgressArea>
                                <telerik:RadProgressManager ID="RadProgressManager2" runat="server" Width="99px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label20" runat="server" Font-Bold="False" Text="Capital Suscrito Pagado :"
                                    Width="198px"></asp:Label>
                            </td>
                            <td class="style24">
                                <telerik:RadNumericTextBox ID="txtCapitalSuscritoPagado" runat="server"
                                    Style="margin-left: 3px">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style30">
                                <asp:Label ID="Label43" runat="server" Font-Bold="False" Text="Tipo participante :" Width="126px"></asp:Label>
                            </td>
                            <td class="style8">
                                <telerik:RadComboBox ID="cbTipoParticipante" runat="server" AllowCustomText="True" CausesValidation="False" DataSourceID="SqlTipoParticipante" DataTextField="Descripcion" DataValueField="TipoParticipanteID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="250px">
                                </telerik:RadComboBox>
                                <asp:SqlDataSource ID="SqlTipoParticipante" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT * FROM [TipoParticipante]"></asp:SqlDataSource>
                                <asp:RequiredFieldValidator ID="ValidatorTipoParticipante" runat="server" ControlToValidate="cbTipoParticipante" ErrorMessage="Seleccione una opción." Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar una opción" Width="70px"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style7"></td>
                        </tr>
                        <tr>
                            <td class="style30">
                                <asp:Label ID="Label44" runat="server" Font-Bold="True" Text="Clasificación participante :" Width="174px"></asp:Label>
                            </td>
                            <td class="style8">
                                <telerik:RadComboBox ID="cbClasificacionParticipante" runat="server" AllowCustomText="True" CausesValidation="False" DataSourceID="SqlClasificacionParticipante" DataTextField="Descripcion" DataValueField="ClasificacionParticipanteID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="250px">
                                </telerik:RadComboBox>
                                <asp:SqlDataSource ID="SqlClasificacionParticipante" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT * FROM [ClasificacionParticipante] order by Descripcion"></asp:SqlDataSource>

                                <%--<asp:RequiredFieldValidator ID="ValidatorClasificacionParticipante" runat="server" ControlToValidate="cbClasificacionParticipante" ErrorMessage="Seleccione una opción." Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Debe seleccionar una opción" Width="70px"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td class="style7"></td>
                        </tr>

                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label47" runat="server" Font-Bold="False" Text="Código SIOPEL :" Width="143px"></asp:Label>
                            </td>
                            <td class="style23">
                                <telerik:RadTextBox ID="txtCodigoSiopel" runat="server" Height="24px" LabelWidth="100px" Style="margin-left: 4px" Width="113px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="Activo :" Width="70px"></asp:Label>
                            </td>
                            <td class="style23">
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <br />
                            </td>
                            <td class="style3">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4"></td>
                            <td class="auto-style5"></td>
                            <td class="auto-style6"></td>
                            <td class="auto-style7"></td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <%-- Directivos --%>
                <telerik:RadPageView ID="RadPageView2" runat="server" TabIndex="2" Width="923px">
                    <table class="style1">
                        <tr>
                            <td class="style17">&nbsp;</td>
                            <td class="style2">&nbsp;</td>
                            <td class="style19">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style13">
                                <asp:Label ID="lblMsgInfoDirectivos" runat="server" Font-Bold="True" ForeColor="Red" Width="209px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Nombre :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtNombreDirectivo" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style19">
                                <asp:RequiredFieldValidator ID="ValidatorNombreDirecctivo" runat="server"
                                    ControlToValidate="txtNombreDirectivo" ErrorMessage="Nombre" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" Font-Bold="False" Text="Email :"
                                    Width="81px"></asp:Label>
                            </td>
                            <td class="style13">
                                <telerik:RadTextBox ID="txtEmailDirectivo" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label22" runat="server" Font-Bold="False" Text="Dirección :"
                                    Width="98px"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtDireccionDirectivo" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style19">&nbsp;</td>
                            <td class="style1">
                                <asp:Label ID="Label25" runat="server" Font-Bold="False" Text="Puesto :"
                                    Width="91px"></asp:Label>
                            </td>
                            <td class="style13">
                                <telerik:RadTextBox ID="txtPuestoDirectivo" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label23" runat="server" Font-Bold="False" Text="Teléfono :"
                                    Width="94px"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadMaskedTextBox ID="txtTelefonoDirectivo" runat="server"
                                    Mask="(###) ###-####" Style="margin-left: 5px">
                                </telerik:RadMaskedTextBox>
                            </td>
                            <td class="style19">&nbsp;</td>
                            <td class="style1">
                                <asp:Label ID="Label26" runat="server" Font-Bold="False" Text="Encargado :"
                                    Width="90px"></asp:Label>
                            </td>
                            <td class="style13">
                                <asp:CheckBox ID="CheckBoxDirectivo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="5">
                                <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellSpacing="0" Culture="es-DO" DataSourceID="SqlTipoDirectivo" GridLines="None"
                                    PageSize="20" Height="355px">
                                    <ExportSettings ExportOnlyData="True" FileName="Lista de Directivos"
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Lista de Directivos" Title="Lista de Directivos" />
                                    </ExportSettings>
                                    <ClientSettings
                                        EnablePostBackOnRowClick="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Lista Directivos" CommandItemDisplay="Bottom"
                                        CommandItemSettings-ShowAddNewRecordButton="False" DataSourceID="SqlTipoDirectivo"
                                        NoMasterRecordsText="No hay información para mostrar." DataKeyNames="PuestoBolsaDirectivoID">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" ShowExportToCsvButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaID" FilterControlAltText="Filter PuestoBolsaID column"
                                                HeaderText="PuestoBolsaID" SortExpression="PuestoBolsaID" UniqueName="PuestoBolsaID"
                                                DataType="System.Int32" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaDirectivoID"
                                                FilterControlAltText="Filter PuestoBolsaDirectivoID column" HeaderText="PuestoBolsaDirectivoID"
                                                SortExpression="PuestoBolsaDirectivoID" UniqueName="PuestoBolsaDirectivoID"
                                                DataType="System.Int32" ReadOnly="True" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Nombre"
                                                FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre"
                                                UniqueName="Nombre">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Direccion"
                                                FilterControlAltText="Filter Direccion column" HeaderText="Direccion" SortExpression="Direccion"
                                                UniqueName="Direccion">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Telefono"
                                                FilterControlAltText="Filter Telefono column" HeaderText="Telefono" SortExpression="Telefono"
                                                UniqueName="Telefono">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">&nbsp;</td>
                            <td class="style2">
                                <asp:SqlDataSource ID="SqlTipoDirectivo" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT [PuestoBolsaID], [PuestoBolsaDirectivoID], [Nombre], [Direccion], [Telefono] FROM [vPuestoBolsaDirectivos] where PuestoBolsaID=@PuestoBolsaID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="PuestoBolsaID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                            </td>
                            <td class="style19">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style13">&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                </telerik:RadPageView>
                <%-- Corredores --%>
                <telerik:RadPageView ID="RadPageView3" runat="server" TabIndex="2" Width="923px">
                    <table class="style1">
                        <tr>
                            <td class="style5" colspan="7">
                                <asp:Label ID="MensajeCorredor" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style5" colspan="7">
                                <telerik:RadGrid ID="RadGridCorredor" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" DataSourceID="SqlTipoCorredores" GridLines="None" PageSize="20">
                                    <ExportSettings ExportOnlyData="True" FileName="Lista de Corredores" OpenInNewWindow="True">
                                        <Pdf PageTitle="Lista de Corredores" Title="Lista de Corredores" />
                                    </ExportSettings>
                                    <ClientSettings AllowColumnsReorder="True" EnableRowHoverStyle="false" ReorderColumnsOnClient="True" Scrolling-UseStaticHeaders="True">
                                        <Selecting AllowRowSelect="True" />
                                        <ClientEvents OnRowDblClick="CargarVentanaEditarCorredor" />
                                        <Scrolling AllowScroll="True" ScrollHeight="300px" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Lista Corredores" CommandItemDisplay="Bottom" CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="PuestoBolsaCorredorID" DataSourceID="SqlTipoCorredores" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True" ShowExportToPdfButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaID" DataType="System.Int32" FilterControlAltText="Filter PuestoBolsaID column" HeaderText="PuestoBolsaID" SortExpression="PuestoBolsaID" UniqueName="PuestoBolsaID" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaCorredorID" DataType="System.Int32" FilterControlAltText="Filter PuestoBolsaCorredorID column" HeaderText="PuestoBolsaCorredorID" ReadOnly="True" SortExpression="PuestoBolsaCorredorID" UniqueName="PuestoBolsaCorredorID" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre" UniqueName="Nombre">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Direccion" FilterControlAltText="Filter Direccion column" HeaderText="Direccion" SortExpression="Direccion" UniqueName="Direccion">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Telefono" FilterControlAltText="Filter Telefono column" HeaderText="Telefono" SortExpression="Telefono" UniqueName="Telefono">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>
                            <td class="style16">
                                <asp:SqlDataSource ID="SqlTipoCorredores" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT  P.[NuevoPuestoBolsaID] AS PuestoBolsaID, P.[PuestoBolsaCorredorID], P.[Nombre], P.[Direccion], P.[Telefono] 
                                        FROM dbo.vPuestoBolsaCorredores  AS P
                                        WHERE (P.Movimiento IN ('C','T')) 
                                        AND P.FechaMovimiento = (SELECT TOP(1) FechaMovimiento from dbo.HistorialCorredor WHERE (PuestoBolsaCorredorID =P.PuestoBolsaCorredorID ) AND (Movimiento IN ('C','T')) ORDER BY FechaMovimiento DESC) 
                                         AND  P.NuevoPuestoBolsaID=@PuestoBolsaID
                                         and p.Activo = 1
                                        ORDER BY P.Nombre DESC">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="PuestoBolsaID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                            </td>
                            <td class="style14">&nbsp;</td>
                            <td class="style17">&nbsp;</td>
                            <td class="style40">&nbsp;</td>
                            <td class="style18">&nbsp;</td>
                            <td class="style18">&nbsp;</td>
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
                            <td class="style1">
                                <asp:Label ID="Label38" runat="server" Font-Bold="True" Text="Fecha :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadDatePicker ID="txtFechaDocumento" runat="server" Culture="es-DO">
                                    <Calendar UseColumnHeadersAsSelectors="False" runat="server" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy"
                                        LabelWidth="40%">
                                    </DateInput>
                                    <DatePopupButton />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style31">
                                <asp:RequiredFieldValidator ID="ValidatorFechaDocumento" runat="server"
                                    ControlToValidate="txtFechaDocumento" ErrorMessage="Fecha" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido."
                                    Width="46px">*</asp:RequiredFieldValidator>
                                <asp:Label ID="Label39" runat="server" Font-Bold="False"
                                    Text="Tipo Documento :" Width="124px"></asp:Label>
                                &nbsp;&nbsp;
                                    <telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="True"
                                        AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoDocumento"
                                        DataTextField="Nombre" DataValueField="TipoDocumentoID"
                                        EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px"
                                        Width="282px">
                                    </telerik:RadComboBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="ValidatorTipoDocumento" runat="server"
                                    ControlToValidate="RadComboBox1" ErrorMessage="Tipo Documento" Font-Size="Small"
                                    ForeColor="Red" Height="16px" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido."
                                    Width="19px">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label40" runat="server" Font-Bold="True" Text="Descripción :"
                                    Width="88px"></asp:Label>
                            </td>
                            <td class="style27">
                                <asp:TextBox ID="txtDescripcion" runat="server" Width="214px"></asp:TextBox>
                            </td>
                            <td class="style31">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtArchivo" runat="server" Visible="False" Width="30px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label33" runat="server" Font-Bold="True" Text="Archivo :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadUpload ID="RadUpload1" runat="server" ControlObjectsVisibility="None"
                                    EnableTheming="True" Height="25px" Width="230px">
                                    <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover"
                                        Select="Seleccionar" />
                                </telerik:RadUpload>
                                <asp:Button ID="Button2" runat="server" Text="Subir"
                                    Width="59px" />
                            </td>
                            <td class="style31">
                                <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Width="363px"
                                    Culture="es-DO" HeaderText="Información de Progreso">
                                    <Localization Uploaded="Cargado" Cancel="Cancelar" CurrentFileName="Subiendo Archivo: "
                                        ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: " TotalFiles="Total Archivos: "
                                        TransferSpeed="Velocidad: " UploadedFiles="Archivos Cargados:"></Localization>
                                </telerik:RadProgressArea>
                            </td>
                            <td>
                                <telerik:RadProgressManager ID="RadProgressManager1" runat="server"
                                    Width="99px" />
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtPuestoBolsaDocumentoID" runat="server" Visible="False">
                                </telerik:RadTextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">


                                <telerik:RadGrid ID="RadGridDocumento" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" DataSourceID="SqlDocumentos"
                                    GridLines="None" PageSize="20">
                                    <ExportSettings ExportOnlyData="True" FileName="Lista de Documentos"
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Lista de Documentos" Subject="Lista de Documentos" />
                                    </ExportSettings>
                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True"
                                        ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Lista Documentos" CommandItemDisplay="Bottom"
                                        CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="PuestoBolsaID,PuestoBolsaDocumentoID"
                                        DataSourceID="SqlDocumentos" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" ShowExportToCsvButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaID" DataType="System.Int32"
                                                FilterControlAltText="Filter PuestoBolsaID column" HeaderText="PuestoBolsaID"
                                                ReadOnly="True" SortExpression="PuestoBolsaID" UniqueName="PuestoBolsaID"
                                                Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaDocumentoID"
                                                DataType="System.Int32" FilterControlAltText="Filter PuestoBolsaDocumentoID column"
                                                HeaderText="PuestoBolsaDocumentoID" ReadOnly="True" SortExpression="PuestoBolsaDocumentoID"
                                                UniqueName="PuestoBolsaDocumentoID" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" DataFormatString="{0:MM/dd/yyyy}"
                                                DataType="System.DateTime" FilterControlAltText="Filter Fecha column" HeaderText="Fecha"
                                                SortExpression="Fecha" UniqueName="Fecha">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreTipo"
                                                FilterControlAltText="Filter NombreTipo column" HeaderText="Tipo Documento"
                                                SortExpression="NombreTipo" UniqueName="NombreTipo">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Descripcion"
                                                FilterControlAltText="Filter Descripcion column" HeaderText="Descripción"
                                                SortExpression="Descripcion" UniqueName="Descripcion">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridTemplateColumn DataField="nombre"
                                                FilterControlAltText="Filter nombre column" HeaderText="Nombre" SortExpression="nombre"
                                                UniqueName="nombre">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"
                                                        Text='<%# Eval("nombre") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridBoundColumn DataField="NombreDocumento" FilterControlAltText="Filter NombreDocumento column"
                                                HeaderText="NombreDocumento" SortExpression="NombreDocumento" UniqueName="NombreDocumento"
                                                Display="False">
                                            </telerik:GridBoundColumn>




                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>




                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>
                            <td class="style27">
                                <asp:SqlDataSource ID="SqlTipoDocumento" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [TipoDocumento]"></asp:SqlDataSource>
                                <br />
                            </td>
                            <td class="style31">
                                <asp:SqlDataSource ID="SqlDocumentos" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [vPuestoBolsaDocumentos] where PuestoBolsaID= @PuestoBolsaID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="PuestoBolsaID" PropertyName="Text" />
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
                <%-- Códigos Participante --%>
                <telerik:RadPageView ID="RadPageView5" runat="server" TabIndex="2" Width="923px">

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
                            <td class="style1">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Código :"
                                    Width="88px"></asp:Label>
                            </td>
                            <td class="style27">
                                <asp:TextBox ID="txtCodigoParticipante" runat="server" Width="214px"></asp:TextBox>
                            </td>
                            <td class="style31">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtCodigoParticipanteID" runat="server" Visible="False" Width="30px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>
                            <td class="style27">&nbsp;</td>
                            <td class="style31">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">


                                <telerik:RadGrid ID="RadGridCodigoParticipantes" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlvPuestoBolsaCodigosParticipante" PageSize="20" GroupPanelPosition="Top">
                                    <GroupingSettings CollapseAllTooltip="Collapse all groups" />

                                    <ExportSettings ExportOnlyData="True" FileName="Códigos Participante"
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Códigos Participante" Subject="Códigos Participante" />
                                    </ExportSettings>

                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True"
                                        ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>

                                    <MasterTableView AllowSorting="True" Caption="Códigos Participante" CommandItemDisplay="Bottom"
                                        CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="PuestoBolsaID,CodigosParticipanteID"
                                        DataSourceID="SqlvPuestoBolsaCodigosParticipante" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" ShowExportToCsvButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>

                                            <telerik:GridBoundColumn DataField="PuestoBolsaID" DataType="System.Int32"
                                                FilterControlAltText="Filter PuestoBolsaID column" HeaderText="PuestoBolsaID"
                                                ReadOnly="True" SortExpression="PuestoBolsaID" UniqueName="PuestoBolsaID"
                                                Display="false">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="CodigosParticipanteID"
                                                DataType="System.Int32" FilterControlAltText="Filter CodigosParticipanteID column"
                                                HeaderText="CodigosParticipanteID" ReadOnly="True" SortExpression="CodigosParticipanteID"
                                                UniqueName="CodigosParticipanteID" Display="false">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="Descripcion"
                                                FilterControlAltText="Filter Descripcion column" HeaderText="Descripción[Código]"
                                                SortExpression="Descripcion" UniqueName="Descripcion">
                                            </telerik:GridBoundColumn>





                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>




                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>
                            <td class="style27">
                                <asp:SqlDataSource ID="SqlCodigosParticipante" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [CodigosParticipante]"></asp:SqlDataSource>
                                <br />
                            </td>
                            <td class="style31">
                                <asp:SqlDataSource ID="SqlvPuestoBolsaCodigosParticipante" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [vPuestoBolsaCodigosParticipante] where PuestoBolsaID= @PuestoBolsaID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="PuestoBolsaID" PropertyName="Text" />
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
                <%-- Mecanismos de Negociación --%>
                <telerik:RadPageView ID="RadPageView6" runat="server" TabIndex="2" Width="923px">

                    <table class="style1">
                        <tr>
                            <td class="style5"></td>
                            <td class="style32"></td>
                            <td class="auto-style1"></td>
                            <td class="style5"></td>
                            <td class="style5"></td>
                            <td class="style5"></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Mecanismo Negociación :"
                                    Width="182px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadComboBox ID="cbMecanismosNegociacion" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlMecanismosNegociacion" DataTextField="Descripcion" DataValueField="MecanismosNegociacionID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="250px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" Visible="False" Width="30px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label46" runat="server" Font-Bold="False" Text="Clasificación participante :" Width="174px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadComboBox ID="cbClasificacionParticipanteMecanismos" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="Sql_ClasificacionParticipante" DataTextField="Descripcion" DataValueField="ClasificacionParticipanteID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="250px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>
                            <td class="style27">&nbsp;</td>
                            <td class="auto-style3">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">


                                <telerik:RadGrid ID="RadGridMecanismosNegociacion" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlvPuestoBolsaMecanismosNegociacion" PageSize="20" GroupPanelPosition="Top" Width="1019px">
                                    <GroupingSettings CollapseAllTooltip="Collapse all groups" />

                                    <ExportSettings ExportOnlyData="True" FileName="Códigos Participante"
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Códigos Participante" Subject="Códigos Participante" />
                                    </ExportSettings>

                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True"
                                        ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>

                                    <MasterTableView AllowSorting="True" Caption="Mecanismos de Negociación" CommandItemDisplay="Bottom"
                                        CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="PuestoBolsaID,PuestoBolsaMecanismosNegociacionID"
                                        DataSourceID="SqlvPuestoBolsaMecanismosNegociacion" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" ShowExportToCsvButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>

                                            <telerik:GridBoundColumn DataField="PuestoBolsaID" DataType="System.Int32"
                                                FilterControlAltText="Filter PuestoBolsaID column" HeaderText="PuestoBolsaID"
                                                ReadOnly="True" SortExpression="PuestoBolsaID" UniqueName="PuestoBolsaID"
                                                Display="false">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="PuestoBolsaMecanismosNegociacionID"
                                                DataType="System.Int32" FilterControlAltText="Filter PuestoBolsaMecanismosNegociacionID column"
                                                HeaderText="PuestoBolsaMecanismosNegociacionID" ReadOnly="True" SortExpression="PuestoBolsaMecanismosNegociacionID"
                                                UniqueName="PuestoBolsaMecanismosNegociacionID" Display="false">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="MecanismosNegociacion"
                                                FilterControlAltText="Filter MecanismosNegociacion column" HeaderText="Mecanismo Negociación"
                                                SortExpression="MecanismosNegociacion" UniqueName="MecanismosNegociacion">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="ClasificacionParticipante"
                                                FilterControlAltText="Filter ClasificacionParticipante column" HeaderText="Clasificación Participante"
                                                SortExpression="ClasificacionParticipante" UniqueName="ClasificacionParticipante">
                                            </telerik:GridBoundColumn>

                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>




                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>

                            <td class="style27">
                                <asp:SqlDataSource ID="Sql_ClasificacionParticipante" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [ClasificacionParticipante] WHERE ([MecanismosNegociacionID] = @MecanismosNegociacionID)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cbMecanismosNegociacion" Name="MecanismosNegociacionID" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                            </td>

                            <td class="auto-style3">
                                <asp:SqlDataSource ID="SqlMecanismosNegociacion" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [MecanismosNegociacion]"></asp:SqlDataSource>
                                <br />
                            </td>

                            <td class="style31">
                                <asp:SqlDataSource ID="SqlvPuestoBolsaMecanismosNegociacion" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [vPuestoBolsaMecanismosNegociacion] where PuestoBolsaID= @PuestoBolsaID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="PuestoBolsaID" PropertyName="Text" />
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

            </telerik:RadMultiPage>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
            <asp:Label ID="InjectScript" runat="server"></asp:Label>
            <br />
            <br />
            <br />

        </div>

        <%-- Windows Manager --%>
        <div>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableViewState="False" OnClientClose="ActualizarGridListaCorredores">
            </telerik:RadWindowManager>
        </div>

        <div></div>

    </form>
</body>

</html>
