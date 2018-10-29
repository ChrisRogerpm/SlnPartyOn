$(document).ready(function () {
    MostrarDatosUsuario();
});

function MostrarDatosUsuario() {
    var url = basepath + "/Usuario/UsuarioIdObtenerJson";
    $.ajax({
        url: url,
        type: "POST",
        contentType: "application/json",
        success: function (response) {
            var resp = response.data;
            $("#txtNombre").val(resp.Nombre);
            $("#txtApellido").val(resp.Apellido);
            $("#txtTelefono").val(resp.Telefono);
            $("#txtEmail").val(resp.Email);
            $("#txtFecha").val(moment(resp.FechaRegistro).format('YYYY-MM-DD'));
            $(".user-img").empty().append('<img src="../Content/Usuario/' + resp.Imagen + '" alt="' + resp.Nombre+'" />');
        }
    });
}