'use strict'

examApp.controller('QuestionCommentController',
    function QuestionCommentController($scope) {

        $scope.saveComment = function () {
            var questionComment = {
                QuestionId: $scope.question.QuestionId,
                UserId: $scope.userInfo.emails[0].value,
                Comment: '',
                Email: '',
                FullName: ''
            };
            examData.saveQuestionComment(questionComment);
        };

 });