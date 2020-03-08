using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Model;
using DAL.Helpers;

namespace DAL.Interface.Customer
{
    public class TourCustomer : ITourCustomer<Tour>
    {
        TravelAgencyContext tac;
        public TourCustomer()
        {
            tac = ContextHelper.GetContext();
        }
        public void AddTour(int customerId, int tourId)
        {
            var c = tac.Tourists.FirstOrDefault(x => x.Id.Equals(customerId));
            var t = tac.Tours.FirstOrDefault(x => x.Id.Equals(tourId));
            if (c == null)
            {
                throw new Exception("Invalid tourist!");
            }
            else
            {
                if (c.Tours.Contains(t))
                {
                    throw new Exception($"{c.FirstName + " " + c.FirstName}! You already have this tour in yout list! Check it");
                }
                else
                {
                    c.Tours.Add(t);
                    tac.SaveChanges();
                }
            }
        }

        public ICollection<Tour> GetAllTours()
        {
            var tours = tac.Tours.Where(x => x.IsDeleted.Equals(false)).ToList();
            return tours.Count > 0 ? tours : throw new Exception("No tours to show");
        }

        public ICollection<Tour> GetCustomerTour(int customerId)
        {
            var c = tac.Tourists.FirstOrDefault(x => x.Id.Equals(customerId));
            if (c == null)
            {
                throw new Exception("Invalid tourist!");
            }
            else
            {
                return c.Tours.ToList() ?? throw new Exception("No tours to show");
            }
        }

        public Tour GetTour(int id)
        {
            return tac.Tours.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new Exception("No such tour in database");
        }

        public ICollection<Tour> GetToursByDate(DateTime date)
        {
            var tours = tac.Tours.Where(x => x.StartDate <= date && x.EndDate >= date).ToList();
            return tours.Count > 0 ? tours : throw new Exception($"No tours for date {date.ToShortDateString()}");
        }

        public ICollection<Tour> GetToursByDateRange(DateTime start, DateTime end)
        {
            var tours = tac.Tours.Where(x => x.StartDate <= start && x.EndDate >= end).ToList();
            return tours.Count > 0 ? tours : throw new Exception($"No tours from {start.ToShortDateString()} to {end.ToShortDateString()}");
        }

        public void RemoveTour(int customerId, int tourId)
        {
            var c = tac.Tourists.FirstOrDefault(x => x.Id.Equals(customerId));
            if (c == null)
            {
                throw new Exception("Invalid tourist!");
            }
            else
            {
                var t = c.Tours.FirstOrDefault(x => x.Id.Equals(tourId));
                if (t == null)
                {
                    throw new Exception("No such tour!");
                }
                else
                {
                    c.Tours.Remove(t);
                    tac.SaveChanges();
                }
            }
        }
        public Tour FindTourByName(string name)
        {
            return tac.Tours.FirstOrDefault(x => x.TourName.ToLower().Equals(name.ToLower())) ?? throw new Exception($"No tour with name {name}");
        }

        public ICollection<Tour> FindToursByCity(string name)
        {
            var cities = tac.Cities.Where(x => x.CityName.ToLower().Equals(name.ToLower()));
            var toursList = cities.Select(x => x.Tours).ToList();
            var res = new List<Tour>();
            foreach (var tours in toursList)
            {
                foreach (var t in tours)
                {
                    res.Add(t);
                }
            }
            return res.Count > 0 ? res : throw new Exception($"No tours for city {name}");
        }

        public ICollection<Tour> FindToursByCountry(string name)
        {
            var countries = tac.Countries.Where(x => x.CountryName.ToLower().Equals(name.ToLower()));
            var toursList = countries.Select(x => x.Tours).ToList();
            var res = new List<Tour>();
            foreach (var tours in toursList)
            {
                foreach (var t in tours)
                {
                    res.Add(t);
                }
            }
            return res.Count > 0 ? res : throw new Exception($"No tours for country {name}");
        }
    }
}
