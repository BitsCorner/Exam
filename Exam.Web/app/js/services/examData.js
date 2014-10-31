'use strict';

var baseUrl = "http://localhost/ExamSvc/api/";
examApp.factory('examData', function ($resource) {
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
            return true;
            //alert(question.Title);
        }
    };
});