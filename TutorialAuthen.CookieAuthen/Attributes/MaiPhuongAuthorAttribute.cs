using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace TutorialAuthen.CookieAuthen.Attributes
{
    public class MaiPhuongAuthorAttribute : TypeFilterAttribute
    {
        public string RoleName { get; set; }
        public string ActionValue { get; set; }
        public MaiPhuongAuthorAttribute(string roleName, string actionValue) : base(typeof(MaiPhuongAuthorizeFilter))
        {
            this.RoleName = roleName;
            this.ActionValue = actionValue;
            Arguments = new object[] {RoleName, ActionValue};
        }
    }

    public class MaiPhuongAuthorizeFilter : IAuthorizationFilter
    {
        public string RoleName { get; set; }
        public string ActionValue { get; set; }
        public MaiPhuongAuthorizeFilter(string roleName, string actionValue)
        {
            this.RoleName = roleName;
            this.ActionValue = actionValue;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!CanAccesToAction(context.HttpContext))
            {
                context.Result = new ForbidResult();
            }
        }

        private bool CanAccesToAction(HttpContext httpContext)
        {
            var roles = httpContext.User.FindFirstValue(ClaimTypes.Role);
            if(roles.Equals(RoleName))
            {
                return true;
            }
            return false;
        }
    }
}
