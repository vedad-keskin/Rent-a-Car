using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GMS.Helpers.Auth
{
    public class AutorizacijaSwaggerHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "my-auth-token",
                In = ParameterLocation.Header,
                Description = "Iz autentifikacije upisati preuzeti token"

            });
        }
    }
}
