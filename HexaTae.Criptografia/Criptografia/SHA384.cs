using HexaCore.Tickets.Services.Criptografia.Enums;

namespace HexaCore.Tickets.Services.Criptografia
{
    public class SHA384 : Hash
    {
        public SHA384(string mensagem)
            : base(mensagem, EHash.SHA384)
        {
        }

        public new void Criptografar()
        {
            hashBytes = System.Security.Cryptography.SHA384.Create().ComputeHash(sourceBytes);
            base.Criptografar();
        }
    }
}
