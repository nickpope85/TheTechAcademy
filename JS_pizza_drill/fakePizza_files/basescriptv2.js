
// Trim white space
function trim(s){
	return s.replace(/^\s*(.*?)\s*$/,"$1")
}


// for login junk
function checkLogin(){

	$.ajax({
		url:'/actions/login_check.php',
		async:   false,
		type: 'POST',
		dataType: 'json',
		success: function(data)
		{
			for (var i in data)
			{
				$('body').data(i, data[i]);
			}
			
			$('.loggedin, .loggedout').stop(true, true);
			
			$('.loggedin').toggle(data['loggedin']);			
			$('.loggedout').toggle(!data['loggedin']);
			$('.iswholesale').toggle(data['iswholesale']);
			
			// Verify e-mail was created via Facebook login
			// Note: if no e-mail exists, log user out immediately
			if (typeof fb_email_check == 'function') { fb_email_check(); }
		 }        
    });

	return $('body').data('loggedin');
}
function logout()
{
	// Log user out of Facebook
	// Note: This function will first check that the user logged in via Facebook
	if (typeof fb_logout == 'function') { fb_logout(); }
	
	$.post('/actions/login_logout.php',function(data){		
		window.location.reload();
	});
	return false;
}

function showLoginScreen(cb){
	$.fancybox({
		type: 'ajax',
		href: '/login.php',
		opacity: 0.15,
		onClosed: function(){ postLoginScreen(cb) },
		afterClose: function(){ postLoginScreen(cb) },
	});
	
	return false;
}

function postLoginScreen(cb){
	checkLogin();
	
	// Run callback if provided..
	if (cb) { cb() }
}

//for google analytics
var _gaq = _gaq || [];

function anltx_trackEvent(category, action, opt_label, opt_value, opt_noninteraction){	
	_gaq.push(['_trackEvent', category, action, opt_label, opt_value, opt_noninteraction]);
}

$(document).ready(function(){
	
	$('.signinlink').click(function(){
		return showLoginScreen();
	});
	
	checkLogin();
	
	$('.lightbox').fancybox({ type: 'iframe' });
	$('a.colorbox').fancybox();	// Backward compatibility
});

// Facebook - Login for Web
// TODO: compile this into efelle.js
$.getScript("/scripts/login_facebook.js");
