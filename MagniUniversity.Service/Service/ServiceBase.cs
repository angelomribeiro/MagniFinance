using MagniUniversity.Domain.Repository;
using MagniUniversity.Service.Interface;
using System.Collections.Generic;

namespace MagniUniversity.Service.Service
{
    public class ServiceBase<T> : IServiceBase<T>
        where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public ICollection<T> List()
        {
            return _repository.List();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public T Update(T command)
        {
            return _repository.Update(command);
        }

        public T Add(T command)
        {
            return _repository.Add(command);
        }
    }
}
