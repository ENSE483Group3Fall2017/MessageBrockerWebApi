using System;

namespace ENSE483Group3Fall2017.PetTracking.Contracts.V1
{
    public class TrackingItem
    {
        public Guid Id { get; set; }

        public string BeaconId { get; set; }

        public decimal Proximity { get; set; }

        public DateTime Created { get; set; }
    }
}
