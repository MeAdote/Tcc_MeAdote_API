using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (User)context.HttpContext.Items["User"];

        if(user == null)
        {
            context.Result = new JsonResult(new{message = "Unauthorized"});

            context.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"\", charset=\"UTF-8\"";
        }
    }
}