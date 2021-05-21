using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.DomainService
{
    public class RegisterDomainService: IRegisterDomainService
    {

        private readonly ApiDataContext dc;

        public RegisterDomainService(ApiDataContext dc)
        {
            this.dc = dc;
        }

        public bool PostRegisterUser(RegisterReqDTO user)
        {
            bool requiredField = true;
            requiredField = (user.Email == null) ? false : true;
            if (requiredField == false)
            {
                return requiredField;
            }
            requiredField = (user.Name == null) ? false : true;
            if (requiredField == false)
            {
                return requiredField;
            }
            requiredField = (user.PhoneNumber == null) ? false : true;
            if (requiredField == false)
            {
                return requiredField;
            }
            requiredField = (user.Password == null) ? false : true;

            return requiredField;
        }

        public async Task<User> FindUserEquals(RegisterReqDTO user)
        {
            User Euser = null;
            Euser = await dc.User.FirstOrDefaultAsync(x => x.Email == user.Email);
            return Euser;
        }

    }
}
