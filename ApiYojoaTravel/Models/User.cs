using System.ComponentModel.DataAnnotations;

namespace ApiYojoaTravel.Models
{
    public class User
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}