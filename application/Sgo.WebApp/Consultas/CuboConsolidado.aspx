<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Consultas_CuboConsolidado" Codebehind="CuboConsolidado.aspx.vb" %>

<%@ Register Assembly="RadarSoft.RadarCube.Web.Direct" Namespace="RadarSoft.RadarCube.Web" TagPrefix="cc1" %>
<%@ Register Assembly="RadarSoft.RadarCube.Web" Namespace="RadarSoft.RadarCube.Web" TagPrefix="radarcube" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cubo Operaciones Bursátiles y Extrabursátiles</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>

    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
    <style type="text/css">
        #Mover, #Actualizar
        {
            height: 25px;
            -moz-box-shadow: inset -1px -1px 0px 0px #b6d8fa;
            -webkit-box-shadow: inset -1px -1px 0px 0px #b6d8fa;
            box-shadow: inset -1px -1px 0px 0px #b6d8fa;
            background-color: #b6d8fa;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
            border-bottom: 1px solid #3A6DC1;
            border-right: 1px solid #3A6DC1;
            display: inline-block;
            color: #ffffff;
            padding: 6px 15px;
        }

        .MoverFondo
        {
            background-image: url("../Images/WindowMove.png");
            background-repeat: no-repeat;
            background-position: 5px;
        }

        .ActualizarFondo
        {
            background-image: url("../Images/refresh.png");
            background-repeat: no-repeat;
            background-position: 5px;
        }

        #Mover:hover, #Actualizar:hover
        {
            background-color: #b6d8fa;
        }

        #Mover:active, #Actualizar:active
        {
            position: relative;
            top: 1px;
        }


        .rc_levelcell /* main table header */
        {
            background-color: #d7e9f7;
            color: #2e6e9e;
            border-left: 1px solid #ffffff;
            border-top: 1px solid #e4f1fb;
            border-bottom: 1px solid #c5dbec;
            border-right: 1px solid #c5dbec;
            padding-right: 2px;
            white-space: nowrap;
        }

        .rc_membercell /* table header */
        {
            background-color: #eaf4fd;
            color: #2e6e9e;
            border-left: 1px solid #ffffff;
            border-top: 1px solid #f3f9ff;
            border-bottom: 1px solid #cbdeef;
            border-right: 1px solid #cbdeef;
            padding-right: 2px;
            white-space: nowrap;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

         <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>

        <div id="Herramientas" style="margin-bottom: 10px; float: left">
            <radarcube:TOLAPToolbox ID="BarraHerramienta" runat="server" ExportID="Exportar" GridID="Grid">
                <SaveLayoutButton Tooltip="Guardar diseño actual" FileName="Cubo Consolidado"></SaveLayoutButton>

                <LoadLayoutButton Tooltip="Cargar diseño" FileNamePrompt="Seleccione el diseña a aplicar:"></LoadLayoutButton>

                <MDXQueryButton MDXQueryPrompt="MDX Consulta:" />

                <AddCalculatedMeasureButton ClientScript="$find('Grid').showDialog('createcalculatedmeasure')" />

                <ExportJPEGButton Tooltip="Exportar vista a formato {0} " FileName="Cubo Consolidado"></ExportJPEGButton>

                <ExportCSVButton Tooltip="Exportar vista a formato {0} " FileName="Cubo Consolidado"></ExportCSVButton>

                <ExportXLSButton Tooltip="Exportar vista a formato {0} " FileName="Cubo Consolidado"></ExportXLSButton>

                <ExportHTMLButton Tooltip="Exportar vista a formato {0} " FileName="Cubo Consolidado"></ExportHTMLButton>

                <ExportPDFButton Tooltip="Exportar vista a formato {0} " FileName="Cubo Consolidado"></ExportPDFButton>

                <AllAreasButton Tooltip="Mostrar todos las areas" />
                <ClearLayoutButton Tooltip="Limpiar el diseño actual" />
                <DataAreaButton Tooltip="Mostrar solo area de datos" />
                <PivotAreaButton Tooltip="Mostrar areas del pivote" />

                <ZoomOutButton Tooltip="Reducir"></ZoomOutButton>

                <ZoomInButton Tooltip="Ampliar"></ZoomInButton>

                <ResetZoomButton Tooltip="Reestablecer al 100%"></ResetZoomButton>
            </radarcube:TOLAPToolbox>
        </div>

        <div id="ActualizarBtn" style="margin-right: 2px; float: left">
            <asp:Button ID="Actualizar" CssClass="ActualizarFondo" runat="server" ToolTip="Actualizar" />
        </div>

        <div id="BotonMover">
            <asp:Button ID="Mover" CssClass="MoverFondo" runat="server" ToolTip="Nueva ventana" OnClientClick="ventanaSecundaria('../Consultas/CuboOperaciones.aspx',1000,600)" />
        </div>


        <div id="AreaCubo" style="Clear: Both; height: 600px">
            <radarcube:TOLAPGrid ID="Grid" runat="server"
                CubeID="Cubo" DefaultLanguageCode="es"
                MaxTextLength="50"
                PivotingBehavior="RadarCube"
                SupportEMail="soporte@peopleworks.com.do"
                Title="Cubo Consolidado"
                Height="600px" Skin="Redmond" Width="100%"
                StructureTreeWidth="100%"
                MaxRowsInGrid="1000000000" AllowPaging="False" AllowScrolling="True">
            </radarcube:TOLAPGrid>
        </div>

        <div>
            <cc1:TOLAPCube ID="Cubo" runat="server" CubeGuid="" DataSourceID="SqlvCuboConsolidado" FactTableName="DefaultView">

                <Measures>
                    <radarcube:TCubeMeasure AggregateFunction="stAverage" DataTable="DefaultView" DisplayName="Precio" SourceField="Precio" SourceFieldType="System.Decimal" UniqueName="df8bd50f-b912-43d3-b23a-546e60931cf6" Visible="True" />
                    <radarcube:TCubeMeasure AggregateFunction="stAverage" DataTable="DefaultView" DefaultFormat="Standard" DisplayName="Premioo Spread" SourceField="PremiooSpread" SourceFieldType="System.Decimal" UniqueName="2693aae2-6a38-43be-b728-d9a3e05709e7" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Rendimiento Nominal" SourceField="RendimientoNominal" SourceFieldType="System.Decimal" UniqueName="7e799c5d-a476-47e6-8ae0-d7d9eaf82e45" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Valor Facial" SourceField="Valorfacial" SourceFieldType="System.Decimal" UniqueName="c72504da-198a-4257-9a2c-30caf5ca0c8e" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Valor Transado" SourceField="ValorTransado" SourceFieldType="System.Decimal" UniqueName="6cf01d88-9818-43c3-a127-fa3c4f417173" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DefaultFormat="Standard" DisplayName="Cant. Operaciones" SourceField="CantidadOperaciones" SourceFieldType="System.Double" UniqueName="961f2ecb-3518-41d5-a325-60d4fcb9e9a3" />
                </Measures>

                <Dimensions>
                    <radarcube:TCubeDimension DisplayName="Dimensiones" UniqueName="[Default View]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="ISIN" DisplayFieldType="System.String" DisplayName="ISIN" IDField="ISIN" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="d0f391e5-bd36-4f84-a5e3-a2a1c6aa4d67" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="MercadodeNegociacion" DisplayFieldType="System.String" DisplayName="Mercado" IDField="MercadodeNegociacion" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="6da643fd-efef-4ed6-b82a-535588357a4a" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Monedadeliquidacion" DisplayFieldType="System.String" DisplayName="Moneda" IDField="Monedadeliquidacion" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="9bbd46fe-e0cf-4493-b874-9d3d5063aa8c" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Periodicidad" DisplayFieldType="System.String" DisplayName="Periodicidad" IDField="Periodicidad" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="57ab3d8f-14b7-48e2-8f7a-1c561cf3d038" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="TipodeOperacion" DisplayFieldType="System.String" DisplayName="Tipo Operación" IDField="TipodeOperacion" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="2cb7882e-cd4c-4ff6-9b89-db1652df96db" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="NombredelEmisor" DisplayFieldType="System.String" DisplayName="Emisor" IDField="NombredelEmisor" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="6b21ede6-1df5-4322-80b2-f936a486474e" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="SectordelEmisor" DisplayFieldType="System.String" DisplayName="Sector Emisor" IDField="SectordelEmisor" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="5cdc23d2-852b-4272-8074-bfab66b84626" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="TipodelInstrumento" DisplayFieldType="System.String" DisplayName="Instrumento" IDField="TipodelInstrumento" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="e736f61d-adac-463c-bd32-27e1948302eb" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FuenteDatos" DisplayFieldType="System.String" DisplayName="Mecanismo Negociación" IDField="FuenteDatos" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="398313bf-cdf3-4a48-ae53-a29e16bf41c7" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>
                    <radarcube:TCubeDimension DisplayName="Fecha Operación" UniqueName="[Default View.Fechade Operacion]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeYear" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeOperacion" DisplayFieldType="System.String" DisplayName="Fechade Operacion - Año" IDField="FechadeOperacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="d20a2900-1da1-4dd7-8c7e-849c4eca0fda" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeQuarter" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeOperacion" DisplayFieldType="System.String" DisplayName="Fechade Operacion - Trimestre" IDField="FechadeOperacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="2dc2caf1-fc79-41da-a464-ad13ea9e0404" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeMonthLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeOperacion" DisplayFieldType="System.String" DisplayName="Fechade Operacion - Mes (completo)" IDField="FechadeOperacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="de3b60cd-a69c-40dc-b679-ac002d5702d9" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy Children="d20a2900-1da1-4dd7-8c7e-849c4eca0fda|2dc2caf1-fc79-41da-a464-ad13ea9e0404|de3b60cd-a69c-40dc-b679-ac002d5702d9" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeOperacion" DisplayFieldType="System.DateTime" DisplayName="Fechade Operacion" IDField="FechadeOperacion" IDFieldType="System.DateTime" Origin="hoUserDefined" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="cb6f9b90-3095-47b9-bb10-9deaaa9f6388" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>
                </Dimensions>

                <CubeTablePositions>
                    <cc1:TCubeTablePosition Name="DefaultView" Position="206, 161" />
                </CubeTablePositions>
            </cc1:TOLAPCube>
        </div>

        <div>
            <radarcube:TOLAPExport ID="Exportar" runat="server" GridID="Grid"></radarcube:TOLAPExport>
            <asp:SqlDataSource ID="SqlvCuboConsolidado" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [vCuboConsolidado]"></asp:SqlDataSource>
        </div>

    </form>
</body>
</html>
