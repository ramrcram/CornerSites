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

namespace CornerSites.Web.Modules
{
    public partial class SearchProjectsAdvance : System.Web.UI.UserControl
    {

        #region Events


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindPropertyTypes();
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
            objSearchParams.Add("CityID", Convert.ToByte(hfdCityID.Value));
            objSearchParams.Add("Location", Convert.ToByte(hfdLocation.Value));
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

        #endregion
    }
}