<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_RangoCalificaciones" Codebehind="EditarRangoCalificaciones.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Rango Calificación</title>
    <script src="../Scripts/Ventanas.js"></script>

    <style type="text/css">
        .style1 {
            height: 28px;
        }

        .RadComboBox_Default {
            font: 12px "Segoe UI",Arial,sans-serif;
            color: #333;
        }

        .RadComboBox {
            vertical-align: middle;
            display: -moz-inline-stack;
            display: inline-block;
        }

        .RadComboBox {
            text-align: left;
        }

            .RadComboBox * {
                margin: 0;
                padding: 0;
            }

        .RadComboBox_Default .rcbInputCellLeft {
            background-image: url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png');
        }

        .RadComboBox .rcbInputCellLeft {
            background-color: transparent;
            background-repeat: no-repeat;
        }

        .RadComboBox_Default .rcbInput {
            font: 12px "Segoe UI",Arial,sans-serif;
            color: #333;
        }

        .RadComboBox .rcbInput {
            text-align: left;
        }

        .RadComboBox_Default .rcbArrowCellRight {
            background-image: url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png');
        }

        .RadComboBox .rcbArrowCellRight {
            background-color: transparent;
            background-repeat: no-repeat;
        }

        .style2 {
            width: 100%;
            height: 20px;
            line-height: 20px;
            vertical-align: middle;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin-top: -1px;
            margin-bottom: -1px;
            padding-left: 2px;
            padding-right: 0;
            padding-top: 0;
            padding-bottom: 0;
            background-position: 0 0;
        }

        .style3 {
            width: 18px;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin-top: -1px;
            margin-bottom: -1px;
            padding: 0;
            background-position: 0 -88px;
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
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div>
            <table class="style1">
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label6" runat="server" Text="Empresa Calificadora :"
                            Width="143px"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadComboBox ID="RadComboEmpresaCalificadora" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlEmpresaCalificadora"
                            DataTextField="Nombre" DataValueField="EmpresaCalificadoraID" EmptyMessage="Buscar..."
                            Filter="Contains" Height="100px" Width="297px" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label1" runat="server" Text="Nombre :" Width="70px"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadTextBox ID="txtNombre" runat="server" Height="24px" LabelWidth="64px"
                            Width="297px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtNombre" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="16px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">&nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
           <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlEmpresaCalificadora" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT [EmpresaCalificadoraID], [Nombre] FROM [EmpresaCalificadora] WHERE ([Activa] = @Activa)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="True" Name="Activa" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>



</html>
