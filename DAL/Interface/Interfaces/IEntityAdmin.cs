using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IEntityAdmin<T>
    {
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
