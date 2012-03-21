using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Search;
using System.Data.SqlClient;
using System.Data;
using CornerSites.Lib.Utils;
using CornerSites.Lib.Directory;
using CornerSites.Lib.Data;

namespace CornerSites.Web.Modules
{
    public partial class AgentSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindState();
                
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //dgAgent.Visible = true;
            if (Session["SearchParams"] != null)
                Session.Remove("SearchParams");
            System.Collections.Hashtable objSearchParams = new System.Collections.Hashtable();
            objSearchParams.Add("CityID", Convert.ToByte(ddlCity.SelectedValue));
            objSearchParams.Add("Location", Convert.ToByte(ddlLocation.SelectedValue));
            SiteHelper.SearchParams = objSearchParams;
            CurrentSession.SearchType = "SAg";
            Response.Redirect("/SearchResults.aspx");
        }

        protected void ddlState_SelectedChange(object sender, EventArgs e)
        {
            BindCity(ddlState.SelectedValue);
        }

        protected void ddlCity_SelectedChange(object sender, EventArgs e)
        {
            BindArea(ddlCity.SelectedValue);
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
    }
}