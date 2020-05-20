using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LayoutService.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using LayoutTemplate.API.Services;
using LayoutService.API.Respotiroties;
using LayoutService.API.Respotiroties.Implementation;
using LayoutTemplate.API.Services.Implementation;
using LayoutTemplateType.API.Services.Implementation;

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
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("PDFInboundAutomation"));
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<ITemplateTypeService, TemplateTypeService>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<ITemplateTypeRepository, TemplateTypeRepository>();
            services.AddControllers();
            services.AddHttpContextAccessor();
            //var serviceProvider = services.BuildServiceProvider();

            //IExecutionContextAccessor executionContextAccessor = new ExecutionContextAccessor(serviceProvider.GetService<IHttpContextAccessor>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
