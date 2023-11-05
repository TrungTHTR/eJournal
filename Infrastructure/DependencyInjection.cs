using Application;
using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.Service;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,string databaseConnection) 
        {
            services.AddSingleton<ICurrentTime, CurrentTime>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(databaseConnection).EnableSensitiveDataLogging());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IRequestReviewRepository, RequestReviewRepository>();
            services.AddScoped<IRequestDetailRepository, RequestDetailRepository>();
            services.AddScoped<IMajorRepository, MajorRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            return services;
        }
    }
}
