using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async void RemoveAsync(Country entity)
        {
            await FindByNameAsync(entity.CountryName);
            tac.Countries.Remove(entity);
            await tac.SaveChangesAsync();
        }

        public async void UpdateAsync(int id, Country newEntity)
        {
            var c = await FindByIdAsync(id);
            c = newEntity;
            await tac.SaveChangesAsync();
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

        public async Task<Country> FindByNameAsync(string name)
        {
            return await tac.Countries.FirstOrDefaultAsync(x => x.CountryName.ToLower().Equals(name.ToLower())) ?? throw new Exception("Country was not found");
        }

        public async Task<Country> FindByIdAsync(int id)
        {
            return await tac.Countries.FindAsync(id) ?? throw new Exception("Country was not found");
        }

        public async Task<Country> GetAsync(int id)
        {
            return await tac.Countries.FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new Exception("No country to show");
        }

        public async Task<ICollection<Country>> GetEntitiesAsync()
        {
            var countries = await tac.Countries.ToListAsync();
            return countries.Count > 0 ? countries : throw new Exception("No countries to show");
        }
    }
}
