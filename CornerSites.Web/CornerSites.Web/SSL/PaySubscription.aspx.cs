using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CornerSites.Web.SSL
{
    public partial class PaySubscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAmount();
        }

        #region Method

        private void GetAmount()
        {
            lblAmount.Text = Lib.Utils.CurrentSession.SubscriptionAmount.ToString();
        }

        #endregion
    }
}
