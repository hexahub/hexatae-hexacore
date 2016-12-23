using HexaCore.Tickets.Data.Interfaces;
using HexaCore.Tickets.Models.Usuario;
using MongoDB.Driver;
using System;
using System.Linq;

namespace HexaCore.Tickets.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(string connection)
            :base(connection, "usuarios")
        {
        }

        public override Usuario Get(Guid id)
        {
            var filter = _builder.Eq(x => x.UsuarioId, id);
            return _entities.Find(filter).FirstOrDefault();
        }        

        public Usuario Autenticar(string email, string senha)
        {
            var filter = _builder.Eq(x => x.Email, email) & _builder.Eq(x => x.Senha, senha);
            return _entities.Find(filter).FirstOrDefault();
        }

        public override bool Update(Guid id, Usuario entity)
        {
            var collection = _entities;
            var filter = _builder.Eq(x => x.UsuarioId, id);
            var update = Builders<Usuario>.Update
                .Set(x => x.Nome, entity.Nome)
                .Set(x => x.EmpresaId, entity.EmpresaId);
            var result = collection.UpdateOneAsync(filter, update);

            return !result.IsFaulted;
        }

    }
}
