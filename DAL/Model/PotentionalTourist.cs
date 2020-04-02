using System;

namespace DAL.Model
{
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
