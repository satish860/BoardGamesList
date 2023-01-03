using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BoardGamesListAPI.Validators
{
    public class SortColumnValidatorFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            var attributes = context.ParameterInfo
                                   .GetCustomAttributesData()
                                   .OfType<SortColumnValidator>();
            foreach (var attribute in attributes)
            {
                var properNames = attribute.entityType.GetProperties().Select(p => p.Name);
                parameter.Schema.Extensions.Add("pattern", new OpenApiString(String.Join("|", properNames)));
            }
        }
    }
}
