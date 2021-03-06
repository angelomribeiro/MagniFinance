﻿'use strict';

app.controller('courseController', ['$scope', 'crudBaseService', '$rootScope', '$location', function ($scope, crudBaseService, $rootScope, $location) {
    
    $scope.objectList = [];
    $scope.msgError = "";
    $scope.formData = {};
    $scope.showForm = false;

    crudBaseService.SetAlias('course');

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
        $scope.formData = {
            CourseId: c.CourseId,
            Title: c.Title
        };
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
        _setDefaultModel();
        $scope.showForm = false;        
    }

    $scope.GetList();
    _setDefaultModel();

}]);