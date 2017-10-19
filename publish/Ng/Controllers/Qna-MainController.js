app.controller('appUserRegisterController', ['$rootScope', '$scope', '$http', '$q', '$location', '$timeout', 'svcMain', function ($rootScope, $scope, $http, $q, $location, $timeout, svcMain) {
    $scope.answer = { UserId: 0, UserName: "", QuestionId: "", Answer1: "" }
    $scope.loadQuestion = function () {
        svcMain.generateQuestion().then(function (o) {
            $scope.Question = o.data
            $scope.answer.QuestionId = o.data.Id
        })
    }

    $scope.submit = function () {
        svcMain.SaveAnswer($scope.answer).then(function (o) {
            $location.path('/success')
        })
    }


    $q.all([$scope.loadQuestion()]).then(function (s) {
       
        //$scope.answer.QuestionId = $scope.Question.Id;
        //$scope.answer.QuestionId = $scope.Question.Id
     
    })

}]);

app.controller('appAnswerListControllers', ['$rootScope', '$scope', '$http', '$q', '$location', '$timeout', 'svcMain', function ($rootScope, $scope, $http, $q, $location, $timeout, svcMain) {
    $scope.loadAnswers = function () {
        svcMain.generateAnswers().then(function (o) {
            $scope.Answers = o.data

          
        })
    }
    $scope.loadAnswers()
    $q.all([$scope.loadAnswers()]).then(function (s) {

        //$scope.answer.QuestionId = $scope.Question.Id;
        //$scope.answer.QuestionId = $scope.Question.Id

    })
}]);
app.controller('appAnswerControllers', ['$rootScope', '$scope', '$http', '$q', '$location', '$timeout', 'svcMain', '$stateParams', function ($rootScope, $scope, $http, $q, $location, $timeout, svcMain, $stateParams) {
    $scope.getAnswers = function (id) {
        svcMain.getAnswers(id).then(function (o) {
            $scope.Answers = o.data
            console.log(o.data)

          
        })
    }
    console.log($stateParams.userid)
    //$scope.getAnswers()
    $q.all([$scope.getAnswers($stateParams.userid)]).then(function (s) {

        //$scope.answer.QuestionId = $scope.Question.Id;
        //$scope.answer.QuestionId = $scope.Question.Id

    })
}]);