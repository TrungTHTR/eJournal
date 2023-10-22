using Application.InterfaceService;
using Application.Service;
using GroupProject_PRN231_NET1606_TRY_eJournal.WebService;

namespace GroupProject_PRN231_NET1606_TRY_eJournal
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddHttpContextAccessor();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });
            return services;
        }
    }
}
