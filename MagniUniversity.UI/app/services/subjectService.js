'use strict';
app.factory('subjectService', ['$http', function ($http) {

    var objServiceFactory = {};
    var strAlias = 'subject';

    var _getById = function (id) {
        return $http.get('/' + strAlias + '/information?id=' + id).then(function (results) {
            return results;
        });
    };

    objServiceFactory.GetSubjectInformation = _getById;

    return objServiceFactory;

}]);