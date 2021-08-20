<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_EditarBoletin" Codebehind="EditarBoletin.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    .RadPicker{vertical-align:middle}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker_Default .rcCalPopup{background-position:0 0}
        .style2
        {
            width: 53px;
        }
        .style3
        {
            height: 23px;
            width: 12px;
        }
        .style4
        {
            height: 23px;
            width: 18px;
        }
        .style5
        {
            height: 23px;
            width: 53px;
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
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server"></telerik:RadScriptManager>
        </div>
        <div>
            <telerik:RadToolBar ID="RadToolBar1" Runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                    Text="Guardar" ToolTip="Guardar Información" Value="0" TabIndex="3"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                    Text="Button 1"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                    Text="Cancelar" ToolTip="Cancelar Edición" Value="1"></telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div>
            <table class="style1">
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label2" runat="server" Text="Fecha  :" Width="94px" 
                            Height="21px"></asp:Label>
                    </td>
                    <td class="style3">
                                    <telerik:RadDatePicker ID="txtFecha" Runat="server" 
                                        style="margin-left: 0px" Culture="es-DO" Height="22px" Width="169px">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Height="22px"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                    </td>
                    <td class="style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label3" runat="server" Text="No. Rueda  :" Width="94px" 
                            Height="21px"></asp:Label>
                    </td>
                    <td class="style3">
                        <telerik:RadNumericTextBox ID="txtSecuencial" Runat="server" Culture="es-DO" 
                            DataType="System.Int32" TabIndex="1">
<NumberFormat ZeroPattern="n" AllowRounding="False" DecimalDigits="0"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style5"></td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                    </td>
                    <td class="style2">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>

</html>
