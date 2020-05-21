using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LayoutTemplate.Domain.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity model);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(object Id);

        void Modify(TEntity model);

        void Delete(TEntity model);

        void DeleteById(object Id);

        Task<TEntity> GetByIdAsync(Guid Id);
    }
}
