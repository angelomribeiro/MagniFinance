'use strict';

app.controller('teacherController', ['$scope', 'crudBaseService', '$filter', function ($scope, crudBaseService, $filter) {
    
    $scope.objectList = [];
    $scope.msgError = "";
    $scope.formData = {};
    $scope.showForm = false;

    crudBaseService.SetAlias('teacher');

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

    var _setDefaultModel = function () {
        $scope.formData = {
            TeacherId: 0,
            Name: "",
            BirthDay: "",
            Salary: 0
        };
        $scope.msgError = '';
        $scope.showForm = false;
    };

    $scope.Save = function () {

        var objForm = $scope.formData;

        if (objForm.Name === '') {
            $scope.msgError = 'Name is required.'
        } else if (objForm.Name.length > 100) {
            $scope.msgError = 'The length of Name must be 100 characters.'
        } else if (objForm.BirthDay === '') {
            $scope.msgError = 'BirthDay is required.'
        } else if (!isDate(objForm.BirthDay)) {
            $scope.msgError = 'Invalid BirthDay.'
        } else if (objForm.Salary === '') {
            $scope.msgError = 'Salary is required.'
        } else if (!isNumber(objForm.Salary)) {
            $scope.msgError = 'Invalid Salary.'
        }

        if ($scope.msgError.length == 0) {
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

    $scope.EditForm = function (c) {
        $scope.formData = c;
        $scope.formData.BirthDay = new Date(c.BirthDay);
    };

    $scope.Remove = function (id) {

        crudBaseService.Remove(id).then(function (results) {
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

    };

    $scope.OpenForm = function (c) {
        $scope.EditForm(c);
        $scope.showForm = true;
    }

    $scope.Cancel = function () {
        $scope.showForm = false;
        _setDefaultModel();                
    }

    $scope.GetList();
    _setDefaultModel();

    var isDate = function (date) {
        return (new Date(date) !== "Invalid Date") && !isNaN(new Date(date));
    }

    var isNumber = function(str) {
        return !isNaN(parseFloat(str)) && isFinite(str);
    }

}]);