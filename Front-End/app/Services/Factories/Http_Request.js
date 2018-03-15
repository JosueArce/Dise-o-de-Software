angular.module("loginModule")
    .factory("HttpRequest",function ($http) {
        var obj = {
            http_request : function (http_data,callback) {
                $http({
                    method : http_data.method,
                    url : "http://localhost:50714/logIn",
                    params : http_data.PersonasActivas
                }).then(function successCallback(response) {
                    callback(response);
                }).catch(function errorCallback(response) {
                    callback(response);
                })
            }
        };
        return obj;
    })
;