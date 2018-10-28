$(document).ready(function () {
    $(".RegistrarLogin").click(function () {
        var url = basepath + "/Usuario/LoginRegistroVista";
        window.location.replace(url);
    });
    $(".btnIniciarSesion").click(function () {
        var url = basepath + "/Usuario/IniciarSesionLoginJson";
        var Email = $("#txtEmail").val();
        var Pwd = $("#txtPassword").val();
        if (Email === "") {
            toastr.error('Ingrese el campo Email', 'Mensaje Servidor');
            return false;
        }
        if (Pwd === ""){
            toastr.error('Ingrese el campo Contraseña', 'Mensaje Servidor');
        }
        var dataForm = { Email: Email, Password: Pwd };
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(dataForm),
            success: function (response) {
                var resp = response.respuesta;
                var msj = response.mensaje;
                var tipo_usuario = response.usuario_;
                if (resp) {
                    toastr.success('Bienvenido al Sistema', 'Mensaje Servidor');
                    if (tipo_usuario === 1) {
                        window.location.replace(basepath + "/Administrativo/");
                    } else {
                        window.location.replace("../Usuario/InicioUsuarioVista");
                    }
                } else {
                    toastr.error(msj, 'Mensaje Servidor');
                }
            }
        });

    });
});