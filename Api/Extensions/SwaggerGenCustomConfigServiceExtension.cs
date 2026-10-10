using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;
using System.Text;

namespace Api.Extensions
{
    public static class SwaggerGenCustomConfigServiceExtension
    {
        public static IServiceCollection AddSwaggerGenCustomConfig(
            this IServiceCollection services)
        {
            string description = new StringBuilder()
              .Append("Заголовок авторизации JWT с использованием схемы Bearer.")
              .Append(Environment.NewLine)
              .Append(Environment.NewLine)
              .Append("Введите 'bearer' [пробел], а затем свой токен")
              .Append(Environment.NewLine)
              .Append(Environment.NewLine)
              .Append("Пример: \"bearer eyJh.bGc.iOi\"")
              .ToString();

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(
                    JwtBearerDefaults.AuthenticationScheme,
                    new OpenApiSecurityScheme
                    {
                        Description = description,
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });

                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecuritySchemeReference(JwtBearerDefaults.AuthenticationScheme, document),
                    new List<string>()
                }
            });
            });
            return services;
        }
    }
}
