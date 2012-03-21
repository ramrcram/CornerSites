using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CornerSites.Lib.Data;
using System.Data.Objects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CornerSites.Lib.Search
{
    public class Search
    {
        private static String GetReadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CornerSiteConnectionString"].ToString();

        }

        public static DataSet GetSearchAgents(short? areaID,short? cityID)
        {
            DataSet dsRanges = new DataSet();

            SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {
                    cmd.CommandText = "sp_SearchAgents";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AreaID", areaID);
                    cmd.Parameters.AddWithValue("@CityID", cityID);                    

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

        public static DataSet GetSearchBuilder(short? cityID, char BasedOrOperatingFlag)
        {
            DataSet dsRanges = new DataSet();

            SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {
                    cmd.CommandText = "sp_SearchBuilders";
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@CityID", cityID);
                    cmd.Parameters.AddWithValue("@BasedorOperatingInFalg", BasedOrOperatingFlag);

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

        public static DataSet GetSearchProject(short? cityID, short? AreaID, short? ProjectTypeID)
        {
            DataSet dsRanges = new DataSet();

            SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {
                    cmd.CommandText = "sp_SearchProjects";
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@AreaID", AreaID);
                    cmd.Parameters.AddWithValue("@CityID", cityID);
                    cmd.Parameters.AddWithValue("@ProjectTypeID", ProjectTypeID);

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

        public static void PostRequirement_C(int? Budgetfrom, int? BudgetTo, string Discription,
            int Uid,short Aid,byte prID,int PlotArea ,byte PlotAreaUnit,int BuildArea,byte BuildAreaUnit,int ExpDate  )
        {
            //TODO
            var context = ObjectContextHelper.CurrentObjectContext;
            if (context == null)
                return;
            tblCommercialRequirement objcommercial = new tblCommercialRequirement();
            objcommercial.tblPropertyType = context.tblPropertyType.Where(pt => pt.PropertyTypeID == prID).First();
            objcommercial.MaxBudget = Budgetfrom;
            objcommercial.MinBudget = BudgetTo;
            objcommercial.ReqDescription = Discription;
            objcommercial.PlotArea = PlotArea;
            objcommercial.PlotUnitID = PlotAreaUnit;
            objcommercial.BuildArea = BuildArea;
            objcommercial.BuildUnitID = BuildAreaUnit;
            objcommercial.tblUser = context.tblUser.Where(us => us.UserId == Uid).First();
            objcommercial.AllowedContactsUserType = null;
            objcommercial.tblArea = context.tblArea.Where(ar => ar.AreaID == Aid).First();
            objcommercial.LeaseType = "I";
            objcommercial.ExpiryDate = DateTime.Today.AddDays(ExpDate);

            context.AddTotblCommercialRequirement(objcommercial);
            context.SaveChanges();

        }

        public static void PostRequirement_R(int? Budgetfrom, int? BudgetTo, string Discription,
           int Uid, short Aid, byte prID, int PlotArea, byte PlotAreaUnit, int BuildArea, byte BuildAreaUnit, int ExpDate)
        {
            //TODO
            var context = ObjectContextHelper.CurrentObjectContext;
            if (context == null)
                return;
            tblResidentialRequirement objcommercial = new tblResidentialRequirement();
            objcommercial.tblPropertyType = context.tblPropertyType.Where(pt => pt.PropertyTypeID == prID).First();
            objcommercial.MaxBudget = Budgetfrom;
            objcommercial.MinBudget = BudgetTo;
            objcommercial.ReqDescription = Discription;
            objcommercial.PlotArea = PlotArea;
            objcommercial.PlotUnitID = PlotAreaUnit;
            objcommercial.BuildArea = BuildArea;
            objcommercial.BuildUnitID = BuildAreaUnit;
            objcommercial.tblUser = context.tblUser.Where(us => us.UserId == Uid).First();
            objcommercial.AllowedContactsUserType = null;
            objcommercial.tblArea = context.tblArea.Where(ar => ar.AreaID == Aid).First();
            objcommercial.LeaseType = "I";
            objcommercial.ExpiryDate = DateTime.Today.AddDays(ExpDate);

            context.AddTotblResidentialRequirement(objcommercial);
            context.SaveChanges();

        }

        public static void PostRequirement(tblCommercialRequirement objcommercial)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            if (context == null)
                return;           

            context.AddTotblCommercialRequirement(objcommercial);
            context.SaveChanges();

        }

        public static DataSet GetSearchRequirement(
            int? propertyTypeID,
            short? areaID,
            short? cityID,
            byte? bedrooms,
            string leaseType,
            int? Budget,
            //int? maxBudget,
            //int? minBudget,
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
                    cmd.CommandText = "sp_SearchRequirements";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PropertyTypeID", propertyTypeID);
                    cmd.Parameters.AddWithValue("@AreaID", areaID);
                    cmd.Parameters.AddWithValue("@CityID", cityID);
                    cmd.Parameters.AddWithValue("@Bedrooms", bedrooms);
                    cmd.Parameters.AddWithValue("@LeaseType", leaseType);
                    cmd.Parameters.AddWithValue("Budget", Budget);
                    //cmd.Parameters.AddWithValue("@MinBudget", minBudget);
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