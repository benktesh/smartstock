using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
{
    public class Startup
    {
        private string _applicationName;
        private string _version;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var config = Configuration.GetSection("ApplicationSetting").Get<ApplicationSetting>();
            _applicationName = config.Name;
            _version = config.Version;

            // Register the Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(_version, new Info { Title = _applicationName, Version = _version });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
           
            // Enable Swagger JSON endpoint.
            app.UseSwagger();
            // Enable swagger-ui (HTML, JS, CSS, etc.), with the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{_version}/swagger.json", $"{_applicationName} {_version}");
                
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
