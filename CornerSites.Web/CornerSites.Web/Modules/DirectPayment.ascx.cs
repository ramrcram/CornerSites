using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Utils;
using CornerSites.Lib.Payment;

namespace CornerSites.Web.Modules
{
    public partial class DirectPayment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMonth();
                BindYear();
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            PayPalDirectPaymentProcessor ObjPayment = new PayPalDirectPaymentProcessor();
            string SPaymentStatus =  ObjPayment.DoDirectPaymentCode(CurrentSession.SubscriptionAmount.ToString(), CurrentSession.CurrentUserFullName , 
                                        " ", "Test", "Test2",
                                            "TestCity", "TestState", "560032", ddlCardType.SelectedValue,
                                            txtCardNumber.Text.Trim(), txtCVV.Text.Trim(), int.Parse(ddlMonth.SelectedValue),
                                            int.Parse(ddlYear.SelectedValue));
            if (SPaymentStatus == "Success")
            {   
                Response.Redirect(Web.Components.WebConfigSettings.SiteRoot + "Success.aspx");
            }
        }

        private void BindMonth()
        {
            ddlMonth.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlMonth, "MM");

            for (int i = 1; i <= 12; i++)
            {
                ddlMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        private void BindYear()
        {
            ddlYear.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlYear, "YYYY");

            for (int i = 1990; i <= 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        private void BindUserInfo()
        { 

        }
    }
}