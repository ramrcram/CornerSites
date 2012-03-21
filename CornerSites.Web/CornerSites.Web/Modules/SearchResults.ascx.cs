using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CornerSites.Lib.Data;
using CornerSites.Lib.ResidentialPlot;
using CornerSites.Lib.Utils;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace CornerSites.Web.Modules
{
    public partial class SearchResults : System.Web.UI.UserControl
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Anthem.Manager.Register(this);
            if (!IsPostBack)
            {
                Hashtable ObjSearch = new Hashtable();
                if (SiteHelper.SearchParams != null)
                {
                    ObjSearch = (System.Collections.Hashtable)SiteHelper.SearchParams;
                }
                BindBySearch(ObjSearch);
                HttpContext.Current.Session.Remove("ReturnUrl");
            }            
        }

        protected void grdSearchAds_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "searchresult")
            {
                if (CurrentSession.CurrentUserID == 0)
                {
                    Page.RegisterStartupScript("LightBox", "<script language=JavaScript>ShowPopupFromCodeBehind();</script>");
                    return;
                   
                }
                else if (e.CommandName == "viewcontact")
                {
                    System.Web.UI.HtmlControls.HtmlContainerControl htmlDiv = e.Item.FindControl("divContact") as System.Web.UI.HtmlControls.HtmlContainerControl;
                    htmlDiv.Visible = true;
                }
                else if (e.CommandName == "viewcontact")
                {
                    System.Web.UI.HtmlControls.HtmlContainerControl htmlDiv = e.Item.FindControl("divContact") as System.Web.UI.HtmlControls.HtmlContainerControl;
                    htmlDiv.Visible = true;
                }
            }
        }

        protected void grdSearchAds_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            HtmlContainerControl htmlDiv = e.Item.FindControl("divContact") as System.Web.UI.HtmlControls.HtmlContainerControl;
            htmlDiv.Visible = false;

            HtmlAnchor btnViewMore = ((HtmlAnchor)e.Item.FindControl("btnViewMore"));
            btnViewMore.HRef = "#";
             
        }

        #endregion

        #region Method

        private void BindBySearch(Hashtable ObjSearch)
        {
            DataSet Ds = new DataSet();
            string xsltpath = string.Empty;
            switch (CurrentSession.SearchType)
            {
                case "SRes":
                    Ds = BindSearchResidentialResult(SiteHelper.GetByteSearchParams(ObjSearch, "Property"), SiteHelper.GetShortSearchParams(ObjSearch, "Location"),
                           SiteHelper.GetShortSearchParams(ObjSearch, "City"), SiteHelper.GetByteSearchParams(ObjSearch, "Bedroom"),
                           SiteHelper.GetStringSearchParams(ObjSearch, "LeaseType"), SiteHelper.GetIntSearchParams(ObjSearch, "BudgetFrom"),
                           SiteHelper.GetIntSearchParams(ObjSearch, "BudgetTo") ,SiteHelper.GetStringSearchParams(ObjSearch, "Individual"),
                           SiteHelper.GetStringSearchParams(ObjSearch, "Dealers"), SiteHelper.GetStringSearchParams(ObjSearch, "Builders"),
                           SiteHelper.GetIntSearchParams(ObjSearch, "User"));
                    xsltpath = Server.MapPath("~/Xslts/SearchResidential.xslt");
                    ActiveControl(0);
                    break;
                case "SReq":
                    Ds = BindRequirementResult(SiteHelper.GetByteSearchParams(ObjSearch, "Property"), SiteHelper.GetShortSearchParams(ObjSearch, "Location"),
                           SiteHelper.GetShortSearchParams(ObjSearch, "City"), SiteHelper.GetByteSearchParams(ObjSearch, "Bedroom"),
                           SiteHelper.GetStringSearchParams(ObjSearch, "LeaseType"), SiteHelper.GetIntSearchParams(ObjSearch, "Budget")
                           //SiteHelper.GetIntSearchParams(ObjSearch, "BudgetTo")
                           , SiteHelper.GetStringSearchParams(ObjSearch, "Individual"),
                           SiteHelper.GetStringSearchParams(ObjSearch, "Dealers"), SiteHelper.GetStringSearchParams(ObjSearch, "Builders"),
                           SiteHelper.GetIntSearchParams(ObjSearch, "User"));
                    xsltpath = Server.MapPath("~/Xslts/SearchResidential.xslt");
                    ActiveControl(1);
                    break;
                case "SBui":
                    Ds = BindSearchBuilder(SiteHelper.GetShortSearchParams(ObjSearch, "CityID"),
                        SiteHelper.GetCharSearchParams(ObjSearch, "SearchBuilder"));
                    xsltpath = Server.MapPath("~/Xslts/SearchBuilder.xslt");
                    ActiveControl(2);
                    break;
                case "SAg":
                    Ds = BindSearchAgent(SiteHelper.GetShortSearchParams(ObjSearch, "CityID"),
                        SiteHelper.GetShortSearchParams(ObjSearch, "Location"));
                    xsltpath = Server.MapPath("~/Xslts/SearchAgennt.xslt");
                    ActiveControl(3);
                    break;
                case "SPr":
                    Ds = BindSearchProjects(SiteHelper.GetShortSearchParams(ObjSearch, "CityID"),
                        SiteHelper.GetShortSearchParams(ObjSearch, "Location"), SiteHelper.GetShortSearchParams(ObjSearch, "PropertyType"));
                    xsltpath = Server.MapPath("~/Xslts/SearchProject.xslt");
                    ActiveControl(4);
                    break;

            }

            if(! string.IsNullOrEmpty(xsltpath))
                BindData(Ds.GetXml(), xsltpath);
        }

        public DataSet BindSearchResidentialResult(byte? propertyTypeID,
            short? areaID,
            short? cityID,
            byte? bedrooms,
            string leaseType,
            int? MinBudget,
            int? MaxBudget,
            string brokerUserTyPeID,
            string builderUserTyPeID,
            string individualUserTyPeID,
            int? userID)
        {
                DataSet ObjCommercialPropertyAds = ResidentialPlot.GetSearchResidential(propertyTypeID, areaID, cityID,
                                                            bedrooms, leaseType, MinBudget,MaxBudget, brokerUserTyPeID,
                                                            builderUserTyPeID, individualUserTyPeID, userID);


            return ObjCommercialPropertyAds;
        }

        public DataSet BindRequirementResult(byte? propertyTypeID,
            short? areaID,
            short? cityID,
            byte? bedrooms,
            string leaseType,
            int? Budget,
            //int? minBudget,
            //int? maxBudget,
            string brokerUserTyPeID,
            string builderUserTyPeID,
            string individualUserTyPeID,
            int? userID)
        {
            DataSet ObjCommercialPropertyAds = Lib.Search.Search.GetSearchRequirement(propertyTypeID, areaID, cityID,
                                                        bedrooms, leaseType, Budget
                                                        //, minBudget
                                                        , brokerUserTyPeID,
                                                        builderUserTyPeID, individualUserTyPeID, userID);


            return ObjCommercialPropertyAds;
        }

        private DataSet BindSearchBuilder(short? cityID, char BasedOrOperatingFlag)
        {
            DataSet ObjSearchResut = Lib.Search.Search.GetSearchBuilder(cityID, BasedOrOperatingFlag);
            return ObjSearchResut;
        }

        private DataSet BindSearchAgent(short? cityID, short? Location)
        {
            DataSet ObjSearchResut = Lib.Search.Search.GetSearchAgents(cityID, Location);
            return ObjSearchResut;
        }

        private DataSet BindSearchProjects(short? cityID, short? AreaID, short? ProjectTypeID)
        {
            DataSet ObjSearchResut = Lib.Search.Search.GetSearchProject(cityID, AreaID, ProjectTypeID);
            return ObjSearchResut;
        }

        private void BindData(string xml, string filePath)
        {
            string Result = SiteHelper.XsltTransform(xml, filePath);
            Control ctrl = Page.ParseControl(Result);
            panResult.Controls.Add(ctrl);
        }

        private void ActiveControl(int Index)
        { 
            AjaxControlToolkit.TabContainer tb = (AjaxControlToolkit.TabContainer)this.Page.Master.FindControl("cntSearch").FindControl("tbcSubscription");
            if (tb != null)
                tb.ActiveTabIndex = Index;
        }

        [Anthem.Method]
        public string IsLogin()
        {
            if (CurrentSession.CurrentUserID > 0)
                return "1";
            else
            {
                
                CurrentSession.ReturnUrl = Components.WebConfigSettings.SiteRoot +
                    CurrentSession.SearchType == "SReq" ? "SearchResults.aspx?Search=Req" : "SearchResults.aspx";
                return "0";
            }
        }
        [Anthem.Method]
        public string sendEmail()
        {
            FileStream stream = new FileStream(Server.MapPath("XML/mail.xml"), FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();
            XPathNodeIterator node = navigator.Select("xml/entry");
            stream.Close();
            return string.Empty;
        }

        #endregion


    }
}