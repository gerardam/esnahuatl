function BloqueoIntro(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) {
        return true;
    }
    if (tecla == 13) {
        return false;
    }
}
function validarPwd(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-z0-9&#*_$\%\/]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarLetrasYEspacio() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true;// if (tecla == 13) return false;
    patron = /[A-Za-zÑñÁÉÍÓÚáéíóúÅâÊêÎîÔôÛûÄäËëÏïÜüŸÿÖößÆæŒœÇçÀàÈèÙùÒòÌì\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarTelefono() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[0-9()\-\/.]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarMail() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-z0-9@_.\-]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarMail2() {
    expr = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    email = $("input[name$='txtCorreoE']").val();
    res = expr.test(email);
    if (!res)
        $("input[name$='txtCorreoE']").addClass("error");
    return res;
}

function validarWeb() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-z0-9ÑñÁÉÍÓÚáéíóúÅâÊêÎîÔôÛûÄäÆæŒœÇçÀàÈèÙùÒòÌì_.\/\-]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarNumerico() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[0-9.]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarPorcentaje() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[0-9%]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarDireccion() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-zÑñÁÉÍÓÚáéíóú0-9()#.\/\-:.;,&\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarNombres() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-zÑñÁÉÍÓÚáéíóú.,&\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarNumerosYLetrasConEspacio() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true;
    if (tecla == 13) return false;
    patron = /[A-Za-zÑñÁÉÍÓÚáéíóú0-9\s.,&-]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarNumerosYLetrasSinEspacio() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-zÑñÁÉÍÓÚáéíóú0-9.,&]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarAlfanumerico() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-zÑñÁÉÍÓÚáéíóú0-9_.]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarRFC() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-z0-9&]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarCURP() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-z0-9]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarNumerosLetrasYCaracteres() {
    tecla = (document.all) ? event.keyCode : event.which;
    if (tecla == 8) return true; if (tecla == 13) return false;
    patron = /[A-Za-zÑñÁÉÍÓÚáéíóú0-9!¡@#$%&\/()=¿?*-_+:;.,<>\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function converMayus(val) {
    return val.toUpperCase();
}

function converMinus(val) {
    return val.toLowerCase();
}
function validarMaxLength(Control, maxlength) {

    if (Control.value.length > maxlength) {
        Control.value = Control.value.substring(0, maxlength);

    }
}
function beginRequest(sender, args) {
    var r = args.get_request();
    if (r.get_headers()["X-MicrosoftAjax"]) {
        b = r.get_body();
        var a = "__MicrosoftAjax=" + encodeURIComponent(r.get_headers()["X-MicrosoftAjax"]);
        if (b != null && b.length > 0) {
            b += "&";
        }
        else
            b = "";
        r.set_body(b + a);
    }
}
Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequest);