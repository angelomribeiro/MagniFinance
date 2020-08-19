'use strict';

app.controller('gradeController', ['$scope', 'crudBaseService', function ($scope, crudBaseService) {
    
    $scope.objectList = [];
    $scope.msgError = "";

    crudBaseService.SetAlias('grade');

    $scope.GetList = function () {
        
        crudBaseService.GetList().then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.objectList = results.data;
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    $scope.Save = function (enrollment) {

        $scope.msgError = '';
        var objForm = enrollment;

        if ($scope.msgError.length === 0) {
            crudBaseService.Save(objForm).then(function (results) {
                if (results.data.error_message) {
                    $scope.msgError = results.data.error_message;
                } else {
                    bootbox.alert("Success!");
                    $scope.GetList();
                    _setDefaultModel();
                }
            }, function (error) {
                $scope.msgError = error;
            });
        }

    };

    $scope.Remove = function (id) {

        crudBaseService.Remove(id).then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                bootbox.alert("Success!");
                $scope.GetList();
            }
        }, function (error) {
            $scope.msgError = error;
        });

    };

    $scope.GetList();

}]);