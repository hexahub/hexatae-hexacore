using HexaCore.Tickets.Data.Configuration;
using HexaCore.Tickets.Data.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCore.Tickets.Data.Repositories
{
    public class BaseRepository<TEntity> : MongoDBConfiguration<TEntity>, IBaseRepository<TEntity> where TEntity : class
    {

        public BaseRepository(string connection, string table)
            :base(connection, table)
        {
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

        public void Add(TEntity entity)
        {
            _entities.InsertOne(entity);
        }

        public bool Delete(Guid id)
        {
            var filter = _builder.Eq(_table + "Id", id);
            var result = _entities.DeleteOne(filter);
            return result.DeletedCount == 1;
        }

        public virtual bool Update(Guid id, TEntity entity)
        {
            var collection = _entities;
            var filter = _builder.Eq(nameof(entity) + "Id", id);
            var update = Builders<TEntity>.Update
                .Set("", "");
                //.Set(x => x.Descricao, entity.Descricao)
                //.Set(x => x.Email, entity.Email)
                //.Set(x => x.EmpresaSolicitante, entity.EmpresaSolicitante)
                //.Set(x => x.NomeContato, entity.NomeContato)
                //.Set(x => x.PrazoDesejado, entity.PrazoDesejado)
                //.Set(x => x.TipoTicket, entity.TipoTicket)
                //.Set(x => x.Titulo, entity.Titulo);
            var result = collection.UpdateOneAsync(filter, update);

            return !result.IsFaulted;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(_builder);
            GC.SuppressFinalize(_entities);
            GC.SuppressFinalize(_db);
            GC.Collect();
        }

        public virtual TEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
