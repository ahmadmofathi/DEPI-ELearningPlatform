using E_LearningPlatform.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

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
            _repository.SaveChanges();
        }

        public void Update(int id, T updatedEntity)
        {
            // Find the key property of the entity using reflection
            var keyProperty = typeof(T).GetProperties()
                .FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Any() ||
                                        (prop.PropertyType == typeof(int) &&
                                         (string.Equals(prop.Name, "Id", StringComparison.OrdinalIgnoreCase) ||
                                          string.Equals(prop.Name, typeof(T).Name + "Id", StringComparison.OrdinalIgnoreCase))));

            if (keyProperty == null)
            {
                throw new Exception("No key property found for the entity.");
            }

            // Retrieve the existing entity from the repository using the key property
            var existingEntity = _repository.Get(e => (int)keyProperty.GetValue(e) == id);

            if (existingEntity != null)
            {
                // Update the properties of the existing entity with the values from the updatedEntity
                foreach (var property in typeof(T).GetProperties())
                {
                    if (property.CanWrite && property.Name != keyProperty.Name) // Don't update the key property itself
                    {
                        var newValue = property.GetValue(updatedEntity);
                        property.SetValue(existingEntity, newValue);
                    }
                }

                // Save the changes to the repository
                _repository.SaveChanges();
            }
            else
            {
                throw new Exception("Entity not found");
            }
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
            _repository.SaveChanges();
        }

        public void RemoveById(int id)
        {
            var entity = _repository.Get(e => EF.Property<int>(e, "Id") == id);
            if (entity != null)
            {
                _repository.Remove(entity);
                _repository.SaveChanges();
            }
        }
    }
}
