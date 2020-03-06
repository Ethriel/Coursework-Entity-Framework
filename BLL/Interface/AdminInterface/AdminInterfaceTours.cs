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
    public class AdminInterfaceTours : IAdminInterface<Tour>
    {
        public IEntityAdmin<Tour> EntityAdmin { get; set; }
        public AdminInterfaceTours()
        {
            EntityAdmin = new TourAdmin();
        }

        public void Add(Tour entity)
        {
            EntityAdmin.Add(entity);
        }

        public void AddRange(ICollection<Tour> entities)
        {
            EntityAdmin.AddRange(entities);
        }

        public Tour Find(string name)
        {
            return EntityAdmin.Find(name);
        }

        public Tour FindById(int id)
        {
            return EntityAdmin.FindById(id);
        }

        public Tour Get(int id)
        {
            return EntityAdmin.Get(id);
        }

        public ICollection<Tour> GetEntities()
        {
            return EntityAdmin.GetEntities();
        }

        public void Remove(Tour entity)
        {
            EntityAdmin.Remove(entity);
        }

        public void RemoveRange(ICollection<Tour> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public void Update(int id, Tour newEntity)
        {
            EntityAdmin.Update(id, newEntity);
        }
    }
}
