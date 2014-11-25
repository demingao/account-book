'use strict';

angular
    .module('ABApp', [
        'ngCookies',
        'ngResource',
        'ngSanitize',
        'ngRoute'
    ])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/main.html',
                controller: 'MainCtrl'
            })
            .when('/login', {
                templateUrl: 'views/user.html',
                controller: 'UserCtrl'
            })
            .otherwise({
                redirectTo: '/'
            });
    });
