using System;
using System.ComponentModel.DataAnnotations;

namespace ApiYojoaTravel.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InitTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }
}