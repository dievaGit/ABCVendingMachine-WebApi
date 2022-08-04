using ABCVendingMachine.DataAccess;
using ABCVendingMachine.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ABCVendingMachine.Api
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
            services.AddControllers();

            services.AddScoped<IWarehousesQueryService, WarehousesQueryService>();
            services.AddScoped<IVendingMachinesQueryService, VendingMachinesQueryService>();
            services.AddScoped <IOrdersQueryService, OrdersQueryService>();
            services.AddScoped<IUsersQueryService, UsersQueryService>();

            services.AddMediatR(Assembly.Load("ABCVendingMachine.Services.EventHandlers"));
            services.AddDbContext<ApplicationDBContext>(context => { context.UseInMemoryDatabase("ABCVendingMachine"); });

            var logger = new LoggerConfiguration()
              .ReadFrom.Configuration(Configuration)
               .WriteTo.Console()
              .CreateLogger();
            services.AddSingleton<Serilog.ILogger>(logger);

          

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder //WithOrigins(Configuration["AppSettings:CorsOriginUrl"])
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin());
            });
            services.AddMvc();
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDBContext>();

            DataConfiguration.AddData(context);

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            loggerFactory.AddSerilog();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
