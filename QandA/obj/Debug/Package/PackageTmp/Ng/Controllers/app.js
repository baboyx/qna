var app = angular.module('app', ['ui.router', 'ngSanitize']);

app.run(['$rootScope', '$location', function ($rootScope, $location) {

}]);

app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

    /*For any unmathced URL, send to */
    $urlRouterProvider.otherwise("/")
    $stateProvider
    .state('home', {
        url: '/home',
        templateUrl: '/ng/views/home/index.html',
        controller: ''
    })
    .state('Register', {
        url: '/',
        templateUrl: '/ng/views/home/register.html',
        controller: 'appUserRegisterController'
    })
    .state('Answers', {
        url: '/answers',
        templateUrl: '/ng/views/answers/list.html',
        controller: 'appAnswerListControllers'
    })
    .state('AnswersList', {
            url: "/answer/:userid",
            templateUrl: "/ng/views/answers/answer.html",
            controller: "appAnswerControllers"
    })
        .state('success', {
            url: "/success",
            templateUrl: "/ng/views/success.html",
            controller: ""
        })

  

}]);

