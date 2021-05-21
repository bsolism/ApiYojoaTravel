using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly LoginResDTO loginResDTO;

        public RegisterController(IUnitOfWork uow, LoginResDTO loginResDTO)
        {
            this.uow = uow;
            this.loginResDTO = loginResDTO;
        }

        [HttpPost]

        public async Task<IActionResult> Register([FromBody] RegisterReqDTO registerReqDTO)
        {
            var register = uow.RegisterApplication.Register(registerReqDTO);

            if (register == null)
            {
                return BadRequest();
            }
            var user = uow.RegisterApplication.Convert(registerReqDTO);
            await uow.UserApplication.AddUser(user);
            return Ok(register);
        }
    }
}
