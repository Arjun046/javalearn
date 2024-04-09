using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NACH.API.Services;

namespace NACH.API
{
    public class ValidateSessionAttribute : TypeFilterAttribute
    {
        public ValidateSessionAttribute()
            : base(typeof(ValidateSessionFilter))
        {
        }

        public class ValidateSessionFilter : IAuthorizationFilter
        {
            private const string AuthorizationHeaderName = "Authorization";

            private readonly ISessionValidator _apiKeyValidator;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public ValidateSessionFilter(IHttpContextAccessor httpContextAccessor, ISessionValidator apiKeyValidator)
            {
                _apiKeyValidator = apiKeyValidator;
                _httpContextAccessor = httpContextAccessor;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                string authHeader = _httpContextAccessor.HttpContext.Request.Headers[AuthorizationHeaderName];

                if (authHeader != null && authHeader.StartsWith("Bearer"))
                {
                    var status = _apiKeyValidator.IsValidSession(authHeader);
                    if (!status)
                    {
                        context.Result = new JsonResult(new
                        {
                            date = DateTime.Now,
                            title = "Unauthorized",
                            status = StatusCodes.Status401Unauthorized,
                            Message = "Token is expired. Request Access Denied"
                        })
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };
                    }
                    var IsResetPassword = _apiKeyValidator.IsResetPassword(authHeader);
                    if (IsResetPassword)
                    {
                        context.Result = new JsonResult(new
                        {
                            Date = DateTime.Now,
                            Status = "9",
                            Message = "Your password has been reset by admin user due to security reasons so please set your new password"
                        })
                        {
                            StatusCode = StatusCodes.Status200OK
                        };
                    }
                }
                else
                {
                    context.Result = new JsonResult(new
                    {
                        date = DateTime.Now,
                        title = "Unauthorized",
                        status = StatusCodes.Status401Unauthorized,
                        Message = "Token Validation Has Failed. Request Access Denied"
                    })
                    {
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
                }
            }
        }
    }
}
