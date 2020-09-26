using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleships.Application;
using Battleships.Application.Game.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Battleships.Api.Configuration.Startup
{
    public static class IoConfig
    {
        public static IServiceCollection RegisterIoDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IBoardGenerator, BoardGenerator>();
            services.AddScoped<IGameStateService, GameStateService>();

            return services;
        }
    }
}
