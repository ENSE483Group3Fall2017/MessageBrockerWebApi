using System;
using System.Collections.Generic;

namespace ENSE483Group3Fall2017.PetTracking.Contracts.V1
{
    public class TrackingBatch
    {
        public Guid Id { get; set; }

        public string GpsCoordinates { get; set; }

        public DateTime FrameStart { get; set; }

        public DateTime FrameEnd { get; set; }

        public IEnumerable<TrackingItem> Items { get; set; }
    }
}
