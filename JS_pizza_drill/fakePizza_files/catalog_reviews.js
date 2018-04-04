	$(function(){
		
		
		/**
		 *	Product Reviews
		 *	------------------------
		 * 	
		 **/
		if ($('#review_form').length > 0){
			
			/**
			 *	Form validation!
			 *	------------------------
			 *	Using jQuery Validation: http://bassistance.de/jquery-plugins/jquery-plugin-validation/
			 *	Validates required fields, field lengths, field types, etc...
			 **/
		    $('#review_form').validate({
				invalidHandler: function(form, validator) {
					$(validator.errorList).each(function(i){
						if (i == 0){ $(this.element).focus(); }

						$(this.element).poshytip({
							className: 'tip-error',
							content: this.message,
							showOn: 'none',
							alignTo: 'target',
							alignX: 'left',
							alignY: 'center',
							offsetX: 5,
							timeOnScreen: 3000
						});

						$(this.element).poshytip('show');
						$(this.element).bind('keyup', function(){ $(this).poshytip('hide') });
					});
				},
				focusInvalid: false,
				errorPlacement: function(error,element) {
					return true;
				},
				submitHandler: function(form){
					submitProductReview(form);
				}
			});
			
			if ($('#review_form .review_form_rating').length > 0){
				var size = ($('#review_form .review_form_rating').attr('data-size') != undefined ? $('#review_form .review_form_rating').attr('data-size') : 18);
				var path = ($('#review_form .review_form_rating').attr('data-path') != undefined ? $('#review_form .review_form_rating').attr('data-path') : "/3rdparty/scripts/raty/2.5.2/images/stars/18");
				
				$('#review_form .review_form_rating').raty({
					scoreName: 'rating',
					score: 5,
					size: size,
					path: path,
					number: function() {
						return $(this).attr('data-max');
					}
				});
			}
		}
		
		if ($('.review_rating').length > 0){
			var size = ($('.review_rating').attr('data-size') != undefined ? $('.review_rating').attr('data-size') : 18);
			var path = ($('.review_rating').attr('data-path') != undefined ? $('.review_rating').attr('data-path') : "/3rdparty/scripts/raty/2.5.2/images/stars/18");
			
			$('.review_rating').raty({
				readOnly: true,
				size: size,
				path: path,
				score: function() {
					return $(this).attr('data-score');
				},
				number: function() {
					return $(this).attr('data-max');
				}
			});
		}
	});
	
	
	/**
	 *	Product review form validation..
	 *	------------------------
	 *	Run server-side form validation
	 *	Product review is saved and review is passed back to be displayed
	 *		in reviews area
	 **/
	function submitProductReview(form){
		var submit_btn = $(form).find(':submit').val();
//		var data = $(form).serialize();
		var data = {};
		$(form).find(':input').not(':submit').map(function(index, elm) {
		   data[elm.name] = { type: elm.type, value: $(elm).val(), required: elm.required };
		});
		
		$.ajax({
			type: 'POST',
			url: '/actions/catalog-productreview-submission.php',
			data: data,
			dataType: 'json',
			beforeSend: function(){
				$(form).find(':input').attr('disabled', true);
				$(form).find(':submit').val('Processing...');
			},
			success: function(out){
				if (!$.isEmptyObject(out.error)){
					var errormsg = "<strong>The following errors have been found:</strong><hr />";
					
					$.each(out.error, function(field, error){
					    errormsg += "<strong>" + field + "</strong><br />";
						
					    $.each(error, function(code, msg){
					        errormsg += "&raquo; " + msg + "<br />";
					    });
						errormsg += "<br />";
					});
					
					$.fancybox(errormsg, {
						overlayShow: true,
						autoDimensions: false,
						width: 350,
						height: 'auto',
						transitionIn: 'none',
						transitionOut: 'none',
					});
				} else {
					growlUI('<h3>Your review has been submitted.</h3>');
					$('#review_form')[0].reset();			// Reset form fields..
					
					if (typeof postReviewSubmission == "function")
					{ 
						postReviewSubmission(out.result); 
					}
					
					// Conversion Tracking
					$('body').append('<iframe width="0" height="0" src="' + location.pathname + '/review/thank-you?trackpage=1"></iframe>');
				}
				
				$(form).find(':input').attr('disabled', false);
				$(form).find(':submit').val(submit_btn);
			}
		});
		
		return false;
	}
