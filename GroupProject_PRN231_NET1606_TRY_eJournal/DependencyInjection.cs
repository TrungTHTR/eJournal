using Application.InterfaceService;
using GroupProject_PRN231_NET1606_TRY_eJournal.WebService;

namespace GroupProject_PRN231_NET1606_TRY_eJournal
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services,string secretKey)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
