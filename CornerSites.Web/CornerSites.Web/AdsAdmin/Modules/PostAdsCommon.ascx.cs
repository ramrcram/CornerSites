using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib;
using CornerSites.Lib.Data;
using CornerSites.Lib.PropertyType;
using CornerSites.Lib.Directory;
using CornerSites.Lib.Utils;
using CornerSites.Lib.ResidentialPlot;
using CornerSites.Web.Components;

namespace CornerSites.Web.AdsAdmin.Modules
{
    public partial class PostAdsCommon : System.Web.UI.UserControl
    {

        short CityID; 
        byte PropertyTypeID;
        byte? PropertyAgeID =null ;
        byte? OwnerTypeID = null;
        byte? FurnishTypeID=null;

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
                    BindControls();
                BindDynamicControls();
            }
        }

        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindDynamicControls();
        } 

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLocation();
        }

        #endregion

        #region Method

        private void BindControls()
        {
            BindPropertyTypes();
            BindStates();
            BindBedrooms();
            BindBathrooms();
        }

        private void BindPropertyTypes()
        {
            List<tblPropertyType> ObjPropertyTypes = PropertyType.GetAllPropertyTypes();            
            ddltype.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddltype,"-- select type --");
            if (ObjPropertyTypes != null && ObjPropertyTypes.Count > 0)
            {   
                foreach (tblPropertyType type in ObjPropertyTypes)
                {
                    ddltype.Items.Add(new ListItem(type.PropertyType,type.PropertyTypeID.ToString()));
                }

                //ddltype.DataSource = ObjPropertyTypes;
                //ddltype.DataTextField = "PropertyType";
                //ddltype.DataValueField = "PropertyTypeID";                
                //ddltype.DataBind();
            }
        }

        private void BindSaleType()
        {   
        }

        private void BindStates()
        {
            List<tblState> ObjStates = DirectoryManager.GetAllStatesbyCountryID(1);
            ddlState.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlState, "-- select state --");
            if (ObjStates != null && ObjStates.Count > 0)
            {   
                foreach (tblState state in ObjStates)
                {
                    ddlState.Items.Add(new ListItem(state.StateName,state.StateID.ToString()));
                }
                //SiteHelper.BindDropDownValues<tblState>(ddlState, ObjStates, "--please select state--");
                //ddlState.DataTextField = "StateName";
                //ddlState.DataValueField = "StateID";
                //ddlState.DataBind();
            }
            if (ddlState.Items.Count == 1)
                BindCity();
        }

        private void BindCity()
        {
            List<tblCity> ObjCity = DirectoryManager.GetAllCitysByStateID(Convert.ToInt32(ddlState.SelectedItem.Value.ToString()));
            ddlCity.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlCity, "-- select city --");
            if (ObjCity != null && ObjCity.Count > 0)
            {
                foreach (tblCity city in ObjCity)
                {
                    ddlCity.Items.Add(new ListItem(city.CityName,city.CityID.ToString()));
                }
                //SiteHelper.BindDropDownValues<tblCity>(ddlCity, ObjCity, "--please select city--");
                //ddlCity.DataTextField = "CityName";
                //ddlCity.DataValueField = "CityID";
                //ddlCity.DataBind();
            }
            if (ddlCity.Items.Count == 1)
                BindLocation();
        }

        private void BindLocation()
        {
            List<tblArea> ObjArea = DirectoryManager.GetAllAreas(Convert.ToInt32(ddlCity.SelectedItem.Value.ToString()));
            ddlLocation.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlLocation, "-- select location --");
            if (ObjArea != null && ObjArea.Count > 0)
            {
                foreach (tblArea area in ObjArea)
                {
                    ddlLocation.Items.Add(new ListItem(area.AreaName.ToString(),area.AreaID.ToString()));
                }
                //SiteHelper.BindDropDownValues<tblArea>(ddlLocation, ObjArea, "--please select location--");
                //ddlLocation.DataTextField = "AreaName";
                //ddlLocation.DataValueField = "AreaID";
                //ddlLocation.DataBind();
            }
        }

        private void BindDynamicControls()
        {
            if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.ResidentialPlot)
            {
                Control ResidentialPlotFields = LoadControl("ResidentialPlotFields.ascx");                
                ResidentialPlotFields.ID = "ctrlResidentialPlotFields";
                panSpecialFeilds.Controls.Add(ResidentialPlotFields);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.ResidentialHouseVilla)
            {
                Control ResidentialVilla = LoadControl("ResidentialHouseVilla.ascx");
                ResidentialVilla.ID = "ctrlResidentialVilla";
                panSpecialFeilds.Controls.Add(ResidentialVilla);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.ResidentialApartment)
            {
                Control ResidentialApartment = LoadControl("ResidentialApartment.ascx");
                ResidentialApartment.ID = "ctrlResidentialApartment";
                panSpecialFeilds.Controls.Add(ResidentialApartment);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.BuilderFloorApartment)
            {
                Control BuilderFloorApartment = LoadControl("BuilderFloorApartment.ascx");
                BuilderFloorApartment.ID = "ctrlBuilderFloorApartment";
                panSpecialFeilds.Controls.Add(BuilderFloorApartment);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.StudioApartment)
            {
                Control StudioApartment = LoadControl("StudioApartment.ascx");
                StudioApartment.ID = "ctrlStudioApartment";
                panSpecialFeilds.Controls.Add(StudioApartment);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.ServicedApartment)
            {
                Control ServicedApartment = LoadControl("ServicedApartment.ascx");
                ServicedApartment.ID = "ctrlServicedApartment";
                panSpecialFeilds.Controls.Add(ServicedApartment);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.FarmHouse)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.NewResidentialProjects)
            {
                Control NewResidentialProjects = LoadControl("NewResidentialProjects.ascx");
                NewResidentialProjects.ID = "ctrlNewResidentialProjects";
                panSpecialFeilds.Controls.Add(NewResidentialProjects);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.HolidayHome)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.AgriculturalLand)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.FarmHouse)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.CommercialIndustrialland)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.CommercialOfficeSpace)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.CommercialShowroom)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.CommercialShop)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.Kiosk)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.ResortsHotel)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.GuestHouse)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.PayingGuest)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.GodownWareHouse)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.BusinessCentre)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.Factory)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.IndustrialBuilding)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }
            else if (int.Parse(ddltype.SelectedItem.Value) == (int)SiteHelper.PROPERTYTYPE.NewCommercialProjects)
            {
                Control FarmHouse = LoadControl("FarmHouse.ascx");
                FarmHouse.ID = "ctrlFarmHouse";
                panSpecialFeilds.Controls.Add(FarmHouse);
            }

        }

        private void BindBedrooms()
        {
            //TODO : need to bind from DB
            ddlBedrooms.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlBedrooms, "-- select location --");
            for (int i = 1; i <= 20; i++)
            {
                ddlBedrooms.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        private void BindBathrooms()
        {
            //TODO : need to bind from DB
            ddlBathrooms.Items.Clear();
            SiteHelper.BindDropDownPrefixvalue(ddlBathrooms, "-- select location --");
            for (int i = 1; i <= 20; i++)
            {
                ddlBathrooms.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
       

        public void Save()
        {
            if(ResidentialPlot.GetAddsCount(CurrentSession.CurrentUserID,CurrentSession.CurrentUserType) >= int.Parse(WebConfigSettings.FreeAdds))
            {
                Page.RegisterStartupScript("LightBox", "<script language=JavaScript>LightBox();</script>");
                return;
            }
            tblResidentialPropertyAd objResidentialProAd;
            tblCommercialPropAd objCommercialPropAd;
            tblPropertyType ObjtblPropertyType = Lib.Directory.DirectoryManager.CheckType(int.Parse(ddltype.SelectedValue));
            string sResidentialFlag = ObjtblPropertyType.ResidentialFlag.ToString().ToLower();
            if (ObjtblPropertyType.ResidentialFlag.ToString().ToLower() == "c" ||
                    ObjtblPropertyType.ResidentialFlag.ToString().ToLower() == "a")
            {
                objCommercialPropAd = SaveCommonPropertyFields_C();
                switch (int.Parse(ddltype.SelectedItem.Value))
                {
                    case (int)SiteHelper.PROPERTYTYPE.AgriculturalLand:
                        SaveAgriculturalLand(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.FarmHouse:
                        SaveFarmHouse(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.CommercialIndustrialland:
                        SaveCommercialIndustrialland(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.CommercialOfficeSpace:
                        SaveCommercialOfficeSpace(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.CommercialShowroom:
                        SaveCommercialShowroom(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.CommercialShop:
                        SaveCommercialShop(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.Kiosk:
                        SaveKiosk(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.ResortsHotel:
                        SaveResortsHotel(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.GuestHouse:
                        SaveGuestHouse(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.GodownWareHouse:
                        SaveGodownWareHouse(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.BusinessCentre:
                        SaveBusinessCentre(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.Factory:
                        SaveFactory(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.IndustrialBuilding:
                        SaveIndustrialBuilding(objCommercialPropAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.NewCommercialProjects:
                        SaveNewCommercialProjects(objCommercialPropAd);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                objResidentialProAd = SaveCommonPropertyFields_R();
                switch (int.Parse(ddltype.SelectedItem.Value))
                {
                    case (int)SiteHelper.PROPERTYTYPE.ResidentialPlot:
                        SaveResidentialPlotField(objResidentialProAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.ResidentialHouseVilla:
                        SaveResidentialHouseVilla(objResidentialProAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.HolidayHome:
                        SaveHolidayHome(objResidentialProAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.ResidentialApartment:
                        SaveResidentialApartment(objResidentialProAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.BuilderFloorApartment:
                        SaveBuilderFloorApartment(objResidentialProAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.StudioApartment:
                        SaveStudioApartment(objResidentialProAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.ServicedApartment:
                        SaveServicedApartment(objResidentialProAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.NewResidentialProjects:
                        SaveNewResidentialProjects(objResidentialProAd);
                        break;
                    case (int)SiteHelper.PROPERTYTYPE.PayingGuest:
                        SavePayingGuest(objResidentialProAd);
                        break;
                    default:
                        break;
                }
            }

            Response.Redirect(Components.WebConfigSettings.SiteRoot);
        }

        private tblResidentialPropertyAd SaveCommonPropertyFields_R()
        {
            tblResidentialPropertyAd objResidentialProAd = new tblResidentialPropertyAd();
            if (objResidentialProAd == null)
                return null;

            objResidentialProAd.LeaseType = (radBtnSell.Checked ? "S" : "R");
            objResidentialProAd.AdHeader = txtAdHeader.Text;
            
            /*tblCity objCity = new tblCity();
            objCity.CityID = short.Parse(ddlCity.SelectedItem.Value); //ObjCity;            

            tblPropertyType objType = new tblPropertyType();
            objType.PropertyTypeID = byte.Parse(ddltype.SelectedValue.ToString());*/

            //objResidentialProAd.tblCity = short.Parse(ddlCity.SelectedItem.Value); ;
            CityID = short.Parse(ddlCity.SelectedItem.Value);
            objResidentialProAd.AreaID = byte.Parse(ddlLocation.SelectedItem.Value);
            objResidentialProAd.PlotArea = int.Parse(txtLandArea.Text);
            objResidentialProAd.BuildArea = int.Parse(txtBuildArea.Text);
            objResidentialProAd.PriceNegotiableFlag = chkPrice.Checked;
            objResidentialProAd.PropertyPrice = int.Parse(txtPrice.Text);
            objResidentialProAd.PropertyDescription = txtDescProp.Text;
            objResidentialProAd.BathRooms = byte.Parse(ddlBathrooms.SelectedValue);
            objResidentialProAd.BedRooms = byte.Parse(ddlBedrooms.SelectedValue);


            //objResidentialProAd.tblPropertyType = objType;
            //objResidentialProAd.tblPropertyType.PropertyTypeID = byte.Parse(ddltype.SelectedValue.ToString());
            PropertyTypeID = byte.Parse(ddltype.SelectedValue.ToString());
            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveCommonPropertyFields_C()
        {
            tblCommercialPropAd objCommercialPropAd = new tblCommercialPropAd();
            if (objCommercialPropAd == null)
                return null;

            objCommercialPropAd.LeaseType = (radBtnSell.Checked ? "S" : "R");
            objCommercialPropAd.AdHeader = txtAdHeader.Text;

            /*tblCity objCity = new tblCity();
            objCity.CityID = short.Parse(ddlCity.SelectedItem.Value); //ObjCity;            

            tblPropertyType objType = new tblPropertyType();
            objType.PropertyTypeID = byte.Parse(ddltype.SelectedValue.ToString());*/

            //objResidentialProAd.tblCity = short.Parse(ddlCity.SelectedItem.Value); ;
            CityID = short.Parse(ddlCity.SelectedItem.Value);
            //objCommercialPropAd.AreaID = byte.Parse(ddlLocation.SelectedItem.Value);
            objCommercialPropAd.PlotArea = int.Parse(txtLandArea.Text);
            objCommercialPropAd.BuildArea = int.Parse(txtBuildArea.Text);
            objCommercialPropAd.PriceNegotiableFlag = chkPrice.Checked;
            objCommercialPropAd.PropertyPrice = int.Parse(txtPrice.Text);
            objCommercialPropAd.PropertyDescription = txtDescProp.Text;
            objCommercialPropAd.BathRooms = byte.Parse(ddlBathrooms.SelectedValue);
            //objCommercialPropAd.BedRooms = byte.Parse(ddlBedrooms.SelectedValue);

            //objResidentialProAd.tblPropertyType = objType;
            //objResidentialProAd.tblPropertyType.PropertyTypeID = byte.Parse(ddltype.SelectedValue.ToString());
            PropertyTypeID = byte.Parse(ddltype.SelectedValue.ToString());
            return objCommercialPropAd;
        }


        //private T SaveCommonPropertyFields<T>(T instance) where T : CornerSites.Lib.Data.ObjectInterFace.ItblResidentialPropertyAd
        //{
        //    // T temp = default(T);

        //    CornerSites.Lib.Data.ObjectInterFace.ItblResidentialPropertyAd Objinter = instance;

        //     //tblResidentialPropertyAd objResidentialProAd = new tblResidentialPropertyAd();
        //    // if (Objinter == null)
        //    //return;

        //    Objinter.LeaseType = (radBtnSell.Checked ? "S" : "R");
        //    Objinter.AdHeader = txtAdHeader.Text;

        //    /*tblCity objCity = new tblCity();
        //    objCity.CityID = short.Parse(ddlCity.SelectedItem.Value); //ObjCity;            

        //    tblPropertyType objType = new tblPropertyType();
        //    objType.PropertyTypeID = byte.Parse(ddltype.SelectedValue.ToString());*/

        //    //objResidentialProAd.tblCity = short.Parse(ddlCity.SelectedItem.Value); ;
        //    CityID = short.Parse(ddlCity.SelectedItem.Value);
        //    Objinter.AreaID = byte.Parse(ddlLocation.SelectedItem.Value);
        //    Objinter.PlotArea = int.Parse(txtLandArea.Text);
        //    Objinter.BuildArea = int.Parse(txtBuildArea.Text);
        //    Objinter.PriceNegotiableFlag = chkPrice.Checked;
        //    Objinter.PropertyPrice = int.Parse(txtPrice.Text);
        //    Objinter.PropertyDescription = txtDescProp.Text;
        //    Objinter.BathRooms = byte.Parse(ddlBathrooms.SelectedValue);
        //    Objinter.BedRooms = byte.Parse(ddlBedrooms.SelectedValue);


        //    //objResidentialProAd.tblPropertyType = objType;
        //    //objResidentialProAd.tblPropertyType.PropertyTypeID = byte.Parse(ddltype.SelectedValue.ToString());
        //    PropertyTypeID = byte.Parse(ddltype.SelectedValue.ToString());
        //    return (T)Objinter;
        //}

        #region Commercial Property Ad

        private tblCommercialPropAd SaveAgriculturalLand(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)            
                return null;

            ResidentialPlotFields cntlResidentialPlotFields = (panSpecialFeilds.FindControl("ctrlResidentialPlotFields")) as ResidentialPlotFields;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (cntlResidentialPlotFields.FindControl("PropertyTermsAndConditions1")) as PropertyTermsAndConditions;

            if(cntlResidentialPlotFields == null)
                return null;

            if ((int.Parse((SiteHelper.ReturnDropDownselectedItemValue(cntlResidentialPlotFields, "ddlConstAge")))) > 0)
                PropertyAgeID = byte.Parse(SiteHelper.ReturnDropDownselectedItemValue(cntlResidentialPlotFields, "ddlConstAge"));
            if ((int.Parse(SiteHelper.ReturnDropDownselectedItemValue(cntlResidentialPlotFields, "ddlOwnership")) > 0 ))
                OwnerTypeID = byte.Parse(SiteHelper.ReturnDropDownselectedItemValue(cntlResidentialPlotFields, "ddlOwnership"));

            objResidentialProAd.LandMark = SiteHelper.ReturnTextBoxValue(cntlResidentialPlotFields, "txtLandmarks");


            if(cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (cntlResidentialPlotFields.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;
            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }
            
            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID,CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveFarmHouse(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveCommercialIndustrialland(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveCommercialOfficeSpace(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveCommercialShowroom(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveCommercialShop(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveKiosk(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveResortsHotel(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveGuestHouse(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveGodownWareHouse(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveBusinessCentre(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveFactory(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveIndustrialBuilding(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblCommercialPropAd SaveNewCommercialProjects(tblCommercialPropAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertCommercialPropAd(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        #endregion

        #region Residential Property Ad

        private tblResidentialPropertyAd SaveResidentialPlotField(tblResidentialPropertyAd objResidentialProAd)
        {
            if (objResidentialProAd == null)            
                return null;

            ResidentialPlotFields cntlResidentialPlotFields = (panSpecialFeilds.FindControl("ctrlResidentialPlotFields")) as ResidentialPlotFields;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (cntlResidentialPlotFields.FindControl("PropertyTermsAndConditions1")) as PropertyTermsAndConditions;

            if(cntlResidentialPlotFields == null)
                return null;

            if ((int.Parse((SiteHelper.ReturnDropDownselectedItemValue(cntlResidentialPlotFields, "ddlConstAge")))) > 0)
                PropertyAgeID = byte.Parse(SiteHelper.ReturnDropDownselectedItemValue(cntlResidentialPlotFields, "ddlConstAge"));
            if ((int.Parse(SiteHelper.ReturnDropDownselectedItemValue(cntlResidentialPlotFields, "ddlOwnership")) > 0 ))
                OwnerTypeID = byte.Parse(SiteHelper.ReturnDropDownselectedItemValue(cntlResidentialPlotFields, "ddlOwnership"));

            objResidentialProAd.LandMark = SiteHelper.ReturnTextBoxValue(cntlResidentialPlotFields, "txtLandmarks");


            if(cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (cntlResidentialPlotFields.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;
            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }
            
            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertResidentialPlot(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID,CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblResidentialPropertyAd SaveResidentialHouseVilla(tblResidentialPropertyAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            ResidentialHouseVilla cntlResidentialHouseVilla = (panSpecialFeilds.FindControl("ctrlResidentialVilla")) as ResidentialHouseVilla;
            PropertyFeatures cntlPropertyFeatures = (cntlResidentialHouseVilla.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (cntlResidentialHouseVilla.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (cntlResidentialHouseVilla.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (cntlResidentialHouseVilla.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd,ref PropertyAgeID,ref OwnerTypeID,ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertResidentialPlot(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblResidentialPropertyAd SaveHolidayHome(tblResidentialPropertyAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            ResidentialHouseVilla cntlResidentialHouseVilla = (panSpecialFeilds.FindControl("ctrlResidentialVilla")) as ResidentialHouseVilla;
            PropertyFeatures cntlPropertyFeatures = (cntlResidentialHouseVilla.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (cntlResidentialHouseVilla.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (cntlResidentialHouseVilla.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (cntlResidentialHouseVilla.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertResidentialPlot(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }
        
        private tblResidentialPropertyAd SaveResidentialApartment(tblResidentialPropertyAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            ResidentialApartment ctrlResidentialApartment = (panSpecialFeilds.FindControl("ctrlResidentialApartment")) as ResidentialApartment;
            PropertyFeatures cntlPropertyFeatures = (ctrlResidentialApartment.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlResidentialApartment.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlResidentialApartment.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlResidentialApartment.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertResidentialPlot(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblResidentialPropertyAd SaveBuilderFloorApartment(tblResidentialPropertyAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            BuilderFloorApartment ctrlBuilderFloorApartment = (panSpecialFeilds.FindControl("ctrlBuilderFloorApartment")) as BuilderFloorApartment;
            PropertyFeatures cntlPropertyFeatures = (ctrlBuilderFloorApartment.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlBuilderFloorApartment.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlBuilderFloorApartment.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlBuilderFloorApartment.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertResidentialPlot(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblResidentialPropertyAd SaveStudioApartment(tblResidentialPropertyAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            StudioApartment ctrlStudioApartment = (panSpecialFeilds.FindControl("ctrlStudioApartment")) as StudioApartment;
            PropertyFeatures cntlPropertyFeatures = (ctrlStudioApartment.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlStudioApartment.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlStudioApartment.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlStudioApartment.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertResidentialPlot(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblResidentialPropertyAd SaveServicedApartment(tblResidentialPropertyAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            ServicedApartment ctrlServicedApartment = (panSpecialFeilds.FindControl("ctrlServicedApartment")) as ServicedApartment;
            PropertyFeatures cntlPropertyFeatures = (ctrlServicedApartment.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlServicedApartment.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlServicedApartment.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlServicedApartment.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertResidentialPlot(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblResidentialPropertyAd SavePayingGuest(tblResidentialPropertyAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            FarmHouse ctrlFarmHouse = (panSpecialFeilds.FindControl("ctrlFarmHouse")) as FarmHouse;
            PropertyFeatures cntlPropertyFeatures = (ctrlFarmHouse.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlFarmHouse.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlFarmHouse.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlFarmHouse.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertResidentialPlot(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        private tblResidentialPropertyAd SaveNewResidentialProjects(tblResidentialPropertyAd objResidentialProAd)
        {
            if (objResidentialProAd == null)
                return null;

            NewResidentialProjects ctrlNewResidentialProjects = (panSpecialFeilds.FindControl("ctrlNewResidentialProjects")) as NewResidentialProjects;
            PropertyFeatures cntlPropertyFeatures = (ctrlNewResidentialProjects.FindControl("cntPropertyFeatures")) as PropertyFeatures;
            PropertyTermsAndConditions cntlPropertyTermsAndConditions = (ctrlNewResidentialProjects.FindControl("cntPropertyTermsAndConditions")) as PropertyTermsAndConditions;
            Amenities cntAmenities = (ctrlNewResidentialProjects.FindControl("cntAmenities")) as Amenities;
            DistanceFromKeyLocations cntlDistanceFromKeyLocation = (ctrlNewResidentialProjects.FindControl("cntDistanceFromKeyLocations")) as DistanceFromKeyLocations;


            if (cntlPropertyFeatures != null)
            {
                objResidentialProAd = cntlPropertyFeatures.SaveData(objResidentialProAd, ref PropertyAgeID, ref OwnerTypeID, ref FurnishTypeID);
            }

            if (cntlPropertyTermsAndConditions != null)
            {
                objResidentialProAd = cntlPropertyTermsAndConditions.SaveData(objResidentialProAd);
            }

            if (cntAmenities != null)
            {
                objResidentialProAd = cntAmenities.SaveData(objResidentialProAd);
            }

            if (cntlDistanceFromKeyLocation != null)
            {
                objResidentialProAd = cntlDistanceFromKeyLocation.SaveData(objResidentialProAd);
            }

            if (objResidentialProAd != null)
            {
                ResidentialPlot.InsertResidentialPlot(objResidentialProAd, CityID, PropertyTypeID, PropertyAgeID, OwnerTypeID, FurnishTypeID, CurrentSession.CurrentUserID);
            }

            return objResidentialProAd;
        }

        #endregion

        #region Objects

        tblState ObjState;
        tblCity ObjCity;
        tblAreaUnits ObjAreaUnits;

        #endregion

        #endregion

    }
}