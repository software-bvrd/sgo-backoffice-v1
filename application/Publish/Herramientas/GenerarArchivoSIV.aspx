<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GenerarArchivoSIV.aspx.vb" Inherits="Sgo.WebApp.GenerarArchivoSIV" %>

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
                       <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/printpreview.gif"
                        Text="Consultar" ToolTip="Generar consulta." Value="3" CausesValidation="True">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Guardar" ToolTip="Guardar Información" Value="0">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/icon-download.png"
                        Text="Descargar Archivo" ToolTip="Descargar Archivo" Value="1">
                    </telerik:RadToolBarButton>
                 
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="2" CausesValidation="False">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
            <table style="width: 100%" cellpadding="0px 0px 8px 0px">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblmsg" runat="server" Width="95%" ForeColor="#FF3300"></asp:Label>
                    </td>
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
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <telerik:RadToolBar ID="RadToolBar2" runat="server" Width="100%">
                            <Items>                         
                                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Sep 1">
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/excel.png" Text="Excel" ToolTip="Exportar a Excel" Value="4">
                                </telerik:RadToolBarButton>
                                <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 7">
                                </telerik:RadToolBarButton>              
                           
                            </Items>
                        </telerik:RadToolBar>
                        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="False" CellSpacing="0" Culture="es-DO" EnableHeaderContextMenu="False" GridLines="None" ShowFooter="True" ShowGroupPanel="False">
                            <GroupingSettings CaseSensitive="False" />
                            <ExportSettings ExportOnlyData="True" FileName="Operaciones Realizadas" IgnorePaging="True" OpenInNewWindow="True">
                                <Pdf FontType="Embed" PageTitle="Operaciones Realizadas" />
                            </ExportSettings>
                            <ClientSettings AllowColumnsReorder="False" AllowDragToGroup="False">
                                <Selecting AllowRowSelect="True" />
                                <Resizing AllowColumnResize="True" AllowResizeToFit="True" EnableRealTimeResize="True" />
                                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                            </ClientSettings>
                            <MasterTableView CommandItemDisplay="TopAndBottom" DataKeyNames="rnc,fecha_oper"  ShowFooter="true" ShowGroupFooter="true">
                                <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False" ShowExportToCsvButton="false" ShowExportToExcelButton="false" ShowExportToPdfButton="false" ShowRefreshButton="false" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Created="True" FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <Columns></Columns>
                            </MasterTableView>
                            <PagerStyle Mode="NextPrevNumericAndAdvanced" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                        
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
