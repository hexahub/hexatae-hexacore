using System;
using HexaCore.Tickets.Data.Interfaces;
using HexaCore.Tickets.Models.Ticket;
using MongoDB.Driver;
using System.Linq;

namespace HexaCore.Tickets.Data.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(string connection)
            :base(connection, "tickets")
        {
        }

        public override Ticket Get(Guid id)
        {
            var filter = _builder.Eq(x => x.TicketId, id);
            return _entities.Find(filter).FirstOrDefault();
        }

        public override bool Update(Guid id, Ticket entity)
        {
            var collection = _entities;
            var filter = _builder.Eq(x => x.TicketId, id);
            var update = Builders<Ticket>.Update
                .Set(x => x.DataResolucao, entity.DataResolucao)
                .Set(x => x.Descricao, entity.Descricao)
                .Set(x => x.PrazoDesejado, entity.PrazoDesejado)
                .Set(x => x.TipoTicket, entity.TipoTicket)
                .Set(x => x.Titulo, entity.Titulo)
                .Set(x => x.UsuarioID, entity.UsuarioID);
            var result = collection.UpdateOneAsync(filter, update);

            return !result.IsFaulted;
        }
    }
}
