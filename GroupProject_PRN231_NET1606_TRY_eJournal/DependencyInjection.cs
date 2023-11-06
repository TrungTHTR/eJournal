using Application.InterfaceService;
using Infrastructure.Mappers;
using Application.Service;
using GroupProject_PRN231_NET1606_TRY_eJournal.WebService;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.OData;
using Application.ViewModels.ArticleViewModels;
using BusinessObject;
using System.Reflection;
using Application.ViewModels.UserViewModels;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace GroupProject_PRN231_NET1606_TRY_eJournal
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            // OData
            ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<ArticleResponse>("Articles");
            modelBuilder.EntitySet<Country>("Countries");
            modelBuilder.EntitySet<Account>("Accounts");
            modelBuilder.EntitySet<UserViewAllModel>("Users");
            modelBuilder.EntityType<Country>();
            modelBuilder.EntityType<TopicResponse>();
            modelBuilder.EntityType<AuthorResponse>();
            services.AddControllers().AddOData(options => options.Select().Filter().OrderBy().Expand().AddRouteComponents("odata", modelBuilder.GetEdmModel()));
            services.AddScoped<IClaimService, ClaimService>();
            
            // Services
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IArticleService,ArticleService>();
            services.AddScoped<IRequestDetailService, RequestDetailService>();
            services.AddScoped<IRequestReviewService, RequestReviewService>();
            services.AddHttpContextAccessor();
			services.AddScoped<IClaimService, ClaimService>();
			services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IFirebaseService, FirebaseService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IRequestDetailService, RequestDetailService>();  
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ITopicService, TopicService>();
			services.AddHttpContextAccessor();

            // Mapper
			services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddAutoMapper(typeof(ArticleMappingProfile));

            // Authentication
            services.AddAuthorization();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["jwt:audience"],
                    ValidIssuer = configuration["jwt:issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:secretKey"]))
                };
            });

            // CORS
            services.AddCors();

            // Swagger
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
