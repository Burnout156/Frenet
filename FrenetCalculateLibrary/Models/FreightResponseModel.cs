﻿namespace FrenetCalculate.Models
{
        public class FreightResponseModel
        {
            public string ServiceDescription { get; set; }
            public string TrackingNumber { get; set; }
            public List<TrackingEvent> TrackingEvents { get; set; }
        }
}
