using HexaCore.Tickets.Services.Criptografia.Enums;

namespace HexaCore.Tickets.Services.Criptografia.Interfaces
{
    public interface IHash
    {
        string Mensagem { get; }
        string CodHash { get; }
        EHash Tipo { get; }
    }
}
