'use strict'

examApp.controller('DumpQuestionController',
    function DumpQuestionController($scope, examData) {

        $scope.questionLevels = [
                                    { QuestionLevelId: 1, QuestionLevelName : 'Junior' },
                                    { QuestionLevelId: 2, QuestionLevelName: 'Intermediate' },
                                    { QuestionLevelId: 3, QuestionLevelName: 'Senior' }
        ];

        $scope.certificate = examData.getCertificate(1);

        $scope.$watch('skill', function (newVal) {
            if (newVal) $scope.skillDetails = newVal.SkillDetails;
        });

        $scope.saveEntry = function ($scope.question) {
            polls.save($scope.poll);
        }

        saveQuestion


    }
);