app.factory('svcMain', ["$rootScope", "$http", "$q", function ($rootScope, $http, $q) {
    $this = {
        getQuestion: function (id) {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "Question/Generate",
            }).then(function (data, status) {
                deferred.resolve(data);
                $this.objects = data;
                $this.count = data.length;
            })
        },
        generateQuestion: function () {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "Question/Generate",
            }).then(function (data, status) {
                deferred.resolve(data);
    
            })
            return deferred.promise;
        },
        generateAnswers: function () {

            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "Answer/List",
            }).then(function (data, status) {
                deferred.resolve(data);

            })
            return deferred.promise;
        },
        getAnswers: function (id) {

            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "/Answer/" + id,
            }).then(function (data, status) {
                deferred.resolve(data);

            })
            return deferred.promise;
        },
        SaveAnswer: function (postData) {

            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/Answer/Save',
                data: postData
            }).then(function (data, status) {
                deferred.resolve(data);
            })
            return deferred.promise;
        },
        SaveAll: function (Postdata) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/KillData/SaveAll',
                data: Postdata
            }).success(function (data, status) {
                deferred.resolve(data);
            }).error(function (data, status) {
                deferred.reject(data);
            });
            return deferred.promise;
        }

    }
    return $this;

}])