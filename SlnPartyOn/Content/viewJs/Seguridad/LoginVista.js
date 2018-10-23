$(document).ready(function () {
    $(".RegistrarLogin").click(function () {
        var url = basepath + "/Usuario/LoginRegistroVista";
        window.location.replace(url);
    });
});