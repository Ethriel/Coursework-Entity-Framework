namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Serializable]
    public partial class PastTour
    {
        public int Id { get; set; }

        public int? TourId { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
