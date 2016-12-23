using HexaCore.Tickets.Models.Usuario;

namespace HexaCore.Tickets.Data.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Autenticar(string email, string senha);
    }
}
