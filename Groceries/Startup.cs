﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GroceriesTool.DAL.Context;
using GroceriesTool.DAL.Repositories;
using GroceriesTool.DAL.Models;
using GroceriesTool.Models;

namespace GroceriesTool
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
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddAzureAd(options => Configuration.Bind("AzureAd", options))
            .AddCookie();

            DatabaseContext.ConnectionString = Configuration.GetConnectionString("DatabaseContext");
            services.AddDbContext<DatabaseContext>();

            services.AddMvc();
            services.AddSingleton<IRepository<Groceries>>(new GroceriesRepository(new DatabaseContext()));
            services.AddSingleton<IRepository<Stores>>(new StoresRepository(new DatabaseContext()));
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GrocerieViewModel, Groceries>();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
