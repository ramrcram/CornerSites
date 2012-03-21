using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Data;
using CornerSites.Lib.PropertyType;
using CornerSites.Lib.Utils;
using CornerSites.Lib.ResidentialPlot;
using CornerSites.Lib.Directory;

namespace CornerSites.Web.Modules
{
    public partial class SearchRequirement : System.Web.UI.UserControl
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPropertyTypes();
                BindState();
            }

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
            objSearchParams.Add("Location", ddlLocation.SelectedValue.ToString());
            objSearchParams.Add("City", ddlCity.SelectedValue.ToString());
            objSearchParams.Add("Bedroom", txtBedroooms.Text);
            objSearchParams.Add("LeaseType", strLeaseType.ToString());
            objSearchParams.Add("Budget", txtBudgetfrom.Text);
            //objSearchParams.Add("BudgetTo", txtBudgetTo.Text);
            objSearchParams.Add("Individual", (chkIndividual.Checked ? "I" : string.Empty));
            objSearchParams.Add("Dealers", (chkDealers.Checked ? "D" : string.Empty));
            objSearchParams.Add("Builders", (chkBuilders.Checked ? "B" : string.Empty));
            objSearchParams.Add("User", "0");
            SiteHelper.SearchParams = objSearchParams;
            CurrentSession.SearchType = "SReq";
            Response.Redirect("/SearchResults.aspx?Search=Req");
        }

        protected void ddlCity_SelectedChange(object sender, EventArgs e)
        {
            BindArea(ddlCity.SelectedValue);
        }

        protected void ddlState_SelectedChange(object sender, EventArgs e)
        {
            BindCity(ddlState.SelectedValue);
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

        private void BindState()
        {
            List<tblState> objState = DirectoryManager.GetAllStates();
            ddlState.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlState, "-- select State --");
            if (objState != null && objState.Count > 0)
            {
                foreach (tblState type in objState)
                {
                    ddlState.Items.Add(new ListItem(type.StateName, type.StateID.ToString()));
                }
                // BindArea();
            }
        }

        private void BindCity(string stateId)
        {
            int iStateId = Convert.ToInt32(stateId);
            List<tblCity> objCity = DirectoryManager.GetAllCitysByStateID(iStateId);
            ddlCity.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlCity, "-- select City --");
            if (objCity != null && objCity.Count > 0)
            {
                foreach (tblCity type in objCity)
                {
                    ddlCity.Items.Add(new ListItem(type.CityName, type.CityID.ToString()));
                }
               // BindArea();
            }
        }

        private void BindArea(string cityID)
        {
            List<tblArea> objArea = DirectoryManager.GetSpecificAreas(cityID);
            ddlLocation.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlLocation, "-- select Location --");
            if (objArea != null && objArea.Count > 0)
            {
                foreach (tblArea type in objArea)
                {
                    ddlLocation.Items.Add(new ListItem(type.AreaName, type.AreaID.ToString()));
                }
            }
        }
        #endregion
    }
}