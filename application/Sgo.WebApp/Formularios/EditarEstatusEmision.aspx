<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditarEstatusEmision.aspx.vb" Inherits="Sgo.WebApp.EditarEstatusEmision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Estatus Emisión</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />

<%-- Para Crear edición en Mayúscula --%>
<style type="text/css">
 
.upper
{
    text-transform:uppercase;
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
                    <telerik:RadToolBarButton runat="server" Text="Button 3" IsSeparator="True">
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
                        <asp:Label ID="Label1" runat="server" Text="Descripición :" Width="149px" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style4">
                        <telerik:RadTextBox ID="txtDescripcion" runat="server" Height="24px" LabelWidth="64px"
                            Width="292px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtDescripcion" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="17px" ToolTip="Debe ingresar una Descripción válido."
                            Height="16px">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label9" runat="server" Text="Código Interno :" Width="147px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style4">
                        <telerik:RadTextBox ID="txtCodigoEstatus" runat="server" Height="24px" LabelWidth="64px"
                            Width="93px" Style="margin-left: 4px" SelectionOnFocus="SelectAll" CssClass="upper">
                            <ClientEvents OnValueChanging="MyValueChanging" />
                        </telerik:RadTextBox>
                    </td>
                    <td class="style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label10" runat="server" Text="Mostrar en Edición :" Width="137px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:CheckBox ID="ckMostrarEnEdicion" Width="284px" runat="server" />
                    </td>
                    <td class="style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label7" runat="server" Text="Activo :" Width="70px" Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:CheckBox ID="CheckBox1" Width="291px" runat="server" />
                    </td>
                    <td class="style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style3">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
            </table>
        </div>

<%-- Para Crear edición en Mayúscula --%>

        <script type="text/javascript">
 

function MyValueChanging(sender, args)
{
    args.set_newValue(args.get_newValue().toUpperCase());
}
 
</script>
 
<br /><br />

<br /><br />

    </form>




</body>

</html>
