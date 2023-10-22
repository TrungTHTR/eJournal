using API_gRPC;
using GrpcService;
using GrpcService.Mappers;
using GrpcService.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration.Get<AppConfiguration>();
builder.Services.AddInfrastructureService(configuration!.databaseConnection);
builder.Services.AddWebAPIServices();
builder.Services.AddAutoMapper(typeof(MappersConfigurations));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
