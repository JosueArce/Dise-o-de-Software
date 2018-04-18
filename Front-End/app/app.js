angular.module("appModule",['ngRoute'])
    .config(
        function ($routeProvider,$locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider.when('/board/JvS',{
                templateUrl : "board/JvS/board_JvS_View.html",
                controller : "boardJvSController"
            }).when('/newSession/JvS',{
                templateUrl : "new_session/JvS/new_session_JvS_View.html",
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