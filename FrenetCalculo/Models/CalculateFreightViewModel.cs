namespace FrenetCalculate.Models
{
    public class CalculateFreightViewModel
    {
        public string OriginZipCode { get; set; }
        public string DestinationZipCode { get; set; }
        public List<FreightQuote> FreightQuotes { get; set; }
    }
}
