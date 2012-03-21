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
using CornerSites.Lib.Directory;

namespace CornerSites.Web.Modules
{
    public partial class PostRequirement : System.Web.UI.UserControl
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentSession.CurrentUserID <= 0)
            {
                Page.RegisterStartupScript("LightBox", "<script language=JavaScript>ShowPopupFromCodeBehind();</script>");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindPropertyTypes();
                    BindState();
                    BindUnits();
                }
            }
            lblMessage.Text = string.Empty;
        }

        protected void btnPostReq_Click(object sender, EventArgs e)
        {
            if (CurrentSession.CurrentUserID != null && CurrentSession.CurrentUserID > 0)
            {   
                tblPropertyType ObjtblPropertyType = Lib.Directory.DirectoryManager.CheckType(int.Parse(ddlPropertType.SelectedValue));
                if (ObjtblPropertyType.ResidentialFlag.ToString().ToLower() == "c" ||
                    ObjtblPropertyType.ResidentialFlag.ToString().ToLower() == "a")
                {
                    Lib.Search.Search.PostRequirement_C((string.IsNullOrEmpty(txtBudgetfrom.Text) ? 0 : Convert.ToInt32(txtBudgetfrom.Text)),
                         (string.IsNullOrEmpty(txtBudgetTo.Text) ? 0 : Convert.ToInt32(txtBudgetTo.Text)),
                         txtDiscription.Text,
                         CurrentSession.CurrentUserID,
                         Convert.ToInt16(ddlLocation.SelectedValue),
                         (byte.Parse(ddlPropertType.SelectedValue)),
                         Convert.ToInt32(txtCoveredArea.Text), (byte.Parse(ddlCoverdUnit.SelectedValue)),
                         Convert.ToInt32(txtBuildArea.Text), (byte.Parse(ddlBuildUnit.SelectedValue)),
                         Components.WebConfigSettings.PostReqExpiryDate);
                }
                else if (ObjtblPropertyType.ResidentialFlag.ToString().ToLower() == "r")
                {
                    Lib.Search.Search.PostRequirement_R((string.IsNullOrEmpty(txtBudgetfrom.Text) ? 0 : Convert.ToInt32(txtBudgetfrom.Text)),
                         (string.IsNullOrEmpty(txtBudgetTo.Text) ? 0 : Convert.ToInt32(txtBudgetTo.Text)),
                         txtDiscription.Text,
                         CurrentSession.CurrentUserID,
                         Convert.ToInt16(ddlLocation.SelectedValue),
                         (byte.Parse(ddlPropertType.SelectedValue)),
                         Convert.ToInt32(txtCoveredArea.Text), (byte.Parse(ddlCoverdUnit.SelectedValue)),
                         Convert.ToInt32(txtBuildArea.Text), (byte.Parse(ddlBuildUnit.SelectedValue)),
                         Components.WebConfigSettings.PostReqExpiryDate);
                }
                lblMessage.Text = "Thanks for your Requirement";
                //Lib.Search.Search.PostRequirement(objcommercial);
            }
            else
            {
                Page.RegisterStartupScript("LightBox", "<script language=JavaScript>ShowPopupFromCodeBehind();</script>");
                return;

            }
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

        #region Method

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

        private void BindUnits()
        {
            List<tblAreaUnits> objArea = DirectoryManager.GetAreaUnits();
            ddlBuildUnit.Items.Clear();
            ddlCoverdUnit.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlLocation, "-- select Unit --");
            if (objArea != null && objArea.Count > 0)
            {
                foreach (tblAreaUnits type in objArea)
                {
                    ddlBuildUnit.Items.Add(new ListItem(type.Unit, type.UnitID.ToString()));
                    ddlCoverdUnit.Items.Add(new ListItem(type.Unit, type.UnitID.ToString()));
                }
            }
        }

        #endregion

    }
}