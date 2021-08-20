/*!
 * Scripts para las ventanas flotantes


 * Date: Mon Jan 25 19:43:33 2010 -0500
 */
function makeDoubleDelegate(function1, function2) {
    return function () {
        if (function1)
            function1();
        if (function2)
            function2();
    };
}

window.onload = makeDoubleDelegate(window.onload, AltoGrid);

function AltoGrid() {
    var el = null;
    try {
        if (document.all) {
            el = document.all('RadGrid1_GridData');
            el.style.height = 'auto';
        } else if (document.getElementById) {
            el = document.getElementById('RadGrid1_GridData');
            el.style.height = 'auto';
        }
    }
    //catch (e) {
    //}
}
function ventanaSecundaria(URL, ancho, alto) {

    derecha = (screen.width - ancho) / 2;
    arriba = (screen.height - alto) / 2;
    string = "toolbar=0,scrollbars=1,directories=0,location=0,statusbar=0,menubar=0,resizable=1,width=" + ancho + ",height=" + alto + ",left=" + derecha + ",top=" + arriba + "";
    fin = window.open(URL, "", string);
}

function MensajePopup(mensaje) {
    alert(mensaje);
}

function Delete() {
    if (window.confirm("Estas intentando borrar un registro, Confirma que desea continuar?"))
    {

        __doPostBack("borrar");
    }
    else
    {
        __doPostBack("");
    }
}

function DeleteIncremento() {
    if (window.confirm("Estas intentando borrar el incremento seleccionado, Confirma que desea continuar?")) {

        __doPostBack("borrarincremento");
    }
    else {
        __doPostBack("");
    }
}

function onRequestStart(sender, args) {
    if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
          args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
          args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
          args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
        args.set_enableAjax(false);
    }
}

function ClosePage() {
    try {
        GetRadWindow().Close();
    } catch (e) {
        var error = e.description;
    }
}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}


function VentanaEditar(ventana, ancho, alto, NombreAjax) {

    $find(NombreAjax).ajaxRequest();
    var oWnd = window.radopen(ventana);
    oWnd.setSize(ancho, alto);
    oWnd.moveTo(10, 1);
    oWnd.maximize();
    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Maximize);

}



