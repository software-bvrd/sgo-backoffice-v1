<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditarMecanismosNegociacion.aspx.vb" Inherits="Sgo.WebApp.EditarMecanismosNegociacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Clasificación Participante</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .style1 {
            width: 472px;
        }

        .style2 {
            width: 36px;
        }

        .style3 {
            width: 58px;
        }

        .style4 {
            width: 60px;
        }

        .style5 {
            width: 58px;
            height: 33px;
        }

        .style6 {
            width: 60px;
            height: 33px;
        }

        .style7 {
            width: 36px;
            height: 33px;
        }

        .auto-style1 {
            width: 754px;
        }

        .auto-style2 {
            width: 754px;
            height: 33px;
        }

        .auto-style3 {
            width: 55px;
        }

        .auto-style4 {
            width: 55px;
            height: 33px;
        }

        .auto-style5 {
            width: 79px;
        }

        .auto-style6 {
            width: 79px;
            height: 33px;
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
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Nombre :" Width="70px" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <telerik:RadTextBox ID="txtDescripcion" runat="server" Height="24px" LabelWidth="64px"
                            Width="292px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtDescripcion" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="16px" ToolTip="Debe ingresar una Descripción válida."
                            Height="16px">*</asp:RequiredFieldValidator>
                    </td>


                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Código Mercado :" Width="70px" Font-Bold="True"></asp:Label>
                    </td>

                    <td class="auto-style6">
                        <telerik:RadTextBox ID="txtCodigoMercado" runat="server" Height="24px" LabelWidth="64px"
                            Width="200px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>

                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label7" runat="server" Text="Activo :" Width="70px" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>

</html>
