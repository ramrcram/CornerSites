using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib;
using CornerSites.Lib.Data;
using CornerSites.Lib.ResidentialPlot;
using CornerSites.Lib.Directory;
using CornerSites.Lib.Utils;

namespace CornerSites.Web.AdsAdmin.Modules
{
    public partial class ResidentialPlotFields : System.Web.UI.UserControl
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
                BindControls();
        }

        #endregion

        #region Method 

        private void BindControls()
        {
            BindAllPropertyAge();
            BindAllOwnership();
        }

        private void BindAllPropertyAge()
        {
            List<tblPropertyAge> ObjPropertyAge = ResidentialPlot.BindAllPropertyAge();
            ddlConstAge.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlConstAge, "-- Please select --");
            if (ObjPropertyAge != null && ObjPropertyAge.Count > 0)
            {
                foreach (tblPropertyAge PropertyAge in ObjPropertyAge)
                {
                    ddlConstAge.Items.Add(new ListItem(PropertyAge.PropertyAge,PropertyAge.PropertyAgeID.ToString()));
                }
                //SiteHelper.BindDropDownValues<tblPropertyAge>(ddlConstAge, ObjPropertyAge, "--please select age --");
                //ddlConstAge.DataTextField = "PropertyAge";
                //ddlConstAge.DataValueField = "PropertyAgeID";
                //ddlConstAge.DataBind();
            }
        }

        private void BindAllOwnership()
        {
            List<tblOwnerType> ObjOwnerType = ResidentialPlot.BindAllOwnerType();
            ddlOwnership.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlOwnership, "-- Please select --");
            if (ObjOwnerType != null && ObjOwnerType.Count > 0)
            {
                foreach (tblOwnerType OwnerType in ObjOwnerType)
                {
                    ddlOwnership.Items.Add(new ListItem(OwnerType.OwnerType,OwnerType.OwnerTypeID.ToString()));
                }
                //SiteHelper.BindDropDownValues<tblOwnerType>(ddlOwnership, ObjOwnerType, "--please select ownwertype --");
                //ddlOwnership.DataTextField = "OwnerTypeID";
                //ddlOwnership.DataValueField = "OwnerType";
                //ddlOwnership.DataBind();
            }
        }

        #endregion
    }
}