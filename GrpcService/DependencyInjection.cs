using GrpcService.Repository;
using GrpcService;
using GrpcService.InterfaceRepository;
using GrpcService.InterfaceService;
using GrpcService.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupProject_PRN231_NET1606_TRY_eJournal.WebService;
using Application.InterfaceService;
using Application.Service;
namespace GrpcService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,string databaseConnection) 
        {
            services.AddSingleton<ICurrentTime, CurrentTime>();
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddHttpContextAccessor();
            services.AddDbContext<AppDbContext>(services => services.UseSqlServer(databaseConnection).EnableSensitiveDataLogging());
            return services;
        }
    }
}
