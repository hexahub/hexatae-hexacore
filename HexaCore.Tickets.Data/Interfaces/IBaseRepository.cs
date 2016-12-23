using System;
using System.Collections.Generic;
using System.Linq;

namespace HexaCore.Tickets.Data.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(Guid id);
        void Add(TEntity entity);
        bool Update(Guid id, TEntity entity);
        bool Delete(Guid id);
    }
}
