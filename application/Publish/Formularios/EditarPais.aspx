<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.EditarPais" Codebehind="EditarPais.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar País</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}</style>

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
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server"></telerik:RadScriptManager>
        </div>
        <div>
            <telerik:RadToolBar ID="RadToolBar1" Runat="server" Width="100%">
<Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                    Text="Guardar" ToolTip="Guardar Información" Value="0"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 3">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="3" CausesValidation="False" />
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                    Text="Button 1"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                    Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False"></telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div>
            <table class="style1">
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label8" runat="server" Text="Nombre :" Width="137px" 
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadTextBox ID="TxtNombre" runat="server" Height="24px" LabelWidth="64px"
                            Width="300px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="TxtNombre" ErrorMessage="Name" ForeColor="Red" Width="16px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        ISONUM:</td>
                    <td class="style1">
                        <telerik:RadTextBox ID="TxtISONUM" runat="server" Height="24px" LabelWidth="64px"
                            Width="300px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="TxtISONUM" ErrorMessage="Ingrese un valor" ForeColor="Red" Width="16px" ToolTip="Ingrese un ISONUM.">*</asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtISONUM" ErrorMessage="Solo permite números." ForeColor="Red" MaximumValue="99999" MinimumValue="1" ToolTip="Ingrese solo números" Type="Integer">*</asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        ISO2:</td>
                    <td class="style1">
                        <telerik:RadTextBox ID="TxtISO2" runat="server" Height="24px" LabelWidth="64px"
                            Width="104px" Style="margin-left: 4px" MaxLength="2">
                        </telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="TxtISO2" ErrorMessage="Ingrese un valor" ForeColor="Red" Width="16px" ToolTip="Debe ingresar un ISO2 válido.">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        ISO3:</td>
                    <td class="style1">
                        <telerik:RadTextBox ID="TxtISO3" runat="server" Height="24px" LabelWidth="64px"
                            Width="104px" Style="margin-left: 4px" MaxLength="3">
                        </telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="TxtISO3" ErrorMessage="Ingrese un valor" ForeColor="Red" Width="23px" ToolTip="Ingrese un ISO3 válido.">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:SqlDataSource ID="SqlPais" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:CN %>" 
                            SelectCommand="SELECT * FROM [Pais]">
                        </asp:SqlDataSource>
                    </td>
                    <td class="style3">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
           <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>

                        <br />
                        <asp:Label ID="InjectScript" Runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>


</html>
