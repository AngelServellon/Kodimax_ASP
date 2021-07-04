
$(document).ready(function () {
    $('#Pagar').click(function () {
        //Elementos donde esta el formulario y el ticket
        var formulario = $("#formulario");
        var ticket = $("#ticket");

        var total = parseFloat($('[name="total"]').val());
        var pagar = parseFloat($('[name="pago"]').val());
        var cambio = pagar - total;
        var cambio_redondeado = cambio.toFixed(2);

        if (pagar > total) {
            $('.texto').text("Su cambio es: $" + cambio_redondeado + ", gracias por comprar en KODIMAX");

            $("#formulario").removeClass("poner");
            $("#formulario").addClass("quitar");

            $("#ticket").removeClass("quitar");
            $("#ticket").addClass("poner");
        }
        else if (pagar < total || pagar == isNaN()) {
            $('.texto').text("Pago insuficiente");
            $('[name="pago"]').val = "";
        }
        else {
            $('.texto').text("Cobro exacto, gracias por comprar en KODIMAX");

            $("#formulario").removeClass("poner");
            $("#formulario").addClass("quitar");

            $("#ticket").removeClass("quitar");
            $("#ticket").addClass("poner");
        }

        //console.log(total);
        console.log(pagar);
        ////console.log(cambio_redondeado);
    });
});