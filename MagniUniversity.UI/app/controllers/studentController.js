'use strict';
app.controller('studentController', ['$scope', 'crudBaseService', 'studentService', function ($scope, crudBaseService, studentService) {
    
    $scope.objectList = [];
    $scope.gradeList = [];
    $scope.msgError = "";
    $scope.formData = {};
    $scope.showForm = false;

    crudBaseService.SetAlias('student');

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
            StudentId: 0,
            Name: "",
            BirthDay: "",
            RegistrationNumber: 0
        };
        $scope.msgError = '';
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
        } else if (objForm.RegistrationNumber === '') {
            $scope.msgError = 'Registration Number is required.'
        } else if (!isNumber(objForm.RegistrationNumber)) {
            $scope.msgError = 'Invalid Registration Number.'
        }

        if ($scope.msgError.length == 0) {
            crudBaseService.Save(objForm).then(function (results) {
                if (results.data.error_message) {
                    $scope.msgError = results.data.error_message;
                } else {
                    bootbox.alert("Success!");
                    $scope.GetList();
                    _setDefaultModel();
                    $scope.showForm = false;
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

        var $req;
        $req = crudBaseService.Remove(id);

        $req.success(function () {
            bootbox.alert("Success!");
            $scope.List();
            // clean form
            _setDefaultModel();
        })
        .error(function () {
            bootbox.alert("Error!");
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

    $scope.ShowGrades = function (id) {
        $scope.GetGradeList($scope, id);
    };

    $scope.GetGradeList = function ($scope, id) {

        $scope.gradeList = [];

        studentService.GetGradesByStudentId(id).then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.gradeList = results.data;
                var dlgElem = angular.element("#gradeStudentModal");
                if (dlgElem) {
                    dlgElem.modal("show");
                }
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    $scope.GetList();
    _setDefaultModel();

    var isDate = function (date) {
        return (new Date(date) !== "Invalid Date") && !isNaN(new Date(date));
    }

    var isNumber = function(str) {
        return !isNaN(parseFloat(str)) && isFinite(str);
    }

}]);