using ApiLTMTest.Application.Service;
using ApiLTMTest.Domain.Entities;
using ApiLTMTest.Domain.Enums;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiLTMTest.Host.Providers
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public AuthorizationProvider()
        {
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            const string allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = Startup.Container.GetInstance<UserService>();

            var user = await userManager.FindAsync(context.UserName, context.Password);

            var _userExists = await userManager.FindByEmailAsync(context.UserName) != null;

            if(!_userExists)
            {
                context.SetError("user_not_found", "Usuário não cadastrado.");
                return;
            }

            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou Senha Incorreta");
                return;
            }

            var oAuthIdentity = await userManager.CreateIdentityAsync(user, "Bearer");
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Claims.FirstOrDefault().ToString()));

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);
        }
    }
}