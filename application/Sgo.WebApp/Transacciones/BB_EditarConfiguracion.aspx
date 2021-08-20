<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BB_EditarConfiguracion.aspx.vb" Inherits="Sgo.WebApp.BB_EditarConfiguracion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .style1 {
            width: 208px;
        }

        .style2 {
            width: 188px;
            height: 2px;
        }

        .style3 {
            width: 201px;
            height: 29px;
        }

        .style7 {
            width: 198px;
        }

        .style8 {
            width: 225px;
        }

        .style11 {
            width: 198px;
            height: 29px;
        }

        .style12 {
            width: 188px;
        }

        .style13 {
            width: 188px;
            height: 29px;
        }
    </style>

    <link rel="Stylesheet" href="../Styles/Custom.css" />

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
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="2" />

                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 4">
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
                    <td class="style8">&nbsp;</td>
                    <td class="style11">&nbsp;</td>
                    <td class="style12">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="Label1" runat="server" Text="Descripción :" Width="113px"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style11">
                        <telerik:RadTextBox ID="txtDescricion" runat="server" Height="24px" LabelWidth="64px"
                            Width="300px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style12">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtDescricion" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="19px"
                            ToolTip="Debe ingresar un descripción válida.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label8" runat="server" Text="Tipo Precio:" Width="157px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style11"><telerik:RadComboBox ID="RadComboBoxTP" runat="server" AllowCustomText="True"
                        AutoPostBack="True" CausesValidation="False" EmptyMessage="Buscar..."
                        Filter="Contains" Width="169px" Style="margin-left: 0px">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="U - Unico" Value="U" Selected="True" />
                            <telerik:RadComboBoxItem runat="server" Text="P - Ponderado" Value="P" />
                        </Items>
                    </telerik:RadComboBox>
                    </td>
                    <td class="style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="RadComboBoxTP" ErrorMessage="Seleccione un Tipo Precio" Font-Size="Small"
                            ForeColor="Red" SetFocusOnError="True" Width="16px"
                            ToolTip="Debe ingresar un nombre válido." Style="margin-left: 11px">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="Label7" runat="server" Text="N Títulos Transados :" Width="133px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style7">
                        <telerik:RadNumericTextBox ID="txtNtitulosTransados" Runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" MaxValue="100" MinValue="0" Value="5" Width="160px">
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style12">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style8">&nbsp;</td>
                    <td class="style11">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                    </td>
                    <td class="style12">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>

</html>
