define([
    'angular',
    'underscore',
    'ngResource',
    'ngSanitize',
], function (angular, _, ngResource, ngSanitize) {
    var app = angular.module('firestorm_app', ['ngResource', 'ngSanitize']);
    return app;
});