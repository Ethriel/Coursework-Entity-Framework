using System;

namespace DAL.Model
{
    [Serializable]
    public partial class FutureTour
    {
        public int Id { get; set; }

        public int? TourId { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
