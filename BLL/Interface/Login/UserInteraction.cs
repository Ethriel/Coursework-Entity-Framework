using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Helpers;

namespace BLL.Interface.Login
{
    public class UserInteraction : IUserInteraction
    {
        public User Register(Tourist tourist, LoginData loginData)
        {
            return ValidateUser.ValidateRegister(tourist, loginData);
        }

        public Tourist SignIn(LoginData loginData)
        {
            return ValidateUser.ValidateLogin(loginData);
        }
    }
}
