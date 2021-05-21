using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Interfaces.InterfaceApplication;
using ApiYojoaTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.ApplicationServices
{
    public class RegisterApplication : IRegisterApplication
    {
        private readonly IDomainUnitOfWork duow;
        private readonly LoginResDTO loginResDTO;

        public RegisterApplication(IDomainUnitOfWork duow, LoginResDTO loginResDTO)
        {
            this.duow = duow;
            this.loginResDTO = loginResDTO;
        }

        public LoginResDTO Register(RegisterReqDTO registerReqDTO)
        {
            bool data = duow.RegisterDomainService.PostRegisterUser(registerReqDTO);
            var user = duow.RegisterDomainService.FindUserEquals(registerReqDTO);

            if (data == false)
            {
                return null;
            }

            User newUser = new User
            {
                Name = registerReqDTO.Name,
                Email = registerReqDTO.Email,
                Password = registerReqDTO.Password,
                PhoneNumber = registerReqDTO.PhoneNumber,
                UserName = registerReqDTO.Email
            };

            loginResDTO.UserName = newUser.UserName;
            loginResDTO.Token = duow.CreateToken.CreateJWT(newUser);

            return loginResDTO;
        }

        public User Convert(RegisterReqDTO registerReqDTO)
        {
            User newU = new User
            {
                Name = registerReqDTO.Name,
                Email = registerReqDTO.Email,
                Password = registerReqDTO.Password,
                PhoneNumber = registerReqDTO.PhoneNumber,
                UserName = registerReqDTO.Email
            };
            return newU;
        }
    }
}
