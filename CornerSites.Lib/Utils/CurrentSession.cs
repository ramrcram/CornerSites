using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CornerSites.Lib.Utils
{
    public class CurrentSession
    {
        public static int CurrentUserID
        {
            get { return ((HttpContext.Current.Session["UserID"] == null) ? 0 : (int)HttpContext.Current.Session["UserID"]); }
            set { HttpContext.Current.Session["UserID"] = value; }
        }

        public static string CurrentUserType
        {
            get { return ((HttpContext.Current.Session["UserType"] == null) ? "" : HttpContext.Current.Session["UserType"].ToString()); }
            set { HttpContext.Current.Session["UserType"] = value; }
        }
        public static string CurrentUserFullName
        {
            get { return ((HttpContext.Current.Session["FullName"] == null) ? "" : HttpContext.Current.Session["FullName"].ToString()); }
            set { HttpContext.Current.Session["FullName"] = value; }
        }
        public static string SearchType
        {
            get { return ((HttpContext.Current.Session["SearchType"] == null) ? "" : HttpContext.Current.Session["SearchType"].ToString()); }
            set { HttpContext.Current.Session["SearchType"] = value; }
        }
        public static string ReturnUrl
        {
            get { return ((HttpContext.Current.Session["ReturnUrl"] == null) ? "" : HttpContext.Current.Session["ReturnUrl"].ToString()); }
            set { HttpContext.Current.Session["ReturnUrl"] = value; }
        }

        #region Subscription

        public static decimal SubscriptionAmount
        {
            get { return ((HttpContext.Current.Session["SubscriptionAmount"] == null) ? 0 : (decimal)HttpContext.Current.Session["SubscriptionAmount"]); }
            set { HttpContext.Current.Session["SubscriptionAmount"] = value; }
        }
        public static string Promocode
        {
            get { return ((HttpContext.Current.Session["Promocode"] == null) ? "" : HttpContext.Current.Session["Promocode"].ToString()); }
            set { HttpContext.Current.Session["Promocode"] = value; }
        }
        public static string AdDUserType
        {
            get { return ((HttpContext.Current.Session["AdDUserType"] == null) ? "" : HttpContext.Current.Session["AdDUserType"].ToString()); }
            set { HttpContext.Current.Session["AdDUserType"] = value; }
        }
        public static int AddID
        {
            get { return ((HttpContext.Current.Session["AddID"] == null) ? 0 : (int)HttpContext.Current.Session["AddID"]); }
            set { HttpContext.Current.Session["AddID"] = value; }
        }
        public static DateTime DtExpDate
        {
            get { return ((HttpContext.Current.Session["DtExpDate"] == null) ? DateTime.MinValue : (DateTime)HttpContext.Current.Session["DtExpDate"]); }
            set { HttpContext.Current.Session["DtExpDate"] = value; }
        }

        #endregion

        public static void ClearUserSession()
        {
            HttpContext.Current.Session.Remove("UserID");
            HttpContext.Current.Session.Remove("CurrentUserType");
            HttpContext.Current.Session.Remove("CurrentUserFullName");
        }
    }
}
