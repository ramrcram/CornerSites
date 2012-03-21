using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.User;
using CornerSites.Lib.Data;
using CornerSites.Lib.Utils;

namespace CornerSites.Web.Modules.MyAccount
{
    public partial class ProfileInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUerInfo();
        }

        private void GetUerInfo()
        {
            List<tblUser> obj = User.GetUserInfo(CurrentSession.CurrentUserID);
            if (obj != null && obj.Count > 0)
            {
                foreach (tblUser ObjtblUser in obj)
                {
                    lblName.Text = ObjtblUser.FullName;
                    lblMail.Text = ObjtblUser.EmailID;
                    lblPhone.Text = ObjtblUser.MobileNumber;
                   
                }
            }
        }
    }
}