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
                    RequireUniqueEmail = true, //Ҫ��EmailΨһ
                    AllowedUserNameCharacters = null //������û����ַ�
                };
                options.Password = new PasswordOptions
                {
                    RequiredLength = 8, //Ҫ��������С���ȣ�Ĭ���� 6 ���ַ�
                    RequireDigit = true, //Ҫ��������
                    RequiredUniqueChars = 3, //Ҫ������Ҫ���ֵ���ĸ��
                    RequireLowercase = true, //Ҫ��Сд��ĸ
                    RequireNonAlphanumeric = false, //Ҫ�������ַ�
                    RequireUppercase = false //Ҫ���д��ĸ
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
