using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Utils;
using CornerSites.Lib.Data;

namespace CornerSites.Web.AdsAdmin.Modules
{
    public partial class PropertyTermsAndConditions : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public tblResidentialPropertyAd SaveData(tblResidentialPropertyAd objResidentialProAd)
        {
            objResidentialProAd.TandC = txtTermsConditions.Text;
            objResidentialProAd.DuesToPay = txtAnnualDues.Text;

            return objResidentialProAd;
        }

        public tblCommercialPropAd SaveData(tblCommercialPropAd objResidentialProAd)
        {
            objResidentialProAd.TandC = txtTermsConditions.Text;
            objResidentialProAd.DuesToPay = txtAnnualDues.Text;

            return objResidentialProAd;
        }

    }
}