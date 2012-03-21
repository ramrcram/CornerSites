using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CornerSites.Web.Modules
{
    public partial class AddsSubscription : System.Web.UI.UserControl
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Anthem.Manager.Register(this);
            if (!IsPostBack)            
            {
                BindSubscription();
            }
        }

        protected void rptAlladvertisement_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RadioButton rdb = (RadioButton)e.Item.FindControl("rbtAdTypeShortName");
            HiddenField hfd = (HiddenField)e.Item.FindControl("hdfAdTypeID");
            if (rdb != null && hfd != null)
            {
                rdb.Attributes.Add("onclick", "javascript:return AddSubscription('" + hfd.Value + "','NormalAd');");
            }
        }

        protected void rptServicepack_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RadioButton rdb = (RadioButton)e.Item.FindControl("rbtServicePackName");
            HiddenField hfd = (HiddenField)e.Item.FindControl("hdfServiceID");
            if (rdb != null && hfd != null)
            {
                rdb.Attributes.Add("onclick", "javascript:return AddSubscription('" + hfd.Value + "','ServicePack');");
            }
        }

        protected void rptAdsPakage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RadioButton rdb = (RadioButton)e.Item.FindControl("rbtAdPackageName");
            HiddenField hfd = (HiddenField)e.Item.FindControl("hdfAdPackageID");
            if (rdb != null && hfd != null)
            {
                rdb.Attributes.Add("onclick", "javascript:return AddSubscription('" + hfd.Value + "','AdPack');");
            }
        }

        #endregion

        #region method

        private void BindSubscription()
        {
            DataSet ObjAvailableAdvertisementTypes = Lib.SubscriptionData.GetAvailableAdvertisementTypes();
            if (ObjAvailableAdvertisementTypes.Tables.Count > 0 && ObjAvailableAdvertisementTypes.Tables[0].Rows.Count > 0)
            {
                //rptAlladvertisement.DataSource = ObjAvailableAdvertisementTypes.Tables[0];
                //rptAlladvertisement.DataBind();

                cntIndividuals.BindData(ObjAvailableAdvertisementTypes.Tables[1]);

                cntBuilders.BindData(ObjAvailableAdvertisementTypes.Tables[2]);

                cntAgents.BindData(ObjAvailableAdvertisementTypes.Tables[3]);

                cntServicePack.BindData(ObjAvailableAdvertisementTypes.Tables[4]);
                cntAgentServicePack.BindData(ObjAvailableAdvertisementTypes.Tables[4]);
                cntBuildersServicepack.BindData(ObjAvailableAdvertisementTypes.Tables[4]);

                //rptServicepack.DataSource = ObjAvailableAdvertisementTypes.Tables[4];
                //rptServicepack.DataBind();


                //rptAdsPakage.DataSource = ObjAvailableAdvertisementTypes.Tables[5];
                //rptAdsPakage.DataBind();
            }
        }

        [Anthem.Method]
        public string GetSubscriptionByAdTypeID(string sAdTypeID,string Type)
        {
            string sReturn = string.Empty;
            if (!string.IsNullOrEmpty(sAdTypeID))
            {
                Lib.SubscriptionData.GetSubscriptionByAdTypeID(Convert.ToInt32(sAdTypeID), Type);
            }
            if (Lib.Utils.CurrentSession.CurrentUserID == 0)
            {
                sReturn = "false";
            }
            else 
            {
                sReturn = "PaySubscription.aspx";
            }
            return sReturn;
        }

        #endregion
         
    }
}