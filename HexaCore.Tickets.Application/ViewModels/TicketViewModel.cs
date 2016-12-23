using HexaCore.Tickets.Models.Ticket.Enums;
using System;

namespace HexaCore.Tickets.API.ViewModels
{
    public class TicketViewModel
    {
        public Guid TicketId { get; set; }
        public ETipoTicket TipoTicket { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string EmpresaNome { get; set; }
        public Guid UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string Email { get; set; }
        public DateTime DataAbertura { get; set; }
    }
}
