$(document).ready(function () {
    ListarCategorias();
    $("#btnRegistrarEvento").click(function () {
        var formData = new FormData($("#frmNuevo")[0]);
        var url = basepath + "/Evento/EventoUsuarioRegistrarJson";
        $.ajax({
            async: true,
            type: 'POST',
            url: url,
            mimeType: "multipart/form-data",
            contentType: false,
            cache: false,
            processData: false,
            data: formData,
            dataType: "json",
            success: function (response) {
                var resp = response.respuesta;
                var msj = response.mensaje;
                if (resp) {
                    toastr.success('Se ha registrado el evento exitosamente', 'Mensaje Servidor');
                    $("select.select2-hidden-accessible").val(null).trigger("change");
                    $('input').val('');
                    $('textarea').val('');
                } else {
                    toastr.error(msj, 'Mensaje Servidor');
                }
            }
        });
    });
});

function ListarCategorias() {
    $.ajax({
        type: 'POST',
        url: basepath + "/Categoria/CategoriaListarJson",
        success: function (response) {
            var resp = response.data;
            $("#cboCategoriaId").empty().append('<option value>--Seleccione--</option>');;
            $.each(resp, function (key,value) {
                $("#cboCategoriaId").append('<option value="'+value.Id+'">'+value.Nombre+'</option>');
            });
        }
    });
}