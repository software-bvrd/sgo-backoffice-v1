<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditarConfiguracion.aspx.vb" Inherits="Sgo.WebApp.EditarConfiguracion" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Configuración</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .style1 {
            width: 208px;
        }

        .style2 {
            width: 252px;
        }

        .style3 {
            width: 201px;
        }

        .style4 {
            width: 204px;
        }

        .auto-style2 {
            width: 252px;
            height: 52px;
        }

        .auto-style3 {
            width: 201px;
            height: 52px;
        }

        .auto-style5 {
            width: 252px;
            height: 25px;
        }

        .auto-style6 {
            width: 201px;
            height: 25px;
        }

        .auto-style8 {
            width: 581px;
        }

        .auto-style10 {
            width: 252px;
            height: 30px;
        }

        .auto-style11 {
            width: 201px;
            height: 30px;
        }

        .auto-style13 {
            width: 252px;
            height: 29px;
        }

        .auto-style14 {
            width: 201px;
            height: 29px;
        }

        .auto-style16 {
            width: 244px;
            height: 30px;
        }

        .auto-style17 {
            width: 244px;
            height: 25px;
        }

        .auto-style18 {
            width: 244px;
            height: 29px;
        }

        .auto-style19 {
            width: 244px;
            height: 52px;
        }

        .auto-style20 {
            width: 244px;
        }

        .auto-style21 {
            width: 244px;
            height: 20px;
        }

        .auto-style22 {
            width: 252px;
            height: 20px;
        }

        .auto-style23 {
            width: 201px;
            height: 20px;
        }
    </style>

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
            <table class="auto-style8">
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label9" runat="server" Text="Npmbre Compañía :" Width="173px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadTextBox ID="txtNombreCompania" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="Label11" runat="server" Text="RNC :" Width="173px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <telerik:RadTextBox ID="txtRNC" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style11"></td>
                </tr>

                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="Label1" runat="server" Text="Teléfono:" Width="169px"
                            Font-Bold="False" Height="16px"></asp:Label>
                    </td>

                    <td class="auto-style5">
                        <telerik:RadTextBox ID="txtTelefono" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>

                    <td class="auto-style6">&nbsp;</td>

                </tr>

                <tr>
                    <td class="auto-style18">
                        <asp:Label ID="Label10" runat="server" Text="Email :" Width="134px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <telerik:RadTextBox ID="txtEmail" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style14"></td>
                </tr>

                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label8" runat="server" Text="Web:" Width="137px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadTextBox ID="txtWeb" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>

                <tr>
                    <td class="auto-style20">


                        <asp:Label ID="Label13" runat="server" Text="Registro Mercantil:" Width="137px"
                            Font-Bold="False"></asp:Label>


                    </td>
                    <td class="style2">
                        <telerik:RadTextBox ID="txtRegistroMercantil" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label7" runat="server" Text="Representante :" Width="124px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadTextBox ID="txtRepresentante" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label12" runat="server" Text="Cargo Representante :" Width="145px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadTextBox ID="txtRepresentanteCargo" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label14" runat="server" Text="Resolución Certificado Corredor :" Width="198px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadTextBox ID="txtResolucionCertificadoCorredor" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style21">
                        <asp:Label ID="Label15" runat="server" Text="Representante Operaciones :" Width="198px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="auto-style22">
                        <telerik:RadTextBox ID="txtRepresentanteOperaciones" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style23"></td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label16" runat="server" Text="Representante Operaciones Cargo :" Width="218px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadTextBox ID="txtRepresentanteOperacionesCargo" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style3">&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style21">
                        <asp:Label ID="Label17" runat="server" Text="Representante Operaciones Teléfono :" Width="223px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="auto-style22">
                        <telerik:RadTextBox ID="txtRepresentanteOperacionesTelefono" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style23"></td>
                </tr>
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label18" runat="server" Text="Representante Operaciones Email :" Width="223px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadTextBox ID="txtRepresentanteOperacionesEmail" runat="server" Height="29px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>

                <tr>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="style2">&nbsp;</td>
                    <td class="style3">&nbsp;</td>
                    </tr>

                <tr>
                    <td class="auto-style19">
                        <br />
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
        </div>
    </form>
</body>


</html>
