using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CornerSites.Lib.Data;

namespace CornerSites.Lib.PropertyType
{
    public partial class PropertyType
    {
        public static tblPropertyType PropertyTypeProperties
        {
            get { return new tblPropertyType(); }
        }
        
        public static List<tblPropertyType> GetAllPropertyTypes()
        {
            var context = ObjectContextHelper.CurrentObjectContext;
            //CornerSitesEntities objEnt = new CornerSitesEntities();
            var query = from prt in context.tblPropertyType
                        select prt;
            var PropertyTypeList = query.ToList();

            return PropertyTypeList;
        }
    }
}
