using CozinhaPedidos.Core.Entities;
using CozinhaPedidos.Core.Interfaces.Repositories;
using CozinhaPedidos.Core.Interfaces.Services;
using CozinhaPedidos.Core.ViewModels;
using CozinhaPedidos.Domain.InputModels;
using CozinhaPedidos.Domain.Services;
using CozinhaPedidos.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CozinhaPedidos.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Customização das informações que irão aparecer no Swagger quando executarmos a API.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "[API] Pedidos da Cozinha", 
                    Version = "v1",
                    Description = "API do projeto do grupo 'Help Start'.",
                    Contact = new()
                    {
                        Url = new Uri("http://t.me/helpstartbr"),
                        Name = "Grupo do Telegram"
                    }                    
                });
            });

            //Dois métodos criados para separar a visualização das injeções
            //Para mais explicações: https://pt.stackoverflow.com/questions/20770/o-que-%C3%A9-inje%C3%A7%C3%A3o-de-depend%C3%AAncia
            InjectServices(services);
            InjectRepositories(services);
            InjectUtilitaries(services);

            //Mapeamento das entidades
            MapEntities(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CozinhaPedidos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Injeção de dependencias dos serviços do sistema.
        /// </summary>
        /// <param name="services"></param>
        private void InjectServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IClienteService, ClienteService>();
        }

        /// <summary>
        /// Injeção de dependencias dos repositórios do sistema.
        /// </summary>
        /// <param name="services"></param>

        private void InjectRepositories(IServiceCollection services)
        {
            services.AddSingleton<IClienteRepository, ClienteRepository>();
        }

        /// <summary>
        /// Injeção dos demais elementos da API.
        /// </summary>
        /// <param name="services"></param>
        private void InjectUtilitaries(IServiceCollection services)
        {
#warning FAZER!
        }


        /// <summary>
        /// Mapeamento no AutoMapper das entidades do sistema.<br /><br />
        /// O AutoMapper é uma extensão que faz a conversão entre entidades x viewModels x inputModels <br />
        /// Ao invés de fazermos essa conversão "na unha", utilizamos essa opção.
        /// </summary>
        /// <param name="services"></param>
        private void MapEntities(IServiceCollection services)
        {
            services.AddAutoMapper(map =>
            {
                //Clients
                map.CreateMap<Cliente, ClienteViewModel>();
                map.CreateMap<ClienteInputModel, Cliente>();
            });
        }
    }
}
