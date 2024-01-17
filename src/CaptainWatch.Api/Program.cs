using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Middlewares;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using CaptainWatch.Api.Repository.Db.Movies;
using CaptainWatch.Api.Repository.Db.Series;
using CaptainWatch.Api.Services.Movies;
using CaptainWatch.Api.Services.Sitemaps;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.AddSecurityDefinition("Token", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "GUID",
        In = ParameterLocation.Header,
        Description = "Please insert your authorization token as GUID."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Token"
                }
            },
            new string[] {}
        }
    });
});

// Add services to the container.
builder.Services.AddAuthentication("CustomScheme")
    .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("CustomScheme", null);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection for services
builder.Services.AddScoped<IMovieServiceRead, MovieServiceRead>();
builder.Services.AddScoped<ISitemapServiceRead, SitemapServiceRead>();
builder.Services.AddScoped<IMovieServiceWrite, MovieServiceWrite>();

//dependency injection for repositories
builder.Services.AddScoped<IMovieRepo, MovieRepo>();
builder.Services.AddScoped<ISerieRepo, SerieRepo>();

//dependency injection for db context
builder.Services.AddDbContext<CaptainWatchContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
