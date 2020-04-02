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
    public class HotelAdmin : IEntityAdmin<Hotel>
    {
        TravelAgencyContext tac;
        public HotelAdmin()
        {
            tac = ContextHelper.GetContext();
        }
        public void Add(Hotel entity)
        {
            var c = tac.Countries.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (c == null)
            {
                tac.Hotels.Add(entity);
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Hotel is already at database!");
            }
        }



        public async void RemoveAsync(Hotel entity)
        {
            await FindByIdAsync(entity.Id);
            tac.Hotels.Remove(entity);
            await tac.SaveChangesAsync();
        }

        public async void UpdateAsync(int id, Hotel newEntity)
        {
            var c = await FindByIdAsync(id);
            c = newEntity;
            await tac.SaveChangesAsync();
        }
        public void AddRange(ICollection<Hotel> entities)
        {
            tac.Hotels.AddRange(entities);
            tac.SaveChanges();
        }

        public void RemoveRange(ICollection<Hotel> entities)
        {
            tac.Hotels.RemoveRange(entities);
            tac.SaveChanges();
        }

        public async Task<Hotel> FindByNameAsync(string name)
        {
            return await tac.Hotels.FirstOrDefaultAsync(x => x.HotelName.ToLower().Equals(name.ToLower())) ?? throw new Exception("Hotel was not found");
        }

        public async Task<Hotel> FindByIdAsync(int id)
        {
            return await tac.Hotels.FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new Exception("Hotel was not found");
        }

        public async Task<Hotel> GetAsync(int id)
        {
            return await tac.Hotels.FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new Exception("No hotel to show");
        }

        public async Task<ICollection<Hotel>> GetEntitiesAsync()
        {
            var hotels = await tac.Hotels.ToListAsync();
            return hotels.Count > 0 ? hotels : throw new Exception("No hotels to show");
        }
    }
}
