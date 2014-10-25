'use strict';

examApp.factory('examData', function ($http, $log) {
    return {
        getCertificates: function (successcb) {
            $http({ method: "GET", url: "http://localhost/ExamSvc/api/Certificate" })
            .success(function (data, status, header, config) {
                successcb(data);
            })
            .error(function (data, status, header, config) {
                $log.warn(data, status, header, config)
            });
        }
    };
});