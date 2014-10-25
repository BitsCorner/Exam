'use strict';

examApp.factory('examResource', ['$resource', function ($resource) {
    var service = $resource('/data/event/:id', {id:'@id'});

    service.queryAll = function (cb) {
        return service.query({}, cb)
    };

    return service;
}]);