$(document).ready(function () {
    MostrarEvento();
    $("#btnRegistrarEvento").click(function () {
        if ($("#cboEstado").val() == 1) {
            $("#txtEstado").val(true);
        } else {
            $("#txtEstado").val(false);
        }
        var formData = new FormData($("#frmNuevo")[0]);
        var url = basepath + "/Evento/EventoUsuarioEditarJson";

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
                    toastr.success('Se ha Modifico el evento exitosamente', 'Mensaje Servidor');
                } else {
                    toastr.error(msj, 'Mensaje Servidor');
                }
            }
        });
    });
});

function MostrarEvento() {
    $.ajax({
        type: 'POST',
        url: basepath + "/Evento/EventoUsuarioIDObtenerJson",
        data: {
            'Id': $("#txtId").val()
        },
        success: function (response) {
            var resp = response.respuesta;
            var respdata = response.data;
            var msj = response.mensaje;
            if (resp) {
                $("#txtId").val(respdata.Id);
                $("#txtNombre_Evento").val(respdata.Nombre_Evento);
                $("#txtDescripcion_Evento").val(respdata.Descripcion_Evento);
                $("#txtDireccion_Evento").val(respdata.Direccion_Evento);
                ListarCategorias(respdata.CategoriaId);
                $("#txtFechaInicioEvento").val(moment(respdata.FechaInicioEvento).format('YYYY-MM-DD'));
                console.log(moment(respdata.FechaInicioEvento).format('YYYY/MM/DD'));
                console.log(moment(respdata.FechaInicioEvento).format('DD/MM/YYYY'));
                $("#txtHoraEvento").val(respdata.HoraEvento);
                $("#us3-lat").val(respdata.latitud);
                $("#us3-lon").val(respdata.longitud);

                if (respdata.Estado_Evento == true) {
                    $("#cboEstado").val(1);
                }
                else {
                    $("#cboEstado").val(0);
                }  

                IniciarMapa(respdata.latitud, respdata.longitud);
            } else {
                toastr.error(msj, 'Mensaje Servidor');
            }
        }
    });
}

function ListarCategorias(CategoriaIdEditar) {
    $.ajax({
        type: 'POST',
        url: basepath + "/Categoria/CategoriaListarJson",
        success: function (response) {
            var resp = response.data;
            $("#cboCategoriaId").empty().append('<option value>--Seleccione--</option>');;
            $.each(resp, function (key, value) {
                $("#cboCategoriaId").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
            });
            $("#cboCategoriaId").val(CategoriaIdEditar).change();
        }
    });
}

function IniciarMapa(Latitud,Longitud) {
    $('#us3').locationpicker({
        location: {
            latitude: Latitud,
            longitude: Longitud
        },
        radius: 300,
        inputBinding: {
            latitudeInput: $('#us3-lat'),
            longitudeInput: $('#us3-lon'),
            radiusInput: $('#us3-radius'),
            locationNameInput: $('#txtLocalizacion')
        },
        enableAutocomplete: true,
        onchanged: function (currentLocation, radius, isMarkerDropped) {
            // Uncomment line below to show alert on each Location Changed event
            // alert("Location changed. New location (" + currentLocation.latitude + ", " + currentLocation.longitude + ")");
        }
    });
}
