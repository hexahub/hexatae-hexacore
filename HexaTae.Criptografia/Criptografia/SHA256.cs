using HexaCore.Tickets.Services.Criptografia.Enums;

namespace HexaCore.Tickets.Services.Criptografia
{
    public class SHA256 : Hash
    {
        public SHA256(string mensagem)
            : base(mensagem, EHash.SHA256)
        {
        }

        public new void Criptografar()
        {
            hashBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(sourceBytes);
            base.Criptografar();
        }
    }
}
