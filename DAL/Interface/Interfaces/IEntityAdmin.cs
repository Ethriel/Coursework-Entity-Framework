using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IEntityAdmin<T>
    {
        void Add(T entity);
        void AddRange(ICollection<T> entities);
        void Remove(T entity);
        void RemoveRange(ICollection<T> entities);
        void Update(int id, T newEntity);
        T Find(string name);
        T FindById(int id);
        T Get(int id);
        ICollection<T> GetEntities();
    }
}
