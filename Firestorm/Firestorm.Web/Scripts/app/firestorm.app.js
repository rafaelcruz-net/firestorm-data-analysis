require.config({
    baseUrl: "/Scripts",
    paths: {
        "jquery": "Vendor/jquery/jquery",
        "underscore": "Vendor/underscore/underscore",
        "angular": "Vendor/angular/angular",
        "ngResource": "Vendor/angular-resource/angular-resource",
        "ngSanitize": "Vendor/angular-sanitize/angular-sanitize",
        "bootstrap": "Vendor/bootstrap/bootstrap",
        "material": "vendor/bootstrap-material-design/material",
        "ripples": "vendor/bootstrap-material-design/ripples",
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
        bootstrap: {
            deps: [
                "jquery"
            ]
        },
        material: {
            deps: [
                "ripples"
            ]
        },
        ripples: {
            deps: [
                "jquery"
            ]
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

require(['jquery', 'underscore', 'angular', 'material'], function ($, _, angular) {
    
});