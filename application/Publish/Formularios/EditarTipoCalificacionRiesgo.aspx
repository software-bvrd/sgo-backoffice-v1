<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_EditarTipoCalificacionRiesgo" Codebehind="EditarTipoCalificacionRiesgo.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Tipo Calificación</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>

    <style type="text/css">
        .style1 {
            width: 238px;
        }

        .style2 {
            height: 26px;
        }

        .style3 {
            height: 26px;
            width: 238px;
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
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Empresa Calificadora :"
                            Width="146px"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadComboBox ID="RadComboBox2" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlEmpresaCalificadora"
                            DataTextField="Nombre" DataValueField="EmpresaCalificadoraID" EmptyMessage="Buscar..."
                            Filter="Contains" Height="100px" Width="322px" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Rango Calificación :"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlRangoCalificacionRiesgo"
                            DataTextField="Nombre" DataValueField="RangoCalificacionID" EmptyMessage="Buscar..."
                            Filter="Contains" Height="100px" Width="322px" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Escala :" Width="70px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadTextBox ID="txtCodEnSistema" runat="server" Height="24px" LabelWidth="64px"
                            Width="161px" Style="margin-left: 0px">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtCodEnSistema" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="18px" ToolTip="Debe ingresar una escala válida.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Nombre :" Width="121px"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style1" style="margin-left: 80px">
                        <telerik:RadTextBox ID="txtNombre" runat="server" Height="24px" LabelWidth="64px"
                            Width="300px" Style="margin-left: 0px">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtNombre" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="18px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label3" runat="server" Text="Color :" Width="70px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style3">&nbsp;<telerik:RadColorPicker AutoPostBack="true" runat="server"
                        SelectedColor="#00B050" ID="RadColorPicker2" ShowIcon="true" Preset="Standard" />
                    </td>
                    <td class="style2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Definición :"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadTextBox ID="txtDefinicion" runat="server" Height="70px"
                            TextMode="MultiLine" Width="328px">
                        </telerik:RadTextBox>
                        <br />
                    </td>
                    <td class="style1">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlRangoCalificacionRiesgo" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT * FROM [RangoCalificacion] WHERE ([EmpresaCalificadoraID] = @EmpresaCalificadoraID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="RadComboBox2" Name="EmpresaCalificadoraID"
                                    PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
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
