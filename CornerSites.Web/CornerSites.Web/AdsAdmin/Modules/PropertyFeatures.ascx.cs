using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Data;
using CornerSites.Lib.ResidentialPlot;
using CornerSites.Lib.Utils;
using CornerSites.Web.Components;

namespace CornerSites.Web.AdsAdmin.Modules
{
    public partial class PropertyFeatures : System.Web.UI.UserControl
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            BindAllPropertyAge();
            BindAllOwnership();
            BindFloorNumber();
            BindFurnished();
            BindImage(WebConfigSettings.SiteRoot + WebConfigSettings.DefaultImageUrl);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        #endregion

        #region Method

        private void BindAllPropertyAge()
        {
            List<tblPropertyAge> ObjPropertyAge = ResidentialPlot.BindAllPropertyAge();
            ddlConstructionAge.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlConstructionAge, "-- Please select --");
            if (ObjPropertyAge != null && ObjPropertyAge.Count > 0)
            {
                foreach (tblPropertyAge PropertyAge in ObjPropertyAge)
                {
                    ddlConstructionAge.Items.Add(new ListItem(PropertyAge.PropertyAge, PropertyAge.PropertyAgeID.ToString()));
                }
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
                    ddlOwnership.Items.Add(new ListItem(OwnerType.OwnerType, OwnerType.OwnerTypeID.ToString()));
                }
            }
        }
        private void BindFloorNumber()
        {
            ddlFloorNumber.Items.Clear();
            ddlTotalFloors.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlFloorNumber, "-- Please select --");
            SiteHelper.BindDropDownPrefixvalue(ddlTotalFloors, "-- Please select --");

            for (int i = 0; i <= 120; i++)
            {
                ddlFloorNumber.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlTotalFloors.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        public void BindFurnished()
        {
            List<tblFurnishType> ObjFurnishType = ResidentialPlot.BindAllFurnishedType();
            ddlFurnished.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlFurnished, "-- Please select --");
            if (ObjFurnishType != null && ObjFurnishType.Count > 0)
            {
                foreach (tblFurnishType FurnishType in ObjFurnishType)
                {
                    ddlFurnished.Items.Add(new ListItem(FurnishType.FurnishType, FurnishType.FurnishTypeID.ToString()));
                }
            }
        }
        public tblResidentialPropertyAd SaveData(tblResidentialPropertyAd objResidentialPropertyAd,ref byte? PropertyAgeID,ref byte? OwnerTypeID,ref byte? FurnishTypeID )
        {
            objResidentialPropertyAd.FloorNumber = int.Parse(ddlFloorNumber.SelectedValue) < 1 ? default(byte) : byte.Parse(ddlFloorNumber.SelectedValue);
            objResidentialPropertyAd.TotalFloors = int.Parse(ddlTotalFloors.SelectedValue)< 1 ? default(byte) : byte.Parse(ddlTotalFloors.SelectedValue);
            PropertyAgeID = int.Parse(ddlConstructionAge.SelectedValue) < 1 ? default(byte) : byte.Parse(ddlConstructionAge.SelectedValue);
            OwnerTypeID = int.Parse(ddlOwnership.SelectedValue) <1 ? default(byte) : byte.Parse(ddlOwnership.SelectedValue);
            FurnishTypeID = int.Parse(ddlFurnished.SelectedValue) < 1 ? default(byte) : byte.Parse(ddlFurnished.SelectedValue);
            objResidentialPropertyAd.LandMark = txtLandMark.Text;

            return objResidentialPropertyAd;
        }

        public tblCommercialPropAd SaveData(tblCommercialPropAd objResidentialPropertyAd, ref byte? PropertyAgeID, ref byte? OwnerTypeID, ref byte? FurnishTypeID)
        {
            objResidentialPropertyAd.FloorNumber = int.Parse(ddlFloorNumber.SelectedValue) < 1 ? default(byte) : byte.Parse(ddlFloorNumber.SelectedValue);
            objResidentialPropertyAd.TotalFloors = int.Parse(ddlTotalFloors.SelectedValue) < 1 ? default(byte) : byte.Parse(ddlTotalFloors.SelectedValue);
            PropertyAgeID = int.Parse(ddlConstructionAge.SelectedValue) < 1 ? default(byte) : byte.Parse(ddlConstructionAge.SelectedValue);
            OwnerTypeID = int.Parse(ddlOwnership.SelectedValue) < 1 ? default(byte) : byte.Parse(ddlOwnership.SelectedValue);
            FurnishTypeID = int.Parse(ddlFurnished.SelectedValue) < 1 ? default(byte) : byte.Parse(ddlFurnished.SelectedValue);
            objResidentialPropertyAd.LandMark = txtLandMark.Text;

            return objResidentialPropertyAd;
        }

        private void BindImage(string filePath)
        {
            imgProertyImage.ImageUrl = filePath;
        }
        private bool IsValidFile(FileUpload fupImage)
        {
            return (fupImage.PostedFile.ContentType.ToLower() == "image/jpg" ||
                        fupImage.PostedFile.ContentType.ToLower() == "image/jpeg" ||
                        fupImage.PostedFile.ContentType.ToLower() == "image/pjpeg" ||
                        fupImage.PostedFile.ContentType.ToLower() == "image/gif" ||
                        fupImage.PostedFile.ContentType.ToLower() == "image/x-png" ||
                        fupImage.PostedFile.ContentType.ToLower() == "image/png");
        }
        private bool IsValidSize(FileUpload fupImage)
        {
            return (fupImage.PostedFile.ContentLength <= 3145728);
        }
        private void UploadImage()
        {
            if (fupPropertyImage.HasFile && IsValidFile(fupPropertyImage) && IsValidSize(fupPropertyImage))
            {
                fupPropertyImage.SaveAs(Server.MapPath("/Repository/Ads/") + DateTime.Now.Day+fupPropertyImage.FileName);
                BindImage(WebConfigSettings.SiteRoot + "Repository/Ads/" + DateTime.Now.Day + fupPropertyImage.FileName);
            }
            else
            {
                ltnUploadError.Text = "wrong file size/type";
            }
        }



        #endregion
    }
}