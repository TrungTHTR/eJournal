using Api.issueCRUD;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.SchemaFilter
{
    public class IssueIdSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(IssueId))
            {
                schema.Example = new OpenApiObject
                {
                    ["Id"] = new OpenApiString(Guid.Empty.ToString()),
                };
            }
        }
    }
}
