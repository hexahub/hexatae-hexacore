using System;

namespace HexaCore.Tickets.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid EmpresaId { get; set; }
        public string EmpresaNome { get; set; }
        public DateTime UltimoAcesso { get; set; }
    }
}
