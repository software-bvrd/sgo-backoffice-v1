<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ConsultaFlutuacionTasa" Codebehind="ConsultaFlutuacionTasa.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fluctuación Tasa</title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
        <telerik:RadScriptManager ID="RadScriptManager1"
        Runat="server"></telerik:RadScriptManager>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Año : "></asp:Label>&nbsp;
            <telerik:RadNumericTextBox ID="RadNumericTextBox1" Runat="server"
            AutoPostBack="True" Culture="es-DO" MaxLength="4" MaxValue="2050" MinValue="1970">
                <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
            </telerik:RadNumericTextBox>
        </div>
        <div style="width: 800px; height: 500px;">
            <telerik:RadHtmlChart ID="RadHtmlChart1" runat="server" DataSourceID="SqlDataSource1"
            Height="471px" Width="794px">
                
                <ChartTitle Text="Fluctuación Tasa"></ChartTitle>
                
                <PlotArea>
                 
                    <XAxis>
                        <Items>
                            <telerik:AxisItem LabelText="Ene" />
                            <telerik:AxisItem LabelText="Feb" />
                            <telerik:AxisItem LabelText="Mar" />
                            <telerik:AxisItem LabelText="Abr" />
                            <telerik:AxisItem LabelText="May" />
                            <telerik:AxisItem LabelText="Jun" />
                            <telerik:AxisItem LabelText="Jul" />
                            <telerik:AxisItem LabelText="Ago" />
                            <telerik:AxisItem LabelText="Sep" />
                            <telerik:AxisItem LabelText="Oct" />
                            <telerik:AxisItem LabelText="Nov" />
                            <telerik:AxisItem LabelText="Dic" />
                        </Items>
                    </XAxis>
                    
                 
                    <Series> 
                        <telerik:LineSeries  DataFieldY="TasaCompra" MissingValues="Gap" Name="Compra"></telerik:LineSeries>
                        <telerik:LineSeries DataFieldY="TasaVenta" MissingValues="Gap"   Name="Venta"></telerik:LineSeries>
                    </Series>

                </PlotArea>
            </telerik:RadHtmlChart>
        </div>
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>"
            SelectCommand="SELECT * FROM [vMonedasHistoricaTasasFlutuacion] WHERE ([Anyo] = @Anyo)" DataSourceMode="DataReader">
                <SelectParameters>
                    <asp:ControlParameter ControlID="RadNumericTextBox1" DefaultValue="2012"
                    Name="Anyo" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>


</html>
