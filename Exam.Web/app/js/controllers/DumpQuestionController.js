'use strict'

examApp.controller('DumpQuestionController',
    function DumpQuestionController($scope, examData, toaster, $upload, $routeParams, $filter) {
        $scope.upload = [];

        $scope.options = {
            height: 150,
            toolbar: [
              ['style', ['bold', 'italic', 'underline', 'clear']],
              ['fontsize', ['fontsize']],
              ['color', ['color']],
              ['para', ['ul', 'ol', 'paragraph']],
              ['height', ['height']]
            ]
        };

        $scope.questionLevels = [
                                    { QuestionLevelId: 1, QuestionLevelName : 'Junior' },
                                    { QuestionLevelId: 2, QuestionLevelName: 'Intermediate' },
                                    { QuestionLevelId: 3, QuestionLevelName: 'Senior' }
        ];

        $scope.certificate = examData.getCertificate($routeParams.certificateId);

        $scope.noCorrectAnswers = function (question) {
            var correctAnswers = $filter("filter")(question.Answers, { IsCorrectAnswer: true}).length;
            if (correctAnswers > 0)
                return false;
            else
                return true;
        };


        $scope.$watch('question.Skill', function (newVal) {
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
            $scope.question.Answers.push({ });
        };

        $scope.removeChoice = function () {
            $scope.question.ChoiceQuantity = $scope.question.ChoiceQuantity - 1;
            $scope.question.Answers.pop();
        };

        var email;
        if ($scope.userInfo != null)
            email = $scope.userInfo.emails[0].value;
            
        $scope.question = {
            CertificateId: $routeParams.certificateId,
            UserId: email,
            ChoiceQuantity: 4,
            Title: '',
            Explanation: ''
        };


        var answers = [];
        for (var i = 0; i < $scope.question.ChoiceQuantity; i++) {
            answers.push({ IsCorrectAnswer: false, Description: '' });
        }
        $scope.question.Answers = answers;

          
      $scope.onFileSelect = function ($files, answer) {
          var baseUrl = "http://localhost/ExamSvc/api/";
          //$files: an array of files selected, each file has name, size, and type.
          for (var i = 0; i < $files.length; i++) {
              var $file = $files[i];
              (function (index) {
                  $scope.upload[index] = $upload.upload({
                      url: baseUrl + "files/upload", // webapi url
                      method: "POST",
                      data: { fileUploadObj: $scope.fileUploadObj },
                      file: $file
                  }).progress(function (evt) {
                      // get upload percentage

                      console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
                      if (answer == null)
                          $scope.question.fileUploadProgress = parseInt(100.0 * evt.loaded / evt.total);
                      else
                          answer.fileUploadProgress = parseInt(100.0 * evt.loaded / evt.total);

                  }).success(function (data, status, headers, config) {
                      if (answer == null)
                      // file is uploaded successfully
                          $scope.question.File = data;
                      else
                          answer.File = data;

                  }).error(function (data, status, headers, config) {
                      // file failed to upload
                      console.log(data);
                  });
              })(i);
          }
      }

    }
);