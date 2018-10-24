$(document).ready(function () {
    $(".IniciarLogin").click(function () {
        var url = basepath + "/Usuario/LoginVista";
        window.location.replace(url);
    });

    $(".btnRegistrar").click(function () {
        var url = basepath + "/Usuario/UsuarioRegistrarLoginJson";
        var Pwd = $("#txtPassword").val();
        var PwdConfirm = $("#txtPasswordConfirm").val();
        var dataForm = $('#frmNuevo').serializeFormJSON();
        if (Pwd === PwdConfirm) {
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
                            window.location.replace(basepath + "/Usuario/InicioUsuarioVista");
                        }
                    } else {
                        toastr.error(msj, 'Mensaje Servidor');
                    }
                }
            });
        } else {
            toastr.error('Las contraseñas no coinciden', 'Mensaje Servidor');
        }
        
    });

});