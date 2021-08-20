<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SubastaOrdenesRechazadas.aspx.vb" Inherits="Sgo.WebApp.SubastaOrdenesRechazadas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Registro Ordenes Rechazadas</title>

    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <style type="text/css">
        .style1
        {
            height: 28px;
            width: 876px;
        }

        .style2
        {
            width: 89px;
        }

        .style3
        {
        }

        .style4
        {
            width: 89px;
        }

        .style5
        {
            height: 23px;
        }

        .style32
        {
            width: 434px;
            height: 23px;
        }

        .style33
        {
            height: 23px;
        }

        .style27
        {
            width: 434px;
        }

        .style31
        {
        }



        .style17
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

        .style34
        {
            height: 23px;
            width: 10px;
        }

        .style35
        {
            width: 10px;
        }

        .style36
        {
            width: 968px;
        }

        .style37
        {
            height: 28px;
            width: 968px;
        }

        .style38
        {
            width: 850px;
        }

        .style39
        {
            height: 28px;
            width: 850px;
        }

        .style41
        {
            height: 140px;
        }

        </style>
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




    </script>
    <form id="form1" runat="server" style="background-color: #F1F5FB">
        <div>


            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                <Items>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" Text="Nuevo"
                        ToolTip="Crear Nuevo" Value="2" CausesValidation="False">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 5">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Guardar" ToolTip="Guardar Información" Value="0"
                        >
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 6">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="3" CausesValidation="False" Enabled ="false"  />

                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Separador">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="1" CausesValidation="False">
                    </telerik:RadToolBarButton>

                </Items>
            </telerik:RadToolBar>
            

            <br />
            <div> <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label></div>
                    <table class="style1">

                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label38" runat="server" Text="Fecha :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadDatePicker ID="txtFecha" runat="server" Culture="es-DO">
                                    <Calendar ID="Calendar3" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x" runat="server">
                                    </Calendar>
                                    <DateInput ID="DateInput3" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                        LabelWidth="40%" runat="server" value="">
                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                        <FocusedStyle Resize="None"></FocusedStyle>

                                        <DisabledStyle Resize="None"></DisabledStyle>

                                        <InvalidStyle Resize="None"></InvalidStyle>

                                        <HoveredStyle Resize="None"></HoveredStyle>

                                        <EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>
                                    <DatePopupButton
                                        ToolTip="Seleccionar Calendario." />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style31">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese una fecha" ControlToValidate="txtFecha" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                        </tr>
                                                <tr>
                            <td class="style5">
                                <asp:Label ID="Label39" runat="server" Font-Bold="False"
                                    Text="Tipo Libro Ordenes:" Width="124px"></asp:Label>
                                </td>
                            <td class="style32">
                                <telerik:RadComboBox ID="cboTipoLibroOrdenes" runat="server"
                                    AllowCustomText="True" CausesValidation="False"
                                    DataSourceID="SqlTipoLibroOrdenes" DataTextField="TipoLibroOrdenes"
                                    DataValueField="TipoLibroOrdenes" EmptyMessage="Buscar..." Filter="Contains"
                                    Style="margin-left: 0px" Width="215px" Culture="es-DO" TabIndex="3" AutoPostBack="True">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style33">
                                <asp:RequiredFieldValidator ID="ValidatorTipoDocumento" runat="server"
                                    ControlToValidate="cboTipoLibroOrdenes" ErrorMessage="Tipo Libro Ordenes"
                                    Font-Size="Small" ForeColor="Red" Height="16px" SetFocusOnError="True"
                                    ToolTip="Debe seleccionar una opción." Width="352px">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                                                        <tr>
                            <td class="style5">
                                <asp:Label ID="Label1" runat="server" Font-Bold="False"
                                    Text="Emisión:" Width="124px"></asp:Label>
                                </td>
                            <td class="style32">
                                <telerik:RadComboBox ID="cboEmision" runat="server"
                                    AllowCustomText="True" CausesValidation="False"
                                    DataSourceID="SqlEmision" DataTextField="CodEmisionBVRD"
                                    DataValueField="CodEmisionBVRD" EmptyMessage="Buscar..." Filter="Contains"
                                    Style="margin-left: 0px" Width="215px" Culture="es-DO" TabIndex="3" AutoPostBack="True">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style5">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="cboEmision" ErrorMessage="Tipo Emision"
                                    Font-Size="Small" ForeColor="Red" Height="16px" SetFocusOnError="True"
                                    ToolTip="Debe seleccionar una opción." Width="352px">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label40" runat="server"  Text="Monto:"
                                    Width="88px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadNumericTextBox ID="txtMonto" runat="server"></telerik:RadNumericTextBox>        
                    
                            </td>
                            <td class="style31">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMonto" ErrorMessage="Ingrese un valor." ForeColor="Red" ToolTip="Ingrese un valor.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style27">
                                &nbsp;</td>
                            <td class="style31">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="3">
                                <telerik:RadGrid ID="RadGridOrdenesRechazadas" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" DataSourceID="SqlTodasOrdenes"
                                    GridLines="Horizontal" PageSize="20">
                                    <ExportSettings ExportOnlyData="True" FileName="Lista de Ordenes"
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Lista de Ordenes" Subject="Lista de Ordenes" />
                                    </ExportSettings>
                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True"
                                        ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Lista Ordenes Rechazadas" CommandItemDisplay="Bottom"
                                        CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="SubastaOrdenesRechazadasID"
                                        DataSourceID="SqlTodasOrdenes" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" ShowExportToCsvButton="True" />
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="SubastaOrdenesRechazadasID"
                                                DataType="System.Int32"
                                                FilterControlAltText="Filter SubastaOrdenesRechazadasID column"
                                                HeaderText="SubastaOrdenesRechazadasID" ReadOnly="True"
                                                SortExpression="SubastaOrdenesRechazadasID" UniqueName="SubastaOrdenesRechazadasID"
                                                Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" DataFormatString="{0:MM/dd/yyyy}"
                                                DataType="System.DateTime" FilterControlAltText="Filter Fecha column"
                                                HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoLibroOrdenes"
                                                FilterControlAltText="Filter TipoLibroOrdenes column" HeaderText="Tipo Libro Ordenes"
                                                SortExpression="TipoLibroOrdenes" UniqueName="TipoLibroOrdenes">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="CodEmisionBVRD"
                                                FilterControlAltText="Filter CodEmisionBVRD column" HeaderText="Emisión"
                                                SortExpression="CodEmisionBVRD" UniqueName="CodEmisionBVRD">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridNumericColumn DataFormatString="{0:###,##0.00}" DataField="Monto"
                                                DataType="System.Decimal"
                                                FilterControlAltText="Filter Monto column"
                                                HeaderText="Monto" SortExpression="Monto"
                                                UniqueName="Monto" ItemStyle-HorizontalAlign="Right">
                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                            </telerik:GridNumericColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        </table>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
            <asp:Label ID="InjectScript" runat="server"></asp:Label>
            <br />
                                <asp:SqlDataSource ID="SqlEmision" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT DISTINCT CodEmisionBVRD FROM ResultadoProrrateo  ORDER BY CodEmisionBVRD"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlTipoLibroOrdenes" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT DISTINCT RTRIM(TipoLibroOrdenes) AS TipoLibroOrdenes FROM ResultadoProrrateo WHERE TipoLibroOrdenes  IS NOT NULL ORDER BY TipoLibroOrdenes "></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlTodasOrdenes" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT [SubastaOrdenesRechazadasID]
      ,[Fecha]
      ,[TipoLibroOrdenes]
      ,[CodEmisionBVRD]
      ,[Monto]
  FROM [SubastaOrdenesRechazadas]
GO
">
                                </asp:SqlDataSource>
            <asp:TextBox ID="txtSubastaOrdenesRechazadasID" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
    </form>
</body>


</html>
