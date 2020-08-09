using System.Collections.Generic;

namespace MagniUniversity.Domain.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        ICollection<T> List();
        T GetById(int id);
        void Remove(int id);
        T Update(T command);
        T Add(T command);
    }
}
