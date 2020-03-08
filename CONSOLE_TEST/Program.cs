using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;
using BLL.Interface.Interfaces;
using BLL.Interface.CustomerInterface;
using BLL.Interface.AdminInterface;
using DAL.Model;
using BLL.Interface.Login;

namespace CONSOLE_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerInterface<Tour> customerInterface = new CustomerToursInterface();
            IAdminInterface<Tour> adminInterface = new AdminInterfaceTours();
            IUserInteraction userInteraction = new UserInteraction();
            var t = new Tourist()
            {
                BirthDate = new DateTime(1989, 10, 12),
                Email = "albertsnow@gmail.com",
                FirstName = "Albert",
                SecondName = "Snow",
                Phone = "7890321456"
            };
            var loginData = new LoginData() { Login = t.Email, Password = "1" };
            //var u = userInteraction.Register(t, loginData);
            var tt = userInteraction.SignIn(loginData);
        }
    }
}
