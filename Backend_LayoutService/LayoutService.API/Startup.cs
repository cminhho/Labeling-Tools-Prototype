using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using LayoutService.Infrastructure.Database;
using LayoutTemplate.Infrastructure.Domain;
using LayoutTemplate.Application.Templates;
using LayoutTemplate.Application.TemplateTypes;
using LayoutTemplate.Application.FormRecognizer;
using LayoutTemplate.Application.BlobStorage;
using System;
using System.Reflection;
using System.IO;
using LayoutTemplate.Domain.Common;

namespace LayoutService
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
            // use in-memory database
            ConfigureInMemoryDatabase(services);

            // use real database
            ConfigureProductionService(services);

            services.AddScoped<AppDbContext>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<ITemplateTypeService, TemplateTypeService>();
            services.AddScoped<IFormRecognizerService, FormRecognizerService>();
            services.AddScoped<IFormRecognizerV2Service, FormRecognizerV2Service>();
            services.AddScoped<IStorageService, BlobStorageService>();

            services.AddMemoryCache();
            services.AddControllers();
            services.AddHttpContextAccessor();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PDF Inbound Automation API",
                    Version = "v1"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        private void ConfigureInMemoryDatabase(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("PDFInboundAutomation"));
        }

        private void ConfigureProductionService(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("PDFInboundAutomationContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PDF Inbound Automation API V1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Mapper.Initialize(config => { config.AddProfile<API.Mappings.AutoMapperProfile>(); });

        }
    }
}
