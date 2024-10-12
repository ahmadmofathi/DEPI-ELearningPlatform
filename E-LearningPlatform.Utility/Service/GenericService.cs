using E_LearningPlatform.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningPlatform.Utility.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.Get(e => EF.Property<int>(e, "Id") == id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _repository.Get(filter);
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void RemoveById(int id)
        {
            var entity = _repository.Get(e => EF.Property<int>(e, "Id") == id);
            if (entity != null)
            {
                _repository.Remove(entity);
            }
        }
    }
}
