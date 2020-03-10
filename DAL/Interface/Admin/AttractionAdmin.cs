using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Model;
using DAL.Helpers;

namespace DAL.Interface.Admin
{
    public class AttractionAdmin : IEntityAdmin<Attraction>
    {
        TravelAgencyContext tac;
        public AttractionAdmin()
        {
            tac = ContextHelper.GetContext();
        }
        public void Add(Attraction entity)
        {
            var a = tac.Attractions.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (a == null)
            {
                tac.Attractions.Add(entity);
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Attraction already exists in database!");
            }
        }
        public async void RemoveAsync(Attraction entity)
        {
            await FindByNameAsync(entity.AttractionName);
            tac.Attractions.Remove(entity);
            await tac.SaveChangesAsync();
        }
        public async void UpdateAsync(int id, Attraction newEntity)
        {
            var a = await FindByIdAsync(id);
            if (a != null)
            {
                a = newEntity;
                await tac.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Attraction does not exist in database!");
            }
        }
        public async Task<Attraction> FindByNameAsync(string name)
        {
            return await tac.Attractions.FirstOrDefaultAsync(x => x.AttractionName.ToLower().Equals(name.ToLower())) ?? throw new Exception("Attraction not found");
        }
        public async Task<Attraction> FindByIdAsync(int id)
        {
            return await tac.Attractions.FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new Exception("Attraction was not found");
        }
        public async Task<Attraction> GetAsync(int id)
        {
            return await tac.Attractions.FindAsync(id) ?? throw new Exception("No attraction to show");
        }
        public async Task<ICollection<Attraction>> GetEntitiesAsync()
        {
            var attractions = await tac.Attractions.ToListAsync();
            return attractions.Count > 0 ? attractions : throw new Exception("No attractions to show");
        }

        public void AddRange(ICollection<Attraction> entities)
        {
            tac.Attractions.AddRange(entities);
            tac.SaveChanges();
        }

        public void RemoveRange(ICollection<Attraction> entities)
        {
            tac.Attractions.RemoveRange(entities);
            tac.SaveChanges();
        }
    }
}
