using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Hubs;
using GraduationProject.Models;
using GraduationProject.Models.Entities;
using GraduationProject.Models.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraduationProject
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MembersService>();
            services.AddTransient<GiversService>();
            services.AddTransient<ReceiversService>();
            services.AddTransient<MessagesService>();
            services.AddTransient<BadgeService>();
            services.AddTransient<FileService>();

            var connString = this.configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MyIdentityContext>(o =>
            o.UseSqlServer(connString));
            services.AddDbContext<FreshishContext>(o =>
           o.UseSqlServer(connString, s => s.UseNetTopologySuite()));

            services.AddIdentity<MyIdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.Password.RequireDigit = false;
                o.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<MyIdentityContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(
                o => o.LoginPath = "/");
            services.AddAuthentication(
                   CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(o => o.LoginPath = "/");
            services.AddMvc();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var cultureInfo = new CultureInfo("en-GB");
            cultureInfo.NumberFormat.CurrencySymbol = "SEK";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
