angular.module("appModule",['ngRoute'])
    .config(
        function ($routeProvider,$locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider.when('/',{
                templateUrl : "board/board_View.html",
                controller : "homeController"
            }).otherwise({redirectTo:'/'})
        }
    )
;