$(document).ready(function () {
    linea();
});
function linea() {
    Highcharts.chart('container', {
        chart: {
            type: 'line'
        },
        title: {
            text: 'Categorias de Eventos'           
        },
        subtitle: {
            text: ''
        },
        xAxis: {
            categories: ['Enero', 'Febrero', 'Mar', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Setiembre', 'Octtubre', 'Noviembre', 'Diciembre']
        },
        yAxis: {
            title: {
                text: 'Número de Eventos'
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
        series: [{
            name: 'Eventos',
            data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]
        }]
    });

}


