'use strict';

angular.module('ABApp')
    .directive('abNavigate', function () {
        return {
            templateUrl: 'views/nav.html',
            restrict: 'E'
        };
    });
