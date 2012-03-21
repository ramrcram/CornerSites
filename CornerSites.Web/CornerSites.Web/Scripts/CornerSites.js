function ge(id) {
    return document.getElementById(id);
}

function ShowPopup() {
    //select all the a tag with name equal to modal
    $('a[name=modal]').click(function(e) {
        //Cancel the link behavior
        e.preventDefault();

        //Get the A tag
        var id = $(this).attr('href');

        //Get the screen height and width
        var maskHeight = $(document).height();
        var maskWidth = $(window).width();

        //Set heigth and width to mask to fill up the whole screen
        $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

        //transition effect		
        $('#mask').fadeIn(1000);
        $('#mask').fadeTo("slow", 0.8);

        //Get the window height and width
        var winH = $(window).height();
        var winW = $(window).width();

        //Set the popup window to center
        $(id).css('top', winH / 2 - $(id).height() / 2);
        $(id).css('left', winW / 2 - $(id).width() / 2);

        //transition effect
        $(id).fadeIn(2000);

    });

    //if close button is clicked
    $('.window .close').click(function(e) {
        //Cancel the link behavior
        e.preventDefault();

        $('#mask').hide();
        $('.window').hide();
    });

    //if mask is clicked
    $('#mask').click(function() {
        $(this).hide();
        $('.window').hide();
    });    
}

function HideLightBox() {
    $('#mask').hide();
    $('.window').hide();
}
//function ShowPopupFromCodeBehind(CallBackFunction) {
function ShowPopupFromCodeBehind() {
    //select all the a tag with name equal to modal
    //$('a[name=modal]').click(function(e) {
        //Cancel the link behavior
        //e.preventDefault();

        //Get the A tag
        var id = "#dialog1";
        //SetCallBackethod(CallBackFunction);
        //Get the screen height and width
        var maskHeight = $(document).height();
        var maskWidth = $(window).width();

        //Set heigth and width to mask to fill up the whole screen
        $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

        //transition effect		
        $('#mask').fadeIn(1000);
        $('#mask').fadeTo("slow", 0.8);

        //Get the window height and width
        var winH = $(window).height();
        var winW = $(window).width();

        //Set the popup window to center
        $(id).css('top', winH / 2 - $(id).height() / 2);
        $(id).css('left', winW / 2 - $(id).width() / 2);

        //transition effect
        $(id).fadeIn(2000);

    //});

    //if close button is clicked
    $('.window .close').click(function(e) {
        //Cancel the link behavior
        e.preventDefault();

        $('#mask').hide();
        $('.window').hide();
    });

    //if mask is clicked
    $('#mask').click(function() {
        $(this).hide();
        $('.window').hide();
    });
    $(document).escape(function() {
        $(this).hide();
        $('.window').hide();
    });

}

function EnterLogin(e) {
    if (e.keyCode == 13) {
        ge('hdIsEnter').value = '1';
        ge('ctl00_cntLogin_btnLogin').focus();
    }
}

function DefaultLogin() {
    if (ge('hdIsEnter').value == '1') {
        ge('hdIsEnter').value = '0';
        LoginAnthem();
    }
}
function LoginAnthem() {
    Anthem_InvokeControlMethod(
		"ctl00_cntLogin",
		'LoginUser',
		[],
		function(result) {
		    if (ge('ctl00_cntLogin_CallBackMethod') != null &&
		        ge('ctl00_cntLogin_CallBackMethod').value != "") {
		        Anthem_Method(ge('ctl00_cntLogin_CallBackMethod').value);
		    }
		}
	);
}

function TestLogin() {
    alert('Hi this is testign');
}
function AddSubscription(a, b) {
    SL();
    if (a > 0) {
        Anthem_InvokeControlMethod(
		"ctl00_ContentPlaceHolder1_cntSubscription",
		'GetSubscriptionByAdTypeID',
		[a, b],
		function(result) {
		    HL();
		    if (result.value == 'false') {
		        alert("please login");
		    }
		    else {
		        if (confirm("Pay now ? ")) {
		            location.href = "ssl/PaySubscription.aspx";
		        }
		    }
		}
	);
    }
    else {
        alert("Invalid Subscription");
    }
}
function SL() 
{
    document.getElementById('showimg').style.display = 'block';
    document.getElementById('fade').style.display = 'block';
}
function HL() {
    document.getElementById('showimg').style.display = 'none';
    document.getElementById('fade').style.display = 'none';
}
function ViewContact(a,id) {
    //SL();
    if (ge(a + id).style.display == 'block') {
        ge(a + id).style.display = 'none';
        ge('btnContacts_' + id).value = "View Contact Details";
        HL();
    }
    else {
        SL();
        Anthem_InvokeControlMethod(
		"ctl00_ContentPlaceHolder1_cntSearchResult",
		'IsLogin',
		[],
		function(result) {
		    if (result.value == "1") {
		        ge(a + id).style.display = 'block';
		        ge('btnContacts_' + id).value = "Hide Details";
		    }
		    else {
		        HL();
		        ShowPopupFromCodeBehind();
		    }
		    HL();
		}
	);
    }
}
function SetCallBackethod(MeName) {
    alert(MeName);
    if (ge('ctl00_cntLogin_CallBackMethod') != null) {
        ge('ctl00_cntLogin_CallBackMethod').value = MeName;
    }
}
function MyProfileTabView(id) {
    ge('MyProfile').style.display = 'none';
    ge('UpdateProfile').style.display = 'none';
    ge('MySubscription').style.display = 'none';
    ge('MyAdds').style.display = 'none';
    ge('Invoice').style.display = 'none';
    ge(id).style.display = 'block';
}