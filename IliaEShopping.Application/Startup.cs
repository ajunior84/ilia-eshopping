using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IliaEShopping.Infrastructure.Data;
using IliaEShopping.Infrastructure.Interfaces;
using IliaEShopping.Infrastructure.Repositories;
using IliaEShopping.Service.Interfaces;
using IliaEShopping.Service.Services;
using System.IO;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace IliaEShopping.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddOptions();
            services.AddResponseCaching();

            // Add swagger documentation
            services.AddSwaggerGen(swagger =>
            {
                swagger.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ília e-Shopping API",
                    Version = "v1"
                });

                swagger.CustomSchemaIds(x => x.FullName);
                swagger.DescribeAllParametersInCamelCase();

                var XMLPath = AppDomain.CurrentDomain.BaseDirectory + "IliaEShopping.Application" + ".xml";

                if (File.Exists(XMLPath))
                {
                    swagger.IncludeXmlComments(XMLPath);
                }

                string basePath = AppContext.BaseDirectory;

                Directory.GetFiles(string.Format("{0}/", basePath), "*.xml").ToList().ForEach(file =>
                {
                    swagger.IncludeXmlComments(file, true);
                });
            });

            services.AddControllers()
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Formatting = Formatting.Indented;
                    opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<DbContext, EShoppingDataContext>(options => options.UseMySql(Configuration.GetConnectionString("IliaEShopping"), myOpts =>
            {
                myOpts.EnableRetryOnFailure();
            }), ServiceLifetime.Scoped);

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseWelcomePage("/");
            app.UseWebSockets();
            app.UseResponseCaching();

            app.UseSwagger();
            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("v1/swagger.json", "ília e-Shopping API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
