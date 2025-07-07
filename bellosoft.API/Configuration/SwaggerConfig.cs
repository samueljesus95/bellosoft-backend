using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace bellosoft.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services) =>
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Bellosoft API",
                    Version = "v1",
                    Description = "API for managing movies and TV shows",
                    Contact = new OpenApiContact
                    {
                        Name = "Bellosoft Support",
                        Email = "bellosoft@email.com"
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

        public static WebApplication UseSwaggerConfig(this WebApplication app)
        {
            var apiVersionDescriptorProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();
            app.MapSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var groupName in apiVersionDescriptorProvider.ApiVersionDescriptions.Select(description => description.GroupName))
                    options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());

                options.InjectStylesheet("/swagger-ui/custom.css");
            });

            app.UseStaticFiles();

            return app;
        }
    }
}