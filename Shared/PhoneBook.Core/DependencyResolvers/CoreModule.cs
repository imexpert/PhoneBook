using System.Diagnostics;
using System.Reflection;
using PhoneBook.Core.ApiDoc;
using PhoneBook.Core.CrossCuttingConcerns.Caching;
using PhoneBook.Core.CrossCuttingConcerns.Caching.Microsoft;
using PhoneBook.Core.Utilities.IoC;
using PhoneBook.Core.Utilities.Messages;
using PhoneBook.Core.Utilities.Uri;
using PhoneBook.Core.Utilities.URI;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PhoneBook.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext?.Request;
                var uri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent(), request?.PathBase);
                return new UriManager(uri);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerMessages.Version, new OpenApiInfo
                {
                    Version = SwaggerMessages.Version,
                    Title = SwaggerMessages.Title,
                    Description = SwaggerMessages.Description
                    // TermsOfService = new Uri(SwaggerMessages.TermsOfService),
                    // Contact = new OpenApiContact
                    // {
                    //    Name = SwaggerMessages.ContactName,
                    // },
                    // License = new OpenApiLicense
                    // {
                    //    Name = SwaggerMessages.LicenceName,
                    // },
                });

                c.OperationFilter<AddAuthHeaderOperationFilter>();
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = "`Token only!!!` - without `Bearer_` prefix",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
            });
        }
    }
}