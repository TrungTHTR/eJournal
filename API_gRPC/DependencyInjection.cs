using GrpcService.InterfaceService;
using API_gRPC.WebService;

namespace API_gRPC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddHttpContextAccessor();
            services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true;
            });
            return services;
        }
    }
}
