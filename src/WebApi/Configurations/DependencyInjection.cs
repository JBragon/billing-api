using Business.Interfaces;
using Business.Services;
using DataAccess.Config;
using DataAccess.Context;
using FluentValidation;
using Microsoft.Extensions.Options;
using Models.Business;
using Models.Mapper.Request;
using MongoDB.Bson.Serialization;

namespace WebApi.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            BsonClassMap.RegisterClassMap<Billing>();

            services.AddSingleton<IBillingDatabaseSettings>(options =>
                options.GetRequiredService<IOptions<BillingDatabaseSettings>>().Value);

            services.AddSingleton<MongoDbContext>();

            services.AddScoped<IBillingService, BillingService>();

            //Fluent Validation
            services.AddTransient<IValidator<BillingPost>, BillingPostValidation>();

            return services;
        }
    }
}
