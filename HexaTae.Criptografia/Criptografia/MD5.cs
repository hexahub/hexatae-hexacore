using HexaCore.Tickets.Services.Criptografia.Enums;

namespace HexaCore.Tickets.Services.Criptografia
{
    public class MD5 : Hash
    {
        public MD5(string mensagem)
            : base(mensagem, EHash.MD5)
        {
        }

        public new void Criptografar()
        {
            hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(sourceBytes);
            base.Criptografar();
        }
    }
}
