using AutoMapper;
using FinancialControl.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialControl.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FinancialControlApplicationProfile());
                mc.AddProfile(new FinancialControlQueriesProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}