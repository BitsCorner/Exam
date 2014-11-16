'use strict';

var examApp = angular.module('examApp', ['ngResource', 'ui.bootstrap', 'ngRoute', 'toaster', 'angularFileUpload', 'summernote', 'ngSanitize', 'timer'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/Certificates',
            {
                templateUrl: 'templates/Certificates.html',
                controller: 'CertificateController'
            });
        $routeProvider.when('/DumpQuestion/:certificateId',
            {
                templateUrl: 'templates/DumpQuestion.html',
                controller: 'DumpQuestionController',
                auth: function (user) {
                    return user;
                }
            });
        $routeProvider.when('/Login',
            {
                templateUrl: 'templates/Login.html',
                controller: 'SignInController'
            });
        $routeProvider.when('/Attempt/:certificateId',
            {
                templateUrl: 'templates/Attempt.html',
                controller: 'AttemptController',
                auth: function (user) {
                    return user;
                }
            });

        //$routeProvider.otherwise({ redirectTo: 'Certificates' });

        //TODO: this doesn't work for some reason?! to be able to take # out of the Href attr from the Index.html
        //$locationProvider.html5Mode(true);
    })
    .run(function ($rootScope, $location) {
        $rootScope.$on('$routeChangeStart', function (ev, next, curr) {
            if (next.$$route) {
                var user = $rootScope.user
                var auth = next.$$route.auth
                if (auth && !auth(user)) {
                    $location.path('/Login')
                }
            }
        })
    });


