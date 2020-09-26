using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Battleships.Application.Game.Commands.StartGame;
using Battleships.Application.Infrastructure;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Battleships.Api.Configuration.Startup
{
    public static class MediatRConfig
    {
        public static IServiceCollection AddMediatRSettings(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(StartNewGameCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}

