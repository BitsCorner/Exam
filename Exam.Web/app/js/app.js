'use strict';

var examApp = angular.module('examApp', ['ngResource', 'ui.bootstrap', 'ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/Certificates',
            {
                templateUrl: 'templates/Certificates.html',
                controller: 'CertificateController'
            });
        $routeProvider.when('/DumpQuestion/:certificateId',
            {
                templateUrl: 'templates/DumpQuestion.html',
                controller: 'QuestionController'
            });
        $routeProvider.otherwise({ redirectTo: '/Certificates' });

        $locationProvider.html5Mode(true);
    });
