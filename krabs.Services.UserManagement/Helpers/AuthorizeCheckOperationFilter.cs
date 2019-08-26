using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace krabs.Services.UserManagement.Helpers
{
    public class AuthorizeCheckOperationFilter : IOperationFilter {
        public void Apply(Swashbuckle.AspNetCore.Swagger.Operation operation, OperationFilterContext context)
        {
            var controllerAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true).ToList();
            var hasAuthorize = controllerAttributes
                .OfType<AuthorizeAttribute>()
                .Any();
            
            if (hasAuthorize) {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });
                operation.Responses.Add("403", new Response { Description = "Forbidden" });

                operation.Security = new List<IDictionary<string, IEnumerable<string>>> {
                    new Dictionary<string, IEnumerable<string>> {{"oauth2", new[] {"demo_api"}}}
                };
            }
        }
    }
}