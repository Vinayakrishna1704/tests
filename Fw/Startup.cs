using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace Fw
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			Debug.WriteLine("-->>>>>>>>");


			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true, // In production mode set AllowInsecureHttp = false
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
				Provider = new SimpleAuthorizationServerProvider()
			};

			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());



			/*app.UseJwtBearerAuthentication(
				new JwtBearerAuthenticationOptions
				{
					AuthenticationMode = AuthenticationMode.Active,
					TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = ConfigurationManager.AppSettings["JwtIssuer"], //some string, normally web url,  
						ValidAudience = ConfigurationManager.AppSettings["JwtIssuer"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtKey"]))
					}
				});*/
		}
	}
}