using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Utils;

namespace CornerSites.Web.AdsAdmin
{
    public partial class PostAds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (CurrentSession.CurrentUserID == 0)
              //  Response.Redirect("~/default.aspx");
            if (CurrentSession.CurrentUserID <= 0)
            {
                Page.RegisterStartupScript("LightBox", "<script language=JavaScript>ShowPopupFromCodeBehind();</script>");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            cntAdsCommon.Save();
        }        
    }
}
