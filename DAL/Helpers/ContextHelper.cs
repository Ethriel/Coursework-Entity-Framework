using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Helpers
{
    public static class ContextHelper
    {
        static TravelAgencyContext db;

        public static TravelAgencyContext GetContext()
        {
            if (db == null)
            {
                db = new TravelAgencyContext();
            }
            return db;
        }
        public static void DisposeContext()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
    }
}
