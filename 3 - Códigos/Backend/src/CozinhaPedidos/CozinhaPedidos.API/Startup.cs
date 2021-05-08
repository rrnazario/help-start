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

            //Customiza��o das informa��es que ir�o aparecer no Swagger quando executarmos a API.
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

            //Dois m�todos criados para separar a visualiza��o das inje��es
            //Para mais explica��es: https://pt.stackoverflow.com/questions/20770/o-que-%C3%A9-inje%C3%A7%C3%A3o-de-depend%C3%AAncia
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
        /// Inje��o de dependencias dos servi�os do sistema.
        /// </summary>
        /// <param name="services"></param>
        private void InjectServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IClienteService, ClienteService>();
        }

        /// <summary>
        /// Inje��o de dependencias dos reposit�rios do sistema.
        /// </summary>
        /// <param name="services"></param>

        private void InjectRepositories(IServiceCollection services)
        {
            services.AddSingleton<IClienteRepository, ClienteRepository>();
        }

        /// <summary>
        /// Inje��o dos demais elementos da API.
        /// </summary>
        /// <param name="services"></param>
        private void InjectUtilitaries(IServiceCollection services)
        {
#warning FAZER!
        }


        /// <summary>
        /// Mapeamento no AutoMapper das entidades do sistema.<br /><br />
        /// O AutoMapper � uma extens�o que faz a convers�o entre entidades x viewModels x inputModels <br />
        /// Ao inv�s de fazermos essa convers�o "na unha", utilizamos essa op��o.
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
