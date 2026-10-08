using Api.Service;

namespace Api.Extensions
{
    public static class JwtTokenGeneratorServiceExtensions
    {
        public static IServiceCollection AddJwtTokenGenerator(this IServiceCollection services)
        {
            return services.AddScoped<JwtTokenGenerator>();
        }
    }
}
