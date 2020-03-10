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
            GetTour().GetAwaiter().GetResult();
        }
        static async Task GetTour()
        {
            IAdminInterface<Tour> adminInterface = new AdminInterfaceTours();
            try
            {
                var t = await adminInterface.GetAsync(1);
                Console.WriteLine(t.TourName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
