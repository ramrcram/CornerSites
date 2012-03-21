using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CornerSites.Web
{
    public partial class QueryWindow : System.Web.UI.Page
    {
        private static String GetReadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CornerSiteConnectionString"].ToString();

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnquery_Click(object sender, EventArgs e)
        {
            DataSet ObjSearchResut = BindData(txtquery.Text);
            gridview.DataSource = ObjSearchResut;
            gridview.DataBind();
        }

        private DataSet BindData(string Query)
        { 
            DataSet dsRanges = new DataSet();

            SqlConnection con = new SqlConnection(GetReadConnectionString());

            using (SqlCommand cmd = new SqlCommand("", con))
            {
                try
                {
                    cmd.CommandText = "sp_QuetryExec";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Query", Query);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    CornerSites.Lib.Utils.SiteHelper.OpenConnection(con);
                    adapter.Fill(dsRanges);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    CornerSites.Lib.Utils.SiteHelper.CloseConnection(con);
                }
            }
            return dsRanges;
        }
    }
}
