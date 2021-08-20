<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Consultas_CuboOperacionesMultiple" Codebehind="CuboOperacionesMultiple.aspx.vb" %>

<%@ Register Assembly="RadarSoft.RadarCube.Web.Direct" Namespace="RadarSoft.RadarCube.Web" TagPrefix="cc1" %>

<%@ Register Assembly="RadarSoft.RadarCube.Web" Namespace="RadarSoft.RadarCube.Web" TagPrefix="radarcube" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>

        <div>

            <radarcube:TOLAPGrid ID="TOLAPGrid1" runat="server" CubeID="TOLAPCube1">
            </radarcube:TOLAPGrid>

        </div>

        <div>
            <cc1:TOLAPCube ID="TOLAPCube1" runat="server" CubeGuid="ee11a6a6-0000-0000-0000-000000000000" DataSourceID="SqlDataSource1" FactTableName="DefaultView">
                <Measures>
                    <radarcube:TCubeMeasure DataTable="DefaultView" DisplayName="valor tran" SourceField="valor_tran" SourceFieldType="System.Decimal" UniqueName="6647055a-7a65-48b6-a938-e59c9eecdeca" Visible="True" />
                    <radarcube:TCubeMeasure DataTable="DefaultView" DefaultFormat="Standard" DisplayName="Cantidad Operaciones" SourceField="CantidadOperaciones" SourceFieldType="System.Int32" UniqueName="15669866-5f7c-428d-82e0-6954db9e7e2f" Visible="True" />
                </Measures>
                <Dimensions>
                    <radarcube:TCubeDimension DisplayName="Default View" UniqueName="[Default View]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Nemotecnico" DisplayFieldType="System.String" DisplayName="Nemotecnico" IDField="Nemotecnico" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="5dcbdf7e-5838-4855-9058-6c0987ce08f4" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="Emisor" DisplayFieldType="System.String" DisplayName="Emisor" IDField="Emisor" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="f58271f8-1c55-4a3c-b2ab-c52b9ab278ac" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="NombreInstrumento" DisplayFieldType="System.String" DisplayName="Nombre Instrumento" IDField="NombreInstrumento" IDFieldType="System.String" Origin="hoAttribute" TotalCaption="Total" UniqueName="1e6c05cf-755a-49ab-b720-b905d37f8450" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>
                    <radarcube:TCubeDimension DisplayName="Default View.fecha oper" UniqueName="[Default View.fecha oper]">
                        <Hierarchies>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeYear" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="fecha_oper" DisplayFieldType="System.String" DisplayName="fecha oper - Year" IDField="fecha_oper" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="a968722b-9f7a-4127-9445-367aba39f234" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeQuarter" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="fecha_oper" DisplayFieldType="System.String" DisplayName="fecha oper - Quarter" IDField="fecha_oper" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="63214f17-50c8-4b3a-8d0e-786eaa328bc8" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeMonthLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="fecha_oper" DisplayFieldType="System.String" DisplayName="fecha oper - Month (full name)" IDField="fecha_oper" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="26eaa557-eb2b-40da-af38-b34b3ad4850c" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy BIMembersType="ltTimeDayOfWeekLong" CalculatedByRows="True" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="fecha_oper" DisplayFieldType="System.String" DisplayName="fecha oper - Day of week (long name)" IDField="fecha_oper" Origin="hoAttribute" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="e0ad3d8c-9871-4a7e-a3fa-9d9e4ce6ca8a" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                            <radarcube:TCubeHierarchy Children="a968722b-9f7a-4127-9445-367aba39f234|63214f17-50c8-4b3a-8d0e-786eaa328bc8|26eaa557-eb2b-40da-af38-b34b3ad4850c|e0ad3d8c-9871-4a7e-a3fa-9d9e4ce6ca8a" DataTable="DefaultView" DiscretizationBucketFormat="%{First} - %{Last}" DisplayField="fecha_oper" DisplayFieldType="System.DateTime" DisplayName="fecha oper" IDField="fecha_oper" IDFieldType="System.DateTime" Origin="hoUserDefined" TotalCaption="Total" TypeOfMembers="htDates" UniqueName="c413f4e4-f3c9-43b7-a4ba-9e5af2edea8b" UnknownMemberName="Unknown">
                            </radarcube:TCubeHierarchy>
                        </Hierarchies>
                    </radarcube:TCubeDimension>
                </Dimensions>
                <CubeTablePositions>
                    <cc1:TCubeTablePosition Name="DefaultView" Position="216, 0" />
                </CubeTablePositions>
            </cc1:TOLAPCube>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [vCuboOperaciones]"></asp:SqlDataSource>
        </div>

    </form>
</body>
</html>
