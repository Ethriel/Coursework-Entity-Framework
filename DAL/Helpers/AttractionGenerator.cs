using DAL.Model;
using System.Linq;

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
