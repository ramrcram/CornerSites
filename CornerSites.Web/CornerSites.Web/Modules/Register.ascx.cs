using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.User;
using CornerSites.Lib.Data;
using CornerSites.Lib.Utils;
using CornerSites.Lib.Directory;
using CornerSites.Web.Components;

namespace CornerSites.Web.Modules
{
    public partial class Register : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCity();
               // BindArea();
            }

        }

        protected void btnRegister_click(object sender, EventArgs e)
        {
            ccJoin.ValidateCaptcha(txtCaptcha.Text);
            //if (!ccJoin.UserValidated)
            //{
            //    //Inform user that his input was wrong ...
            //    return;
            //}

            if (!Page.IsValid && !ccJoin.UserValidated)
            {
                lblStatus.Text = "Validation Error";
                return;
            }

            User user = new User();
            string strUserType;
            if (rbtBuilder.Checked)
                strUserType = "B";
            else if (rbtDealer.Checked)
                strUserType = "D";
            else
            { strUserType = "I"; }

            if (!user.UserExists(txtEmail.Text.Trim()))
            {
                List<tblUser> objUser= user.Register(strUserType, txtFullName.Text.Trim(), txtEmail.Text.Trim(),
                    SiteHelper.EncryptPassword(txtPassword.Text.Trim(), true, WebConfigSettings.HashKey), 
                    Convert.ToInt32(ddlCity.SelectedValue), txtMobile.Text.Trim(), txtLandline.Text.Trim(), 
                    Convert.ToInt32(ddlArea.SelectedValue), txtRegOffice.Text.Trim());
                
                if (objUser.Count > 0)
                {
                    //CurrentSession.CurrentUserID = objUser[0].UserId;
                    //CurrentSession.CurrentUserType = objUser[0].UserTypeID;
                    User.Login(txtEmail.Text.Trim(),SiteHelper.EncryptPassword(txtPassword.Text.Trim(), true, WebConfigSettings.HashKey));
                }
                if (Request.QueryString["callback"] != null)
                {
                    Response.Redirect(Request.QueryString["callback"].ToString());
                }
                else
                    Response.Redirect("default.aspx");
            }
            else
            {
                lblStatus.Text = "Email ID exists.Choose a different Email ID";
            }
        }

        protected void ddlCity_SelectedChange(object sender, EventArgs e)
        {
            BindArea(ddlCity.SelectedValue);
        }

        #region method

        private void BindCity()
        {
            List<tblCity> ObjCity = DirectoryManager.GetAllCitys();
            ddlCity.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlCity, "-- select city --");
            if (ObjCity != null && ObjCity.Count > 0)
            {
                foreach (tblCity city in ObjCity)
                {
                    ddlCity.Items.Add(new ListItem(city.CityName, city.CityID.ToString()));
                }
            }
        }

        private void BindArea(string cityID)
        {
            List<tblArea> objArea = DirectoryManager.GetSpecificAreas(cityID);
            ddlArea.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlArea, "-- select Location --");
            if (objArea != null && objArea.Count > 0)
            {
                foreach (tblArea type in objArea)
                {
                    ddlArea.Items.Add(new ListItem(type.AreaName, type.AreaID.ToString()));
                }
            }
        }

        #endregion
    }
}