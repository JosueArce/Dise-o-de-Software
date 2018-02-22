/*
* Controller encargado de manejar el acceso y registro de usuarios en el sistema
* Se apoya del Factory ---- que permite hacer las conexiones con el API Facebook o Google y con la Base de Datos
* */

angular.module("appModule")
    .controller("Login_Controller",function ($scope) {
        $scope.mensaje = "Prueba";
    })
;

