$(document).ready(function() {

	var divider = $('h3').offset();

	window.onscroll = function() {
		if (window.pageYOffset > 0) {
			var opac = (window.pageYOffset / divider.top);
			$('#fag-background-image').css({left: opac * -50});
		}
	}
})