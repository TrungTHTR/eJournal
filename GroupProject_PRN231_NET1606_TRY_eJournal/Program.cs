using Application.Common;
using GroupProject_PRN231_NET1606_TRY_eJournal;
using Infrastructure;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration =builder.Configuration.Get<AppConfiguration> ();
builder.Services.AddWebAPIServices("", builder.Configuration);
builder.Services.AddInfrastructureService(configuration!.databaseConnection);
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
