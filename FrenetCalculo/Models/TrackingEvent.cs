using System.ComponentModel.DataAnnotations.Schema;

namespace FrenetCalculate.Models
{
    [Table("TrackingEvent")]
    public class TrackingEvent
    {
        public int Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public string EventDescription { get; set; }
        public string EventLocation { get; set; }
        public string EventType { get; set; }

        public int FreightQuoteId { get; set; }
        public FreightQuote FreightQuote { get; set; }
    }
}
