using HexaCore.Tickets.Data.Interfaces;
using HexaCore.Tickets.Data.Repositories;
using HexaCore.Tickets.Models.Empresa;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HexaCore.Tickets.API.Controllers
{
    public class EmpresaController : ApiController
    {
        private static readonly IEmpresaRepository _empresaRepository = new EmpresaRepository("");

        [Authorize(Roles = "Admin")]
        public IQueryable<Empresa> Get()
        {
            return _empresaRepository.GetAll();
        }

        [Authorize(Roles = "Admin, User")]
        public Empresa Get(Guid id)
        {
            var empresa = _empresaRepository.Get(id);
            return empresa;
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Post(Empresa empresa)
        {
            try
            {
                _empresaRepository.Add(empresa);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message + " - " + e.InnerException.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Empresa criada com sucesso");

        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Put(Guid id, Empresa empresa)
        {
            if (_empresaRepository.Update(id, empresa))
                return Request.CreateResponse(HttpStatusCode.OK, "Empresa alterada com sucesso");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível alterar a empresa");
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Delete(Guid id)
        {
            if (_empresaRepository.Delete(id))
                return Request.CreateResponse(HttpStatusCode.OK, "Empresa apagada com sucesso");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível apagar a empresa");
        }
    }
}
