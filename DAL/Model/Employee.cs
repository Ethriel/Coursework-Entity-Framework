namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    [Serializable]
    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(30)]
        public string Position { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime EmploymentDate { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
        public Employee()
        {
            Tours = new HashSet<Tour>();
        }
    }
}
