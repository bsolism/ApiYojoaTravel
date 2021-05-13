using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.ApplicationServices
{
    public class LoginApplicationServices
    {
        private readonly IUnitOfWork uow;
        private readonly LoginResDTO loginResDTO;
        private readonly CreateToken createToken;

        public LoginApplicationServices(IUnitOfWork uow, LoginResDTO loginResDTO, CreateToken createToken )
        {
            this.uow = uow;
            this.loginResDTO = loginResDTO;
            this.createToken = createToken;
        }
        
        public async Task<LoginResDTO> Login(LoginReqDTO loginReqDTO) 
        {
            var user = await uow.UserApplication.FindUser(loginReqDTO);

            if (user == null)
            {
                return null;
            }
            loginResDTO.UserName = user.UserName;
            loginResDTO.Token = createToken.CreateJWT(user);
            return loginResDTO;
        }
    }
}
