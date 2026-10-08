using Microsoft.AspNetCore.Identity;

namespace Api.Extensions
{
    public static class IdentityOptionExtensions
    {
        public static IServiceCollection AddConfigureIdentityOption(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            return services;
        }
    }
}
