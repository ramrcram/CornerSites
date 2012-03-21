using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CornerSites.Lib.Data;
using System.Data.Objects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CornerSites.Lib.ResidentialPlot
{
    public class ResidentialPlot
    {
        private static String GetReadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CornerSiteConnectionString"].ToString();

        }
        public static List<tblPropertyAge> BindAllPropertyAge()
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from pra in context.tblPropertyAge
                        select pra;
            var PropertyAgeList = query.ToList();

            return PropertyAgeList;
        }

        public static List<tblOwnerType> BindAllOwnerType()
        {
           var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
           var query = from ow in context.tblOwnerType
                        select ow;
            var OwnerTypeList = query.ToList();

            return OwnerTypeList;
        }

        public static List<tblFurnishType> BindAllFurnishedType()
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from ft in context.tblFurnishType
                        select ft;
            var FurnishTypeList = query.ToList();

            return FurnishTypeList;
        }

        public static void InsertResidentialPlot(tblResidentialPropertyAd RePropertyAd, short CityID, byte PropertyTypeID,
            byte? PropertyAgeID, byte? OwnerTypeID, byte? FurnishTypeID,int UserId)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            if (RePropertyAd == null)
                return;

            RePropertyAd.tblCity = context.tblCity.Where(ct => ct.CityID == CityID).First();
            RePropertyAd.tblPropertyType = context.tblPropertyType.Where(pt => pt.PropertyTypeID == PropertyTypeID).First();
            RePropertyAd.tblUser = context.tblUser.Where(us => us.UserId == UserId).First();

            if (PropertyAgeID != null && PropertyAgeID != 0)
                RePropertyAd.tblPropertyAge = context.tblPropertyAge.Where(pa => pa.PropertyAgeID == PropertyAgeID).First();
            if (OwnerTypeID != null && OwnerTypeID != 0)
                RePropertyAd.tblOwnerType = context.tblOwnerType.Where(ow => ow.OwnerTypeID == OwnerTypeID).First();
            if (FurnishTypeID != null && FurnishTypeID != 0)
                RePropertyAd.tblFurnishType = context.tblFurnishType.Where(ft => ft.FurnishTypeID == FurnishTypeID).First();

            context.AddTotblResidentialPropertyAd(RePropertyAd);
            context.SaveChanges();
        }

        public static void InsertCommercialPropAd(tblCommercialPropAd RePropertyAd, short CityID, byte PropertyTypeID,
            byte? PropertyAgeID, byte? OwnerTypeID, byte? FurnishTypeID, int UserId)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            if (RePropertyAd == null)
                return;

            RePropertyAd.tblCity = context.tblCity.Where(ct => ct.CityID == CityID).First();
            RePropertyAd.tblPropertyType = context.tblPropertyType.Where(pt => pt.PropertyTypeID == PropertyTypeID).First();
            RePropertyAd.tblUser = context.tblUser.Where(us => us.UserId == UserId).First();

            if (PropertyAgeID != null && PropertyAgeID != 0)
                RePropertyAd.PropertyAgeID = PropertyAgeID;
            //if (OwnerTypeID != null && OwnerTypeID != 0)
            //    RePropertyAd. = context.tblOwnerType.Where(ow => ow.OwnerTypeID == OwnerTypeID).First();
            //if (FurnishTypeID != null && FurnishTypeID != 0)
            //    RePropertyAd.tblFurnishType = context.tblFurnishType.Where(ft => ft.FurnishTypeID == FurnishTypeID).First();

            context.AddTotblCommercialPropAd(RePropertyAd);
            context.SaveChanges();
        }


        public static int GetAddsCount(int sUserID, string sUserTypeID)
        {

            DataSet dsRanges = new DataSet();

            SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {
                    cmd.CommandText = "sp_UserFreeAdCount";
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@UserID", sUserID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    Utils.SiteHelper.OpenConnection(con);
                    adapter.Fill(dsRanges);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Utils.SiteHelper.CloseConnection(con);
                }
            }
            if (dsRanges.Tables.Count > 0 && dsRanges.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(dsRanges.Tables[0].Rows[0]["TotalYearlyAds"].ToString());
            }
            else
            {
                return 0;
            }

        }
        
        public static List<vw_CommercialPropertyAds> SearchResidential(
            byte propertyTypeID, 
            short areaID, 
            short cityID, 
            byte bedrooms, 
            string leaseType, 
            int maxBudget, 
            int minBudget, 
            string brokerUserTyPeID, 
            string builderUserTyPeID, 
            string individualUserTyPeID, 
            int userID)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            return context.SearchProperty(propertyTypeID, areaID, cityID, bedrooms,leaseType, maxBudget, minBudget, brokerUserTyPeID, builderUserTyPeID,individualUserTyPeID, userID).ToList();
        }

        public static DataSet GetSearchResidential( 
            int? propertyTypeID,
            short? areaID,
            short? cityID,
            byte? bedrooms,
            string leaseType,
            int? minBudget,
            int? maxBudget,
            string brokerUserTyPeID,
            string builderUserTyPeID,
            string individualUserTyPeID,
            int? userID)
        {
           DataSet dsRanges = new DataSet();

           SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {
                    cmd.CommandText = "sp_SearchProperty";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PropertyTypeID", propertyTypeID);
                    cmd.Parameters.AddWithValue("@AreaID", areaID);
                    cmd.Parameters.AddWithValue("@CityID", cityID);
                    cmd.Parameters.AddWithValue("@Bedrooms", bedrooms);
                    cmd.Parameters.AddWithValue("@LeaseType", leaseType);
                    cmd.Parameters.AddWithValue("@MinBudget", minBudget);
                    cmd.Parameters.AddWithValue("@MaxBudget", maxBudget);
                    cmd.Parameters.AddWithValue("@BrokerUserTyPeID", brokerUserTyPeID);
                    cmd.Parameters.AddWithValue("@BuilderUserTyPeID", builderUserTyPeID);
                    cmd.Parameters.AddWithValue("@IndividualUserTyPeID", individualUserTyPeID);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    Utils.SiteHelper.OpenConnection(con);
                    adapter.Fill(dsRanges);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Utils.SiteHelper.CloseConnection(con);
                }
            }
            return dsRanges;
        }
    }
}
