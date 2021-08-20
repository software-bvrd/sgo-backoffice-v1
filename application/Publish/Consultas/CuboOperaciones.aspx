<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.CuboOperaciones" Codebehind="CuboOperaciones.aspx.vb" %>

<%@ Register Assembly="RadarSoft.RadarCube.Web.Direct" Namespace="RadarSoft.RadarCube.Web" TagPrefix="cc1" %>

<%@ Register Assembly="RadarSoft.RadarCube.Web" Namespace="RadarSoft.RadarCube.Web" TagPrefix="radarcube" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cubo de Operaciones</title>
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

        /*#olapgrid_IG_levels {height:0px!important;}
        #olapgrid_IG_cols{height:0px!important;}
        #olapgrid_IG_rows{height:0px!important;}*/
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <%--<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />--%>
            </Scripts>
        </telerik:RadScriptManager>


        <div id="Herramientas" style="margin-bottom: 10px; float: left">
            <radarcube:TOLAPToolbox ID="BarraHerramienta" runat="server" ExportID="Exportar" GridID="Grid">
                <SaveLayoutButton Tooltip="Guardar diseño actual" FileName="CuboOperaciones"></SaveLayoutButton>

                <LoadLayoutButton Tooltip="Cargar diseño" FileNamePrompt="Seleccione el diseña a aplicar:"></LoadLayoutButton>

                <MDXQueryButton MDXQueryPrompt="MDX Consulta:" />

                <AddCalculatedMeasureButton ClientScript="$find('Grid').showDialog('createcalculatedmeasure')" />

                <ExportJPEGButton Tooltip="Exportar vista a formato {0} " FileName="CuboOperaciones"></ExportJPEGButton>

                <ExportCSVButton Tooltip="Exportar vista a formato {0} " FileName="CuboOperaciones"></ExportCSVButton>

                <ExportXLSButton Tooltip="Exportar vista a formato {0} " FileName="CuboOperaciones"></ExportXLSButton>

                <ExportHTMLButton Tooltip="Exportar vista a formato {0} " FileName="CuboOperaciones"></ExportHTMLButton>

                <ExportPDFButton Tooltip="Exportar vista a formato {0} " FileName="CuboOperaciones"></ExportPDFButton>

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
                Title="Cubo Operaciones"
                Height="600px" Skin="Redmond" Width="100%"
                StructureTreeWidth="100%"
                MaxRowsInGrid="1000000000" AllowPaging="False" AllowScrolling="True">
            </radarcube:TOLAPGrid>
        </div>

        <div>
            <cc1:TOLAPCube ID="Cubo" runat="server" CubeGuid="" DataSourceID="SqlInstrumento" FactTableName="DefaultView">

                <Measures>
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Monto Emitido" SourceField="Monto_Emitido" SourceFieldType="System.Decimal" UniqueName="2c505e35-7997-452f-b533-779e73ecd01e" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="VTransado Equivalente Pesos" SourceField="ValorTransadoEquivalentePesos" SourceFieldType="System.Decimal" UniqueName="b98d336c-3b3a-4811-a692-fdf90f735018" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="VTransado Equivalente USD" SourceField="ValorTransadoEquivalenteDolares" SourceFieldType="System.Decimal" UniqueName="e843079e-4a8a-46a3-bb5e-91afec393c1f" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Días Acumulados" SourceField="dias_acum" SourceFieldType="System.Double" UniqueName="99d685dd-a951-4e4a-b382-b5672f526504" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DefaultFormat="#####" DisplayName="Cantidad Operaciones" SourceField="CantidadOperaciones" SourceFieldType="System.Double" UniqueName="92e3ba1a-97a6-4b09-bb6a-f8ab3ef57f80" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Precio" SourceField="precio_limp" SourceFieldType="System.Double" UniqueName="0b0322c4-b762-4c31-9f9c-ea9ee10452f4" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Valor Transado" SourceField="valor_tran" SourceFieldType="System.Double" UniqueName="5e12c53d-ae75-4b18-8eae-252f0428409a" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Valor Nominal Total" SourceField="valor_nom_tot" SourceFieldType="System.Double" UniqueName="9c883c6a-ff3a-44ae-8040-0ceb4e947e70" />
                </Measures>

                <Dimensions>
                    <radarcube:TCubeDimension DisplayName="Dimensiones" UniqueName="[Dimensiones]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Nemotecnico" DisplayFieldType="System.String" DisplayName="Nemotecnico" IDField="Nemotecnico" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="fb0524d1-4e39-4335-9f4f-ba94cef66197" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="CodigoISIN" DisplayFieldType="System.String" DisplayName="Codigo ISIN" IDField="CodigoISIN" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="3d1c5ef2-1048-4340-99af-20e7374d2674" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="TipoTasa" DisplayFieldType="System.String" DisplayName="Tipo Tasa" IDField="TipoTasa" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="47d1bee7-5a93-414b-b658-caacebd7a712" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="TipoLiquidacion" DisplayFieldType="System.String" DisplayName="Tipo Liquidacion" IDField="TipoLiquidacion" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="260fa501-1c03-4d12-b573-d6a868f0a1fb" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Emisor" DisplayFieldType="System.String" DisplayName="Emisor" IDField="Emisor" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="2f608433-6d76-4f50-a18f-1862ffb5dddc" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="BaseLiquidacion" DisplayFieldType="System.String" DisplayName="Base Liquidacion" IDField="BaseLiquidacion" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="e25fba16-d652-437c-ba72-881fba68456e" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="NombreInstrumento" DisplayFieldType="System.String" DisplayName="Nombre Instrumento" IDField="NombreInstrumento" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="9f7cff8b-af7a-4e5e-be83-44b81a77a637" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Moneda" DisplayFieldType="System.String" DisplayName="Moneda" IDField="Moneda" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="36ab9adb-6936-4c2d-9190-35671e6b055a" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Industria" DisplayFieldType="System.String" DisplayName="Industria" IDField="Industria" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="ca66336d-a919-42bc-ac73-5c6c0b013927" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Sector" DisplayFieldType="System.String" DisplayName="Sector" IDField="Sector" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="9d3fa5ea-5738-42e1-9ee1-be31e147e491" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Calificacion" DisplayFieldType="System.String" DisplayName="Calificacion" IDField="Calificacion" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="2ad9e075-4b3f-4b05-863b-0db29570d612" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="DescripcionCalificacion" DisplayFieldType="System.String" DisplayName="Descripcion Calificacion" IDField="DescripcionCalificacion" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="2b6e0396-b2c1-45e6-9d89-ca0dd5f2ea41" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayFieldType="System.String" DisplayName="DefaultView" Origin="hoAttribute" TotalCaption="Total" UniqueName="[Dimensiones].[DefaultView]" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="NombreMercado" DisplayFieldType="System.String" DisplayName="Nombre Mercado" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htStrings" UniqueName="[Dimensiones].[NombreMercado]" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>

                    <radarcube:TCubeDimension DisplayName="Fecha Emisión" UniqueName="[Fecha Emision]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeYear" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaEmision" DisplayFieldType="System.String" DisplayName="Fecha Emision - Año" IDField="FechaEmision" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="b4200eb6-b1fc-45a0-9f0d-b384f94de65b" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeQuarter" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaEmision" DisplayFieldType="System.String" DisplayName="Fecha Emision - Q" IDField="FechaEmision" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="2c23b251-c9ff-4e51-b8e5-922e11698ed4" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeMonthLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaEmision" DisplayFieldType="System.String" DisplayName="Fecha Emision -Mes" IDField="FechaEmision" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="b9b7d184-e02b-4772-bf7c-899c3836ab6d" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy Children="b4200eb6-b1fc-45a0-9f0d-b384f94de65b|2c23b251-c9ff-4e51-b8e5-922e11698ed4|b9b7d184-e02b-4772-bf7c-899c3836ab6d" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaEmision" DisplayFieldType="System.DateTime" DisplayName="Fecha Emision" IDField="FechaEmision" IDFieldType="System.DateTime" Origin="hoUserDefined" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="9676b6f4-7e5e-4c7b-962e-ead33ca92dca" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>

                    <radarcube:TCubeDimension DisplayName="Fecha Vencimiento" UniqueName="[Fecha Vencimiento]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeYear" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaVencimiento" DisplayFieldType="System.String" DisplayName="Fecha Vencimiento - Año" IDField="FechaVencimiento" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="0a23851a-d176-4bcd-82f1-19f75ed3fb17" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeQuarter" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaVencimiento" DisplayFieldType="System.String" DisplayName="Fecha Vencimiento - Q" IDField="FechaVencimiento" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="332333bc-0e45-4601-bf9d-11e0600e157e" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeMonthLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaVencimiento" DisplayFieldType="System.String" DisplayName="Fecha Vencimiento - Mes" IDField="FechaVencimiento" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="0ae708b9-8032-4649-8587-f157d8a4b4f2" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy Children="0a23851a-d176-4bcd-82f1-19f75ed3fb17|332333bc-0e45-4601-bf9d-11e0600e157e|0ae708b9-8032-4649-8587-f157d8a4b4f2" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaVencimiento" DisplayFieldType="System.DateTime" DisplayName="Fecha Vencimiento" IDField="FechaVencimiento" IDFieldType="System.DateTime" Origin="hoUserDefined" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="d9683571-398a-47ab-8e7d-ffa1cad010eb" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>

                    <radarcube:TCubeDimension DisplayName="Fecha Liquidación" UniqueName="[Fecha Liquidacion]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeYear" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaLiquidacion" DisplayFieldType="System.String" DisplayName="Fecha Liquidacion - Año" IDField="FechaLiquidacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="4f305844-d4ea-421f-8256-2ba71b9194ba" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeQuarter" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaLiquidacion" DisplayFieldType="System.String" DisplayName="Fecha Liquidacion - Q" IDField="FechaLiquidacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="d160b0b7-5ee1-49cb-883e-d3825ebdd3a4" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeMonthLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaLiquidacion" DisplayFieldType="System.String" DisplayName="Fecha Liquidacion - Mes" IDField="FechaLiquidacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="0c5fced4-498e-411e-85ca-8a36918159c6" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy Children="4f305844-d4ea-421f-8256-2ba71b9194ba|d160b0b7-5ee1-49cb-883e-d3825ebdd3a4|0c5fced4-498e-411e-85ca-8a36918159c6" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechaLiquidacion" DisplayFieldType="System.DateTime" DisplayName="Fecha Liquidacion" IDField="FechaLiquidacion" IDFieldType="System.DateTime" Origin="hoUserDefined" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="b1168def-2fe0-45dd-9c94-cb5b7ec3c6af" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>

                    <radarcube:TCubeDimension DisplayName="Fecha Operación" UniqueName="[9099E2C4CAD87C5A2C94C154C5726B31]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy Children="[9099E2C4CAD87C5A2C94C154C5726B31].[DE990336DEE173676DC062E7B4038EA5]|[9099E2C4CAD87C5A2C94C154C5726B31].[Quarter]|[9099E2C4CAD87C5A2C94C154C5726B31].[Year]" DiscretizationBucketFormat="%{First} - %{Last}" DisplayFieldType="System.DateTime" DisplayName="fecha_oper" Origin="hoUserDefined" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="[9099E2C4CAD87C5A2C94C154C5726B31].[fecha_oper]" UnknownMemberName="">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeMonthLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="fecha_oper" DisplayFieldType="System.String" DisplayName="Mes" FormatString="MMMM" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="[9099E2C4CAD87C5A2C94C154C5726B31].[DE990336DEE173676DC062E7B4038EA5]" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeQuarter" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="fecha_oper" DisplayFieldType="System.String" DisplayName="Q" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="[9099E2C4CAD87C5A2C94C154C5726B31].[Quarter]" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeYear" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="fecha_oper" DisplayFieldType="System.String" DisplayName="Año" FormatString="YYYY" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="[9099E2C4CAD87C5A2C94C154C5726B31].[Year]" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>

                        </Hierarchies>
                    </radarcube:TCubeDimension>

                    <radarcube:TCubeDimension DisplayName="Operaciones" UniqueName="[Operaciones]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="cant_tit" DisplayFieldType="System.String" DisplayName="Cantidad Títulos" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htNumbers" UniqueName="[Operaciones].[cant_tit]" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="mercado" DisplayFieldType="System.String" DisplayName="Mercado" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htStrings" UniqueName="[Operaciones].[mercado]" UnknownMemberName="Desconocido">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>

                </Dimensions>

                <CubeTablePositions>
                    <cc1:TCubeTablePosition Name="DefaultView" Position="216, 17" />
                </CubeTablePositions>
            </cc1:TOLAPCube>
        </div>

        <div>
            <radarcube:TOLAPExport ID="Exportar" runat="server" GridID="Grid"></radarcube:TOLAPExport>
            <asp:SqlDataSource ID="SqlInstrumento" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [vCuboOperaciones]"></asp:SqlDataSource>
        </div>

    </form>
</body>
</html>
