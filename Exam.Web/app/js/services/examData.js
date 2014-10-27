'use strict';

var baseUrl = "http://localhost/ExamSvc/api/";
examApp.factory('examData', function ($resource) {
    return {
        getCertificates: function () {
            return $resource(baseUrl + "Certificate", null).query();
        },

        getSkills: function () {
            return $resource(baseUrl + "Skill/id", {id:'@id'}).query(id);
        }
    };
});