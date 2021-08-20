<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Edicion_EditarComisionesTarifas" Codebehind="EditarComisionesTarifas.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Comisiones y Tarifas</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">

        .style1
        {
            height: 28px;
            }
        .style2
        {
        }
        .style19
        {
            width: 8px;
        }
        .style13
        {
            width: 433px;
        }
        .style36
        {
            width: 968px;
        }
        .RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center}.RadPicker_Default .rcCalPopup{background-position:0 0}.RadPicker_Default .rcCalPopup{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Calendar.sprite.gif')}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center}.RadGrid_Default{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid_Default{border:1px solid #828282;background:#fff;color:#333}.RadGrid_Default{border:1px solid #828282;background:#fff;color:#333}.RadGrid_Default{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid_Default{border:1px solid #828282;background:#fff;color:#333}
        .RadGrid_Default{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid_Default .rgHeaderDiv{background:#eee 0 -7550px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeaderDiv{background:#eee 0 -7550px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeaderDiv{background:#eee 0 -7550px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgMasterTable{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgMasterTable{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid .rgClipCells .rgHeader{overflow:hidden}.RadGrid .rgClipCells .rgHeader{overflow:hidden}.RadGrid .rgClipCells .rgHeader{overflow:hidden}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid .rgHeader{cursor:default}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}.RadGrid .rgHeader{cursor:default}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgCommandRow{background:#c5c5c5 0 -2099px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');color:#000}.RadGrid_Default .rgCommandRow{background:#c5c5c5 0 -2099px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');color:#000}.RadGrid_Default .rgCommandRow{background:#c5c5c5 0 -2099px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');color:#000}.RadGrid_Default .rgMasterTable > tbody > tr.rgCommandRow .rgCommandCell{border-top-width:1px;border-bottom-width:0}.RadGrid_Default .rgMasterTable > tbody > tr.rgCommandRow .rgCommandCell{border-top-width:1px;border-bottom-width:0}.RadGrid_Default .rgMasterTable > tbody > tr.rgCommandRow .rgCommandCell{border-top-width:1px;border-bottom-width:0}.RadGrid_Default .rgCommandCell{border:1px solid;border-color:#999 #f2f2f2;border-top-width:0;padding:0}.RadGrid_Default .rgCommandCell{border:1px solid;border-color:#999 #f2f2f2;border-top-width:0;padding:0}.RadGrid_Default .rgCommandCell{border:1px solid;border-color:#999 #f2f2f2;border-top-width:0;padding:0}.RadGrid_Default .rgCommandTable{border:0;border-top:1px solid #fdfdfd;border-bottom:1px solid #e7e7e7}.RadGrid_Default .rgCommandTable{border:0;border-top:1px solid #fdfdfd;border-bottom:1px solid #e7e7e7}.RadGrid_Default .rgCommandTable{border:0;border-top:1px solid #fdfdfd;border-bottom:1px solid #e7e7e7}.RadGrid_Default .rgRefresh{margin-right:3px;background-position:0 -1600px}.RadGrid_Default .rgRefresh{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgRefresh{width:18px;height:18px;vertical-align:bottom}.RadGrid .rgRefresh{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid .rgRefresh{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid .rgRefresh{width:18px;height:18px;vertical-align:bottom}.RadGrid_Default .rgRefresh{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgRefresh{margin-right:3px;background-position:0 -1600px}.RadGrid .rgRefresh{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid .rgRefresh{width:18px;height:18px;vertical-align:bottom}.RadGrid_Default .rgRefresh{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgRefresh{margin-right:3px;background-position:0 -1600px}.RadGrid_Default .rgExpXLS{background-position:0 0}.RadGrid_Default .rgExpXLS{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Common.Grid.export.gif')}.RadGrid_Default .rgExpXLS{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgExpXLS{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid .rgExpXLS{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid_Default .rgExpXLS{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgExpXLS{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Common.Grid.export.gif')}.RadGrid_Default .rgExpXLS{background-position:0 0}.RadGrid .rgExpXLS{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid_Default .rgExpXLS{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgExpXLS{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Common.Grid.export.gif')}.RadGrid_Default .rgExpXLS{background-position:0 0}.RadGrid_Default .rgExpPDF{background-position:0 -100px}.RadGrid_Default .rgExpPDF{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Common.Grid.export.gif')}.RadGrid_Default .rgExpPDF{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgExpPDF{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid .rgExpPDF{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid_Default .rgExpPDF{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgExpPDF{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Common.Grid.export.gif')}.RadGrid_Default .rgExpPDF{background-position:0 -100px}.RadGrid .rgExpPDF{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid_Default .rgExpPDF{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgExpPDF{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Common.Grid.export.gif')}.RadGrid_Default .rgExpPDF{background-position:0 -100px}.RadGrid_Default .rgExpCSV{background-position:0 -150px}.RadGrid_Default .rgExpCSV{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Common.Grid.export.gif')}.RadGrid_Default .rgExpCSV{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.912.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgExpCSV{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid .rgExpCSV{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}
        .RadGrid_Default .rgExpCSV{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgExpCSV{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Common.Grid.export.gif')}.RadGrid_Default .rgExpCSV{background-position:0 -150px}.RadGrid .rgExpCSV{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}.RadGrid_Default .rgExpCSV{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid_Default .rgExpCSV{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.724.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Common.Grid.export.gif')}.RadGrid_Default .rgExpCSV{background-position:0 -150px}
        .style39
        {
            height: 28px;
            width: 339px;
        }
        .style40
        {
            width: 339px;
        }
        .style41
        {
            width: 77px;
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
                    Text="Guardar" ToolTip="Guardar Información" Value="0"></telerik:RadToolBarButton>
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
                        <asp:Label ID="Label1" runat="server" Text="Concepto :" Width="103px" 
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style3">
                        <telerik:RadTextBox ID="ConceptoEncabezado" Runat="server" Height="24px" LabelWidth="64px"
                        Width="300px" style="margin-left: 0px"></telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="ConceptoEncabezado" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                        SetFocusOnError="True" Width="24px" 
                            ToolTip="Debe ingresar un concepto válido.">*</asp:RequiredFieldValidator>
                                <asp:Label ID="Guardado" runat="server" Font-Bold="True" ForeColor="Red" 
                                    Width="209px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label2" runat="server" Text="Entidad :" Width="70px"></asp:Label>
                    </td>
                    <td class="style3">
                        
                        <telerik:RadComboBox ID="RadComboBox1" Runat="server" Width="271px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Emisor" Value="Emisor" />
                                <telerik:RadComboBoxItem runat="server" Text="Emisión" Value="Emisión" />
                                <telerik:RadComboBoxItem runat="server" Text="Operaciones Compra" 
                                    Value="Operaciones Compra" />
                                <telerik:RadComboBoxItem runat="server" Text="Operaciones Venta" 
                                    Value="Operaciones Venta" />
                                <telerik:RadComboBoxItem runat="server" Text="Puesto" Value="Puesto" />
                                <telerik:RadComboBoxItem runat="server" Text="Corredor" Value="Corredor" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td>
                                <asp:TextBox ID="Codigo" runat="server" Enabled="False" ReadOnly="True"
                                Width="61px" Visible="False"></asp:TextBox>
                            </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label3" runat="server" Text="Activo :" Width="70px"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:CheckBox ID="chkActivo" runat="server" />
                    </td>
                    <td class="style1">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>

        <div>
        
        <asp:Label ID="Label7" runat="server"  Text="Detalles Comisión/Tarifas"
                        Width="100%" style="font-size:medium; font-weight: 700;" 
                   ></asp:Label>
        </div>
        
        <div>
        
            <telerik:RadToolBar ID="RadToolBar2" Runat="server" Width="100%">
                    
                    <Items>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" 
                        Text="Nuevo" ToolTip="Crear Nuevo" Value="0"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" 
                        Text="Button 4" IsSeparator="True"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Guardar" ToolTip="Guardar Información" Value="1"></telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" CheckOnClick="True"
                        ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="2"></telerik:RadToolBarButton>
                    </Items>

                </telerik:RadToolBar>

        </div>

        <div>
        
                    <table class="style1">
                        <tr>
                            <td class="style41">
                                &nbsp;</td>
                            <td class="style2">
                                &nbsp;</td>
                            <td class="style19">
                                &nbsp;</td>
                            <td class="style40">
                                &nbsp;</td>
                            <td class="style13">
                                &nbsp;</td>
                            <td class="style36">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style41">
                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Concepto :" 
                                    Width="97px"></asp:Label>
                            </td>
                            <td class="style2" colspan="4">
                                <telerik:RadTextBox ID="Concepto" Runat="server" Width="444px" 
                                    AutoPostBack="True">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style36">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style41">
                                <asp:Label ID="Label22" runat="server" Font-Bold="False" Text="Valor Inicio :" 
                                    Width="97px"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadNumericTextBox ID="ValorInicio" Runat="server">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style19">
                                &nbsp;</td>
                            <td class="style39">
                                <asp:Label ID="Label24" runat="server" Font-Bold="False" Text="Porcentaje  :" 
                                    Width="81px"></asp:Label>
                            </td>
                            <td class="style13">
                                <telerik:RadNumericTextBox ID="PorcentajeCobrar" Runat="server" 
                                    Culture="en-US" DbValueFactor="1" LabelWidth="64px" Type="Percent" 
                                    Width="96px">
<NumberFormat ZeroPattern="n %"></NumberFormat>
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style36">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style41">
                                <asp:Label ID="Label23" runat="server" Font-Bold="False" Text="Valor Final :" 
                                    Width="111px"></asp:Label>
                            </td>
                            <td class="style2">
                                <telerik:RadNumericTextBox ID="ValorFinal" Runat="server">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style19">
                                &nbsp;</td>
                            <td class="style39">
                                <asp:Label ID="Label25" runat="server" Font-Bold="False" Text="Valor Cobrar  :" 
                                    Width="110px"></asp:Label>
                            </td>
                            <td class="style13">
                                <telerik:RadNumericTextBox ID="ValorCobrar" Runat="server">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="style36">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="6">
                                
                                <telerik:RadGrid ID="RadGridComisionesTarifasDetalles" runat="server" AllowSorting="True" 
                                    AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" GridLines="None" 
                                    Height="327px" PageSize="20" DataSourceID="SQLvComisionesTarifasDetalle" 
                                    Width="830px">
                                    
                                    <ExportSettings ExportOnlyData="True" FileName="Comisiones y Tarifas Detalle" 
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Comisiones y Tarifas Detalle" 
                                            Title="Comisiones y Tarifas Detalle" />
                                    </ExportSettings>
                                    
                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True" 
                                        ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Comisiones y Tarifas Detalle" 
                                        CommandItemDisplay="Bottom" CommandItemSettings-ShowAddNewRecordButton="False" 
                                        NoMasterRecordsText="No hay información para mostrar." 
                                        DataKeyNames="ComisionesTarifasDetalleID" 
                                        DataSourceID="SQLvComisionesTarifasDetalle">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" 
                                            ShowExportToCsvButton="True" ShowExportToExcelButton="True" 
                                            ShowExportToPdfButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        
                                        <Columns>
                                        
                                            <telerik:GridBoundColumn DataField="ComisionesTarifasDetalleID" 
                                                DataType="System.Int32" 
                                                FilterControlAltText="Filter ComisionesTarifasDetalleID column" 
                                                HeaderText="ComisionesTarifasDetalleID" ReadOnly="True" 
                                                SortExpression="ComisionesTarifasDetalleID" 
                                                UniqueName="ComisionesTarifasDetalleID" Visible="False">
                                            </telerik:GridBoundColumn>
                                        
                                            <telerik:GridBoundColumn DataField="ComisionesTarifasID" 
                                                DataType="System.Int32" 
                                                FilterControlAltText="Filter ComisionesTarifasID column" 
                                                HeaderText="ComisionesTarifasID" SortExpression="ComisionesTarifasID" 
                                                UniqueName="ComisionesTarifasID" Visible="False">
                                            </telerik:GridBoundColumn>
                                        
                                            <telerik:GridBoundColumn DataField="Concepto" 
                                                FilterControlAltText="Filter Concepto column" HeaderText="Concepto" 
                                                SortExpression="Concepto" UniqueName="Concepto">
                                            </telerik:GridBoundColumn>
                                        
                                            <telerik:GridBoundColumn DataField="ValorInicio" DataType="System.Decimal" 
                                                FilterControlAltText="Filter ValorInicio column" HeaderText="Valor Inicio" 
                                                SortExpression="ValorInicio" UniqueName="ValorInicio">
                                            </telerik:GridBoundColumn>
                                        
                                            <telerik:GridBoundColumn DataField="ValorFinal" DataType="System.Decimal" 
                                                FilterControlAltText="Filter ValorFinal column" HeaderText="Valor Final" 
                                                SortExpression="ValorFinal" UniqueName="ValorFinal">
                                            </telerik:GridBoundColumn>
                                        
                                            <telerik:GridBoundColumn DataField="PorcentajeCobrar" DataType="System.Decimal" 
                                                FilterControlAltText="Filter PorcentajeCobrar column" 
                                                HeaderText="PorcentajeCobrar" SortExpression="Porcentaje Cobrar" 
                                                UniqueName="PorcentajeCobrar">
                                            </telerik:GridBoundColumn>
                                        
                                            <telerik:GridBoundColumn DataField="ValorCobrar" DataType="System.Decimal" 
                                                FilterControlAltText="Filter ValorCobrar column" HeaderText="Valor Cobrar" 
                                                SortExpression="ValorCobrar" UniqueName="ValorCobrar">
                                            </telerik:GridBoundColumn>
                                        
                                        </Columns>

                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td class="style41">
                                &nbsp;</td>
                            <td class="style2">
                                <br />
                            </td>
                            <td class="style19">
                                &nbsp;</td>
                            <td class="style40">
                                &nbsp;</td>
                            <td class="style13">
                                &nbsp;</td>
                            <td class="style36">
                                <asp:SqlDataSource ID="SQLvComisionesTarifasDetalle" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:CN %>" 
                                    
                                    SelectCommand="SELECT * FROM [vComisionesTarifasDetalle] WHERE ([ComisionesTarifasID] = @ComisionesTarifasID)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Codigo" Name="ComisionesTarifasID" 
                                            PropertyName="Text" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
        
        </div>


    </form>
</body>


</html>
