using HexaCore.Tickets.API.ViewModels;
using HexaCore.Tickets.Application.Adapters;
using HexaCore.Tickets.Data.Interfaces;
using HexaCore.Tickets.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HexaCore.Tickets.API.Controllers
{
    public class TicketController : ApiController
    {

        private static readonly ITicketRepository _tickets = new TicketRepository("");

        [Authorize(Roles = "Admin")]
        public IList<TicketViewModel> Get()
        {
            var ticketViewModelLst = new List<TicketViewModel>();
            _tickets.GetAll().ToList().ForEach(t => ticketViewModelLst.Add(TicketAdapter.ToViewModel(t)));
            return ticketViewModelLst;
        }

        [Authorize(Roles = "Admin")]
        public TicketViewModel Get(Guid id)
        {
            var ticket = TicketAdapter.ToViewModel(_tickets.Get(id));
            return ticket;
        }

        //[Authorize(Roles = "User")]
        public HttpResponseMessage Post(TicketViewModel ticketViewModel)
        {
            var ticket = TicketAdapter.ToModel(ticketViewModel);

            try
            {
                _tickets.Add(ticket);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message + " - " + e.InnerException.Message);
            }

            if(ticket.EfetivarCadastro())
                return Request.CreateResponse(HttpStatusCode.OK, "Ticket criado com sucesso");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ticket criado com sucesso, porém email não enviado");

        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Put(Guid id, TicketViewModel ticketViewModel)
        {
            var ticket = TicketAdapter.ToModel(ticketViewModel);
            if(_tickets.Update(id, ticket))
                return Request.CreateResponse(HttpStatusCode.OK, "Ticket alterado com sucesso");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível alterar o ticket");
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Delete(Guid id)
        {
            if (_tickets.Delete(id))
                return Request.CreateResponse(HttpStatusCode.OK, "Ticket apagado com sucesso");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível apagar o ticket");
        }

        [Route("api/ticket/finalizar/{id}")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Finalizar(Guid id)
        {
            var ticket = _tickets.Get(id);
            ticket.DefinirDataResolucao();

            if (_tickets.Update(id, ticket))
                return Request.CreateResponse(HttpStatusCode.OK, "Ticket finalizado com sucesso");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível finalizar o ticket");
        }
    }
}
