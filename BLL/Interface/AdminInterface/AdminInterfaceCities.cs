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
    public class AdminInterfaceCities : IAdminInterface<City>
    {
        public IEntityAdmin<City> EntityAdmin { get; set; }
        public AdminInterfaceCities()
        {
            EntityAdmin = new CityAdmin();
        }

        public void Add(City entity)
        {
            EntityAdmin.Add(entity);
        }

        public void AddRange(ICollection<City> entities)
        {
            EntityAdmin.AddRange(entities);
        }

        public City Find(string name)
        {
            return EntityAdmin.Find(name);
        }

        public City FindById(int id)
        {
            return EntityAdmin.FindById(id);
        }

        public City Get(int id)
        {
            return EntityAdmin.Get(id);
        }

        public ICollection<City> GetEntities()
        {
            return EntityAdmin.GetEntities();
        }

        public void Remove(City entity)
        {
            EntityAdmin.Remove(entity);
        }

        public void RemoveRange(ICollection<City> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public void Update(int id, City newEntity)
        {
            EntityAdmin.Update(id, newEntity);
        }
    }
}
