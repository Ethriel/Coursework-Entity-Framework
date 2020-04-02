using DAL.Model;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
{
    class PictureConfiguration : EntityTypeConfiguration<Picture>
    {
        public PictureConfiguration()
        {
            HasMany(e => e.Attractions).WithMany(e => e.Pictures);
            HasMany(e => e.Hotels).WithMany(e => e.Pictures);
        }
    }
}
