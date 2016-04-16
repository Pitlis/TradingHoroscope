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
            libs:{
                files: [{
                    expand: true,
                    cwd: 'bower_components/video.js/dist',
                    src: ['**/*'],
                    dest: 'dist/libs/video.js/dist'
                }],
            }
        },
        concat: {
            options: {
                separator: ';'
            },
            dist: {
                src: ['app/**/*.js'],
                dest: 'dist/app.js'
            }
        },
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
                    'dist/styles.css': 'static_components/styles.scss'
                }
            }
        },

        watch: {
            css: {
                files: ['./app/**/*.scss', './static_components/**/*.scss'],
                tasks: ['sass'],
                options: {
                    atBegin: true,
                    spawn: false
                }
            },
            scripts: {
                files: ['./app/**/*.js', './static_components/**/*.html'],
                tasks: ['concat:dist', 'masterify'],
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

    grunt.registerTask('default', ['clean:dist', 'bower', 'concat:dist', 'masterify', 'sass', 'copy:main', 'copy:libs']);

    grunt.registerTask('static', ['clean:dist', 'masterify', 'sass', 'copy:main', 'copy:libs']);

};