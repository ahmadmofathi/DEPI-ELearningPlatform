using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace E_LearningPlatform.Utility.Service
{
    public interface IGenericService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(int id,T entity);
        void Remove(T entity);
        void RemoveById(int id);
    }
}