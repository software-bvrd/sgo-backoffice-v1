<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EnvioOperacionesCevaldomManual.aspx.vb" Inherits="Sgo.WebApp.EnvioOperacionesCevaldomManual" Debug="true" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" />
    <title>Envio de Operación Manual a Liquidación</title>
    <script type="text/javascript">
        function _EnviarOP(sender, args) {
            __doPostBack("EnviarOP");
        }
    </script>
    <style type="text/css">
        .centered {
            position: fixed; /* or absolute if you prefer */
            top: 50%;
            left: 50%;
            width: 50%;
            transform: translate(-50%, -50%);
        }
        divmodal {
  border-style: solid;
  border-color: coral;
}
    </style>
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
                                <asp:Button ID="BtnEnviarOperaciones" runat="server" Text="Enviar" class="btn btn-success btn-lg" OnClick="MostrarEnvio" />
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
                       </table>
            </div>
        </div>

        <script>
            function CerrarEnvio() {
                document.getElementById("pnmodal").style.display = "none";
            }
        </script>
        <div class="centered">
            <asp:Panel ID="pnmodal" runat="server" Visible="false">
                <div class="modal-dialog" role="document" id="pnmodaldialog" runat="server">
                    <div class="modal-content" style="border-color:#007bff;border-style:solid">
                        <div class="modal-header">
                            <h5 class="modal-title">
                                <asp:Label ID="lblmensajeenvio" Text="Envio de Operaciones" runat="server"></asp:Label>
                            </h5> 
                        </div>
                        <div class="modal-body">
                            <p>Desea enviar las operaciones a liquidación?</p>
                        </div>
                        <div class="modal-footer"> 
                            <asp:Button ID="btnenviar" runat="server" class="btn btn-primary" Text="Si" OnClick="GenerarToken" />
                            <button type="button" id="Btncerrarmodal" class="btn btn-secondary" data-dismiss="modal" onclick="CerrarEnvio()">No</button>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>

</html>
