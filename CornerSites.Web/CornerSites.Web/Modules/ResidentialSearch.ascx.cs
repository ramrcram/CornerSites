using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using CornerSites.Lib.Data;
using CornerSites.Lib.PropertyType;
using CornerSites.Lib.Utils;
using CornerSites.Lib.ResidentialPlot;
using System.Data;

namespace CornerSites.Web.Modules
{
    public partial class ResidentialSearch : System.Web.UI.UserControl
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindPropertyTypes();

        }

        protected void btnSearch_click(object sender, EventArgs e)
        {
            string strLeaseType = string.Empty;
            if (rbdBuy.Checked)
            {
                strLeaseType = "S";
            }
            else
            {
                strLeaseType = "R";
            }

            if (Session["SearchParams"] != null)
                Session.Remove("SearchParams");
            System.Collections.Hashtable objSearchParams = new System.Collections.Hashtable();
            objSearchParams.Add("Property", (ddlPropertType.SelectedValue.ToString()).Contains("-1") ? "-1" : ddlPropertType.SelectedValue.ToString());
            objSearchParams.Add("Location", hfdLocation.Value.ToString());
            objSearchParams.Add("City", hfdCityID.Value.ToString());
            objSearchParams.Add("Bedroom", txtBedroooms.Text);
            objSearchParams.Add("LeaseType", strLeaseType.ToString());
            objSearchParams.Add("BudgetFrom", txtBudgetfrom.Text);
            objSearchParams.Add("BudgetTo", txtBudgetTo.Text);
            objSearchParams.Add("Individual", (chkIndividual.Checked ? "I" : string.Empty));
            objSearchParams.Add("Dealers", (chkDealers.Checked ? "D" : string.Empty));
            objSearchParams.Add("Builders", (chkBuilders.Checked ? "B" : string.Empty));
            objSearchParams.Add("User", "0");
            SiteHelper.SearchParams = objSearchParams;
            //BindData(SiteHelper.SearchParams);
            CurrentSession.SearchType = "SRes";
            Response.Redirect("/SearchResults.aspx");
        }

        #endregion

        #region method

        private void BindPropertyTypes()
        {
            List<tblPropertyType> ObjPropertyTypes = PropertyType.GetAllPropertyTypes();
            ddlPropertType.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlPropertType, "-- select type --");
            if (ObjPropertyTypes != null && ObjPropertyTypes.Count > 0)
            {
                foreach (tblPropertyType type in ObjPropertyTypes)
                {
                    ddlPropertType.Items.Add(new ListItem(type.PropertyType, type.PropertyTypeID.ToString()));
                }
            }
        }

        #endregion
    }
}