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
    public class CountryAdmin : IEntityAdmin<Country>
    {
        TravelAgencyContext tac;
        public CountryAdmin()
        {
            tac = ContextHelper.GetContext();
        }
        public void Add(Country entity)
        {
            var c = tac.Countries.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (c == null)
            {
                tac.Countries.Add(entity);
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Country is already at database!");
            }
        }

        public Country Find(string name)
        {
            return tac.Countries.FirstOrDefault(x => x.CountryName.ToLower().Equals(name.ToLower())) ?? throw new Exception("Country was not found");
        }
        public Country FindById(int id)
        {
            return tac.Countries.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new Exception("Country was not found");
        }
        public Country Get(int id)
        {
            return tac.Countries.FirstOrDefault(x=>x.Id.Equals(id)) ?? throw new Exception("No country to show");
        }

        public ICollection<Country> GetEntities()
        {
            var countries = tac.Countries.ToList();
            return countries.Count > 0 ? countries : throw new Exception("No countries to show");
        }

        public void Remove(Country entity)
        {
            Find(entity.CountryName);
            tac.Countries.Remove(entity);
            tac.SaveChanges();
        }

        public void Update(int id, Country newEntity)
        {
            var c = FindById(id);
            if (c != null)
            {
                c = newEntity;
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Country does not exist in database!");
            }
        }
        public void AddRange(ICollection<Country> entities)
        {
            tac.Countries.AddRange(entities);
            tac.SaveChanges();
        }

        public void RemoveRange(ICollection<Country> entities)
        {
            tac.Countries.RemoveRange(entities);
            tac.SaveChanges();
        }
    }
}
