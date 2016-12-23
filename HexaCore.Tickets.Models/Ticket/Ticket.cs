using HexaCore.Tickets.Models.Ticket.Enums;
using MongoDB.Bson;
using System;
using System.Xml.Serialization;

namespace HexaCore.Tickets.Models.Ticket
{
    public class Ticket
    {

        [XmlIgnore]
        public ObjectId _id { get; set; }
        
        public string MongoId
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }

        public Guid TicketId { get; private set; }
        public ETipoTicket TipoTicket { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public Guid UsuarioID { get; private set; }
        public Usuario.Usuario Usuario { get; private set; }
        public DateTime PrazoDesejado { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public DateTime? DataResolucao { get; private set; }


        protected Ticket()
        {

        }

        public Ticket(Guid ticketId, int tipoTicket, string titulo, string descricao, Guid usuarioId)
        {
            TicketId = ticketId == Guid.Empty ? Guid.NewGuid() : ticketId;
            TipoTicket = (ETipoTicket)tipoTicket;
            Titulo = titulo;
            Descricao = descricao;
            UsuarioID = usuarioId;
            PrazoDesejado = DateTime.Now + TimeSpan.FromDays(5);
            DataAbertura = DateTime.Now;
        }

        public void DefinirTitulo(string titulo)
        {
            if (!string.IsNullOrEmpty(titulo))
                Titulo = titulo;
        }

        public void DefinirDescricao(string descricao)
        {
            if (!string.IsNullOrEmpty(descricao))
                Descricao = descricao;
        }

        public void DefinirDataResolucao()
        {
            DataResolucao = DateTime.Now;
        }

        public bool EfetivarCadastro()
        {

            var mensagem = "";
            //string mensagem = "<h3>" + this.TipoTicket.ToString() + " de " + this.EmpresaId + "</h3><br/>"
            //    + "<p>" + this.NomeContato + " diz: </p>"
            //    + "<p>" + this.Descricao + "</p><br/>"
            //    + "<p>Prazo desejado:" + this.PrazoDesejado.ToShortDateString() + "</p><br/>"
            //    + "<p>Mensagem recebida em: " + this.DataAbertura.ToShortDateString() + " de " + this.NomeContato + " da empresa " + this.EmpresaId + "</p><br/>";

            var result = Services.Email.Email.EnviarEmail(new string[] { this.Usuario.Email }, null, null,this.TipoTicket.ToString(), mensagem, null);

            return result.Item1;

        }

    }

}
