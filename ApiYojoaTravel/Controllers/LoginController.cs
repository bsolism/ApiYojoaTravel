using ApiYojoaTravel.ApplicationServices;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.Controllers
{
    public class LoginController:BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly LoginResDTO loginResDTO;
        private readonly LoginApplicationServices loginApplicationServices;

        public LoginController(IUnitOfWork uow, LoginResDTO loginResDTO, LoginApplicationServices loginApplicationServices )
        {
            this.uow = uow;
            this.loginResDTO = loginResDTO;
            this.loginApplicationServices = loginApplicationServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDTO loginReqDTO)
        {
            var login = await loginApplicationServices.Login(loginReqDTO);
            return Ok(login);
        }
    }
}
