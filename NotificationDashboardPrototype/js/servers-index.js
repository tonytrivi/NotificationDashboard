// servers-index.js
var app = angular.module("NotificationDashboard", []);

// $scope is data container
// $http does gets and puts
app.controller("serversIndexController", function ($scope, $http) {
    $scope.serverCount = 0;
    $scope.data = [];

});
