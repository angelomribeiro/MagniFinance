'use strict';

app.controller('subjectController', ['$scope', 'crudBaseService', 'subjectService', function ($scope, crudBaseService, subjectService) {
    
    $scope.objectList = [];
    $scope.objectTeacherList = [];
    $scope.objectCourseList = [];
    $scope.subjectInformation = {};
    $scope.msgError = "";
    $scope.formData = {};
    $scope.showForm = false;
    $scope.studentsForm = [];

    var subjectAlias = 'subject';
    var teacherAlias = 'teacher';
    var studentAlias = 'student';
    var courseAlias = 'course';

    $scope.GetList = function () {
        crudBaseService.SetAlias(subjectAlias);
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

    $scope.GetById = function ($scope, id) {

        // update teacher, student and course list
        $scope.GetTeacherList($scope);
        $scope.GetStudentList($scope);
        $scope.GetCourseList($scope);

        crudBaseService.SetAlias(subjectAlias);
        crudBaseService.GetById(id).then(function (results) {

            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
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
            } 

        }, function (error) {
                $scope.msgError = error;
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

        $scope.subjectInformation = {};
        $scope.showForm = false;
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

    $scope.EditForm = function (id) {
        $scope.GetById($scope,id);
    };

    $scope.NewForm = function (c) {
        $scope.formData = c;
    };

    $scope.Remove = function (id) {
        crudBaseService.SetAlias(subjectAlias);
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
    $scope.GetTeacherList = function () {
        crudBaseService.SetAlias(teacherAlias);
        crudBaseService.GetList().then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.objectTeacherList = results.data;
            }               
        }, function (error) {
            $scope.msgError = error;
        });
    };
    /* end : teacher */

    /* begin : student */
    $scope.GetStudentList = function () {
        crudBaseService.SetAlias(studentAlias);
        crudBaseService.GetList().then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.studentsForm = [];
                angular.forEach(results.data, function (item) {
                    $scope.studentsForm.push({
                        StudentId: item.StudentId,
                        Name: item.Name,
                        Selected: false
                    });
                });
            } 
        }, function (error) {
            $scope.msgError = error;
        });
    };
    /* end : student */

    /* begin : course */
    $scope.GetCourseList = function () {
        crudBaseService.SetAlias(courseAlias);
        crudBaseService.GetList().then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.objectCourseList = results.data;
            }             
        }, function (error) {
            $scope.msgError = error;
        });
    };
    /* end : course */

    /* begin : subject information */
    $scope.GetSubjectInformation = function (id) {
        subjectService.GetSubjectInformation(id).then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.subjectInformation = results.data;

                var dlgElem = angular.element("#subjectInformationModal");
                if (dlgElem) {
                    dlgElem.modal("show");
                }
            }    
        }, function (error) {
                $scope.msgError = error;
        });
    };
    /* end : subject information */

    $scope.GetList();
    $scope.GetTeacherList();
    $scope.GetStudentList();
    $scope.GetCourseList();
    _setDefaultModel();

}]);