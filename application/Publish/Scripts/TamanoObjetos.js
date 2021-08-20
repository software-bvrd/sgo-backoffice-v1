/*!
 * Scripts el tamaño de los objetos grid


 * Date: Mon Jan 25 19:43:33 2010 -0500
 */
function makeDoubleDelegate(function1, function2) {
    return function () {
        if (function1)
            function1();
        if (function2)
            function2();
    }
}

window.onload = makeDoubleDelegate(window.onload, AltoGrid);

function AltoGrid() {
    var el = null;
    if (document.all) {
        el = document.all('RadGrid1_GridData');
        el.style.height = 'auto';
    } else if (document.getElementById) {
        el = document.getElementById('RadGrid1_GridData');
        el.style.height = 'auto';
    }
}

