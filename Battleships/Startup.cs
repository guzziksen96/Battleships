using Battleships.Api.Configuration.Startup;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Battleships.Api.Filters;
using Battleships.Application.Game.Commands.StartGame;
using Battleships.Application.Helpres;

namespace Battleships
{
    public class Startup
    {
        private readonly string ApplicationName = "Battleships";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(c => c.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StartNewGameCommandValidator>()); ; 
            services.AddMemoryCache();
            services.AddAutoMapper(typeof(MappingProfiles));
            services.RegisterIoDependencies(Configuration);
            services.AddSwaggerDocumentation(ApplicationName);
            services.AddMediatRSettings();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwaggerDocumentation();

            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
