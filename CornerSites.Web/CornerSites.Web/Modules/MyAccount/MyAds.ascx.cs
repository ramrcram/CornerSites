using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CornerSites.Lib.Utils;

namespace CornerSites.Web.Modules.MyAccount
{
    public partial class MyAds : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindAds();
        }

        #region Method

        private void BindAds()
        {
            BindData(GetAdsDetails().GetXml(), Server.MapPath("~/Xslts/MyAds.xslt"));
        }

        private DataSet GetAdsDetails()
        {
            DataSet ObjSearchResut = Lib.User.User.GetAdsDetails(CurrentSession.CurrentUserID);
            return ObjSearchResut;
        }


        private void BindData(string xml, string filePath)
        {
            string Result = SiteHelper.XsltTransform(xml, filePath);
            Control ctrl = Page.ParseControl(Result);
            PanAds.Controls.Add(ctrl);
        }

        #endregion
    }
}