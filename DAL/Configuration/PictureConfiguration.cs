using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
