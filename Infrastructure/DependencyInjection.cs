﻿using Application;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRequestDetailRepository, RequestDetailRepository>();
            services.AddScoped<IIssueRepository,IssueRepository>();
            services.AddDbContext<AppDbContext>(services => services.UseSqlServer(databaseConnection).EnableSensitiveDataLogging());
            return services;
        }
    }
}
