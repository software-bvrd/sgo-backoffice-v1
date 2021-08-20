<%@ Page Language="VB" AutoEventWireup="false" Inherits="Sgo.WebApp.Transacciones_ListaEmisionSerieCalendarioCambioTasas" CodeBehind="ListaEmisionSerieCalendarioCambioTasas.aspx.vb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Styles/Custom.css" />
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow;
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                    return oWindow;
                }

                function ClosePage() {
                    GetRadWindow().Close();
                }

                function ClientClose2() {

                    $find("RadAjaxManager1").ajaxRequest();
                    var oWnd = window.radopen("EditarEmision.aspx");

                    oWnd.setSize(1300, 600);
                    oWnd.moveTo(10, 1);

                    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Maximize);

                }
                
            </script>
        </telerik:RadCodeBlock>

        <div lang="es-do">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        </div>

        <div>


            <div>
                <telerik:RadToolBar ID="RadToolBar1" runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/add.png" Text="Nuevo"
                            Value="0">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" IsSeparator="True"
                            Text="Button 1">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/clear.gif"
                            Text="Cancelar" ToolTip="Cancelar Edición" Value="2">
                        </telerik:RadToolBarButton>
                    </Items>
                </telerik:RadToolBar>

            </div>

            <div class="Calendario">

                <telerik:RadScheduler ID="RadScheduler1" runat="server" DataDescriptionField="Description"
                    DataEndField="FechaEnd" DataKeyField="EmisionSerieCalendarioCambioTasasID"
                    DataRecurrenceField="RecurrenceRule" DataRecurrenceParentKeyField="RecurrenceParentID"
                    DataReminderField="Reminder" DataSourceID="SqlEmisionSerieCalendarioCambioTasas"
                    DataStartField="FechaStart" DataSubjectField="Subject" EnableDescriptionField="True"
                    ReadOnly="True" EnableRecurrenceSupport="False" EnableViewState="False"
                    SelectedView="MultiDayView" Culture="es-DO" Localization-ShowBusinessHours="Mostrar Horas Laborables..."
                    Localization-Show24Hours="Mostrar 24 Horas..." Localization-Save="Guardar"
                    Localization-ShowAdvancedForm="Opciones" Localization-ShowMore="más..."
                    Localization-ReminderWeek="semana" Localization-ReminderWeeks="semanas"
                    Height="420px">
                    <ExportSettings FileName="Calendario" OpenInNewWindow="True"></ExportSettings>
                    <%--Cambia los colores--%>
                    <ResourceTypes>
                        <telerik:ResourceType DataSourceID="SqlDataSourceStatus" ForeignKeyField="StatusId"
                            KeyField="StatusId" Name="Estatus" TextField="StatusDesc" />
                    </ResourceTypes>
                    <Localization AdvancedAllDayEvent="Todo el día" AdvancedCalendarToday="Hoy"
                        AdvancedNewAppointment="Nuevo" AdvancedSubject="Asunto" HeaderDay="Día"
                        HeaderMonth="Mes" HeaderTimeline="Línea de Tiempo" HeaderToday="Hoy" HeaderWeek="Semana"
                        ReminderHour="Hora" ReminderHours="Horas" ReminderMinute="Minuto" ReminderMinutes="Minutos"
                        ReminderNone="Nada" ReminderWeek="semena" ReminderWeeks="semanas" Save="Guardar"
                        Show24Hours="Mostrar 24 Horas..." ShowMore="Más..." AllDay="todo el día" />
                    <AppointmentContextMenus>
                        <telerik:RadSchedulerContextMenu runat="server" ID="ContextMenu1">
                            <Items>
                                <%-- <telerik:RadMenuItem Text="Nueva Cita" Value="NC" runat="server"
                                    />--%>
                                <telerik:RadMenuItem Text="Editar" Value="Editar" runat="server" />
                                <telerik:RadMenuItem Text="Imprimir" Value="CommandPrint" runat="server" />
                                <telerik:RadMenuItem Text="Borrar" Value="BR" runat="server" />
                            </Items>
                        </telerik:RadSchedulerContextMenu>
                        <telerik:RadSchedulerContextMenu runat="server" ID="SchedulerAppointmentContextMenu">
                            <Items>
                                <telerik:RadMenuItem Text="Editar" Value="CommandEdit" runat="server" />
                                <telerik:RadMenuItem Text="Borrar" Value="CommandDelete" runat="server" />
                                <telerik:RadMenuItem Text="Imprimir" Value="CommandPrint" runat="server" />
                            </Items>
                        </telerik:RadSchedulerContextMenu>
                    </AppointmentContextMenus>
                    <Reminders Enabled="True" />
                </telerik:RadScheduler>




            </div>

        </div>


        <div>
            <asp:SqlDataSource ID="SqlEmisionSerieCalendarioCambioTasas" runat="server"
                ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT * FROM [vEmisionSerieCalendarioCambioTasas]  WHERE (FechaStart &lt; @RangeEnd) AND (FechaEnd &gt; @RangeStart) OR (RecurrenceRule &lt;&gt; '') OR (RecurrenceParentID IS NOT NULL)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1900/1/1" Name="RangeEnd" />
                    <asp:Parameter DefaultValue="2900/1/1" Name="RangeStart" />
                </SelectParameters>
            </asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Behaviors="Close, Maximize, Move"
                Height="500px" Width="800px" BackColor="#F1F5FB" VisibleStatusbar="False"
                Modal="True" EnableViewState="false">
            </telerik:RadWindowManager>
            <asp:SqlDataSource ID="SqlDataSourceStatus"
                runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" SelectCommand="SELECT [StatusId], [StatusDesc] FROM [AppointmentStatus]"></asp:SqlDataSource>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
