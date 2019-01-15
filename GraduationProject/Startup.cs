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
using Microsoft.Extensions.DependencyInjection;

namespace GraduationProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MembersService>();
            services.AddTransient<GiversService>();
            services.AddTransient<ReceiversService>();
            services.AddTransient<MessagesService>();
            services.AddTransient<BadgeService>();

            var connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FreshishDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
                o => o.LoginPath = "/Members/Login");
            services.AddAuthentication(
                   CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(o => o.LoginPath = "/Members/Login");
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
