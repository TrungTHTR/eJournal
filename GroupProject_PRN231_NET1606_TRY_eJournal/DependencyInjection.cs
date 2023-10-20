using Application.InterfaceService;
using GroupProject_PRN231_NET1606_TRY_eJournal.WebService;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GroupProject_PRN231_NET1606_TRY_eJournal
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services,string secretKey, IConfiguration configuration)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddHttpContextAccessor();
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

            return services;
        }
    }
}
