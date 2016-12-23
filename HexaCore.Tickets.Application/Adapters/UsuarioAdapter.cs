using HexaCore.Tickets.Application.ViewModels;
using HexaCore.Tickets.Data.Repositories;
using HexaCore.Tickets.Models.Empresa;
using HexaCore.Tickets.Models.Usuario;

namespace HexaCore.Tickets.Application.Adapters
{
    public static class UsuarioAdapter
    {

        public static UsuarioViewModel ToViewModel(Usuario usuario)
        {
            var _empresaRepository = new EmpresaRepository("");
            Empresa empresa = _empresaRepository.Get(usuario.EmpresaId);

            var usuarioViewModel = new UsuarioViewModel()
            {
                Email = usuario.Email,
                EmpresaId = usuario.EmpresaId,
                EmpresaNome = empresa.Nome,
                Nome = usuario.Nome,
                UltimoAcesso = usuario.UltimoAcesso,
                UsuarioId = usuario.UsuarioId
            };

            return usuarioViewModel;
        }
    }
}
