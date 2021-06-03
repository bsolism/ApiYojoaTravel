using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.DomainService
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ActivityDTO, Activity>();
        }
    }
    
}
