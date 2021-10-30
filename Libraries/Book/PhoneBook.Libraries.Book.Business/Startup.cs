using Autofac;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Core.DependencyResolvers;
using PhoneBook.Core.Extensions;
using PhoneBook.Core.Utilities.IoC;
using PhoneBook.Core.Utilities.MessageBrokers.RabbitMq;
using PhoneBook.Libraries.Book.Business.DependencyResolvers;
using PhoneBook.Libraries.Book.DataAccess.Abstract;
using PhoneBook.Libraries.Book.DataAccess.Concrete.EntityFramework;
using PhoneBook.Libraries.Book.DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Business
{
    public partial class BusinessStartup
    {
        public IConfiguration Configuration { get; }

        protected IHostEnvironment HostEnvironment { get; }

        public BusinessStartup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            var coreModule = new CoreModule();

            services.AddDependencyResolvers(Configuration, new ICoreModule[] { coreModule });

            services.AddSingleton<ConfigurationManager>();

            services.AddTransient<IMessageBrokerHelper, MqQueueHelper>();
            services.AddTransient<IMessageConsumer, MqConsumerHelper>();

            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddAutoMapper(typeof(ConfigurationManager));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(BusinessStartup).GetTypeInfo().Assembly);

            ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) =>
            {
                return memberInfo.GetCustomAttribute<DisplayAttribute>()
                    ?.GetName();
            };

            services.AddDbContext<ProjectDbContext>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacBusinessModule(new ConfigurationManager(Configuration, HostEnvironment)));
        }
    }
}
