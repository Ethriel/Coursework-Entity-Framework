using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;

namespace DAL.Helpers
{
    public static class AttractionGenerator
    {
        public static Attraction GetFirstAttraction()
        {
            TravelAgencyContext db = ContextHelper.GetContext();
            db.Configuration.LazyLoadingEnabled = false;
            return db.Attractions.Include("Hotels").Include("Pictures").Include("Pictures").FirstOrDefault();
        }
    }
}
