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

namespace CONSOLE_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerInterface<Tour> customerInterface = new CustomerToursInterface();
            IAdminInterface<Tour> adminInterface = new AdminInterfaceTours();
        }
    }
}
