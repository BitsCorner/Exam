'use strict'

examApp.controller('CertPrepController',
    function CertificateController($scope, examData) {

        $scope.questions = examData.getQuestions();

    }
);