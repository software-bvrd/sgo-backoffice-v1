<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfConsultaEstadoOperaciones1.aspx.vb" Inherits="Sgo.WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <div>
               <asp:Button ID="BtnConsultaOperacionesCevaldom" runat="server" Text="Consultar"   OnClick="EstadosOperacionesWS" />
        </div>
         <div>
            <textarea id="TextArea1" cols="20" rows="50" runat="server"  style="width:100%"></textarea>
               </div>
           <div> 
    </form> 
</body>
</html>
