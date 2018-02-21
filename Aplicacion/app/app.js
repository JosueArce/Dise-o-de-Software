angular.module("appModule",['ngRoute'])
    .config(['$routeProvider',function ($routeProvider) {
        $routeProvider.when('/home',{
            templateUrl: "Templates/Home_View.html",
            controller: "Home_Controller"
        })
    }])
;