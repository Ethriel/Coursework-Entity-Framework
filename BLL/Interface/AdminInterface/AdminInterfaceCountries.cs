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
    public class AdminInterfaceCountries : IAdminInterface<Country>
    {
        public IEntityAdmin<Country> EntityAdmin { get; set; }
        public AdminInterfaceCountries()
        {
            EntityAdmin = new CountryAdmin();
        }

        public void Add(Country entity)
        {
            EntityAdmin.Add(entity);
        }

        public void AddRange(ICollection<Country> entities)
        {
            EntityAdmin.AddRange(entities);
        }

        public Country Find(string name)
        {
            return EntityAdmin.Find(name);
        }

        public Country FindById(int id)
        {
            return EntityAdmin.FindById(id);
        }

        public Country Get(int id)
        {
            return EntityAdmin.Get(id);
        }

        public ICollection<Country> GetEntities()
        {
            return EntityAdmin.GetEntities();
        }

        public void Remove(Country entity)
        {
            EntityAdmin.Remove(entity);
        }

        public void RemoveRange(ICollection<Country> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public void Update(int id, Country newEntity)
        {
            EntityAdmin.Update(id, newEntity);
        }
    }
}
