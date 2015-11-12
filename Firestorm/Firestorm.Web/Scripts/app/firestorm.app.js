require.config({
    baseUrl: "/Scripts",
    paths: {
        "jquery": "vendor/jquery/jquery",
        "underscore": "vendor/underscore/underscore",
        "angular": "vendor/angular/angular",
        "ngResource": "vendor/angular-resource/angular-resource",
        "ngSanitize": "vendor/angular-sanitize/angular-sanitize",
    },
    shim: {
        underscore: {
            exports: "_",
        },
        jquery: {
            exports: "$"
        },
        angular: {
            deps: ['jquery'],
            exports: "angular"
        },
        ngResource: {
            deps: [
                "angular"
            ]
        },
        ngSanitize: {
            deps: [
                "angular"
            ]
        }

    }
});

require(['jquery', 'underscore', 'angular'], function ($, _, angular) {
    
});