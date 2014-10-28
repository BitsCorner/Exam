'use strict'

examApp.controller('CertificateController',
    function CertificateController($scope, examData) {

        $scope.certificates = examData.getCertificates();

    }
);