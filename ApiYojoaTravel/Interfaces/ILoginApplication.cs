using ApiYojoaTravel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.Interfaces
{
    interface ILoginApplication
    {
        Task<LoginResDTO> Login(LoginReqDTO loginReqDTO);
    }
}
