/// <binding AfterBuild='min:css, min:js' ProjectOpened='sass:watch' />
// Defining dependencies  
var gulp = require("gulp"),
    sass = require("gulp-sass"),
    sourcemaps = require('gulp-sourcemaps'),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");
// Defining paths  
var webroot = './wwwroot/';
var paths = {
  js: webroot + "js/**/*.js",
  minJs: webroot + "js/**/*.min.js",
  css: "./Views/**/*.scss",
  minCss: webroot + "css/**/*.min.css",
  concatJsDest: webroot + "js/site.min.js",
  concatCssDest: webroot + "css/site.min.css"
};
// Bundling (via concat()) and minifying (via uglify()) Javascript  
gulp.task("min:js", function () {
  return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
      .pipe(concat(paths.concatJsDest))
      .pipe(uglify())
      .pipe(gulp.dest("."));
});
// Bundling (via concat()) and minifying (via cssmin()) Javascript  
gulp.task("min:css", function () {
    return gulp.src(paths.css)
        .pipe(sourcemaps.init())
        .pipe(sass())
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task('sass:watch', function () {
    gulp.watch(paths.css, gulp.series('min:css'));
});