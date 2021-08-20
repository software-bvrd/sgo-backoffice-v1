<%@ Page Title="" Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Usuarios" Codebehind="Usuarios.aspx.vb" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link rel="Stylesheet" href="../Styles/Custom.css" />
     <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        #form1
        {
            font-weight: 700;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function CargarEditarVentana(sender, args) {
                    VentanaEditarFlotante("EditUsuario.aspx", 900, 300, "RadAjaxManager1")
                }


                window.blockConfirm = function (text, mozEvent, oWidth, oHeight, callerObj, oTitle) {
                    var ev = mozEvent ? mozEvent : window.event; //Moz support requires passing the event argument manually
                    //Cancel the event
                    ev.cancelBubble = true;
                    ev.returnValue = false;
                    if (ev.stopPropagation) ev.stopPropagation();
                    if (ev.preventDefault) ev.preventDefault();

                    //Determine who is the caller
                    var callerObj = ev.srcElement ? ev.srcElement : ev.target;

                    //Call the original radconfirm and pass it all necessary parameters
                    if (callerObj) {
                        //Show the confirm, then when it is closing, if returned value was true, automatically call the caller's click method again.
                        var callBackFn = function (arg) {
                            if (arg) {
                                callerObj["onclick"] = "";
                                if (callerObj.click) callerObj.click(); //Works fine every time in IE, but does not work for links in Moz
                                else if (callerObj.tagName == "A") //We assume it is a link button!
                                {
                                    try {
                                        eval(callerObj.href)
                                    } catch (e) { }
                                }
                            }
                        }

                        radconfirm(text, callBackFn, oWidth, oHeight, callerObj, oTitle);
                    }
                    return false;
                }



                function RefreshGrid() {
                    var masterTable = $find("<%= RadGrid1.ClientID %>")
                        .get_masterTableView();
                    masterTable.rebind();
                }



                function OnClientClickHandler(clickedButton) { // Button is clicked
                    function callbackFunction(arg) {
                        if (arg) {
                            // Continue postback
                            __doPostBack(clickedButton.name, ""); // Actual postback
                        }
                    }
                    //OnClientClick="return blockConfirm('Estas intentando cancelar viajes que probablemente tienen ventas, las cuales serán movidas a Standby, Confirma que desea continuar?', event, 330, 100,'','Cancelando Viaje');"
                    radconfirm("Estas intentando borrar un registro, Confirma que desea continuar?", callbackFunction, 300, 100, null, "Pregunta");
                }

                function OnClientClicked(button, args) {
                    if (window.confirm("Estas intentando borrar un registro, Confirma que desea continuar?")) {
                        button.set_autoPostBack(true);
                    } else {
                        button.set_autoPostBack(false);
                    }
                }
            </script>
        </telerik:RadCodeBlock>
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server"></telerik:RadScriptManager>
 
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                    <Items>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" Text="Nuevo"
                            Value="0">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 1">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                            Text="Mover" ToolTip="Mover a Ventana" Value="7">
                        </telerik:RadToolBarButton>

                         <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="3" CausesValidation="False" />

                        <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 8">
                        </telerik:RadToolBarButton>

                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>

                    </Items>
                </telerik:RadToolBar>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" width="100%" HorizontalAlign="NotSet"
        LoadingPanelID="RadAjaxLoadingPanel1">
            <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" DataSourceID="SqlDataSource1"
            GridLines="None" AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True"
            culture="es" AutoGenerateColumns="False">
                <GroupingSettings CaseSensitive="False" />
                <ExportSettings ExportOnlyData="True" FileName="Usuarios" 
                    OpenInNewWindow="True">
                    <Pdf PageTitle="Usuarios" Title="Usuarios" />
                </ExportSettings>
                <ValidationSettings CommandsToValidate="Perform,Insert" />
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                    <ClientEvents OnRowDblClick="CargarEditarVentana" />
                </ClientSettings>
                <MasterTableView datakeynames="IdUsuario" datasourceid="SqlDataSource1"  CommandItemSettings-ShowAddNewRecordButton="false"
                    CommandItemDisplay="Bottom">
                    <CommandItemSettings ExportToPdfText="Export to PDF" ShowExportToCsvButton="True" ShowExportToExcelButton="True"  ShowRefreshButton="false"
                        ShowExportToPdfButton="True"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="IdUsuario" DataType="System.Int32" Display="False" FilterControlAltText="Filter IdUsuario column" HeaderText="IdUsuario" ReadOnly="True" SortExpression="IdUsuario" UniqueName="IdUsuario">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre" UniqueName="Nombre">
                        </telerik:GridBoundColumn>        
                        <telerik:GridBoundColumn DataField="CorreoElectronico" FilterControlAltText="Filter CorreoElectronico column" HeaderText="CorreoElectronico" SortExpression="CorreoElectronico" UniqueName="CorreoElectronico">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreUsuario" FilterControlAltText="Filter NombreUsuario column" HeaderText="NombreUsuario" SortExpression="NombreUsuario" UniqueName="NombreUsuario">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Perfil" FilterControlAltText="Filter Perfil column" HeaderText="Perfil" SortExpression="Perfil" UniqueName="Perfil">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Estado" FilterControlAltText="Filter Estado column" HeaderText="Estado" SortExpression="Estado" UniqueName="Estado">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <PagerStyle PageSizeControlType="RadComboBox" />
                </MasterTableView>
                <PagerStyle PageSizeControlType="RadComboBox" />
                <FilterMenu EnableImageSprites="False"></FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
            </telerik:RadGrid>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
            SelectCommand="SELECT * FROM [vUsuarios]"></asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"
            Behaviors="Close, Maximize, Move" EnableViewState="False" Height="450px"
            Modal="True" VisibleStatusbar="False" Width="769px" OnClientClose="RefreshGrid"></telerik:RadWindowManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <br />
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server"></telerik:RadAjaxLoadingPanel>
        </telerik:RadAjaxPanel>
        <p>
        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </p>
    </form>
</body>

 </html>