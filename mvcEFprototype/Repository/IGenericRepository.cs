using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mvcEFprototype.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        void Dispose();
    }
}
