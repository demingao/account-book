'use strict';

angular.module('ABApp')
    .controller('UserCtrl', function ($scope) {
        $scope.tab = 'login';
        console.log($scope.tab);
        $scope.toLogin = function () {
            $scope.tab = 'login';
        };
        $scope.toRegister = function () {
            $scope.tab = 'register';
        };
    });
