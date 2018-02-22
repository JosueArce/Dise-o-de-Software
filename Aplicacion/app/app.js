angular.module("appModule",['ngRoute'])
    .config(['$routeProvider',function ($routeProvider) {
        $routeProvider.when('/home',{
            templateUrl: "Templates/Home_View.html",
            controller: "Home_Controller"
        })
        .when('/login',{
            templateUrl: "Templates/Login_View.html",
            controller: "Login_Controller"
        })
    }])
;