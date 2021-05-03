using System.ComponentModel.DataAnnotations;

namespace ApiYojoaTravel.Models
{
    public class Classification
    {
        [Key]
        public int ClassificationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}