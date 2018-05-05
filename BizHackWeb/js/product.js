var current = 0;
var max = 0;

$(document).ready(function() {
	max = $('.product').length;
	$(".product").each(function(i, obj) {
		if (i != current) {
			$(this).addClass('display-none');
		}
	})

	$('.left-nav').click(function() {
		if (current > 0) {
			displayProduct(current - 1);			
		}
	});

	$('.right-nav').click(function() {
		if (current < max - 1) {
			displayProduct(current + 1);			
		}
	});
	var qs = decodeURIComponent(window.location.search);
	qs = qs.substring(1);
	displayProduct(qs.split("=")[1]);
	updateNavHeight();
})

function setCurrent(pos) {
	current = pos;
}

function updateNavHeight() {
	$('.product').each(function(i, obj) {
		if (!$(this).hasClass('display-none')) {
			var cn = $(this).height();
			$('.left-nav').css({'height':cn+'px'});
			$('.left-nav').css({'line-height':cn+'px'});
			$('.right-nav').css({'height':cn+'px'});
			$('.right-nav').css({'line-height':cn+'px'});
		}
	})
}

function displayProduct(pos) {
	if (pos !=  current) {
		$(".product").each(function(i, obj) {
			if (i == pos) {
				$(this).removeClass('display-none');
			}
			if (i == current) {
				$(this).addClass('display-none');
			}
		})
		setCurrent(parseInt(pos));
	}
}

$(window).resize(function() {
	updateNavHeight();
})