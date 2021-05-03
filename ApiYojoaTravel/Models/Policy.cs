using System.ComponentModel.DataAnnotations;

namespace ApiYojoaTravel.Models
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public string Description { get; set; }
        public int CancellationDeadlineHours { get; set; }
    }
}