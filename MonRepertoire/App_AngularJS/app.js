var app = angular.module("MonRepertoire", ['ngRoute']);

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider
        .when('/home', {
            templateUrl: 'App_AngularJS/views/home/home.html'
        })
        .when('/help', {
            templateUrl: 'App_AngularJS/views/home/help.html'
        })
        .when('/morceaux', {
            templateUrl: 'App_AngularJS/views/morceau/morceaux.html'
            , controller: 'morceauController'
        })
        .when('/morceau/:morceauId', {
            templateUrl: 'App_AngularJS/views/morceau/morceau.html'
            , controller: 'morceauController'
        })
        .when('/addMorceau', { 
            templateUrl: 'App_AngularJS/views/morceau/addMorceau.html',
            controller: 'morceauController'
        })
        .when('/updateMorceau', {
            templateUrl: 'App_AngularJS/views/morceau/updateMorceau.html',
            controller: 'morceauController'
        })
        .when('/deleteMorceau/:morceauId', {
            templateUrl: 'App_AngularJS/views/morceau/deleteMorceau.html',
            controller: 'morceauController'
        })
        .otherwise({
            redirectTo:'/home'
        });
}]);