<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.EditarCorredor" Culture="es-DO" CodeBehind="EditarCorredor.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }

        .auto-style3 {
            width: 93px;
        }
        .auto-style4 {
            height: 30px;
        }
    </style>
</head>

<body style="background-color: #F1F5FB;">

    <form id="form1" runat="server" style="background-color: #F1F5FB">

        <div style="height: auto">

            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server"
                SelectedIndex="0" MultiPageID="RadMultiPage1" CausesValidation="False"
                Width="100%">
                <Tabs>
                    <telerik:RadTab runat="server" Text="Datos personales" PageViewID="RadPageView1"
                        SelectedIndex="1" Selected="True">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Licencia" PageViewID="RadPageView2"
                        SelectedIndex="2">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" PageViewID="RadPageView3"
                        Text="Documentos" SelectedIndex="3">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" PageViewID="RadPageView4"
                        Text="Historial" SelectedIndex="4">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>

            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%" TabIndex="99">

                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png"
                        Text="Nuevo" ToolTip="Crear Nuevo" Value="0" CausesValidation="False">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server"
                        Text="Button 4" IsSeparator="True" TabIndex="1">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Guardar" ToolTip="Guardar Información" Value="1" TabIndex="2" CausesValidation="False">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True" TabIndex="3" Text="Button 6">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server"
                        ImageUrl="~/Images/delete2.gif" Text="Borrar" Value="2" TabIndex="4" CausesValidation="False">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1" TabIndex="5">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="3" CausesValidation="False" TabIndex="6">
                    </telerik:RadToolBarButton>
                </Items>

            </telerik:RadToolBar>

            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Height="41px" Width="893px" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageView1" runat="server" Height="427px" Width="144px">
                    <table class="style1">
                        <tr>
                            <td class="style5"></td>
                            <td class="style34" colspan="2">
                                <asp:Label ID="Guardado" runat="server" Font-Bold="True" ForeColor="Red" Width="209px"></asp:Label>
                            </td>
                            <td class="style35"></td>
                            <td class="style37" rowspan="4">&nbsp;</td>
                            <td class="style37" rowspan="6">
                                <telerik:RadBinaryImage ID="FotoCorredor" runat="server" AutoAdjustImageControlSize="False" ResizeMode="Fill" Width="100px" />
                                <asp:Label ID="MensajeLogo" runat="server" Font-Bold="False" Width="265px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="Nombre :" Width="70px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadTextBox ID="txtNombreCorredor" runat="server" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style14">
                                <asp:RequiredFieldValidator ID="ValidatorNombreCorredor" runat="server" ControlToValidate="txtNombreCorredor" ErrorMessage="Ingrese un nombre." Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Ingrese un nombre de corredor." Width="19px">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label64" runat="server" Font-Bold="False" Text="Cédula:" Width="70px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadMaskedTextBox ID="txtCedula" runat="server" Mask="###-#######-#" TabIndex="1">
                                </telerik:RadMaskedTextBox>
                            </td>
                            <td class="style14">
                                <asp:RequiredFieldValidator ID="ValidatorCedulaCorredor" runat="server" ControlToValidate="txtCedula" ErrorMessage="Ingrese una Cédula." Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Problemas con la Cédula o Código BVRD, Verifique pueden estar repetidos" Width="19px">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label28" runat="server" Font-Bold="False" Text="Dirección :" Width="75px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadTextBox ID="txtDireccionCorredor" runat="server" Width="265px" TabIndex="2">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style14">
                                <asp:RequiredFieldValidator ID="ValidatorDireccionCorredor0" runat="server" ControlToValidate="txtDireccionCorredor" ErrorMessage="Ingrese un dirección." Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Ingrese un nombre de corredor." Width="19px">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Pais/Prov./Sector:" Width="86px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadTextBox ID="txtDireccion2" runat="server" Width="265px" TabIndex="3">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style14"></td>
                        </tr>

                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label29" runat="server" Font-Bold="False" Text="Teléfono oficina:" Width="112px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadMaskedTextBox ID="txtTelefonoCorredor" runat="server" Mask="(###) ###-####" TabIndex="4">
                                </telerik:RadMaskedTextBox>
                            </td>
                            <td class="style14" rowspan="2">&nbsp;</td>
                            <td class="style37">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label66" runat="server" Font-Bold="False" Text="Teléfono casa:" Width="112px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadMaskedTextBox ID="txtTelefonoCasa" runat="server" Mask="(###) ###-####" TabIndex="5">
                                </telerik:RadMaskedTextBox>
                            </td>
                            <td class="style37">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label67" runat="server" Font-Bold="False" Text="Celular:" Width="112px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadMaskedTextBox ID="txtTelefonoCelular" runat="server" Mask="(###) ###-####" TabIndex="6">
                                </telerik:RadMaskedTextBox>
                            </td>
                            <td class="style14">
                                <asp:RequiredFieldValidator ID="ValidatorDireccionCorredor1" runat="server" ControlToValidate="txtDireccionCorredor" ErrorMessage="Ingrese un dirección." Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Ingrese un nombre de corredor." Width="19px">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style37">
                                <asp:Label ID="lblFoto" runat="server" Font-Bold="False" Text="Foto:" Width="90px"></asp:Label>
                            </td>
                            <td class="style37">

                                <telerik:RadUpload ID="RadUpload1" runat="server" ControlObjectsVisibility="None" EnableTheming="True" Height="25px" TabIndex="13" Width="230px">
                                    <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover" Select="Seleccionar" />
                                </telerik:RadUpload>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label30" runat="server" Font-Bold="False" Text="Email Oficina:" Width="109px"></asp:Label>
                            </td>
                            <td class="auto-style4" colspan="2">
                                <telerik:RadTextBox ID="txtEmailCorredor" runat="server" Width="241px" TabIndex="7">
                                </telerik:RadTextBox>
                            </td>
                            <td class="auto-style4"></td>
                            <td class="auto-style4"></td>
                            <td class="auto-style4">
                                <asp:Button ID="BtnSubirLogo" runat="server" CausesValidation="False" Text="Subir" Width="59px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label68" runat="server" Font-Bold="False" Text="Email Personal:" Width="108px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadTextBox ID="txtEmailPersonal" runat="server" Width="241px" TabIndex="8">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style14">&nbsp;</td>
                            <td class="style37">&nbsp;</td>
                            <td class="style37">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label69" runat="server" Font-Bold="False" Text="Nota:" Width="108px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadTextBox ID="txtNota" runat="server" Width="265px" Height="55px" TabIndex="9" TextMode="MultiLine">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style14">&nbsp;</td>
                            <td class="style37">&nbsp;</td>
                            <td class="style37">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label71" runat="server" Font-Bold="False" Style="height: 16px" Text="Código BVRD :" Width="90px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadTextBox ID="txtCodBVRD" runat="server" TabIndex="10" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style14">
                                <asp:RegularExpressionValidator ID="emailValidator" runat="server" Display="Dynamic"
                                    ErrorMessage="Por favor, ingrese un e-mail válido." ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                    ControlToValidate="txtEmailCorredor" ForeColor="Red" ToolTip="Por favor, ingrese un e-mail válido.">*</asp:RegularExpressionValidator>
                            </td>
                            <td class="style37">&nbsp;</td>
                            <td class="style37">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label72" runat="server" Font-Bold="False" Text="Código BLID :" Width="92px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <telerik:RadTextBox ID="txtCodBLUUID" runat="server" TabIndex="11" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style14" rowspan="2">&nbsp;</td>
                            <td class="style37" rowspan="6">&nbsp;</td>
                            <td class="style37" rowspan="6">
                                <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Culture="es-DO" HeaderText="Información de Progreso" Height="220px" Width="351px">
                                    <Localization Cancel="Cancelar" CurrentFileName="Subiendo Archivo: " ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: " TotalFiles="Total Archivos: " TransferSpeed="Velocidad: " Uploaded="Cargado" UploadedFiles="Archivos Cargados:" />
                                </telerik:RadProgressArea>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">Participante Mercado</td>
                            <td class="style16" colspan="2">
                                <telerik:RadComboBox ID="cbPuestoBolsaId" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlPuestoBolsa" DataTextField="Nombre" DataValueField="PuestoBolsaID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="280px" TabIndex="12">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label63" runat="server" Font-Bold="False" Text="Activo :" Width="90px"></asp:Label>
                            </td>
                            <td class="style16" colspan="2">
                                <asp:CheckBox ID="CheckBoxCorredor" runat="server" Checked="True" />
                            </td>
                            <td class="style14">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>
                            <td class="style16" colspan="2">
                                <asp:SqlDataSource ID="SqlPuestoBolsa" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="select PuestoBolsaID,Nombre from dbo.vPuestoBolsa 
                                UNION ALL
                                select 0 AS PuestoBolsaID,'  Sin puesto de bolsa' AS Nombre  
                                ORDER BY Nombre"></asp:SqlDataSource>
                            </td>
                            <td class="style14">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="3">
                                <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                                <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                                <telerik:RadProgressManager ID="RadProgressManager2" runat="server" Width="99px" />
                            </td>
                            <td class="style1">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="2">
                                <asp:SqlDataSource ID="SqlDatosPersonales" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT * FROM [TipoMoneda]"></asp:SqlDataSource>
                                <telerik:RadNotification ID="Notification1" runat="server" Animation="Fade" AutoCloseDelay="4000" ContentIcon="deny" EnableRoundedCorners="true" EnableShadow="True" Height="83px" Opacity="95" Position="BottomRight" RenderMode="Lightweight" Title="Información" TitleIcon="warning" Width="238px">
                                </telerik:RadNotification>
                            </td>
                            <td class="style1" colspan="2">
                                <asp:TextBox ID="txtCodigoPuestoBolsa" runat="server" Enabled="False" ReadOnly="True" Width="61px" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="txtCodigoPuestoBolsaCorredorID" runat="server" Enabled="False" ReadOnly="True" Width="61px" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView2" runat="server">
                    <table class="style1">
                        <tr>
                            <td class="style36">
                                <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="Licencia" Width="89px"></asp:Label>
                                <hr />
                            </td>
                            <td class="style38">
                                <asp:Label ID="Label53" runat="server" Font-Bold="True" Text="No." Width="89px"></asp:Label>
                                <hr />
                            </td>
                            <td class="style37">
                                <asp:Label ID="Label54" runat="server" Font-Bold="True" Text="Fecha de Inicio" Width="133px"></asp:Label>
                                <hr />
                            </td>
                            <td class="style37">
                                <asp:Label ID="Label55" runat="server" Font-Bold="True" Text="Fecha de Vencimiento" Width="151px"></asp:Label>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label57" runat="server" Font-Bold="True" Text="BVRD:" Width="101px"></asp:Label>
                            </td>
                            <td class="style40">
                                <telerik:RadTextBox ID="txtLicencia" runat="server" Height="24px" LabelWidth="64px" Width="151px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style18">
                                <telerik:RadDatePicker ID="txtFechaInicioLicencia" runat="server" Culture="es-DO" Style="margin-left: 4px" Width="140px" TabIndex="1">
                                    <Calendar ID="Calendar1" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput ID="DateInput1" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="1">
                                    </DateInput>
                                    <DatePopupButton TabIndex="1" />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style18">
                                <telerik:RadDatePicker ID="txtFechaVenceLicencia" runat="server" Culture="es-DO" Style="margin-left: 4px" Width="140px" TabIndex="2">
                                    <Calendar ID="Calendar2" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput ID="DateInput2" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="2">
                                    </DateInput>
                                    <DatePopupButton TabIndex="2" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label59" runat="server" Font-Bold="True" Text="SIV:" Width="101px"></asp:Label>
                            </td>
                            <td class="style40">
                                <telerik:RadTextBox ID="txtLicenciaSIV" runat="server" Width="151px" TabIndex="3">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style18">
                                <telerik:RadDatePicker ID="txtFechaInicioLicenciaSIV" runat="server" Culture="es-DO" Style="margin-left: 4px" Width="140px" TabIndex="4">
                                    <Calendar ID="Calendar3" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput ID="DateInput3" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="4">
                                    </DateInput>
                                    <DatePopupButton TabIndex="4" />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style18">
                                <telerik:RadDatePicker ID="txtFechaVenceLicenciaSIV" runat="server" Culture="es-DO" Style="margin-left: 4px" Width="140px" TabIndex="5">
                                    <Calendar ID="Calendar4" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput ID="DateInput4" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="5">
                                    </DateInput>
                                    <DatePopupButton TabIndex="5" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td class="style17">
                                <asp:Label ID="Label70" runat="server" Font-Bold="True" Text="Nota:" Width="101px"></asp:Label>
                            </td>
                            <td class="style40">
                                <telerik:RadTextBox ID="txtNotaLicencia" runat="server" Height="47px" TabIndex="6" TextMode="MultiLine" Width="163px">
                                </telerik:RadTextBox>
                            </td>
                            <td class="style18">
                                <asp:Label ID="lblMensajeLicencia" runat="server"></asp:Label>
                            </td>
                            <td class="style18">
                                <asp:TextBox ID="txtCodigoPuestoBolsaCorredorLicenciaID" runat="server" Enabled="False" ReadOnly="True" Visible="False" Width="61px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"></td>
                            <td class="auto-style1"></td>
                            <td class="auto-style1"></td>
                            <td class="auto-style1"></td>
                        </tr>
                        <tr>
                            <td class="style5" colspan="4">
                                <telerik:RadGrid ID="RadGridCorredorLicencia" runat="server" AllowSorting="True" CellSpacing="0" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlCorredorLicencia" Width="714px">
                                    <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True"
                                        EnablePostBackOnRowClick="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="PuestoBolsaCorredorLicenciaID" DataSourceID="SqlCorredorLicencia">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaCorredorID" DataType="System.Int32" FilterControlAltText="Filter PuestoBolsaCorredorID column" HeaderText="PuestoBolsaCorredorID" SortExpression="PuestoBolsaCorredorID" UniqueName="PuestoBolsaCorredorID" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaCorredorLicenciaID" DataType="System.Int32" FilterControlAltText="Filter PuestoBolsaCorredorLicenciaID column" HeaderText="PuestoBolsaCorredorLicenciaID" ReadOnly="True" SortExpression="PuestoBolsaCorredorLicenciaID" UniqueName="PuestoBolsaCorredorLicenciaID" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Licencia" FilterControlAltText="Filter Licencia column" HeaderText="Licencia" SortExpression="Licencia" UniqueName="Licencia">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaLicencia" DataType="System.DateTime" FilterControlAltText="Filter FechaLicencia column" HeaderText="Fecha Inicio" SortExpression="FechaLicencia" UniqueName="FechaLicencia" DataFormatString="{0:dd/MM/yyyy}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaLicenciaVence" DataType="System.DateTime" FilterControlAltText="Filter FechaLicenciaVence column" HeaderText="Fecha Vencimiento" SortExpression="FechaLicenciaVence" UniqueName="FechaLicenciaVence" DataFormatString="{0:dd/MM/yyyy}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="LicenciaSIV" FilterControlAltText="Filter LicenciaSIV column" HeaderText="LicenciaSIV" SortExpression="LicenciaSIV" UniqueName="LicenciaSIV">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaLicenciaSIV" DataType="System.DateTime" FilterControlAltText="Filter FechaLicenciaSIV column" HeaderText="Fecha inicio" SortExpression="FechaLicenciaSIV" UniqueName="FechaLicenciaSIV" DataFormatString="{0:dd/MM/yyyy}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaLicenciaSIVVence" DataType="System.DateTime" FilterControlAltText="Filter FechaLicenciaSIVVence column" HeaderText="Fecha Vencimiento" SortExpression="FechaLicenciaSIVVence" UniqueName="FechaLicenciaSIVVence" DataFormatString="{0:dd/MM/yyyy}">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td class="style5" colspan="4">
                                <%--<asp:SqlDataSource ID="SqlCorredorLicencia" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT PuestoBolsaCorredorID, PuestoBolsaCorredorLicenciaID, Licencia, FechaLicencia, FechaLicenciaVence, LicenciaSIV, FechaLicenciaSIV, FechaLicenciaSIVVence FROM PuestoBolsaCorredorLicencia WHERE (PuestoBolsaCorredorID = @PuestoBolsaCorredorID) ORDER BY  FechaLicenciaSIV DESC, FechaLicencia DESC">--%>
                                <asp:SqlDataSource ID="SqlCorredorLicencia" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT PuestoBolsaCorredorID, PuestoBolsaCorredorLicenciaID, Licencia, FechaLicencia, FechaLicenciaVence, LicenciaSIV, FechaLicenciaSIV, FechaLicenciaSIVVence FROM PuestoBolsaCorredorLicencia WHERE (PuestoBolsaCorredorID = @PuestoBolsaCorredorID) ORDER BY  FechaLicenciaSIV DESC, FechaLicencia DESC">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtCodigoPuestoBolsaCorredorID" Name="PuestoBolsaCorredorID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView3" runat="server">
                    <table class="style1">
                        <tr>
                            <td class="auto-style3"></td>
                            <td class="style32">
                                <asp:Label ID="lblMensajeDocumento" runat="server"></asp:Label>
                            </td>
                            <td class="style32">&nbsp;</td>
                            <td class="style33"></td>
                            <td class="style5"></td>
                            <td class="style5"></td>
                            <td class="style5"></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label38" runat="server" Font-Bold="True" Text="Fecha :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadDatePicker ID="txtFechaDocumento" runat="server" Culture="es-DO">
                                    <Calendar ID="Calendar5" UseColumnHeadersAsSelectors="False" runat="server" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput ID="DateInput5" DateFormat="dd/MM/yyyy" runat="server" DisplayDateFormat="dd/MM/yyyy"
                                        LabelWidth="40%">
                                    </DateInput>
                                    <DatePopupButton />
                                </telerik:RadDatePicker>
                            </td>
                            <td class="style27">
                                <asp:RequiredFieldValidator ID="ValidatorFechaDocumento" runat="server" ControlToValidate="txtFechaDocumento" ErrorMessage="Fecha" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido." Width="46px">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="style31">&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="ValidatorTipoDocumento" runat="server" ControlToValidate="RadComboBox1" ErrorMessage="Tipo Documento" Font-Size="Small" ForeColor="Red" Height="16px" SetFocusOnError="True" ToolTip="Debe ingresar un nombre válido." Width="19px">*</asp:RequiredFieldValidator>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label40" runat="server" Font-Bold="True" Text="Descripción :"
                                    Width="88px"></asp:Label>
                            </td>
                            <td class="style27">
                                <asp:TextBox ID="txtDescripcion" runat="server" Width="214px"></asp:TextBox>
                            </td>
                            <td class="style27">&nbsp;</td>
                            <td class="style31">&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtArchivo" runat="server" Visible="False" Width="30px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label39" runat="server" Font-Bold="False" Text="Tipo Documento :" Width="106px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadComboBox ID="RadComboBox1" runat="server" AllowCustomText="True" AutoPostBack="True" CausesValidation="False" DataSourceID="SqlTipoDocumento" DataTextField="Nombre" DataValueField="TipoDocumentoID" EmptyMessage="Buscar..." Filter="Contains" Style="margin-left: 0px" Width="215px">
                                </telerik:RadComboBox>
                            </td>
                            <td class="style27">&nbsp;</td>
                            <td class="style31">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label33" runat="server" Font-Bold="True" Text="Archivo :"
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style27">
                                <telerik:RadUpload ID="RadUpload2" runat="server" ControlObjectsVisibility="None"
                                    EnableTheming="True" Height="25px" Width="230px">
                                    <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover"
                                        Select="Seleccionar" />
                                </telerik:RadUpload>
                                <asp:Button ID="Button2" runat="server" Text="Subir"
                                    Width="59px" />
                            </td>
                            <td class="style27">&nbsp;</td>
                            <td class="style31">
                                <telerik:RadProgressArea ID="RadProgressArea2" runat="server" Width="363px"
                                    Culture="es-DO" HeaderText="Cargando documento">
                                    <Localization Uploaded="Cargado" Cancel="Cancelar" CurrentFileName="Subiendo Archivo: "
                                        ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: " TotalFiles="Total Archivos: "
                                        TransferSpeed="Velocidad: " UploadedFiles="Archivos Cargados:"></Localization>
                                </telerik:RadProgressArea>
                            </td>
                            <td>
                                <telerik:RadProgressManager ID="RadProgressManager1" runat="server"
                                    Width="99px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="7">
                                <telerik:RadGrid ID="RadGridDocumento" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" DataSourceID="SqlDocumentos"
                                    GridLines="None" PageSize="20">
                                    <ExportSettings ExportOnlyData="True" FileName="Lista de Documentos"
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Lista de Documentos" Subject="Lista de Documentos" />
                                    </ExportSettings>
                                    <ClientSettings AllowColumnsReorder="True" EnablePostBackOnRowClick="True"
                                        ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Lista Documentos" CommandItemDisplay="Bottom"
                                        CommandItemSettings-ShowAddNewRecordButton="False" DataKeyNames="PuestoBolsaCorredorDocumentoID"
                                        DataSourceID="SqlDocumentos" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" ShowExportToCsvButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaCorredorID" DataType="System.Int32"
                                                FilterControlAltText="Filter PuestoBolsaCorredorID column" HeaderText="PuestoBolsaCorredorID" SortExpression="PuestoBolsaCorredorID" UniqueName="PuestoBolsaCorredorID"
                                                Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaCorredorDocumentoID"
                                                DataType="System.Int32" FilterControlAltText="Filter PuestoBolsaCorredorDocumentoID column"
                                                HeaderText="PuestoBolsaCorredorDocumentoID" ReadOnly="True" SortExpression="PuestoBolsaCorredorDocumentoID"
                                                UniqueName="PuestoBolsaCorredorDocumentoID" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha"
                                                DataType="System.DateTime" FilterControlAltText="Filter Fecha column" HeaderText="Fecha"
                                                SortExpression="Fecha" UniqueName="Fecha" DataFormatString="{0:dd/MM/yyyy}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreTipo" DataType="System.Int32" FilterControlAltText="Filter NombreTipo column" HeaderText="Tipo Documento" SortExpression="NombreTipo" UniqueName="NombreTipo">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Descripcion" FilterControlAltText="Filter Descripcion column" HeaderText="Descripción" SortExpression="Descripcion" UniqueName="Descripcion">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn DataField="nombre"
                                                FilterControlAltText="Filter nombre column" HeaderText="Nombre" SortExpression="nombre"
                                                UniqueName="nombre">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"
                                                        Text='<%# Eval("nombre") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="Creacion" DataType="System.DateTime" FilterControlAltText="Filter Creacion column" HeaderText="Creacion" SortExpression="Creacion" UniqueName="Creacion" Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreDocumento" FilterControlAltText="Filter NombreDocumento column" HeaderText="Nombre Documento" SortExpression="NombreDocumento" UniqueName="NombreDocumento" Display="False">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="style27">
                                <asp:SqlDataSource ID="SqlTipoDocumento" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [TipoDocumento] ORDER BY [Nombre]"></asp:SqlDataSource>
                                <br />
                            </td>
                            <td class="style27">&nbsp;</td>
                            <td class="style31">
                                <asp:SqlDataSource ID="SqlDocumentos" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT * FROM [vPuestoBolsaCorredorDocumento] where PuestoBolsaCorredorID= @PuestoBolsaCorredorID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtCodigoPuestoBolsaCorredorID" Name="PuestoBolsaCorredorID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView4" runat="server">
                    <table class="style1">
                        <tr>
                            <td class="style1" colspan="7">
                                <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" CellSpacing="0" Culture="es-DO" DataSourceID="SqlHistorialCorredor"
                                    GridLines="None" PageSize="20">
                                    <ExportSettings ExportOnlyData="True" FileName="Lista de Documentos"
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Lista de Documentos" Subject="Lista de Documentos" />
                                    </ExportSettings>
                                    <ClientSettings AllowColumnsReorder="True"
                                        ReorderColumnsOnClient="True">
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                    </ClientSettings>
                                    <MasterTableView AllowSorting="True" Caption="Historial" CommandItemDisplay="Bottom"
                                        CommandItemSettings-ShowAddNewRecordButton="False"
                                        DataSourceID="SqlHistorialCorredor" NoMasterRecordsText="No hay información para mostrar.">
                                        <CommandItemSettings ExportToPdfText="Exportar a PDF" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" ShowExportToCsvButton="True" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="FechaMovimiento" DataType="System.DateTime"
                                                FilterControlAltText="Filter FechaMovimiento column" HeaderText="Fecha Movimiento" SortExpression="FechaMovimiento" UniqueName="FechaMovimiento" DataFormatString="{0:dd/MM/yyyy hh:mm:ss}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaNombreAnterior" FilterControlAltText="Filter PuestoBolsaNombreAnterior column"
                                                HeaderText="Puesto de Bolsa Anterior" SortExpression="PuestoBolsaNombreAnterior"
                                                UniqueName="PuestoBolsaNombreAnterior">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PuestoBolsaNombre" FilterControlAltText="Filter PuestoBolsaNombre column" HeaderText="Puesto de Bolsa Actual"
                                                SortExpression="PuestoBolsaNombre" UniqueName="PuestoBolsaNombre">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Movimiento" FilterControlAltText="Filter Movimiento column" HeaderText="Movimiento" SortExpression="Movimiento" UniqueName="Movimiento">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Nota" FilterControlAltText="Filter Nota column" HeaderText="Nota" SortExpression="Nota" UniqueName="Nota">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style1">&nbsp;</td>
                            <td class="style27">
                                <br />
                            </td>
                            <td class="style27">&nbsp;</td>
                            <td class="style31">
                                <asp:SqlDataSource ID="SqlHistorialCorredor" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
                                    SelectCommand="SELECT FechaMovimiento,PuestoBolsaNombreAnterior,PuestoBolsaNombre,
                      CASE WHEN Movimiento = 'T' THEN 'Transferido' ELSE CASE WHEN Movimiento = 'C' THEN 'Creado' ELSE '' END END AS
                       Movimiento,Nota FROM [vPuestoBolsaCorredores] where PuestoBolsaCorredorID=  @PuestoBolsaCorredorID ORDER BY FechaMovimiento DESC">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtCodigoPuestoBolsaCorredorID" Name="PuestoBolsaCorredorID" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>

        </div>
    </form>
</body>
</html>
