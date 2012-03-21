using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CornerSites.Lib.Data;
using CornerSites.Lib.Directory;

namespace CornerSites.Web.Modules
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class LocationAutoComplete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                List<tblArea> ObjArea = DirectoryManager.GetAreaAutoComplete(context.Request.QueryString["q"]);
                if (ObjArea.Count > 0)
                {
                    foreach (tblArea Area in ObjArea)
                    {
                        context.Response.Write("<span>" + Area.AreaName + "</span><input type='hidden' value='" + Area.AreaID + "' /> " + Environment.NewLine);
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
