require.config({
    baseUrl: "/Scripts",
    paths: {
        "jquery": "vendor/jquery/jquery",
        "underscore": "vendor/underscore/underscore",
        "angular": "vendor/angular/angular",
        "ngResource": "vendor/angular-resource/angular-resource",
        "ngSanitize": "vendor/angular-sanitize/angular-sanitize",
        "bootstrap": "vendor/bootstrap-sass/bootstrap"
    },
    shim: {
        underscore: {
            exports: "_",
        },
        jquery: {
            exports: "jquery"
        },
        angular: {
            deps:["jquery"],
            exports: "angular"
        },
        bootstrap: {
            deps: ["jquery"],
            exports: "bootstrap"
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

require(['angular', "bootstrap"], function (angular) {

    $(document).ready(function () {
        
        
    });
   
});