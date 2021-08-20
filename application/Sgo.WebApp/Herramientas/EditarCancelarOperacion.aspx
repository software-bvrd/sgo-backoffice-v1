<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditarCancelarOperacion.aspx.vb" Inherits="Sgo.WebApp.EditarCancelarOperacion" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cancelar Operación </title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .style1 {
            width: 208px;
        }

        .style2 {
            width: 252px;
        }

        .style5 {
            width: 252px;
            height: 26px;
        }

        .style6 {
            width: 208px;
            height: 26px;
        }

        .style7 {
            width: 200px;
        }

        .style8 {
            width: 200px;
            height: 26px;
        }

        .auto-style1 {
            width: 230px;
        }

        .auto-style2 {
            width: 578px;
        }

        .auto-style3 {
            width: 218px;
        }

        .auto-style4 {
            width: 218px;
            height: 26px;
        }

        .auto-style5 {
            width: 208px;
            height: 20px;
        }
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

        function CloseAndRebind() {
            GetRadWindow().Close();
            GetRadWindow().BrowserWindow.refreshGrid(null);
        }


        function CancelEdit() {
            GetRadWindow().Close();
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
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>

        <div>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server"
                SelectedIndex="0" MultiPageID="RadMultiPage1" CausesValidation="False"
                Width="100%">
                <Tabs>

                    <telerik:RadTab runat="server" Text="Cancelar" Selected="True" PageViewID="RadPageView1"
                        SelectedIndex="1">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Documentos" PageViewID="RadPageView2 "
                        SelectedIndex="2">
                    </telerik:RadTab>


                </Tabs>
            </telerik:RadTabStrip>

        </div>


        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Height="16px"
            SelectedIndex="0" Width="140px">
            <telerik:RadPageView ID="RadPageView1" runat="server" Width="140px" TabIndex="1" Selected="True">
                <div>
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style3">
                                <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" ImageStorageLocation="Cache" ImageUrl="~/Images/cancelaroperaciones.png" /></td>
                            <td class="style2">&#160;</td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Estatus :" Width="92px"></asp:Label></td>
                            <td class="style2">
                                <%--<telerik:RadTextBox ID="ddlEstatus" runat="server" Enabled="False" Height="24px" LabelWidth="64px" Style="margin-left: 0px" Width="300px"></telerik:RadTextBox>--%>
                                <telerik:RadDropDownList ID="ddlEstatus" runat="server" DataSourceID="SqlOperacionesCSVEstatus" DataTextField="Descripcion" DataValueField="CodigoEstatus" SelectedText="Cancelada" SelectedValue="Cancelada" Width="296px">
                                    <Items>
                                        <telerik:DropDownListItem runat="server" Value="Cancelada" Text="Cancelada" Selected="True" />
                                        <telerik:DropDownListItem runat="server" Value="No Liquidada" Text="No Liquidada" />
                                    </Items>
                                </telerik:RadDropDownList>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Fecha :" Width="92px"></asp:Label></td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtFecha" runat="server" Enabled="False" Height="24px" LabelWidth="64px" Style="margin-left: 0px" Width="300px"></telerik:RadTextBox>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="No. Oper :" Width="92px"></asp:Label></td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtNoOper" runat="server" Enabled="False" Height="24px" LabelWidth="64px" Style="margin-left: 0px" Width="300px"></telerik:RadTextBox>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label41" runat="server" Font-Bold="True" Text="Nercado :" Width="92px"></asp:Label></td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtMercado" runat="server" Enabled="False" Height="24px" LabelWidth="64px" Style="margin-left: 0px" Width="300px"></telerik:RadTextBox></td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="No.Oper DCV :" Width="92px"></asp:Label></td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtNoOperDCV" runat="server" Height="24px" LabelWidth="64px" Style="margin-left: 0px" Width="300px"></telerik:RadTextBox>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&#160;</td>
                            <td class="style2">
                                <asp:Label ID="lblMensaje" runat="server"></asp:Label></td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Motivo :" Width="92px"></asp:Label></td>
                            <td class="style2">
                                <telerik:RadTextBox ID="txtNombre" runat="server" Height="151px" LabelWidth="64px" Style="margin-left: 0px" Width="373px" TextMode="MultiLine"></telerik:RadTextBox>
                            </td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&#160;</td>
                            <td class="style5">&#160;</td>
                            <td class="style6"></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&#160;</td>
                            <td class="style2">
                                <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label><asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label><br />
                                <asp:Label ID="InjectScript" runat="server"></asp:Label>
                                <asp:SqlDataSource ID="SqlOperacionesCSVEstatus" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT * FROM [OperacionesCSVEstatus]"></asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server" TabIndex="2" Width="140px">
                <table class="style1">
                    <tr>
                        <td class="style5"></td>
                        <td class="auto-style1"></td>
                        <td class="style33"></td>
                        <td class="style5"></td>
                        <td class="style5"></td>
                        <td class="style5"></td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label40" runat="server" Font-Bold="False" Text="Nombre Documento :" Width="88px"></asp:Label></td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtNombreDoc" runat="server" Width="214px"></asp:TextBox></td>
                        <td class="style31">&#160;</td>
                        <td>
                            <asp:TextBox ID="txtArchivo" runat="server" Visible="False" Width="30px"></asp:TextBox>
                            <asp:TextBox ID="Codigo" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="35px"></asp:TextBox>
                        </td>
                        <td>&#160;</td>
                        <td>&#160;</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label33" runat="server" Font-Bold="False" Text="Archivo :" Width="70px"></asp:Label></td>
                        <td class="auto-style1">
                            <telerik:RadUpload ID="RadUpload1" runat="server" ControlObjectsVisibility="None" EnableTheming="True" Height="25px" Width="285px">
                                <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover" Select="Seleccionar" />
                            </telerik:RadUpload>
                            <asp:Button ID="Button2" runat="server" CausesValidation="False" Text="Subir" Width="59px" /></td>
                        <td class="style31">
                            <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Culture="es-DO" HeaderText="Información de Progreso" Width="363px">
                                <Localization Cancel="Cancelar" CurrentFileName="Subiendo Archivo: " ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: " TotalFiles="Total Archivos: " TransferSpeed="Velocidad: " Uploaded="Cargado" UploadedFiles="Archivos Cargados:"></Localization>
                            </telerik:RadProgressArea>
                        </td>
                        <td>
                            <telerik:RadProgressManager ID="RadProgressManager1" runat="server" Width="99px" />
                        </td>
                        <td>&#160;</td>
                        <td>&#160;</td>
                    </tr>
                    <tr>
                        <td class="style1" colspan="6">

                            <telerik:RadGrid ID="RadGridDocumento" runat="server" AllowSorting="True" DataSourceID="SqlDocumentos" GroupPanelPosition="Top">
                                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <MasterTableView AllowSorting="False" AutoGenerateColumns="False" DataSourceID="SqlDocumentos">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="nombre" FilterControlAltText="Filter nombre column" HeaderText="nombre" SortExpression="nombre" UniqueName="nombre">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Archivo" FilterControlAltText="Filter Archivo column" HeaderText="Archivo" SortExpression="Archivo" UniqueName="Archivo">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>


                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" colspan="6">
                            <asp:SqlDataSource ID="SqlDocumentos" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT IdOperacion, nombre, Adjunto, Archivo
                                                   FROM [dbo].[vOperacionesCSVDocumento] where idOperacion = @idOperacion">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="Codigo" Name="idOperacion" PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>

                        <td>



                        </td>
                        
                    </tr>
                    <tr>
                        <td>&#160;</td>
                        <td class="auto-style1">&#160;</td>
                        <td>&#160;</td>
                    </tr>
                </table>
                <br />
            </telerik:RadPageView>
        </telerik:RadMultiPage>

    </form>
</body>
</html>
