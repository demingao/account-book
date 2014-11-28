angular.module 'ABApp'
.controller 'UserCtrl',[
  '$scope'
  ($scope)->
    $scope.tab = 'login'
    $scope.toLogin = () ->
      $scope.tab = 'login'
    $scope.toRegister = ()->
      $scope.tab = 'register'
]
