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

        public async void RemoveAsync(Picture entity)
        {
            await Task.Run(() => EntityAdmin.RemoveAsync(entity));
        }

        public void RemoveRange(ICollection<Picture> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public async void UpdateAsync(int id, Picture newEntity)
        {
            await Task.Run(() => EntityAdmin.UpdateAsync(id, newEntity));
        }

        public async Task<Picture> FindByNameAsync(string name)
        {
            return await EntityAdmin.FindByNameAsync(name);
        }

        public async Task<Picture> FindByIdAsync(int id)
        {
            return await EntityAdmin.FindByIdAsync(id);
        }

        public async Task<Picture> GetAsync(int id)
        {
            return await EntityAdmin.GetAsync(id);
        }

        public async Task<ICollection<Picture>> GetEntitiesAsync()
        {
            return await EntityAdmin.GetEntitiesAsync();
        }
        public async Task<Picture> GetByReferenceAsync(string reference)
        {
            return await (EntityAdmin as PictureAdmin).GetByReferenceAsync(reference);
        }
    }
}
