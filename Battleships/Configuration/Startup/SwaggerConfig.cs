using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Battleships.Api.Configuration.Startup
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string applicationName)
        {
            services.AddSwaggerDocument(c =>
            {
                c.DocumentName = "OpenAPI 2";
                c.GenerateEnumMappingDescription = true;
                c.GenerateExamples = true;
                c.Title = applicationName;
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3(c =>
            {
                c.EnableTryItOut = true;
            });

            return app;
        }
    }
}
