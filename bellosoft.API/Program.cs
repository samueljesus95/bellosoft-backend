using bellosoft.API.Configuration;
using bellosoft.API.Middlewares;
using bellosoft.Domain.Interfaces;
using bellosoft.Domain.Settings;
using bellosoft.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddVersioningApiConfig();

builder.Services.Configure<TMDBSettings>(
    builder.Configuration.GetSection("TMDB")
);

builder.Services.AddHttpClient<ITMDBService, TMDBService>((sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<TMDBSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
});

builder.Services.AddAuthenticationConfig(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwaggerConfig();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
