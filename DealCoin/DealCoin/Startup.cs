using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using DealCoin.Authentication;
using Dealcoin.Models;
using System.Text;
using DealCoin.Services;
using DealCoin.DAL;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;

namespace DealCoin
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            string secretKey = Configuration["JwtBearer:SigningKey"];
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services.Configure<TokenProviderOptions>(o =>
            {
                o.Audience = Configuration["JwtBearer:Audience"];
                o.Issuer = Configuration["JwtBearer:Issuer"];
                o.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });


            services.Configure<MaintenanceOption>(Configuration.GetSection("Maintenance"));

            services.AddSingleton(_ => new UserLink(Configuration["ConnectionStrings:DealcoinDB"]));
            services.AddSingleton(_ => new ArticleLink(Configuration["ConnectionStrings:DealcoinDB"]));
            services.AddSingleton(_ => new SalesLink(Configuration["ConnectionStrings:DealcoinDB"]));
            services.AddSingleton(_ => new CategoryLink(Configuration["ConnectionStrings:DealcoinDB"]));
            services.AddSingleton<PasswordHasher>();
            services.AddSingleton<UserService>();
            services.AddSingleton<ArticleService>();
            services.AddSingleton<SalesService>();
            services.AddSingleton<CategoryServices>();
            services.AddSingleton<TokenService>();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            
                string secretKey = Configuration["JwtBearer:SigningKey"];
                SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

                app.UseJwtBearerAuthentication(new JwtBearerOptions
                {
                    AuthenticationScheme = JwtBearerAuthentication.AuthenticationScheme,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,

                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JwtBearer:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = Configuration["JwtBearer:Audience"],

                        NameClaimType = ClaimTypes.Email,
                        AuthenticationType = JwtBearerAuthentication.AuthenticationType
                    }
                });
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationScheme = CookieAuthentication.AuthenticationScheme
                });

                ExternalAuthenticationEvents googleAuthenticationEvents = new ExternalAuthenticationEvents(
                    new GoogleExternalAuthenticationManager(app.ApplicationServices.GetRequiredService<UserService>()));

                app.UseGoogleAuthentication(c =>
                {
                    c.SignInScheme = CookieAuthentication.AuthenticationScheme;
                    c.ClientId = Configuration["Authentication:Google:ClientId"];
                    c.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                    c.Events = new OAuthEvents
                    {
                        OnCreatingTicket = googleAuthenticationEvents.OnCreatingTicket
                    };
                    c.AccessType = "offline";
                });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "spa",
                    template: "Home/{*anything}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
