using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCX.Configuration;
using BCX.DAL;
using BCX.DomainAccessLayer;
using BCX.Interfaces;
using BCX.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BCX
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("appsettings.json").Build();

        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddIdentity(;
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<DataContext>(c => c.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
            services.AddTransient<IPersonHandler, PersonHandler>();
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<ILevelHandler,LevelHandler>();
            services.AddTransient<ITaskHandler,TaskHandler>();
            services.AddTransient<IEmployeeHandler, EmployeeHandler>();
            services.AddTransient<IEmployerHandler, EmployerHandler>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

        }
    

      

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
       
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });
            // new RoleSeed().CreateUserRoles(serviceProvider).Wait();
        }
    }
}
