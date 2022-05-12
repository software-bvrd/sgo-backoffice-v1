<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ActivarCorredor.aspx.vb" Inherits="Sgo.WebApp.ActivarCorredor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Activar Corredor</title>


    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        .auto-style1 {
            width: 279px;
        }

        .auto-style3 {
            width: 178px;
            height: 23px;
        }

        .auto-style4 { 
            width: 279px;
            height: 23px;
        }

        .auto-style5 {
            width: 12px;
        }

        .auto-style6 {
            height: 23px;
            width: 12px;
        }
    </style>



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
            <table class="style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label45" runat="server" Font-Bold="True" Text="Corredor  :"
                            Width="101px"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="lblNombreCorredor" runat="server" Font-Bold="True" Text="NombreCorredor"
                            Width="269px"></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label46" runat="server" Font-Bold="True" Text="Asignar a Puesto Bolsa :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="RadComboBoxPuestoBolsaID" runat="server"
                            DataSourceID="SqlPuestoBolsa" DataTextField="Nombre"
                            DataValueField="PuestoBolsaID" EmptyMessage="Buscar..." Filter="Contains"
                            Width="370px" AllowCustomText="True" AutoPostBack="True"
                            CausesValidation="False" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                                <asp:TextBox ID="txtCodigoPuestoBolsaCorredorID" runat="server" Enabled="False" ReadOnly="True" Width="61px" Visible="False"></asp:TextBox>
                            </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlPuestoBolsa" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT PuestoBolsaID, Nombre, Activo, TipoParticipanteID FROM PuestoBolsa WHERE (Activo = 1) AND (TipoParticipanteID = 1) ORDER BY Nombre">
                        </asp:SqlDataSource>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

