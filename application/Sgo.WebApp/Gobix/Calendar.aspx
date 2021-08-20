<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Calendar.aspx.vb" Inherits="Sgo.WebApp.Calendar" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <title>Calendario Días Hábiles</title>

    <link rel="Stylesheet" href="../Styles/Calendar.css"  type="text/css" />

</head>
<body>


<body style="background-color: #F1F5FB;">

    <script type="text/javascript">

        function RefreshParentPage() {
            GetRadWindow().Close();
            GetRadWindow().BrowserWindow.location.reload();
        }

        function RedirectParentPage(newUrl) {
            GetRadWindow().BrowserWindow.document.location.href = newUrl;
            GetRadWindow().Close();
        }

        function CallFunctionOnParentPage(fnName) {
            alert("Calling the function " + fnName + " defined on the parent page");
            var oWindow = GetRadWindow();
            if (oWindow.BrowserWindow[fnName] && typeof (oWindow.BrowserWindow[fnName]) == "function") {
                oWindow.BrowserWindow[fnName](oWindow);
            }
        }


        function ClientClose() {
            $find("RadAjaxManager1").ajaxRequest();
        }

        function OnClientItemsRequesting(sender, e) {
            if (sender.get_appendItems()) e.get_context().CustomText = "";
            else e.get_context().CustomText = sender.get_text();
        }

        if (!document.all) {
            window.onbeforeunload = function () {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);
            }
        }

        function endRequest(sender, e) {
            err = e.get_error();
            if (err) {
                if (err.name == "Sys.WebForms.PageRequestManagerServerErrorException") {
                    e.set_errorHandled(true);
                }
            }
        }

        function CloseAndRebind() {
            GetRadWindow().Close();
            GetRadWindow().BrowserWindow.refreshGrid(null);
        }

       
        function CancelEdit() {
            GetRadWindow().Close();
        }


    </script>
	
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadCalendar1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadCalendar1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadCalendar ID="RadCalendar1" runat="server" AutoPostBack="true" Skin="Special"
        EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false" EnableMonthYearFastNavigation="false"
        DayNameFormat="Short" ShowRowHeaders="false" ShowOtherMonthsDays="false" OnDefaultViewChanged="RadCalendar1_DefaultViewChanged">

         <HeaderTemplate>
            <asp:Image ID="HeaderImage" runat="server" Width="757" Height="94" Style="display: block">
            </asp:Image>
        </HeaderTemplate>
        <FooterTemplate>
            <asp:Image ID="FooterImage" runat="server" Width="757" Height="70" Style="display: block">
            </asp:Image>
        </FooterTemplate>

        <SpecialDays>
            <telerik:RadCalendarDay Date="2009/06/12" Repeatable="DayInMonth" TemplateID="DateTemplate">
            </telerik:RadCalendarDay>
            <telerik:RadCalendarDay Date="2009/06/19" Repeatable="DayInMonth" TemplateID="DateTemplate">
            </telerik:RadCalendarDay>
            <telerik:RadCalendarDay Date="2009/06/17" Repeatable="DayInMonth" TemplateID="MortgageTemplate">
            </telerik:RadCalendarDay>
            <telerik:RadCalendarDay Date="2009/06/8" Repeatable="DayAndMonth" TemplateID="BirthdayTemplate">
            </telerik:RadCalendarDay>
            <telerik:RadCalendarDay Date="2009/08/7" Repeatable="DayAndMonth" TemplateID="BirthdayTemplate">
            </telerik:RadCalendarDay>
            <telerik:RadCalendarDay Date="2009/10/8" Repeatable="DayAndMonth" TemplateID="BirthdayTemplate">
            </telerik:RadCalendarDay>
            <telerik:RadCalendarDay Date="2009/12/23" Repeatable="DayAndMonth" TemplateID="BirthdayTemplate">
            </telerik:RadCalendarDay>
            <telerik:RadCalendarDay Date="2010/2/14" Repeatable="DayAndMonth" TemplateID="BirthdayTemplate">
            </telerik:RadCalendarDay>
        </SpecialDays>

        <CalendarDayTemplates>
            <telerik:DayTemplate ID="DateTemplate" runat="server">
                <Content>
                    <div class="rcTemplate rcDayDate">
                        date
                    </div>
                </Content>
            </telerik:DayTemplate>
            <telerik:DayTemplate ID="MortgageTemplate" runat="server">
                <Content>
                    <div class="rcTemplate rcDayMortgage">
                        mortgage
                    </div>
                </Content>
            </telerik:DayTemplate>
            <telerik:DayTemplate ID="BirthdayTemplate" runat="server">
                <Content>
                    <div class="rcTemplate rcDayBirthday">
                        birthday
                    </div>
                </Content>
            </telerik:DayTemplate>
        </CalendarDayTemplates>
    </telerik:RadCalendar>
    </form>
</body>
</html>
