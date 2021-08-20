<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_EditarMercado" Codebehind="EditarMercado.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Mercado</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
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
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                    Text="Button 1"></telerik:RadToolBarButton>
                     <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="2" />
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 4">
                    </telerik:RadToolBarButton>
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
                    <td class="style4">
                        <asp:Label ID="Label1" runat="server" Text="Nombre :" Width="70px" 
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style3">
                        <telerik:RadTextBox ID="txtNombre" Runat="server" Height="24px" LabelWidth="64px"
                        Width="300px" style="margin-left: 0px"></telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtNombre" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                        SetFocusOnError="True" Width="70px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Alias:</td>
                    <td class="style3">
                        <telerik:RadTextBox ID="TxtAlias" Runat="server" Height="24px" Width="300px">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label9" runat="server" Text="Código Mercado :" Width="137px" 
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadTextBox ID="txtCodigoMercado" Runat="server">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label8" runat="server" Text="Tipo Mercado :" Width="137px" 
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="True" 
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoMercado" 
                            DataTextField="Nombre" DataValueField="TipoMercadoID" 
                            EmptyMessage="Buscar..." Filter="Contains" Height="200px" Width="294px" 
                            style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="RadComboBox1" ErrorMessage="Tipo Instrumento" 
                            Font-Size="Small" ForeColor="Red"
                        SetFocusOnError="True" Width="70px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label7" runat="server" Text="Activo :" Width="70px" 
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        Incluir en Reporte</td>
                    <td class="style1">
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:SqlDataSource ID="SqlTipoMercado" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:CN %>" 
                            SelectCommand="SELECT * FROM [TipoMercado]">
                        </asp:SqlDataSource>
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
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
