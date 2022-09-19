using EventsProject.Dtos;
using Mapster;
using System.Reflection;

namespace EventsProject.Extentions
{
    public static class ServiceExtentions
    {
        public static void AddMapster(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            Assembly applicationAssembly = typeof(BaseDto<,>).Assembly;
            typeAdapterConfig.Scan(applicationAssembly);
        }
    }
}
