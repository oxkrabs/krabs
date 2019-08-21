using System;
using System.Reflection;
using krabs.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace krabs.SSO.Config
{
    public static class IdentityServerConfig
    {
        // TODO: Configuration of stores should be moved in krabs.Infrastructure.Data/Configuration/IdentityServerCOnfig.cs
        public static IIdentityServerBuilder AddIdentityServer(this IServiceCollection services,
            IConfiguration configuration, IHostingEnvironment environment, ILogger logger)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var builder = services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                })
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseSqlite(connectionString, sql =>
                            sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseSqlite(connectionString, sql =>
                            sql.MigrationsAssembly(migrationsAssembly));
                    
                    options.EnableTokenCleanup = true;
                })
//                
//                .AddInMemoryIdentityResources(Config.GetIdentityResources())
//                .AddInMemoryApiResources(Config.GetApis())
//                .AddInMemoryClients(Config.GetClients())
                .AddAspNetIdentity<ApplicationUser>();

            if (environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("need to configure key material");
            }

            return builder;
        }
    }
}