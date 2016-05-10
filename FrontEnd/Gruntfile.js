"use strict";

module.exports = function(grunt) {

    grunt.initConfig({
        bower: {
            install: {
                options: {
                    install: false,
                    copy: true,
                    targetDir: './dist/libs',
                    cleanTargetDir: true,
                    stripAffix: ''
                }
            }
        },
        clean: {
            dist: {
                src: ['dist/**/*', '!dist/libs/**/*']
            }
        },
        copy: {
            main: {
                files: [{
                    expand: true,
                    cwd: 'static_components/assets',
                    src: ['**/*'],
                    dest: 'dist/assets/'
                }],
            },
            scripts: {
                files: [{
                    expand: true,
                    cwd: 'static_components',
                    src: ['**/*.js'],
                    dest: 'dist/js/'
                }],
            },
            libs: {
                files: [{
                    expand: true,
                    cwd: 'bower_components/video.js/dist',
                    src: ['**/*'],
                    dest: 'dist/libs/video.js/dist'
                },
                {
                    expand: true,
                    cwd: 'bower_components/bootstrap/dist',
                    src: ['**/*'],
                    dest: 'dist/libs/bootstrap/dist'
                }],
            }
        },
        // concat: {
        //     options: {
        //         separator: ';'
        //     },
        //     dist: {
        //         src: ['app/**/*.js'],
        //         dest: 'dist/app.js'
        //     }
        // },
        masterify: {
            dist: {
                src: ['static_components/**/*.html', '!static_components/master.html'],
                dest: 'dist/',
                options: {
                    beautify: true,
                    masters: {
                        master1: 'static_components/master.html'
                    }
                }
            }
        },
        sass: {
            dist: {
                options: {
                    style: 'compressed',
                    sourcemap: 'none'
                },
                files: {
                    '../Backend/WebApp/WebApp/Content/Styles/styles.css': '../Backend/WebApp/WebApp/Content/Styles/styles.scss'
                }
            }
        },

        watch: {
            css: {
                files: ['../Backend/WebApp/WebApp/Content/Styles/**/*.scss'],
                tasks: ['sass'],
                options: {
                    atBegin: true,
                    spawn: false
                }
            },
            scripts: {
                files: ['./static_components/**/*.js', './static_components/**/*.html'],
                tasks: ['copy:scripts', 'masterify'],
                options: {
                    atBegin: true,
                    spawn: false
                }
            }
        },


    });

    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-bower-task');
    grunt.loadNpmTasks('grunt-html-master');
    grunt.loadNpmTasks('grunt-contrib-sass');
    grunt.loadNpmTasks('grunt-contrib-copy');

    grunt.registerTask('default', ['clean:dist', 'bower', 'masterify', 'sass', 'copy:main', 'copy:libs', 'copy:scripts']);

    grunt.registerTask('static', ['clean:dist', 'masterify', 'sass', 'copy:main', 'copy:libs', 'copy:scripts']);

};