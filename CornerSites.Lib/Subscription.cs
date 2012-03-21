using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.Configuration;
using CornerSites.Lib.Data;
using CornerSites.Lib.Utils;
using System.Data.SqlClient;

namespace CornerSites.Lib
{
    public class SubscriptionData
    {
        private static String GetReadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CornerSiteConnectionString"].ToString();

        }

        public static void GetSubscriptionByAdTypeID(int sAdTypeID, string Type)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            var AdvertisementType = (from va in context.vw_AdvertisementType
                          where va.AdTypeID == sAdTypeID 
                          select new
                          {
                              va.AdPriceinRS,
                              va.AdTypeID,
                              va.AdValidityDays,
                          }).ToList();
            if (AdvertisementType.ToArray().Length > 0)
            {
                CurrentSession.SubscriptionAmount = Convert.ToDecimal(AdvertisementType[0].AdPriceinRS);
                CurrentSession.AdDUserType = Type;
                CurrentSession.AddID = AdvertisementType[0].AdTypeID;
                CurrentSession.DtExpDate = DateTime.Today.AddDays(Convert.ToDouble(AdvertisementType[0].AdValidityDays));
            }
        }

        public static DataSet GetAvailableAdvertisementTypes()
        {
            DataSet dsRanges = new DataSet();

            SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {
                    cmd.CommandText = "sp_AvailableAdvertisementTypes";
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public static void InsPayDetails(int AdUserID, int @AmountinRS,
                string Notes, int PaymentTypeID, string PayPalTransactionID, string OtherTransactionID,
                string PromocodeUsed, string AdUsageType, int AdID, DateTime AdvExpiryDate)
        {
            //DataSet dsRanges = new DataSet();

            SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {   
                    cmd.CommandText = "sp_InsPayDetails";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdUserID", AdUserID);
                    cmd.Parameters.AddWithValue("@AmountinRS", AmountinRS);
                    cmd.Parameters.AddWithValue("@Notes", Notes);
                    cmd.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);
                    cmd.Parameters.AddWithValue("@PayPalTransactionID", PayPalTransactionID);
                    cmd.Parameters.AddWithValue("@OtherTransactionID", OtherTransactionID);
                    cmd.Parameters.AddWithValue("@PromocodeUsed", PromocodeUsed);
                    cmd.Parameters.AddWithValue("@AdUsageType", AdUsageType);
                    cmd.Parameters.AddWithValue("@AdID", AdID);
                    cmd.Parameters.AddWithValue("@AdvExpiryDate", AdvExpiryDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    Utils.SiteHelper.OpenConnection(con);
                    cmd.ExecuteScalar();
                    //adapter.Fill(dsRanges);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Utils.SiteHelper.CloseConnection(con);
                }
            }
            //return dsRanges;
        }
    }
}
