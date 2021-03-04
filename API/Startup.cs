using LIBs.Domain;
using LIBs.Infra.Context;
using LIBs.Repository;
using LIBs.Repository.IRepositoy;
using LIBs.Service;
using LIBs.Service.IService;
using LIBs.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ProjetoContext>(opt => opt.UseInMemoryDatabase("ProjetoVendas"));

            services.AddTransient<IServiceVenda, ServiceVenda>();
            services.AddTransient<IServiceVendedor, ServiceVendedor>();
            services.AddTransient<IServiceVeiculo, ServiceVeiculo>();
            services.AddTransient<IRepositoryVenda, RepositoryVenda>();
            services.AddTransient<IRepositoryVendedor, RepositoryVendedor>();
            services.AddTransient<IRepositoryVeiculo, RepositoryVeiculo>();
            services.AddTransient<IStatusVenda, StatusVenda>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Projeto API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "William Gontijo",
                        Email = "william854@live.com",
                        Url = new Uri("https://www.linkedin.com/in/william-gontijo-543628142/"),
                    },

                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);


            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Framw");
                c.RoutePrefix = string.Empty;
            });

            var scope = app.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider.GetService<ProjetoContext>();

            AdicionarDadosIniciais(service);

          

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        private static void AdicionarDadosIniciais(ProjetoContext context)
        {
            Vendedor vendedor = new Vendedor
            {
                Codigo = Guid.NewGuid(),
                Nome = "Joao Vendedor",
                Email = "JoaoVendedor@yahoo.com",
                CPF = "064.6464.54.5454"
            };

            Veiculo veiculo = new Veiculo
            {
                Codigo = Guid.NewGuid(),
                Marca = "Ford",
                Modelo = "Fiesta",
                AnoFabricacao = "2009"

            };
            Veiculo veiculo2 = new Veiculo
            {
                Codigo = Guid.NewGuid(),
                Marca = "FIAT",
                Modelo = "Palio",
                AnoFabricacao = "2029"

            };

            Venda venda = new Venda
            {
                Codigo = Guid.NewGuid(),
                Veiculos = new List<Veiculo>()
                {
                    veiculo
                },
                Vendedor = vendedor,
                StatusVenda = 0
            };


            context.Veiculos.Add(veiculo);
            context.Veiculos.Add(veiculo2);
            context.Vendedores.Add(vendedor);
            context.Vendas.Add(venda);
            context.SaveChanges();
        }
    }
}
