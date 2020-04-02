using DAL.Model;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
{
    public class AttractionConfiguration : EntityTypeConfiguration<Attraction>
    {
        public AttractionConfiguration()
        {
            HasMany(e => e.Hotels).WithMany(e => e.Attractions);
            HasMany(e => e.Tours).WithMany(e => e.Attractions);
        }
    }
}
