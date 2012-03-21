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
using System.Web.UI.HtmlControls;
using CornerSites.Lib.Directory;
using CornerSites.Lib.Data;

namespace CornerSites.Web.Modules
{
    public partial class SearchBuilder : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindState();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //dgBuilder.Visible = true;
            if (Session["SearchParams"] != null)
                Session.Remove("SearchParams");
            System.Collections.Hashtable objSearchParams = new System.Collections.Hashtable();
            objSearchParams.Add("CityID", Convert.ToByte(ddlCity.SelectedValue));
            objSearchParams.Add("SearchBuilder", Convert.ToChar(ddlSearchBuilder.SelectedValue));
            SiteHelper.SearchParams = objSearchParams;
            CurrentSession.SearchType = "SBui";
            Response.Redirect("/SearchResults.aspx");

            //DataSet ObjSearchResut = Lib.Search.Search.GetSearchBuilder(Convert.ToByte(hfdCityID.Value), Convert.ToChar(ddlSearchBuilder.SelectedValue));
            //if (ObjSearchResut.Tables.Count > 0 && ObjSearchResut.Tables[0].Rows.Count > 0)
            //{
            //    //dgBuilder.Visible = true;
            //    //dgBuilder.DataSource = ObjSearchResut.Tables[0];
            //    //dgBuilder.DataBind();
            //}
        }

        protected void dgBuilder_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            HtmlContainerControl htmlDiv = e.Item.FindControl("divContact") as System.Web.UI.HtmlControls.HtmlContainerControl;
            htmlDiv.Visible = false;

            HtmlAnchor btnViewMore = ((HtmlAnchor)e.Item.FindControl("btnViewMore"));
            btnViewMore.HRef = "#";
        }

        protected void dgBuilder_ItemCommand(object source, DataGridCommandEventArgs e)
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
    }
}