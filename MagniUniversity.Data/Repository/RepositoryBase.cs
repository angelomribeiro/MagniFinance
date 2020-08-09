using AutoMapper;
using MagniUniversity.Data.Context;
using MagniUniversity.Data.Mapping;
using MagniUniversity.Domain.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MagniUniversity.Data.Repository
{
    public class RepositoryBase<M, E> : IRepositoryBase<M>
        where M : class
        where E : class
    {
        protected readonly MagniUniversityContext _db;
        protected readonly IMapper _mapper;

        public RepositoryBase(MagniUniversityContext ctx)
        {
            _db = ctx;
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(typeof(MappingProfile));
            });
            _mapper = config.CreateMapper();
        }

        public ICollection<M> List()
        {
            var entities = _db.Set<E>().ToList();

            var models = _mapper.Map<ICollection<M>>(entities);
            return models;
        }

        public M GetById(int id)
        {
            return _mapper.Map<M>(_db.Set<E>().Find(id));
        }

        public void Remove(int id)
        {
            var entity = _db.Set<E>().Find(id);
            _db.Set<E>().Remove(entity);
            _db.SaveChanges();
        }

        public M Add(M command)
        {
            var entity = _mapper.Map<E>(command);
            _db.Set<E>().Add(entity);
            _db.SaveChanges();

            return _mapper.Map<M>(entity);
        }

        public M Update(M command)
        {
            var entity = _mapper.Map<E>(command);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();

            return _mapper.Map<M>(entity);
        }
    }
}
