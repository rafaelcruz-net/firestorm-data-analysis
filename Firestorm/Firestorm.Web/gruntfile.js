module.exports = function (grunt) {

    require('time-grunt')(grunt);
    require('jit-grunt')(grunt, {
        bower: 'main-bower-files',
        bowercopy: 'grunt-bowercopy'
    });

    publicSass = './content/scss/',
    publicCss = './content/css/',
    publicFont = './content/fonts/',
    vendorScript = './scripts/vendor/',
    vendorStyle = './content/scss/',
    devBower = './bower_components/';

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        exec: {
            installBower: {
                cmd: 'bower-installer'
            }
        },
        sass: {
            dist: {
                options: {
                    update: true,
                    noCache: false,
                    update: true,
                    trace: true
                },
                files: [{
                    expand: true,
                    cwd: publicSass,
                    src: ['*.scss'],
                    dest: publicCss,
                    ext: '.css'
                }]
            }
        },
        copy: {
            fontawesome: {
                files: [{
                    cwd: 'bower_components/font-awesome/',
                    expand: true,
                    src: ['fonts/*'],
                    dest: publicFont
                }]
            },
            materialize: {
                files: [{
                    cwd: 'bower_components/materialize/font/',
                    expand: true,
                    src: ['material-design-icons/*', 'roboto/*'],
                    dest: publicFont
                }]
            },
            bootstrap: {
                files: [{
                    cwd: 'bower_components/bootstrap-sass-official/assets/fonts',
                    expand: true,
                    src: ['bootstrap/*'],
                    dest: publicFont
                }]
            }
        },
        cssmin: {
            dist: {
                options: {
                    shorthandCompacting: false,
                    roundingPrecision: -1
                },
                files: [{
                    expand: true,
                    cwd: publicCss,
                    src: ['style.css'],
                    dest: publicCss,
                    ext: '.min.css'
                }]
            }
        },
        clean: {
            vendor: [vendorStyle, vendorScript],
            mincss: [publicCss + '*.min.css']
        },
    });

    grunt.registerTask('install', 'Install bower dependencies', function () {
        var exec = require('child_process').exec;
        var cb = this.async();
        exec('bower install --allow-root --verbose', { cwd: './' }, function (err, stdout, stderr) {
            console.log(stdout);
            cb();
        });
    });

    grunt.registerTask('files', ['exec', 'copy']);
    grunt.registerTask('default', ['install', 'exec', 'copy', 'sass', 'cssmin']);
};
