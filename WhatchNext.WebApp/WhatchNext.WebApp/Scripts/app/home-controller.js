angular.module('WhatchNextApp', [])
    .controller('WhatchNextCtrl', function ($scope, $http) {
        $scope.id = 0;
        $scope.title = "loading shows...";
        $scope.image = [];
        $scope.trailer = "";
        $scope.poster = "";
        $scope.rating = 0.0;

        $scope.getNextShow = function (id) {

            $http.get("/controllers/wncontroller").success(function (id, title, image, trailer, poster, rating) {
                $scope.id = id;
                $scope.title = title;
                $scope.image = image;
                $scope.trailer = trailer;
                $scope.poster = poster;
                $scope.rating = rating;
            }).error(function (id, title, image, trailer, poster, rating) {
                $scope.title = "oops something went wrong";

            });

        };

        
    });