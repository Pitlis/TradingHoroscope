"use strict";

module.exports = function(grunt) {

    grunt.initConfig({
        bower: {
            install: {
                options: {
                    install: false,
                    copy: true,
                    targetDir: './dist/libs',
                    cleanTargetDir: true
                }
            }
        },

        html2js: {
            dist: {
                src: ['app/*/*.html'],
                dest: 'tmp/templates.js'
            }
        },

        clean: {
            temp: {
                src: ['tmp', 'app/**/*.js', 'app/**/*.js.map']
            }
        },

        concat: {
            options: {
                separator: ';'
            },
            dist: {
                src: ['tmp/*.js'],
                dest: 'dist/app.js'
            }
        },
        ts: {
            default: {
                src: ["app/**/*.ts", "typings/**/*.d.ts"],
                dest: 'tmp/scripts.js',
                options: {
                    sourceMap: false,
                    target: 'es5',
                    fast: 'always',
                    comments: true,
                    sortOutput: true,
                    noExternalResolve: true
                }

            }
        },
        masterify: {
            dist: {
                src: ['!static_components/*.html', '!static_components/master.html'],
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
                files: ['./app/**/*.ts', './static_components/**/*.html'],
                tasks: ['html2js:dist', 'ts', 'concat:dist', 'masterify', 'clean:temp'],
                options: {
                    atBegin: true,
                    spawn: false
                }
            }
        },


    });

    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-html2js');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-bower-task');
    grunt.loadNpmTasks('grunt-ts');
    grunt.loadNpmTasks('grunt-html-master');
    grunt.loadNpmTasks('grunt-contrib-sass');

    grunt.registerTask('default', ['bower', 'html2js:dist', 'ts', 'concat:dist', 'masterify', 'sass', 'clean:temp']);

    grunt.registerTask('static', ['masterify', 'sass']);

};