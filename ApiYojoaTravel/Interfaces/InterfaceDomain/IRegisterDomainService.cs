using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.Interfaces
{
    public interface IRegisterDomainService
    {
        bool PostRegisterUser(RegisterReqDTO user);
        Task<User> FindUserEquals(RegisterReqDTO user);
    }
}
