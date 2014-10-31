'use strict'

examApp.controller('DumpQuestionController',
    function DumpQuestionController($scope, examData, toaster) {

        $scope.questionLevels = [
                                    { QuestionLevelId: 1, QuestionLevelName : 'Junior' },
                                    { QuestionLevelId: 2, QuestionLevelName: 'Intermediate' },
                                    { QuestionLevelId: 3, QuestionLevelName: 'Senior' }
        ];

        $scope.certificate = examData.getCertificate(1);

        $scope.$watch('skill', function (newVal) {
            if (newVal) $scope.skillDetails = newVal.SkillDetails;
        });

        $scope.saveQuestion = function () {
            var result = examData.saveQuestion($scope.question);
            if(result)
                toaster.pop('success', "", "Your question is saved!");
            else
                toaster.pop('error', "", "Happy Question Dump!");
        };

        $scope.addChoice = function () {
            $scope.question.ChoiceQuantity = $scope.question.ChoiceQuantity + 1;
            $scope.question.Answers.push({ name: '', email: '' });
        };

        $scope.removeChoice = function () {
            $scope.question.ChoiceQuantity = $scope.question.ChoiceQuantity - 1;
            $scope.question.Answers.pop();
        };

        var question = { Title: '' };
        $scope.question = question;

        var answers = [];
        $scope.question.ChoiceQuantity = 4;

      for (var i = 0; i < $scope.question.ChoiceQuantity; i++) {
          answers.push({ name: '', email: '' });
      }

      $scope.question.Answers = answers;

    }
);