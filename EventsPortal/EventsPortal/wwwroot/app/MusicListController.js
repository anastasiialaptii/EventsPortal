(function (app) {
    var MusicListController = function ($scope, $http) {
        $scope.message = "hiya";
        $http({
            method: 'GET',
            url: 'http://localhost:50618/api/Event/GetPublicEvents'
        }).then(function (response) {
            console.dir(response);
            $scope.musics = response.data;
        }, function (error) {
            console.log(error);
        });
    };
    app.controller("MusicListController", MusicListController);
}(angular.module("theMusic", [])));