'use strict';

app.controller('teacherController', ['$scope', 'crudBaseService', '$filter', function ($scope, crudBaseService, $filter) {
    
    $scope.objectList = [];
    $scope.msgError = "";
    $scope.formData = {};
    $scope.showForm = false;

    crudBaseService.SetAlias('teacher');

    $scope.GetList = function ($scope) {
        crudBaseService.GetList().then(function (results) {
            $scope.objectList = results.data;
        }, function (error) {
            bootbox.alert(error.data.message);
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
            var $req;
            $req = crudBaseService.Save(objForm);

            $req.success(function () {
                bootbox.alert("Success!");
                $scope.List();
                // clean form
                _setDefaultModel();
                $scope.showForm = false;
            })
            .error(function () {
                bootbox.alert("Error!");
            });
        }      
    };

    $scope.List = function () {
        $scope.GetList($scope);
    };

    $scope.EditForm = function (c) {
        $scope.formData = c;
        $scope.formData.BirthDay = new Date(c.BirthDay);
    };

    $scope.Remove = function (id) {
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
        // clean form
        $scope.showForm = false;
        _setDefaultModel();                
    }

    $scope.List();
    _setDefaultModel();

    var isDate = function (date) {
        return (new Date(date) !== "Invalid Date") && !isNaN(new Date(date));
    }

    var isNumber = function(str) {
        return !isNaN(parseFloat(str)) && isFinite(str);
    }

}]);