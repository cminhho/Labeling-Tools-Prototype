using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using LayoutService.API.Infrastructure;
using LayoutTemplate.API.Services;
using LayoutService.API.Respotiroties;
using LayoutService.API.Respotiroties.Implementation;
using LayoutTemplate.API.Services.Implementation;
using LayoutService.API.Services.Implementation;
using LayoutTemplateType.API.Services.Implementation;
using LayoutService.API.Configuration;

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
            //services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("PDFInboundAutomation"));
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("PDFInboundAutomationContext")));
            services.Configure<AppConfig>(Configuration);

            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<ITemplateTypeRepository, TemplateTypeRepository>();

            services.AddScoped<UnitOfWork>();

            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<ITemplateTypeService, TemplateTypeService>();
            services.AddScoped<IFormRecognizerService, FormRecognizerService>();
            services.AddScoped<IStorageService, BlobStorageService>();


            services.AddControllers();
            services.AddHttpContextAccessor();
            //var serviceProvider = services.BuildServiceProvider();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PDF Inbound Automation API", Version = "v1" });
            });

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
