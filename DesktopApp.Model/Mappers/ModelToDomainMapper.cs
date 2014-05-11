using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DesktopApp.Model.Mappers
{
    public static class ModelToDomainMapper
    {
        public static Account Map(LoginModel model)
        {
            return new Account
            {
                EmailAddress = model.EmailAddress,
                Password = model.Password
            };
        }
    }
}
