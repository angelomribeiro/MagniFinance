'use strict';

app.controller('courseController', ['$scope', 'crudBaseService', '$rootScope', '$location', function ($scope, crudBaseService, $rootScope, $location) {
    
    $scope.objectList = [];
    $scope.msgError = "";
    $scope.formData = {};
    $scope.showForm = false;

    crudBaseService.SetAlias('course');

    $scope.GetList = function ($scope) {
        crudBaseService.GetList().then(function (results) {
            $scope.objectList = results.data;
        }, function (error) {
            bootbox.alert(error.data.message);
        });
    };

    var _setDefaultModel = function () {
        $scope.formData = {
            CourseId: 0,
            Title: ""
        };
        $scope.msgError = '';
        $scope.showForm = false;
    };

    $scope.Save = function () {

        $scope.msgError = '';
        var objForm = $scope.formData;

        if (objForm.Title === '') {
            $scope.msgError = 'Title is required.'
        } else if (objForm.Title.length > 100) {
            $scope.msgError = 'The length of Title must be 100 characters.'
        }

        if ($scope.msgError.length === 0) {
            var $req;
            $req = crudBaseService.Save(objForm);

            $req.success(function () {
                bootbox.alert("Success!");
                $scope.List();
                // clean form
                _setDefaultModel();
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
        $scope.formData = {
            CourseId: c.CourseId,
            Title: c.Title
        };
    };

    $scope.Remove = function (id) {
        console.log('Remove', id);
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
        _setDefaultModel();
        $scope.showForm = false;        
    }

    $scope.List();
    _setDefaultModel();

}]);