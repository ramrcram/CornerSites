using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using CornerSites.Lib.Directory;
using CornerSites.Lib.Data;

namespace CornerSites.Web.Modules
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CityAutoComplete : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                List<tblCity> ObjCity = DirectoryManager.GetCityAutoComplete(context.Request.QueryString["q"]);
                if (ObjCity.Count > 0)
                {
                    foreach (tblCity city in ObjCity)
                    {
                        context.Response.Write("<span>" + city.CityName + "</span><input type='hidden' value='"+ city.CityID +"' /> "  + Environment.NewLine);
                    }
                }
                else 
                {
                    context.Response.Write("No Result" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}
