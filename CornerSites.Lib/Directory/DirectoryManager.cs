using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CornerSites.Lib.Data;
using System.Data.Linq.SqlClient;

namespace CornerSites.Lib.Directory
{
    public class DirectoryManager
    {
        public static List<tblState> GetAllStates()
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from prt in context.tblState
                        select prt;
            var StatesList = query.ToList();

            return StatesList;
        }

        public static List<tblState> GetAllStatesbyCountryID(int CountryID)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from s in context.tblState
                        where s.tblCountry.CountryID == CountryID
                        select s;
            var StatesList = query.ToList();

            return StatesList;
        }

        public static List<tblCity> GetAllCitysByStateID(int StateID)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from c in context.tblCity
                        where c.tblState.StateID == StateID
                        select c;
            var CityList = query.ToList();

            return CityList;
        }

        public static List<tblAreaUnits> GetAllAreaUnits(int CityID)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from a in context.tblAreaUnits                        
                        select a;
            var AreasunitsList = query.ToList();

            return AreasunitsList;
        }

        public static List<tblArea> GetAllAreas(int CityID)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from a in context.tblArea
                        select a;
            var AreasList = query.ToList();

            return AreasList;
        }

        public static List<tblCountry> GetAllCountry()
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from prt in context.tblCountry
                        select prt;
            var CountryList = query.ToList();
            return CountryList;
        }

        public static List<tblCity> GetCityAutoComplete(string q)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = (from c in context.tblCity
                        //where  SqlMethods.Like(c.CityName, "%a%" )
                        where c.CityName.StartsWith(q)
                        select c).Take(5) ;
            var CityList = query.ToList();

            return CityList;
        }

        public static List<tblArea> GetAreaAutoComplete(string q)
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = (from a in context.tblArea
                         //where  SqlMethods.Like(c.CityName, "%a%" )
                         where a.AreaName.StartsWith(q)
                         select a).Take(5);
            var AreaList = query.ToList();

            return AreaList;
        }
        
        public static List<tblCity> GetAllCitys()
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from c in context.tblCity
                        select c;
            var CityList = query.ToList();

            return CityList;
        }

        public static List<tblArea> GetAllAreas()
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from a in context.tblArea
                        select a;
            var AreasList = query.ToList();

            return AreasList;
        }
        public static List<tblArea> GetSpecificAreas(string cityID)
        {
            int iCityId = Convert.ToInt32(cityID);
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from a in context.tblArea
                        where a.tblCity.CityID == iCityId
                        select a;
            var AreasList = query.ToList();

            return AreasList;
        }
        public static List<tblAreaUnits> GetAreaUnits()
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from a in context.tblAreaUnits
                        select a;
            var AreasList = query.ToList();

            return AreasList;
        }

        public static tblPropertyType CheckType(int ProperyType)
        {
            if (ProperyType == 0)
                return null;

            var context = ObjectContextHelper.CurrentObjectContext;
            var query = from a in context.tblPropertyType 
                        where a.PropertyTypeID == ProperyType
                        select a;
            //var AreasList = query.ToList();

            tblPropertyType tblProperty = query.FirstOrDefault();
            return tblProperty;
            
        }
    }
}
