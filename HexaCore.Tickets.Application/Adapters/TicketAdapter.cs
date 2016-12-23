using HexaCore.Tickets.API.ViewModels;
using HexaCore.Tickets.Models.Ticket;

namespace HexaCore.Tickets.Application.Adapters
{
    public static class TicketAdapter
    {
        public static TicketViewModel ToViewModel (Ticket ticket)
        {
            var ticketViewModel = new TicketViewModel()
            {
                DataAbertura = ticket.DataAbertura,
                Descricao = ticket.Descricao,
                EmpresaNome = ticket.Usuario.Empresa.Nome,
                TicketId = ticket.TicketId,
                TipoTicket = ticket.TipoTicket,
                Titulo = ticket.Titulo,
                UsuarioId = ticket.UsuarioID,
                UsuarioNome = ticket.Usuario.Nome
            };
            return ticketViewModel;
        }

        public static Ticket ToModel (TicketViewModel ticketViewModel)
        {
            var ticket = new Ticket(ticketViewModel.TicketId, (int)ticketViewModel.TipoTicket, ticketViewModel.Titulo, ticketViewModel.Descricao, ticketViewModel.UsuarioId);
            return ticket;
        }
    }
}
