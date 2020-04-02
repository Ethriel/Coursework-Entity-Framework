using DAL.Model;
using System.Data.Entity.ModelConfiguration;

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
