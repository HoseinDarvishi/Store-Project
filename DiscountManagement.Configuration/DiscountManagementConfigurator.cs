﻿using DiscountManagement.Application;
using DiscountManagement.Application.Constracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure;
using DiscountManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementConfigurator
    {
        public static void Configure(IServiceCollection services , string connectionString)
        {
            services.AddTransient<ICustomerDiscountApplication , CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscoutRepository, CustomerDiscountRepository>();

            services.AddDbContext<Context>(x => x.UseSqlServer(connectionString , b => b.MigrationsAssembly("ServiceHost")));
        }
    }
}