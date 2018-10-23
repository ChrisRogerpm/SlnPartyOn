$(document).ready(function () {
    $(".IniciarLogin").click(function () {
        var url = basepath + "/Usuario/LoginVista";
        window.location.replace(url);
    });
});