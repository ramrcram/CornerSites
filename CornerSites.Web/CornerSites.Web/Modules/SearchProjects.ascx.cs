using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Data;
using CornerSites.Lib.Utils;
using CornerSites.Lib.PropertyType;
using System.Data;
using System.Web.UI.HtmlControls;
using CornerSites.Lib.Directory;

namespace CornerSites.Web.Modules
{
    public partial class SearchProjects : System.Web.UI.UserControl
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //dgProject.Visible = true;
            //DataSet ObjSearchResut = Lib.Search.Search.GetSearchProject(short.Parse(hfdCityID.Value), short.Parse(hfdLocation.Value), 
            //short.Parse(ddlPropertyType.SelectedValue));
            //if (ObjSearchResut.Tables.Count > 0 && ObjSearchResut.Tables[0].Rows.Count > 0)
            //{
            //    //dgProject.Visible = true;
            //    //dgProject.DataSource = ObjSearchResut.Tables[0];
            //    //dgProject.DataBind();
            //}
            if (Session["SearchParams"] != null)
                Session.Remove("SearchParams");
            System.Collections.Hashtable objSearchParams = new System.Collections.Hashtable();
            objSearchParams.Add("CityID", Convert.ToByte(ddlCity.SelectedValue));
            objSearchParams.Add("Location", Convert.ToByte(ddlLocation.SelectedValue));
            objSearchParams.Add("PropertyType", Convert.ToByte(ddlPropertyType.SelectedValue));
            SiteHelper.SearchParams = objSearchParams;
            CurrentSession.SearchType = "SPr";
            Response.Redirect("/SearchResults.aspx");
        }

        protected void dgProject_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            HtmlContainerControl htmlDiv = e.Item.FindControl("divContact") as System.Web.UI.HtmlControls.HtmlContainerControl;
            htmlDiv.Visible = false;

            HtmlAnchor btnViewMore = ((HtmlAnchor)e.Item.FindControl("btnViewMore"));
            btnViewMore.HRef = "#";

        }

        protected void dgProject_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "searchresult")
            {
                if (CurrentSession.CurrentUserID == 0)
                {
                    Page.RegisterStartupScript("LightBox", "<script language=JavaScript>ShowPopupFromCodeBehind();</script>");
                    return;

                }
                else if (e.CommandName == "viewcontact")
                {
                    System.Web.UI.HtmlControls.HtmlContainerControl htmlDiv = e.Item.FindControl("divContact") as System.Web.UI.HtmlControls.HtmlContainerControl;
                    htmlDiv.Visible = true;
                }
                else if (e.CommandName == "viewcontact")
                {
                    System.Web.UI.HtmlControls.HtmlContainerControl htmlDiv = e.Item.FindControl("divContact") as System.Web.UI.HtmlControls.HtmlContainerControl;
                    htmlDiv.Visible = true;
                }
            }
        }

        protected void ddlState_SelectedChange(object sender, EventArgs e)
        {
            BindCity(ddlState.SelectedValue);
        }

        protected void ddlCity_SelectedChange(object sender, EventArgs e)
        {
            BindArea(ddlCity.SelectedValue);
        }
        #endregion

        #region Method

        private void BindPropertyTypes()
        {
            List<tblPropertyType> ObjPropertyTypes = PropertyType.GetAllPropertyTypes();
            ddlPropertyType.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlPropertyType, "-- select type --");
            if (ObjPropertyTypes != null && ObjPropertyTypes.Count > 0)
            {
                foreach (tblPropertyType type in ObjPropertyTypes)
                {
                    ddlPropertyType.Items.Add(new ListItem(type.PropertyType, type.PropertyTypeID.ToString()));
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