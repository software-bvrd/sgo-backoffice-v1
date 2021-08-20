<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BB_RentaVariableMercadoSecundarioTopTitulosTransadosMes.aspx.vb" Inherits="Sgo.WebApp.BB_RentaVariableMercadoSecundarioTopTitulosTransadosMes" %>



<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=10.1.16.615, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BB | Mercado Secundario Top N Títulos Transados en el Mes RV</title>
    <script src="../Scripts/Ventanas.js" type="text/javascript"></script>

</head>
<body style="background: #F1F5FB">
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
            <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

            <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                <Items>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" Text="Nuevo"
                        Value="0" Visible="False">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 1" Visible="False">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/edit.png"
                        Text="Editar" ToolTip="Editar Información" Value="1" Visible="False">
                    </telerik:RadToolBarButton>

                    <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/ActivarEmision.png"
                        Text="Activar" ToolTip="Activar Emisión" Value="8" Visible="False">
                    </telerik:RadToolBarButton>


                    <telerik:RadToolBarButton runat="server" IsSeparator="True"
                        Text="Button 3" Visible="False">
                    </telerik:RadToolBarButton>

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
                Width="100%" ViewMode="PrintPreview"></telerik:ReportViewer>

            <br />

        </div>
    </form>
</body>
</html>

