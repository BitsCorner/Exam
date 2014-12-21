'use strict'

examApp.controller('AttemptController',
    function AttemptController($scope, examData, $routeParams) {
        $scope.questionsLoaded = false;
        $scope.certificate = examData.getCertificate($routeParams.certificateId);

        //TODO: Add a Cert Prep Option view so that the user can decide how to get the questions
        var questionsQuantity = 50;
        var orderBy = 'latest';

        $scope.startAttempt = function () {
            examData.getQuestionIds($routeParams.certificateId, questionsQuantity, orderBy)
                    .then(function (data) {
                        $scope.currentIndex = 0;

                        $scope.firstQuestionId = data[$scope.currentIndex].QuestionId;
                        $scope.questionIds = data;

                        $scope.questionsLoaded = true;
                        
                        examData.getQuestion($scope.firstQuestionId)
                                .$promise.then(
                                    //success
                                    function (value) {/*Do something with value*/
                                        $scope.question = value;
                                        for (var i = 0; i < $scope.question.Answers.length; i++) {
                                            $scope.question.Answers[i].checked = false;
                                        }
                                    },
                                    //error
                                    function (error) {/*Do something with error*/ }
                                    );

                    }, function (reason) {
                        errorMngrSvc.handleError(reason);
                    });
        };

 });