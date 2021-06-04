using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.DTO
{
    public class ActivityDTO
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InitTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public int ClientId { get; set; }
        public IFormFile File { get; set; }
    }
}
