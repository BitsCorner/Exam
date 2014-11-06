'use strict'

examApp.controller('CertPrepController',
    function CertPrepController($scope, examData, toaster, $upload, $routeParams, $filter) {

        $scope.certificate = examData.getCertificate($routeParams.certificateId);

        $scope.questions = examData.getQuestions($routeParams.certificateId);

    }
);