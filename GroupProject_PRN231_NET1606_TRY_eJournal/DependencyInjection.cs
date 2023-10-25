using Application.InterfaceService;
using Infrastructure.Mappers;
using GroupProject_PRN231_NET1606_TRY_eJournal.WebService;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Application.ViewModels.ArticleViewModels;

namespace GroupProject_PRN231_NET1606_TRY_eJournal
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services,string secretKey, IConfiguration configuration)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<ArticleResponse>("Articles");
            services.AddControllers().AddOData(options => options.Select().Filter().OrderBy().Expand().AddRouteComponents("odata", modelBuilder.GetEdmModel()));
            services.AddScoped<IClaimService, ClaimService>();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddAuthorization();
            services.AddAuthentication().AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["jwt:audience"],
                    ValidIssuer = configuration["jwt:issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:secretKey"]))
                };
            });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "eJournal API", Version = "v1", Description = "API for eJournal project" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter bearer authorization token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            return services;
        }
    }
}
