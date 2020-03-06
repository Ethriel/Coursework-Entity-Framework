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
    public class AdminInterfacePictures : IAdminInterface<Picture>
    {
        public IEntityAdmin<Picture> EntityAdmin { get; set; }
        public AdminInterfacePictures()
        {
            EntityAdmin = new PictureAdmin();
        }

        public void Add(Picture entity)
        {
            EntityAdmin.Add(entity);
        }

        public void AddRange(ICollection<Picture> entities)
        {
            EntityAdmin.AddRange(entities);
        }

        public Picture Find(string name)
        {
            return EntityAdmin.Find(name);
        }

        public Picture FindById(int id)
        {
            return EntityAdmin.FindById(id);
        }

        public Picture Get(int id)
        {
            return EntityAdmin.Get(id);
        }

        public ICollection<Picture> GetEntities()
        {
            return EntityAdmin.GetEntities();
        }

        public void Remove(Picture entity)
        {
            EntityAdmin.Remove(entity);
        }

        public void RemoveRange(ICollection<Picture> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public void Update(int id, Picture newEntity)
        {
            EntityAdmin.Update(id, newEntity);
        }
    }
}
