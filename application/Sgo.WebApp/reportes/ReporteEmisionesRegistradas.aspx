<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.ReporteEmisionesRegistradas" Codebehind="ReporteEmisionesRegistradas.aspx.vb" %>







<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=10.1.16.615, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reporte Emisiones Registradas</title>
     <script src="../Scripts/Ventanas.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Styles/Custom.css" />   
    <style type="text/css">   
    html#html, body#body, form#form1, div#content
    { 
        height: 710px;
    }
    </style>

</head>
<body  id="body" style="background-color: #F1F5FB; margin-bottom:0px">
       
        <form id="form1" runat="server" style="background-color: #F1F5FB">
            <div id="content" >
              
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
              
                 <telerik:ReportViewer ID="ReportViewer1" runat="server" height="100%"
                Width="100%" ViewMode="PrintPreview">
                    

                   <Resources CurrentPageToolTip="Página Actual" ExportButtonText="Exportar"
                    ExportSelectFormatText="Exportar al Formato Seleccionado" ExportToolTip="Exportar"
                    FirstPageToolTip="Primera Página" LabelOf="de" LastPageToolTip="Ultima Página"
                    NextPageToolTip="Próxima Página" PrintToolTip="Imprimir" ProcessingReportMessage="Generando Reporte..."
                    RefreshToolTip="Actualizar" PreviousPageToolTip="Página Anterior" 
                    ReportParametersPreviewButtonText="Visualizar" 
                    ReportParametersSelectAllText="&lt;Seleccionar Todo&gt;" 
                    ZoomToWholePage="Página Completa" 
                    ReportParametersInputDataError="Falta o valor de parámetro no válido. Por favor, ingrese datos de entrada válidos para todos los parámetros." 
                    ReportParametersInvalidValueText="Valor incorrecto" 
                    ReportParametersNoValueText="Valor requerido" ParametersToolTip="Clic aquí para abrir el area de parámetros|Clic aquí para cerrar el area de parámetros" TogglePageLayoutToolTip="Cambiar a  modalidad interactiva|Cambiar a modalidad de Vista Previa" ZoomToPageWidth="Ancho Página" SessionHasExpiredError="La sesión ha expirado" SessionHasExpiredMessage="Por favor, actualice la página." ReportParametersSelectAValueText="<seleccionar un valor>"></Resources>
                

              </telerik:ReportViewer>
            
            </div>
        </form>
    </body>
</html>
