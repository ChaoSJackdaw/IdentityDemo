using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MvcWithIs4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWithIs4
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
            services.AddControllersWithViews();
            var builder = services.AddIdentityServer()
                                    .AddInMemoryIdentityResources(Config.IdentityResources)
                                    .AddInMemoryApiScopes(Config.ApiScope)
                                    .AddInMemoryClients(Config.clients)
                                    .AddTestUsers(TestUsers.Users);

            builder.AddDeveloperSigningCredential();

            /*services.AddAuthentication()
                    .AddGoogle("Google", options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                        options.ClientId = "<insert here>";
                        options.ClientSecret = "<insert here>";
                    })
                    .AddOpenIdConnect("oidc", "Demo IdentityServer", options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                        options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                        options.SaveTokens = true;

                        options.Authority = "https://demo.identityserver.io/";
                        options.ClientId = "interactive.confidential";
                        options.ClientSecret = "secret";
                        options.ResponseType = "code";

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            NameClaimType = "name",
                            RoleClaimType = "role"
                        };
                    });*/

            /* services.AddAuthentication("Bearer")
                 .AddJwtBearer("Bearer", options =>
                 {
                     options.Authority = "http://localhost:29174";

                     options.RequireHttpsMetadata = false;
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateAudience = false
                     };
                 });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
