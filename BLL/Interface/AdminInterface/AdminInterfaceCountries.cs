using System.Collections.Generic;
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

        public async void RemoveAsync(Country entity)
        {
            await Task.Run(() => EntityAdmin.RemoveAsync(entity));
        }

        public void RemoveRange(ICollection<Country> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public async void UpdateAsync(int id, Country newEntity)
        {
            await Task.Run(() => EntityAdmin.UpdateAsync(id, newEntity));
        }

        public async Task<Country> FindByNameAsync(string name)
        {
            return await EntityAdmin.FindByNameAsync(name);
        }

        public async Task<Country> FindByIdAsync(int id)
        {
            return await EntityAdmin.FindByIdAsync(id);
        }

        public async Task<Country> GetAsync(int id)
        {
            return await EntityAdmin.GetAsync(id);
        }

        public async Task<ICollection<Country>> GetEntitiesAsync()
        {
            return await EntityAdmin.GetEntitiesAsync();
        }
    }
}
