using System.Collections.Generic;
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

        public async void RemoveAsync(City entity)
        {
            await Task.Run(() => EntityAdmin.RemoveAsync(entity));
        }

        public void RemoveRange(ICollection<City> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public async void UpdateAsync(int id, City newEntity)
        {
            await Task.Run(() => EntityAdmin.UpdateAsync(id, newEntity));
        }

        public async Task<City> FindByNameAsync(string name)
        {
            return await EntityAdmin.FindByNameAsync(name);
        }

        public async Task<City> FindByIdAsync(int id)
        {
            return await EntityAdmin.FindByIdAsync(id);
        }

        public async Task<City> GetAsync(int id)
        {
            return await EntityAdmin.GetAsync(id);
        }

        public async Task<ICollection<City>> GetEntitiesAsync()
        {
            return await EntityAdmin.GetEntitiesAsync();
        }
    }
}
