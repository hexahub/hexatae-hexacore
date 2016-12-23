using HexaCore.Tickets.Data.Interfaces;
using HexaCore.Tickets.Models.Empresa;
using MongoDB.Driver;
using System;
using System.Linq;

namespace HexaCore.Tickets.Data.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(string connection)
            :base(connection, "empresas")
        {
        }

        public override Empresa Get(Guid id)
        {
            var filter = _builder.Eq(x => x.EmpresaId, id);
            return _entities.Find(filter).FirstOrDefault();
        }

        public override bool Update(Guid id, Empresa entity)
        {
            var collection = _entities;
            var filter = _builder.Eq(x => x.EmpresaId, id);
            var update = Builders<Empresa>.Update
                .Set(x => x.Nome, entity.Nome)
                .Set(x => x.CNPJ, entity.CNPJ);
            var result = collection.UpdateOneAsync(filter, update);

            return !result.IsFaulted;
        }
    }
}
