using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.User;
using CornerSites.Lib.Utils;
using CornerSites.Web.Components;

namespace CornerSites.Web.Modules
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Anthem.Manager.Register(this);
        }

        #region Method

        #region Anthem 

        [Anthem.Method]
        public void LoginUser(string strCallbackurl)
        {
            if (txtPassword.Text != "")//(objUser.Login(txtLoginID.Text.Trim(), txtPassword.Text.Trim()))
            {
                User.Login(txtLoginID.Text, SiteHelper.EncryptPassword(txtPassword.Text.Trim(), true, WebConfigSettings.HashKey));
                if (CurrentSession.CurrentUserID != 0)
                {
                    if (!string.IsNullOrEmpty(CurrentSession.ReturnUrl))
                        Response.Redirect(CurrentSession.ReturnUrl);
                    else
                        Response.Redirect("Default.aspx");
                }
                else
                {
                    lblStatus.Text = "Incorrect login details";
                }
            }
            else
            {
                lblStatus.Text = "Incorrect login details";
            }

            lblStatus.UpdateAfterCallBack = true;
        }

        #endregion
        #endregion

        protected void btnLogin_click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")//(objUser.Login(txtLoginID.Text.Trim(), txtPassword.Text.Trim()))
            {
                User.Login(txtLoginID.Text, SiteHelper.EncryptPassword(txtPassword.Text.Trim(),true,WebConfigSettings.HashKey));
            }
            else
            {
                lblStatus.Text = "Incorrect login details";
            }
        }
    }
}