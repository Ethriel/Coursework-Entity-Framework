using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;
using DAL.Interface.Interfaces;
using DAL.Model;

namespace DAL.Interface.Admin
{
    public class CityAdmin : IEntityAdmin<City>
    {
        TravelAgencyContext tac;
        public CityAdmin()
        {
            tac = ContextHelper.GetContext();
        }

        public void Add(City entity)
        {
            var c = tac.Cities.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (c == null)
            {
                tac.Cities.Add(entity);
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("City is already at database!");
            }
        }

        public City Find(string name)
        {
            return tac.Cities.FirstOrDefault(x => x.CityName.ToLower().Equals(name.ToLower())) ?? throw new Exception("City was not found");
        }
        public City FindById(int id)
        {
            return tac.Cities.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new Exception("City was not found");
        }
        public City Get(int id)
        {
            return tac.Cities.Find(id) ?? throw new Exception("No city to show");
        }

        public ICollection<City> GetEntities()
        {
            return tac.Cities.ToList() ?? throw new Exception("No cities to show");
        }

        public void Remove(City entity)
        {
            Find(entity.CityName);
            tac.Cities.Remove(entity);
            tac.SaveChanges();
        }

        public void Update(int id, City newEntity)
        {
            var c = FindById(id);
            if (c != null)
            {
                c = newEntity;
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("City does not exist in database!");
            }
        }
        public void AddRange(ICollection<City> entities)
        {
            tac.Cities.AddRange(entities);
            tac.SaveChanges();
        }

        public void RemoveRange(ICollection<City> entities)
        {
            tac.Cities.RemoveRange(entities);
            tac.SaveChanges();
        }
    }
}
