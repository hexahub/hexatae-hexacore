using MongoDB.Bson;
using System;
using System.Xml.Serialization;

namespace HexaCore.Tickets.Models.Empresa
{
    public class Empresa
    {
        [XmlIgnore]
        public ObjectId _id { get; set; }

        public string MongoId
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }

        public Guid EmpresaId { get; private set; }
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }

        public Empresa(Guid empresaId, string nome, string cnpj)
        {
            EmpresaId = empresaId == Guid.Empty ? Guid.NewGuid() : empresaId;
            Nome = nome;
            CNPJ = cnpj;
        }

    }
}
