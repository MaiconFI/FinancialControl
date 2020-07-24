using FinancialControl.Queries.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialControl.Queries.IoC
{
    public static class IoCQueries
    {
        public static void AddQueries(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ReadDbContext, ReadDbContext>();

            var mongoConfiguration = configuration.GetSection("MongoDb").Get<MongoConfiguration>();
            services.AddSingleton<IMongoConfiguration>(mongoConfiguration);
        }
    }
}