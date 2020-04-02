using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Interface.Interfaces
{
    public interface ICustomerInterface<T>
    {
        ITourCustomer<T> TourCustomer { get; set; }
        void AddTour(int customerId, int tourId);
        void RemoveTour(int customerId, int tourId);
        T GetTour(int id);
        ICollection<T> GetAllTours();
        ICollection<T> GetCustomerTour(int customerId);
        ICollection<T> GetToursByDate(DateTime date);
        ICollection<T> GetToursByDateRange(DateTime start, DateTime end);
        T FindTourByName(string name);
        ICollection<T> FindToursByCity(string name);
        ICollection<T> FindToursByCountry(string name);
    }
}
