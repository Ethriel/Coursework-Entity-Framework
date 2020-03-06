namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attraction")]
    [Serializable]
    public partial class Attraction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string AttractionName { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
        public Attraction()
        {
            Hotels = new HashSet<Hotel>();
            Pictures = new HashSet<Picture>();
            Tours = new HashSet<Tour>();
        }
    }
}
