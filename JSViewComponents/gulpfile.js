/// <binding AfterBuild='sass' ProjectOpened='sass:watch' />
var gulp = require("gulp"),
    sass = require("gulp-sass"),
    concat = require('gulp-concat'),
    sourcemaps = require('gulp-sourcemaps');

var sassfiles = './Components/**/*.scss';

gulp.task("sass", function () {
    return gulp.src(sassfiles)
        .pipe(sourcemaps.init())
        .pipe(sass())
        .pipe(concat('JSViewComponents.css'))
        .pipe(gulp.dest('./resources/'));
});

gulp.task('sass:watch', function () {
    gulp.watch(sassfiles, gulp.series('sass'));
});