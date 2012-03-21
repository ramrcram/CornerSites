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

namespace CornerSites.Lib.User
{
    public class User
    {
        private static String GetReadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CornerSiteConnectionString"].ToString();

        }
        public List<tblUser> Register(string strUserType, string strFullName, string strEmailID, string strPassword, 
            int iCity, string strMobile, string strLandLine, int iArea, string strRegAddress)
        {            
            var context = ObjectContextHelper.CurrentObjectContext;
            return context.CreateUser(strUserType, strFullName, strEmailID, short.Parse(iCity.ToString()), short.Parse(iArea.ToString()),
                                strMobile, strLandLine, false, strRegAddress, false, strPassword).ToList();
           // return new tblUser();

        }

        private void LogInsert(int iUserID, string strEmailID, string strPassword)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            tblLogs tbLog = new tblLogs();
            tbLog= tblLogs.CreatetblLogs(iUserID);
            tbLog.UserId = iUserID;
            tbLog.EmailID = strEmailID;
            tbLog.Secure = strPassword;
            context.AddTotblLogs(tbLog);
            context.SaveChanges();
        }
       
        public bool UserExists(string strEmail)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            var tab = from c in context.tblLogs
                      where c.EmailID == strEmail
                      select c;
            if (tab.ToArray().Length > 0)
                return true;
            return false;
        }

        public static void  Login(string strEmailID, string strPassword)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            var tbUser = (from l in context.tblLogs
                          join u in context.tblUser on l.UserId equals u.UserId
                          join ut in context.tblUserType on u.tblUserType.UserTypeID equals ut.UserTypeID
                          where u.EmailID == strEmailID && l.Secure == strPassword
                          select new
                          {
                              u.UserId,
                              ut.UserTypeID,
                              u.FullName,                              
                          }).ToList();
            if (tbUser.ToArray().Length > 0)
            {
                CurrentSession.CurrentUserID = tbUser[0].UserId;
                CurrentSession.CurrentUserType = tbUser[0].UserTypeID;
                CurrentSession.CurrentUserFullName = tbUser[0].FullName;
            }            
        }

        public static List<tblUser> GetUserInfo(int UserID)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            var UserInfo = from us in context.tblUser
                      where us.UserId == UserID
                      select us;

            return UserInfo.ToList();
        }

        public static DataSet GetSubscriptionDetails(int UserID)
        {
            DataSet dsRanges = new DataSet();

            SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {
                    cmd.CommandText = "Sp_GetSubscriptionDetails_UserID";
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@UserID", UserID);

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

        public static DataSet GetAdsDetails(int UserID)
        {
            DataSet dsRanges = new DataSet();

            SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {
                    cmd.CommandText = "Sp_GetAllAds_UserID";
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@UserID", UserID);

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
