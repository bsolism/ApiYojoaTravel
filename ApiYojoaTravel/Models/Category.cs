using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiYojoaTravel.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClassificationId { get; set; }
        [ForeignKey("ClassificationId")]
        public Classification Classification { get; set; }
    }
}