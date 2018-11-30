﻿$(document).ready(function () {
    pie();
    
});
function pie() {

    var url = basepath + "/Categoria/EventosporCategoriaJson";
    
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
                    'name': value.Nombre,
                    'y': value.Total,
                })

            });
            //pie
            Highcharts.chart('container', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Eventos por Categoria'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },
                series: [{
                    name: 'Categorias',
                    colorByPoint: true,
                    data: [{
                        name: 'Musica',
                        y: 61.41                        
                    }, {
                        name: 'Gastronomia',
                        y: 11.84
                    }, {
                        name: 'Fiesta',
                        y: 10.85
                    }, {
                        name: 'Deportes',
                        y: 4.67
                    }, {
                        name: 'Otros',
                        y: 4.67
                    }]
                }]
            });
                //pien end
        }
    });

    
}


