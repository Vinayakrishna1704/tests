using Fw.DataAccessLayer;
using Fw.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Fw.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		[Authorize]
		public IHttpActionResult Get()
		{
			AuthDAO authDAO = new AuthDAO();
			
			var username = User.GetUsername();
			var role = User.GetRole();
			                    
			return Ok(authDAO.GetUserByUsername("admin"));
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
