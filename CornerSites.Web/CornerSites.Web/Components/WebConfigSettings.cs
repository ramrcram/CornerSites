using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CornerSites.Web.Components
{
    public class WebConfigSettings
    {
        public static string SiteRoot
        {
            get { return ConfigurationManager.AppSettings["SiteRoot"].ToString(); }
        }
        public static string DefaultImageUrl
        {
            get { return ConfigurationManager.AppSettings["DefaultImageUrl"].ToString(); }
        }
        public static string HashKey
        {
            get { return ConfigurationManager.AppSettings["HashKey"].ToString(); }
        }
        public static string FreeAdds
        {
            get { return ConfigurationManager.AppSettings["FreeAdds"].ToString(); }
        }
        public static int PostReqExpiryDate
        {
            get { return int.Parse(ConfigurationManager.AppSettings["PostExpiryDate"].ToString()); }
        }
    }
}
