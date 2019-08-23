using System.Reflection;
using AutoMapper;
using krabs.Application.AutoMapper;
using krabs.Application.Interfaces;
using krabs.Application.Services;
using krabs.Domain.Core.Bus;
using krabs.Domain.EventHandlers;
using krabs.Domain.Events;
using krabs.Domain.Interfaces;
using krabs.Infrastructure.Bus;
using krabs.Infrastructure.Data.Entities;
using krabs.Infrastructure.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace krabs.Infrastructure.IoC
{
    public class RepositoryBootstraper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration["DB_CONNECTION_STRING"];
            services.AddScoped<ApplicationDbContext>();
            
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connection));
            
            services.AddScoped<IClientRepository, ClientRepository>();    
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<NotifyEvent>, NotificationHandler>();
            
            services.AddTransient<IClientAppService, ClientAppService>();
            services.AddTransient<IUserManageAppService, UserManageAppService>();
            
            //services.AddAutoMapper();
            services.AddAutoMapper();
            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings();
        }
    }
}