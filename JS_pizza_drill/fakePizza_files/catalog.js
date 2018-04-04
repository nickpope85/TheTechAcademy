	
	$(function(){
		$(':checkbox').attr('checked', false);
		$('.paging_pages select').val(1);

		/**
		 *	Lazy Loading
		 *	------------------------
		 *	Using: http://www.appelsiini.net/projects/lazyload
		 **/
		var $blurb = $('.product_image').length ? $('.product_image') : $('.category_image');
		var images = $blurb.find('> img').length;
		
		if (images > 0)
		{
			$(window).bind("load", function() {
			    var timeout = setTimeout(function() { $blurb.find('> img:visible').lazyload(); }, 300);
			});
			
			// var $container = $('#catalog_products').length ? $('#catalog_products') : $('#catalog_categories');
			// $blurb.find('> img').lazyload({ threshold: $container.css('height') });		// Old
			// $blurb.find('> img').lazyload({ failure_limit: Math.max(images - 1, 0) });	// Older
		}
	});

	/**
	 *	Add To Cart
	 *	------------------------
	 *	
	 **/
	function addToCart(pid, type, options){
		
		switch(type){
			case "growl":
				if (pid == 0){
					growlUI('<h3>Please choose a product option.</h3>', {}, { backgroundColor: "#ff7a2d" });
				} else {
					$.post('/actions/catalog-productstock.php',
						{ product: pid },
						function(output){
							var amt = parseInt($('#amt-' + pid).val());
							var itemnotes = ($('#itemnotes-' + pid).length == 1 ? encodeURIComponent($('#itemnotes-' + pid).val()) : "");
							var stock = parseInt(output.stock);
							var cartamt = parseInt(output.cartamt);
							var cartitems = parseInt(output.cartitems);
							var productname = output.title + (output.subtitle != '' ? ' - ' + output.subtitle : '');
							
							if ((amt + cartamt) > stock){
								amt = (stock - cartamt);
							}
							
							if (amt > 0){
								$.get('/actions/cart_additem.php', { pid: pid, amt: amt, itemnotes: itemnotes });
								growlUI('<h3>' + amt + 'x ' + productname + ' has been added to your cart!</h3><a href="/store/cart" target="_parent">Proceed to cart</a>');
								
								$('#shoppingbag').html(cartitems + amt);
							} else {
								growlUI('<h3>Sorry, this item is currently out of stock.</h3>', {}, { backgroundColor: "#9e0000" });
							}
						},
						'json'
					);
				}
			break;
			default:
				if (pid == 0){
					if ($.fancybox != undefined) {
						$.fancybox({
							content: '<em>Please choose a product option.</em>',
							opacity: 0.15
						});
					} else {
						$.colorbox({
							html: '<em>Please choose a product option.</em>',
							opacity: 0.15
						});
					}
				} else {
					var amt = parseInt($('#amt-' + pid).val());
					var itemnotes = ($('#itemnotes-' + pid).length == 1 ? encodeURIComponent($('#itemnotes-' + pid).val()) : "");
					
					if ($.fancybox != undefined) {
						$.fancybox({
							href: '/actions/cart_additem.php?pid=' + pid + '&amt=' + amt + '&itemnotes=' + itemnotes,
							scrolling: false,
							opacity: 0.15,
							type:'ajax',
						});
					} else {
						$.colorbox({
							href: '/actions/cart_additem.php?pid=' + pid + '&amt=' + amt + '&itemnotes=' + itemnotes,
							scrolling: false,
							opacity: 0.15,
						});
					}
				}
		}
	}
	
	function growlUI(content, params, css){
		
		// Default settings..
		var data = {
			message: $(document.createElement('div')).addClass('growlUI').html(content),
			fadeIn: 700, 
			fadeOut: 1000, 
			timeout: 5000,
			centerY: false,
			showOverlay: false
		};
		
		// Default CSS..
		var growlCSS = {
			width: '300px',
			top: '10px',
			left: '',
			right: '10px',
			border: 'none',
			padding: '5px 10px',
			opacity: 0.8,
			cursor: 'default',
			color: '#FFFFFF',
			textAlign: 'left',
			backgroundColor: '#101856',
			'-webkit-border-radius': '10px',
			'-moz-border-radius': '10px',
			'border-radius': '10px'
		};
		
		// Merge settings with defaults..
		var settings = $.extend(data, params);
		settings['css'] = $.extend(growlCSS, css);
		
		// Fire!!
		$.blockUI(settings);
	}
