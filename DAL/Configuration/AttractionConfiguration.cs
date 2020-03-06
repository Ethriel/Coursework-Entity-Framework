using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
