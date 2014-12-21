'use strict';

// var baseUrl = "http://certapi.koukia.ca/api/";
var baseUrl = 'http://localhost/ExamSvc/api/';

examApp.factory('examData', function ($resource, $http, $q) {

    return {
        getCertificates: function () {
            return $resource(baseUrl + "Certificate", null).query();
        },

        getCertificate: function (id) {
            return $resource(baseUrl + "Certificate/:id", { id: '@id' }).get({ id: id });
        },

        getSkills: function () {
            return $resource(baseUrl + "Skill/id", {id:'@id'}).query(id);
        },

        saveQuestion: function (question) {
            return $resource(baseUrl + "Question", null).save(question);
        },

        getQuestionIds: function (id, questionQuantity, orderBy) {
            var deferred = $q.defer();
            $http({
                method: 'get',
                url: baseUrl + 'Certificate/'+ id +'/Questions',
                //data: location
            })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
            //return $resource(baseUrl + "Certificate/:id/Questions", { id: '@id' }).query();
        },

        getQuestion: function (id) {
            return $resource(baseUrl + "Question/:id", { id: '@id' }).get({ id: id });
        },

        getComments: function (id) {
            var deferred = $q.defer();
            $http({
                method: 'get',
                url: baseUrl + 'Question/' + id + '/Comments',
                //data: location
            })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },

        saveUser: function (user) {
            return $resource(baseUrl + "User", null).save(user);
        },

        saveUserAttempt: function (userAttempt) {
            return $resource(baseUrl + "Question/Attempt", null).save(userAttempt);
        },

        saveQuestionVote: function (questionVote) {
            return $resource(baseUrl + "Question/Vote", null).save(questionVote);
        },

        saveQuestionComment: function (questionComment) {
            return $resource(baseUrl + "Question/Comment", null).save(questionComment);
        },

        //storeQuestionIds: function (qIds) {
        //    questionIds = qIds;
        //},

        //getStoredQuestionIds: function () {
        //    return questionIds;
        //}

    };
});