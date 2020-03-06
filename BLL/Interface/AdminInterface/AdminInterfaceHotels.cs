using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Interface.Admin;
using DAL.Interface.Interfaces;
using BLL.Interface.Interfaces;

namespace BLL.Interface.AdminInterface
{
    public class AdminInterfaceHotels : IAdminInterface<Hotel>
    {
        public IEntityAdmin<Hotel> EntityAdmin { get; set; }
        public AdminInterfaceHotels()
        {
            EntityAdmin = new HotelAdmin();
        }

        public void Add(Hotel entity)
        {
            EntityAdmin.Add(entity);
        }

        public void AddRange(ICollection<Hotel> entities)
        {
            EntityAdmin.AddRange(entities);
        }

        public Hotel Find(string name)
        {
            return EntityAdmin.Find(name);
        }

        public Hotel FindById(int id)
        {
            return EntityAdmin.FindById(id);
        }

        public Hotel Get(int id)
        {
            return EntityAdmin.Get(id);
        }

        public ICollection<Hotel> GetEntities()
        {
            return EntityAdmin.GetEntities();
        }

        public void Remove(Hotel entity)
        {
            EntityAdmin.Remove(entity);
        }

        public void RemoveRange(ICollection<Hotel> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public void Update(int id, Hotel newEntity)
        {
            EntityAdmin.Update(id, newEntity);
        }
    }
}
