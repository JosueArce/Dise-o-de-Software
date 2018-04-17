angular.module("appModule",['ngRoute'])
    .config(
        function ($routeProvider,$locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider.when('/board',{
                templateUrl : "board/board_View.html",
                controller : "boardController"
            }).when('/newSession',{
                templateUrl : "new_session/new_session_View.html",
                controller : "new_session_Controller"
            }).when('/status',{
                templateUrl : "status/status_View.html",
                controller : "status_Controller"
            }).when('/',{
                templateUrl : "home/home_View.html",
                controller : "home_Controller"
            }).when('/about',{
                templateUrl : "",
                controller : ""
            }).otherwise({redirectTo:'/'})
        }
    )
;