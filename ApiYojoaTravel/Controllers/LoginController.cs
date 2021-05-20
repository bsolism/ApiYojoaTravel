using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiYojoaTravel.Controllers
{
    public class LoginController:BaseController
    {
        private readonly IUnitOfWork uow;

        public LoginController(IUnitOfWork uow )
        {
            this.uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginReqDTO loginReqDTO)
        {
            var login = await uow.LoginApplication.Login(loginReqDTO);
            return Ok(login);
        }
    }
}
