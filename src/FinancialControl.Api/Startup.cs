using FinancialControl.Api.Configurations;
using FinancialControl.Api.Controllers.V1;
using FinancialControl.Application.Commands.Expensies.CreateExpense;
using FinancialControl.Infrastructure.Data;
using FinancialControl.Infrastructure.Data.IoC;
using FinancialControl.Queries.DomainEventHandlers.ExpenseCreated;
using FinancialControl.Queries.IoC;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseMvc()
                .UseApiVersioning();

            app.UseSwagger(provider);
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

            services.AddApiVersioning(s =>
            {
                s.DefaultApiVersion = new ApiVersion(1, 0);
                s.ReportApiVersions = true;
                s.AssumeDefaultVersionWhenUnspecified = true;

                s.Conventions.Controller<ExpenseController>().HasApiVersion(new ApiVersion(1, 0));
            });

            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            services.AddSwagger();

            services.AddAutoMapper();

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

        private void MigrateDatabase(IServiceCollection services)
        {
            using var serviceScope = services.BuildServiceProvider().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<FinancialControlContext>();

            if (context.AllMigrationsApplied()) return;

            context.Database.Migrate();
        }
    }
}