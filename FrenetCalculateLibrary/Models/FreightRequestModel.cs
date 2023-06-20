using System.ComponentModel.DataAnnotations;

namespace FrenetCalculate.Models
{
    public class FreightRequestModel
    {
        [Required]
        public string ShippingServiceCode { get; set; }
        [Required]
        public string DestinationZipCode { get; set; }
        public decimal PackageWeight { get; set; }
        public decimal PackageLength { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageWidth { get; set; }
    }
}
