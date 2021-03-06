﻿'use strict';
app.factory('studentService', ['$http', function ($http) {

    var objServiceFactory = {};
    var strAlias = 'student';

    var _getById = function (id) {
        return $http.get('/' + strAlias + '/grades?id=' + id)
            .then(function (results) {
                return results;
            }, function (err) {
                return err;
            });
    };

    objServiceFactory.GetGradesByStudentId = _getById;

    return objServiceFactory;

}]);