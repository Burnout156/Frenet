namespace FrenetCalculate.Models
{
    public class FreightQuote
    {
        public int Id { get; set; }
        public string OriginZipCode { get; set; }
        public string DestinationZipCode { get; set; }
        public decimal FreightPrice { get; set; }
        public DateTime QuoteDate { get; set; }

        public List<TrackingEvent> TrackingEvents { get; set; }
    }
}
