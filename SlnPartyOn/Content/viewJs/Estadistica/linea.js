$(document).ready(function () {
    pie();

});
function pie() {

    var url = basepath + "/Evento/EventosporMesJson";

    // Build the chart
    $.ajax({
        url: url,
        type: "POST",
        contentType: "application/json",
        success: function (response) {

            var resp = response.data;

            var myarray = [];

            $.each(resp, function (key, value) {
                myarray.push({
                    'name': value.Descripcion_Categoria,
                    'data': value.Cantidad_Evento
                })

               
            });
            //pie

            Highcharts.chart('container', {
                chart: {
                    type: 'line'
                },
                title: {
                    text: 'Eventos por Mes'
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    categories: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Setiembre', 'Octubre', 'Noviembre', 'Diciembre']
                },
                yAxis: {
                    title: {
                        text: 'Cantidad de Eventos'
                    }
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: false
                    }
                },
                series: myarray
            });
            //pien end
        }
    });
}


