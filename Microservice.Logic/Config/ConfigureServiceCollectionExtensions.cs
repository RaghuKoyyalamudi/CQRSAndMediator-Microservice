﻿using Microservice.Db.Config;
using Microservice.Logic.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Logic.Config
{
    public static class ConfigureServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureLogic(this IServiceCollection container, IConfiguration config)
        {
            var settings = new MicroserviceSettings();
            config.Bind(settings);

            container
                .ConfigureDb(settings.MicroserviceDbContext)
                .AddTransient<IMapper, Mapper>()
                ;

            return container;
        }
    }
}
