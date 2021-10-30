using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using PhoneBook.Core.Extensions;
using PhoneBook.Core.Utilities.IoC;
using PhoneBook.Libraries.Book.Business;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Api
{
    public class Startup : BusinessStartup
    {
        /// <summary>
        /// Constructor of <c>Startup</c>
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hostEnvironment"></param>
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
            : base(configuration, hostEnvironment)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml"));
            });

            services.AddTransient<PostgreSqlLogger>();

            base.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceTool.ServiceProvider = app.ApplicationServices;

            app.UseDeveloperExceptionPage();

            app.ConfigureCustomExceptionMiddleware();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("v1/swagger.json", "Phone Book Api");
                c.DocExpansion(DocExpansion.None);
            });

            app.UseCors("AllowOrigin");

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
