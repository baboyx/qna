app.factory('svcMain', ['$rootScope,$scope,$http,$q', function ($rootScope, $scope, $http, $q) {
    $this = {
        getUser: function (id) {
            var r = $q;
            $http({
                method: "GET",
                url: "Lyrics/" + id
            }).success(function (data) {

            })
        },

    }
    return $this;

}])