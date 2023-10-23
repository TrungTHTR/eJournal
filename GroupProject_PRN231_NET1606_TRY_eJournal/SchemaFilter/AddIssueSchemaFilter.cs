using Api.issueCRUD;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GroupProject_PRN231_NET1606_TRY_eJournal.SchemaFilter
{
    public class AddIssueSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(AddIssue))
            {
                schema.Example = new OpenApiObject
                {
                    ["Volumn"] = new OpenApiString("string"),
                    ["Description"] = new OpenApiString("string"),
                    ["DateRelease"] = new OpenApiString(DateTime.UtcNow.ToString("dd-MM-yyyy"))
                };
            }
        }
    }
}
