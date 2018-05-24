using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeePortal.Core.Domain;
using EmployeePortal.Core.Interfaces.Repository;
using EmployeePortal.Core.Interfaces.Service;
using EmployeePortal.Data.Repository;
using EmployeePortal.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using AutoMapper;
using EmployeePortal.Mappings;

namespace EmployeePortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration,ILoggerFactory logger)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            services.AddDbContext<EmployeePortalDbContext>(options =>
                  options.UseMySQL(Configuration.GetConnectionString("mysqlconnection")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(BaseRepository<>));

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            
            services.AddMvc();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/ClientApp";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc();

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.Options.StartupTimeout = new TimeSpan(0, 0, 120);
                    spa.UseAngularCliServer(npmScript: "start");
                 }
            });
        }
    }
}
