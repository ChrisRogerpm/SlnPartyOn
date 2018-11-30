$(document).ready(function () {
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
                var Total = TotalFavoritosEvento(value.Id);
                $(".contenedor_evento_usuario").append('<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">\n' +
                    '        <div class="card-wrapper blue probando">\n' +
                    '            <div class="card clearfix">\n' +
                    '<span class="card-type">' + Total +'</span>' +
                    '                <a href="../Evento/EventoUsuarioEditarVistar/' + value.Id +'"> <img src="../Content/Evento/' + value.Imagen + '" class="img-thumbnail imagen-evento" alt="Arise Admin" style="margin-bottom:15px; height:200px;"> </a>\n' +
                    '                <h4><strong>' + value.Nombre_Evento +'</strong></h4>\n' +
                    '                <h5></h5>\n' +
                    '                <p>' + value.Descripcion_Evento+'</p>\n' +
                    '            </div>\n' +
                    '        </div>\n' +
                    '    </div>');
            });
        }
    });
}

function TotalFavoritosEvento(Id) {
    var Cantidad;
    $.ajax({
        type: 'POST',
        async: false,
        url: basepath + "/Evento/TotalFavoritosEventoJson",
        data: {
            'Id': Id
        },
        success: function (response) {
            var resp = response.data;
            Cantidad = resp;
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }
    });
    return Cantidad;
}









