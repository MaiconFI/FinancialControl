using AutoMapper;
using FinancialControl.Application.Commands.Expensies.CreateExpense;
using FinancialControl.Application.Mappers;
using FinancialControl.Infrastructure.Data;
using FinancialControl.Infrastructure.Data.IoC;
using FinancialControl.Queries.DomainEventHandlers.ExpenseCreated;
using FinancialControl.Queries.IoC;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace FinancialControl.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(m => { m.EnableEndpointRouting = false; })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            AddAutoMapper(services);

            services.AddMediatR(typeof(CreateExpenseCommandHandler).GetTypeInfo().Assembly, typeof(ExpenseCreatedDomainEventHandler).GetTypeInfo().Assembly);
            services.AddQueries(_configuration);

            services.AddDbContext<FinancialControlContext>(opts =>
            {
                var connectionString = _configuration.GetConnectionString(nameof(FinancialControlContext));
                opts.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(FinancialControlContext).Assembly.FullName));
            });
            MigrateDatabase(services);
            services.AddData();
        }

        private void AddAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FinancialControlApplicationProfile());
                mc.AddProfile(new FinancialControlQueriesProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void MigrateDatabase(IServiceCollection services)
        {
            using var serviceScope = services.BuildServiceProvider().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<FinancialControlContext>();

            if (context.AllMigrationsApplied()) return;

            context.Database.Migrate();
        }
    }
}