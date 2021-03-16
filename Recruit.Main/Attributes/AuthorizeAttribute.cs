using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruit.Main.Attributes
{

	/// <summary>
	/// Adapted from: https://stackoverflow.com/questions/49551047/custom-bearer-token-authorization-for-asp-net-core
	/// Using static token for authorization
	/// </summary>

	public class AuthorizeAttribute : TypeFilterAttribute
	{
		public AuthorizeAttribute() : base(typeof(AuthorizeActionFilter)) { }
	}

	public class AuthorizeActionFilter : IAsyncActionFilter
	{
		private readonly IValidateBearerToken _authToken;
		public AuthorizeActionFilter(IValidateBearerToken authToken)
		{
			_authToken = authToken;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			const string AUTHKEY = "authorization";
			var headers = context.HttpContext.Request.Headers;
			if (headers.ContainsKey(AUTHKEY))
			{
				bool isAuthorized = _authToken.Validate(headers[AUTHKEY]);
				if (!isAuthorized)
					context.Result = new UnauthorizedResult();
				else
					await next();
			}
			else
				context.Result = new UnauthorizedResult();
		}
	}

	public class APISettings
	{
		public string Key { get; set; }
	}

	public interface IValidateBearerToken
	{
		bool Validate(string bearer);
	}
	public class ValidateBearerToken : IValidateBearerToken
	{
		private readonly string _bearer = "123456";

		public bool Validate(string bearer)
		{
			return (bearer.Equals($"Bearer {_bearer}"));
		}
	}
}
