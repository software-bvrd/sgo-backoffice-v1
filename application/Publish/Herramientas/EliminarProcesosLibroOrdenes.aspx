<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EliminarProcesosLibroOrdenes.aspx.vb" Inherits="Sgo.WebApp.EliminarProcesosLibroOrdenes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head id="Head1" runat="server">
    <title>Prorrateo Libro de Ordenes</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">/**/
        .auto-style1
        {
            width: 279px;
        }

        .auto-style3
        {
            width: 156px;
            height: 23px;
        }

        .auto-style5
        {
            width: 224px;
        }

        .rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}div.RadPicker table.rcSingle .rcInputCell{padding-right:0}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}
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
                        Text="Procesar" ToolTip="Procesar Información" Value="0">
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

        <div><asp:Label ID="Mensaje" runat="server" Text=""></asp:Label></div>
        <div>
            <table class="style1">

                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label45" runat="server" Font-Bold="False" Text="Emisor :"
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
                        <asp:Label ID="Label46" runat="server" Font-Bold="False" Text="Prorgama de Emisiones:"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="RadComboBoxEmisionID" runat="server"
                            DataSourceID="SqlEmision" DataTextField="CodEmisionBVRD"
                            DataValueField="EmisionID" EmptyMessage="Buscar..." Filter="Contains"
                            Width="230px" AllowCustomText="True" AutoPostBack="True"
                            CausesValidation="False" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="VakidadorEmision" runat="server"
                            ControlToValidate="RadComboBoxEmisionID" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="208px" ToolTip="Debe seleccionar una Emisión.">Debe seleccionar un Programa de Emisiones.</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label51" runat="server" Font-Bold="False" Text="Emisión :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="cbEmisionSerie" runat="server"
                            DataSourceID="SqlEmisionSerie" DataTextField="CodigoSerie"
                            DataValueField="CodigoSerie" EmptyMessage="Buscar..." Filter="Contains"
                            Width="230px" AllowCustomText="True" Style="margin-left: 0px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="cbEmisionSerie" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="208px" ToolTip="Debe seleccionar una Emisión.">Debe seleccionar una Emisión.</asp:RequiredFieldValidator></td>
                </tr>
                                                              <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Tipo Libro Ordenes :"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <telerik:RadComboBox ID="cboTipoLibroOrdenes" runat="server"
                            DataSourceID="SqlTipoLibroOrdenes" DataTextField="TipoLibroOrdenes"
                            DataValueField="TipoLibroOrdenes" EmptyMessage="Buscar..." Filter="Contains"
                            Width="230px" AllowCustomText="True" Style="margin-left: 0px" CausesValidation="False">
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="cboTipoLibroOrdenes" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="208px" ToolTip="Debe seleccionar una Emisión.">Debe seleccionar un tipo de libro ordenes.</asp:RequiredFieldValidator></td>
                </tr>
                                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Tipo de proceso:"></asp:Label>
                    </td>
                    <td class="auto-style1">
                                       <telerik:RadComboBox ID="cboTipoProceso" runat="server" Width="240px"  >
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Todo" Value="T" />
                                <telerik:RadComboBoxItem runat="server" Text="Ordenes" Value="O" />
                                <telerik:RadComboBoxItem runat="server" Text="Prorrateo" Value="P" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td class="auto-style5">
                                              </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlEmision" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [CodEmisionBVRD], [EmisorID], [Estatus], [EmisionID] FROM [Emision] WHERE (([Estatus] = @Estatus) AND ([EmisorID] = @EmisorID))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Activo" Name="Estatus" Type="String" />
                                <asp:ControlParameter ControlID="RadComboBoxEmisorID" Name="EmisorID" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlEmisorID" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [EmisorID], [NombreEmisor] FROM [Emisor] ORDER BY [NombreEmisor]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlEmisionSerie" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT rtrim(CodigoSerie) as CodigoSerie
FROM [EmisionSerie]   inner join EmisionTramo  on EmisionTramo.EmisionTramoID=EmisionSerie.EmisionTramoID
WHERE (EmisionTramo.EmisionID = @EmisionID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="RadComboBoxEmisionID" Name="EmisionID" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlTipoLibroOrdenes" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT DISTINCT TipoLibroOrdenes FROM dbo.Subasta  ">
                        </asp:SqlDataSource>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>


</html>
