using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace bellosoft.API.Configuration
{
    public static class VersioningApiConfig
    {
        public static IServiceCollection AddVersioningApiConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;

                var urlSegmentVersionReader = new UrlSegmentApiVersionReader();
                var hearderVersionReader = new HeaderApiVersionReader("x-api-version");
                var mediaTypeVersionReader = new MediaTypeApiVersionReader("x-api-version");

                options.ApiVersionReader = ApiVersionReader.Combine(
                    urlSegmentVersionReader,
                    hearderVersionReader,
                    mediaTypeVersionReader
                );
            })
                .AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
