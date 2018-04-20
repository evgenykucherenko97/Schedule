using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.EF.Interfaces
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(Guid id);
        Task<T> GetAsync(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
