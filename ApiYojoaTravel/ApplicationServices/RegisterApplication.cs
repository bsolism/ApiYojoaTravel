using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Helper;
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
            var hash = HashHelper.Hash(registerReqDTO.Password);
            
            User newUser = new User
            {
                Name = registerReqDTO.Name,
                Email = registerReqDTO.Email,
                Password = hash.Password,
                PhoneNumber = registerReqDTO.PhoneNumber,
                UserName = registerReqDTO.Email,
                Sal=hash.Salt
            };

            loginResDTO.UserName = newUser.UserName;
            loginResDTO.Token = duow.CreateToken.CreateJWT(newUser);

            return loginResDTO;
        }

        public User Convert(RegisterReqDTO registerReqDTO)
        {
            var hash = HashHelper.Hash(registerReqDTO.Password);
            User newU = new User
            {
                Name = registerReqDTO.Name,
                Email = registerReqDTO.Email,
                Password = hash.Password,
                PhoneNumber = registerReqDTO.PhoneNumber,
                UserName = registerReqDTO.Email,
                Sal = hash.Salt
            };
            return newU;
        }
    }
}
