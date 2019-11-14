'use strict';
 
var gulp = require('gulp');
var htmlreplace = require('gulp-html-replace');

gulp.task("get-ndm-templates", function() {
	return gulp.src('./node_modules/ndm-package/dist/ndm.template.html')
		.pipe(gulp.dest('./src'));
});

gulp.task('copy-templates', function () {
	return gulp.src('./src/index.html')
		.pipe(htmlreplace({
			templates: {
				src: gulp.src('./src/**/*.template.html'),
				tpl: '%s'
			  }
		}, { allowEmpty: true }))
		.pipe(gulp.dest('./dist'));
});
