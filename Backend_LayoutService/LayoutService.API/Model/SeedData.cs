using LayoutService.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LayoutService.API.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                SeedTemplateItems(context);
                SeedTemplateTypeItems(context);
                context.SaveChanges();
            }
        }

        private static void SeedTemplateItems(AppDbContext context) 
        {
            // Look for any templates
            if (context.Templates.Any())
            {
                return; // DB has been seeded
            }

            context.Templates.AddRange(
                new Template
                {
                    Name = "Template 1 XXXX",
                    IsComplete = false,
                    Code = "XXXXXXXXXXXX",
                    ModelId = "daa1c0b5-5ba6-46ad-91cb-54f92a871c5f",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                }
            );
        }

        private static void SeedTemplateTypeItems(AppDbContext context)
        {
            // Look for any templates
            if (context.TemplateTypes.Any())
            {
                return; // DB has been seeded
            }

            context.TemplateTypes.AddRange(
                new TemplateType
                {
                    Name = "Template Type 1",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
