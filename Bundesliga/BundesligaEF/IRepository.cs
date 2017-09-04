using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaEF
{
   public interface IRepository<TEntity> where TEntity :class
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
