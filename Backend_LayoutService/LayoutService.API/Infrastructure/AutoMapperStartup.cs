using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace LayoutService.API.Infrastructure
{
    public static class AutoMapperStartup
    {
        public static IServiceCollection AddAutoMapperModule(this IServiceCollection @this)
        {
            @this.AddAutoMapper(typeof(Startup));
            return @this;
        }
    }
}
