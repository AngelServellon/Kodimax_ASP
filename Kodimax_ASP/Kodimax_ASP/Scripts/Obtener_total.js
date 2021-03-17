
$(document).ready(function () {
    $('#Pagar').click(function () {
        //Elementos donde esta el formulario y el ticket
        var formulario = $("#formulario");
        var ticket = $("#ticket");

        var total = parseFloat($('[name="total"]').val());
        var pagar = parseFloat($('[name="pago"]').val());
        var cambio = pagar - total;
        var cambio_redondeado = cambio.toFixed(2);

        //ticket.append('<h2>KODIMAX</h2><br />\
        //        <span><strong>Id_Empleado:</strong>@Html.DisplayFor(model => model.id_empleado) <strong>Empleado: </strong></span > <br />\
        //        <p>@Html.DisplayFor(model => model.Fecha)</p><br />\
        //        <p><strong>SALA: </strong></p><br />\
        //        <p>@Html.DisplayNameFor(model => model.Cantidad) x $</p>\
        //        <p>         @Html.DisplayFor(model => model.SubTotal)</p>\
        //        <p>----------------------------------------------</p>\
        //        <p>Subtotal         @Html.DisplayFor(model => model.SubTotal)</p>\
        //        <p>Impuesto         @Html.DisplayFor(model => model.Tax)</p><br />\
        //        <p>TOTAL            @Html.DisplayNameFor(model => model.Total)</p>');

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