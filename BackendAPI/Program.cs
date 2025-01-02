using BackendAPI.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI
{
    namespace BackendAPI
    {
        public class Program
        {
           

            public static void Main(string[] args)
            {
                CreateHostBuilder(args).Build().Run();
            }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
         .ConfigureAppConfiguration((context, config) =>
         {
             var env = context.HostingEnvironment;
             config.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();
         })
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.UseStartup<Startup>(); // Startup s�n�f�n� giri� noktas� olarak kullan
         });

        }
        public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            // Bu metod servisleri eklemek i�in kullan�l�r
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllers();
                services.AddSwaggerGen(); // Swagger/OpenAPI deste�ini ekler
                services.AddScoped<TasinmazService>();
            }

            // Bu metod HTTP isteklerini i�lemek i�in pipeline'� yap�land�r�r
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                            app.UseSwagger(); // Swagger JSON deste�ini aktif et
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            c.RoutePrefix = string.Empty; // Swagger UI'ye do�rudan eri�im
        });

                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }

}
