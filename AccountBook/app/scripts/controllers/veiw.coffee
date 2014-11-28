angular.module 'ABApp'
.controller 'MainCtrl'
($scope)->
  $scope.tab = 'login'
  $scope.toLogin = () ->
    $scope.tab = 'login'
  $scope.toRegister () ->
    $scope.tab = 'register'
  undefined
