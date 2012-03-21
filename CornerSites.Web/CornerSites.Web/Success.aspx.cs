using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CornerSites.Web
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrSuccessMessage.Text = "Paymrnt Success ";
            HtmlAnchor anc = new HtmlAnchor();
            anc.HRef = Web.Components.WebConfigSettings.SiteRoot;
            anc.InnerText = "Go to home";
            dvmessage.Controls.Add(anc);
        }
    }
}
