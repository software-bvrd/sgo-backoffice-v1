<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.CargaLibroDeOrdenes" CodeBehind="CargaLibroDeOrdenes.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title></title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />

    <style type="text/css">
        .style1 {
            width: 100%;
        }

        .style2 {
            margin-left: 40px;
        }

        .style3 {
            width: 213px;
        }

        .style4 {
            height: 72px;
            margin-left: 40px;
        }

        .style5 {
            margin-left: 40px;
            width: 849px;
        }
    </style>
</head>

<body style="background-color: #F1F5FB">
    <form id="form1" runat="server" style="background-color: #F1F5FB">


        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

            <script type="text/javascript">

                function pageLoad() {
                    var grid = $find("rgListaArchivosCargados");
                    var columns = grid.get_masterTableView().get_columns();


                    for (var i = 0; i < columns.length; i++) {
                        columns[i].resizeToFit();
                    }
                }
            </script>

        </telerik:RadCodeBlock>

        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

        </div>

        <div>
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/upload.gif"
                        Text="Cargar Archivo" ToolTip="Cargar Archivo Seleccionado" Value="0">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 0">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/saveas.gif"
                        Text="Procesar" ToolTip="Procesar Información" Value="1">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar" Value="2">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div>
            <asp:Label ID="Mensaje" runat="server" Text=""></asp:Label>
            <div>
                <div id="Columa1" style="float: left; width: 70%">
                    <div>
                        <table>

                            <tr>
                                <td>
                                    <asp:Label ID="lblFormatofecha" runat="server" Text="Formato Fecha :"></asp:Label>


                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cboFormatoFecha" runat="server" Width="240px"
                                        LoadingMessage="Cargando..." AutoPostBack="True">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Español" Value="Español" />
                                            <telerik:RadComboBoxItem runat="server" Text="Inglés" Value="Inglés" />
                                        </Items>
                                    </telerik:RadComboBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelTipoLibroOrdenes" runat="server" Text="Tipo Libro Ordenes :   "></asp:Label>

                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cboTipoLibroOrdenes" runat="server" Width="240px" AutoPostBack="True" Enabled="False">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="LOPI" Value="LOPI" />
                                            <telerik:RadComboBoxItem runat="server" Text="LOIG" Value="LOIG" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTipoBono" runat="server" Text="Tipo de Bono:   "></asp:Label>
                                </td>

                                <td>
                                    <telerik:RadComboBox ID="cboTipoBono" runat="server" Width="240px" AutoPostBack="True" Enabled="False">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="Emisión" Value="Emision" />
                                            <telerik:RadComboBoxItem runat="server" Text="Programa de Emisiones" Value="ProgramaEmisiones" />

                                        </Items>
                                    </telerik:RadComboBox>
                                </td>

                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lblTipoMoneda" runat="server" Text="Tipo de Moneda:   "></asp:Label>

                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lblLimiteInversionMinimo" runat="server" Text="Límite de Inversión mínimo:"></asp:Label>

                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lblLimiteInversionMaximo" runat="server" Text="Límite de Inversión máximo:"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td></td>
                                <td>
                                    <asp:CheckBox ID="chkSobrescribirArchivo" runat="server" Text="Sobrescribir archivo libro de ordenes:" TextAlign="Left" Enabled="False" />
                                </td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>

                                    <asp:Label ID="lblResultadoValidacion" runat="server" ForeColor="Red"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblTextoArchivoProcesar" runat="server"></asp:Label>
                                    <telerik:RadUpload ID="RadUpload1" runat="server" Height="37px" Width="673px"
                                        Culture="es-DO" InputSize="75" MaxFileInputsCount="1" OverwriteExistingFiles="True"
                                        ToolTip="Herramienta de carga de archivos"
                                        ControlObjectsVisibility="ClearButtons">
                                        <Localization Add="Agregar" Clear="Limpiar" Delete="Borrar" Remove="Remover"
                                            Select="Seleccionar " />
                                    </telerik:RadUpload>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">

                                    <telerik:RadListBox ID="lstErrores" runat="server" Visible="False"
                                        Width="900px">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div>
                        <telerik:RadGrid ID="dgVistaPrevia" runat="server" CellSpacing="0"
                            Culture="es-DO" GridLines="None" Height="273px" Visible="False" Width="850px">
                            <ExportSettings ExportOnlyData="True" FileName="Lista de Operaciones"
                                OpenInNewWindow="True">
                                <Pdf PageTitle="Lista de Operaciones" Title="Lista de Operaciones" />
                            </ExportSettings>
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <MasterTableView CommandItemDisplay="Bottom">
                                <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                                    ShowExportToCsvButton="True" ShowExportToExcelButton="True"
                                    ShowExportToPdfButton="True" ShowRefreshButton="False"></CommandItemSettings>

                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>

                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </ExpandCollapseColumn>

                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                </EditFormSettings>

                            </MasterTableView>

                            <FilterMenu EnableImageSprites="False"></FilterMenu>
                        </telerik:RadGrid>
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

                    </div>

                </div>
                <div id="Columna2" style="float: right; width: 100%">
                    <table width="800px">
                        <tr>
                            <td>
                                <asp:Label ID="lblFormatofecha0" runat="server" Text="Historial de archivos  cargados en el día :"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="rgListaArchivosCargados" runat="server" CellSpacing="0"
                                    Culture="es-DO" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="400px">
                                    <ExportSettings ExportOnlyData="True" FileName="Lista de Operaciones"
                                        OpenInNewWindow="True">
                                        <Pdf PageTitle="Lista de Operaciones" Title="Lista de Operaciones" />
                                    </ExportSettings>
                                    <ClientSettings>
                                        <Selecting AllowRowSelect="True" />
                                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                        <Resizing AllowColumnResize="true" EnableRealTimeResize="true" />
                                    </ClientSettings>
                                    <MasterTableView CommandItemDisplay="Bottom" DataSourceID="SqlDataSource1">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                                            ShowExportToCsvButton="True" ShowExportToExcelButton="True"
                                            ShowExportToPdfButton="True" ShowRefreshButton="False"></CommandItemSettings>

                                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </RowIndicatorColumn>

                                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </ExpandCollapseColumn>

                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter Nombre column" HeaderText="Nombre" SortExpression="Nombre" UniqueName="Nombre">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" DataType="System.DateTime" FilterControlAltText="Filter Fecha column" HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="LineasValidas" DataType="System.Int32" FilterControlAltText="Filter LineasValidas column" HeaderText="Líneas válidas" SortExpression="LineasValidas" UniqueName="LineasValidas">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="LineasNoValidas" DataType="System.Int32" FilterControlAltText="Filter LineasNoValidas column" HeaderText="Líneas No válidas" SortExpression="LineasNoValidas" UniqueName="LineasNoValidas">
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
                    </table>

                </div>
                <div>
                    <telerik:RadProgressManager ID="RadProgressManager1" runat="server" />
                    <telerik:RadProgressArea ID="RadProgressArea1" runat="server" HeaderText="Cargando documento"
                        Height="210px" Width="700px">
                        <Localization Uploaded="Cargado" Cancel="Cancelar" CurrentFileName="Subiendo Archivo: "
                            ElapsedTime="Tiempo Transcurrido: " EstimatedTime="Tiempo Estimado: " TotalFiles="Total Archivos: "
                            TransferSpeed="Velocidad: " UploadedFiles="Archivos Cargados:"></Localization>
                    </telerik:RadProgressArea>
                </div>
                <div style="clear: both"></div>
            </div>


        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" ProviderName="<%$ ConnectionStrings:CN.ProviderName %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlCodigoProrrateoLOPI" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT DISTINCT CodigoProrrateo,  CodEmisionBVRD+'-'+ CAST(CodigoProrrateo AS VARCHAR) AS Descripcion FROM dbo.ResultadoProrrateo WHERE TipoLibroOrdenes='LOPI'"></asp:SqlDataSource>
    </form>
</body>

</html>
