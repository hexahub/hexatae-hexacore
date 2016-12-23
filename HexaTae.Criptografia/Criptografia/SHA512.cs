using HexaCore.Tickets.Services.Criptografia.Enums;

namespace HexaCore.Tickets.Services.Criptografia
{
    public class SHA512 : Hash
    {
        public SHA512(string mensagem)
            : base(mensagem, EHash.SHA512)
        {
        }

        public new void Criptografar()
        {
            hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(sourceBytes);
            base.Criptografar();
        }
    }
}
