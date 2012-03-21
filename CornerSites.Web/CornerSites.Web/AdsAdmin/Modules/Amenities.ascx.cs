using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Data;

namespace CornerSites.Web.AdsAdmin.Modules
{
    public partial class Amenities : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public tblResidentialPropertyAd SaveData(tblResidentialPropertyAd objResidentialPropertyAd)
        {
            objResidentialPropertyAd.PipedGas = chkPipedGas.Checked;
            objResidentialPropertyAd.ROWaterSystem = chkROWaterSystem.Checked;
            objResidentialPropertyAd.InternetConnectivity = chkInternetConnectivity.Checked;
            objResidentialPropertyAd.ServantQuarters = chkServantQuarters.Checked;            
            objResidentialPropertyAd.VaastuCompliant = chkVaastuCompliant.Checked;
            objResidentialPropertyAd.InternetConnectivity = chkIntercomFacility.Checked;
            objResidentialPropertyAd.ReservedParking = chkParking.Checked;
            objResidentialPropertyAd.PowerBackUp = chkPowerBackUp.Checked;
            objResidentialPropertyAd.Gymnasium = chkGymnasium.Checked;
            objResidentialPropertyAd.Lift = chkLift.Checked;
            objResidentialPropertyAd.WasteDisposal = chkWasteDisposal.Checked;
            objResidentialPropertyAd.AirConditioned = chkAirConditioned.Checked;
            objResidentialPropertyAd.Security = chkSecurity.Checked;
            objResidentialPropertyAd.ServiceLift = chkServiceLift.Checked;
            objResidentialPropertyAd.VisitorParking = chkVisitorsParking.Checked;
            objResidentialPropertyAd.SwimmingPool = chkSwimmingPool.Checked;
            objResidentialPropertyAd.Park = chkPark.Checked;
            objResidentialPropertyAd.WaterStorage = chkWaterStorage.Checked;
            objResidentialPropertyAd.RainWaterHarvesting = chkRainWaterHarvesting.Checked;
            objResidentialPropertyAd.ClubHouse = chkClubHouse.Checked;
            objResidentialPropertyAd.BanquetHall = chkBanquetHall.Checked;
            objResidentialPropertyAd.DTHTelevisionFacility = chkDTHFacility.Checked;
            objResidentialPropertyAd.LaundryService = chkLaundryService.Checked;
            objResidentialPropertyAd.MaintenanceStaff = chkMaintenanceStaff.Checked;
            objResidentialPropertyAd.ConferenceRoom = chkConferenceRoom.Checked;
            objResidentialPropertyAd.FoodCourt = chkFoodCourt.Checked;
            objResidentialPropertyAd.BarLounge = chkBarLounge.Checked;

            return objResidentialPropertyAd;
        }

        public tblCommercialPropAd SaveData(tblCommercialPropAd objResidentialPropertyAd)
        {
            objResidentialPropertyAd.PipedGas = chkPipedGas.Checked;
            objResidentialPropertyAd.ROWaterSystem = chkROWaterSystem.Checked;
            objResidentialPropertyAd.InternetConnectivity = chkInternetConnectivity.Checked;
            objResidentialPropertyAd.ServantQuarters = chkServantQuarters.Checked;
            objResidentialPropertyAd.VaastuCompliant = chkVaastuCompliant.Checked;
            objResidentialPropertyAd.InternetConnectivity = chkIntercomFacility.Checked;
            objResidentialPropertyAd.ReservedParking = chkParking.Checked;
            objResidentialPropertyAd.PowerBackUp = chkPowerBackUp.Checked;
            objResidentialPropertyAd.Gymnasium = chkGymnasium.Checked;
            objResidentialPropertyAd.Lift = chkLift.Checked;
            objResidentialPropertyAd.WasteDisposal = chkWasteDisposal.Checked;
            objResidentialPropertyAd.AirConditioned = chkAirConditioned.Checked;
            objResidentialPropertyAd.Security = chkSecurity.Checked;
            objResidentialPropertyAd.ServiceLift = chkServiceLift.Checked;
            objResidentialPropertyAd.VisitorParking = chkVisitorsParking.Checked;
            objResidentialPropertyAd.SwimmingPool = chkSwimmingPool.Checked;
            objResidentialPropertyAd.Park = chkPark.Checked;
            objResidentialPropertyAd.WaterStorage = chkWaterStorage.Checked;
            objResidentialPropertyAd.RainWaterHarvesting = chkRainWaterHarvesting.Checked;
            objResidentialPropertyAd.ClubHouse = chkClubHouse.Checked;
            objResidentialPropertyAd.BanquetHall = chkBanquetHall.Checked;
            objResidentialPropertyAd.DTHTelevisionFacility = chkDTHFacility.Checked;
            objResidentialPropertyAd.LaundryService = chkLaundryService.Checked;
            objResidentialPropertyAd.MaintenanceStaff = chkMaintenanceStaff.Checked;
            objResidentialPropertyAd.ConferenceRoom = chkConferenceRoom.Checked;
            objResidentialPropertyAd.FoodCourt = chkFoodCourt.Checked;
            objResidentialPropertyAd.BarLounge = chkBarLounge.Checked;

            return objResidentialPropertyAd;
        }
    }
}