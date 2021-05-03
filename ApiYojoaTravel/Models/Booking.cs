using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiYojoaTravel.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package Package { get; set; }
        public int PeopleQuantity { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public double TotalAmount { get; set; }
        public double TotalTax { get; set; }
        public double TaxPercentage { get; set; }
    }
}