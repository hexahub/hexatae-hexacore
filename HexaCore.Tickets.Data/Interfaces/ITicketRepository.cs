using HexaCore.Tickets.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCore.Tickets.Data.Interfaces
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
    }
}
