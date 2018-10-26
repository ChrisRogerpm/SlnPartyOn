﻿$(document).ready(function () {
    ListarEventoUsuario();
});

function ListarEventoUsuario() {
    var url = basepath + "/Evento/EventoUsuarioListarJson";
    $.ajax({
        url: url,
        type: "POST",
        contentType: "application/json",
        success: function (response) {
            var resp = response.data;
            $(".contenedor_evento_usuario").empty();
            $.each(resp, function (key, value) {
                $(".contenedor_evento_usuario").append('<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">\n' +
                    '        <div class="card-wrapper blue">\n' +
                    '            <div class="card clearfix">\n' +
                    '                <span class="card-type">1st</span>\n' +
                    '                <img src="../Content/Evento/' + value.Imagen + '" class="img-thumbnail" alt="Arise Admin">\n' +
                    '                <h4><strong>' + value.Nombre_Evento +'</strong></h4>\n' +
                    '                <h5></h5>\n' +
                    '                <p>' + value.Descripcion_Evento+'</p>\n' +
                    '            </div>\n' +
                    '            <ul class="card-actions clearfix">\n' +
                    '                <li>\n' +
                    '                    <a href="#" class="action-btn btn-Detalle" data-id="'+value.Id+'">\n' +
                    '                        <i class="icon-eye3"></i>\n' +
                    '                    </a>\n' +
                    '                </li>\n' +
                    '                <li>\n' +
                    '                    <a href="#" class="action-btn btn-Informacion"  data-id="' + value.Id +'">\n' +
                    '                        <i class="icon-info-with-circle"></i>\n' +
                    '                    </a>\n' +
                    '                </li>\n' +
                    '            </ul>\n' +
                    '        </div>\n' +
                    '    </div>');
            });

            $(".btn-Detalle").tooltip({
                title: "Detalle de Evento"
            });
            $(".btn-Informacion").tooltip({
                title: "Información de Evento"
            });
        }
    });
}