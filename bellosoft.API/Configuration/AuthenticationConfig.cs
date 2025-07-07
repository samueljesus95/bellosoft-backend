using bellosoft.Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace bellosoft.API.Configuration
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {

            var settings = configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(settings);

            var jwtSettings = settings.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = false
                    };
                });

            return services;
        }
    }
}
