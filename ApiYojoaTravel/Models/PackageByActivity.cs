using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiYojoaTravel.Models
{
    public class PackageByActivity
    {
        [Key]
        public int Id { get; set; }
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package Package { get; set; }
        public int ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }
    }
}