<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditarUsuariosSiopel.aspx.vb" Inherits="Sgo.WebApp.EditarUsuariosSiopel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Usuario Siopel</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .style1 {
            width: 208px;
        }

        .style2 {
            width: 252px;
        }

        .style3 {
            width: 201px;
        }

        .style4 {
            width: 204px;
        }

        .auto-style2 {
            width: 252px;
            height: 52px;
        }

        .auto-style3 {
            width: 201px;
            height: 52px;
        }

        .auto-style5 {
            width: 252px;
            height: 25px;
        }

        .auto-style6 {
            width: 201px;
            height: 25px;
        }

        .auto-style8 {
            width: 581px;
        }

        .auto-style10 {
            width: 252px;
            height: 30px;
        }

        .auto-style11 {
            width: 201px;
            height: 30px;
        }

        .auto-style13 {
            width: 252px;
            height: 29px;
        }

        .auto-style14 {
            width: 201px;
            height: 29px;
        }

        .auto-style15 {
            width: 162px;
        }

        .auto-style16 {
            width: 162px;
            height: 30px;
        }

        .auto-style17 {
            width: 162px;
            height: 25px;
        }

        .auto-style18 {
            width: 162px;
            height: 29px;
        }

        .auto-style19 {
            width: 162px;
            height: 52px;
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
            <table class="auto-style8">
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="Label9" runat="server" Text="Puesto Bolsa/Otra Entidad :" Width="173px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadComboBox ID="RadComboPuestoBolsa" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlPuestoBolsa"
                            DataTextField="Nombre" DataValueField="PuestoBolsaID"
                            EmptyMessage="Buscando..." Filter="Contains" Height="70px" Width="331px"
                            Style="margin-left: 4px" LoadingMessage="Cargando..."
                            OnClientFocus="onFocus" TabIndex="3">
                        </telerik:RadComboBox>
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="Label11" runat="server" Text="Código PB/Otra Entidad :" Width="173px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <telerik:RadTextBox ID="txtCodigoEntidad" runat="server" Height="21px" LabelWidth="64px"
                            Width="331px" Style="margin-left: 4px" Enabled="True">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style11"></td>
                </tr>

                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="Label1" runat="server" Text="Nombre del Operador:" Width="169px"
                            Font-Bold="True" Height="16px"></asp:Label>
                    </td>

                    <td class="auto-style5">
                        <telerik:RadComboBox ID="txtNombre" runat="server" AllowCustomText="false"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlCorredores"
                            DataTextField="Nombre" DataValueField="UsuarioSiopelID"
                            EmptyMessage="Buscando..." Filter="Contains" Height="70px" Width="331px"
                            Style="margin-left: 4px" LoadingMessage="Cargando..."
                            OnClientFocus="onFocus" TabIndex="3">
                        </telerik:RadComboBox>
                    </td>

                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtNombre" ErrorMessage="Name" Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="16px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>

                </tr>

                <tr>
                    <td class="auto-style18">
                        <asp:Label ID="Label10" runat="server" Text="Código del Operador :" Width="134px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <telerik:RadTextBox ID="txtAgente" runat="server" Height="20px" LabelWidth="64px"
                            Width="327px" TabIndex="1">
                        </telerik:RadTextBox>
                    </td>
                    <td class="auto-style14"></td>
                </tr>

                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="Label8" runat="server" Text="Tipo Usuario :" Width="137px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="True"
                            AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoUsuariosSiopel"
                            DataTextField="Nombre" DataValueField="BO_TipoUsuarios_Siopel_TID"
                            EmptyMessage="Buscando..." Filter="Contains" Height="70px" Width="236px"
                            Style="margin-left: 4px" LoadingMessage="Cargando..." ShowDropDownOnTextboxClick="true"
                            OnClientFocus="onFocus" TabIndex="2">
                        </telerik:RadComboBox>
                    </td>
                    <td class="style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="RadComboBox1" ErrorMessage="Tipo Instrumento"
                            Font-Size="Small" ForeColor="Red"
                            SetFocusOnError="True" Width="16px" ToolTip="Debe ingresar un nombre válido.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="Label7" runat="server" Text="Activo :" Width="70px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" TabIndex="4" />
                    </td>
                    <td class="style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style19">
                        <asp:SqlDataSource ID="SqlTipoUsuariosSiopel" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="SELECT BO_TipoUsuarios_Siopel_TID, Nombre, Activo FROM BO_TipoUsuarios_Siopel_T WHERE (Activo = @Activo) ORDER BY Nombre">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="True" Name="Activo" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                        <asp:SqlDataSource ID="SqlPuestoBolsa" runat="server"
                            ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand="
                                SELECT dbo.PuestoBolsa.PuestoBolsaID, 
                                       dbo.PuestoBolsa.Nombre, 
                                       dbo.PuestoBolsa.TipoParticipanteID
                                FROM dbo.PuestoBolsa
                                WHERE dbo.PuestoBolsa.Activo = 1
                                  ORDER BY 2"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                        <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="InjectScript" runat="server"></asp:Label>
                        <asp:SqlDataSource ID="SqlCorredores" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                            SelectCommand=" SELECT NuevoPuestoBolsaID as [PuestoBolsaID],
                                        [Nombre],
                                        [Activo],
                                        [PuestoBolsaCorredorID],
                                        'C-' + CAST([PuestoBolsaCorredorID] AS VARCHAR(8)) AS UsuarioSiopelID
                                FROM   dbo.vPuestoBolsaCorredores AS P
                                WHERE  P.Movimiento IN ('C', 'T')
                                        -- AND P.FechaMovimiento = (
                                        --  SELECT TOP(1)              FechaMovimiento
                                        --  FROM   dbo.HistorialCorredor
                                        --  WHERE  PuestoBolsaCorredorID = P.PuestoBolsaCorredorID
                                        --  AND Movimiento IN ('C', 'T')
                                        --  ORDER BY  FechaMovimiento     DESC)
                                        AND p.nombre IS NOT NULL
                                        AND p.licencia IS NOT NULL
                                        AND p.Activo = 1
                                            AND (([Activo] = @Activo) AND (p.NuevoPuestoBolsaID = @PuestoBolsaID))
           
 
                                    UNION
 
                                SELECT pbd.PuestoBolsaID,
                                        pbd.Nombre,
                                        1                           AS Activo,
                                        pbd.PuestoBolsaDirectivoID  AS PuestoBolsaCorredorID,
                                        'D-' + CAST([PuestoBolsaDirectivoID] AS VARCHAR(8)) AS UsuarioSiopelID
                                FROM   PuestoBolsaDirectivo        AS pbd
                                where ([PuestoBolsaID] = @PuestoBolsaID)
                                ORDER BY
                                        P.Nombre  ">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="True" Name="Activo" Type="Boolean" />
                                <asp:ControlParameter ControlID="RadComboPuestoBolsa" Name="PuestoBolsaID" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
        </div>
    </form>
</body>


</html>

