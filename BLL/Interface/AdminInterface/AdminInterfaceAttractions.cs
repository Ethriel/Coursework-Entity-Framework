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
    public class AdminInterfaceAttractions : IAdminInterface<Attraction>
    {
        public IEntityAdmin<Attraction> EntityAdmin { get; set; }
        public AdminInterfaceAttractions()
        {
            EntityAdmin = new AttractionAdmin();
        }

        public void Add(Attraction entity)
        {
            EntityAdmin.Add(entity);
        }

        public void AddRange(ICollection<Attraction> entities)
        {
            EntityAdmin.AddRange(entities);
        }

        public Attraction Find(string name)
        {
            return EntityAdmin.Find(name);
        }

        public Attraction FindById(int id)
        {
            return EntityAdmin.FindById(id);
        }

        public Attraction Get(int id)
        {
            return EntityAdmin.Get(id);
        }

        public ICollection<Attraction> GetEntities()
        {
            return EntityAdmin.GetEntities();
        }

        public void Remove(Attraction entity)
        {
            EntityAdmin.Remove(entity);
        }

        public void RemoveRange(ICollection<Attraction> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public void Update(int id, Attraction newEntity)
        {
            EntityAdmin.Update(id, newEntity);
        }
    }
}
