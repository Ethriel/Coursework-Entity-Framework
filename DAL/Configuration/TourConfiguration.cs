using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class TourConfiguration : EntityTypeConfiguration<Tour>
    {
        public TourConfiguration()
        {
            HasMany(e => e.Cities).WithMany(e => e.Tours);
            HasMany(e => e.Countries).WithMany(e => e.Tours);
            HasMany(e => e.Employees).WithMany(e => e.Tours);
            HasMany(e => e.Tourists).WithMany(e => e.Tours);
        }
    }
}
