<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.EditUsuario" Codebehind="EditUsuario.aspx.vb" %>



<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="Stylesheet" href="../Styles/Custom.css" />
     <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style2 {
            width: 15px;
        }
        .auto-style4 {
            width: 73px;
        }
        .auto-style5 {
            width: 103px;
        }
        </style>
 </head>
<body style="background-color: #F1F5FB;">
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
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"><Scripts>
<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
</Scripts>
            </telerik:RadScriptManager>
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%" Enabled="False">
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
        <table style="width: 100%" cellpadding="0px 0px 8px 0px">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblmsg" runat="server" Width="95%"   ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Revisar,"
                        Width="100%" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtFind" runat="server" MaxLength="50" Width="187px"></asp:TextBox>     
                    <asp:Button ID="btnFind"  Text="..."  runat="server"/>
                </td>
                <td class="auto-style2"></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label14" runat="server" Text="Nombre:"></asp:Label>                                   
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" Width="188px" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label16" runat="server" Text="Email:"></asp:Label>
                    
               
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtCorreoElectronico" runat="server" MaxLength="50" Width="187px" Enabled="False"></asp:TextBox>
                    
               
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label2" runat="server" Text="Nombre de Usuario" Width="130px"></asp:Label>
                    
               
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtNombreUsuario" runat="server" MaxLength="50" Width="187px" Enabled="False"></asp:TextBox>                                   
                </td>
                <td>
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label10" runat="server" Text="Perfil" Width="150px"></asp:Label>                                   
                </td>
                <td class="auto-style4">
                    <telerik:RadComboBox ID="RadComboBox1" Runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="Nombre" DataValueField="IdPerfil" Width="187px">
                    </telerik:RadComboBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label13" runat="server" Text="Estatus" Width="150px"></asp:Label>
                    
               
                </td>
                <td class="auto-style4">
                    <telerik:RadComboBox ID="RadComboBox3" Runat="server" DataTextField="Nombre" 
                        DataValueField="IdPerfil" Width="187px">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Activo" Value="A" />
                            <telerik:RadComboBoxItem runat="server" Text="Inactivo" Value="I" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
     
    </div>
        <p>
                   <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </p>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:CN %>" 
                        SelectCommand="SELECT * FROM [Perfiles]"></asp:SqlDataSource>
    </form>
</body>
</html>
