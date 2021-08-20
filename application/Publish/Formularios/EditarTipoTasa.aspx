<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_EditarTipoTasa" Codebehind="EditarTipoTasa.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .style1 {
            width: 208px;
        }
        .style2
        {
            width: 188px;
            height: 2px;
        }
        .style3
        {
            width: 201px;
            height: 29px;
        }
        .style7
        {
            width: 198px;
        }
        .style8
        {
            width: 225px;
        }
        .style11
        {
            width: 198px;
            height: 29px;
        }
        .style12
        {
            width: 188px;
        }
        .style13
        {
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
                        <telerik:RadTextBox ID="txtDescricion" Runat="server" Height="24px" LabelWidth="64px"
                        Width="300px" style="margin-left: 4px"></telerik:RadTextBox>
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
                        <asp:Label ID="Label9" runat="server" Text="Descripción Corta :" Width="137px"
                        Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style11">
                        <telerik:RadTextBox ID="txtDescripcionCorta" Runat="server" Height="24px" LabelWidth="64px"
                        Width="113px" style="margin-left: 4px"></telerik:RadTextBox>
                    </td>
                    <td class="style13"></td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label8" runat="server" Text="Atributo :" Width="157px"
                        Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style11">&nbsp;<telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="True"
                        AutoPostBack="True" CausesValidation="False"
                        DataTextField="Nombre" DataValueField="TipoInstrumentoID" EmptyMessage="Buscar..."
                        Filter="Contains" Width="169px" style="margin-left: 0px">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="F-Fijo" Value="F" />
                            <telerik:RadComboBoxItem runat="server" Text="V-Variable" Value="V" />
                        </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td class="style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="RadComboBox1" ErrorMessage="Seleccione un Atributo" Font-Size="Small"
                        ForeColor="Red" SetFocusOnError="True" Width="16px" 
                            ToolTip="Debe ingresar un nombre válido." style="margin-left: 11px">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="Label7" runat="server" Text="Frecuencia :" Width="122px" 
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style7">
                        <telerik:RadTextBox ID="txtFrecuencia" Runat="server" Height="24px" LabelWidth="64px"
                        Width="113px" style="margin-left: 4px"></telerik:RadTextBox>
                    </td> 
                    <td class="style12">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style8">
                        &nbsp;</td>
                    <td class="style11">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
           <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" Runat="server"></asp:Label>
                    </td>
                    <td class="style12">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>

</html>
