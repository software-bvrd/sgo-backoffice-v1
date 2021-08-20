<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Herramientas_NombreConsultaUsuario" CodeBehind="NombreConsultaUsuario.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar consulta </title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .style1 {
            width: 208px;
        }

        .style2 {
            width: 252px;
        }

        .style5 {
            width: 252px;
            height: 26px;
        }

        .style6 {
            width: 208px;
            height: 26px;
        }

        .style7 {
            width: 200px;
        }

        .style8 {
            width: 200px;
            height: 26px;
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
                    <td class="style7">&nbsp;</td>
                    <td class="style2">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="style7">
                        <asp:Label ID="Label1" runat="server" Text="Nombre :" Width="126px"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadTextBox ID="txtNombre" runat="server" Height="24px" LabelWidth="64px"
                            Width="300px" Style="margin-left: 0px">
                        </telerik:RadTextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="style8">&nbsp;</td>
                    <td class="style5">&nbsp;</td>
                    <td class="style6"></td>
                </tr>
                <tr>
                    <td class="style7">&nbsp;</td>
                    <td class="style2">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
