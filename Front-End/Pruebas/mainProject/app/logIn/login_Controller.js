angular.module("loginModule",['ngRoute'])
    .config(
        function ($routeProvider,$locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider.when('/loginWindow',{
                templateUrl : "app/logIn/login_View.html",
                controller : "loginController"
            }).otherwise({redirectTo:'/loginWindow'})
        }
    )
    .controller("loginController",function ($scope,$location) {

        // This is called with the results from from FB.getLoginStatus().
        function statusChangeCallback(response) {
            setTimeout(function () {
                $scope.$apply(function () {
                    if (response.status === 'connected') {
                        // Logged into your app and Facebook.
                        testAPI();
                    } else {
                        // The person is not logged into your app or we are unable to tell.
                        document.getElementById('status').innerHTML = 'Please log ' +
                            'into this app.';
                    }
                });
            }, 500);

        }

        function checkLoginState() {
            FB.getLoginStatus(function(response) {
                statusChangeCallback(response);
            });
        }

        window.fbAsyncInit = function() {
            FB.init({
                appId      : '807099809474052',
                cookie     : true,  // enable cookies to allow the server to access
                                    // the session
                xfbml      : true,  // parse social plugins on this page
                version    : 'v2.12' // use graph api version 2.8
            });


            FB.getLoginStatus(function(response) {
                statusChangeCallback(response);
            });

        };

        // Load the SDK asynchronously
        (function(d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "https://connect.facebook.net/es_LA/sdk.js#xfbml=1&version=v2.12&appId=807099809474052&autoLogAppEvents=1";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));

        // Here we run a very simple test of the Graph API after login is
        // successful.  See statusChangeCallback() for when this call is made.
        function testAPI() {
            console.log('Welcome!  Fetching your information.... ');
            FB.api('/me', function(response) {
                document.getElementById('status').innerHTML =
                    'Thanks for logging in, ' + response.name + '!';
                $.notify("Thanks for logging in "+response.name,"success");
                getInfo();

                // setTimeout(function () {
                //     window.location.href = "Templates/Home_View.html/#!/board";
                // }, 2000);
            });
        }
        // Here we obtain extra information from the facebook api
        // Profile picture
        function getInfo() {
            FB.api('/me', 'GET', {fields: 'first_name,last_name,name,id,picture.width(150).height(150)'}, function(response) {
                //document.getElementById('status2').innerHTML = "<img src='" + response.picture.data.url + "'>";
                localStorage.setItem("user_information",JSON.stringify(response));
            });
        }
    })
;