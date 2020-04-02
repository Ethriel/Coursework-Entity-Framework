using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        
        public async void RemoveAsync(City entity)
        {
            await FindByNameAsync(entity.CityName);
            tac.Cities.Remove(entity);
            await tac.SaveChangesAsync();
        }

        public async void UpdateAsync(int id, City newEntity)
        {
            var c = await FindByIdAsync(id);
            c = newEntity;
            await tac.SaveChangesAsync();
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

        public async Task<City> FindByNameAsync(string name)
        {
            return await tac.Cities.FirstOrDefaultAsync(x => x.CityName.ToLower().Equals(name.ToLower())) ?? throw new Exception("City was not found");
        }

        public async Task<City> FindByIdAsync(int id)
        {
            return await tac.Cities.FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new Exception("City was not found");
        }

        public async Task<City> GetAsync(int id)
        {
            return await tac.Cities.FindAsync(id) ?? throw new Exception("No city to show");
        }

        public async Task<ICollection<City>> GetEntitiesAsync()
        {
            var cities = await tac.Cities.ToListAsync();
            return cities.Count > 0 ? cities : throw new Exception("No cities to show");
        }
    }
}
