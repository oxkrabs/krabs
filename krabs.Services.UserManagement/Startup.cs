using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using krabs.Application.AutoMapper;
using krabs.Infrastructure.Data.Entities;
using krabs.Infrastructure.Identity.Config.Configuration;
using krabs.Infrastructure.Identity.Entities;
using krabs.Infrastructure.IoC;
using krabs.Services.UserManagement.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using krabs.SSO.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace krabs.Services.UserManagement
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        private readonly ILogger<Startup> _logger;

//        private void InitializeDatabase(IApplicationBuilder app)
//        {
//            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
//            {
//                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
//
//                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
//                //context.Database.EnsureCreated();
//                context.Database.Migrate();
//                if (!context.Clients.Any())
//                {
//                    foreach (var client in Config.GetClients())
//                    {
//                        context.Clients.Add(client.ToEntity());
//                    }
//                    context.SaveChanges();
//                }
//
//                if (!context.IdentityResources.Any())
//                {
//                    foreach (var resource in Config.GetIdentityResources())
//                    {
//                        context.IdentityResources.Add(resource.ToEntity());
//                    }
//                    context.SaveChanges();
//                }
//
//                if (!context.ApiResources.Any())
//                {
//                    foreach (var resource in Config.GetApis())
//                    {
//                        context.ApiResources.Add(resource.ToEntity());
//                    }
//                    context.SaveChanges();
//                }
//            }
//        }
        
        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _environment = environment;
            _logger = logger;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddIdentityServer(Configuration, _environment, _logger);
            services.AddAuthentication(IdentityConstants.ApplicationScheme);
            
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5001"; // Who do we trust?
                    options.RequireHttpsMetadata = true;
                    options.Audience = "api1";                   // Who are we?
                });
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy", _ => 
                    _.WithOrigins("http://localhost:5100", "http://localhost:5010", "https://localhost:5011", "https://localhost:5101").AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info {Title = "Protected api", Version = "v1"});
                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Flow = "implicit",
                    AuthorizationUrl = "https://localhost:5001/connect/authorize",
                    Scopes = new Dictionary<string, string> { 
                        { "demo_api", "Demo API - full access" },
                        { "api1", "normal api"}
                    }
                });
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
            
            RepositoryBootstraper.RegisterServices(services, Configuration);
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
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                options.RoutePrefix = string.Empty;
                options.OAuthClientId("demo_api_swagger");
                options.OAuthAppName("Demo API - Swagger");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}