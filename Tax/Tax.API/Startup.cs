using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Tax.API.Application.Queries;
using Tax.API.Application.Queries.Interfaces;
using Tax.API.Settings;
using Tax.Infrastructure;
using Tax.Infrastructure.Interface;
using Newtonsoft.Json.Serialization;

namespace Tax.API
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
            services.AddScoped<ITaxService, TaxService>();

            services.AddHttpClient<ITaxService, TaxService>(client =>
            {
                client.Timeout = TimeSpan.FromMinutes(2);
            }).SetHandlerLifetime(TimeSpan.FromMinutes(5));

            services.AddSingleton(Configuration.GetSection("Tax:TaxApiSettings").Get<TaxApiSettings>());

            services.AddTransient<ICalculateTaxQuery, CalculateTaxQuery>();
            services.AddTransient<IGetTaxRateByLocationQuery, GetTaxRateByLocationQuery>();


            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        ///<see cref="https://www.newtonsoft.com/json/help/html/SerializationSettings.htm"/>
                        options.SerializerSettings.Converters.Add(
                            new Newtonsoft.Json.Converters.StringEnumConverter(new CamelCaseNamingStrategy()));
                        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
                        options.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
                        options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                        options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;

                    });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tax.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tax.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
