using bellosoft.API.Configuration;
using bellosoft.API.Middlewares;
using bellosoft.Domain.Interfaces;
using bellosoft.Domain.Settings;
using bellosoft.Infrastructure.Data.Context;
using bellosoft.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddVersioningApiConfig();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("AuthDb"));

builder.Services.Configure<JWTSettings>(
    builder.Configuration.GetSection("JWTSettings")
);
builder.Services.Configure<TMDBSettings>(
    builder.Configuration.GetSection("TMDB")
);

builder.Services.AddHttpClient<ITMDBService, TMDBService>((sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<TMDBSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthenticationConfig(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwaggerConfig();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
