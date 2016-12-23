using HexaCore.Tickets.Models.Usuario.Enums;
using HexaCore.Tickets.Services.Criptografia;
using MongoDB.Bson;
using System;
using System.Xml.Serialization;

namespace HexaCore.Tickets.Models.Usuario
{
    public class Usuario
    {

        [XmlIgnore]
        public ObjectId _id { get; set; }

        public string MongoId
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }

        public Guid UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public Guid EmpresaId { get; set; }
        public Empresa.Empresa Empresa { get; set; }
        public DateTime UltimoAcesso { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public EPermissao Permissao { get; private set; }
        public bool Ativo { get; private set; }

        public Usuario(Guid usuarioId, string nome, string email, string senha, int permissao, bool ativo, Guid empresaId)
        {
            UsuarioId = usuarioId == Guid.Empty ? Guid.NewGuid() : usuarioId;
            Nome = nome;
            Email = email;
            Senha = Criptografia.Criptografar(senha);
            Permissao = (EPermissao)permissao;
            Ativo = ativo;
            EmpresaId = empresaId;
        }

        public void DefinirPermissao(int permissao)
        {
            Permissao = (EPermissao)permissao;
        }

        public void Autenticar()
        {
            UltimoAcesso = DateTime.Now;
        }
    }
}
