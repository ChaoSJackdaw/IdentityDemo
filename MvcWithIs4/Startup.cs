using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MvcWithIs4.Models;
using MvcWithIs4.Models.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddControllersWithViews();


            services.AddDbContext<UserDb>(options => 
                                        options.UseSqlServer(
                                            Constant.connectString
                                            //  Configuration.GetConnectionString("DefaultConnection")
                                            ));

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User = new UserOptions
                {
                    RequireUniqueEmail = true, //要求Email唯一
                    AllowedUserNameCharacters = null //允许的用户名字符
                };
                options.Password = new PasswordOptions
                {
                    RequiredLength = 8, //要求密码最小长度，默认是 6 个字符
                    RequireDigit = true, //要求有数字
                    RequiredUniqueChars = 3, //要求至少要出现的字母数
                    RequireLowercase = true, //要求小写字母
                    RequireNonAlphanumeric = false, //要求特殊字符
                    RequireUppercase = false //要求大写字母
                };
            })
                .AddEntityFrameworkStores<UserDb>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer()
                    .AddAspNetIdentity<ApplicationUser>();

            builder.AddInMemoryIdentityResources(Config.IdentityResources)
                    .AddInMemoryClients(Config.clients)
                    .AddInMemoryApiScopes(Config.ApiScope);

            builder.AddDeveloperSigningCredential();
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
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
