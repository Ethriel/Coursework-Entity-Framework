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

        public Hotel Find(string name)
        {
            return tac.Hotels.FirstOrDefault(x => x.HotelName.ToLower().Equals(name.ToLower())) ?? throw new Exception("Hotel was not found");
        }
        public Hotel FindById(int id)
        {
            return tac.Hotels.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new Exception("Hotel was not found");
        }
        public Hotel Get(int id)
        {
            return tac.Hotels.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new Exception("No hotel to show");
        }

        public ICollection<Hotel> GetEntities()
        {
            return tac.Hotels.ToList() ?? throw new Exception("No hotels to show");
        }

        public void Remove(Hotel entity)
        {
            FindById(entity.Id);
            tac.Hotels.Remove(entity);
            tac.SaveChanges();
        }

        public void Update(int id, Hotel newEntity)
        {
            var c = FindById(id);
            if (c != null)
            {
                c = newEntity;
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Hotel does not exist in database!");
            }
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
    }
}
