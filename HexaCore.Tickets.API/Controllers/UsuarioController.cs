using HexaCore.Tickets.Application.Adapters;
using HexaCore.Tickets.Application.ViewModels;
using HexaCore.Tickets.Data.Interfaces;
using HexaCore.Tickets.Data.Repositories;
using HexaCore.Tickets.Models.Usuario;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HexaCore.Tickets.API.Controllers
{
    
    public class UsuarioController : ApiController
    {
        private static readonly IUsuarioRepository _usuarios = new UsuarioRepository("");

        [Authorize(Roles = "Admin")]
        public IQueryable<Usuario> Get()
        {
            return _usuarios.GetAll();
        }

        [Authorize(Roles = "Admin")]
        public Usuario Get(Guid id)
        {
            var usuario = _usuarios.Get(id);
            return usuario;
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Post(Usuario usuario)
        {
            try
            {
                _usuarios.Add(usuario);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message + " - " + e.InnerException.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Usuário criado com sucesso");
        }

        public HttpResponseMessage Put(Guid id, Usuario usuario)
        {
            if (_usuarios.Update(id, usuario))
                return Request.CreateResponse(HttpStatusCode.OK, "Usuário alterado com sucesso");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível alterar o usuário");
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Delete(Guid id)
        {
            if (_usuarios.Delete(id))
                return Request.CreateResponse(HttpStatusCode.OK, "Usuário apagado com sucesso");
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Não foi possível apagar o usuário");
        }

        [Route("api/security/usuarioautenticado")]
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public UsuarioViewModel UsuarioAutenticado()
        {
            UsuarioViewModel usuario;
            if (User.Identity.IsAuthenticated)
                usuario = UsuarioAdapter.ToViewModel(_usuarios.Get(new Guid(User.Identity.Name)));
            else
                usuario = null;
            return usuario;
        }
    }
}