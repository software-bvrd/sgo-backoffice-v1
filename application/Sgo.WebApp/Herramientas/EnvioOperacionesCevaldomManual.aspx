<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EnvioOperacionesCevaldomManual.aspx.vb" Inherits="Sgo.WebApp.EnvioOperacionesCevaldomManual" Debug="true" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <title>Envio de Operación Manual a Liquidación</title>
    <script type="text/javascript">
        function _EnviarOP(sender, args) {
            __doPostBack("EnviarOP");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <ul class="list-group">
                <li class="list-group-item active">
                    <table>
                        <tr>
                            <td class="col-lg-9">
                                <h3>Envio Manual a Liquidación</h3>
                                <asp:Label ID="lblNoOperacion" Text="OPERACION #: " runat="server"></asp:Label>
                            </td>
                            <td class="col-lg-3" style="text-align: right;">
                                <asp:Button ID="BtnEnviarOperaciones" runat="server" Text="Enviar" class="btn btn-success btn-lg" OnClick="GenerarToken" />
                            </td>
                               
                        </tr>
                        <tr>
                            <td class="col-lg-12">
                                <asp:Label ID="lblMensaje" runat="server" Text="MENSAJE:"></asp:Label>
                                <asp:Label ID="InjectScriptLabelImprimir" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </li>
            </ul>
            <div class="row">
                <table>
                    <tr>
                         <td class="col-lg-9">
                               <label for="txtDescripcionInmueble" class="control-label" style="color: black">
                               <strong>Operación a Enviar</strong></label>
                            <textarea id="txtxmloperacion" cols="100" rows="24" runat="server"></textarea>
                        </td>
                          <td class="col-lg-3">
                               <label for="txtDescripcionInmueble" class="control-label" style="color: black">
                               <strong>Respuesta del Envio</strong></label>
                            <textarea id="txtxmlMensaje" cols="100" rows="24" runat="server"></textarea>
                        </td>
                    </tr>
            </div>
        </div>
    </form>
</body>

</html>
