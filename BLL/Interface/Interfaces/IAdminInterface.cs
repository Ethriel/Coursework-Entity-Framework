using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Interface.Admin;
using DAL.Interface.Interfaces;

namespace BLL.Interface.Interfaces
{
    public interface IAdminInterface<T>
    {
        IEntityAdmin<T> EntityAdmin { get; set; }
        void Add(T entity);
        void AddRange(ICollection<T> entities);
        void RemoveAsync(T entity);
        void RemoveRange(ICollection<T> entities);
        void UpdateAsync(int id, T newEntity);
        Task<T> FindByNameAsync(string name);
        Task<T> FindByIdAsync(int id);
        Task<T> GetAsync(int id);
        Task<ICollection<T>> GetEntitiesAsync();
    }
}
