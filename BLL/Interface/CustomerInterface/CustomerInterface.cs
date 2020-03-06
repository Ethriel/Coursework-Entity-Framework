using BLL.Interface.Interfaces;
using DAL.Interface.Customer;
using DAL.Interface.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.CustomerInterface
{
    public class CustomerInterface : ICustomerInterface<Tour>
    {
        public ITourCustomer<Tour> TourCustomer { get; set; }
        public CustomerInterface()
        {
            TourCustomer = new TourCustomer();
        }
        public void AddTour(int customerId, int tourId)
        {
            TourCustomer.AddTour(customerId, tourId);
        }

        public Tour FindTourByName(string name)
        {
            return TourCustomer.FindTourByName(name);
        }

        public ICollection<Tour> FindToursByCity(string name)
        {
            return TourCustomer.FindToursByCity(name);
        }

        public ICollection<Tour> FindToursByCountry(string name)
        {
            return TourCustomer.FindToursByCountry(name);
        }

        public ICollection<Tour> GetAllTours()
        {
            return TourCustomer.GetAllTours();
        }

        public ICollection<Tour> GetCustomerTour(int customerId)
        {
            return TourCustomer.GetCustomerTour(customerId);
        }

        public Tour GetTour(int id)
        {
            return TourCustomer.GetTour(id);
        }

        public ICollection<Tour> GetToursByDate(DateTime date)
        {
            return TourCustomer.GetToursByDate(date);
        }

        public ICollection<Tour> GetToursByDateRange(DateTime start, DateTime end)
        {
            return TourCustomer.GetToursByDateRange(start, end);
        }

        public void RemoveTour(int customerId, int tourId)
        {
            TourCustomer.RemoveTour(customerId, tourId);
        }
    }
}
