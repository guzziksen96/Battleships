using System.Reflection;
using Battleships.Application.Game.Commands.StartGame;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Battleships.Api.Configuration.Startup
{
    public static class MediatRConfig
    {
        public static IServiceCollection AddMediatRSettings(this IServiceCollection services)
        {
            services.AddMediatR(typeof(StartNewGameCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}

