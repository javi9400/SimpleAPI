using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Simple.Api.Context;
using Simple.Api.Services;

namespace Simple.Api
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
            services.AddControllers(setup=>
            {
                  setup.ReturnHttpNotAcceptable=true;   
                  setup.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            }   
             );

            services.AddDbContext<CourseLibraryContext>(options=> options.UseNpgsql(Configuration.GetConnectionString("CourseLibraryHn")));
            services.AddScoped<ICourseLibraryRepository,CourseLibraryRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                    app.UseExceptionHandler(appBuilder=>
                    {
                        appBuilder.Run(async context=>
                        {
                            context.Response.StatusCode=500;
                            await context.Response.WriteAsync("An unexpected error happened");  //for production purposes
                        }
                        );
                    });
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
