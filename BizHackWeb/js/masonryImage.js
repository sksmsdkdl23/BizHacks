$(document).ready(function() {

	// external js: masonry.pkgd.js, imagesloaded.pkgd.js
	var cw = $('.grid-item').children('a').children('img').width();
	$('.grid-item').children('a').children('img').css({'height':cw+'px'});


	// init Masonry
	var $grid = $('.grid').masonry({
	  itemSelector: '.grid-item',
	  percentPosition: true,
	  columnWidth: '.grid-sizer'
	});
	// layout Masonry after each image loads
/*	$grid.imagesLoaded().progress( function() {
	  $grid.masonry();
	});*/
})

$(window).resize(function() {
	var cw = $('.grid-item').children('a').children('img').width();
	$('.grid-item').children('a').children('img').css({'height':cw+'px'});
})