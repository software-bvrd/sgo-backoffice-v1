<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Formularios_EditarEmpresaCalificadora" Codebehind="EditarEmpresaCalificadora.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Empresa Calificadora</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
.RadUpload_Default{font:normal 11px/10px "Segoe UI",Arial,sans-serif}.RadUpload{width:430px;text-align:left}.RadUpload_Default{font:normal 11px/10px "Segoe UI",Arial,sans-serif}.RadUpload{width:430px;text-align:left}.RadUpload_Default{font:normal 11px/10px "Segoe UI",Arial,sans-serif}.RadUpload{width:430px;text-align:left}.RadUpload .ruInputs{list-style:none;margin:0;padding:0}.RadUpload .ruInputs{position:relative;zoom:1}.RadUpload .ruInputs{list-style:none;margin:0;padding:0}.RadUpload .ruInputs{position:relative;zoom:1}.RadUpload .ruInputs{list-style:none;margin:0;padding:0}.RadUpload .ruInputs{position:relative;zoom:1}.RadUpload_Default .ruFakeInput{border-color:#abadb3 #dbdfe6 #e3e9ef #e2e3ea;color:#333}.RadUpload .ruFakeInput{height:16px;margin-right:-1px;background-position:0 -93px;background-repeat:repeat-x;background-color:#fff;line-height:20px\9;height:20px\9;padding-top:0\9}.RadUpload .ruFakeInput{float:none;vertical-align:top}.RadUpload .ruFakeInput{border-width:1px;border-style:solid;line-height:18px;padding:4px 4px 0 4px;-moz-box-sizing:content-box;-webkit-box-sizing:content-box;box-sizing:content-box}.RadUpload_Default .ruFakeInput{border-color:#abadb3 #dbdfe6 #e3e9ef #e2e3ea;color:#333}.RadUpload .ruFakeInput{height:16px;margin-right:-1px;background-position:0 -93px;background-repeat:repeat-x;background-color:#fff;line-height:20px\9;height:20px\9;padding-top:0\9}.RadUpload .ruFakeInput{float:none;vertical-align:top}.RadUpload .ruFakeInput{border-width:1px;border-style:solid;line-height:18px;padding:4px 4px 0 4px;-moz-box-sizing:content-box;-webkit-box-sizing:content-box;box-sizing:content-box}.RadUpload_Default .ruFakeInput{border-color:#abadb3 #dbdfe6 #e3e9ef #e2e3ea;color:#333}.RadUpload .ruFakeInput{height:16px;margin-right:-1px;background-position:0 -93px;background-repeat:repeat-x;background-color:#fff;line-height:20px\9;height:20px\9;padding-top:0\9}.RadUpload .ruFakeInput{float:none;vertical-align:top}.RadUpload .ruFakeInput{border-width:1px;border-style:solid;line-height:18px;padding:4px 4px 0 4px;-moz-box-sizing:content-box;-webkit-box-sizing:content-box;box-sizing:content-box}.RadUpload_Default .ruButton{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1308.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Upload.ruSprite.png');color:#000}.RadUpload .ruBrowse{margin-left:4px;width:65px;_height:20px;background-position:0 0;_vertical-align:middle}.RadUpload .ruButton{width:79px;height:22px;border:0;padding-bottom:2px;background-position:0 -23px;background-repeat:no-repeat;background-color:transparent;text-align:center}.RadUpload .ruButton{float:none;vertical-align:top}.RadUpload_Default .ruButton{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1308.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Upload.ruSprite.png');color:#000}.RadUpload .ruBrowse{margin-left:4px;width:65px;_height:20px;background-position:0 0;_vertical-align:middle}.RadUpload .ruButton{width:79px;height:22px;border:0;padding-bottom:2px;background-position:0 -23px;background-repeat:no-repeat;background-color:transparent;text-align:center}.RadUpload .ruButton{float:none;vertical-align:top}.RadUpload_Default .ruButton{background-image:url('mvwres://Telerik.Web.UI, Version=2012.3.1308.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Upload.ruSprite.png');color:#000}.RadUpload .ruBrowse{margin-left:4px;width:65px;_height:20px;background-position:0 0;_vertical-align:middle}.RadUpload .ruButton{width:79px;height:22px;border:0;padding-bottom:2px;background-position:0 -23px;background-repeat:no-repeat;background-color:transparent;text-align:center}.RadUpload .ruButton{float:none;vertical-align:top}
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
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div>
            <table class="style1">
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label2" runat="server" Text="Código Interno :" Width="120px"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style3">
                        <telerik:RadTextBox ID="txtCodigo" runat="server" Height="22px" LabelWidth="64px"
                            Width="150px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                                <asp:Label ID="Guardado" runat="server" Font-Bold="True" ForeColor="Red" 
                                    Width="209px"></asp:Label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtCodigo" ErrorMessage="Codigo" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="47px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                    <td rowspan="9">
                                <telerik:RadProgressArea ID="RadProgressArea1" Runat="server" Culture="es-DO" 
                                    HeaderText="Información de Progreso" Height="220px" Width="351px">
                                    <Localization Cancel="Cancelar" CurrentFileName="Subiendo Archivo: " 
                                        ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: " 
                                        TotalFiles="Total Archivos: " TransferSpeed="Velocidad: " Uploaded="Cargado" 
                                        UploadedFiles="Archivos Cargados:" />
                                </telerik:RadProgressArea>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label1" runat="server" Text="Nombre :" Width="70px"
                            Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style3">
                        <telerik:RadTextBox ID="txtNombre" runat="server" Height="24px" LabelWidth="64px"
                            Width="300px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtNombre" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="44px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label3" runat="server" Text="Dirección :" Width="79px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadTextBox ID="txtDireccion" runat="server" Height="24px" LabelWidth="64px"
                            Width="300px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtDireccion" ErrorMessage="Direccion" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="34px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label4" runat="server" Text="Teléfono :" Width="70px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadMaskedTextBox ID="txtTelefono" runat="server" Mask="(###) ###-####"
                            Style="margin-left: 5px" Width="160px">
                        </telerik:RadMaskedTextBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtTelefono" ErrorMessage="Telefono" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="36px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label5" runat="server" Text="Email :" Width="70px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadTextBox ID="txtEmail" runat="server" Height="24px" LabelWidth="64px"
                            Width="300px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label6" runat="server" Text="Web:" Width="70px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <telerik:RadTextBox ID="txtWeb" runat="server" Height="24px" LabelWidth="64px"
                            Width="300px" Style="margin-left: 4px">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1" rowspan="3">
                        Logo:</td>
                    <td class="style1">
                                <telerik:RadBinaryImage ID="ImagenEmpresaCalificadora" runat="server" AutoAdjustImageControlSize="False" ResizeMode="Fill" Width="100px" />
                                <asp:Label ID="MensajeLogo" runat="server" Font-Bold="False" Width="265px"></asp:Label>
                    </td>
                    <td class="style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                                <telerik:RadUpload ID="RadUpload1" Runat="server" ControlObjectsVisibility="None" EnableTheming="True" Height="25px" TabIndex="22" Width="230px">
                                    <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover" Select="Seleccionar" />
                                </telerik:RadUpload>
                    </td>
                    <td class="style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                                <asp:Button ID="BtnSubirLogo" runat="server" Text="Subir" Width="59px" CausesValidation="False" />
                    </td>
                    <td class="style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label7" runat="server" Text="Activa :" Width="70px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </td>
                    <td class="style1">&nbsp;</td>
                    <td rowspan="2">
                                &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:SqlDataSource ID="SqlTipoCalificacionRiesgo" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT * FROM [TipoMoneda]"></asp:SqlDataSource>
                    </td>
                    <td class="style3">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
           <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                                <telerik:RadProgressManager ID="RadProgressManager1" Runat="server" 
                                    Width="99px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
