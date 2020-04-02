using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Picture")]
    [Serializable]
    public partial class Picture
    {
        public int Id { get; set; }

        [Column("Picture")]
        [Required]
        [StringLength(50)]
        public string Picture1 { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
        public Picture()
        {
            Hotels = new HashSet<Hotel>();
            Attractions = new HashSet<Attraction>();
        }
    }
}
