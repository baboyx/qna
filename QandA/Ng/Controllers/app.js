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
        url: '/User',
        templateUrl: '/ng/views/home/register.html',
        controller: 'appUserRegisterController'
    })
  

}]);

