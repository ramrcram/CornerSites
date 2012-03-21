var curr_lb_div;
var curr_lbfade_div;    //Declared by Gerald
var is_modal = false;

function ShowLightBox(lb_div, isModal, offsetLeft, offsetTop, floatIt, grayOutBg) {
    placeDivAtCenter(lb_div, offsetLeft, offsetTop, floatIt, grayOutBg);
    document.getElementById(lb_div).style.display = 'block';
    document.getElementById('fade').style.display = 'block';
    curr_lb_div = lb_div;
    curr_lbfade_div = 'fade';
    if (isModal)
        is_modal = true;
    else is_modal = false;
}

function HideLightBox() {
    if (document.getElementById(curr_lb_div)) {
        document.getElementById(curr_lb_div).style.display = 'none';
        
        //The following line is commented by Gerald
        //document.getElementById('fade').style.display = 'none';
        document.getElementById(curr_lbfade_div).style.display = 'none';
        curr_lb_div = '';
        curr_lbfade_div = '';
    }
}
function HideVideoLightBox() {
    if (document.getElementById(curr_lb_div)) {
        document.getElementById('')
        document.getElementById(curr_lb_div).style.display = 'none';
        document.getElementById(curr_lbfade_div).style.display = 'none';
        curr_lb_div = '';
        curr_lbfade_div = '';
    }
}

function ShowAddNewShippingAddressLightBox(lb_div, isModal, cartItemId, hfCartItemIdClientId) {
    
    document.getElementById(lb_div).style.display = 'block';
    document.getElementById('fade').style.display = 'block';
    document.getElementById(hfCartItemIdClientId).value = cartItemId;
    curr_lb_div = lb_div;
    curr_lbfade_div = 'fade';
    if (isModal)
        is_modal = true;
    else is_modal = false;
}

/* Created By : Gerald
 * Created On : 13-10-2010
 * */
function ShowLightBoxByDivID(lb_div, isModal) {    
    placeDivAtCenter(lb_div, -500, -400, 0, 0);
    document.getElementById(lb_div).style.display = 'block';
    document.getElementById('fade').style.display = 'block';
    curr_lb_div = lb_div;
    curr_lbfade_div = 'fade';
    if (isModal)
        is_modal = true;
    else is_modal = false;
}

//Added by ramesh 
    //*********************************************************
    //     * You may use this code for free on any web page provided that 
    //     * these comment lines and the following credit remain in the code.
    //     * Floating Div from http://www.javascript-fx.com
    //********************************************************
    var ns = (navigator.appName.indexOf("Netscape") != -1);
    var d = document;
    function JSFX_FloatDiv(id, sx, sy)
    {
     var el=d.getElementById?d.getElementById(id):d.all?d.all[id]:d.layers[id];
     var px = document.layers ? "" : "px";
     window[id + "_obj"] = el;
     if(d.layers)el.style=el;
     el.cx = el.sx = sx;el.cy = el.sy = sy;
     el.sP=function(x,y){this.style.left=x+px;this.style.top=y+px;};

     el.floatIt=function()
     {
      var pX, pY;
      pX = (this.sx >= 0) ? 0 : ns ? innerWidth : 
      document.documentElement && document.documentElement.clientWidth ? 
      document.documentElement.clientWidth : document.body.clientWidth;
      pY = ns ? pageYOffset : document.documentElement && document.documentElement.scrollTop ? 
      document.documentElement.scrollTop : document.body.scrollTop;
      if(this.sy<0) 
      pY += ns ? innerHeight : document.documentElement && document.documentElement.clientHeight ? 
      document.documentElement.clientHeight : document.body.clientHeight;
      this.cx += (pX + this.sx - this.cx)/8;this.cy += (pY + this.sy - this.cy)/8;
      this.sP(this.cx, this.cy);
      setTimeout(this.id + "_obj.floatIt()", 40);
     }
     return el;
 }
//*********************************************************
    //    Places the element at cetre
    //*********************************************************
 function placeDivAtCenter(divID, offsetLeft, offsetTop, floatIt, grayOutBg) {
     curr_lb_div = divID;
     curr_lbfade_div = 'fade';
        var elm = document.getElementById(divID)
        if(elm)
        {
            viewport.getAll();
            var WinW = viewport.width;
            var WinH = viewport.height;
            var ScrollX = viewport.scrollX;
            var ScrollY = viewport.scrollY;
            var ElemW = 300;
            var ElemH = 300;
            
            if(elm.style.display == 'none')
                elm.style.display = 'block';
            if (document.all || document.getElementById)
            {
                ElemW = elm.offsetWidth; //MSIE + NS6
                ElemH = elm.offsetHeight; // MSIE + NS6
            }
            else
            {
                ElemW = elm.document.width; //Netscape 4
                ElemH = elm.document.height; //Netscape 4
            }

            //Added by Ramesh
            //To clear the value at next time
           ElemW = 0;
           ElemH = 0;

            //calculate positions:
            var xPos = WinW / 2 - (ElemW / 2) + ScrollX;
            var yPos = WinH / 2 - (ElemH / 2) + ScrollY;
            xPos = Math.round(xPos, 0) + offsetLeft;
            yPos = Math.round(yPos, 0) + offsetTop;
            //move layers to the above positions:
            elm.style.left = xPos + "px";
            elm.style.top = yPos + "px";
            if(grayOutBg == '1')
            {
                elm.style.zIndex = '9999';
                //grayOut(true);
                document.getElementById('fade').style.display = 'block';
            }
            var ie = document.all;
            if(floatIt == '1')
                JSFX_FloatDiv(divID, xPos - ScrollX, yPos - ScrollY).floatIt();
        }
    }
 //============================================================
    viewport =
    {
       getIECanvas: function ()
       {
          var canv = null;
          if (!window.opera && document.all && typeof document.body.clientWidth != "undefined")
          {
             var cm = document.compatMode && document.compatMode == "CSS1Compat";
             canv = cm ? document.documentElement : document.body;
          }
          return canv;
       },

       getWinWidth: function ()
       {
          var canv;
          if ( canv = this.getIECanvas() )
             this.width = canv.clientWidth;
          else
             this.width = window.innerWidth - 18;
       },

       getWinHeight: function ()
       {
          var canv;
          if (canv = this.getIECanvas())
             this.height = canv.clientHeight;
          else
              this.height = window.innerHeight - 18;

          // Added by ramesh Issue : screen resolution the light box going down
          this.height = screen.height;
       },

       getScrollX: function ()
       {
          var canv;
          if (canv = this.getIECanvas())
             this.scrollX = canv.scrollLeft;
          else if (window.pageXOffset)
             this.scrollX = window.pageXOffset;
          else if (window.scrollX)
             this.scrollX = window.scrollX;
          else
             this.scrollX = 0;
       },

       getScrollY: function ()
       {
          var canv;
          if (canv = this.getIECanvas())
             this.scrollY = canv.scrollTop;
          else if (window.pageYOffset)
             this.scrollY = window.pageYOffset;
          else if (window.scrollY)
             this.scrollY = window.scrollY;
          else
             this.scrollY = 0;
       },

       getAll: function ()
       {
          this.getWinWidth();
          this.getWinHeight();
          this.getScrollX();
          this.getScrollY();
       }
    };
//