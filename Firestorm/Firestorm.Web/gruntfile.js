/// <vs BeforeBuild='sass, bower' SolutionOpened='bower:install' />
module.exports = function (grunt) {
    grunt.initConfig({
        //this loads our packages for our grunt file
        pkg: grunt.file.readJSON('package.json'),

        //this section does our bower installs for us
        bower: {
            install: {
                options: {
                    targetDir: './scripts/vendor',
                    layout: 'byComponent',
                    install: true,
                    verbose: true,
                    cleanTargetDir: false,
                    cleanBowerDir: false,
                    bowerOptions: {} 
                }
            } 
        },
        sass: {
            dist: {
                options: {
                    sourcemap: "none"
                },
                files: [{
                    expand: true,
                    cwd: "content/",
                    src: ['sass/*.scss'],
                    dest: 'content/css/',
                    ext: '.min.css',
                    flatten: true
                }]
            }
        }
    });

    //npm modules need for our task
    grunt.loadNpmTasks('grunt-bower-task');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-sass');

    grunt.registerTask('default', ['bower', 'sass']);
};