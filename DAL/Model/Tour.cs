using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Tour")]
    [Serializable]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            FutureTours = new HashSet<FutureTour>();
            PastTours = new HashSet<PastTour>();
            PotentionalTourists = new HashSet<PotentionalTourist>();
            Attractions = new HashSet<Attraction>();
            Cities = new HashSet<City>();
            Countries = new HashSet<Country>();
            Employees = new HashSet<Employee>();
            Tourists = new HashSet<Tourist>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string TourName { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int MaxTourists { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FutureTour> FutureTours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PastTour> PastTours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PotentionalTourist> PotentionalTourists { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Tourist> Tourists { get; set; }
    }
}
