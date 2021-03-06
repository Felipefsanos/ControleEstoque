﻿using ControleEstoque.Application.AppServices;
using ControleEstoque.Application.AppServices.Clientes;
using ControleEstoque.Application.AppServices.Interfaces;
using ControleEstoque.Application.AppServices.Interfaces.Clientes;
using ControleEstoque.Application.AppServices.Interfaces.Telefones;
using ControleEstoque.Application.AppServices.Telefones;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Domain.Repositories.Clientes;
using ControleEstoque.Domain.Repositories.Telefones;
using ControleEstoque.Domain.Services.Auth;
using ControleEstoque.Domain.Services.Interfaces.Auth;
using ControleEstoque.Domain.UnitOfWork;
using ControleEstoque.Infra.Data.Context;
using ControleEstoque.Infra.Data.Repositories;
using ControleEstoque.Infra.Data.Repositories.Clientes;
using ControleEstoque.Infra.Data.Repositories.Telefones;
using ControleEstoque.Infra.Helpers.Authorization;
using ControleEstoque.Infra.Helpers.Authorization.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ControleEstoque.Infra.Data.IoC
{
    public class InjetorDependecias
    {
        public static void ConfigurarDependencias(IServiceCollection services, IConfiguration configuration)
        {
            ConfigurarJwt(services, configuration);
            ConfigurarDatabases(services, configuration);
            ConfigurarAppServices(services);
            ConfigurarServices(services);
            ConnfigurarRepositories(services);
        }

        private static void ConfigurarJwt(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        private static void ConnfigurarRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<ITelefonesRepository, TelefonesRepository>();
        }

        private static void ConfigurarServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtHelper, JwtHelper>();
        }

        private static void ConfigurarAppServices(IServiceCollection services)
        {
            services.AddScoped<IUsuariosAppService, UsuariosAppService>();
            services.AddScoped<IClientesAppService, ClientesAppService>();
            services.AddScoped<ITelefonesAppService, TelefonesAppService>();
        }

        private static void ConfigurarDatabases(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ControleEstoqueContext>(options => options.UseLazyLoadingProxies()
                                                                            .UseSqlServer(configuration.GetConnectionString("SqlServer"), x => x.MigrationsAssembly("ControleEstoque.Infra.Data")));
        }
    }
}
