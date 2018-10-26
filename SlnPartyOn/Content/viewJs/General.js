var basepath = document.location.origin;

$.fn.serializeFormJSON = function () {

    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

$("#btnCerrarSesion").click(function () {
    $.ajax({
        type: 'POST',
        url: basepath + "/Usuario/CerrarSesionLoginJson",
        success: function (response) {
            var resp = response.respuesta;
            var msj = response.mensaje;
            if (resp) {
                toastr.success('Cerrando Sesión, Vuelva Pronto', 'Mensaje Servidor');
                window.location.replace(basepath + "/");
            } else {
                toastr.error(msj,'Mensaje Servidor');
            }
        }
    });
});