<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_EditarCambiosTasasSeries" Codebehind="EditarCambiosTasasSeries.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Editar Tasas de Emisiones</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        .auto-style1
        {
            width: 279px;
        }
        .auto-style3
        {
            width: 178px;
            height: 23px;
        }
        .auto-style4
        {
            width: 279px;
            height: 23px;
        }
        .auto-style5
        {
            width: 12px;
        }
        .auto-style6
        {
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
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server"></telerik:RadScriptManager>
        </div>
        <div>
            <telerik:RadToolBar ID="RadToolBar1" Runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                    Text="Guardar" ToolTip="Guardar Información" Value="0"></telerik:RadToolBarButton>
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
                    <td class="auto-style3">
                                    <asp:Label ID="Label45" runat="server" Font-Bold="True" Text="Emisor :" 
                                        Width="101px"></asp:Label>
                                </td>
                    <td class="auto-style1" >
                                    <telerik:RadComboBox ID="RadComboBoxEmisorID" Runat="server" 
                                        DataSourceID="SqlEmisorID" DataTextField="NombreEmisor" 
                                        DataValueField="EmisorID" EmptyMessage="Buscar..." Filter="Contains" 
                                        Width="358px" AllowCustomText="True" AutoPostBack="True" 
                                        CausesValidation="False" style="margin-left: 0px">
                                    </telerik:RadComboBox>
                                </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label46" runat="server" Font-Bold="True" Text="Emisión :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                                    <telerik:RadComboBox ID="RadComboBoxEmisionID" Runat="server" 
                                        DataSourceID="SqlEmision" DataTextField="CodEmisionBVRD" 
                                        DataValueField="EmisionID" EmptyMessage="Buscar..." Filter="Contains" 
                                        Width="230px" AllowCustomText="True" AutoPostBack="True" 
                                        CausesValidation="False" style="margin-left: 0px" TabIndex="1">
                                    </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label47" runat="server" Font-Bold="True" Text="Serie :"></asp:Label>
                    </td>
                    <td class="auto-style4">
                                <telerik:RadComboBox ID="RadComboBoxEmisionSerie" runat="server" 
                                    AllowCustomText="True" CausesValidation="False" 
                                    DataSourceID="SqlEmisionSerie" DataTextField="CodigoSerie" 
                                    DataValueField="EmisionSerieID" EmptyMessage="Buscar..." Filter="Contains" 
                                    style="margin-left: 0px" Width="215px" Culture="es-DO" TabIndex="2">
                                </telerik:RadComboBox>
                    </td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Fecha :"></asp:Label>
                    </td>
                    <td class="auto-style1" style="margin-left: 0px">
                        <telerik:RadDatePicker ID="txtFecha" Runat="server" style="margin-left: 0px"
                        Culture="es-DO" Height="22px" Width="169px" TabIndex="3">
                            <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            ViewSelectorText="x" runat="server" style="margin-left: 0px"></Calendar>
                            <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            LabelWidth="40%" Height="22px" runat="server" TabIndex="3"></DateInput>
                            <DatePopupButton TabIndex="3"></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label9" runat="server" Text="Tasa  :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadNumericTextBox ID="txtTasa" Runat="server" style="margin-left: 0px" TabIndex="4">
                            <NumberFormat ZeroPattern="n" DecimalDigits="4"></NumberFormat>
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtTasa" ErrorMessage="Name" Font-Size="Small"
                        ForeColor="Red" SetFocusOnError="True" Width="16px" ToolTip="valor de compra.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label10" runat="server" Text="Descripción :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadTextBox ID="txtDescripcion" Runat="server" Width="240px" style="margin-left: 0px" TabIndex="5">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" Runat="server"></asp:Label>
      <asp:SqlDataSource ID="SqlEmisionSerie" runat="server" 
          ConnectionString="<%$ ConnectionStrings:CN %>" 
          SelectCommand="SELECT * FROM [vEmisionSerieConsulta] WHERE ([EmisionID] = @EmisionID)">
          <SelectParameters>
              <asp:ControlParameter ControlID="RadComboBoxEmisionID" Name="EmisionID" PropertyName="SelectedValue" Type="Int32" />
          </SelectParameters>
      </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlEmision" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [CodEmisionBVRD], [EmisorID], [Estatus], [EmisionID] FROM [Emision] WHERE (([Estatus] = @Estatus) AND ([EmisorID] = @EmisorID))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Activo" Name="Estatus" Type="String" />
                                <asp:ControlParameter ControlID="RadComboBoxEmisorID" Name="EmisorID" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlEmisorID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [EmisorID], [NombreEmisor] FROM [Emisor] ORDER BY [NombreEmisor]"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
