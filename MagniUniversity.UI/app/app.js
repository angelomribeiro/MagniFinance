var app = angular.module('MagniUniversity', [
    'ngRoute',
    'ngStorage',
    'angular-loading-bar',
    'ui.utils.masks'
]);
angular.module('ui.bootstrap.demo', ['ngAnimate', 'ngSanitize', 'ui.bootstrap']);

app.config(function ($routeProvider) {
    
    $routeProvider.when("/", {
        controller: "subjectController",
        templateUrl: "/templates/subject.html"
    });
    $routeProvider.when("/course", {
        controller: "courseController",
        templateUrl: "/templates/course.html"
    });
    $routeProvider.when("/teacher", {
        controller: "teacherController",
        templateUrl: "/templates/teacher.html"
    });
    $routeProvider.when("/student", {
        controller: "studentController",
        templateUrl: "/templates/student.html"
    });
    $routeProvider.when("/subject", {
        controller: "subjectController",
        templateUrl: "/templates/subject.html"
    });
    $routeProvider.when("/grade", {
        controller: "gradeController",
        templateUrl: "/templates/grade.html"
    });
    $routeProvider.when("/home", {
        controller: "subjectController",
        templateUrl: "/templates/subject.html"
    });

});

angular.module('ui.bootstrap.demo').controller('ModalInstanceCtrl', function ($uibModalInstance, data) {
    var pc = this;
    pc.data = data;
});