using HexaCore.Tickets.Services.Criptografia.Enums;
using HexaCore.Tickets.Services.Criptografia.Interfaces;
using System.Text;

namespace HexaCore.Tickets.Services.Criptografia
{
    public class Hash : IHash
    {
        public string CodHash { get; private set; }
        public string Mensagem { get; private set; }
        public EHash Tipo { get; private set; }
        protected byte[] sourceBytes;
        protected byte[] hashBytes = null;

        public Hash(string mensagem, EHash tipo)
        {
            DefinirMensagem(mensagem);
            Tipo = tipo;
            sourceBytes = Encoding.Default.GetBytes(this.Mensagem);
        }

        private void DefinirMensagem(string mensagem)
        {
            if (!string.IsNullOrWhiteSpace(mensagem))
                Mensagem = mensagem;
        }

        private void DefinirHash(string str)
        {
            CodHash = str;
        }

        protected void Criptografar()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; hashBytes != null && i < hashBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", hashBytes[i]);
            }
            DefinirHash(sb.ToString());
        }
    }
}
