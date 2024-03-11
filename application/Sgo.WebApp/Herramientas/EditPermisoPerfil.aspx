<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.EditPermiso_Perfil" Codebehind="EditPermisoPerfil.aspx.vb" %>



<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="Stylesheet" href="../Styles/Custom.css" />
     <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <link href="../Formularios/Styles/msg.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 184px;
        }
        .auto-style2 {
            width: 63px;
        }
        .auto-style3 {
            width: 40px;
        }
        .auto-style4 {
            width: 40px;
            height: 32px;
        }
        .auto-style5 {
            width: 184px;
            height: 32px;
        }
        .auto-style6 {
            width: 63px;
            height: 32px;
        }
        .auto-style7 {
            height: 33px;
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
			

         function UpdateAllChildren(nodes, checked) {
             var i;
             var test;
             for (i = 0; i < nodes.get_count(); i++) {
                 if (checked) {
                     nodes.getNode(i).check();
                 }
                 else {
                     nodes.getNode(i).set_checked(false);
                 }

                 if (nodes.getNode(i).get_nodes().get_count() > 0) {
                     UpdateAllChildren(nodes.getNode(i).get_nodes(), checked);
                 }
             }
         }
      function clientNodeChecked(sender, eventArgs) {
          var childNodes = eventArgs.get_node().get_nodes();
          var isChecked = eventArgs.get_node().get_checked();
          UpdateAllChildren(childNodes, isChecked);
      }
 

        </script>
    
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">

                    <Items>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                            Text="Guardar" ToolTip="Guardar Información" Value="0" />

                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 1" />

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="2" Enabled="False" />

                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 1" />

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False" />

                    </Items>

                </telerik:RadToolBar>
            <br />
        <table style="width: 100%">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server"   Width="90%" 
                        ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="vertical-align: top">
                    &nbsp;</td>
                <td class="auto-style1" style="vertical-align: top">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadComboBox3" ErrorMessage="Seleccione un perfil" ForeColor="Red" ToolTip="Seleccione un perfil">Seleccione un perfil</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2" style="vertical-align: top">
                    &nbsp;</td>
                <td style="vertical-align: top">
                    <telerik:RadButton ID="RadButton1" runat="server" Text="Ver Permisos">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" style="vertical-align: top">
                    <asp:Label ID="Label11" runat="server" Text="Perfil:" Width="35px" Font-Bold="True"></asp:Label>
             
                </td>
                <td class="auto-style5" style="vertical-align: top">
                    <telerik:RadComboBox ID="RadComboBox3" Runat="server" 
                        DataSourceID="SqlDataSource3" DataTextField="Nombre" 
                        DataValueField="IdPerfil" Width="189px" style="margin-left: 0px">
                    </telerik:RadComboBox>                    
               
                </td>
                <td class="auto-style6" style="vertical-align: top">
                    <asp:Label ID="Label10" runat="server" Text="Opción de menú:" Width="114px" Font-Bold="True"></asp:Label>
                    
               
                </td>
                <td style="vertical-align: top" class="auto-style7">
                    <telerik:RadTreeView ID="rtvOpcionesMenu" Runat="server" DataFieldID="IdOpcion" DataFieldParentID="IdPadre" DataSourceID="SqlOpcionesMenu" DataTextField="Nombre" CheckBoxes="True" TriStateCheckBoxes="True" DataValueField="IdOpcion" CheckChildNodes="False">
                    </telerik:RadTreeView>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="vertical-align: top">
                    &nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
 
    
    </div>
                    <br />
        <br />
        <br />
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:CN %>" 
                        SelectCommand=" SELECT -1 as IdPerfil, '' as Nombre UNION SELECT IdPerfil, Nombre FROM [Perfiles] ORDER BY [Nombre]">
                    </asp:SqlDataSource>
                    
               
                    <asp:SqlDataSource ID="SqlOpcionesMenu" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [IdPadre], [IdOpcion], [Nombre], [OrdenDespliegue] FROM [vOpcionesMenu] ORDER BY [IdPadre], [OrdenDespliegue]"></asp:SqlDataSource>
                    
               
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [padre], [hijo], [desc] FROM [tPrueba]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:CN %>" 
                        
                        SelectCommand="Select 0 as [IdOpcion],'' as [Nombre] Union SELECT [IdOpcion], [Nombre] FROM [OpcionesMenu]   ORDER BY Nombre ">
                        
                    </asp:SqlDataSource>
                    
               
        <p>
                   <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
               </p>     
               
    </form>
</body>
</html>
