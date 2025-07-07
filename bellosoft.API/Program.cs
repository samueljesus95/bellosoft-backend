using bellosoft.API.Middlewares;
using bellosoft.Domain.Interfaces;
using bellosoft.Domain.Settings;
using bellosoft.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TMDBSettings>(
    builder.Configuration.GetSection("TMDB")
);

builder.Services.AddHttpClient<ITMDBService, TMDBService>((sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<TMDBSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();
