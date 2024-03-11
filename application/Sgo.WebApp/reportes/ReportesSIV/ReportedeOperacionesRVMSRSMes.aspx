<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportedeOperacionesRVMSRSMes.aspx.vb" Inherits="Sgo.WebApp.ReportedeOperacionesRVMSRSMes" %>


<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=10.1.16.615, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIV - Reporte de Operaciones RF MS-RS Mes</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                <Items>



                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/WindowMove.png"
                        Text="Mover" ToolTip="Mover a Ventana" Value="7">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" IsSeparator="True" Text="Button 7">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                        Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                    </telerik:RadToolBarButton>


                </Items>
            </telerik:RadToolBar>
            <br />

            <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="1000px"
                Width="100%" ViewMode="PrintPreview" ShowZoomSelect="True"></telerik:ReportViewer>

            <br />

        </div>
    </form>
</body>
</html>
