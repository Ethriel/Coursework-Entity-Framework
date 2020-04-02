using System.Collections.Generic;
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

        public async void RemoveAsync(Attraction entity)
        {
           await Task.Run(()=> EntityAdmin.RemoveAsync(entity));
        }

        public void RemoveRange(ICollection<Attraction> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public async void UpdateAsync(int id, Attraction newEntity)
        {
            await Task.Run(() => EntityAdmin.UpdateAsync(id, newEntity));
        }

        public async Task<Attraction> FindByNameAsync(string name)
        {
            return await EntityAdmin.FindByNameAsync(name);
        }

        public async Task<Attraction> FindByIdAsync(int id)
        {
            return await EntityAdmin.FindByIdAsync(id);
        }

        public async Task<Attraction> GetAsync(int id)
        {
            return await EntityAdmin.GetAsync(id);
        }

        public async Task<ICollection<Attraction>> GetEntitiesAsync()
        {
            return await EntityAdmin.GetEntitiesAsync();
        }
    }
}
