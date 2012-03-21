using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Utils;

namespace CornerSites.Web.App_Master
{
    public partial class layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(CurrentSession.CurrentUserID>0)
                BindMessages();
        }

        protected void bntLogOut_Click(object sender, EventArgs e)
        {
            CurrentSession.ClearUserSession();
            Response.Redirect(Components.WebConfigSettings.SiteRoot);
        }

        #region Method

        private void BindMessages()
        {
            lblLoginAs.Text = CurrentSession.CurrentUserFullName;
        }

        #endregion
    }
}
