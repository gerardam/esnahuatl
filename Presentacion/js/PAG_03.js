//==== \ / ============================================== == ==
//==== 101 =====|<> Es-Nahuatl v:1.0 - 20/08/2016 </>|=== = ===
//== =10101= ===|    { The bug develop & network }   |=== === =
//== =01010= ===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==== 010 ============================================== = ===
jQuery(function ($) {
    ValidacionCampo();
    AgregarValidador();
    buscaPalabras();

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ValidacionCampo);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(AgregarValidador);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(buscaPalabras);
});

function ValidacionCampo() {
    $("input[id$='txtEspaniol']").attr("maxlength", 50).bind("keypress", validarNumerosYLetrasConEspacio);
    $("input[id$='txtNahuatl']").attr("maxlength", 50).bind("keypress", validarNumerosYLetrasConEspacio);
    $("input[id$='txtTipo']").attr("maxlength", 30).bind("keypress", validarNumerosYLetrasConEspacio);
    $("input[id$='Url']").attr("maxlength", 250).bind("keypress", validarWeb);
    $("input[id$='txtDescripcion']").attr("maxlength", 250).bind("keypress", validarNumerosYLetrasConEspacio);
}

function AgregarValidador() {
    $("input[id$='txtEspaniol']").addClass("required");
    $("input[id$='txtNahuatl']").addClass("required");
    $("input[id$='txtTipo']").addClass("required");

    $('[id$=lnkAceptar]').on('click', function (event) {
        var isValid = ValidateAndSubmit(".validationGroup");
        if (!isValid)
            return false;
    });
    ValidateAndSubmit(".validationGroup");
}

function ValidateAndSubmit(validationGroup) {
    var $group = $(validationGroup);
    var isValid = true;
    $group.find(':input[type=text]').each(function (i, item) {
        if (item.type == "select-one") {
            if (item[0].selected == true) {
                var par = $(item).before();
                if (par.hasClass("required") && item[0].selected == true) {
                    isValid = false;
                    par.addClass("error");
                }
            }
        }
        else if (!$(item).valid() && !$(item).hasClass('valid')) {
            isValid = false;
        }
    });
    return isValid;
}

function buscaPalabras() {
    $("#MainContent_txtBusca").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../BuscaPalabra.asmx/ObtenerListaAutocomplete",
                data: "{ 'prefixText': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item.split('-')[0],
                            valcon: item.split('-')[1]
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        select: function (e, i) {
            $("#MainContent_hdComerId").val(i.item.valcon);
            itemSel(i.item.valcon);
        },
        minLength: 2 // MINIMUM 2 CHARACTER TO START WITH.
    });
}

function itemSel(valor) {
    document.getElementById("MainContent_hdComerId").value = valor;
    __doPostBack("MainContent_hdComerId", "");
}

function validarClic() {
    $('[id$=btnBuscar]').on('click', function (event) {
        $("input[id$='txtBusca']").val("");
        $("input[id$='txtBusca']").blur();
    });
}