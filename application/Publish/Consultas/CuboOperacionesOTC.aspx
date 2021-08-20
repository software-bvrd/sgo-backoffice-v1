<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.CuboOperacionesOTC" Codebehind="CuboOperacionesOTC.aspx.vb" %>

<%@ Register Assembly="RadarSoft.RadarCube.Web.Direct" Namespace="RadarSoft.RadarCube.Web" TagPrefix="cc1" %>

<%@ Register Assembly="RadarSoft.RadarCube.Web" Namespace="RadarSoft.RadarCube.Web" TagPrefix="radarcube" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
            <cc1:TOLAPCube ID="Cubo" runat="server" CubeGuid="" DataSourceID="SqlOperacionesOTC" FactTableName="DefaultView">

                <Measures>
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Plazodelaoperacion" SourceField="Plazodelaoperacion" SourceFieldType="System.Int32" UniqueName="6b812f6a-79d5-41da-8c39-912850c12283" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Precio" SourceField="Precio" SourceFieldType="System.Decimal" UniqueName="df8a6f8b-5968-42df-b526-6dac0c4e7c07" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Premioo Spread" SourceField="PremiooSpread" SourceFieldType="System.Decimal" UniqueName="f570e0e4-a2d2-4984-a468-b408489a0825" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Rendimiento Nominal" SourceField="RendimientoNominal" SourceFieldType="System.Decimal" UniqueName="0eed45ed-af8c-463f-9495-8c20893daba3" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Valorfacial" SourceField="Valorfacial" SourceFieldType="System.Decimal" UniqueName="b83e0ae6-0bf0-4016-9786-ded5f10fd241" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Valor Transado" SourceField="ValorTransado" SourceFieldType="System.Decimal" UniqueName="55510e4a-ae63-4411-b354-a345d38d7628" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="Cantidad Operaciones" SourceField="CantidadOperaciones" SourceFieldType="System.Int32" UniqueName="e8471576-9deb-4d0b-86a9-c6881c96081f" Visible="True" />
                </Measures>

                <Dimensions>
                    <radarcube:TCubeDimension DisplayName="Default View" UniqueName="[Default View]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="ISIN" DisplayFieldType="System.String" DisplayName="ISIN" IDField="ISIN" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="ace947f3-1a9c-4be8-a2de-def67c8da65b" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayFieldType="System.String" DisplayName="Hora" Origin="hoAttribute" TotalCaption="Total" UniqueName="df081c52-fac6-487b-bc1d-f16fed071d5a" UnknownMemberName="Unknown" DisplayField="Hora" IDField="Hora" IDFieldType="System.String">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="MercadodeNegociacion" DisplayFieldType="System.String" DisplayName="Mercadode Negociacion" Origin="hoAttribute" TotalCaption="Total" UniqueName="d205539a-39fd-4559-a586-4c3e79b8e0e5" UnknownMemberName="Unknown" IDField="MercadodeNegociacion" IDFieldType="System.String">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Monedadeliquidacion" DisplayFieldType="System.String" DisplayName="Monedadeliquidacion" Origin="hoAttribute" TotalCaption="Total" UniqueName="a55b5cee-e568-4617-97e6-2c7a49f91b80" UnknownMemberName="Unknown" IDField="Monedadeliquidacion" IDFieldType="System.String">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Periodicidad" DisplayFieldType="System.String" DisplayName="Periodicidad" Origin="hoAttribute" TotalCaption="Total" UniqueName="d399d457-8205-4c44-9bde-d4f6f7c12415" UnknownMemberName="Unknown" IDField="Periodicidad" IDFieldType="System.String">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Formadenegociacion" DisplayFieldType="System.String" DisplayName="Formadenegociacion" Origin="hoAttribute" TotalCaption="Total" UniqueName="c3e7e482-5a7f-4847-b676-f15aa90b2b1e" UnknownMemberName="Unknown" IDField="Formadenegociacion" IDFieldType="System.String">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="RuedadeNegociacion" DisplayFieldType="System.String" DisplayName="Rueda Negociacion" Origin="hoAttribute" TotalCaption="Total" UniqueName="af846f2f-4b29-42a9-8f31-248cbc5618c9" UnknownMemberName="Unknown" IDField="RuedadeNegociacion" IDFieldType="System.String">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="TipodeOperacion" DisplayFieldType="System.String" DisplayName="Tipode Operacion" Origin="hoAttribute" TotalCaption="Total" UniqueName="8d0e9167-ca98-453b-97e7-81f4e7cca836" UnknownMemberName="Unknown" IDField="TipodeOperacion" IDFieldType="System.String">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="NombredelEmisor" DisplayFieldType="System.String" DisplayName="Nombre Emisor" IDField="NombredelEmisor" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="eeaaf478-f5ef-4eb7-b665-6113a9f9d60a" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="SectordelEmisor" DisplayFieldType="System.String" DisplayName="Sector Emisor" IDField="SectordelEmisor" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="a12bca27-3179-4377-8b93-9da3368dc7ff" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="SectorEspecifico" DisplayFieldType="System.String" DisplayName="Sector Especifico" IDField="SectorEspecifico" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="d57b9f39-0e88-4dd5-a901-3d53a82ef1d6" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="TipodelInstrumento" DisplayFieldType="System.String" DisplayName="Tipodel Instrumento" IDField="TipodelInstrumento" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="b0a4bb1f-cea9-4cb2-b7a8-4b819e5c4882" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Monedadelinstrumento" DisplayFieldType="System.String" DisplayName="Moneda instrumento" IDField="Monedadelinstrumento" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="afdf062b-a6e2-4826-85ee-3abc4570da9e" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>

                    <radarcube:TCubeDimension DisplayName="Fecha Operacion" UniqueName="[Default View.Fechade Operacion]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeYear" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeOperacion" DisplayFieldType="System.String" DisplayName="Fechade Operacion - Año" IDField="FechadeOperacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="97fef479-03bb-4c5b-9a57-12a1e4dff81d" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeQuarter" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeOperacion" DisplayFieldType="System.String" DisplayName="Fechade Operacion - Trimestre" IDField="FechadeOperacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="516be8c0-a055-488a-bfae-e09464c7afd7" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeMonthLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeOperacion" DisplayFieldType="System.String" DisplayName="Fechade Operacion - Mes (completo)" IDField="FechadeOperacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="fabbcb5a-15d2-4b73-9a26-2744796e2368" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy Children="97fef479-03bb-4c5b-9a57-12a1e4dff81d|516be8c0-a055-488a-bfae-e09464c7afd7|fabbcb5a-15d2-4b73-9a26-2744796e2368" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeOperacion" DisplayFieldType="System.DateTime" DisplayName="Fechade Operacion" IDField="FechadeOperacion" IDFieldType="System.DateTime" Origin="hoUserDefined" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="16752fe0-e845-47c1-a88b-472080c30ff1" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>

                    <radarcube:TCubeDimension DisplayName="Fecha Vencimiento" UniqueName="[Default View.Fechadevencimiento]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeYear" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Fechadevencimiento" DisplayFieldType="System.String" DisplayName="Fechadevencimiento - Año" IDField="Fechadevencimiento" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="5f5982ed-47a3-481e-8a47-cf352905c0de" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeQuarter" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Fechadevencimiento" DisplayFieldType="System.String" DisplayName="Fechadevencimiento - Trimestre" IDField="Fechadevencimiento" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="ae04213b-06ed-4245-99ec-b42d58b57b8f" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeMonthLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Fechadevencimiento" DisplayFieldType="System.String" DisplayName="Fechadevencimiento - Mes (completo)" IDField="Fechadevencimiento" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="078ea761-24d0-4450-9a29-496b1a83fe55" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy Children="5f5982ed-47a3-481e-8a47-cf352905c0de|ae04213b-06ed-4245-99ec-b42d58b57b8f|078ea761-24d0-4450-9a29-496b1a83fe55" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Fechadevencimiento" DisplayFieldType="System.DateTime" DisplayName="Fechadevencimiento" IDField="Fechadevencimiento" IDFieldType="System.DateTime" Origin="hoUserDefined" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="f8279670-e2ba-4376-a097-ed426c8df965" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>

                    <radarcube:TCubeDimension DisplayName="Fecha Liquidacion" UniqueName="[Default View.Fechade Liquidacion]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeYear" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeLiquidacion" DisplayFieldType="System.String" DisplayName="Fechade Liquidacion - Año" IDField="FechadeLiquidacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="0662b416-ee96-41e6-8ca4-41191305a42d" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeQuarter" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeLiquidacion" DisplayFieldType="System.String" DisplayName="Fechade Liquidacion - Trimestre" IDField="FechadeLiquidacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="40045f48-f1a9-4232-9d44-8b160bc4b829" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeMonthLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeLiquidacion" DisplayFieldType="System.String" DisplayName="Fechade Liquidacion - Mes (completo)" IDField="FechadeLiquidacion" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="d734ba51-d405-4f05-94c9-591b3b5b326d" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy Children="0662b416-ee96-41e6-8ca4-41191305a42d|40045f48-f1a9-4232-9d44-8b160bc4b829|d734ba51-d405-4f05-94c9-591b3b5b326d" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="FechadeLiquidacion" DisplayFieldType="System.DateTime" DisplayName="Fechade Liquidacion" IDField="FechadeLiquidacion" IDFieldType="System.DateTime" Origin="hoUserDefined" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="d37037b2-e78b-4e92-a29f-05c85fac006f" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>

                </Dimensions>

                <CubeTablePositions>
                    <cc1:TCubeTablePosition Name="DefaultView" Position="258, 0" />
                </CubeTablePositions>
            </cc1:TOLAPCube>
        </div>

        <div>
            <radarcube:TOLAPExport ID="Exportar" runat="server" GridID="Grid"></radarcube:TOLAPExport>
            <asp:SqlDataSource ID="SqlOperacionesOTC" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [vProveedoraPreciosHechos_OTC]"></asp:SqlDataSource>
        </div>

    </form>
</body>
</html>
