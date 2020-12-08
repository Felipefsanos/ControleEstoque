﻿using AutoMapper;
using ControleEstoque.Application.AppServices;
using ControleEstoque.Application.AppServices.Interfaces;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Infra.Data.Context;
using ControleEstoque.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ControleEstoque.Infra.Data.IoC
{
    public class InjetorDependecias
    {
        public static void ConfigurarDependencias(IServiceCollection services, IConfiguration configuration)
        {
            ConfigurarDatabases(services, configuration);
            ConfigurarAutoMapper(services);
            ConfigurarAppServices(services);
            ConfigurarServices(services);
            ConnfigurarRepositories(services);
        }

        private static void ConnfigurarRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
        }

        private static void ConfigurarServices(IServiceCollection services)
        {
            services.AddScoped<IUsuariosAppService, UsuariosAppService>();
        }

        private static void ConfigurarAppServices(IServiceCollection services)
        {
            
        }

        private static void ConfigurarAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(config => config.AddMaps("ControleEstoque.Application"));
        }

        private static void ConfigurarDatabases(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ControleEstoqueContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer"), x => x.MigrationsAssembly("ControleEstoque.Infra.Data")));
        }
    }
}
