using com.w3cnet.WebApi.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace com.w3cnet.WebApi
{
    public class Startup
    {
        const string ApiName = "WebApi脚手架";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //var builder = new ConfigurationBuilder()
            //   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo()
                {
                    Title = $"{ApiName}接口文档",
                    Version = "v1",
                    Description = $"{ApiName} HTTP API v1"
                });

                options.OrderActionsBy(o => o.RelativePath);
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "com.w3cnet.WebApi.xml"), true);
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "com.w3cnet.WebApi.Model.xml"), false);
            });

            services.AddJWT();           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // swagger
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    //设置Swagger文档路径
                    options.SwaggerEndpoint("/swagger/V1/swagger.json", $"{ApiName}接口文档");
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
