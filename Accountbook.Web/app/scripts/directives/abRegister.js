'use strict';

angular.module('ABApp')
    .directive('abRegister', function () {
        return {
            templateUrl: 'views/register.html',
            restrict: 'E'
        };
    });
