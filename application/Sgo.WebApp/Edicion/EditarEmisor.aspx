<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Edicion_EditarEmisor" CodeBehind="EditarEmisor.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Emisor</title>

    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        .style1 {
            height: 28px;
            width: 876px;
        }

        .style2 {
            width: 89px;
        }

        .style3 {
        }

        .style4 {
            width: 89px;
        }

        .style5 {
            height: 23px;
        }

        .style32 {
            width: 434px;
            height: 23px;
        }

        .style33 {
            width: 420px;
            height: 23px;
        }

        .style27 {
            width: 434px;
        }

        .style31 {
            width: 420px;
        }



        .style17 {
        }

        .style19 {
            width: 8px;
        }

        .style13 {
            width: 433px;
        }

        .style34 {
            height: 23px;
            width: 10px;
        }

        .style35 {
            width: 10px;
        }

        .style36 {
            width: 968px;
        }

        .style37 {
            height: 28px;
            width: 968px;
        }

        .style38 {
            width: 850px;
        }

        .style39 {
            height: 28px;
            width: 850px;
        }

        .style41 {
            height: 140px;
        }

        .auto-style1 {
            width: 84px;
            height: 23px;
        }

        .auto-style2 {
            width: 89px;
            height: 23px;
        }

        .auto-style3 {
            width: 8px;
            height: 23px;
        }

        .auto-style4 {
            width: 433px;
            height: 23px;
        }

        .auto-style5 {
            width: 968px;
            height: 23px;
        }

        .auto-style6 {
            width: 762px;
        }

        .auto-style7 {
            height: 140px;
            width: 762px;
        }

        .auto-style8 {
            height: 28px;
            width: 762px;
        }

        .auto-style9 {
            height: 33px;
        }

        .auto-style10 {
            width: 762px;
            height: 33px;
        }

        .auto-style11 {
            width: 850px;
            height: 33px;
        }

        .auto-style12 {
            width: 89px;
            height: 33px;
        }
    </style>
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

        function confirmCallbackFunction(args) {
            if (args) {
                clickCalledAfterRadconfirm = true;
                lastClickedItem.click();
            }
            else
                clickCalledAfterRadconfirm = false;
            lastClickedItem = null;
        }




    </script>


    <script type="text/javascript" id="telerikClientEvents1">

    </script>

    <form id="form1" runat="server" style="background-color: #F1F5FB">
        <div>


            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

            <telerik:RadTabStrip ID="RadTabStrip1" runat="server"
                SelectedIndex="0" MultiPageID="RadMultiPage1" CausesValidation="False"
                Width="100%">
                <Tabs>
                    <telerik:RadTab runat="server" Text="Emisor" PageViewID="RadPageView1"
                        SelectedIndex="1" Selected="True">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Documentos" PageViewID="RadPageView2"
                        SelectedIndex="2">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" PageViewID="RadPageView3"
                        Text="Calificaciones Riesgo" SelectedIndex="3">
                    </telerik:RadTab>

                    <telerik:RadTab runat="server" PageViewID="RadPageView4" Text="Historico de Cambios" SelectedIndex="4">
                    </telerik:RadTab>

                </Tabs>
            </telerik:RadTabStrip>


            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                <Items>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" Text="Nuevo"
                        ToolTip="Crear Nuevo" Value="2" CausesValidation="False">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 5">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Guardar" ToolTip="Guardar Información" Value="0"
                        CausesValidation="False">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 6">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="3" CausesValidation="False" />

                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Separador">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False">
                    </telerik:RadToolBarButton>

                </Items>
            </telerik:RadToolBar>


            <br />
            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Height="16px"
                SelectedIndex="0" Width="165px">
                <telerik:RadPageView ID="RadPageView1" runat="server" Width="922px" TabIndex="1" Selected="True">
                    <table class="style1">
                        <tr>
                            <td class="style28">&nbsp;</td>
                            <td class="auto-style6" colspan="3">&nbsp;</td>
                            <td class="style38">&nbsp;</td>
                            <td class="style2">
                                <asp:TextBox ID="Codigo" runat="server" Enabled="False" ReadOnly="True"
                                    Width="61px" Visible="False" TabIndex="22"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True"
                                    Text="Código (Interno) :" Width="151px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadTextBox ID="txtCodEmisorBVRD" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="113px" MaxLength="20">
                                </telerik:RadTextBox>
                                <asp:Label ID="Guardado" runat="server" Font-Bold="True" ForeColor="Red"
                                    Width="209px"></asp:Label>
                            </td>
                            <td class="style38">
                                <asp:RequiredFieldValidator ID="ValidatorCodigo" runat="server"
                                    ControlToValidate="txtCodEmisorBVRD" ErrorMessage="Codigo" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True"
                                    ToolTip="Debe ingresar un nombre válido." Width="27px">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label12" runat="server" Font-Bold="False" Text="Teléfono :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadMaskedTextBox ID="txtTelefonoEmisor" runat="server"
                                    Mask="(###) ###-####" TabIndex="9">
                                </telerik:RadMaskedTextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Nombre :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadTextBox ID="txtNombreEmisor" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" Width="374px" TabIndex="1" MaxLength="100">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style38">
                                <asp:RequiredFieldValidator ID="ValidatorNombre" runat="server"
                                    ControlToValidate="txtNombreEmisor" ErrorMessage="Name" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True"
                                    ToolTip="Debe ingresar un nombre válido." Width="34px">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label17" runat="server" Font-Bold="False"
                                    Text="No. Registro SIV :" Width="137px"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtNoRegistroSIV" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-bottom: 0px;"
                                    Width="300px" TabIndex="10" MaxLength="20">
                                </telerik:RadTextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label61" runat="server" Font-Bold="False" Text="Descripción :"
                                    Width="151px"></asp:Label>
                            </td>
                            <td class="auto-style8" colspan="3">&nbsp;<telerik:RadTextBox ID="txtDescripcionEmisor" runat="server" Height="33px"
                                TextMode="MultiLine" Width="374px" TabIndex="2">
                            </telerik:RadTextBox>
                            </td>
                            <td class="style39"></td>
                            <td class="style4">
                                <asp:Label ID="Label60" runat="server" Font-Bold="False" Text="Email :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="style1">
                                <telerik:RadTextBox ID="txtEmail" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-bottom: 0px;"
                                    Width="300px" TabIndex="11" MaxLength="100">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style1"></td>
                        </tr>

                        <tr>

                            <td class="auto-style9">
                                <asp:Label ID="Label45" runat="server" Font-Bold="False"
                                    Text="Código (Operaciones)  :" Width="151px"></asp:Label>
                            </td>

                            <td class="auto-style10">
                                <telerik:RadTextBox ID="txtCodEnSistema" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" TabIndex="3" Width="113px">
                                </telerik:RadTextBox>


                            </td>

                            
                            <td class="auto-style10">
                                <asp:Label ID="Label2" runat="server" Font-Bold="False"
                                    Text="Abreviatura :" Width="100px"></asp:Label>
                            </td>

                            <td class="auto-style10">
                               <telerik:RadTextBox ID="txtCodigoCorto" runat="server" Height="24px"
                                    LabelWidth="64px" Style="margin-left: 4px" TabIndex="3" Width="80px" MaxLength="5">
                                </telerik:RadTextBox>
                            </td>




                            <td class="auto-style11"></td>

                            <td class="auto-style12">
                                <asp:Label ID="Label14" runat="server" Font-Bold="False" Text="Web :"
                                    Width="137px"></asp:Label>
                            </td>

                            <td class="auto-style9">
                                <telerik:RadTextBox ID="txtWeb" runat="server" Height="24px" LabelWidth="64px"
                                    Style="margin-bottom: 0px;" Width="300px" TabIndex="12" MaxLength="100">
                                </telerik:RadTextBox>
                            </td>

                            <td class="auto-style9"></td>
                        </tr>


                        <tr>
                            <td class="style28">
                                <asp:Label ID="Label15" runat="server" Font-Bold="False" Text="RNC :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadMaskedTextBox ID="txtRNC" runat="server" Mask="#-##-#####-#"
                                    Style="margin-left: 3px" TabIndex="4">
                                </telerik:RadMaskedTextBox>
                            </td>
                            <td class="style38">
                                <asp:RequiredFieldValidator ID="ValidatorDireccion" runat="server"
                                    ControlToValidate="txtDireccion" ErrorMessage="Direccion" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True"
                                    ToolTip="Debe ingresar un nombre válido." Width="28px">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label19" runat="server" Font-Bold="False"
                                    Text="Fecha Constitución :" Width="140px"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="txtFechaConstitucion" runat="server"
                                    TabIndex="13" Culture="es-DO" MinDate="1800-01-01">
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x" runat="server">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                        LabelWidth="40%" TabIndex="13" runat="server">
                                    </DateInput>
                                    <DatePopupButton TabIndex="13"
                                        ToolTip="Seleccionar Calendario." />
                                </telerik:RadDatePicker>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label46" runat="server" Font-Bold="False" Text="Dirección :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style8" colspan="3">
                                <telerik:RadTextBox ID="txtDireccion" runat="server" Height="52px"
                                    LabelWidth="64px" TabIndex="5" TextMode="MultiLine"
                                    Width="374px" MaxLength="100">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style39"></td>
                            <td class="style4">
                                <asp:Label ID="Label42" runat="server" Text="Presidente :"></asp:Label>
                            </td>
                            <td class="style1">
                                <telerik:RadTextBox ID="txtPresidente" runat="server" Height="24px"
                                    LabelWidth="64px" Width="300px" TabIndex="14" MaxLength="100">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style1">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label47" runat="server" Font-Bold="False"
                                    Text="Nombre Edificio :" Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadTextBox ID="txtNombreEdificio" runat="server" Height="24px"
                                    LabelWidth="64px" TabIndex="6" Width="300px" MaxLength="50">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style4">
                                <asp:Label ID="Label54" runat="server" Font-Bold="False"
                                    Text="Capital Suscrito Pagado :" Width="198px"></asp:Label>
                            </td>
                            <td class="style3">
                                <telerik:RadNumericTextBox ID="txtCapitalSuscritoPagado" runat="server"
                                    TabIndex="15">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label48" runat="server" Font-Bold="False" Text="Casa Apto No :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadTextBox ID="txtCasaAptoNo" runat="server" Height="24px"
                                    LabelWidth="64px" TabIndex="7" Width="300px" MaxLength="50">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style4">
                                <asp:Label ID="Label55" runat="server" Font-Bold="False" Text="Fecha Ingreso :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="style3">

                                <telerik:RadDatePicker ID="txtFechaIngreso" runat="server" TabIndex="16"
                                    Culture="es-DO">
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x" runat="server">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                        LabelWidth="40%" TabIndex="16" runat="server">
                                    </DateInput>
                                    <DatePopupButton TabIndex="16"
                                        ToolTip="Seleccionar Calendario." />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label49" runat="server" Font-Bold="False" Text="Piso :"
                                    Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadTextBox ID="txtPiso" runat="server" Height="24px" LabelWidth="64px"
                                    Style="margin-left: 0px" TabIndex="8" Width="113px" MaxLength="20">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style4" rowspan="4">
                                <asp:Label ID="Label56" runat="server" Font-Bold="False" Text="Foto:"
                                    Width="137px"></asp:Label>
                            </td>
                            <td rowspan="4">
                                <telerik:RadBinaryImage ID="ImagenEmisor" runat="server" AutoAdjustImageControlSize="False" ResizeMode="Fill" Width="100px" />
                                <asp:Label ID="MensajeLogo" runat="server" Font-Bold="False" Width="242px"></asp:Label>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label51" runat="server" Font-Bold="False" Text="Pais :" Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadComboBox ID="RadComboBoxPais" runat="server" AutoPostBack="true" CausesValidation="False" Culture="es-DO" DataSourceID="SQLPais" DataTextField="Nombre" DataValueField="PaisID" Filter="Contains" MarkFirstMatch="True" Sort="Ascending" TabIndex="9" Width="295px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label52" runat="server" Font-Bold="False" Text="Ciudad :" Width="137px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadComboBox ID="RadComboBoxCiudad" runat="server" DataSourceID="SqlCiudad" DataTextField="Nombre" DataValueField="CiudadID" Filter="Contains" TabIndex="10" Width="295px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label59" runat="server" Font-Bold="False" Text="Tipo Emisor :" Width="148px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadComboBox ID="RadComboBoxTipoEmisor" runat="server" Culture="es-DO" DataSourceID="SqlTipoEmisor" DataTextField="Nombre" DataValueField="TipoEmisorID" Filter="Contains" TabIndex="11" Width="295px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label73" runat="server" Font-Bold="False" Text="Tipo Entidad:" Width="148px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadComboBox ID="RadComboBoxTipoEntidad" runat="server" Culture="es-DO" DataTextField="Nombre" DataValueField="TipoEntidadID" Filter="Contains" TabIndex="11" Width="295px" DataSourceID="SqlTipoEntidad">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td class="style3">
                                <telerik:RadUpload ID="RadUpload1" runat="server" ControlObjectsVisibility="None" EnableTheming="True" Height="25px" TabIndex="17" Width="230px">
                                    <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover" Select="Seleccionar" />
                                </telerik:RadUpload>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label71" runat="server" Font-Bold="False" Text="Sector :" Width="141px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadComboBox ID="RadComboBoxSector" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlActividadEconomica" DataTextField="Nombre" DataValueField="ActividadEconomicaID" EmptyMessage="Buscar..." Filter="Contains" Height="100px" TabIndex="12" Width="295px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td class="style3">
                                <asp:Button ID="BtnSubirLogo" runat="server" Text="Subir" Width="59px" CausesValidation="False" />
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">
                                <asp:Label ID="Label72" runat="server" Font-Bold="False" Text="Actividad Económica :" Width="141px"></asp:Label>
                            </td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadComboBox ID="RadComboBoxActividadEconomica" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlSector" DataTextField="Nombre" DataValueField="SectorID" EmptyMessage="Buscar..." Filter="Contains" Height="100px" TabIndex="13" Width="295px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style4">
                                <asp:Label ID="Label57" runat="server" Font-Bold="False" Text="Estatus :" Width="70px"></asp:Label>
                            </td>
                            <td class="style3">
                                <telerik:RadComboBox ID="RadComboBoxEstatus" runat="server" Style="margin-bottom: 3px" TabIndex="23">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Activo" Value="Activo" />
                                        <telerik:RadComboBoxItem runat="server" Text="Inactivo" Value="Inactivo" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">Código SIMV Entidad :</td>
                            <td class="auto-style6" colspan="3">
                                <telerik:RadTextBox ID="txtCodigoSIMVEntidad" runat="server" Height="24px" LabelWidth="64px" MaxLength="20" Style="margin-left: 0px" TabIndex="24" Width="289px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style38">&nbsp;</td>
                            <td class="style4">Código SIMV Fondo</td>
                            <td class="style3">
                                <telerik:RadTextBox ID="txtCodigoSIMVFondo" runat="server" Height="24px" LabelWidth="64px" MaxLength="20" Style="margin-left: 0px" TabIndex="25" Width="289px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">&nbsp;</td>
                            <td class="auto-style6" colspan="3">&nbsp;</td>
                            <td class="style38">&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style41">
                                <asp:SqlDataSource ID="SQLPais" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT [PaisID], [Nombre] FROM [Pais] ORDER BY [Nombre]"></asp:SqlDataSource>
                            </td>
                            <td class="auto-style7" colspan="3">
                                <asp:SqlDataSource ID="SqlTipoEmisor" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [TipoEmisor]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlCiudad" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT CiudadID, Nombre, PaisID FROM Ciudad WHERE (PaisID = @PaisID)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="RadComboBoxPais" Name="PaisID"
                                            PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlActividadEconomica" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [ActividadEconomica] WHERE ([Activo] = @Activo)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="True" Name="Activo" Type="Boolean" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlSector" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT [SectorID], [Nombre], [ActividadEconomicaID] FROM [Sector] WHERE ([ActividadEconomicaID] = @ActividadEconomicaID)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="RadComboBoxSector" Name="ActividadEconomicaID"
                                            PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <asp:SqlDataSource ID="SqlTipoEntidad" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT * FROM [TipoEntidad] ORDER BY [Nombre]"></asp:SqlDataSource>
                            </td>
                            <td class="style3" colspan="2" rowspan="2">&nbsp;</td>
                            <td class="style41">
                                <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Culture="es-DO"
                                    HeaderText="Información de Progreso" Height="220px" Width="351px">
                                    <Localization Cancel="Cancelar" CurrentFileName="Subiendo Archivo: "
                                        ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: "
                                        TotalFiles="Total Archivos: " TransferSpeed="Velocidad: " Uploaded="Cargado"
                                        UploadedFiles="Archivos Cargados:" />
                                </telerik:RadProgressArea>
                                <telerik:RadProgressManager ID="RadProgressManager1" runat="server"
                                    Width="99px" />
                            </td>
                            <td class="style41"></td>
                        </tr>
                        <tr>
                            <td class="style29">&nbsp;</td>
                            <td class="auto-style6" colspan="3">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style29">&nbsp;</td>
                            <td class="auto-style6" colspan="3">&nbsp;</td>
                            <td class="style38">&nbsp;</td>
                            <td class="style4">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                            <td class="style3">&nbsp;</td>
                        </tr>
                    </table>
                </telerik:RadPageView>


                <telerik:RadPageView ID="RadPageView2" runat="server" TabIndex="2" Width="923px">
                    <table class="style1">
                        <tr>
                            <td class="style5"></td>
                            <td class="style32"></td>
                            <td class="style33"></td>
                            <td class="style5"></td>
                            <td class="style34"></td>
                            <td class="style5"></td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label38" runat="server" Font-Bold="True" Text="Fecha :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadDatePicker ID="txtFechaDocumento" runat="server" Culture="es-DO">
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x" runat="server">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                        LabelWidth="40%" runat="server">
                                    </DateInput>
                                    <DatePopupButton
                                        ToolTip="Seleccionar Calendario." />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style31">
                                <asp:RequiredFieldValidator ID="ValidatorFechaDocumento" runat="server"
                                    ControlToValidate="txtFechaDocumento" ErrorMessage="Fecha" Font-Size="Small"
                                    ForeColor="Red" SetFocusOnError="True"
                                    ToolTip="Debe ingresar un nombre válido." Width="46px">*</asp:RequiredFieldValidator>
                                <asp:Label ID="Label39" runat="server" Font-Bold="False"
                                    Text="Tipo Documento :" Width="124px"></asp:Label>
                                &nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxDocumentos" runat="server"
                                    AllowCustomText="True" CausesValidation="False"
                                    DataSourceID="SqlTipoDocumento" DataTextField="Nombre"
                                    DataValueField="TipoDocumentoID" EmptyMessage="Buscar..." Filter="Contains"
                                    Style="margin-left: 0px" Width="261px" Culture="es-DO" TabIndex="3" AutoPostBack="True">
                                </telerik:RadComboBox>
                            </td>
                            <td>&nbsp;</td>
                            <td class="style35">&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="ValidatorTipoDocumento" runat="server"
                                    ControlToValidate="RadComboBoxDocumentos" ErrorMessage="Tipo Documento"
                                    Font-Size="Small" ForeColor="Red" Height="16px" SetFocusOnError="True"
                                    ToolTip="Debe ingresar un nombre válido." Width="352px">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label40" runat="server" Font-Bold="True" Text="Descripción :"
                                    Width="88px"></asp:Label>
                            </td>
                            <td class="style27">
                                <asp:TextBox ID="txtDescripcion" runat="server" Width="214px" TabIndex="1" MaxLength="255"></asp:TextBox>
                            </td>
                            <td class="style31">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtArchivo" runat="server" Visible="False" Width="30px" TabIndex="4"></asp:TextBox>
                            </td>
                            <td class="style35">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label33" runat="server" Font-Bold="True" Text="Archivo :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadUpload ID="RadUpload2" runat="server"
                                    ControlObjectsVisibility="None" EnableTheming="True" Height="25px"
                                    Width="230px" TabIndex="2">
                                    <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover"
                                        Select="Seleccionar" />
                                </telerik:RadUpload>
                                <asp:Button ID="Button2" runat="server" Text="Subir" Width="59px"
                                    CausesValidation="False" />
                            </td>
                            <td class="style31">
                                <telerik:RadProgressArea ID="RadProgressArea2" runat="server" Culture="es-DO"
                                    HeaderText="Información de Progreso" Width="363px">
                                    <Localization Cancel="Cancelar" CurrentFileName="Subiendo Archivo: "
                                        ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: "
                                        TotalFiles="Total Archivos: " TransferSpeed="Velocidad: " Uploaded="Cargado"
                                        UploadedFiles="Archivos Cargados:" />
                                </telerik:RadProgressArea>
                            </td>
                            <td>
                                <telerik:RadProgressManager ID="RadProgressManager2" runat="server"
                                    Width="99px" />
                            </td>
                            <td class="style35">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">

                                <telerik:RadGrid ID="RadGridDocumento" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" Culture="es-DO" DataSourceID="SqlDocumentos"
                                    GridLines="Horizontal" PageSize="20" GroupPanelPosition="Top">

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
                                        CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="EmisorID,EmisorDocumentoID"
                                        DataSourceID="SqlDocumentos" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" ShowExportToCsvButton="True" />
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EmisorID" DataType="System.Int32"
                                                FilterControlAltText="Filter EmisorID column" HeaderText="EmisorID"
                                                ReadOnly="True" SortExpression="EmisorID" UniqueName="EmisorID"
                                                Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmisorDocumentoID"
                                                DataType="System.Int32"
                                                FilterControlAltText="Filter EmisorDocumentoID column"
                                                HeaderText="EmisorDocumentoID" ReadOnly="True"
                                                SortExpression="EmisorDocumentoID" UniqueName="EmisorDocumentoID"
                                                Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" DataFormatString="{0:MM/dd/yyyy}"
                                                DataType="System.DateTime" FilterControlAltText="Filter Fecha column"
                                                HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha">
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
                                                FilterControlAltText="Filter nombre column" HeaderText="Nombre"
                                                SortExpression="nombre" UniqueName="nombre">
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
                                    </MasterTableView>
                                </telerik:RadGrid>





                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>
                            <td class="style27">
                                <asp:SqlDataSource ID="SqlTipoDocumento" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [TipoDocumento] order by Nombre"></asp:SqlDataSource>
                                <br />
                            </td>
                            <td class="style31">
                                <asp:SqlDataSource ID="SqlDocumentos" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [vEmisorDocumentos] where EmisorID= @EmisorID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="EmisorID"
                                            PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                            <td class="style35">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView3" runat="server" TabIndex="2" Width="923px">
                    <table class="style1">
                        <tr>
                            <td class="style17" colspan="2">
                                <asp:Label ID="lblInfoCalificacionRiesgo" runat="server" Font-Bold="True" ForeColor="Red"
                                    Width="209px"></asp:Label></td>
                            <td class="style19">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style13">&nbsp;</td>
                            <td class="style36">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label22" runat="server" Font-Bold="False" Text="Empresa Calificadora :"
                                    Width="144px"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <telerik:RadComboBox ID="RadComboBoxEmpresaCalificadora" runat="server"
                                    AllowCustomText="True" AutoPostBack="True" CausesValidation="False"
                                    Culture="es-DO" DataSourceID="SqlEmpresaCalificadora" DataTextField="Nombre"
                                    DataValueField="EmpresaCalificadoraID" EmptyMessage="Buscar..."
                                    Filter="Contains" Style="margin-left: 0px" Width="267px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="ValidatorNombreDirecctivo" runat="server"
                                    ControlToValidate="txtFechaCalificacion" ErrorMessage="Nombre"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style5"></td>
                            <td class="auto-style4"></td>
                            <td class="auto-style5"></td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label70" runat="server" Font-Bold="False"
                                    Text="Rango Calificación :" Width="145px"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadComboBox ID="RadComboBoxRangoCalificacion" runat="server"
                                    AllowCustomText="True" AutoPostBack="True" CausesValidation="False"
                                    DataSourceID="SqlRangoCalificacionRiesgo" DataTextField="Nombre"
                                    DataValueField="RangoCalificacionID" EmptyMessage="Buscar..." Filter="Contains"
                                    Height="100px" Style="margin-left: 0px" Width="267px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style19">&nbsp;</td>
                            <td class="style1">&nbsp;</td>
                            <td class="style13">&nbsp;</td>
                            <td class="style36">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label23" runat="server" Font-Bold="False"
                                    Text="Tipo Calificación :" Width="123px"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadComboBox ID="RadComboBoxTipoCalificacion" runat="server"
                                    AllowCustomText="True" CausesValidation="False" Culture="es-DO"
                                    DataSourceID="SqlTipoCalificacion" DataTextField="CodEnSistema"
                                    DataValueField="TipoCalificacionRiesgoID" EmptyMessage="Buscar..."
                                    Filter="Contains" Style="margin-left: 0px" Width="267px"
                                    AutoPostBack="True">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style19">
                                <asp:RequiredFieldValidator ID="ValidatorTelefonoDirecctivo" runat="server"
                                    ControlToValidate="RadComboBoxTipoCalificacion" ErrorMessage="Nombre"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style1">&nbsp;</td>
                            <td class="style13">&nbsp;</td>
                            <td class="style36">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label10" runat="server" Font-Bold="False" Text="Fecha :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadDatePicker ID="txtFechaCalificacion" runat="server" Culture="es-DO">
                                    <Calendar runat="server" UseColumnHeadersAsSelectors="False"
                                        UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput runat="server" DateFormat="dd/MM/yyyy"
                                        DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                    </DateInput>
                                    <DatePopupButton
                                        ToolTip="Seleccionar Calendario." />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style19">&nbsp;</td>
                            <td class="style1">&nbsp;</td>
                            <td class="style13">&nbsp;</td>
                            <td class="style36">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label30" runat="server" Font-Bold="False" Text="Nota :"
                                    Width="83px"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtNotasCalificacion" runat="server" Height="71px"
                                    LabelWidth="64px" TextMode="MultiLine" Width="323px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style19">&nbsp;</td>
                            <td class="style1">
                                <asp:SqlDataSource ID="SqlEmpresaCalificadora" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT [EmpresaCalificadoraID], [Nombre] FROM [EmpresaCalificadora] order by [Nombre]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlRangoCalificacionRiesgo" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT RangoCalificacionID, Nombre, EmpresaCalificadoraID FROM RangoCalificacion WHERE (EmpresaCalificadoraID = ISNULL(@EmpresaCalificadoraID, 0)) order by Nombre">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="RadComboBoxEmpresaCalificadora"
                                            Name="EmpresaCalificadoraID" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlTipoCalificacion" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT TipoCalificacionRiesgoID, Nombre, CodEnSistema FROM TipoCalificacionRiesgo WHERE (EmpresaCalificadoraID = ISNULL(@EmpresaCalificadoraID, 0)) AND (RangoCalificacionID = ISNULL(@RangoCalificacionID, 0)) order by Nombre">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="RadComboBoxEmpresaCalificadora"
                                            Name="EmpresaCalificadoraID" PropertyName="SelectedValue" />
                                        <asp:ControlParameter ControlID="RadComboBoxRangoCalificacion"
                                            Name="RangoCalificacionID" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td class="style13">&nbsp;</td>
                            <td class="style36">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="5">
                                <telerik:RadGrid ID="RadGridCalificaciones" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO"
                                    DataSourceID="SQLvEmisorCalificacionRiesgo" GridLines="None"
                                    Height="355px" PageSize="20">
                                    <ExportSettings ExportOnlyData="True" FileName="Lista de Calificaciones de Riesgo"
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Lista de Calificaciones de Riesgo" Title="Lista de Calificaciones de Riesgo" />
                                    </ExportSettings>
                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True"
                                        ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Lista Calificaciones Riesgo"
                                        CommandItemDisplay="Bottom" CommandItemSettings-ShowAddNewRecordButton="False"
                                        DataKeyNames="EmisorCalificacionRiesgoID" DataSourceID="SQLvEmisorCalificacionRiesgo"
                                        NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF"
                                            ShowExportToCsvButton="True" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="EmisorID" DataType="System.Int32"
                                                FilterControlAltText="Filter EmisorID column" HeaderText="EmisorID"
                                                SortExpression="EmisorID" UniqueName="EmisorID" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmpresaCalificadoraID"
                                                DataType="System.Int32"
                                                FilterControlAltText="Filter EmpresaCalificadoraID column"
                                                HeaderText="EmpresaCalificadoraID"
                                                SortExpression="EmpresaCalificadoraID" UniqueName="EmpresaCalificadoraID"
                                                Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmisorCalificacionRiesgoID"
                                                FilterControlAltText="Filter EmisorCalificacionRiesgoID column" HeaderText="EmisorCalificacionRiesgoID"
                                                SortExpression="EmisorCalificacionRiesgoID"
                                                UniqueName="EmisorCalificacionRiesgoID" DataType="System.Int32" ReadOnly="True"
                                                Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoCalificacionRiesgoID"
                                                DataType="System.Int32"
                                                FilterControlAltText="Filter TipoCalificacionRiesgoID column"
                                                HeaderText="TipoCalificacionRiesgoID" SortExpression="TipoCalificacionRiesgoID"
                                                UniqueName="TipoCalificacionRiesgoID" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" DataType="System.DateTime"
                                                FilterControlAltText="Filter Fecha column" HeaderText="Fecha"
                                                SortExpression="Fecha" UniqueName="Fecha"
                                                DataFormatString="{0:dd/MM/yyyy} ">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmpresaCalificadoraNombre"
                                                FilterControlAltText="Filter EmpresaCalificadoraNombre column" HeaderText="Empresa Calificadora"
                                                SortExpression="EmpresaCalificadoraNombre"
                                                UniqueName="EmpresaCalificadoraNombre">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="TipoCalificacionRiesgoNombre"
                                                FilterControlAltText="Filter TipoCalificacionRiesgoNombre column" HeaderText="Calificación Riesgo"
                                                SortExpression="TipoCalificacionRiesgoNombre"
                                                UniqueName="TipoCalificacionRiesgoNombre">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="CodEnSistema"
                                                FilterControlAltText="Filter CodEnSistema column" HeaderText="Escala"
                                                SortExpression="CodEnSistema"
                                                UniqueName="CodEnSistema">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="Nota"
                                                FilterControlAltText="Filter Nota column" HeaderText="Nota"
                                                SortExpression="Nota" UniqueName="Nota" Visible="False">
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
                            <td class="style37">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style17">&nbsp;</td>
                            <td class="style2">
                                <br />
                            </td>
                            <td class="style19">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="style13">&nbsp;</td>
                            <td class="style36">&nbsp;</td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SQLvEmisorCalificacionRiesgo" runat="server"
                        ConnectionString="<%$ ConnectionStrings:CN %>"
                        SelectCommand="SELECT TipoCalificacionRiesgoNombre, EmpresaCalificadoraNombre, EmisorID, EmisorCalificacionRiesgoID, EmpresaCalificadoraID, Fecha, TipoCalificacionRiesgoID, Nota, CodEnSistema FROM vEmisorCalificacionRiesgo WHERE (EmisorID = @EmisorID) ORDER BY Fecha DESC">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Codigo" Name="EmisorID" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </telerik:RadPageView>



                <telerik:RadPageView ID="RadPageView4" runat="server">
                    <div>

                        <telerik:RadGrid ID="RadGridEmisionesLOG" runat="server" AllowAutomaticDeletes="True"
                            AllowAutomaticInserts="True" AllowAutomaticUpdates="True" Culture="es-DO" DataSourceID="SqlEmisor"
                            AllowFilteringByColumn="True" PageSize="20" AllowSorting="True" EnableHeaderContextMenu="True"
                            AllowPaging="True" GroupPanelPosition="Top" AutoGenerateColumns="False">
                            <GroupingSettings CaseSensitive="False" />

                            <ExportSettings ExportOnlyData="True" FileName="Historial de Cambios Emisor"
                                OpenInNewWindow="True" IgnorePaging="True">
                                <Pdf PageTitle="Lista de Cambios Emisor" Title="Historial de Cambios Emisor" DefaultFontFamily="Arial Narrow" PageLeftMargin="5" PageRightMargin="5" FontType="Embed" PageWidth="297mm" PageHeight="210mm" />
                                <%--<Excel Format="Xlsx" />--%>
                                <Word Format="Docx" />
                            </ExportSettings>

                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <%--<Scrolling AllowScroll="True" UseStaticHeaders="True" />--%>
                                <%--<ClientEvents OnRowDblClick="ClientClose2" />--%>
                                <%--    <Resizing AllowColumnResize="True" AllowResizeToFit="True" />--%>
                            </ClientSettings>

                            <MasterTableView Caption="Historial de Cambios de Emisores" CommandItemDisplay="None" DataSourceID="SqlEmisor" NoMasterRecordsText="No hay información para mostrar."
                                CommandItemSettings-ShowAddNewRecordButton="False" AllowSorting="True">

                                <CommandItemSettings
                                    ShowExportToExcelButton="True"
                                    ShowExportToPdfButton="True"
                                    ShowExportToCsvButton="True"
                                    ShowExportToWordButton="True"
                                    ShowRefreshButton="True"
                                    ExportToExcelText="Exportar a Excel"
                                    ExportToWordText="Exportar a Word"
                                    ExportToPdfText="Exportar a PDF"
                                    ExportToCsvText="Exportar a CSV"></CommandItemSettings>


                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>

                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </ExpandCollapseColumn>

                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                </EditFormSettings>

                                <Columns>
                                    <telerik:GridBoundColumn DataField="EmisorID" DataType="System.Int32" FilterControlAltText="Filter EmisorID column" HeaderText="EmisorID" SortExpression="EmisorID" UniqueName="EmisorID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CodEmisorBVRD" FilterControlAltText="Filter CodEmisorBVRD column" HeaderText="CodEmisorBVRD" ReadOnly="True" SortExpression="CodEmisorBVRD" UniqueName="CodEmisorBVRD">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreEmisor" FilterControlAltText="Filter NombreEmisor column" HeaderText="NombreEmisor" ReadOnly="True" SortExpression="NombreEmisor" UniqueName="NombreEmisor">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Direccion" FilterControlAltText="Filter Direccion column" HeaderText="Direccion" ReadOnly="True" SortExpression="Direccion" UniqueName="Direccion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Telefono" FilterControlAltText="Filter Telefono column" HeaderText="Telefono" SortExpression="Telefono" UniqueName="Telefono">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TipoEmisorNombre" FilterControlAltText="Filter TipoEmisorNombre column" HeaderText="TipoEmisorNombre" SortExpression="TipoEmisorNombre" UniqueName="TipoEmisorNombre">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActividadEconomica" FilterControlAltText="Filter ActividadEconomica column" HeaderText="ActividadEconomica" ReadOnly="True" SortExpression="ActividadEconomica" UniqueName="ActividadEconomica">
                                        <ItemStyle Width="600px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Sector" FilterControlAltText="Filter Sector column" HeaderText="Sector" SortExpression="Sector" UniqueName="Sector">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Estatus" FilterControlAltText="Filter Estatus column" HeaderText="Estatus" SortExpression="Estatus" UniqueName="Estatus">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CodEnSistema" FilterControlAltText="Filter CodEnSistema column" HeaderText="CodEnSistema" SortExpression="CodEnSistema" UniqueName="CodEnSistema">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="RNC" FilterControlAltText="Filter RNC column" HeaderText="RNC" SortExpression="RNC" UniqueName="RNC">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreEdificio" FilterControlAltText="Filter NombreEdificio column" HeaderText="NombreEdificio" SortExpression="NombreEdificio" UniqueName="NombreEdificio">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CasaAptoNo" FilterControlAltText="Filter CasaAptoNo column" HeaderText="CasaAptoNo" SortExpression="CasaAptoNo" UniqueName="CasaAptoNo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Piso" FilterControlAltText="Filter Piso column" HeaderText="Piso" SortExpression="Piso" UniqueName="Piso">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PaisID" DataType="System.Int32" FilterControlAltText="Filter PaisID column" HeaderText="PaisID" SortExpression="PaisID" UniqueName="PaisID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CiudadID" DataType="System.Int32" FilterControlAltText="Filter CiudadID column" HeaderText="CiudadID" SortExpression="CiudadID" UniqueName="CiudadID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="RegistroSIV" FilterControlAltText="Filter RegistroSIV column" HeaderText="RegistroSIV" SortExpression="RegistroSIV" UniqueName="RegistroSIV">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PaginaWeb" FilterControlAltText="Filter PaginaWeb column" HeaderText="PaginaWeb" SortExpression="PaginaWeb" UniqueName="PaginaWeb">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaConstitucion" DataType="System.DateTime" FilterControlAltText="Filter FechaConstitucion column" HeaderText="FechaConstitucion" SortExpression="FechaConstitucion" UniqueName="FechaConstitucion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PresidentedelaEmpresa" FilterControlAltText="Filter PresidentedelaEmpresa column" HeaderText="PresidentedelaEmpresa" SortExpression="PresidentedelaEmpresa" UniqueName="PresidentedelaEmpresa">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CapitalSuscritoPagado" DataType="System.Decimal" FilterControlAltText="Filter CapitalSuscritoPagado column" HeaderText="CapitalSuscritoPagado" SortExpression="CapitalSuscritoPagado" UniqueName="CapitalSuscritoPagado">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaIngresoComoEmisor" DataType="System.DateTime" FilterControlAltText="Filter FechaIngresoComoEmisor column" HeaderText="FechaIngresoComoEmisor" SortExpression="FechaIngresoComoEmisor" UniqueName="FechaIngresoComoEmisor">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TipoEmisorID" DataType="System.Int32" FilterControlAltText="Filter TipoEmisorID column" HeaderText="TipoEmisorID" SortExpression="TipoEmisorID" UniqueName="TipoEmisorID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Email" FilterControlAltText="Filter Email column" HeaderText="Email" SortExpression="Email" UniqueName="Email">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActividadEconomicaID" DataType="System.Int32" FilterControlAltText="Filter ActividadEconomicaID column" HeaderText="ActividadEconomicaID" SortExpression="ActividadEconomicaID" UniqueName="ActividadEconomicaID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Creacion" DataType="System.DateTime" FilterControlAltText="Filter Creacion column" HeaderText="Creacion" SortExpression="Creacion" UniqueName="Creacion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SectorID" DataType="System.Int32" FilterControlAltText="Filter SectorID column" HeaderText="SectorID" SortExpression="SectorID" UniqueName="SectorID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TipoEntidadID" DataType="System.Int32" FilterControlAltText="Filter TipoEntidadID column" HeaderText="TipoEntidadID" SortExpression="TipoEntidadID" UniqueName="TipoEntidadID">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaModificacion" DataType="System.DateTime" FilterControlAltText="Filter FechaModificacion column" HeaderText="FechaModificacion" SortExpression="FechaModificacion" UniqueName="FechaModificacion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PCModifica" FilterControlAltText="Filter PCModifica column" HeaderText="PCModifica" SortExpression="PCModifica" UniqueName="PCModifica">
                                    </telerik:GridBoundColumn>
                                </Columns>

                                <PagerStyle PageSizeControlType="RadComboBox" Mode="NextPrevNumericAndAdvanced"></PagerStyle>


                            </MasterTableView>
                            <FilterMenu EnableImageSprites="False"></FilterMenu>
                        </telerik:RadGrid>
                    </div>
                    <asp:SqlDataSource ID="SqlEmisor" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                        SelectCommand="SELECT * FROM [vEmisorLOG] WHERE (EmisorID = @EmisorID) order by NombreEmisor" DataSourceMode="DataReader">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Codigo" Name="EmisorID" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </telerik:RadPageView>


            </telerik:RadMultiPage>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
            <asp:Label ID="InjectScript" runat="server"></asp:Label>
            <br />
            <br />
            <br />
        </div>
        <div></div>
        <div>
            <telerik:RadNotification ID="Notification1" runat="server" Position="BottomRight"
                AutoCloseDelay="5000" Width="350" Title="Información" EnableRoundedCorners="true">
            </telerik:RadNotification>
        </div>
    </form>
</body>


</html>
