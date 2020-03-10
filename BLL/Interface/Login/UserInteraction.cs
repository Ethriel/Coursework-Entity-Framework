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
        public async Task<User> Register(Tourist tourist, LoginData loginData)
        {
            return await ValidateUser.ValidateRegisterAsync(tourist, loginData);
        }

        public async Task<User> SignIn(LoginData loginData)
        {
            return await ValidateUser.ValidateLoginAsync(loginData);
        }
        public async Task<string> GetUserRole(LoginData loginData)
        {
            return await ValidateUser.GetUserRoleAsync(loginData);
        }
    }
}
