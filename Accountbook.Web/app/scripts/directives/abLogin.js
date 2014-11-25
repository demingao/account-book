'use strict';

angular.module('ABApp')
    .directive('abLogin', function () {
        return {
            templateUrl: 'views/login.html',
            restrict: 'E'
        };
    });
