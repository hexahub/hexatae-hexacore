using HexaCore.Tickets.Data.Interfaces;
using HexaCore.Tickets.Data.Repositories;
using HexaCore.Tickets.Services.Criptografia;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace HexaCore.Tickets.API
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = context.UserName;
                var password = Criptografia.Criptografar(context.Password);

                IUsuarioRepository _usuarioRepository = new UsuarioRepository("");
                var usuario = _usuarioRepository.Autenticar(user, password);

                if (usuario == null)
                {
                    context.SetError("invalid_grant", "Usuário ou senha inválidos");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.UsuarioId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));

                var roles = new List<string>();

                roles.Add(usuario.Permissao.ToString());

                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);

            }
            catch (Exception e)
            {
                context.SetError("invalid_grant", e.Message);
            }
        }
    }
}