using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.EntityClient;

namespace CornerSites.Lib.Data
{
    public static class ObjectContextHelper
    {

        public static CornerSitesEntities CurrentObjectContext
        {
            get { return new CornerSitesEntities(GetEntityConnectionString()); }
            //set { _ProfaneWords = value; }
        }
        public static tblCity City
        {
            get { return new tblCity(); }
            //set { _ProfaneWords = value; }
        }
        public static tblState State
        {
            get { return new tblState(); }
            //set { _ProfaneWords = value; }
        }
        public static tblAreaUnits AreaUnits
        {
            get { return new tblAreaUnits(); }
            //set { _ProfaneWords = value; }
        }

        private static string _connectionString;
        /// <summary>
        /// Gets a connection string
        /// </summary>
        /// <returns>Connection string</returns>
        public static string GetEntityConnectionString()
        {
            if (_connectionString == null)
            {
                var ecsbuilder = new EntityConnectionStringBuilder();
                ecsbuilder.Provider = "System.Data.SqlClient";
                ecsbuilder.ProviderConnectionString = ConfigurationManager.ConnectionStrings["CornerSiteConnectionString"].ToString();
                //ecsbuilder.Metadata = @"res://*/Data.NopModel.csdl|res://*/Data.NopModel.ssdl|res://*/Data.NopModel.msl";
                ecsbuilder.Metadata = @"res://*/Data.Data.csdl|res://*/Data.Data.ssdl|res://*/Data.Data.msl";
                _connectionString = ecsbuilder.ToString();
            }
            return _connectionString;
        }
    }
}
