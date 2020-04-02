using System.Collections.Generic;
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

        public async void RemoveAsync(Tour entity)
        {
            await Task.Run(() => EntityAdmin.RemoveAsync(entity));
        }

        public void RemoveRange(ICollection<Tour> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public async void UpdateAsync(int id, Tour newEntity)
        {
            await Task.Run(() => EntityAdmin.UpdateAsync(id, newEntity));
        }
        public void MarkNotRelevant()
        {
            (EntityAdmin as TourAdmin).MarkNotRelevant();
        }

        public async Task<Tour> FindByNameAsync(string name)
        {
            return await EntityAdmin.FindByNameAsync(name);
        }

        public async Task<Tour> FindByIdAsync(int id)
        {
            return await EntityAdmin.FindByIdAsync(id);
        }

        public async Task<Tour> GetAsync(int id)
        {
            return await EntityAdmin.GetAsync(id);
        }

        public async Task<ICollection<Tour>> GetEntitiesAsync()
        {
            return await EntityAdmin.GetEntitiesAsync();
        }
    }
}
