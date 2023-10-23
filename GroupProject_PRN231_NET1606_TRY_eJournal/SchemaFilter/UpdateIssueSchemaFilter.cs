using Api.issueCRUD;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Guid = System.Guid;

namespace API_gRPC.SchemaFilter
{
    public class UpdateIssueSchemaFilter : ISchemaFilter
    {
       
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
         
            if (context.Type == typeof(ModifyIssue))
            {
                schema.Example = new OpenApiObject
                {
                    ["Id"] = new OpenApiObject
                    {
                        ["value"] = new OpenApiString(Guid.Empty.ToString())
                    },
                    ["Volumn"] = new OpenApiString("string"),
                    ["Description"] = new OpenApiString("string"),
                    ["DateRelease"] = new OpenApiString(DateTime.UtcNow.ToString("dd-MM-yyyy"))
                };
            }
        }
    }
}
