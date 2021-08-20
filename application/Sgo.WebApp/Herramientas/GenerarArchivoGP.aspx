<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GenerarArchivoGP.aspx.vb" Inherits="Sgo.WebApp.GenerarArchivoGP" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            width: 223px;
        }

        .auto-style2 {
            width: 15px;
        }

        .auto-style3 {
            height: 29px;
        }

        .auto-style4 {
            width: 223px;
            height: 29px;
        }

        .auto-style5 {
            width: 15px;
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">


            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)				
                return oWindow;
            }

            function CloseOnReload() {
                alert("Dialog is about to close itself");
                GetRadWindow().close();
            }

            function RefreshParentPage() {
                GetRadWindow().Close();

                GetRadWindow().BrowserWindow.location.reload();



            }

            function ClosePage() {

                GetRadWindow().Close();
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



        </script>

        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/icon-download.png"
                        Text="Descargar Archivo" ToolTip="Descargar Archivo" Value="1">
                    </telerik:RadToolBarButton>
                 
                    </Items>
            </telerik:RadToolBar>

            <table style="width: 100%" cellpadding="0px 0px 8px 0px">
               <tr>
                    <td colspan="3">
                        <asp:Label ID="Label1" runat="server" Width="95%" ForeColor="#3399FF" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha Inicio</td>
                    <td class="auto-style1">
                        <telerik:RadDatePicker ID="txtFechaInicial" runat="server" Style="margin-left: 0px"
                            Culture="es-DO" Width="169px">
                            <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                ViewSelectorText="x" runat="server">
                            </Calendar>
                            <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%" runat="server">
                                <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                <FocusedStyle Resize="None"></FocusedStyle>

                                <DisabledStyle Resize="None"></DisabledStyle>

                                <InvalidStyle Resize="None"></InvalidStyle>

                                <HoveredStyle Resize="None"></HoveredStyle>

                                <EnabledStyle Resize="None"></EnabledStyle>
                            </DateInput>
                            <DatePopupButton></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="VakidadorFechaInicial" runat="server"
                            ControlToValidate="txtFechaInicial" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="209px" ToolTip="Debe seleccionar una Fecha Inicial.">Debe seleccionar una Fecha Inicial.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Fecha Fin</td>
                    <td class="auto-style4">
                        <telerik:RadDatePicker ID="txtFechaFinal" runat="server" Style="margin-left: 0px"
                            Culture="es-DO" Width="169px">
                            <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                ViewSelectorText="x" runat="server">
                            </Calendar>
                            <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%" runat="server">
                                <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                <FocusedStyle Resize="None"></FocusedStyle>

                                <DisabledStyle Resize="None"></DisabledStyle>

                                <InvalidStyle Resize="None"></InvalidStyle>

                                <HoveredStyle Resize="None"></HoveredStyle>

                                <EnabledStyle Resize="None"></EnabledStyle>
                            </DateInput>
                            <DatePopupButton></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="VakidadorFechaFinal" runat="server"
                            ControlToValidate="txtFechaFinal" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="215px" ToolTip="Debe seleccionar una Fecha Final.">Debe seleccionar una Fecha Final.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="lblmsg" runat="server" Width="95%" ForeColor="#FF3300"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>


        </div>
        <p>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </p>
      
    </form>
</body>
</html>
