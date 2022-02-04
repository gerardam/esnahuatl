//==== \ / ============================================== == ==
//==== 101 =====|<> Es-Nahuatl v:1.0 - 20/08/2016 </>|=== = ===
//== =10101= ===|    { The bug develop & network }   |=== === =
//== =01010= ===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==== 010 ============================================== = ===
jQuery(function ($) {
    buscaPalabras();
    validarClic();

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(buscaPalabras);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(validarClic);
});

function buscaPalabras() {
    $("#MainContent_txtBuscar").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "BuscaPalabra.asmx/ObtenerListaAutocomplete",
                data: "{ 'prefixText': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            value: item.split('-')[0],
                            valcon:item.split('-')[1]
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
        $("input[id$='txtBuscar']").val("");
        $("input[id$='txtBuscar']").blur();
    });
}