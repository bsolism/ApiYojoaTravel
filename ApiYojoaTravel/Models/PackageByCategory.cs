using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiYojoaTravel.Models
{
    public class PackageByCategory
    {
        [Key]
        public int Id { get; set; }
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package Package { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}