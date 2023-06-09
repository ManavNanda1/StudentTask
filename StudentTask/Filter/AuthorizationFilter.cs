using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace StudentTask.Filter
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string customerJWTToken = Convert.ToString(context.HttpContext.Session.GetString("_userToken"));
            if (!string.IsNullOrEmpty(customerJWTToken))
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken? token = handler.ReadToken(customerJWTToken) as JwtSecurityToken;
                if (token != null)
                {
                    if (token.ValidTo < DateTime.UtcNow.AddMinutes(1))
                    {
                        context.HttpContext.Session.Clear();
                        context.HttpContext.Response.Cookies.Delete(".Admin.Session");
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            action = "Login",
                            controller = "User",
                            returnUrl = context.HttpContext.Request.Path.Value
                        }));
                    }
                }
            }
            else
            {
                context.HttpContext.Session.Clear();
                context.HttpContext.Response.Cookies.Delete(".Admin.Session");
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "User",
                    returnUrl = context.HttpContext.Request.Path.Value
                }));
            }
        }
    
    }
}
