var app = angular.module("myApp", []);

app.controller("myCtrl", function($scope, $http) {

    var url = "http://localhost:59835/api/products";

    $scope.prdId = 1;
    $scope.product = "";
    $scope.message = "";

    $scope.getData= function(prdId) {
        $http.get(url + "/" + prdId).then(function (response) {
            $scope.product = response.data;
            $scope.message = "Featched!";
        });

        
    };

    $scope.postData = function () {
        $http.post(url, JSON.stringify(this.product)).then(function (response) {
            $scope.message = "Updated!!";
        });
    };
});