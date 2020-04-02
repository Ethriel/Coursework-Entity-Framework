using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Tourist")]
    [Serializable]
    public partial class Tourist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tourist()
        {
            PotentionalTourists = new HashSet<PotentionalTourist>();
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public int? UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PotentionalTourist> PotentionalTourists { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
