using System.Collections.Generic;

namespace BrandDataProcessing
{
    public interface IRepository<T>
    {
        void Add(T item, int? id = null);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
