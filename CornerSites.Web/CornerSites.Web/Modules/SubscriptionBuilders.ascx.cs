using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CornerSites.Lib.Utils;

namespace CornerSites.Web.Modules
{
    public partial class SubscriptionBuilders : System.Web.UI.UserControl
    {
        #region events

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Method

        public void BindData(DataTable Dt)
        {
            DataSet ds = new DataSet();
            DataTable DtTemp = new DataTable();
            
            DtTemp = Dt.Copy();
            DtTemp.TableName = "Table";
            ds.Tables.Add(DtTemp);
            BindData(ds.GetXml(), Server.MapPath("~/Xslts/SubscriptionDetails.xslt"));
        }

        private void BindData(string xml, string filePath)
        {
            string Result = SiteHelper.XsltTransform(xml, filePath);
            Control ctrl = Page.ParseControl(Result);
            dvBuilders.Controls.Add(ctrl);
        }

        #endregion
    }
}