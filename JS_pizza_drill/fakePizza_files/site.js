
/*
jQuery(function($){
				
	$.supersized({
		slides  :  	[ {image :'/img/i.jpg', title : ''} ]
	});


});
*/

jQuery.noConflict();
jQuery(document).ready(function( $ ) {
	var pag = {
		Common: null,
		Home: null,

		init: function () {
			// Fire off JS based on URI segment
			var uri = document.location.pathname.split('/');

			if (uri[1] == '' || uri[1] == null)
			{
				//pag.Home.init();
			}
			pag.Common.init();
		}

	}

	pag.Common = {
		
		init: function () {
			pag.Common.moreContent();
		},

		moreContent: function () {

			$('a[href*=#]').not('.navbar .brand').click(function(event){		
				event.preventDefault();
				$('html,body').animate({scrollTop:$(this.hash).offset().top}, 500);
			});

		},

	}

	$(function () {
		pag.init();
	});

});
