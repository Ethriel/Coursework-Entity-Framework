using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Interface.Admin;
using DAL.Interface.Interfaces;
using BLL.Interface.Interfaces;

namespace BLL.Interface.AdminInterface
{
    public class AdminInterfaceHotels : IAdminInterface<Hotel>
    {
        public IEntityAdmin<Hotel> EntityAdmin { get; set; }
        public AdminInterfaceHotels()
        {
            EntityAdmin = new HotelAdmin();
        }

        public void Add(Hotel entity)
        {
            EntityAdmin.Add(entity);
        }

        public void AddRange(ICollection<Hotel> entities)
        {
            EntityAdmin.AddRange(entities);
        }



        public async void RemoveAsync(Hotel entity)
        {
            await Task.Run(() => EntityAdmin.RemoveAsync(entity));
        }

        public void RemoveRange(ICollection<Hotel> entities)
        {
            EntityAdmin.RemoveRange(entities);
        }

        public async void UpdateAsync(int id, Hotel newEntity)
        {
           await Task.Run(() => EntityAdmin.UpdateAsync(id, newEntity));
        }

        public async Task<Hotel> FindByNameAsync(string name)
        {
            return await EntityAdmin.FindByNameAsync(name);
        }

        public async Task<Hotel> FindByIdAsync(int id)
        {
            return await EntityAdmin.FindByIdAsync(id);
        }

        public async Task<Hotel> GetAsync(int id)
        {
            return await EntityAdmin.GetAsync(id);
        }

        public async Task<ICollection<Hotel>> GetEntitiesAsync()
        {
            return await EntityAdmin.GetEntitiesAsync();
        }
    }
}
