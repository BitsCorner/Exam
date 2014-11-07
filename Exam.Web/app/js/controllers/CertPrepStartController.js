'use strict'

examApp.controller('CertPrepStartController',
    function CertPrepStartController($rootScope, $scope, examData, toaster, $upload, $routeParams, $filter, $location) {

        $scope.certificate = examData.getCertificate($routeParams.certificateId);

        //TODO: Add a Cert Prep Option view so that the user can decide how to get the questions
        var questionsQuantity = 50;
        var orderBy = 'latest';

        examData.getQuestionIds($routeParams.certificateId, questionsQuantity, orderBy)
                .then(function (data) {
                    $scope.currentIndex = 0;
                    $scope.firstQuestionId = data[$scope.currentIndex].QuestionId;
                    $rootScope.questionIds = data;
                    //examData.storeQuestionIds(data);
                }, function (reason) {
                    errorMngrSvc.handleError(reason);
                });
    }
);