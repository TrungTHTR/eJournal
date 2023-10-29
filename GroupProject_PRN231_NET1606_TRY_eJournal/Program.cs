using Application.Common;
using GroupProject_PRN231_NET1606_TRY_eJournal;
using GroupProject_PRN231_NET1606_TRY_eJournal.SchemaFilter;
using Infrastructure;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var configuration =builder.Configuration.Get<AppConfiguration> ();
/*configuration.DatabaseConnection = builder.Configuration.GetConnectionString("Default");*/
builder.Services.AddWebAPIServices("", builder.Configuration);
builder.Services.AddInfrastructureService(configuration!.DatabaseConnection);

builder.Services.AddWebAPIServices();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SchemaFilter<AddIssueSchemaFilter>();
    opt.SchemaFilter<UpdateIssueSchemaFilter>();
    opt.SchemaFilter<IssueIdSchemaFilter>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseODataBatching();

app.MapControllers();

app.Run();
