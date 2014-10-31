'use strict';

var examApp = angular.module('examApp', ['ngResource', 'ui.bootstrap', 'ngRoute', 'toaster'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/Certificates',
            {
                templateUrl: 'templates/Certificates.html',
                controller: 'CertificateController'
            });
        $routeProvider.when('/DumpQuestion/:certificateId',
            {
                templateUrl: 'templates/DumpQuestion.html',
                controller: 'DumpQuestionController'
            });
        $routeProvider.when('/CertPrep/:certificateId',
            {
                templateUrl: 'templates/CertPrep.html',
                controller: 'CertPrepController'
            });

        $routeProvider.otherwise({ redirectTo: 'Certificates' });
        //TODO: this doesn't work for some reason?! to be able to take # out of the Href attr from the Index.html
        //$locationProvider.html5Mode(true);
    });
