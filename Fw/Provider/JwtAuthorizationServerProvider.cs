using Fw.DataAccessLayer;
using Fw.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
{
	AuthDAO _authDAO;
	public SimpleAuthorizationServerProvider()
	{
		this._authDAO = new AuthDAO();
	}
	

	public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
	{
		context.Validated(); 
	}

	public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
	{
		User user=_authDAO.GetUserByUsername(context.UserName);
		if(user!=null && user.Password.Equals(context.Password))
		{
			var identity = new ClaimsIdentity(context.Options.AuthenticationType);
			identity.AddClaim(new Claim("username", context.UserName));
			identity.AddClaim(new Claim("role", user.Role));

            var ticket = new AuthenticationTicket(identity, null);
            context.Validated(ticket);

          
            //context.Validated(identity);
		}
		else
		{
			context.SetError("invalid_grant", "The user name or password is incorrect.");
			return;
		}
		
	
	}


}
