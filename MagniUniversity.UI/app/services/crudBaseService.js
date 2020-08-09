'use strict';
app.factory('crudBaseService', ['$http', function ($http) {

    var objServiceFactory = {};
    var strAlias = '';

    var _getList = function () {
        return $http.get('/' + strAlias).then(function (results) {
            return results;
        });
    };

    var _save = function (c) {
        return $http.post('/' + strAlias + '/save', c, { headers: { 'Content-Type': 'application/json' } });
    };

    var _remove = function (id) {
        return $http.delete('/' + strAlias + '/remove?id=' + id, { headers: { 'Content-Type': 'application/json' } });
    };

    var _setAlias = function (alias) {
        strAlias = alias;
    }

    var _getById = function (id) {
        return $http.get('/' + strAlias + '/detail?id=' + id).then(function (results) {
            return results;
        });
    };

    objServiceFactory.GetList = _getList;
    objServiceFactory.Save = _save;
    objServiceFactory.Remove = _remove;
    objServiceFactory.SetAlias = _setAlias;
    objServiceFactory.GetById = _getById;

    return objServiceFactory;

}]);