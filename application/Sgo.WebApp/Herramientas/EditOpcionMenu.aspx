<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.EditOpcionMenu" Codebehind="EditOpcionMenu.aspx.vb" %>



<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/msg.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" href="../Styles/Custom.css" />
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
          //alert ("Dialog is about to reload parent page");
          //				GetRadWindow().BrowserWindow.location.reload();
          //			 
          //			  
          //				GetRadWindow().close();		

          GetRadWindow().Close();

          GetRadWindow().BrowserWindow.location.reload();



      }

      function ClosePage() {
          //alert ("Dialog is about to reload parent page");
          //				GetRadWindow().BrowserWindow.location.reload();
          //			 
          //			  
          //				GetRadWindow().close();		

          GetRadWindow().Close();
          GetRadWindow().Close();

          //   GetRadWindow().BrowserWindow.location.reload();



      }

      function RedirectParentPage(newUrl) {
          //alert ("Dialog is about to redirect parent page to " + newUrl);
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
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Guardar" ToolTip="Guardar Información" Value="0">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1">
                    </telerik:RadToolBarButton>
                    <%--<telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="2" />
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 4">
                    </telerik:RadToolBarButton>--%>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
            <br />
        <table style="width: 100%">
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblmsg" runat="server"   Width="95%" 
                         ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Revisar,"
                        Width="100%" />
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="Id Usuario">*</asp:RequiredFieldValidator></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" Text="Nombre" Width="150px"></asp:Label>
                    
               
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox2" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                    
               
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="Nombre">*</asp:RequiredFieldValidator></td>
                <td>
                   <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label14" runat="server" Text="Url" Width="150px"></asp:Label>
                    
               
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox3" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                    
               
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label15" runat="server" Text="Parámetro" Width="150px"></asp:Label>
                    
               
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox4" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                    
               
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label16" runat="server" Text="Menu Padre" Width="150px"></asp:Label>
                    
               
                </td>
                <td style="width: 100px">
                    <telerik:RadComboBox ID="RadComboBox1" Runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="Nombre" 
                        DataValueField="IdOpcion" Width="308px" AutoPostBack="True" CausesValidation="False">
                    </telerik:RadComboBox>
                    
               
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label17" runat="server" Text="Orden despliegue" Width="150px"></asp:Label>
                    
               
                </td>
                <td style="width: 100px">
                    <telerik:RadComboBox ID="cbOrdenDespliegue" Runat="server" 
                        DataSourceID="SqlOrdenDespliegue" DataTextField="Nombre" 
                        DataValueField="OrdenDespliegue" Width="308px">
                    </telerik:RadComboBox>
                    
               
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label13" runat="server" Text="Estatus" Width="150px"></asp:Label>
                    
               
                </td>
                <td style="width: 100px">
                    <telerik:RadComboBox ID="RadComboBox3" Runat="server" DataTextField="Nombre" 
                        DataValueField="IdPerfil">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Text="Activo" Value="1" />
                            <telerik:RadComboBoxItem runat="server" Text="Inactivo" Value="0" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
 
    
    </div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:CN %>" 
                        SelectCommand=" Select 0 as IdOpcion, '' as Nombre union SELECT     IdOpcion, Nombre FROM  dbo.OpcionesMenu ORDER BY Nombre"></asp:SqlDataSource>
                    
               
        <asp:SqlDataSource ID="SqlOrdenDespliegue" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [Nombre], [OrdenDespliegue] FROM [vOpcionesMenu] WHERE (([IdPadre] IS NOT NULL) AND ([IdPadre] = @IdPadre)) ORDER BY [OrdenDespliegue]">
            <SelectParameters>
                <asp:ControlParameter ControlID="RadComboBox1" Name="IdPadre" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
                    
               
    </form>
</body>
</html>
