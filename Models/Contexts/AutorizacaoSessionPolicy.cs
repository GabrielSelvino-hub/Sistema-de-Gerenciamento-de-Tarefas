using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Sistema_de_Gerenciamento_de_Tarefas.Models.Contexts
{
    public class AutorizacaoSessionPolicy : IAuthorizationRequirement
    {
        public string Autorizado { get; set; }

        public AutorizacaoSessionPolicy(string autorizado)
        {
            Autorizado = autorizado;
        }
    }

    public class AutorizacaoSessionHandler : AuthorizationHandler<AutorizacaoSessionPolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AutorizacaoSessionPolicy requirement)
        {
            if (context.User.Identity.IsAuthenticated && context.Resource is AuthorizationFilterContext filterContext)
            {
                var sessionValue = filterContext.HttpContext.Session.GetString("Autorizado");

                if (sessionValue == requirement.Autorizado)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }

}
