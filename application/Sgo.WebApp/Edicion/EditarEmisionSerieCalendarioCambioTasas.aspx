<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.EditarEmisionSerieCalendarioCambioTasas" Codebehind="EditarEmisionSerieCalendarioCambioTasas.aspx.vb" %> 

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

 

 
<%-- 
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
--%> 

 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <title></title>      
   <link rel="Stylesheet" href="../Styles/Custom.css" />
</head>


<body>
  <form id="form1" runat="server" >
      <script type="text/javascript">
          function GetRadWindow() {
              var oWindow = null;
              if (window.radWindow) oWindow = window.radWindow;
              else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
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
              $find("RadAjaxPanel1").ajaxRequest();
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


          function CloseOnReload() {
              alert("Dialog is about to close itself");
              GetRadWindow().close();
          }

 
   
           
    </script>
      <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"
          EnableTheming="True">
      </telerik:RadScriptManager>
           
           
            <telerik:RadToolBar ID="RadToolBar1" Runat="server" Width="100%">
                <Items>
                    
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                    Text="Guardar" ToolTip="Guardar Información" Value="0" 
                        CausesValidation="False"></telerik:RadToolBarButton>
                    
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                    
                    Text="Separador"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                    Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False"></telerik:RadToolBarButton>

                </Items>
            </telerik:RadToolBar>


<div class="MainDiv">
     <div class="ContentDiv">
            
                <TABLE class="TablaMantenimiento" cellSpacing=3 cellPadding=0><TBODY>
                    <tr>
                        <td colspan="5" rowspan="1" style="font-weight: normal;
                            height: 8px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="CeldaNombreCampo" style="font-weight: normal; width: 135px;">
                            <asp:Label ID="Label7" runat="server" Text="Emision Serie"></asp:Label></td>
                        <td class="CeldaContenidoCampo" colspan="4" style="height: 7px">
                                <telerik:RadComboBox ID="RadComboBoxEmisionSerie" runat="server" 
                                    AllowCustomText="True" CausesValidation="False" 
                                    DataSourceID="SqlEmisionSerie" DataTextField="Serie" 
                                    DataValueField="EmisionSerieID" EmptyMessage="Buscar..." Filter="Contains" 
                                    style="margin-left: 0px" Width="215px" Culture="es-DO">
                                </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="CeldaNombreCampo" rowspan="1" style="font-weight: normal; width: 135px;">
                            <asp:Label ID="Label1" runat="server" Text="Asunto"></asp:Label></td>
                        <td class="CeldaContenidoCampo" colspan="4" style="height: 7px">
                            <asp:TextBox ID="Subject" runat="server" Width="542px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="CeldaNombreCampo" rowspan="1" style="font-weight: normal; height: 8px; width: 135px;">
                            <asp:Label ID="Label3" runat="server" Text="Fecha "></asp:Label></td>
                        <td class="CeldaContenidoCampo" style="width: 238px; height: 8px">
                            <telerik:RadDateTimePicker ID="RadDateTimePickerFechaStart" runat="server" 
                                Culture="es-DO" Width="195px">
<TimeView CellSpacing="-1" Culture="es-DO"></TimeView>

<TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>

<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDateTimePicker>
                            </td>
                        <td class="CeldaContenidoCampo" style="width: 238px; height: 8px">
                            &nbsp;</td>
                        <td class="CeldaNombreCampo" colspan="2" style="font-weight: normal; height: 8px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="CeldaNombreCampo" rowspan="1" style="font-weight: normal; height: 8px; width: 135px;">
                            <asp:Label ID="Label5" runat="server" Text="Tasa"></asp:Label></td>
                        <td class="CeldaContenidoCampo" colspan="4" style="height: 8px">
                            <asp:TextBox ID="Tasa" runat="server" Width="543px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="CeldaNombreCampo" rowspan="1">
                            <asp:Label ID="Label6" runat="server" Text="Descripción"></asp:Label></td>
                        <td class="CeldaNombreCampo" colspan="4">
                            <asp:TextBox ID="Description" runat="server" Height="69px" Width="544px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="CeldaNombreCampo" rowspan="1" style="height: 8px">
                            <asp:Label ID="Label9" runat="server" Text="Estatus"></asp:Label></td>
                        <td class="CeldaNombreCampo" colspan="3" style="height: 8px">
                            <%--           <telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="True" AutoPostBack="True"
                                BackColor="White" CausesValidation="False" EnableLoadOnDemand="True" EnableVirtualScrolling="True"
                                Height="200px" MarkFirstMatch="True" OnClientItemsRequesting="OnClientItemsRequesting"
                                OnItemsRequested="RadComboBox1_ItemsRequested" ShowMoreResultsBox="True" Skin="Office2007"
                                Width="245px">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                            </telerik:RadComboBox>--%>
                                <telerik:RadComboBox ID="RadComboBoxStatus" runat="server" 
                                    AllowCustomText="True" CausesValidation="False" 
                                    DataSourceID="SqlDataSourceStatus" DataTextField="StatusDesc" 
                                    DataValueField="StatusId" EmptyMessage="Buscar..." Filter="Contains" 
                                    style="margin-left: 0px" Width="215px" Culture="es-DO">
                                </telerik:RadComboBox>
                            
                            
                        </td>
                        <td class="CeldaNombreCampo" style="height: 8px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="CeldaNombreCampo" rowspan="1" style="font-weight: normal; width: 135px;
                            height: 8px">
                            &nbsp;</td>
                        <td class="CeldaNombreCampo" colspan="4" style="font-weight: normal; height: 8px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="CeldaNombreCampo" rowspan="1" style="font-weight: normal; height: 8px" colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                Font-Size="Small" HeaderText="Favor Revisar" Width="99%" Height="43px" />
                        </td>
                        <td class="CeldaNombreCampo" style="font-weight: normal; width: 179px; height: 8px">
                            &nbsp;</td></tr>
                    <tr>
                        <td class="CeldaNombreCampo" style="font-weight: normal; height: 8px; width: 135px;">
                            </td>
                        <td class="CeldaContenidoCampo" style="width: 238px; height: 8px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox1"
                                Font-Size="Smaller" InitialValue="0" Visible="False" Width="1px"></asp:RequiredFieldValidator></td>
                        <td class="CeldaContenidoCampo" style="width: 238px; height: 8px">
                        <asp:TextBox
                                    ID="TextBox5" runat="server" Visible="False"></asp:TextBox></td>
                        <td class="CeldaNombreCampo" style="font-weight: normal; width: 179px; height: 8px">
                        </td>
                        <td class="CeldaNombreCampo" style="font-weight: normal; width: 179px; height: 8px">
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                SelectCommand="SELECT  CitizenId,  CitizenName,NombreFull  FROM   vCitizens  where TipoSolicitanteId=1">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <TR><TD style="FONT-WEIGHT: normal; HEIGHT: 8px; width: 135px;" class="CeldaNombreCampo">
      <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        </TD><TD style="WIDTH: 238px; HEIGHT: 8px" class="CeldaContenidoCampo">
      <asp:SqlDataSource ID="SqlEmisionSerie" runat="server" 
          ConnectionString="<%$ ConnectionStrings:CN %>" 
          SelectCommand="SELECT [EmisionSerieID], [Serie] FROM [EmisionSerie]">
      </asp:SqlDataSource>
                        </TD>
                        <td class="CeldaContenidoCampo" style="width: 238px; height: 8px">
            <asp:SqlDataSource ID="SqlDataSourceStatus" runat="server" 
                ConnectionString="<%$ ConnectionStrings:CN %>" 
                SelectCommand="SELECT [StatusId], [StatusDesc] FROM [AppointmentStatus]">
            </asp:SqlDataSource>
                        </td>
                        <TD style="FONT-WEIGHT: normal; WIDTH: 179px; HEIGHT: 8px" class="CeldaNombreCampo"></TD>
                        <td class="CeldaNombreCampo" style="font-weight: normal; width: 179px; height: 8px">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                SelectCommand="SELECT  CitizenId,  CitizenName,NombreFull  FROM   vCitizens  where TipoSolicitanteId in(2,3)">
                            </asp:SqlDataSource>
                        </td>
                    </TR></TBODY></TABLE>
        &nbsp;
        </div> 
        </div>
                              </form>
</body>
</html>
