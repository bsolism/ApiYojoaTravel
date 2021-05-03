using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiYojoaTravel.Models
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey("PolicyId")]
        public Policy Policy { get; set; }
        public double Subtotal { get; set; }
    }
}