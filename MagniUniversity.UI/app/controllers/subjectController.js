'use strict';

app.controller('subjectController', ['$scope', 'crudBaseService', '$rootScope', '$location', function ($scope, crudBaseService, $rootScope, $location) {
    
    $scope.objectList = [];
    $scope.objectTeacherList = [];
    $scope.msgError = "";
    $scope.formData = {};
    $scope.showForm = false;
    $scope.studentsForm = [];

    var subjectAlias = 'subject';
    var teacherAlias = 'teacher';
    var studentAlias = 'student';
    var courseAlias = 'course';

    $scope.GetList = function ($scope) {
        crudBaseService.SetAlias(subjectAlias);
        crudBaseService.GetList().then(function (results) {
            $scope.objectList = results.data;
        }, function (error) {
            bootbox.alert(error.data.message);
        });
    };

    $scope.GetById = function ($scope, id) {

        // update teacher, student and course list
        $scope.GetTeacherList($scope);
        $scope.GetStudentList($scope);
        $scope.GetCourseList($scope);

        crudBaseService.SetAlias(subjectAlias);
        crudBaseService.GetById(id).then(function (results) {

            $scope.formData = {
                SubjectId: results.data.SubjectId,
                Title: results.data.Title,
                TeacherId: results.data.TeacherId,
                CourseId: results.data.CourseId
            };

            var arrStudents = results.data.Students;

            if (arrStudents.length > 0) {
                angular.forEach($scope.studentsForm, function (item) {
                    if (arrStudents.includes(item.StudentId)) {
                        item.Selected = true;
                    }
                });
            }

        }, function (error) {
            bootbox.alert(error.data.message);
        });
    }
    
    var _setDefaultModel = function () {
        $scope.formData = {
            SubjectId: 0,
            Title: "",
            TeacherId: 0,
            CourseId: 0
        };
        $scope.msgError = '';

        angular.forEach($scope.studentsForm, function (item) {
            item.Selected = false;
        });
    };

    $scope.Save = function () {        
        crudBaseService.SetAlias(subjectAlias);
        var objForm = $scope.formData;
        $scope.msgError = '';
        objForm.Students = [];

        angular.forEach($scope.studentsForm, function (item) {
            if (item.Selected) {
                objForm.Students.push(item.StudentId);
            }
        });

        if (objForm.Title === '') {
            $scope.msgError = 'Title is required.';
        } else if (objForm.Title.length > 100) {
            $scope.msgError = 'The length of Title must be 100 characters.';
        } else if (typeof (objForm.CourseId) === 'undefined') {
            $scope.msgError = 'Course is required.';
        } else if (typeof (objForm.TeacherId) === 'undefined') {
            $scope.msgError = 'Teacher is required.';
        }

        if ($scope.msgError.length == 0) {
            var $req;
            $req = crudBaseService.Save(objForm);

            $req.success(function () {
                bootbox.alert("Success!");
                $scope.GetList($scope);
                // clean form
                _setDefaultModel();
                $scope.showForm = false;
            })
            .error(function () {
                bootbox.alert("Error!");
            });
        }      
    };

    $scope.EditForm = function (id) {
        $scope.GetById($scope,id);
    };

    $scope.NewForm = function (c) {
        $scope.formData = c;
    };

    $scope.Remove = function (id) {
        crudBaseService.SetAlias(subjectAlias);
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
        _setDefaultModel();
        if (c.SubjectId == 0) {
            $scope.NewForm(c);
        } else {
            $scope.EditForm(c.SubjectId);
        }
        
        $scope.showForm = true;
    }

    $scope.Cancel = function () {
        // clean form
        _setDefaultModel();
        $scope.showForm = false;        
    }

    /* begin : teacher */
    $scope.GetTeacherList = function ($scope) {
        crudBaseService.SetAlias(teacherAlias);
        crudBaseService.GetList().then(function (results) {
            $scope.objectTeacherList = results.data;
        }, function (error) {
            bootbox.alert(error.data.message);
        });
    };
    /* end : teacher */

    /* begin : student */
    $scope.GetStudentList = function ($scope) {
        crudBaseService.SetAlias(studentAlias);
        crudBaseService.GetList().then(function (results) {
            $scope.studentsForm = [];
            angular.forEach(results.data, function (item) {
                $scope.studentsForm.push({
                    StudentId: item.StudentId,
                    Name: item.Name,
                    Selected: false
                });
            });

        }, function (error) {
            bootbox.alert(error.data.message);
        });
    };
    /* end : student */

    /* begin : course */
    $scope.GetCourseList = function ($scope) {
        crudBaseService.SetAlias(courseAlias);
        crudBaseService.GetList().then(function (results) {
            $scope.objectCourseList = results.data;
        }, function (error) {
            bootbox.alert(error.data.message);
        });
    };
    /* end : course */

    $scope.GetList($scope);
    $scope.GetTeacherList($scope);
    $scope.GetStudentList($scope);
    $scope.GetCourseList($scope);
    _setDefaultModel();

}]);