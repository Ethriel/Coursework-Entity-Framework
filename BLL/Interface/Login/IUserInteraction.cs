using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Login
{
    public interface IUserInteraction
    {
        User Register(Tourist tourist, LoginData loginData);
        Tourist SignIn(LoginData loginData);
    }
}
