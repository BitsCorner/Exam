'use strict'

examApp.controller('CertPrepController',
    function CertPrepController($rootScope, $scope, examData, toaster, $upload, $routeParams, $filter, $location) {

        //TODO: we should get these from the CertPrepOptions Page....
        var questionsQuantity = 50;
        var orderBy = 'latest';

        $scope.certificate = examData.getCertificate($routeParams.certificateId);

        //TODO: this we might have, if user not bookmarked, is $resource smart enough?
        if (!$rootScope.questionIds) {
            
            examData.getQuestionIds($routeParams.certificateId, questionsQuantity, orderBy)
                    .then(function (data) {
                        $scope.currentIndex = 0;
                        $scope.firstQuestionId = data[$scope.currentIndex].QuestionId;
                        $scope.questionIds = data;

                        $scope.question = examData.getQuestion($routeParams.questionId);
                        $scope.prevQuestionId = 0;
                        if ($rootScope.questionIds[1])
                            $scope.nextQuestionId = $rootScope.questionIds[1].QuestionId;
                        else
                            $scope.nextQuestionId = 0;

                    }, function (reason) {
                        errorMngrSvc.handleError(reason);
                    });
        }
        else {
            $scope.nextQuestionId = 0;
            $scope.prevQuestionId = 0;
            for (var i = 0; i < $rootScope.questionIds.length; i++) {
                if ($rootScope.questionIds[i].QuestionId == $routeParams.questionId) {
                    if ($rootScope.questionIds[i + 1]) {
                        $scope.nextQuestionId = $rootScope.questionIds[i + 1].QuestionId;
                    }
                    if ($scope.questionIds[i - 1]) {
                        $scope.prevQuestionId = $rootScope.questionIds[i - 1].QuestionId;
                    }
                }
                $scope.question = examData.getQuestion($routeParams.questionId);
            }
        }


 });