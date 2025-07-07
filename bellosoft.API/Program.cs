using bellosoft.Domain.Settings;
using bellosoft.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TMDBSettings>(
    builder.Configuration.GetSection("TMDB")
);

builder.Services.AddHttpClient<TMDBService>((sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<TMDBSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
