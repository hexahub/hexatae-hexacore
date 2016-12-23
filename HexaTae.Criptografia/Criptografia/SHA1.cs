using HexaCore.Tickets.Services.Criptografia.Enums;

namespace HexaCore.Tickets.Services.Criptografia
{
    public class SHA1 : Hash
    {
        public SHA1(string mensagem)
            : base(mensagem, EHash.SHA1)
        {
        }

        public new void Criptografar()
        {
            hashBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(sourceBytes);
            base.Criptografar();
        }
    }
}
