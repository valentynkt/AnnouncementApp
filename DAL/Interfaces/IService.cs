using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> Get();
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity item);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
