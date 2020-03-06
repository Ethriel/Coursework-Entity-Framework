namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    [Serializable]
    public partial class Hotel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string HotelName { get; set; }

        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public Hotel()
        {
            Attractions = new HashSet<Attraction>();
            Pictures = new HashSet<Picture>();
        }
    }
}
