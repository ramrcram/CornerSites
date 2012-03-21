using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Utils;
using CornerSites.Lib.Data;

namespace CornerSites.Web.AdsAdmin.Modules
{
	public partial class DistanceFromKeyLocations : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        public tblResidentialPropertyAd SaveData(tblResidentialPropertyAd objResidentialPropertyAd)
        {
            objResidentialPropertyAd.Hospital = string.IsNullOrEmpty(txtHospital.Text) ? default(byte) : byte.Parse(txtHospital.Text);
            objResidentialPropertyAd.Market = string.IsNullOrEmpty(txtMall.Text) ? default(byte) : byte.Parse(txtMall.Text);
            objResidentialPropertyAd.Airport = string.IsNullOrEmpty(txtAirport.Text) ? default(byte) : byte.Parse(txtAirport.Text);
            objResidentialPropertyAd.RailwayStation = string.IsNullOrEmpty(txtRailway.Text) ? default(byte) : byte.Parse(txtRailway.Text);
            objResidentialPropertyAd.School= string.IsNullOrEmpty(txtSchool.Text) ? default(byte) : byte.Parse(txtSchool.Text);
            objResidentialPropertyAd.CityCenter = string.IsNullOrEmpty(txtTown.Text) ? default(byte) : byte.Parse(txtTown.Text);


            return objResidentialPropertyAd;
        }
        public tblCommercialPropAd SaveData(tblCommercialPropAd objResidentialPropertyAd)
        {
            objResidentialPropertyAd.Hospital = string.IsNullOrEmpty(txtHospital.Text) ? default(byte) : byte.Parse(txtHospital.Text);
            objResidentialPropertyAd.Market = string.IsNullOrEmpty(txtMall.Text) ? default(byte) : byte.Parse(txtMall.Text);
            objResidentialPropertyAd.Airport = string.IsNullOrEmpty(txtAirport.Text) ? default(byte) : byte.Parse(txtAirport.Text);
            objResidentialPropertyAd.RailwayStation = string.IsNullOrEmpty(txtRailway.Text) ? default(byte) : byte.Parse(txtRailway.Text);
            objResidentialPropertyAd.School = string.IsNullOrEmpty(txtSchool.Text) ? default(byte) : byte.Parse(txtSchool.Text);
            objResidentialPropertyAd.CityCenter = string.IsNullOrEmpty(txtTown.Text) ? default(byte) : byte.Parse(txtTown.Text);


            return objResidentialPropertyAd;
        }
	}
}