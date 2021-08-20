<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Edicion_ActivarEmision" CodeBehind="ActivarEmision.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cambiar Estatus Emisión</title>
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
        .style1 {
            height: 254px;
            width: 604px;
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
                        <asp:Label ID="Label45" runat="server" Font-Bold="True" Text="Emisor :"
                            Width="101px"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="RadComboBoxEmisorID" runat="server"
                            DataSourceID="SqlEmisorID" DataTextField="NombreEmisor"
                            DataValueField="EmisorID" EmptyMessage="Buscar..." Filter="Contains"
                            Width="358px" AllowCustomText="True" AutoPostBack="True"
                            CausesValidation="False" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label46" runat="server" Font-Bold="True" Text="Emisión :"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <telerik:RadComboBox ID="RadComboBoxEmisionID" runat="server"
                            DataSourceID="SqlEmision" DataTextField="CodEmisionBVRD"
                            DataValueField="EmisionID" EmptyMessage="Buscar..." Filter="Contains"
                            Width="230px" AllowCustomText="True" AutoPostBack="True"
                            CausesValidation="False" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style3">Estatus:</td>
                    <td class="auto-style4">
                                <telerik:RadComboBox ID="cbEstatus" runat="server" DataSourceID="SqlEmisionEstatus" DataTextField="Descripcion" DataValueField="CodigoEstatus" EmptyMessage="Buscar..." Filter="Contains" TabIndex="16" Width="205px">
                                </telerik:RadComboBox>
                                 </td>
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
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlEmision" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT CodEmisionBVRD, EmisorID, Estatus, EmisionID FROM Emision WHERE (Estatus IN (SELECT CodigoEstatus FROM EmisionEstatus WHERE (MostrarEnEdicion = 0))) AND (EmisorID = @EmisorID)" DataSourceMode="DataReader">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="RadComboBoxEmisorID" Name="EmisorID" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlEmisorID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [EmisorID], [NombreEmisor] FROM [Emisor]" DataSourceMode="DataReader"></asp:SqlDataSource>
                                 <asp:SqlDataSource ID="SqlEmisionEstatus" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT [EmisionEstatusID] ,RTRIM([CodigoEstatus]) as CodigoEstatus ,RTRIM([Descripcion]) as Descripcion ,[MostrarEnEdicion] ,[Activo] FROM [dbo].[EmisionEstatus]  ORDER BY [Descripcion]" DataSourceMode="DataReader"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
