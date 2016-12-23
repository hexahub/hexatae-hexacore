namespace HexaCore.Tickets.Services.Criptografia
{
    public static class Criptografia
    {
        public static string Criptografar(string mensagem)
        {
            var cripto = new SHA256(mensagem);
            cripto.Criptografar();
            return cripto.CodHash;
        }
    }
}
