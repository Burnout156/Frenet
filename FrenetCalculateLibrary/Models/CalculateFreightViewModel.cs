namespace FrenetCalculate.Models
{
    public class CalculateFreightViewModel
    {
        public string OriginZipCode { get; set; }
        public string DestinationZipCode { get; set; }

        public string ServiceDescription { get; set; }
        public string TrackingNumber { get; set; }
        public List<TrackingEvent> TrackingEvents { get; set; }
        public List<FreightQuote> FreightQuotes { get; set; }
    }
}
