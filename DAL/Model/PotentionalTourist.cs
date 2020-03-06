namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Serializable]
    public partial class PotentionalTourist
    {
        public int Id { get; set; }

        public int? TourId { get; set; }

        public int? TouristId { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual Tourist Tourist { get; set; }
    }
}
