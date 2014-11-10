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

                        examData.getQuestion($routeParams.questionId)
                        .$promise.then(
                           //success
                           function (value) {/*Do something with value*/
                               $scope.question = value;
                               for (var i = 0; i < $scope.question.Answers.length; i++) {
                                   $scope.question.Answers[i].checked = false;
                               }
                           },
                           //error
                           function (error) {/*Do something with error*/}
                         );
                        
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

            $scope.question = examData.getQuestion($routeParams.questionId);
            examData.getQuestion($routeParams.questionId)
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

            for (var i = 0; i < $rootScope.questionIds.length; i++) {
                if ($rootScope.questionIds[i].QuestionId == $routeParams.questionId) {
                    if ($rootScope.questionIds[i + 1]) {
                        $scope.nextQuestionId = $rootScope.questionIds[i + 1].QuestionId;
                    }
                    if ($scope.questionIds[i - 1]) {
                        $scope.prevQuestionId = $rootScope.questionIds[i - 1].QuestionId;
                    }
                }
            }

        }

        $scope.checkAnswer = function (question) {
            $scope.alerts = [];
            $scope.showCorrectAnswer = true;
            var gotItRight = true;
            for (var i = 0; i < $scope.question.Answers.length; i++) {
                if ($scope.question.Answers[i].checked != $scope.question.Answers[i].IsCorrectAnswer) {
                    gotItRight = false;
                }
            }
            if (gotItRight)
                $scope.alerts.push({ type: 'success', msg: 'Well done! you got it right.' });
            else
                $scope.alerts.push({ type: 'danger', msg: 'Opps! you got it wrong.' });

            $scope.$broadcast('timer-stop');
            $scope.timerRunning = false;

            var userAnswers = [];
            for (var i = 0; i < $scope.question.Answers.length; i++) {
                if ($scope.question.Answers[i].checked) 
                    userAnswers.push($scope.question.Answers[i].AnswerId);
            }

            var userAttempt = {
                QuestionId: question.QuestionId,
                UserId: $scope.userInfo.emails[0].value,
                TimeSpent: $scope.question.TimeSpent,
                GotItRight: gotItRight,
                Answers: userAnswers
            };
            examData.saveUserAttempt(userAttempt);

        };

        $scope.closeAlert = function (index) {
            $scope.alerts.splice(index, 1);
            $scope.showCorrectAnswer = false;
        };

        $scope.showComments = function (question) {

            examData.getComments(question.QuestionId)
                                    .then(function (data) {
                                        $scope.question.Comments = data;
                                        $scope.displayComments = true;
                                    });
        };

        $scope.timerRunning = true;

        $scope.startTimer = function () {
            $scope.$broadcast('timer-start');
            $scope.timerRunning = true;
        };

        $scope.$on('timer-stopped', function (event, data) {
            console.log('Timer Stopped - data = ', data);
        });

        $scope.$on('timer-tick', function (event, args) {
            $scope.question.TimeSpent = args.millis / 1000;
            $rootScope.totalTime += (args.millis / 1000);
            $scope.prepTotalTime = $rootScope.totalTime
        });

        $scope.voteUp = function () {
            var questionVote = {
                QuestionId: $scope.question.QuestionId,
                UserId: $scope.userInfo.emails[0].value,
                Vote: 1,
            };
            examData.saveQuestionVote(questionVote);
            $scope.question.Vote += 1;
        };

        $scope.voteDown = function () {
            var questionVote = {
                QuestionId: $scope.question.QuestionId,
                UserId: $scope.userInfo.emails[0].value,
                Vote: -1,
            };
            examData.saveQuestionVote(questionVote);
            $scope.question.Vote -= 1;
        };

 });