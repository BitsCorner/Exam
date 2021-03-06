﻿'use strict'

examApp.controller('QuestionController',
    function QuestionController($rootScope, $scope, examData) {

        $scope.isFirstQuestion = function () {
            if ($scope.currentIndex == 0)
                return true;
            else
                return false;
        },
        $scope.isLastQuestion = function () {
            if ($scope.questionIds != null && $scope.currentIndex < $scope.questionIds.length - 1)
                return false;
            else
                return true;
        },
        $scope.prevQuestion = function () {

            if ($scope.currentIndex > 0)
                $scope.currentIndex -= 1;

            examData.getQuestion($scope.questionIds[$scope.currentIndex].QuestionId)
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
        },

        $scope.nextQuestion = function () {
            if ($scope.currentIndex < $scope.questionIds.length-1)
                $scope.currentIndex += 1;

            examData.getQuestion($scope.questionIds[$scope.currentIndex].QuestionId)
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
        },

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

            var userAnswers = [];
            for (var i = 0; i < $scope.question.Answers.length; i++) {
                if ($scope.question.Answers[i].checked)
                    userAnswers.push($scope.question.Answers[i].AnswerId);
            }

            var userAttempt = {
                QuestionId: question.QuestionId,
                UserId: $rootScope.user.emails[0].value,
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
                                        $scope.question.displayComments = true;
                                    });
        };

        $scope.voteUp = function () {
            var questionVote = {
                QuestionId: $scope.question.QuestionId,
                UserId: $rootScope.user.emails[0].value,
                Vote: 1,
            };
            examData.saveQuestionVote(questionVote);
            $scope.question.Vote += 1;
        };

        $scope.voteDown = function () {
            var questionVote = {
                QuestionId: $scope.question.QuestionId,
                UserId: $rootScope.user.emails[0].value,
                Vote: -1,
            };
            examData.saveQuestionVote(questionVote);
            $scope.question.Vote -= 1;
        };

 });