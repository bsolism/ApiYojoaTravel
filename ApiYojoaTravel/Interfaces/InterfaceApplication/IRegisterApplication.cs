using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.Interfaces.InterfaceApplication
{
    public interface IRegisterApplication
    {
        LoginResDTO Register(RegisterReqDTO registerReqDTO);

        User Convert(RegisterReqDTO registerReqDTO);
    }
}
