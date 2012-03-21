using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Utils;
using System.Data;

namespace CornerSites.Web.Modules.MyAccount
{
    public partial class MySubscription : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindSubscription();
        }

        #region Method

        private void BindSubscription()
        {
            BindData(GetSubscriptionDetails().GetXml(), Server.MapPath("~/Xslts/MySubscription.xslt"));
        }

        private DataSet GetSubscriptionDetails()
        {
            DataSet ObjSearchResut = Lib.User.User.GetSubscriptionDetails(CurrentSession.CurrentUserID);
            return ObjSearchResut;
        }


        private void BindData(string xml, string filePath)
        {
            string Result = SiteHelper.XsltTransform(xml, filePath);
            Control ctrl = Page.ParseControl(Result);
            PanSubscription.Controls.Add(ctrl);
        }

        #endregion
    }
}