using System.Security.Claims;
using System.Security.Principal;

namespace Fw.utils
{
	public static class AuthUtils
	{

		public static string GetUsername(this IPrincipal user)
		{
			var identity = user.Identity as ClaimsIdentity;
			return identity?.FindFirst("username")?.Value;
		}

		public static string GetRole(this IPrincipal user)
		{
			var identity = user.Identity as ClaimsIdentity;
			return identity?.FindFirst("role")?.Value;
		}

	}
}