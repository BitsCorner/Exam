'use strict'

examApp.controller('CertificateController',
    function CertificateController($scope, examData) {

        examData.getCertificates(function (certificates) {
            $scope.certificates = certificates;
        });

        //$scope.certificates = [
        //    {certificateCode : "70-480",
        //    certificateId : 1,
        //    certificateName:"Programming in HTML5 with JavaScript and CSS3",
        //    companyName: "Microsoft",
        //    publishDate: "2012-08-20T00:00:00"
        //    },
        //    {certificateCode: "70-480",
        //     certificateId: 1,
        //     certificateName: "Programming in HTML5 with JavaScript and CSS3",
        //     companyName: "Microsoft",
        //     publishDate: "2012-08-20T00:00:00"
        //    },
        //]
    }
);